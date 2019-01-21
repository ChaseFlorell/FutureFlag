using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FeatureFlag
{
    [ContentProperty(nameof(Key))]
    public class GridLengthForFeatureFlagExtension : BindableObject, IMarkupExtension
    {
        public static readonly BindableProperty GridLengthProperty = BindableProperty.Create(nameof(GridLength),
            typeof(GridLength),
            typeof(GridLengthForFeatureFlagExtension),
            new GridLength(1.0, GridUnitType.Star));

        /// <summary>
        /// GridLength summary. This is a bindable property.
        /// </summary>
        public GridLength GridLength
        {
            get => (GridLength) GetValue(GridLengthProperty);
            set => SetValue(GridLengthProperty, value);
        }
        
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