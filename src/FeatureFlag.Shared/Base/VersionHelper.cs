using System;

namespace FeatureFlag.Base
{
    public abstract class VersionHelper
    {        
        private Version _version;
        private static bool _isVersionOverridden;
        private static Version _overriddenVersion;
        
        public Version Version => _version ?? (_version = GetVersionInternal());

        public static void OverrideVersion(string version) => OverrideVersion(new Version(version));

        public static void OverrideVersion(Version version)
        {
            _isVersionOverridden = true;
            _overriddenVersion = version;
        }

        private Version GetVersionInternal() => _isVersionOverridden ? _overriddenVersion : GetVersion();
        protected abstract Version GetVersion();
    }
}