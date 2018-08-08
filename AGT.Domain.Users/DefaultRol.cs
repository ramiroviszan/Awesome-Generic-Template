using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class DefaultRol : IRol
    {
        public string Name { get { return "Default"; } }
        public ICollection<IFeature> Features { get; private set; }

        public DefaultRol()
        {
            Features = new List<IFeature>();
        }

        public void AddFeature(IFeature feature)
        {
            Features.Add(feature);
        }

        public bool HasFeature(IFeature feature)
        {
            return Features.Contains(feature);
        }

        public void RemoveFeature(IFeature feature)
        {
            Features.Remove(feature);
        }
    }
}
