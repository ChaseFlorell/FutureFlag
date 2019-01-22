using System;

namespace FeatureFlag
{
    public class FeatureFlagConfiguration : IFeatureFlagConfiguration
    {
        private static bool _appVersionAlreadyOverridden;
        private static bool _configured;

        private FeatureFlagConfiguration(){ /* Private Constructor so that the user must use the static method */ }
        
        public IFeatureFlagConfiguration OverrideAppVersion(string version)
        {
            if(_appVersionAlreadyOverridden)
                throw new ArgumentException("App Version already overridden",nameof(version));

            _appVersionAlreadyOverridden = true;
            
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }

        public IFeatureFlagConfiguration OverrideAppVersion(Version version)
        {
            if(_appVersionAlreadyOverridden)
                throw new ArgumentException("App Version already overridden",nameof(version));
            
            _appVersionAlreadyOverridden = true;
            
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }
        
        public static void Configure(Action<IFeatureFlagConfiguration> config)
        {
            if(_configured)
                throw new InvalidOperationException("Configuration has already been run.");
            
            _configured = true;
            
            var featureConfiguration = new FeatureFlagConfiguration();
            config(featureConfiguration);
        }
    }
}