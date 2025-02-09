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

Make sure that your system settings reflects official documentation and you can start [sample application](https://learn.microsoft.com/en-us/dotnet/maui/mac-catalyst/cli?view=net-maui-9.0)

[Xcode](https://apps.apple.com/us/app/xcode/id497799835?mt=12) needs to be installed, server enabled, all warnings resolved.

> **Warning** This option was tested on Macbook Air 2021 M1. It has not been officially supported or recommended, nor will it be periodically tested further. Use this at your own risk.

> **Note** PRs reflecting your experience with additional dependencies/configurations are welcomed if you tried this option!

### Dotnet
Simpliest way to make this work is using [Brew](https://docs.brew.sh/Installation):
1. Install dotnet [`brew install --cask dotnet`](https://formulae.brew.sh/cask/dotnet)
2. Install MAUI workload `dotnet workload install maui`.
3. Compile CookBook `dotnet build`, and run CookBook App `dotnet run --project ./CookBook.App/CookBook.App.csproj`.

### Rider
1. Install Rider [`brew install --cask rider`](brew install --cask rider).
2. Open solution `rider CookBook.sln`.

## Linux

### Recommended Tooling / IDEs
- [Rider](https://www.jetbrains.com/rider/)

> **Warning** This option was not tested! It has not been officially supported or recommended, nor will it be periodically tested further. Use this at your own risk.

> **Note** If you decide to test this option, you must make additional configuration changes to the project. Look for `TargetFramework` configuration.

> **Note** PRs reflecting your experience with additional dependencies/configurations are welcomed if you tried this option!

## Nix
> :warning: **Warning**  
> Highly experimental!!!

This repository uses [Flakes](https://zero-to-nix.com/concepts/flakes/). 
1. [Install](https://zero-to-nix.com/start/install/) Nix on your system.
2. Run [`nix develop`](https://zero-to-nix.com/start/nix-develop/) which opens shell with loaded dotnet.
3. If you need MAUI, install workload in the devshell `dotnet workload install maui`.
4. Validate `dotnet --info`, and CookBook build `dotnet build CookBook.sln`. If you make this work (no errors), let [me](pluskal@vut.cz) know and submit PR fixing these instructions!
5. 