namespace FutureFlag
{
    public class AlwaysOffFutureFlag : IFutureFlag
    {
        public bool IsEnabled => false;
    }
}