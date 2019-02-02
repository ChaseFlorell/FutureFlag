using System;
using FeatureFlag.Base;

namespace FeatureFlag
{
    public class OnOrBeforeDateFeatureFlag : DateFeatureFlag
    {
        public string Date { get; set; }
        public override bool IsEnabled =>(UseUtc? UtcNow : Now) <= DateTime.Parse(Date, CultureInfo.DateTimeFormat);
    }
}