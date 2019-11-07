@echo off
set SourcePath=..\OutputAssemblies
set BinPath=.\Bin
set BtsInstallPath=%ProgramFiles(x86)%\Microsoft BizTalk Server 2010
set BtsAppName=Contoso.Cloud.Integration

net stop BTSSvc$BizTalkServerApplication
net stop BTSSvc$ServiceBusReceiveHost
net stop BTSSvc$ServiceBusSendHost
net stop BTSSvc$DiagnosticEventCollectorHost

robocopy "%SourcePath%" %BinPath%\ *.dll

for %%i in ("%BinPath%\*.dll") do .\Utilities\gacutil /if  %%i

"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:Assembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.Framework.dll"
"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:Assembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.BizTalk.Core.dll"
"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:Assembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.BizTalk.Components.dll"
"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:BizTalkAssembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.BizTalk.Pipelines.dll"
"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:BizTalkAssembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.BizTalk.Schemas.dll"
"%BtsInstallPath%\BTSTask.exe" AddResource -ApplicationName:%BtsAppName% -Type:System.BizTalk:BizTalkAssembly -Overwrite -Source:"%BinPath%\Contoso.Cloud.Integration.BizTalk.Maps.dll"

net start BTSSvc$DiagnosticEventCollectorHost
net start BTSSvc$ServiceBusSendHost
net start BTSSvc$ServiceBusReceiveHost
net start BTSSvc$BizTalkServerApplication

