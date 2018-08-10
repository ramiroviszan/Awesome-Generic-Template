using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    [Serializable]
    internal class InvalidCredentialsException : ApplicationSessionsException
    {
        public InvalidCredentialsException() : base("Invalid username and password")
        {
        }

    }
}