using System;

namespace FutureFlag
{
    public class VersionHelper: Base.VersionHelper
    {       
        protected override Version GetVersion()
        {
            var versionString = global::Android.App.Application.Context.PackageManager.GetPackageInfo(global::Android.App.Application.Context.PackageName, 0).VersionName;
            return new Version(versionString);
        }
    }
}