namespace FeatureFlag
{
    public interface IFeatureFlag
    {
        bool IsEnabled { get; }
    }
}