namespace AGT.Domain.Users
{
    public interface IRol
    {
        string Name { get; } 
        void AddFeature(IFeature feature);
        void RemoveFeature(IFeature feature);
        bool HasFeature(IFeature feature);
    }
}