using System;
using System.Reflection;

namespace FutureFlag
{
    public class VersionHelper : Base.VersionHelper
    {
        protected override Version GetVersion() => Assembly.GetExecutingAssembly().GetName().Version;
    }
}