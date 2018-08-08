using System;

namespace AGT.Domain.Users
{
    public class Feature : IEquatable<Feature>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Value { get; private set; }

        private Feature()
        {

        }

        public bool Equals(Feature feature)
        {
            if(feature is Feature)
            {
                Feature other = feature as Feature;
                return Name.Equals(other.Name) && Value.Equals(other.Value);
            }
            return false;
        }
    }
}