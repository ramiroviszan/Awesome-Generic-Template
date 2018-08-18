using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserAlreadyExistsException : ApplicationUsersException
    {
        private const string MESSAGE = "User already exists";
        public UserAlreadyExistsException() : base(MESSAGE)
        {
        }

        public UserAlreadyExistsException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}
