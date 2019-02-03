using System;

namespace FutureFlag.Base
{
    internal abstract class VersionHelper
    {        
        private static Version _version;
        private static bool _isVersionOverridden;
        private static Version _overriddenVersion;
        
        internal Version Version => _version ?? (_version = GetVersionInternal());
        internal string VersionSource => _isVersionOverridden ? 
            $"{nameof(FutureFlagConfiguration)}.{nameof(FutureFlagConfiguration.OverrideAppVersion)}" 
            : GetVersionSource();

        internal static void OverrideVersion(string version) => OverrideVersion(new Version(version));

        internal static void OverrideVersion(Version version)
        {
            _isVersionOverridden = true;
            _overriddenVersion = version;
        }

        protected abstract Version GetVersion();
        protected abstract string GetVersionSource();
        private Version GetVersionInternal() => _isVersionOverridden ? _overriddenVersion : GetVersion();
    }
}