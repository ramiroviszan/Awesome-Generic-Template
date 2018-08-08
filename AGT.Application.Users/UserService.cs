using AGT.Contracts.DataAccess;
using AGT.Application.Users.Exceptions;
using AGT.Domain.Users;
using System;
using AGT.Contracts.Application.Users;

namespace AGT.Application.Users
{
    public class UserService : IUserService
    {
        private IBaseDataAccess<User> repository;
        private IRolFactory rolFactory;

        public UserService(IBaseDataAccess<User> repo, IRolFactory factory)
        {
            repository = repo;
            rolFactory = factory;
        }

        public void SignUp(User user)
        {
            if (repository.Exists(user))
                throw new UserAlreadyExistsException();

            user.AddRol(rolFactory.Create(RolEnum.DEFAULT));

            repository.Add(user);
        }

    }
}
