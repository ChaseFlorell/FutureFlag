using System;
using FutureFlag.Internal;

namespace FutureFlag
{
    /// <summary>
    /// Defines an <see cref="IFutureFlag"/> whereby we can cache the child Flag for a given duration
    /// </summary>
    /// <inheritdoc cref="IFutureFlag"/>
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(FutureFlag))]
#endif
    public class CachedFutureFlagProvider : IFutureFlag
    {
        private Cached<bool> _temp;
        private bool _validated;
        
        private Cached<bool> Temp => _temp ?? (_temp = new Cached<bool>(UpdateCheckTimeAndReturnFlagValue, CacheDuration)); 
        
        /// <summary>
        /// Future Flag to cache
        /// </summary>
        public IFutureFlag FutureFlag { get; set; }
        
        /// <summary>
        /// Duration to retain the cached value before re-checking the <see cref="FutureFlag"/>
        /// </summary>
        public TimeSpan CacheDuration { get; set; }

        ///<inheritdoc cref="IFutureFlag.IsEnabled"/>
        public bool IsEnabled => Temp.Value;

        private bool UpdateCheckTimeAndReturnFlagValue()
        {
            if (!_validated) ValidateProperties();

            return FutureFlag.IsEnabled;
        }

        private void ValidateProperties()
        {
            if(FutureFlag == default)
                throw new InvalidOperationException($"You must provide an {nameof(IFutureFlag)} when using a {nameof(CachedFutureFlagProvider)}");
            
            if(CacheDuration == default)
                throw new InvalidOperationException($"You must provide a {nameof(CacheDuration)} when using a {nameof(CachedFutureFlagProvider)}");
            
            _validated = true;
        }
    }
}