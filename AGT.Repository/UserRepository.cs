using AGT.Domain.Users;
using System;
using AGT.Repository;
using AGT.Contracts.Repository;
using AGT.Repository.Exceptions;
using System.Linq;

namespace AGT.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
   
        public UserRepository(DomainContext context) : base(context)
        {
        }

        public override bool Exists(User entity)
        {
            User result = Context.Set<User>().FirstOrDefault(e => e.Equals(entity));
            return result != null;
        }

        public override User Find(User entity)
        {
            User result = Context.Set<User>().Find(entity.Id);
            if (result is null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }

        private DomainContext DomainContext
        {
            get { return Context as DomainContext; }
        }
    }
}
