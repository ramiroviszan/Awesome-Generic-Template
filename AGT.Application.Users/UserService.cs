using AGT.Domain.Users;
using AGT.Contracts.Application.Users;
using AGT.Contracts.Repository;
using AGT.Application.Users.Exceptions;
using AGT.Contracts.CrossCutting;

namespace AGT.Application.Users
{
    public class UserService : IUserService
    {
        private IUnitOfWork repositories;
        private IRolFactory rolFactory;
        private IHashGenerator hashGenerator;

        public UserService(IUnitOfWork unit, IRolFactory factory, IHashGenerator generator)
        {
            repositories = unit;
            rolFactory = factory;
            hashGenerator = generator;
        }

        public User GetUser(int id)
        {
            try
            {
                return TryGetUser(id);
            } catch (RepositoryException e)
            {
                throw new UserNotFoundException(e);
            }
        }
        protected virtual User TryGetUser(int id) {
            var user = repositories.Users.Find(id);
            return user;
        }

        public User SignUp(User user)
        {
            try
            {
                return TrySignUp(user);
            } catch (RepositoryException e)
            {
                throw new UserSignUpException(e);
            }
        }
        protected virtual User TrySignUp(User user) {
            if(repositories.Users.Exists(user))
            {
                throw new UserAlreadyExistsException();
            }

            user.PasswordSalt = hashGenerator.GetRandomSalt();
            user.Password = hashGenerator.GetHash(user.Password, user.PasswordSalt);

            user.AddRol(rolFactory.Create(RolEnum.DEFAULT));

            repositories.Users.Add(user);
            repositories.Complete();

            return user;
        }

        public User ChangeProfileImage(int id, string path)
        {
            try
            {
                return TryChangeProfileImage(id, path);
            } catch (RepositoryException e)
            {
                throw new UserChangeProfileImageException(e);
            }
        }
        protected virtual User TryChangeProfileImage(int id, string path) {
            var user = GetUser(id);
            user.ProfileImage = path;
            repositories.Complete();
            return user;
        }

    }
}
