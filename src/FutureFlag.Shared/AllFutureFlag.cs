using System.Linq;
using FutureFlag.Base;

namespace FutureFlag
{
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(Flags))]
#endif
    public class AllFutureFlag : CompositeFutureFlag
    {
        public override bool IsEnabled => Flags.All(x => x.IsEnabled);
    }
}