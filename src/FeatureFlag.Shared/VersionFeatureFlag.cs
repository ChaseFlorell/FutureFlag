using System;

namespace FeatureFlag
{
    public class VersionFeatureFlag : IFeatureFlag
    {
        private Lazy<VersionHelper> _appVersionHelper;
        private Version _version;

        public VersionFeatureFlag()
        {
            _appVersionHelper = new Lazy<VersionHelper>(() => new VersionHelper());
        }
        private Version RequestedVersion => _version ?? (_version = new Version(Version));
        public string Version { get; set; }
        public bool IsEnabled => RequestedVersion <= _appVersionHelper.Value.Version;
    }
}