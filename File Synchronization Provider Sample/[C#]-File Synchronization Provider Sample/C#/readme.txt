© 2009 Microsoft Corporation.  All rights reserved.

File Synchronization Provider Sample
==============================================

Overview
--------
This sample shows how to use the file synchronization provider component of Microsoft Sync Framework.
The file synchronization provider is a fully functioning provider that helps an application to synchronize 
files and folders in NTFS, FAT, and SMB file systems. This sample synchronizes the contents of two folders
in a file system.

Required Software
-----------------
- Visual Studio 2005 or Visual Studio 2008
- .NET Framework 2.0 SP1 or .NET Framework 3.x
- Microsoft Sync Framework 2.0

Steps
-----
1. Open the FileSyncProviderSample.sln solution in Visual Studio.
2. Build the solution.
3. The application requires command line arguments of the following form:

   FileSyncSample.exe [valid directory path 1] [valid directory path 2]

   * A directory path can be either an absolute path or a path relative to the current
     working directory.

4. To set command line arguments in Visual Studio 2005, click the FileSyncProviderSample Properties item
   on the Project menu. Click the Debug tab. Enter the arguments in the "Command line arguments" text box.
5. Run the application from the command line or from within Visual Studio. To see console output in Visual
   Studio, run the application by pressing CTRL+F5.