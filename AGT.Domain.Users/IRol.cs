namespace AGT.Domain.Users
{
    public interface IRol
    {
        void AddFeature(IFeature feature);
        void RemoveFeature(IFeature feature);
        void HasFeature(IFeature feature);
    }
}