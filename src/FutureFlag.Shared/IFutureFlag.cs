namespace FutureFlag
{
    public interface IFutureFlag
    {
        /// <summary>
        /// Indicates whether or not the feature is enabled
        /// </summary>
        bool IsEnabled { get; }
    }
}