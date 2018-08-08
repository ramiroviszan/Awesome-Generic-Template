using AGT.Contracts.DataAccess;
using AGT.Domain.Users;
using System;

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
                throw new Exception();

            user.AddRol(rolFactory.Create(RolEnum.DEFAULT));

            repository.Add(user);
        }

    }
}
