using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class EmptyRol : Rol
    {
        public override int Id { get; protected set; }
        public string Name { get { return "Empty"; } }

        public override void AddFeature(Feature feature)
        {
        }

        public override bool HasFeature(Feature feature)
        {
            return false;
        }

        public override void RemoveFeature(Feature feature)
        {
        }
    }
}
