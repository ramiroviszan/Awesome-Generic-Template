using AGT.Contracts.Application.Users;
using System;

namespace AGT.Application.Users.Exceptions
{
    public class UserChangeProfileImageException : ApplicationUsersException
    {
        private const string MESSAGE = "Ups! Couldn't change your picture, try again!";
        
        public UserChangeProfileImageException() : base(MESSAGE)
        {
        }

        public UserChangeProfileImageException(Exception inner) : base(MESSAGE, inner)
        {
        }
    }
}
