using System.Globalization;

namespace FeatureFlag.Base
{
    public abstract class DateFeatureFlag : IFeatureFlag
    {
        public bool UseUtc { get; set; } = false;
        public  CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentUICulture;
        public string Date { get; set; }
        public abstract bool IsEnabled { get; }
    }
}