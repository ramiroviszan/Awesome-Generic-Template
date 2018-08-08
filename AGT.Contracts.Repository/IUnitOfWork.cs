using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        void Complete();
    }
}
