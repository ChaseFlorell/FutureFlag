using System.Net.Http;
using FakeItEasy;
using FutureFlag.Tests.Base;
using NUnit.Framework;

namespace FutureFlag.Tests
{
    [TestFixture]
    public class JsonRestFutureFlagTests : TestBase
    {
        [Test]
        public void ShouldApplyCustomHttpHandler()
        {
            // setup
            var handler = A.Fake<DelegatingHandler>();
            FutureFlagConfiguration.Configure(cfg => cfg.WithHttpHandler(handler));
            var restFlag = new JsonRestFutureFlag();

            // execute
            restFlag.Url = "https://example.com";
            
            // assert
            A.CallTo(handler).Where(x => x.Method.Name == "SendAsync").MustHaveHappened();
        }
        
        [Test]
        public void ShouldNotApplyCustomHttpHandler()
        {
            // setup
            var handler = A.Fake<DelegatingHandler>();
            var restFlag = new JsonRestFutureFlag();

            // execute
            restFlag.Url = "https://example.com";
            
            // assert
            A.CallTo(handler).Where(x => x.Method.Name == "SendAsync").MustNotHaveHappened();
        }
    }
}