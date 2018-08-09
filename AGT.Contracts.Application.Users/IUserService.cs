using AGT.Domain.Users;

namespace AGT.Contracts.Application.Users
{
    public interface IUserService
    {
        User GetUser(int id);
        User SignUp(User user);
    }
}