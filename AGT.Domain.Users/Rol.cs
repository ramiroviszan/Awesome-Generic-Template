namespace AGT.Domain.Users
{
    public abstract class Rol
    {
        public abstract int Id { get; protected set; }
        public abstract void AddFeature(Feature feature);
        public abstract bool HasFeature(Feature feature);
        public abstract void RemoveFeature(Feature feature);
    }
}