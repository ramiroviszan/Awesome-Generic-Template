using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserAlreadyExistsException : ApplicationUsersException
    {
        public UserAlreadyExistsException() : base("User already exists")
        {
        }

        public UserAlreadyExistsException(Exception inner) : base("User already exists", inner)
        {
        }
    }
}
