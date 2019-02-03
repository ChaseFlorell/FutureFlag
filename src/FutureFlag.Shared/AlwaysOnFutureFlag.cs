namespace FutureFlag
{
    /// <summary>
    /// Defines a Future Flag that returns <see cref="p:IFutureFlat.IsEnabled"/> = <c>true</c>;
    /// </summary>
    public class AlwaysOnFutureFlag : IFutureFlag
    {     
        /// <inheritdoc />
        /// <returns>Always returns <c>true</c></returns>
        public bool IsEnabled => true;
    }
}