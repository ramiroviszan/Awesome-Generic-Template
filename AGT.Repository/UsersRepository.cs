using AGT.Domain.Users;
using System;
using AGT.Repository;
using AGT.Contracts.Repository;
using AGT.Repository.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AGT.Repository
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
   
        public UsersRepository(DomainContext context) : base(context)
        {
        }

        public override bool Exists(User entity)
        {
            var result = Context.Set<User>().FirstOrDefault(e => e.Equals(entity));

            return result != null;
        }

        public override User Find(int id)
        {
            var result = Context.Set<User>()
                .Include(e => e.Roles)
                .ThenInclude(r => r.Features)
                .FirstOrDefault(u => u.Id.Equals(id));

            if (result is null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }

        public override User Find(User entity)
        {
            var result = Context.Set<User>().FirstOrDefault(e => e.Equals(entity));
            return result;
        }

        private DomainContext DomainContext
        {
            get { return Context as DomainContext; }
        }
    }
}
