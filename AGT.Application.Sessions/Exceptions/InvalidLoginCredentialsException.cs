using AGT.Contracts.Application.Sessions;
using System;
using System.Runtime.Serialization;

namespace AGT.Application.Sessions.Exceptions
{
    public class InvalidLoginCredentialsException : ApplicationSessionsException
    {
        public InvalidLoginCredentialsException() : base("Invalid username and password")
        {
        }
    }
}