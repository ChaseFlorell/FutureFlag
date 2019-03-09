using System;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;

namespace FutureFlag.Tests
{
    [TestFixture]
    public class VersionFutureFlagTests
    {
        private VersionFutureFlag _versionFutureFlag;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Version VersionProvider() => new Version("1.0.0.0");
            FutureFlagConfiguration.Configure(cfg => cfg.VersionProvider(VersionProvider));
        }
        
        [SetUp]
        public void SetUp()
        {
            _versionFutureFlag = new VersionFutureFlag();
        }
        
        [Test]
        public void ShouldDisableFeatureWhenExecutingAssemblyIsOlder()
        {
            
            // setup
            _versionFutureFlag.Version = "2.0.0.0";
            
            
            // assert
            _versionFutureFlag.IsEnabled.Should().BeFalse();
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetAssembly(typeof(VersionFutureFlagTests)).GetName().Version);
        }
        
        [Test]
        public void ShouldEnableFeatureWhenExecutingAssemblyIsNewer()
        {
            // setup
            _versionFutureFlag.Version = "0.0.0.1";
            
            // assert
            _versionFutureFlag.IsEnabled.Should().BeTrue();
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetAssembly(typeof(VersionFutureFlagTests)).GetName().Version);
        }
    }
}