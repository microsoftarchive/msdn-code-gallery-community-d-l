@echo on
set Bts2010InstallPath=%ProgramFiles(x86)%\Microsoft BizTalk Server 2010

if exist "%Bts2010InstallPath%\*.*" xcopy /Y %1 "%Bts2010InstallPath%\Pipeline Components"
