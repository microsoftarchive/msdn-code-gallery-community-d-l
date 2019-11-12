# Direct3D Multithreaded Rendering Win32 Sample
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
- DirectX SDK
## Topics
- Graphics and 3D
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is hosted on <a href="https://github.com/walbourn/directx-sdk-samples">
GitHub</a>.</p>
<p>This is the DirectX SDK's MultithreadedRendering11 sample updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. This sample is a Win32 desktop DirectX 11.0 application for Windows 8, Windows 7,
 and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.&nbsp;</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop sample running on Windows Vista, Windows 7, and Windows 8. This is not intended for use with Windows Store apps or Windows RT, although the techniques shown are applicable.</strong></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><em><img id="96362" src="96362-multithreadedrendering11.jpg" alt="" width="90" height="71"></em></p>
<p><em>This sample uses the&nbsp;<a href="http://go.microsoft.com/fwlink/?LinkId=320437">DXUT for Direct3D 11</a>&nbsp;framework for Win32 desktop applications.</em>&nbsp;</p>
<p>This sample explains how to split rendering among multiple threads, with very low overhead. Direct3D 11 separates out much of the core rendering functionality, which used to reside in the D3D device, into a new interface called the D3D device context. D3D
 device contexts can be one of two types: immediate or deferred. An immediate context submits commands directly to the device driver, as in traditional rendering. A deferred context batches up commands for inclusion in a command list; the command list can be
 executed by an immediate context at any time, possibly running on a different thread.</p>
<p>By assigning different fragments of the overall scene to different deferred contexts (running on different CPU cores), titles can realize significant CPU performance gains.</p>
<h2>Overview</h2>
<p>The sample renders a collection of objects into the main scene, into a shadow map, and into multiple mirrors. Five options are presented in the radio buttons to the right of the window:</p>
<table border="1">
<tbody>
<tr>
<td>UI Name</td>
<td>Full name</td>
<td># deferred context</td>
<td># total threads</td>
<td>Notes</td>
</tr>
<tr>
<td>Immediate</td>
<td>Immediate</td>
<td>0</td>
<td>1</td>
<td>The frame is rendered sequentially on a single thread, using the immediate D3D device context for everything.</td>
</tr>
<tr>
<td>ST Def/scene</td>
<td>single-threaded deferred per scene</td>
<td>1 &#43; #shadows &#43; #mirrors</td>
<td>1</td>
<td>The frame is rendered sequentially on a single thread, using multiple D3D device contexts --- one deferred context per shadow map, plus one deferred context per mirror, plus the immediate context for the main scene. The deferred contexts record command
 lists which are later executed by the immediate context. This path is just an API demonstration, with no performance advantage.</td>
</tr>
<tr>
<td>MT Def/scene</td>
<td>multi-threaded deferred per scene</td>
<td>1 &#43; #shadows &#43; #mirrors</td>
<td>2 &#43; #shadows &#43; #mirrors</td>
<td>The frame is rendered on multiple threads --- one per shadow map, plus one per mirror, plus one for the main scene. The mirror threads all operate in parallel and use deferred contexts to record command lists. As before, the main thread later executes these
 command lists using the immediate context. This path has a potential performance benefit, but the benefit does not scale past the fixed number of threads.</td>
</tr>
<tr>
<td>ST Def/chunk</td>
<td>single-threaded deferred per chunk</td>
<td>#cores - 1</td>
<td>1</td>
<td>The frame is rendered on a single thread, using multiple deferred contexts --- one deferred context per available processor on the PC. Within the main scene and each of the mirror scenes, rendering is divided into chunks, and the chunks are farmed out equally
 among the deferred contexts. This path is just an API demonstration, with no performance advantage.</td>
</tr>
<tr>
<td>MT Def/chunk</td>
<td>multi-threaded deferred per chunk</td>
<td>#cores - 1</td>
<td>#cores</td>
<td>The frame is rendered on multiple worker threads --- one per available processor on the PC. The worker threads all operate in parallel and use deferred contexts to record command lists. Within the main scene and each of the subsidiary scenes, rendering
 is divided into chunks, and the chunks are farmed out equally among the deferred contexts. This path has a potential performance benefit, and the benefit scales with the number of available cores.</td>
</tr>
</tbody>
</table>
<p>&nbsp;</p>
<h1>Dependencies</h1>
<p>DXUT-based samples typically make use of runtime HLSL compilation. Build-time compilation is recommended for all production Direct3D applications, but for experimentation and samples development runtime HLSL compiliation is preferred. Therefore, the D3DCompile*.DLL
 must be available in the search path when this program is executed.</p>
<ul>
<li>When using the Windows 8.x SDK and targeting Windows Vista or later, you can include the D3DCompile_46 or D3DCompile_47 DLL side-by-side with your application copying the file from the REDIST folder.
</li></ul>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.0\Redist\D3D\arm, x86 or x64</pre>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.1\Redist\D3D\arm, x86 or x64</pre>
<h1>Building with Visual Studio 2010</h1>
<p>The code in this sample can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
<ul>
<li>Change the Platform Toolset to &quot;v100&quot; </li><li>Obtain the <a href="http://msdn.microsoft.com/en-us/windows/hardware/hh852363">
Windows SDK 8.0</a> </li><li>Use the <a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
instructions </a>for adding the Windows 8.0 SDK headers for VS 2010 projects </li></ul>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using the Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DXUT package. Remove the &quot;DXUT_2012.vcxproj&quot; &amp; &quot;DXUTOpt_2012.vcxproj&quot; references,
 add the projects &quot;DXUT_2013.vcxproj&quot; &amp; &quot;DXUTOpt_2013.vcxproj&quot;, and add new References to these projects.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<ul>
<li>July 28, 2014 - Updated for July 2014 DUXT release </li><li>October 1, 2013 - Initial release </li></ul>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
