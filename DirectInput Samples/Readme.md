# DirectInput Samples
## Requires
- Visual Studio 2012
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
<p>These are the original DirectX SDK Win32 samples for the legacy <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee418273.aspx">
DirectInput</a> API updated to build with Visual Studio 2012 without using the DirectX SDK.</p>
<p><strong>These samples are based on legacy DirectX SDK DirectInput samples that were shipped as part of the DirectX 8.0 SDK (circa 2000) for Win32 desktop applications running on Windows XP, Windows Vista, Windows 7, and Windows 8. This is not intended for
 use with Windows Store apps or Windows RT.</strong></p>
<p><em>The DirectInput API is not available for&nbsp;Windows Store apps or on Windows RT (aka Windows on ARM). The Xbox 360 Common Controller and the XINPUT API is the recommended solution for modern game controllers and is supported on these platforms.</em></p>
<p><em>The DirectInput API is not recommended for use for traditional mouse and keyboard data, and use of standard Win32 messages is preferred. This is why the older DirectX SDK samples &quot;Keyboard&quot; and &quot;Mouse&quot; are not included in the latest DirectX SDK or this&nbsp;
 package.</em></p>
<p><em>The DirectInput API's remaining utility is for driving HID-only game controllers, haptic devices, and custom force-feedback devices.</em></p>
<h1>Description</h1>
<h2>CustomFormat</h2>
<p><img src="57653-customformat.gif" alt="" width="90" height="93"></p>
<p>This sample illustrates the use of a custom data format.</p>
<p><strong>Note:</strong> If your mouse has more than four buttons, not all of the buttons will be used by this sample.</p>
<p>The comments in CustomFormat.cpp explain how to create, initialize, and retrieve data with a custom data format. You might want to use a custom data format for adding support for a non-standard input device. By enumerating the device objects, you can determine&nbsp;
 exactly what data is available. The data format you create specifies how the data you are interested in will be stored.</p>
<p>For compatibility, this sample creates a new format to store mouse data. Usually, you would want to use one of the provided c_dfDIMouse types, but the steps taken to create the custom format will be the same for any hardware device. For more information,&nbsp;
 see IDirectInputDevice8::SetDataFormat.</p>
<h2>FFCont</h2>
<p><img src="57654-ffconst.gif" alt="" width="90" height="122"></p>
<div class="hxnx1" id="Description">
<p>The FFConst sample program applies raw forces to a force-feedback input device, illustrating how a simulator-type application can use force feedback to generate forces computed by a physics engine.</p>
<p>You must have a force-feedback device connected to your system in order to run the application.</p>
<p>When you run the application, it displays a window with a crosshair and a black spot in it. Click anywhere within the window's client area to move the black spot. (Note that moving the device itself does not do anything.) FFConst exerts&nbsp; a constant&nbsp;
 force on the device from the direction of the spot, in proportion to the distance from the crosshair. You can also hold down the mouse button and move the spot continuously.</p>
<p>This sample program enumerates the input devices and acquires the first force-feedback device that it finds. If none are detected, it displays a message and terminates.</p>
<p>When the user moves the black spot, joySetForcesXY function converts the cursor coordinates to a force direction and magnitude. This data is used to modify the parameters of the constant force effect.</p>
</div>
<h2>Joystick</h2>
<p><img src="57655-joystick.gif" alt="" width="90" height="101"></p>
<p>The Joystick sample program obtains and displays joystick data.</p>
<p>The application polls the joystick for immediate data in response to a timer set inside the dialog procedure.</p>
<h1>Building for Windows XP</h1>
<p>The DirectInput legacy API is available on Windows XP, so this sample can be built using Visual Studio 2012 with the Windows XP compatible Platform Toolset &quot;v110_xp&quot; included with
<em>Visual Studio 2012 Update 1</em>. Remove the link references to <code>DXGUID.LIB</code>. You will need to locally define the required GUIDs by using
<code>#define INITGUID</code> before including <code>dinput.h</code> in one of the modules.</p>
<h1>Building with Visual Studio 2010</h1>
<p>It is possible to modify these projects to build with Visual Studio 2010 without using the legacy DirectX SDK. Set the Platform Toolset to &quot;v100&quot; for all configurations, and then remove the link references to
<code>DXGUID.LIB</code>. You will need to locally&nbsp; define the required GUIDs by using
<code>#define INITGUID</code> before including <code>dinput.h</code> in one of the modules.</p>
<h1>Building with Visual Studio 2013</h1>
<p>This sample can be modified to build with Visual Studio 2013 using the Windows 8.1 SDK.</p>
<p>You can allow VS 2013 to upgrade the projects in place to use Platform Toolset &quot;v120&quot;</p>
<h1>Notes</h1>
<ul>
<li>These samples use DirectInput8. The DirectInput7 API is not supported for x64 native applications. The Windows 8.0 SDK only includes the DirectInput8 link library (<code>dinput8.lib</code>), and DirectInput7 was last supported by the DirectX SDK (August
 2007) release. </li><li>The Xbox 360 Common Controller driver exposes a legacy HID device for compatability with older DirectInput only applications. Such a device can be used with the Joystick sample as a result.
</li><li>This Xbox One driver for Windows also exposes a legacy HID device that behaves exactly as the Xbox 360 Common Controller driver's HID device support.
</li><li>Legacy joysticks using a &quot;gameport&quot; are not supported for Windows Vista, Windows 7, or Windows 8. Only HID-based USB devices are supported.
</li><li>The &quot;ActionMapper&quot; functionality was removed from DirectInput as of Windows Vista and is no longer supported.
</li></ul>
<h1>Version History</h1>
<ul>
<li>July 28, 2014 - Minor code cleanup </li><li>May 21, 2012 - Initial release of cleanup from legacy DirectX SDK </li></ul>
<h1>More Information</h1>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee417014.aspx">XINPUT and DirectInput</a></p>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/ee418864.aspx">Taking Advantage of High-Definition Mouse Movement</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/11/26/visual-studio-2012-update-1.aspx">Visual Studio 2012 Update 1</a></p>
