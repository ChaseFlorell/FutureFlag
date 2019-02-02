using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FeatureFlag.Base;

namespace FeatureFlag
{
    public class FeatureFlagConfiguration : IFeatureFlagConfiguration
    {
        private static bool _configured;
        private static readonly HashSet<string> _assertions = new HashSet<string>();

        private FeatureFlagConfiguration(){ /* Private Constructor so that the user must use the static method */ }

        public IFeatureFlagConfiguration NowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFeatureFlag.SetNowProvider(provider);
            return this;
        }

        public IFeatureFlagConfiguration UtcNowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFeatureFlag.SetUtcNowProvider(provider);
            return this;
        }

        public IFeatureFlagConfiguration OverrideAppVersion(string version)
        {
            AssertConfiguration();
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }

        public IFeatureFlagConfiguration OverrideAppVersion(Version version)
        {
            AssertConfiguration();
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }
        
        public static void Configure(Action<IFeatureFlagConfiguration> config)
        {
            if(_configured)
                throw new InvalidOperationException("Configuration has already been run");
            
            _configured = true;
            
            var featureConfiguration = new FeatureFlagConfiguration();
            config(featureConfiguration);
        }
        
        private static void AssertConfiguration([CallerMemberName] string methodName = null)
        {
            if(_assertions.Contains(methodName))
                throw new ArgumentException($"{methodName} can only be configured once" );

            _assertions.Add(methodName);
        }
    }
}