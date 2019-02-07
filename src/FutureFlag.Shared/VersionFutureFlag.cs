using System;

namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag for when the current version of your application is greater than or equal the specified version
    /// </summary>
    /// <remarks>
    /// There are some platform specific tricks that will acquire the current version of the application from the Info.plist (iOS),
    /// App Manifest (Android), or the Executing Assembly (netstandard). These values can be overridden in the <see cref="FutureFlagConfiguration"/>
    /// </remarks>
    public class VersionFutureFlag : IFutureFlag
    {
        private Version _version;
        private static VersionHelper _appVersionHelper;
        private VersionHelper AppVersionHelper => _appVersionHelper ?? (_appVersionHelper = new VersionHelper());
        private Version RequestedVersion => _version ?? (_version = new Version(Version));

        /// <summary>
        /// Get the source of the <see cref="ActualVersion"/>. This can come from a platform specific location or be overridden via <see cref="FutureFlagConfiguration"/>
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
        /// <returns><c>true</c> if the current version is greater than or equal to the requested <see cref="Version"/> otherwise <c>false</c></returns>
        public bool IsEnabled => AppVersionHelper.Version == AppVersionHelper.ExactVersionToOverride 
                                 || AppVersionHelper.Version >= RequestedVersion;
    }
}