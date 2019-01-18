using System;
using Foundation;

namespace FeatureFlag
{
    public class VersionHelper
    {
        private static readonly Lazy<Version> _version = new Lazy<Version>(GetTouchVersion);
        public static Version Version => _version.Value;

        private static Version GetTouchVersion()
        {
            var versionString = NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
            return new Version(versionString);
        }
    }
}