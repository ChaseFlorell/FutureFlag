using System;
using System.Reflection;

namespace FeatureFlag
{
    public class VersionHelper
    {
        private static Version _version;
        public static Version Version => _version ?? (_version = Assembly.GetExecutingAssembly().GetName().Version);
    }
}