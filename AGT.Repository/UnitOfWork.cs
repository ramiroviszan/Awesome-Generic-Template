using AGT.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainContext context;

        public IUsersRepository Users { get; private set; }

        public ISessionsRepository Sessions { get; private set; }

        public UnitOfWork(DomainContext aContext)
        {
            context = aContext;
            Users = new UsersRepository(context);
            Sessions = new SessionsRepository(context);
        }
     
        public void Dispose()
        {
            context.Dispose();
        }

        public void Complete()
        {
            context.SaveChanges();
        }
    }
}
