using System;
using Xamarin.Forms;

namespace FeatureFlag
{
    public sealed class Toggle
    {
        public static readonly BindableProperty FeatureFlagProperty = BindableProperty.Create("FeatureFlag",
            typeof(IFeatureFlag),
            typeof(Toggle),
            default(IFeatureFlag), BindingMode.OneTime, propertyChanged: OnFeatureFlagPropertyChanged);

        private static void OnFeatureFlagPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if(!(bindable is VisualElement visual))
                throw new ArgumentException("Toggle can only be applied to Visual Elements", nameof(bindable));
            
            if(!(newvalue is IFeatureFlag featureFlag))
                throw new ArgumentException("Value can only be of type IFeatureFlag", nameof(newvalue));

            // using a trigger allows the user to define "IsVisible" on top of the feature toggle.
            var setter = new Setter
            {
                Property = VisualElement.IsVisibleProperty, 
                Value = false
            };

            var trigger = new DataTrigger(typeof(VisualElement))
            {
                Binding = new Binding(nameof(IFeatureFlag.IsEnabled), BindingMode.OneTime, source: featureFlag), 
                Value = false
            };
            
            trigger.Setters.Add(setter);
            
            visual.Triggers.Add(trigger);
        }

        public static IFeatureFlag GetFeatureFlag (BindableObject view) 
            => (IFeatureFlag)view.GetValue (FeatureFlagProperty);

        public static void SetFeatureFlag (BindableObject view, IFeatureFlag value) 
            => view.SetValue (FeatureFlagProperty, value);
    }
}