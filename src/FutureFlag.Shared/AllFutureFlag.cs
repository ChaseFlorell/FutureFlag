using System.Linq;
using FutureFlag.Base;

namespace FutureFlag
{
    /// <summary>
    /// A Composite Future Flag that sets <see cref="p:IsEnabled"/> only when All child <see cref="IFutureFlag"/>s are enabled.
    /// </summary>
    public class AllFutureFlag : CompositeFutureFlag
    {
        /// <inheritdoc />
        /// <returns><c>true</c> when all defined <see cref="p:Flags"/> are enabled, otherwise <c>false</c></returns>
        public override bool IsEnabled => Flags.All(x => x.IsEnabled);
    }
}