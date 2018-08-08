using AGT.Domain.Users;
using AGT.Contracts.Application.Users;
using AGT.Contracts.Repository;
using AGT.Application.Users.Exceptions;

namespace AGT.Application.Users
{
    public class UserService : IUserService
    {
        private IUnitOfWork repositories;
        private IRolFactory rolFactory;

        public UserService(IUnitOfWork unit, IRolFactory factory)
        {
            repositories = unit;
            rolFactory = factory;
        }

        public void SignUp(User user)
        {
            if(repositories.Users.Exists(user))
            {
                throw new UserAlreadyExistsException();
            }
            user.AddRol(rolFactory.Create(RolEnum.DEFAULT));
            repositories.Users.Add(user);
        }
    }
}
