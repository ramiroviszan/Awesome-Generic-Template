using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUsersRepository Users { get; }
        ISessionsRepository Sessions { get; }
        void Complete();
    }
}
