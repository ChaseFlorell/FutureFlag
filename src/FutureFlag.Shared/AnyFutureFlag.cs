using System.Linq;
using FutureFlag.Base;

namespace FutureFlag
{
    /// <summary>
    /// A Composite Future Flag that sets <see cref="p:IsEnabled"/> when ANY child <see cref="IFutureFlag"/> is enabled.
    /// </summary>
    public class AnyFutureFlag : CompositeFutureFlag
    {
        /// <inheritdoc />
        /// <returns><c>true</c> when any single defined <see cref="p:Flags"/> is enabled, otherwise <c>false</c></returns>
        public override bool IsEnabled => Flags.Any(x => x.IsEnabled); 
    }
}