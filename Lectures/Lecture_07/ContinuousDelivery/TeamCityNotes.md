# Configure builds using TeamCity

* It is recommended to have only one workspace, but different checkout rules. To define checkout rules see https://confluence.jetbrains.com/display/TCD8/VCS+Checkout+Rules

## Monolitic Build

Complete workspace using Visual Studio TeamServices:
https://yourLiveIdLogin.visualstudio.com/DefaultCollection
$/Examples/AutomatedBuilds/BankCalculators
##LIVE##\yourLiveIdLogin
`Checkout directory`: custom path= c:\TeamCity\buildAgent\work\%env.TEAMCITY_BUILDCONF_NAME%

1. Compile: Solution build
    * `Solution file`: BankCalculators.sln
2. Unit tests: Nunit
    * `Run tests from`: Output\**\Tests\Calculator.Engine.Tests.dll
    * `Coverage`: dotCover, filterrules= +:Calculators.Engine
 3. acceptance tests: Nunit
    * Output\**\Tests\WebCalculator.Tests.dll
4. JavaScript tests: Command line
    * `Artifacts`: _Chutzpah.coverage.html => Coverage.zip
    * `Run`: Executables with parameters
    * `Command executable`: packages/Chutzpah.3.3.1/tools/chutzpah.console.exe
    * `arguments`: /path web\WebCalculator.Javascript.Tests\Scripts\ShowPreviewTests.js /teamcity /coverage /failOnError
    * On Project site add new `Report tab`: Title=JavaScript coverage, StartPage=Coverage.zip!_Chutzpah.coverage.html
5. Static code analysis: .Net inspections
    * `Solution file`: BankCalculators.sln
    * `Custom settings profile path`: BankCalculators.sln.DotSettings
5. Pack the web application: msbuild
    * `build file path`: web/WebCalculator/WebCalculator.csproj
    * `targets`: Package
    * `command line arguments`: /p:PublishProfile="CreateInstaller"
toolsVersion: 4.0
6. Install the application to the local IIS: command line
    * `run`: custom script
call Output\Release\WebPackage\WebCalculator.deploy.cmd /Y

## Solution Split

1. EngineOnly
    * `Artifacts`: Output\Release\*.*
    * `Step Visual Studio`: Shared/Shared.sln
    * `Step Nunit`: Output\**\Tests\Calculator.Engine.Tests.dll
2. ConsoleApp 
    * `Artifacts`: Output\Release\*.* => ConsoleApp.zip
    * `Step Visual Studio`: Console/Console.sln
    * `Trigger VCS`: Trigger a build on changes in snapshot dependencies
    * Dependency Snapshot + Artifacts on EngineOnly: *.* => Output\Release (Build from the same chain)

3. WebApp
    * `Artifacts`: Output\Release\WebPackage\*.* => WebApp.zip
_Chutzpah.coverage.html => Coverage.zip
    * `Step Visual Studio`: Web/Web.sln
    * `Step Command line`: See javascript step in monolitic
    * `Step msbuild`: see package step in monolitic
    * `Trigger VCS`: Trigger a build on changes in snapshot dependencies
    * Dependency Snapshot + Artifacts on EngineOnly: *.* => Output\Release (Build from the same chain)

4. Install to Stage
Step Command line: See monolitic Install step
Dependency Snapshot + Artifacts on WebApp: WebApp.zip!\*.* => Output\Release\WebPackage

### Optional

5. Pack DvD
    * Dependency Snapshot + Artifacts on ConsoleApp: ConsoleApp.zip => Output\Release\Installer (Build from the same chain)
    * Dependency Snapshot + Artifacts on WebApp: WebApp.zip => \Output\Release\Installer (Build from the same chain)
Artifacts: Output\Release\Installer\*.* => Dvd.zip
6. Inspections:
    * `Step Inspections (.NET)`: path=Shared/Shared.sln
    * `Step Inspections (.NET)`: path=Console/Console.sln
    * `Step Inspections (.NET)`: Web/Web.sln