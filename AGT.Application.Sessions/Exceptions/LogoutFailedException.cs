using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    public class LogoutFailedException : ApplicationSessionsException
    {
        private const string MESSAGE = "Failed to end session";
        public LogoutFailedException() : base(MESSAGE)
        {
        }

        public LogoutFailedException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}