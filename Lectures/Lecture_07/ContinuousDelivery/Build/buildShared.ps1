. .\Build\settings.ps1

dotnet build .\Shared\Shared.sln --configuration $env:BuildConfiguration --nologo -p:Version=$env:VersionNumber