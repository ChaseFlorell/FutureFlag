using System;
using FutureFlag.Internal;
using Xamarin.Forms;

namespace FutureFlag
{
    public sealed class VisualElement
    {
        // ReSharper disable once InconsistentNaming
        private const string FutureFlag = nameof(FutureFlag);
        
        /// <summary>Implements the attached property that represents the <see cref="IFutureFlag"/>  attached to a <see cref="VisualElement"/>.</summary>
        /// <remarks>
        ///     <para>The interface for this property is defined by the <see cref="M:FutureFlag.VisualElement.GetFutureFlag" /> and <see cref="M:FutureFlag.VisualElement.SetFutureFlag" /> methods.</para>
        /// </remarks>
        public static readonly BindableProperty FutureFlagProperty = BindableProperty.Create(FutureFlag,
            typeof(IFutureFlag),
            typeof(VisualElement),
            default(IFutureFlag),
            BindingMode.OneTime, 
            propertyChanged: OnFutureFlagPropertyChanged);

        /// <summary>Gets the <see cref="IFutureFlag"/> of the supplied <see cref="BindableObject"/>.</summary>
        /// <param name="view">A <see cref="VisualElement"/> containing an <see cref="IFutureFlag"/>.</param>
        public static IFutureFlag GetFutureFlag (BindableObject view) 
            => (IFutureFlag)view.GetValue (FutureFlagProperty);

        /// <param name="bindable">A visual element to apply the <see cref="IFutureFlag"/> to.</param>
        /// <param name="value">The specified <see cref="IFutureFlag"/>.</param>
        /// <summary>Applies an <see cref="IFutureFlag"/> to a <see cref="Xamarin.Forms.VisualElement"/> and toggles the <see cref="p:VisualElement.IsVisible"/> based on the value found in <see cref="p:IFutureFlag.IsEnabled"/>.</summary>
        public static void SetFutureFlag (BindableObject bindable, IFutureFlag value) 
            => bindable.SetValue (FutureFlagProperty, value);
        
        private static void OnFutureFlagPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if(!(bindable is Xamarin.Forms.VisualElement visual))
                throw new ArgumentException("Toggle can only be applied to Visual Elements", nameof(bindable));
            
            if(!(newvalue is IFutureFlag featureFlag))
                throw new ArgumentException("Value can only be of type IFutureFlag", nameof(newvalue));

            // using a trigger allows the user to define "IsVisible" on top of the feature toggle.          
            visual.Triggers.Add(Helpers.CreateDataTriggerForFutureFlag(
                featureFlag, 
                Xamarin.Forms.VisualElement.IsVisibleProperty, 
                false, 
                typeof(Xamarin.Forms.VisualElement),
                false));
        }
    }
}