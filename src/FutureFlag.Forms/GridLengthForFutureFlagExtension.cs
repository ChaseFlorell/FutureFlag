using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FutureFlag
{
    /// <summary>
    /// Toggles a <see cref="RowDefinition"/> or <see cref="ColumnDefinition"/> <see cref="Xamarin.Forms.GridLength"/> between ZERO and the specified <see cref="p:GridLength"/> based on whether or not the provided <see cref="p:IFutureFlag.IsEnabled"/>.
    /// </summary>
    [ContentProperty(nameof(Key))]
    public class GridLengthForFutureFlagExtension : BindableObject, IMarkupExtension
    {
        public static readonly BindableProperty GridLengthProperty = BindableProperty.Create(nameof(GridLength),
            typeof(GridLength),
            typeof(GridLengthForFutureFlagExtension),
            new GridLength(1.0, GridUnitType.Star));

        /// <summary>
        /// Gets or sets the GridLength of a <see cref="RowDefinition"/> or <see cref="ColumnDefinition"/>. This is a bindable property.
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
            
            if(!(value is IFutureFlag featureFlag))
                throw new ArgumentException($"Key must point to an instance of {nameof(IFutureFlag)}", nameof(Key));

            
            return featureFlag.IsEnabled ? GridLength : new GridLength(0);
        }
    }
}