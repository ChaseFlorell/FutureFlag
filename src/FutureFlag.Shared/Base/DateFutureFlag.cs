using System;
using System.Globalization;

namespace FutureFlag.Base
{
    public abstract class DateFutureFlag : IFutureFlag
    {
        private static Func<DateTime> _utcNowProvider;
        private static Func<DateTime> _nowProvider;
        private static bool _useUtcByDefault;

        internal static void SetUtcNowProvider(Func<DateTime> provider) => _utcNowProvider = provider;
        internal static void SetNowProvider(Func<DateTime> provider) => _nowProvider = provider;
        internal static void UseUtcByDefault(bool useUtc) => _useUtcByDefault = useUtc;

        protected DateTime UtcNow => _utcNowProvider?.Invoke() ?? DateTime.UtcNow;
        protected DateTime Now => _nowProvider?.Invoke() ?? DateTime.Now;

        public bool UseUtc { get; set; } = _useUtcByDefault;

        public  CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentUICulture;
        
        public abstract bool IsEnabled { get; }
    }
}