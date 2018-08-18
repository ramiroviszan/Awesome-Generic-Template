using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserNotFoundException : ApplicationUsersException
    {
        private const string MESSAGE = "Ups! User not found, try again!";

        public UserNotFoundException() : base(MESSAGE)
        {
        }

        public UserNotFoundException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}
