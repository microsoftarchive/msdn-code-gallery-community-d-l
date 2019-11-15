# Direct3D 11 Install Helper
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
<p>The <strong>D3D11InstallHelper </strong>sample is designed to simplify detection of the Direct3D 11 API, automatically install the system update if applicable to an end-user's computer, and to provide appropriate messages to the end-user on manual procedure
 if a newer Service Pack is required.</p>
<p>See the <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee416644.aspx">
Direct3D 11 Deployment for Game Developers</a> article for more details.</p>
<h2>D3D11InstallHelper.dll</h2>
<p><code>D3D11InstallHelper.dll</code> hosts the core functionality for detecting Direct3D 11 components, and performing the system update through the Windows Update service if applicable. The DLL displays no messages or dialog boxes directly.</p>
<h2>D3D11Install.exe</h2>
<p><code>D3D11Install.exe</code> is a tool for using <code>D3D11InstallHelper.dll</code> as a stand-alone installer complete with UI and end-user messages, as well as acting as an example for proper use of the DLL. The process exits with a 0 if Direct3D 11
 is already installed, if the system update applies successfully without requiring a system restart, if a Service Pack installation is required, or if Direct3D 11 is not supported by this computer. A 1 is returned if the system update is applied successfully
 and requires a system restart to complete. A 2 is returned for other error conditions. Note that this executable file requires administrator rights to run, and it has a manifest that requests elevation when run on Windows Vista or Windows 7 with UAC enabled.
 D3D11Install.exe can be used as a stand-alone tool for deploying the Direct3D 11 update, or it can be used directly by installers.</p>
<p>The message depends on the system and the current configuration.</p>
<p><strong>Windows Vista / Windows Server 2008 Service Pack 2 w/ KB 971644, Windows 7, or Windows 8</strong></p>
<p><img src="http://i1.code.msdn.s-msft.com/direct3d-11-install-helper-3044575e/image/file/57674/1/capture3.jpg" alt="" width="360" height="144"></p>
<p><strong>Windows Vista / Windows Server 2008 RTM or Service Pack 1:</strong></p>
<p><img src="http://i1.code.msdn.s-msft.com/direct3d-11-install-helper-3044575e/image/file/57673/1/capture2.jpg" alt="" width="473" height="301"></p>
<p><strong>Windows Vista / Windows Server 2008 Service Pack 2 without the KB 971644 update:</strong></p>
<p><img src="http://i1.code.msdn.s-msft.com/direct3d-11-install-helper-3044575e/image/file/57672/1/capture.jpg" alt="" width="461" height="230"></p>
<p><strong>Windows XP</strong></p>
<h1><img src="http://i1.code.msdn.s-msft.com/direct3d-11-install-helper-3044575e/image/file/57675/1/capture4.jpg" alt="" width="354" height="144"></h1>
<h1>Localization</h1>
<p>The D3D11Install program is localized for Brazilian Portuguese, Dutch, English, French, German, Italian, Japanese, Korean, Polish, Russian, Simplified Chinese, Spanish, Swedish, Traditional Chinese, Czech and Norwegian (Bokmal).</p>
<h1>Building with Visual Studio 2012</h1>
<p>The Visual Studio 2010 project files can be updated to use Visual Studio 2012 automatically. Be sure to add to the Processor Definitions of all configurations<code>_WIN32_WINNT=0x0600</code> so the resulting DLL/EXE will be compatible with Windows Vista,
 Windows 7, and Windows 8.</p>
<h1>Version History</h1>
<p>The DirectX SDK (June 2010) contained the previously released version of this utility. This version is similiar with the following improvements:</p>
<ul>
<li>General code cleanup and <code>/analyze</code> warnings resolved </li><li>Fix for the resulting manifest (see the related blog <a href="http://blogs.msdn.com/b/chuckw/archive/2010/11/10/known-issue-d3d11installhelper-sample.aspx">
post</a>) </li></ul>
<h1>More Information</h1>
<p>KB <a href="http://go.microsoft.com/fwlink/?LinkId=160189">971644</a> / <a href="http://support.microsoft.com/kb/971512/">
971512</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/ee417691.aspx">Games for Windows Technical Requirements</a> (TR 1.1 and 1.2)</p>
<p><a href="http://msdn.microsoft.com/en-us/library/ee417692.aspx">Games for Windows Test Cases</a> (TR 1.1 and 1.2)</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
