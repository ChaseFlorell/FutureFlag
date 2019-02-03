using System;

namespace FutureFlag
{
    public class VersionFutureFlag : IFutureFlag
    {
        private Version _version;
        private static VersionHelper _appVersionHelper;
        private VersionHelper AppVersionHelper => _appVersionHelper ?? (_appVersionHelper = new VersionHelper());
        private Version RequestedVersion => _version ?? (_version = new Version(Version));

        /// <summary>
        /// Get the source of the <see cref="ActualVersion"/>. This can come from a platform specific location or be overridden via <see cref="IFutureFlagConfiguration"/>
        /// </summary>
        public string VersionSource => _appVersionHelper.VersionSource;
        
        /// <summary>
        /// Gets the version specified by the executing application or overridden in config
        /// </summary>
        public Version ActualVersion => AppVersionHelper.Version;
        
        /// <summary>
        /// Gets or Sets the minimum version required to activate this feature flag
        /// </summary>
        public string Version { get; set; }
        
        /// <inheritdoc cref="IFutureFlag"/>
        public bool IsEnabled => RequestedVersion <= AppVersionHelper.Version;
    }
}