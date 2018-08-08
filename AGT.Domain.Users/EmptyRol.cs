using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class EmptyRol : IRol
    {
        public string Name { get { return "Empty"; } }

        public void AddFeature(IFeature feature)
        {
        }

        public bool HasFeature(IFeature feature)
        {
            return false;
        }

        public void RemoveFeature(IFeature feature)
        {
        }
    }
}
