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
        
        public static IFeatureFlag GetFeatureFlag (BindableObject view) 
            => (IFeatureFlag)view.GetValue (FeatureFlagProperty);

        public static void SetFeatureFlag (BindableObject view, IFeatureFlag value) 
            => view.SetValue (FeatureFlagProperty, value);

        private static void OnFeatureFlagPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if(!(newvalue is IFeatureFlag featureFlag))
                throw new ArgumentException("Value must be of type IFeatureFlag", nameof(newvalue));
            
            switch (bindable)
            {
                case VisualElement visual:
                    ApplyTriggerToVisual(visual, featureFlag);
                    break;
                case RowDefinition rowDefinition:
                    ApplyTriggerToRowDefinition(rowDefinition, featureFlag);
                    break;
                case ColumnDefinition columnDefinition:
                    ApplyTriggerToColumnDefinition(columnDefinition, featureFlag);
                    break;
            }

            throw new ArgumentException("Feature Flag can only be applied to Visual Elements, Column Definitions, and Row Definitions", nameof(bindable));
        }

        private static Setter CreateSetter(BindableProperty property, object value)
            => new Setter {Property = property, Value = value};
        
        private static DataTrigger CreateDataTrigger(Type type, IFeatureFlag featureFlag) 
            => new DataTrigger(type) { Binding = CreateBinding(featureFlag),   Value = false };

        private static Binding CreateBinding(IFeatureFlag featureFlag) 
            => new Binding(nameof(IFeatureFlag.IsEnabled), BindingMode.OneTime, source: featureFlag);

        private static void ApplyTriggerToColumnDefinition(ColumnDefinition columnDefinition, IFeatureFlag featureFlag)
        {           
            throw new NotImplementedException("Column Definitions don't support triggers");
            var setter = CreateSetter(ColumnDefinition.WidthProperty, new GridLength(0));
            var trigger = CreateDataTrigger(typeof(ColumnDefinition), featureFlag);
            trigger.Setters.Add(setter);
        }

        private static void ApplyTriggerToRowDefinition(RowDefinition rowDefinition, IFeatureFlag featureFlag)
        {           
            throw new NotImplementedException("Row Definitions don't support triggers");
            var setter = CreateSetter(RowDefinition.HeightProperty, new GridLength(0));
            var trigger = CreateDataTrigger(typeof(RowDefinition), featureFlag);  
            trigger.Setters.Add(setter);      
        }

        private static void ApplyTriggerToVisual(VisualElement visual, IFeatureFlag featureFlag)
        {
            // using a trigger allows the user to define "IsVisible" on top of the feature toggle.
            var setter = CreateSetter(VisualElement.IsVisibleProperty, false);
            var trigger = CreateDataTrigger(typeof(VisualElement), featureFlag);
            
            trigger.Setters.Add(setter);
            
            visual.Triggers.Add(trigger);        
        }
    }
}