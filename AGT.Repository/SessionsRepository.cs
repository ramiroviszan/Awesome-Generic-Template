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
            var result = Context.Set<Session>().FirstOrDefault(e => e.Equals(entity));

            return result != null;
        }

        public override Session Find(int id)
        {
            var result = Context.Set<Session>()
                .FirstOrDefault(e => e.Id.Equals(id));

            if (result is null)
            {
                throw new EntityNotFoundException();
            }
            return result;
        }

        public override Session Find(Session entity)
        {
            var result = Context.Set<Session>().FirstOrDefault(e => e.Equals(entity));
            return result;
        }

        private DomainContext DomainContext
        {
            get { return Context as DomainContext; }
        }
    }
}
