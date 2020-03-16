. .\Build\settings.ps1

$projectToPack = ".\Web\WebCalculator\WebCalculator.csproj"
$publishDir = Join-Path $global:outputDir '\Publish'
$publishWebDir = Join-Path $publishDir "\Web\"
$compressDir = Join-Path $publishDir "\Compressed"
$publishFile = Join-Path $compressDir "\CalculatorWeb.$($env:VersionNumber).zip"

dotnet publish $projectToPack --nologo --no-build --configuration $env:BuildConfiguration --output $publishWebDir
