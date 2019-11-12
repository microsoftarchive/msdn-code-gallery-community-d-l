# DirectXTK Simple Win32 Sample
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Win32
- DirectX
## Topics
- Graphics and 3D
## Updated
- 10/12/2015
## Description

<p>The latest version of this sample is&nbsp;hosted on <a href="https://github.com/walbourn/directxtk-samples">
GitHub</a>.</p>
<h1>Introduction</h1>
<p>The DirectX Tool Kit is&nbsp;a collection of helper classes for writing Direct3D 11 C&#43;&#43; code for Windows Store apps, Windows 8.x Win32 desktop applications, Windows Phone 8 applications, Windows 7 applications, and Windows Vista Direct3D 11.0 applications.</p>
<p>This sample provides a simple demonstration of using the DirectXTK library in a Win32 desktop application. This is based on the simple rendering loop setup in the
<a href="http://code.msdn.microsoft.com/Direct3D-Tutorial-Win32-829979ef">Direct3D Tutorial Win32 sample</a>.</p>
<p>For the latest version of DirectXTK, more detailed documentation, discussion forums, bug reports and feature requests, please visit the Codeplex site.</p>
<p><a href="http://go.microsoft.com/fwlink/?LinkId=248929">http://go.microsoft.com/fwlink/?LinkId=248929</a></p>
<p><em>This is the Win32 desktop version of this sample that will run on Windows 8.x, Windows 7, or Windows Vista SP2&#43;KB971644. There is a
<a href="http://code.msdn.microsoft.com/DXUTDirectXTK-Simple-Win32-9cf797e9">Win32 desktop version</a> that uses DXUT, a
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Sample-608bc274">Windows Store app version</a> of this sample that requires VS 2012 installed on a Windows 8 machine to build and run, a
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Sample-a0b6de36">Windows Store app for Windows 8.1</a> version of this sample, and one for
<a href="http://code.msdn.microsoft.com/DirectXTK-Simple-Windows-80e6b591">Windows phone 8</a>.</em></p>
<h1>Description</h1>
<p>The SimpleSample demo shows how to link to the DirectXTK library and demonstrates the use of several DirectXTK components:</p>
<ul>
<li>SpriteBatch is used to render a Windows logo </li><li>SpriteFont and SpriteBatch are used to render text </li><li>GeometricPrimitive is used to render a teapot </li><li>PrimitiveBatch is used to render the grid </li><li>Model is used to render a mesh loaded from the legacy DirectX SDK <code>.SDKMESH</code> file &quot;Tiny.SDKMESH&quot;
</li><li>Several textures are loaded using DDSTextureLoader </li></ul>
<p><strong>Note:</strong> Because of the different versions of XAudio2 for Win32 desktop apps, this sample does not demonstrate
<em>DirectXTK for Audio</em>. See the<em> DirectXTK for Audio Simple Win32 Sample&nbsp;</em>for
<a href="http://code.msdn.microsoft.com/DirectXTK-for-Audio-Simple-9d6a7da2">Windows 8</a> or&nbsp;down-level version that uses the legacy
<a href="http://code.msdn.microsoft.com/DirectXTK-for-Audio-Simple-928e0700">DirectX SDK</a>.&nbsp;</p>
<p>&nbsp;</p>
<p><img id="75197" src="75197-capture.jpg" alt="" width="656" height="518"></p>
<h1>Coordinate system</h1>
<p>This sample makes use of the left-handed coordinate system commonly assumed by DirectX Win32 desktop applications.
<code>.SDKMESH</code> files are exported assuming standard backface winding for left-handed coordinates. If wanting to make use of right-handed coordinates (as used by XNA Game Studio) for using
<code>.CMO</code> models instead, change the following source code in SimpleSample.cpp:</p>
<ul>
<li><code>XMMatrixLookAtLH</code> -&gt; <code>XMMatrixLookAtRH</code> </li><li><code>XMMatrixPerspectiveFovLH</code> -&gt; <code>XMMatrixPerspectiveFovRH</code>
</li><li>Change the fourth parameter for <code>CreateTeapot</code> from false to true </li><li>Change the fourth parameter for <code>CreateFromSDKMESH</code> from true to false -or- replace it with
<code>CreateFromCMO</code> and use a different model file. </li><li>Change the Z positions of the objects by making them negative numbers. </li></ul>
<h1>Building with Visual Studio 2010</h1>
<p>It is possible to modify this project to build with Visual Studio 2010 using the Windows 8.0 SDK. Set the Platform Toolset to &quot;v100&quot; for all configurations, and obtain the latest DirectXTK package. Remove the &quot;DirectXTK_Desktop_2012.vcxproj&quot; reference, add
 the project &quot;DirectXTK_Desktop_2010.vcxproj&quot;. and add a <a href="https://directxtk.codeplex.com/wikipage?title=DirectXTK">
new Reference </a>to this project. You will also need to apply the changes to the main project described on the
<a href="http://blogs.msdn.com/b/vcblog/archive/2012/11/23/using-the-windows-8-sdk-with-visual-studio-2010-configuring-multiple-projects.aspx">
Visual Studio team blog</a>.</p>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with the Visual Studio 2013 using the Windows 8.1 SDK. Set the Platform Toolset to &quot;v120&quot; for all configurations, and obtain the latest DirectXTK package. Remove the &quot;DirectXTK_Desktop_2012.vcxproj&quot;&nbsp;reference, add
 the project &quot;DirectXTK_Desktop_2013.vcxproj&quot;, and add a <a href="https://directxtk.codeplex.com/wikipage?title=DirectXTK">
new Reference</a> to this project.</p>
<p>You can also allow VS 2013 to upgrade the projects in place.</p>
<h1>Version History</h1>
<p>January 25, 2013 - Initial release</p>
<p>July 1, 2013 - Updated for July 2013 release of DirectXTK</p>
<p>October 28, 2013 - Updated for October 2013 release of DirectXTK</p>
<p>February 28, 2014 - Update for the February 2014 release of DirectXTK</p>
<p>July 24, 2014 - Update for the July 2014 release of DirectXTK</p>
<p>November 24, 2014 - Update for the November 2014 release of DirectXTK</p>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://directxtk.codeplex.com/">DirectX Toolkit</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/12/25/directx-tool-kit-for-audio.aspx">DirectX Tool Kit for Audio</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
<p><a href="http://blogs.msdn.com/b/shawnhar/">Shawn Hargreaves Blog</a></p>
