using System;
using Xamarin.Forms.Xaml;

namespace FeatureFlag
{
    public abstract class ValueFeatureFlagExtension<T> : IMarkupExtension
    {
        private IFeatureFlag _toggle;
        public string Key { get; set; }
        public T TrueValue { get; set; }
        public T FalseValue { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var staticResource = new StaticResourceExtension {Key = Key};

            var value =  staticResource.ProvideValue(serviceProvider);

            _toggle = value is IFeatureFlag featureFlag
                ? featureFlag
                : throw new ArgumentException("Invalid Feature Flag provided.");

            return _toggle.IsEnabled ? TrueValue : FalseValue;        
        }
    }
}