using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    public class LoginFailedException : ApplicationSessionsException
    {
        private const string MESSAGE = "Ups! Failed to log in, try again!";
        public LoginFailedException() : base(MESSAGE)
        {
        }

        public LoginFailedException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}