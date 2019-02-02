using System;
using System.Globalization;

namespace FutureFlag.Base
{
    public abstract class DateFutureFlag : IFutureFlag
    {
        private static Func<DateTime> _utcNowProvider;
        private static Func<DateTime> _nowProvider;
        internal static void SetUtcNowProvider(Func<DateTime> provider) => _utcNowProvider = provider;
        internal static void SetNowProvider(Func<DateTime> provider) => _nowProvider = provider;

        protected DateTime UtcNow => _utcNowProvider?.Invoke() ?? DateTime.UtcNow;
        protected DateTime Now => _nowProvider?.Invoke() ?? DateTime.UtcNow;
        public bool UseUtc { get; set; } = false;
        public  CultureInfo CultureInfo { get; set; } = CultureInfo.CurrentUICulture;
        
        public abstract bool IsEnabled { get; }
    }
}