using AGT.Domain.Users;

namespace AGT.Application.Users
{
    public enum RolEnum
    {
        DEFAULT
    }

    public interface IRolFactory
    {
        IRol Create(RolEnum rolName);
    }
}