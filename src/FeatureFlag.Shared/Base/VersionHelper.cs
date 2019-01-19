using System;

namespace FeatureFlag.Base
{
    public abstract class VersionHelper
    {        
        private static Version _version;
        private static bool _isVersionOverridden;
        private static Version _overriddenVersion;
        private static VersionHelper _context;

        protected VersionHelper()
        {
            _context = _context ?? this;
        }
        
        public static Version Version => _version ?? (_version = GetVersionInternal(_context));

        public static void OverrideVersion(string version) => OverrideVersion(new Version(version));

        public static void OverrideVersion(Version version)
        {
            _isVersionOverridden = true;
            _overriddenVersion = version;
        }

        private static Version GetVersionInternal(VersionHelper context) => _isVersionOverridden ? _overriddenVersion : context.GetVersion();
        protected abstract Version GetVersion();
    }
}