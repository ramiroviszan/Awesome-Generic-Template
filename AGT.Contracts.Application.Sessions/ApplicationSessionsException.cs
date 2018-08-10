using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.Application.Sessions
{
    public abstract class ApplicationSessionsException : Exception
    {
        public ApplicationSessionsException(string message) : base(message)
        {
        }

        public ApplicationSessionsException(string message, Exception inner) : base(message, inner) {
        }
    }
}
