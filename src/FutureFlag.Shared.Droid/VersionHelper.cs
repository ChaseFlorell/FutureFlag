using System;

namespace FutureFlag
{
    internal class VersionHelper: Base.VersionHelper
    {       
        protected override Version GetVersion()
        {
            var versionString = global::Android.App.Application.Context.PackageManager.GetPackageInfo(global::Android.App.Application.Context.PackageName, 0).VersionName;
            return new Version(versionString);
        }

        protected override string GetVersionSource() => $"Android {nameof(Android.Content.PM.PackageInfo.VersionName)}";
    }
}