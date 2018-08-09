using System.Collections.Generic;

namespace AGT.Domain.Users
{
    public abstract class Rol
    {
        public int Id { get; private set; }
        public ICollection<Feature> Features { get; private set; }

        public Rol()
        {
            Features = new List<Feature>();
        }

        public virtual void AddFeature(Feature feature)
        {
            Features.Add(feature);
        }

        public virtual bool HasFeature(Feature feature)
        {
            return Features.Contains(feature);
        }

        public virtual void RemoveFeature(Feature feature)
        {
            Features.Remove(feature);
        }
    }
}