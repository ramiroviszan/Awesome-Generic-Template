using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.Application.Users
{
    public class ApplicationUsersException : Exception
    {
        public ApplicationUsersException(string message) : base(message)
        {
        }

        public ApplicationUsersException(string message, Exception inner) : base(message, inner) {
        }
    }
}
