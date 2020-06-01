#tool nuget:?package=NUnit.ConsoleRunner&version=3.11.1

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
      MSBuild("./FutureFlag.sln", new MSBuildSettings()
        .SetConfiguration(configuration)
        .SetVerbosity(Verbosity.Minimal)
        .WithTarget("Rebuild")
        .WithProperty("VersionSuffix", versionSuffix)
        .WithProperty("OutDir", System.IO.Path.GetFullPath(artifactsDir.ToString()))
      );
});

Task("Run-Unit-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    var resultsFile = artifactsDir.ToString() + "/test-results.xml";

    NUnit3("./artifacts/*.Tests.dll", new NUnit3Settings {
        NoResults = false,
        Results = new[] { new NUnit3Result { FileName = resultsFile } },           
    });

    if(AppVeyor.IsRunningOnAppVeyor)
    {
        AppVeyor.UploadTestResults(resultsFile, AppVeyorTestResultsType.NUnit3);
    }
});

RunTarget(target);