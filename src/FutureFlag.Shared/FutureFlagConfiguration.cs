using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FutureFlag.Base;
using FutureFlag.Exceptions;

namespace FutureFlag
{
    /// <summary>
    /// Configure how you want your <see cref="IFutureFlag"/>s to behave
    /// </summary>
    public class FutureFlagConfiguration
    {
        private static bool _configured;
        private static readonly HashSet<string> _assertions = new HashSet<string>();

        private FutureFlagConfiguration(){ /* Private Constructor so that the user must use the static method */ }

        /// <summary>Overrides the way the library acquires Now</summary>
        /// <param name="provider">Provider used to determine Now</param>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to override the Now provider more than once</exception>
        public FutureFlagConfiguration NowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFutureFlag.SetNowProvider(provider);
            return this;
        }


        /// <summary>Overrides the way the library acquires UtcNow</summary>
        /// <param name="provider">Provider used to determine UtcNow</param>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to override the UtcNow provider more than once</exception>
        public FutureFlagConfiguration UtcNowProvider(Func<DateTime> provider)
        {
            AssertConfiguration();
            DateFutureFlag.SetUtcNowProvider(provider);
            return this;
        }

        /// <summary>
        /// Overrides how the FutureFlag configuration finds you app version.
        /// </summary>
        /// <param name="versionProvider">Provider used to determine app version</param>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to override the Version provider more than once</exception>
        public FutureFlagConfiguration VersionProvider(Func<Version> versionProvider)
        {
            AssertConfiguration();
            Base.VersionHelper.VersionProvider(versionProvider);
            return this;
        }

        /// <summary>Indicates an exact version you want to set <see cref="p:IFutureFlag.IsEnabled"/> = <c>true</c> for.</summary>
        /// <param name="version">A <see cref="System.String"/> representation of the version</param>
        /// <remarks>This is useful for development purposes in order to ensure you can see future features</remarks>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to set the IsEnabled for exact version more than once</exception>
        /// <exception cref="InvalidAppVersionException">Thrown when you specify <c>null</c> or <c>default(Version)</c></exception>
        public FutureFlagConfiguration SetIsEnabledForExactVersion(string version) 
            => SetIsEnabledForExactVersion(new Version(version));

        /// <summary>Indicates an exact version you want to set <see cref="p:IFutureFlag.IsEnabled"/> = <c>true</c> for.</summary>
        /// <param name="version">A <see cref="System.Version"/> representation of the version</param>
        /// <remarks>This is useful for development purposes in order to ensure you can see future features</remarks>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to set the IsEnabled for exact version more than once</exception>
        /// <exception cref="InvalidAppVersionException">Thrown when you specify <c>null</c> or <c>default(Version)</c></exception>
        public FutureFlagConfiguration SetIsEnabledForExactVersion(Version version)
        {
            if(version == default)
                throw new InvalidAppVersionException("You must specify an actual version to enable.");
            AssertConfiguration();
            Base.VersionHelper.SetIsEnabledForExactVersion(version);
            return this;
        }
        
        /// <summary>
        /// Invokes the configuration, this can only be run once
        /// </summary>
        /// <param name="config">An instance of <see cref="FutureFlagConfiguration"/></param>
        /// <exception cref="InvalidOperationException">Thrown when a user tries to define <see cref="M:Config"/> more than once</exception>
        public static void Configure(Action<FutureFlagConfiguration> config)
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
                throw new InvalidOperationException($"{methodName} can only be configured once" );

            _assertions.Add(methodName);
        }
    }
}