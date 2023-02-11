# Cookbook

## Dependencies

```pwsh
winget install Microsoft.DotNet.SDK.7
dotnet tool install dotnet-ef --global
dotnet workload install maui
```

## Recommended Tooling / IDE

```
winget install Microsoft.VisualStudio.2022.Community --override "--add Microsoft.VisualStudio.Workload.NetCrossPlat --add Microsoft.VisualStudio.Workload.Data --add Microsoft.VisualStudio.Workload.ManagedDesktop"
winget install JetBrains.ReSharper #https://www.jetbrains.com/community/education/#students
```

or 

```
winget install JetBrains.Rider #https://www.jetbrains.com/community/education/#students
```

## Notes

In case you are missing nuget source, e.g. `dotnet restore` fails

```
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
```
