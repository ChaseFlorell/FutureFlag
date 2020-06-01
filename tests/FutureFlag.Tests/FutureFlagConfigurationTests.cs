using System;
using System.Net.Http;
using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace FutureFlag.Tests
{
    public class FutureFlagConfigurationTests : TestBase
    {
        [Test]
        public void ShouldNotFailConfiguration()
        {
            // setup
            var handler = A.Fake<DelegatingHandler>();
            Action config = () => FutureFlagConfiguration.Configure(cfg => cfg
                .UseUtcByDefault(true)
                .NowProvider(() => DateTime.Now)
                .VersionProvider(() => Version.Parse("123"))
                .WithHttpHandler(handler)
                .UtcNowProvider(() => DateTime.UtcNow)
                .SetIsEnabledForExactVersion("1.2.3.4")
            );

            // execute 

            // assert
            config.Should().NotThrow();
        }

        [Test]
        public void ShouldFailConfigurationBecauseAlreadyConfigured()
        {
            // setup
            Action configOne = () => FutureFlagConfiguration.Configure(x => x.UseUtcByDefault(true));
            Action configTwo = () => FutureFlagConfiguration.Configure(x => x.UseUtcByDefault(true));

            // execute 

            // assert
            configOne.Should().NotThrow();
            configTwo.Should().Throw<InvalidOperationException>().WithMessage("Configuration has already been run");
        }

        [Test]
        public void ShouldFailConfigurationBecauseSameMethodTwice()
        {
            // setup
            Action config = () => FutureFlagConfiguration.Configure(x => x.UseUtcByDefault(true).UseUtcByDefault(true));

            // execute 

            // assert
            config.Should().Throw<InvalidOperationException>().WithMessage("UseUtcByDefault can only be configured once");
        }
    }
}