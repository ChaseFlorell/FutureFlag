using System;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace FutureFlag.Tests
{
    [TestFixture]
    public class CachedFutureFlagProviderTests
    {
        [Test]
        public void ShouldCacheAFutureFlagValue()
        {
           // setup
           const int secondsToTest = 1;
           var loopCount = 0;
           var simpleFlag = new Mock<IFutureFlag>();
           simpleFlag.SetupGet(x => x.IsEnabled).Returns(true);
           var cacheProvider = new CachedFutureFlagProvider
           {
               FutureFlag = simpleFlag.Object,
               CacheDuration = TimeSpan.FromSeconds(secondsToTest)
           };
           var stamp = DateTime.Now;
           var end = DateTime.Now.AddSeconds(secondsToTest);
           
           // assert
           cacheProvider.IsEnabled.Should().BeTrue("We manually set IsEnabled to true");
           
           // execute
           simpleFlag.SetupGet(x => x.IsEnabled).Returns(false);
           
           // assert
           while (end >= stamp)
           {
               stamp = DateTime.Now;
               cacheProvider.IsEnabled.Should().BeTrue("even though we've set it to false, the true value is cached");
               loopCount++;
           }

           loopCount.Should().BeGreaterThan(100, because: "the loop should execute many times in one second");
           cacheProvider.IsEnabled.Should().BeFalse("the cache has now expired and we should be picking up the new value");
        }

        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenMissingCacheDuration()
        {
            // setup
            var mockFlag = new Mock<IFutureFlag>();
            var cacheProvider = new CachedFutureFlagProvider
            {
                FutureFlag = mockFlag.Object
            };
            
            // execute
            Func<bool> result = () => cacheProvider.IsEnabled;
            
            // assert
            result.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void ShouldThrowInvalidOperationExceptionWhenMissingFutureFlag()
        {
            // setup
            var cacheProvider = new CachedFutureFlagProvider
            {
                CacheDuration = TimeSpan.Zero
            };
            
            // execute
            Func<bool> result = () => cacheProvider.IsEnabled;
            
            // assert
            result.Should().Throw<InvalidOperationException>();
        }
    }
}