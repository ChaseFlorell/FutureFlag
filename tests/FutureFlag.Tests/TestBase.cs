using NUnit.Framework;

namespace FutureFlag.Tests
{
    public class TestBase
    {
        [TearDown]
        public void TearDown()
        {
            FutureFlagConfiguration.Reset();
        }
    }
}