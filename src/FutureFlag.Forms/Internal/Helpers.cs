using System;
using Xamarin.Forms;

namespace FutureFlag.Internal
{
    public static class Helpers
    {
        /// <summary>
        /// Create a Data Trigger specific for Future Flags
        /// </summary>
        /// <param name="bindableProperty">The property that will be updated when the trigger is applied</param>
        /// <param name="valueAppliedToPropertyWhenTriggerIsActivated">The value that will be set with the trigger is applied</param>
        /// <param name="objectTypeToApplyTheTriggerTo">Object type to apply the trigger to</param>
        /// <param name="featureFlag">Instance of <see cref="IFutureFlag"/> that the trigger will be applied against</param>
        /// <param name="featureFlagStateThatAppliesTheSetterValue">Indicates if the <see cref="p:IFutureFlag.IsEnabled"/> property state used to activate the trigger</param>
        /// <returns></returns>
        public static DataTrigger CreateDataTriggerForFutureFlag( 
            IFutureFlag featureFlag, 
            BindableProperty bindableProperty, 
            object valueAppliedToPropertyWhenTriggerIsActivated, 
            Type objectTypeToApplyTheTriggerTo,
            bool featureFlagStateThatAppliesTheSetterValue)
        {
            var setter = new Setter
            {
                Property = bindableProperty, 
                Value = valueAppliedToPropertyWhenTriggerIsActivated
            };

            var trigger = new DataTrigger(objectTypeToApplyTheTriggerTo)
            {
                Binding = new Binding(nameof(IFutureFlag.IsEnabled), source: featureFlag), 
                Value = featureFlagStateThatAppliesTheSetterValue
            };
            
            trigger.Setters.Add(setter);
            return trigger;
        }
    }
}