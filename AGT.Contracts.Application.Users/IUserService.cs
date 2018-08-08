using AGT.Domain.Users;

namespace AGT.Contracts.Application.Users
{
    public interface IUserService
    {
        void SignUp(User user);
    }
}