using System;
using FutureFlag.Internal;
using Xamarin.Forms;

namespace FutureFlag
{
    public sealed class Toggle
    {
        // ReSharper disable once InconsistentNaming
        private const string FutureFlag = nameof(FutureFlag);
        
        public static readonly BindableProperty FutureFlagProperty = BindableProperty.Create(FutureFlag,
            typeof(IFutureFlag),
            typeof(Toggle),
            default(IFutureFlag),
            BindingMode.OneTime, 
            propertyChanged: OnFutureFlagPropertyChanged);

        public static IFutureFlag GetFutureFlag (BindableObject view) 
            => (IFutureFlag)view.GetValue (FutureFlagProperty);

        public static void SetFutureFlag (BindableObject view, IFutureFlag value) 
            => view.SetValue (FutureFlagProperty, value);
        
        private static void OnFutureFlagPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if(!(bindable is VisualElement visual))
                throw new ArgumentException("Toggle can only be applied to Visual Elements", nameof(bindable));
            
            if(!(newvalue is IFutureFlag featureFlag))
                throw new ArgumentException("Value can only be of type IFutureFlag", nameof(newvalue));

            // using a trigger allows the user to define "IsVisible" on top of the feature toggle.          
            visual.Triggers.Add(Helpers.CreateDataTriggerForFutureFlag(
                featureFlag, 
                VisualElement.IsVisibleProperty, 
                false, 
                typeof(VisualElement),
                false));
        }
    }
}