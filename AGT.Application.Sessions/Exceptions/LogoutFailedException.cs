using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    public class LogoutFailedException : ApplicationSessionsException
    {
        public LogoutFailedException() : base("Failed to end session")
        {
        }

        public LogoutFailedException(Exception inner) : base("Failed to end session", inner)
        {
        }
    }
}