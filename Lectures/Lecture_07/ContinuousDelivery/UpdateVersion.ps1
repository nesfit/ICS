Param(
  [string]$pathToSearch = $env:BUILD_SOURCESDIRECTORY,
  [string]$buildNumber = $env:BUILD_BUILDNUMBER,
  [string]$searchFilter = "AssemblyInfo.*",
  [regex]$pattern = "\d+\.\d+\.\d+\.\d+"
)

Write-Host "Variable Buildnumber='$buildNumber'";
Write-Host "Variable PathToSearch='$pathToSearch'";
 
try
{
    if ($buildNumber -match $pattern -ne $true) {
        Write-Host "Could not extract a version from [$buildNumber] using pattern [$pattern]"
        exit 1
    } else {
        $extractedBuildNumber = $Matches[0]
        Write-Host "Using version $extractedBuildNumber"
 
        gci -Path $pathToSearch -Filter $searchFilter -Recurse | %{
            Write-Host "  -> Changing $($_.FullName)"
         
            # remove the read-only bit on the file
            sp $_.FullName IsReadOnly $false
 
            # run the regex replace
            (gc $_.FullName) | % { $_ -replace $pattern, $extractedBuildNumber } | sc $_.FullName
        }
 
        Write-Host "Done!"
    }
}
catch {
    Write-Host $_
    exit 1
}