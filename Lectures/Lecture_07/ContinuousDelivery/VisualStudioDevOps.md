# Example configuration using Visual Studio DevOps

For all build steps see `Builds\build.yaml` (working in march 2020).

> Note: Since Azure builds are changing in time it may happen, that some build steps or options wouldn't be available in the future.

On pipeline level set following variables:
* VersionNumber = 1.0.0.$(Build.BuildID)
* BuildConfiguration = Release
* BuildPlatform = any cpu
