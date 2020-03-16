. .\Build\settings.ps1

dotnet build .\Console\Console.sln --configuration $env:BuildConfiguration --nologo -p:Version=$env:VersionNumber