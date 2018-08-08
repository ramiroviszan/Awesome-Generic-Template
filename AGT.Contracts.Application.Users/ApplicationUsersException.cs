using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Contracts.Application.Users
{
    public class ApplicationUsersException : Exception
    {
        public ApplicationUsersException(string message) : base(message) {
        }
    }
}
