# File Synchronization Provider Sample
## Requires
- Visual Studio 2005
## License
- Custom
## Technologies
- Microsoft Sync Framework 2.0
## Topics
- File Synchronization
## Updated
- 05/13/2011
## Description

<div class="wikidoc">This sample shows how to use the file synchronization provider component of Microsoft Sync Framework.The file synchronization provider is a fully functioning provider that helps an application to synchronize files and folders in NTFS,
 FAT, and SMB file systems. This sample synchronizes the contents of two folders in a file system.<br>
<br>
<strong>Required Software</strong><br>
<ul>
<li>Visual Studio 2005 or Visual Studio 2008 </li><li>.NET Framework 2.0 SP1 or .NET Framework 3.x </li><li>Microsoft Sync Framework 2.0 </li></ul>
</div>
<div class="wikidoc"><strong>Steps</strong><br>
<br>
1. Open the FileSyncProviderSample.sln solution in Visual Studio.<br>
2. Build the solution.<br>
3. The application requires command line arguments of the following form:</div>
<div class="wikidoc">
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FileSyncSample.exe [valid directory path 1] [valid directory path 2]</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; * A directory path can be either an absolute path or a path relative to the current<br>
&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; working directory.</p>
<p>4. To set command line arguments in Visual Studio 2005, click the FileSyncProviderSample Properties item on the Project menu. Click the Debug tab. Enter&nbsp;&nbsp; the arguments in the &quot;Command line arguments&quot; text box.<br>
5. Run the application from the command line or from within Visual Studio. To see console output in Visual Studio, run the application by pressing CTRL&#43;F5.</p>
<p>For more information on synchronizing files, see <a class="externalLink" href="http://msdn.microsoft.com/en-us/library/bb902860(SQL.105).aspx">
Synchronizing Files</a>.</p>
<div class="WikiContent">
<p><strong>Note:</strong>&nbsp;If you use Visual Studio 2010 to compile these samples, you will first need to remove references to the Sync Framework assemblies and then re-add the assembly references to the projects. Otherwise, you will see &quot;type or namespace
 name could not be found&quot; compilation errors.</p>
<hr>
<p><img src="http://code.msdn.microsoft.com/site/view/file/19002/1/MSF_Logo.jpg" alt="" width="639" height="56"></p>
</div>
</div>
<div class="wikidoc">&nbsp;</div>
