namespace FutureFlag
{
    /// <summary>
    /// Use this to define your own simple flag implementation
    /// </summary>
    /// <example>
    ///<![CDATA[
    ///    var simpleFutureFlag = new SimpleFutureFlag { IsEnabled = true };
    ///    myElement.IsVisible = simpleFutureFlag.IsEnabled;
    /// ]]>
    /// </example>
    public class SimpleFutureFlag : IFutureFlag
    {
        public virtual bool IsEnabled { get; set; }
    }
}