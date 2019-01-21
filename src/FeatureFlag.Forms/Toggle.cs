using System;
using FeatureFlag.Internal;
using Xamarin.Forms;

namespace FeatureFlag
{
    public sealed class Toggle
    {
        // ReSharper disable once InconsistentNaming
        private const string FeatureFlag = nameof(FeatureFlag);
        
        public static readonly BindableProperty FeatureFlagProperty = BindableProperty.Create(FeatureFlag,
            typeof(IFeatureFlag),
            typeof(Toggle),
            default(IFeatureFlag),
            BindingMode.OneTime, 
            propertyChanged: OnFeatureFlagPropertyChanged);

        public static IFeatureFlag GetFeatureFlag (BindableObject view) 
            => (IFeatureFlag)view.GetValue (FeatureFlagProperty);

        public static void SetFeatureFlag (BindableObject view, IFeatureFlag value) 
            => view.SetValue (FeatureFlagProperty, value);
        
        private static void OnFeatureFlagPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if(!(bindable is VisualElement visual))
                throw new ArgumentException("Toggle can only be applied to Visual Elements", nameof(bindable));
            
            if(!(newvalue is IFeatureFlag featureFlag))
                throw new ArgumentException("Value can only be of type IFeatureFlag", nameof(newvalue));

            // using a trigger allows the user to define "IsVisible" on top of the feature toggle.
            var trigger = Helpers.CreateDataTriggerForFeatureFlag(
                featureFlag, 
                VisualElement.IsVisibleProperty, 
                false, 
                typeof(VisualElement),
                false);
            
            visual.Triggers.Add(trigger);
        }
    }
}