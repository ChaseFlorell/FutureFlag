namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag that returns <see cref="p:IFutureFlat.IsEnabled"/> = <c>false</c>;
    /// </summary>
    public class AlwaysOffFutureFlag : IFutureFlag
    {
        /// <inheritdoc />
        /// <returns>Always returns <c>false</c></returns>
        public bool IsEnabled => false;
    }
}