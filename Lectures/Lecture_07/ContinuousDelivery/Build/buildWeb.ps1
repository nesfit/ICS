. .\Build\settings.ps1

dotnet build .\Web\Web.sln --configuration $env:BuildConfiguration --nologo -p:Version=$env:VersionNumber