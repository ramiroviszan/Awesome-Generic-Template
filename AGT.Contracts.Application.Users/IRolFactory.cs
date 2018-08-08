using AGT.Domain.Users;

namespace AGT.Contracts.Application.Users
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