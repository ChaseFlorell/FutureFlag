using NUnit.Framework;

namespace FutureFlag.Tests.Base
{
    public class TestBase
    {
        [TearDown]
        public void TearDown()
        {
            // simply resets the configuration assertions after every test run
            FutureFlagConfiguration.Reset();
        }
    }
}