using System;

namespace FeatureFlag
{
    public class FeatureFlagConfiguration : IFeatureFlagConfiguration
    {
        public IFeatureFlagConfiguration OverrideAppVersion(string version)
        {
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }

        public IFeatureFlagConfiguration OverrideAppVersion(Version version)
        {
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }
        
        public static void Configure(Action<IFeatureFlagConfiguration> config)
        {
            var featureConfiguration = new FeatureFlagConfiguration();
            config(featureConfiguration);
        }
    }

    public interface IFeatureFlagConfiguration
    {
        IFeatureFlagConfiguration OverrideAppVersion(string version);
        IFeatureFlagConfiguration OverrideAppVersion(Version version);
    }
}