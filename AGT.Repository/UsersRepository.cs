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

        protected override bool TryExists(User entity)
        {
            var result = Context.Set<User>().FirstOrDefault(e => e.Username == entity.Username);
            return result != null;
        }

        protected override User TryFind(int id)
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

        protected override User TryFind(User entity)
        {
            var result = Context.Set<User>().FirstOrDefault(e => e.Username == entity.Username);
            if (result is null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }

    }
}
