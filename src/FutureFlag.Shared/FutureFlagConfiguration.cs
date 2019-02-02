using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FutureFlag.Base;

namespace FutureFlag
{
    public class FutureFlagConfiguration : IFutureFlagConfiguration
    {
        private static bool _configured;
        private static readonly HashSet<string> _assertions = new HashSet<string>();

        private FutureFlagConfiguration(){ /* Private Constructor so that the user must use the static method */ }

        public IFutureFlagConfiguration NowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFutureFlag.SetNowProvider(provider);
            return this;
        }

        public IFutureFlagConfiguration UtcNowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFutureFlag.SetUtcNowProvider(provider);
            return this;
        }

        public IFutureFlagConfiguration OverrideAppVersion(string version)
        {
            AssertConfiguration();
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }

        public IFutureFlagConfiguration OverrideAppVersion(Version version)
        {
            AssertConfiguration();
            Base.VersionHelper.OverrideVersion(version);
            return this;
        }
        
        public static void Configure(Action<IFutureFlagConfiguration> config)
        {
            if(_configured)
                throw new InvalidOperationException("Configuration has already been run");
            
            _configured = true;
            
            var featureConfiguration = new FutureFlagConfiguration();
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