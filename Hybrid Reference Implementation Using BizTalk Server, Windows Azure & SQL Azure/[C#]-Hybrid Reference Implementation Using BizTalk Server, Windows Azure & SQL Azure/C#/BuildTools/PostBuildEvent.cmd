@echo off
set AssemblyFile=%1
set DocFile=%AssemblyFile:.dll=.xml%
set OutputFolder=..\..\..\OutputAssemblies\

setlocal

call "%VS100COMNTOOLS%vsvars32.bat"

echo Installing %AssemblyFile% assembly in the GAC...
echo.
@GacUtil /if %AssemblyFile%

echo Copying the assembly to the main output folder
xcopy /Y %AssemblyFile% %OutputFolder%

echo Copying the documentation file to the main output folder
if exist %DocFile% xcopy /Y %DocFile% %OutputFolder%

endlocal

if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd