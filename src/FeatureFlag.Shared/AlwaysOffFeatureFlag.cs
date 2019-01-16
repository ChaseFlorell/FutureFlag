namespace FeatureFlag
{
    public class AlwaysOffFeatureFlag : IFeatureFlag
    {
        public bool IsEnabled => false;
    }
}