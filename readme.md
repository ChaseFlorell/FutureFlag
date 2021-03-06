# FutureFlag
Simple cross platform feature flags build for various flavours of .net

# FutureFlag.Forms
.netstandard feature flags and also Xamarin Forms specific extensions

## Releases

|                  |  Release                          |  Pre-Release                                |
| ---------------- | --------------------------------: |  -----------------------------------------: |
| Build            | [![status][master]][master-build] | [![status][development]][development-build] |
| FutureFlag       | [![nuget][flag]][flag-link]       | [![nuget-pre][flag-pre]][flag-link]         |
| FutureFlag.Forms | [![nuget][forms]][forms-link]     | [![nuget-pre][forms-pre]][forms-link]       |

## Feature Flags
 - All - A composite flag that enables when all children are enabled
 - Any - A composite flag that enables when any single child is enabled
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

## Xamarin Forms
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
Use the attached property to attach a future flag to a VisualElement
```xml
<Label Text="I'm only visible on or after version 1.3" 
       featureFlag:VisualElement.FutureFlag="{StaticResource FutureVersion}"/>
```

### Accolades
Attribution to [Jason Roberts][jason-roberts] and his work on [FeatureToggle][feature-toggle], as it's what got me started.

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

[feature-toggle]: https://github.com/jason-roberts/FeatureToggle
[jason-roberts]: https://twitter.com/robertsjason




