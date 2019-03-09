namespace FutureFlag
{
    public static class Is<T> where T : IFutureFlag, new()
    {
        public static bool Enabled => new T().IsEnabled;
        public static bool Disabled => ! new T().IsEnabled;
    }
}