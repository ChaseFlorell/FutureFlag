using System;

namespace FutureFlag
{
    public interface IFutureFlagConfiguration
    {
        IFutureFlagConfiguration OverrideAppVersion(string version);
        IFutureFlagConfiguration OverrideAppVersion(Version version);
        IFutureFlagConfiguration UtcNowProvider(Func<DateTime> provider);
        IFutureFlagConfiguration NowProvider(Func<DateTime> provider);
    }
}