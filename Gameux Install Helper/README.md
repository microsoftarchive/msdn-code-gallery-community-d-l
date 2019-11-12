# Gameux Install Helper
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- Win32
- DirectX SDK
## Topics
- Games
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>The <strong>GameuxInstallHelper</strong> is a DLL for use with install/setup programs to handle registration of Game Definition Files (GDF) with Windows Vista, Windows 7, and Windows 8 desktop games. For Windows 7 and Windows 8, the utility registers the
 GDFv2 schema data file using <code>IGameExplorer2</code>. For Windows Vista, the utility handles the additional manual steps required for registering a GDFv2 schema data file using the
<code>IGameExplorer</code> interface.</p>
<p>The package also includes <strong>GDFInstall</strong> which is a command-line test tool and utility for using the GameuxInstallHelper DLL. It supports a number of command-line options and switches. Run it with
<code>/?</code> to see this help dialog.</p>
<p><img src="57545-gdfinstall.jpg" alt="" width="487" height="429"></p>
<p>The technical article <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee419047.aspx">
Windows Games Explorer for Game Developers</a> covers usage of this install helper.</p>
<p>This utility was originally published as part of the legacy DirectX SDK. This version does not require the DirectX SDK to build and can be built using Visual Studio 2010 or Visual Studio 2012.</p>
<p><strong>Note: </strong>This utility is not required or used for Metro style applications. For details on how you use a GDF file to provide game ratings information for Metro style applications, see
<a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh452788.aspx">Windows game publishing requirements</a>.</p>
<h1>Localization</h1>
<p>The <strong>GameUxInstallHelper </strong>DLL is intended to ber called by a install/setup program which handes all UI requirements, so there is no localization support.</p>
<h1>Building with Visual Studio 2012</h1>
<p>The Visual Studio 2010 project files can be updated to use Visual Studio 2012 automatically. Be sure to add to the Processor Definitions of all configurations
<code>_WIN32_WINNT=0x0600</code> so the resulting DLL/EXE will be compatible with Windows Vista, Windows 7, and Windows 8.</p>
<h1>Version History</h1>
<p>The DirectX SDK (June 2010) contained the previously released version of this utility. This version is similiar with the following improvements:</p>
<ul>
<li><code>GameExplorerUpdate</code> API and <code>/r</code> command-line option for updating/refreshing the GDF data
</li><li>Returns an error code if detected from the Windows shell API <code>CreateShortcut</code>
</li><li>A fatal error condition no longer shows a message box and returns an failure to the caller instead
</li><li>General code cleanup and <code>/analyze</code> warnings resolved </li></ul>
<h1>More Information</h1>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee415240.aspx">Windows Games Explorer</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/apps/hh465153.aspx">Creating a GDF File</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/hh437965.aspx">Games Explorer</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/ee417691.aspx">Games for Windows Technical Requirements</a> (TR 1.1 and 1.2)</p>
<p><a href="http://msdn.microsoft.com/en-us/library/ee417692.aspx">Games for Windows Test Cases</a> (TR 1.1 and 1.2)</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
