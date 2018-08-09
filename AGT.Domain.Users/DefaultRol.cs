using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class DefaultRol : Rol
    {
        public string Name { get { return "Default"; } }

        public DefaultRol() : base()
        {
        }
    }
}
