using System;

namespace FeatureFlag
{
    public class VersionHelper
    {
        private static readonly Lazy<Version> _version = new Lazy<Version>(GetTouchVersion);
        public static Version Version => _version.Value;

        private static Version GetTouchVersion()
        {
            var versionString = global::Android.App.Application.Context.PackageManager.GetPackageInfo(global::Android.App.Application.Context.PackageName, 0).VersionName;
            return new Version(versionString);
        }    
    }
}