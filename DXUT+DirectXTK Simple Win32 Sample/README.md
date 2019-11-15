# DXUT+DirectXTK Simple Win32 Sample
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
<h1>Introduction</h1>
<p>The DirectX Tool Kit is&nbsp;a collection of helper classes for writing Direct3D 11 C&#43;&#43; code for Windows Store apps, Windows 8.x Win32 desktop applications, Windows Phone 8 applications, Windows 7 applications, and Windows Vista Direct3D 11.0 applications.</p>
<p>This sample provides a simple demonstration of using the DirectXTK library in combination with the
<a href="http://go.microsoft.com/fwlink/?LinkId=320437">DXUT for Direct3D 11</a> framework for Win32 desktop applications.</p>
<p>For the latest version of DirectXTK, more detailed documentation, discussion forums, bug reports and feature requests, please visit the Codeplex site.</p>
<p><a href="http://go.microsoft.com/fwlink/?LinkId=248929">http://go.microsoft.com/fwlink/?LinkId=248929</a></p>
<p><em>This is the Win32 desktop version of this sample that will run on Windows 8.x, Windows 7, or Windows Vista SP2&#43;KB971644. There is a
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Win32-23db418a">Win32 desktop version</a> that does not make use of DXUT, a
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Sample-608bc274">Windows Store app version</a> of this sample that requires VS 2012 installed on a Windows 8 machine to build and run, a
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Sample-a0b6de36">Windows Store app for Windows 8.1</a> version of this sample, and one for
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Windows-80e6b591">Windows phone 8</a>.</em></p>
<h1>SimpleSampleTK</h1>
<p>The SimpleSample demo shows how to link to the DirectXTK library and DXUT framework together, and demonstrates the use of several DirectXTK components:</p>
<ul>
<li>SpriteBatch is used to render a Windows logo </li><li>SpriteFont and SpriteBatch are used to render text </li><li>GeometricPrimitive is used to render a teapot </li><li>PrimitiveBatch is used to render the grid </li><li>Model is used to render a mesh loaded from the legacy DirectX SDK <code>.SDKMESH</code> file &quot;Tiny.SDKMESH&quot;
</li><li>Several textures are loaded using DDSTextureLoader&nbsp;&nbsp; </li></ul>
<p><strong>Note: </strong>Because of the different versions of XAudio2 for Win32 desktop apps, this sample does not demonstrate
<em>DirectXTK for Audio</em>.</p>
<p><img id="121871" src="http://i1.code.msdn.s-msft.com/dxutdirectxtk-simple-win32-9cf797e9/image/file/121871/1/simplesampletk.jpg" alt="" width="612" height="480"></p>
<h1>ModelViewerTK</h1>
<p>This is a simple viewer application for loading .sdkmesh, .cmo, and .vbo&nbsp;files using DirectXTK's Model class and allowing viewing of the loaded model.</p>
<p><img id="121872" src="http://i1.code.msdn.s-msft.com/dxutdirectxtk-simple-win32-9cf797e9/image/file/121872/1/modelviewertk.jpg" alt="" width="576" height="480"></p>
<h1>Changes to DXUT</h1>
<p>This solution includes a DXUT_DirectXTK_2012.vcxproj and DXUTOpt_DirectxTK_2012.vcxproj based on the original DXUT_2012.vcxproj and DXUTOpt_2012.vcxproj files with the following changes:</p>
<ul>
<li><code>DDSTextureLoader.h, DDSTextureLoader.cpp, WICTextureLoader.h, WICTextureLoader.cpp, ScreenGrab.h</code>, and
<code>ScreenGrab.cpp</code> have been removed from <code>DXUT\Core</code> </li><li><code>SDKmesh.h</code> and <code>SDKmesh.cpp</code> have been removed from <code>
DXUT\Optional</code> </li><li>The projects paths now include <code>DirectXTK\Inc</code> so that DXUT will make use of the DirectXTK copy of DDSTextureLoader, WICTextureLoader, and ScreenGrab.
</li></ul>
<h1>Coordinate system</h1>
<p>This sample makes use of the left-handed coordinate system commonly assumed by DirectX Win32 desktop applications and by the DXUT framework. The&nbsp;<code>.SDKMESH</code> files are exported assuming standard backface winding for left-handed coordinates.</p>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using the Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DXUT and DirectXTK packages. Remove the &quot;DXUT_DirectXTK_2012.vcxproj&quot;, &quot;DXUTOpt_DirectXTK_2012.vcxproj&quot;
 &amp; &quot;DirectXTK_Desktop_2012.vcxproj&quot; references, add the projects &quot;DXUT_DirectXTK_2013.vcxproj&quot;, &quot;DXUTOpt_DirectXTK_2013.vcxproj&quot; &amp; &quot;DirectXTK_Desktop_2013.vcxproj&quot;, and add new References to these projects.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<p>November 24, 2014 - Updated for November 2014 releases of DXUT (11.07) and DirectX Tool Kit</p>
<p>July 29, 2014 - Updated for July 2014 releases of DXUT (11.06) and DirectX Tool Kit</p>
<p>October 28, 2013 - Updated for DXUT version 11.04 and DirectXTK October 2013</p>
<p>September 19,&nbsp;2013 - Initial release for DXUT version 11.03</p>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://directxtk.codeplex.com/">DirectX Toolkit</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
<p><a href="http://blogs.msdn.com/b/shawnhar/">Shawn Hargreaves Blog</a></p>
