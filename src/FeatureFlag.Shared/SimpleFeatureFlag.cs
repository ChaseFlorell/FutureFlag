namespace FeatureFlag
{
    public class SimpleFeatureFlag : IFeatureFlag
    {
        public virtual bool IsEnabled { get; set; }
    }
}