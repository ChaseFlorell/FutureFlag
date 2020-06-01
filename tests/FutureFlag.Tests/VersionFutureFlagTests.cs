using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace FutureFlag.Tests
{
    public class VersionFutureFlagTests : TestBase
    {
        private VersionFutureFlag _versionFutureFlag;

        [SetUp]
        public void SetUp()
        {
            Version VersionProvider() => new Version("1.0.0.0");
            FutureFlagConfiguration.Configure(cfg => cfg.VersionProvider(VersionProvider));
            _versionFutureFlag = new VersionFutureFlag();
        }

        [Test]
        public void ShouldDisableFeatureWhenExecutingAssemblyIsOlder()
        {
            
            // setup
            _versionFutureFlag.Version = "2.0.0.0";
            
            
            // assert
            _versionFutureFlag.IsEnabled.Should().BeFalse();
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetAssembly(typeof(VersionFutureFlagTests))?.GetName().Version);
        }
        
        [Test]
        public void ShouldEnableFeatureWhenExecutingAssemblyIsNewer()
        {
            // setup
            _versionFutureFlag.Version = "0.0.0.1";
            
            // assert
            _versionFutureFlag.IsEnabled.Should().BeTrue();
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetAssembly(typeof(VersionFutureFlagTests))?.GetName().Version);
        }
    }
}