using AGT.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DomainContext context;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(DomainContext aContext)
        {
            context = aContext;
            Users = new UserRepository(context);
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
