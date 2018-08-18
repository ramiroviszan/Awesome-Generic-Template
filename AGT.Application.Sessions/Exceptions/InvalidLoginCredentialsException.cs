using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    public class InvalidLoginCredentialsException : ApplicationSessionsException
    {
        private const string MESSAGE = "Invalid username and password";
        public InvalidLoginCredentialsException() : base(MESSAGE)
        {
        }
    }
}