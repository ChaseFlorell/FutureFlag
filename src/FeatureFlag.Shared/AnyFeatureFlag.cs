using System.Linq;
using FeatureFlag.Base;

namespace FeatureFlag
{
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(Flags))]
#endif
    public class AnyFeatureFlag : CompositeFeatureFlag
    {
        public override bool IsEnabled => Flags.Any(x => x.IsEnabled); 
    }
}