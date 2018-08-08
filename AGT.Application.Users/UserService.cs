using AGT.Contracts.DataAccess;
using AGT.Domain.Users;
using System;

namespace AGT.Application.Users
{
    public class UserService : IUserService
    {
        private IBaseDataAccess<User> repository;

        public UserService(IBaseDataAccess<User> repo)
        {
            repository = repo;
        }

        public void SignUp(User user)
        {
            if (repository.Exists(user))
                throw new Exception();

            repository.Add(user);
        }
    }
}
