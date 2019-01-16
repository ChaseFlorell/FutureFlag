using System;
using FeatureFlag.Base;

namespace FeatureFlag
{
    public class OnOrBeforeDateFeatureFlag : DateFeatureFlag
    {
        public override bool IsEnabled =>(UseUtc? DateTime.UtcNow : DateTime.Now) <= DateTime.Parse(Date, CultureInfo.DateTimeFormat);
    }
}