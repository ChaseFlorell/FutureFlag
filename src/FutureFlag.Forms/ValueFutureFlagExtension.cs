using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutureFlag
{
    [ContentProperty(nameof(Key))]
    public abstract class ValueFutureFlagExtension<T> : IMarkupExtension
    {
        private IFutureFlag _toggle;
        public string Key { get; set; }
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var staticResource = new StaticResourceExtension {Key = Key};

            var value =  staticResource.ProvideValue(serviceProvider);

            _toggle = value is IFutureFlag featureFlag
                ? featureFlag
                : throw new ArgumentException("Invalid Future Flag provided.");

            return _toggle.IsEnabled ? TrueValue : FalseValue;        
        }
    }
}