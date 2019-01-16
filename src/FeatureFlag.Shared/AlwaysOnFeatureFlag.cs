namespace FeatureFlag
{
    public class AlwaysOnFeatureFlag : IFeatureFlag
    {
        public bool IsEnabled => true;
    }
}