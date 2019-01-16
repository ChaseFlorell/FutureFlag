using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeatureFlag
{
    [ContentProperty(nameof(Key))]
    public class GridLengthForFeatureFlagExtension : IMarkupExtension
    {
        public GridLength GridLength { get; set; } = 0D;
        public string Key { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            var staticResource = new StaticResourceExtension{Key = Key};
            var value = staticResource.ProvideValue(serviceProvider);
            
            if(!(value is IFeatureFlag featureFlag))
                throw new ArgumentException($"Key must point to an instance of {nameof(IFeatureFlag)}", nameof(Key));

            
            return featureFlag.IsEnabled ? GridLength : new GridLength(0);
        }
    }
}