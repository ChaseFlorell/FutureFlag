using System;
using Foundation;

namespace FutureFlag
{
    public class VersionHelper : Base.VersionHelper
    {
        protected override Version GetVersion()
        {
            var versionString = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
            return new Version(versionString);
        }
    }
}