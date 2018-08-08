using AGT.Domain.Users;

namespace AGT.Application.Users
{
    public interface IUserService
    {
        void SignUp(User user);
    }
}