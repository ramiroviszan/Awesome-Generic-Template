using System;
using System.Collections.Generic;
using System.Text;

namespace AGT.Domain.Users
{
    public class DefaultRol : Rol
    {
        public override int Id { get; protected set; }
        public string Name { get { return "Default"; } }
        public ICollection<Feature> Features { get; protected set; }

        public DefaultRol()
        {
            Features = new List<Feature>();
        }

        public override void AddFeature(Feature feature)
        {
            Features.Add(feature);
        }

        public override bool HasFeature(Feature feature)
        {
            return Features.Contains(feature);
        }

        public override void RemoveFeature(Feature feature)
        {
            Features.Remove(feature);
        }
    }
}
