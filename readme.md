#FutureToggle
Simple cross platform feature toggles build for various flavours of .net

#FutureToggle.Forms
.netstandard feature toggles and also Xamarin Forms specific extensions

##Releases

|                  |  Release                     |  Pre-Release                                        |
| ---------------- | ---------------------------: |  -------------------------------------------------: |
| Build | [![Build status][master]][master-build] | [![Build status][development]][development-build]   |
| Artifact       | [![nuget][flag]][flag-link]    | [![nuget-pre][flag-pre]][flag-link]                 |

##Feature Flags
 - All - A composite flag that toggles only when all children are enabled
 - Any - A composite flag that toggles when any single child is enabled
 - AlwaysOff - IsEnabled = false
 - AlwaysOn - IsEnabled = true
 - JsonRest - IsEnabled when a JSON response comes back `{isEnabled : true|false}`
 - OnOrAfter - IsEnabled on or after a specific date
 - OnOrBefore - IsEnabled on or before a specific date
 - BetweenDates - IsEnabled between two dates
 - Random - IsEnabled is totally random
 - Version - IsEnabled on or after a specific version
 - Simple - IsEnabled is specified by the developer
 - Cached - Caches the `IsEnabled` result of a given `IFutureFlag` for a given amount of time.
 
 _note: you can create any custom Future Flag you like by using the `IFutureFlag` interface_

##Xamarin Forms
declare your Future Flag via xaml
```xml
<Page xmlns:futureFlag="http://github.com/chaseflorell/futureflag">
  <Page.Resources>
    <ResourceDictionary>
      <featureFlag:VersionFutureFlag x:Key="FutureVersion"
                                     Version="1.3"/>
    </ResourceDictionary>
  </Page.Resources>
</Page>
```
Use the attached property to attach a future toggle to a VisualElement
```xml
<Label Text="I'm only visible on or after version 1.3" 
       featureFlag:VisualElement.FutureFlag="{StaticResource FutureVersion}"/>
```

[flag]: https://img.shields.io/nuget/v/futureflag.svg?style=flat-square&label=nuget&logo=nuget
[flag-pre]: https://img.shields.io/nuget/vpre/futureflag.svg?style=flat-square&label=nuget-pre&logo=nuget
[flag-link]: https://www.nuget.org/packages/FutureFlag/
[forms]: https://img.shields.io/nuget/v/futureflag.forms.svg?style=flat-square&label=nuget&logo=nuget
[forms-pre]: https://img.shields.io/nuget/vpre/futureflag.forms.svg?style=flat-square&label=nuget-pre&logo=nuget
[forms-link]: https://www.nuget.org/packages/FutureFlag.Forms/
[master]: https://img.shields.io/appveyor/ci/chaseflorell/futureflag/master.svg?style=flat-square&label=master&logo=appveyor
[master-build]:https://ci.appveyor.com/project/ChaseFlorell/futureflag
[development]: https://img.shields.io/appveyor/ci/chaseflorell/futureflag/development.svg?style=flat-square&label=development&logo=appveyor
[development-build]: https://ci.appveyor.com/project/ChaseFlorell/futureflag/branch/development




