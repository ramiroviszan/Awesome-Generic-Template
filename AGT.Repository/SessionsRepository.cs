using AGT.Domain.Users;
using System;
using AGT.Repository;
using AGT.Contracts.Repository;
using AGT.Repository.Exceptions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AGT.Domain.Sessions;

namespace AGT.Repository
{
    public class SessionsRepository : BaseRepository<Session>, ISessionsRepository
    {
   
        public SessionsRepository(DomainContext context) : base(context)
        {
        }

        protected override bool TryExists(Session entity)
        {
            var result = Context.Set<Session>().FirstOrDefault(e => e.Token == entity.Token);

            return result != null;
        }

        protected override Session TryFind(int id)
        {
            throw new EntityNotFoundException();
        }

        protected override Session TryFind(Session entity)
        {
            var result = Context.Set<Session>().FirstOrDefault(e => e.Token == entity.Token);
            if (result is null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }
    }
}
