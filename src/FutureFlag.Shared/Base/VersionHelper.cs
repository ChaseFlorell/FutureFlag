using System;
using FutureFlag.Exceptions;

namespace FutureFlag.Base
{
    internal abstract class VersionHelper
    {        
        private static Version _version;
        private static bool _isVersionOverridden;
        private static Version _overriddenVersion;
        private static Version _exactVersionToOverride;

        internal Version ExactVersionToOverride => _exactVersionToOverride;
        internal Version Version => _version ?? (_version = GetVersionInternal());
        internal string VersionSource => _isVersionOverridden ? 
            $"{nameof(FutureFlagConfiguration)}.{nameof(FutureFlagConfiguration.OverrideAppVersion)}" 
            : GetVersionSource();

        internal static void OverrideVersion(Version version)
        {
            _isVersionOverridden = true;
            _overriddenVersion = version;
        }
        
        internal static void SetIsEnabledForExactVersion(Version version)
        {
            _exactVersionToOverride = AssertNotDefault(() => version);
        }

        protected abstract Version GetVersion();
        protected abstract string GetVersionSource();
        private Version GetVersionInternal() => _isVersionOverridden 
            ? AssertNotDefault(() => _overriddenVersion) 
            : AssertNotDefault(GetVersion);

        private static Version AssertNotDefault(Func<Version> getVersion)
        {
            var version = getVersion();
            if (version == default)
                throw new InvalidAppVersionException("Specified app version cannot be null or default. This probably means you've overridden a version value with `default(Version)` or `null`");

            return version;
        }
    }
}