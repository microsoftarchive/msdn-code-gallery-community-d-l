@echo off

setlocal

call "%VS100COMNTOOLS%vsvars32.bat"

echo Removing %1 assembly from the GAC...
echo.
GacUtil /u %1

endlocal

if errorlevel 1 goto CSharpReportError
goto CSharpEnd
:CSharpReportError
echo Project error: A tool returned an error code from the build event
exit 1
:CSharpEnd