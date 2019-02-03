using System;
using Foundation;

namespace FutureFlag
{
    internal class VersionHelper : Base.VersionHelper
    {
        private const string _plistKey = "CFBundleVersion";
        protected override Version GetVersion()
        {
            var versionString = NSBundle.MainBundle.InfoDictionary[new NSString(_plistKey)].ToString();
            return new Version(versionString);
        }

        protected override string GetVersionSource() => $"iOS {_plistKey}";
    }
}