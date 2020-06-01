#tool "nuget:?package=xunit.runner.console&version=2.4.1"

var target = Argument("target", "Default");
var clean = Argument("configuration", "Clean");
var configuration = Argument("configuration", "Release");
var environment = Argument<string>("environment", "local");
var artifactsDir = Directory("./artifacts");
var versionSuffix = Argument("versionSuffix", "");

var notLocal = !environment.Equals("local");

Setup(context =>
{
    var binsToClean = GetDirectories("./src/**/bin/");
    var testsToClean = GetDirectories("./test/**/bin/");
    var artifactsToClean = GetDirectories(artifactsDir);
    Information(configuration);
	CleanDirectories(binsToClean);
	CleanDirectories(testsToClean);
    CreateDirectory(artifactsDir);
    NuGetRestore("./FutureFlag.sln", new NuGetRestoreSettings { NoCache = true });
});

Task("Default").IsDependentOn("Run-Unit-Tests");

Task("Build")
    .Does(() => {
      Information(artifactsDir);
      MSBuild("./FutureFlag.sln", configurator => configurator
        .SetConfiguration(configuration)
        .SetVerbosity(Verbosity.Minimal)
        .UseToolVersion(MSBuildToolVersion.VS2019)
        .WithTarget("Rebuild")
        .WithProperty("VersionSuffix", versionSuffix)
        .WithProperty("OutDir", System.IO.Path.GetFullPath(artifactsDir.ToString()))
      );
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var projects = GetFiles("./tests/**/*.Tests.csproj");

    foreach(var project in projects)
    {
      DotNetCoreTest(
        project.FullPath,
        new DotNetCoreTestSettings()
          {
            // Set configuration as passed by command line
            Configuration = configuration
          });
    }
});

RunTarget(target);