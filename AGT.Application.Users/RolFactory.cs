using System;
using System.Collections.Generic;
using System.Text;
using AGT.Contracts.Application.Users;
using AGT.Domain.Users;

namespace AGT.Application.Users
{
    public class RolFactory : IRolFactory
    {
        public RolFactory()
        {

        }

        public Rol Create(RolEnum rolName)
        {
            switch (rolName)
            {
                case RolEnum.DEFAULT:
                    return new DefaultRol();
                default:
                    return new EmptyRol();
            };
        }
    }
}
