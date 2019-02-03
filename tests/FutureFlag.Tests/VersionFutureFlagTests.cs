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
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetExecutingAssembly().GetName().Version);
        }
        
        [Test]
        public void ShouldEnableFeatureWhenExecutingAssemblyIsNewer()
        {
            // setup
            _versionFutureFlag.Version = "0.0.0.1";
            
            // assert
            _versionFutureFlag.IsEnabled.Should().BeTrue();
            _versionFutureFlag.ActualVersion.Should().Be(Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}