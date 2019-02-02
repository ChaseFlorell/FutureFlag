namespace FutureFlag
{
    public class AlwaysOnFutureFlag : IFutureFlag
    {
        public bool IsEnabled => true;
    }
}