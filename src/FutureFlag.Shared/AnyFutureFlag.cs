using System.Linq;
using FutureFlag.Base;

namespace FutureFlag
{
#if XAMARIN_FORMS
    [Xamarin.Forms.ContentProperty(nameof(Flags))]
#endif
    public class AnyFutureFlag : CompositeFutureFlag
    {
        public override bool IsEnabled => Flags.Any(x => x.IsEnabled); 
    }
}