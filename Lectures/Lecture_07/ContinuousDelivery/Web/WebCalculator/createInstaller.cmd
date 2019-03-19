rem setup the visual studio 2013 command prompt needed to get environment variables
call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsDevCmd.bat"

rem for remote configuration you need to: /P:MsDeployServiceUrl=https://yourServer:8172/MsDeploy.axd /P:MSDeployPublishMethod=WMSvc
rem see http://www.troyhunt.com/2010/11/you-deploying-it-wrong-teamcity_26.html

REM Example of complete commandline
REM msbuild.exe webcalculator.csproj /P:Configuration=Release /P:DeployOnBuild=True /P:DeployTarget=MSDeployPublish  /P:AllowUntrustedCertificate=True /P:MSDeployPublishMethod=InProc /P:CreatePackageOnPublish=True /P:DeployIisAppPath=WebCalculator

rem to build using visual studio
MSBuild webcalculator.csproj /T:Package /p:PublishProfile="CreateInstaller"