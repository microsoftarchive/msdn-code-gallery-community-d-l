@if "%_echo%"=="" echo off

:
: Resolve the folder name in which this script is located. It will be used to locate the tracing tools.
:
for /f %%i in ("%0") do set TraceUtils=%%~dpi

set CurrentPath=%~dp0
set TraceLogTool=%TraceUtils%\tracelog.exe
set TraceFmtTool=%TraceUtils%\tracefmt.exe
set DefaultTmfFile=%TraceUtils%\default.tmf 
set TraceLogName=

:
: Process the usage help parameter.
:
if /I "%1" == "help" goto PrintUsage
if /I "%1" == "-help" goto PrintUsage
if /I "%1" == "/help" goto PrintUsage
if /I "%1" == "-h" goto PrintUsage
if /I "%1" == "/h" goto PrintUsage
if /I "%1" == "-?" goto PrintUsage
if /I "%1" == "/?" goto PrintUsage
if /I "%1" == "" goto PrintUsage

:
: Parse the command line and extract all parameters.
:
:ParseCmdLine

if /I "%1" == "-log" shift & goto GetLogName

goto CheckParams

:GetLogName
set TraceLogName=%1 

shift
goto ParseCmdLine

:CheckParams
if "%TraceLogName%"=="" goto PrintUsage

set TraceLogFileName=%TraceLogName%
for /F "tokens=2 delims=." %%A IN ("%TraceLogName%") do set TraceLogNameExt=%%A
if "%TraceLogNameExt%"=="" set TraceLogFileName=%TraceLogName: =%.bin

:
: Stop ETW trace for the first component
:
echo.
echo Stopping ETW tracing...

"%TraceLogTool%" -flush %TraceLogName% > nul
"%TraceLogTool%" -stop %TraceLogName% > nul
if ERRORLEVEL 1 echo ERROR: Unable to stop the ETW tracing, the log provider may not be running!

echo.
echo Converting the trace log into readable format...
echo.

"%TraceFmtTool%" "%TraceLogFileName%" -o "%TraceLogFileName: =%.txt" -tmf "%DefaultTmfFile%"

echo.
echo The command has completed sucessfully.

goto :eof

:PrintUsage
echo.
echo =========================================================================
echo Command-line utility to disable ETW tracing for instrumented application
echo.
echo Part of Microsoft.BizTalk.CAT.BestPractices.Samples.Tracing sample.
echo.
echo THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
echo EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
echo OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
echo -------------------------------------------------------------------------
echo.
echo Usage: 
echo.
echo	StopTrace -log ^<FileName^>
echo.
echo Where: 
echo		^<FileName^> = trace log name (.bin extension will be added if omitted)
echo.
echo Examples: 
echo		StopTrace -log MyBtsAppTrace

