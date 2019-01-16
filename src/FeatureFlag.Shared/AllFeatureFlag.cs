using System.Linq;
using FeatureFlag.Base;

namespace FeatureFlag
{
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(Flags))]
#endif
    public class AllFeatureFlag : CompositeFeatureFlag
    {
        public override bool IsEnabled => Flags.All(x => x.IsEnabled);
    }
}