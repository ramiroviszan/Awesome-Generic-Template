using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class EmptyRol : Rol
    {
        public string Name { get { return "Empty"; } }

        public override bool HasFeature(Feature feature)
        {
            return false;
        }
    }
}
