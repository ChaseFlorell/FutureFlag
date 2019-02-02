using System;

namespace FutureFlag
{
    public class VersionFutureFlag : IFutureFlag
    {
        private Version _version;
        private static VersionHelper _appVersionHelper;
        private VersionHelper AppVersionHelper => _appVersionHelper ?? (_appVersionHelper = new VersionHelper());
        private Version RequestedVersion => _version ?? (_version = new Version(Version));
        public string Version { get; set; }
        public bool IsEnabled => RequestedVersion <= AppVersionHelper.Version;
    }
}