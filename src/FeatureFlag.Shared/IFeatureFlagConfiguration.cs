using System;

namespace FeatureFlag
{
    public interface IFeatureFlagConfiguration
    {
        IFeatureFlagConfiguration OverrideAppVersion(string version);
        IFeatureFlagConfiguration OverrideAppVersion(Version version);
    }
}