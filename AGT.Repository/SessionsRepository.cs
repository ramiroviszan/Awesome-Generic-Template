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

        public override bool Exists(Session entity)
        {
            var result = Context.Set<Session>().FirstOrDefault(e => e.Token == entity.Token);

            return result != null;
        }

        public override Session Find(int id)
        {
            throw new EntityNotFoundException();
        }

        public override Session Find(Session entity)
        {
            var result = Context.Set<Session>().FirstOrDefault(e => e.Token == entity.Token);
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
