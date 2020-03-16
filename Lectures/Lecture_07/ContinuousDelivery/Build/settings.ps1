$global:outputDir = Join-Path $PSScriptRoot "..\Output"

# Default settings for local builds

if($env:BuildConfiguration -eq $null) {
    Write-Host "Updating BuildConfiguration environment variable"
    $env:BuildConfiguration = "Release"
}

if($env:VersionNumber -eq $null) {
    Write-Host "Updating VersionNumber environment variable"
    $env:VersionNumber = "1.0.0"
}
