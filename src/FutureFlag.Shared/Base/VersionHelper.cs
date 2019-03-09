using System;
using FutureFlag.Exceptions;

namespace FutureFlag.Base
{
    internal abstract class VersionHelper
    {        
        private static Version _version;
        private static bool _isVersionOverridden;
        private static Version _exactVersionToOverride;
        private static Func<Version> _versionProvider;

        internal Version ExactVersionToOverride => _exactVersionToOverride;
        internal Version Version => _version ?? (_version = GetVersionInternal());
        internal string VersionSource => _isVersionOverridden ? 
            $"{nameof(FutureFlagConfiguration)}.{nameof(FutureFlagConfiguration.VersionProvider)}" 
            : GetVersionSource();
        
        internal static void SetIsEnabledForExactVersion(Version version) 
            => _exactVersionToOverride = AssertNotDefault(() => version);

        protected abstract Version GetVersion();
        protected abstract string GetVersionSource();
        private Version GetVersionInternal() => _isVersionOverridden 
            ? AssertNotDefault(_versionProvider) 
            : AssertNotDefault(GetVersion);

        private static Version AssertNotDefault(Func<Version> versionProvider)
        {
            var version = versionProvider();
            if (version == default)
                throw new InvalidAppVersionException("Specified app version cannot be null or default. This probably means you've overridden a version value with `default(Version)` or `null`");

            return version;
        }

        internal static void VersionProvider(Func<Version> versionProvider)
        {
            _isVersionOverridden = true;
            _versionProvider = versionProvider;
        }
    }
}