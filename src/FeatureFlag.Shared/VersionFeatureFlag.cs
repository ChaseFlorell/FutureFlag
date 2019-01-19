using System;

namespace FeatureFlag
{
    public class VersionFeatureFlag : IFeatureFlag
    {
        private Version _version;
        private Version RequestedVersion => _version ?? (_version = new Version(Version));
        public string Version { get; set; }
        public bool IsEnabled => RequestedVersion <= Base.VersionHelper.Version;
    }
}