. .\Build\settings.ps1

if (Test-Path $global:outputDir) {
    Remove-Item -Path $global:outputDir -Recurse -Force
}

