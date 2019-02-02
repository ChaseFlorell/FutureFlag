using System;

namespace FeatureFlag
{
    public interface IFeatureFlagConfiguration
    {
        IFeatureFlagConfiguration OverrideAppVersion(string version);
        IFeatureFlagConfiguration OverrideAppVersion(Version version);
        IFeatureFlagConfiguration UtcNowProvider(Func<DateTime> provider);
        IFeatureFlagConfiguration NowProvider(Func<DateTime> provider);
    }
}