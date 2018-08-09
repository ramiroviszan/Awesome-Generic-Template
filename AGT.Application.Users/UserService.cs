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

        public User GetUser(int id)
        {
            try
            {
                var user = repositories.Users.Find(id);
                return user;
            } catch (RepositoryException e)
            {
                throw new UserNotFoundException(e);
            }
        }

        public User SignUp(User user)
        {
            if(repositories.Users.Exists(user))
            {
                throw new UserAlreadyExistsException();
            }
            user.AddRol(rolFactory.Create(RolEnum.DEFAULT));
            repositories.Users.Add(user);
            repositories.Complete();
            return user;
        }

        public User ChangeProfileImage(int id, string path)
        {
            var user = GetUser(id);
            user.ProfileImage = path;
            repositories.Complete();

            return user;
        }

    }
}
