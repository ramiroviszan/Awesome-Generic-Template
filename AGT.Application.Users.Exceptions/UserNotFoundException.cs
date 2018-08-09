using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserNotFoundException : ApplicationUsersException
    {
        public UserNotFoundException() : base("User not found")
        {
        }

        public UserNotFoundException(Exception inner) : base("User not found", inner)
        {
        }
    }
}
