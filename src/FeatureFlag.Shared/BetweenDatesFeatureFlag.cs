using System;
using System.Globalization;

namespace FeatureFlag
{
    public class BetweenDatesFeatureFlag : IFeatureFlag
    {
            public bool UseUtc { get; set; } = false;
            public  CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentUICulture;
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public bool IsEnabled
            {
                get
                {
                    var start = DateTime.Parse(StartDate, CultureInfo.DateTimeFormat);
                    var end = DateTime.Parse(EndDate, CultureInfo.DateTimeFormat);
                    var current = UseUtc ? DateTime.UtcNow : DateTime.Now;
                    return current >= start && current <= end;
                }
            }
    }
}