using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserSignUpException : ApplicationUsersException
    {
        private const string MESSAGE = "Ups! Couldn't create the user, try again!";

        public UserSignUpException() : base(MESSAGE)
        {
        }

        public UserSignUpException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}
