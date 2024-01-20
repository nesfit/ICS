# Cookbook

## Windows

### Dependencies

```pwsh
winget install Git.Git
winget install Microsoft.DotNet.SDK.8
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
dotnet tool install dotnet-ef --global # or local installation into your own projects
dotnet workload install maui # or dotnet workload restore
```

> **Warning** Make sure that additional workloads for VS 2022 are installed as well in case that application is not compiling or cannot start properly - [FAQ](https://github.com/nesfit/ICS/wiki/Projekt-CookBook-nelze-vůbec-spustit)

### Recommended Tooling / IDEs

> **Warning** Without VS 2022 installation with at least the following workloads, MAUI application will not be runnable.

- Visual Studio 2022 + Resharper
```
winget install Microsoft.VisualStudio.2022.Community --override "--add Microsoft.VisualStudio.Workload.NetCrossPlat --add Microsoft.VisualStudio.Workload.Data --add Microsoft.VisualStudio.Workload.ManagedDesktop Microsoft.VisualStudio.ComponentGroup.WindowsAppSDK.Cs"
winget install JetBrains.ReSharper #https://www.jetbrains.com/community/education/#students
```

- Rider
```
winget install JetBrains.Rider #https://www.jetbrains.com/community/education/#students
```

> **Note** Clean installation without VS 2022 is not tested. PRs reflecting your experience with additional dependencies/configurations are welcomed if you tried this option!

## MacOS

### Recommended Tooling / IDEs
- [Visual Studio for MAC](https://visualstudio.microsoft.com/vs/mac/)
- [Rider](https://www.jetbrains.com/rider/)

Make sure that your system settings reflects official documentation and you can start [sample application](https://learn.microsoft.com/en-us/dotnet/maui/macos/cli?view=net-maui-7.0)

[Xcode](https://apps.apple.com/us/app/xcode/id497799835?mt=12) needs to be installed, server enabled, all warnings resolved.

> **Warning** This option was tested on Macbook Air 2021 M1. It has not been officially supported or recommended, nor will it be periodically tested further. Use this at your own risk.

> **Note** PRs reflecting your experience with additional dependencies/configurations are welcomed if you tried this option!

## Linux

### Recommended Tooling / IDEs
- [Rider](https://www.jetbrains.com/rider/)

> **Warning** This option was not tested! It has not been officially supported or recommended, nor will it be periodically tested further. Use this at your own risk.

> **Note** If you decide to test this option, you must make additional configuration changes to the project. Look for `TargetFramework` configuration.

> **Note** PRs reflecting your experience with additional dependencies/configurations are welcomed if you tried this option!
