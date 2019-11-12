# DXUT Tutorial Win32 Sample
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
<p>This is the DirectX SDK's Direct3D Tutorial08, Tutorial09, and Tutorial10 samples updated to use Visual Studio 2012 and the Windows SDK 8.0 without any dependencies on legacy DirectX SDK content. These are samples Win32 desktop DirectX 11.0 applications
 for Windows 8, Windows 7, and Windows Vista Service Pack 2 with the DirectX 11.0 runtime.&nbsp;</p>
<p><strong>This is based on the the legacy DirectX SDK (June 2010) Win32 desktop samples running on Windows Vista, Windows 7, and Windows 8. This is not intended for use with Windows Store apps or Windows RT.</strong></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>The original Direct3D 10 tutorial series covered Win32 basics in Tutorial01 - Tutorial07, and then DXUT in Tutorial08 - Tutorial10. The Direct3D 11 versions of Tutorial01 - Tutorial07 can be find on
<a href="http://code.msdn.microsoft.com/Direct3D-Tutorial-Win32-829979ef">MSDN Code Gallery</a>. This is Tutorial08 - Tutorial10 updated to use the
<a href="http://go.microsoft.com/fwlink/?LinkId=320437">DXUT for Direct3D 11</a>&nbsp;framework for Win32 desktop applications.
<em>These tutorials do not make use of Effects 11</em>.</p>
<h2>Tutorial08</h2>
<p><img id="96238" src="96238-tutorial08.jpg" alt="" width="200" height="150"></p>
<p>This tutorial introduces DXUT. DXUT is a layer that is built on top of&nbsp;Direct3D to help make samples, prototypes, tools, and professional games more&nbsp; robust and easier to build. It simplifies Windows and Direct3D APIs, based on&nbsp; typical usage.</p>
<p>The result of this tutorial is a sample that looks just like Tutorial07. However, it is implemented differently.</p>
<h3 class="heading">DXUT</h3>
<p>DXUT provides a simplified process for creating a window, creating (or selecting) a Direct3D device, and handling Windows messages. This allows you to spend less time worrying about how to perform these standard tasks.</p>
<div class="hxnx1" id="DXUT">
<p>DXUT for Direct3D 11 is also highly componentized. The core component of DXUT contains the standard window creation, device creation, and management functions. Optional components of DXUT include functions such as camera manipulation, a GUI system, and mesh
 handling. This tutorial explains the DXUT core component. Optional components are explained in later tutorials. Features introduced in this tutorial include device creation, the main loop, and simple keyboard input.</p>
<p>DXUT exposes a wide range of callback functions that the user can hook into. The callbacks are called by DXUT at logical points during program execution. You can insert custom code into the callbacks to build the application, while DXUT manages the window
 and device management implementation requirements.</p>
<h4 class="subHeading">Setting Callback Functions</h4>
<div class="hxnx2" id="Setting_Callback_Functions">
<p>Modifying the WinMain function of an application is the first step. In previous tutorials, WinMain invoked the initialization function, and then entered the message loop. In the DXUT framework, WinMain behaves similarly.</p>
<p>First, the callback functions are set by the application. These are the functions that DXUT calls during specific events when the application is run. Notable events include device creation, swap chain creation, keyboard entry, frame move, and frame rendering.</p>
<pre>// Direct3D11 callbacks
DXUTSetCallbackD3D11DeviceAcceptable( IsD3D11DeviceAcceptable );
DXUTSetCallbackD3D11DeviceCreated( OnD3D11CreateDevice );
DXUTSetCallbackD3D11SwapChainResized( OnD3D11ResizedSwapChain );
DXUTSetCallbackD3D11SwapChainReleasing( OnD3D11ReleasingSwapChain );
DXUTSetCallbackD3D11DeviceDestroyed( OnD3D11DestroyDevice );
DXUTSetCallbackD3D11FrameRender( OnD3D11FrameRender );

DXUTSetCallbackMsgProc( MsgProc );
DXUTSetCallbackKeyboard( KeyboardProc );
DXUTSetCallbackFrameMove( OnFrameMove );
DXUTSetCallbackDeviceChanging( ModifyDeviceSettings );</pre>
<pre>DXUTSetCallbackDeviceRemoved( OnDeviceRemoved );<br></pre>
<p>Then the application sets any additional DXUT settings, as in the following example:</p>
<pre>    // Show the cursor and clip it when in full screen
    DXUTSetCursorSettings( true, true );
</pre>
<p>Finally, the initialization functions are called. The difference between this tutorial and the basic tutorials is that you have to deal only with application specific code during initialization. This is because the device and window creation is handled by
 DXUT. Application specific code can be inserted during each of the associated callback functions. DXUT invokes these functions as it progresses through the initialization process.</p>
<pre>    // Initialize DXUT and create the desired Win32 window and Direct3D 
    // device for the application. Calling each of these functions is optional, but they
    // allow you to set options that control the behavior of the framework.
    DXUTInit( true, true, nullptr ); // Parse the command line, handle the default hotkeys, and show msgboxes
    DXUTCreateWindow( L&quot;Tutorial8&quot; );
    DXUTCreateDevice( D3D_FEATURE_LEVEL_10_0, true, 800, 600 );&nbsp;</pre>
</div>
</div>
<h4>Debugging with DXUTTrace</h4>
<p>DXUTTrace is a macro that can be called to create debug output for the application. It functions much like the standard debug output functions, but it allows a variable number of arguments. For example:</p>
<pre>&nbsp;&nbsp;&nbsp; DXUTTRACE( L&quot;Hit points left: %d\n&quot;, nHitPoints );</pre>
<p>In this tutorial, it is placed next to function entry, to report the state of the application. For instance, at the beginning of OnD3D11ResizedSwapChain(), the debugger reports &quot;SwapChain Reset called&quot;.</p>
<pre>&nbsp;&nbsp;&nbsp; DXUTTRACE( L&quot;SwapChain Reset called\n&quot; );</pre>
<h3>Device Management and Initialization</h3>
<p>DXUT provides various methods for creating and configuring the window and the Direct3D device. The methods that are used in this tutorial are listed below. They are sufficient for a moderately complex Direct3D application.</p>
<p>The procedure from the previous tutorial inside InitDevice() and CleanupDevice() has been properly managed by splitting it into the following functions.</p>
<ul>
<li>IsD3D11DeviceAcceptable Callback </li><li>ModifyDeviceSettings Callback </li><li>OnD3D11CreateDevice Callback </li><li>OnD3D11DestroyDevice Callback </li></ul>
<p>Because not all resources are created at the same time, we can minimize overhead by reducing the number of repeated calls. We achieve this goal by recreating only resources that are context dependent. For the sake of simplicity, previous tutorials recreated
 everything whenever the screen was resized.</p>
<h4>IsD3D11DeviceAcceptable Callback</h4>
<p>This function is invoked for each combination of valid device settings that is found on the system. It allows the application to accept or reject each combination. For example, the application can reject all REF devices, or it can reject full screen device
 setting combinations.</p>
<p>In this tutorial, all devices are acceptable, because we do not need any advanced functionality.</p>
<h4>ModifyDeviceSettings Callback</h4>
<p>This callback function allows the application to change any device settings immediately before DXUT creates the device. In this tutorial, nothing needs to be done in the callback, because we do not need any advanced functionality.</p>
<h4>OnD3D11CreateDevice Callback</h4>
<p>This function is called after the Direct3D11 device is created. After the device is created, an application can use this callback to allocate resources, set buffers, and handle other necessary tasks.</p>
<p>In this tutorial, most of the InitDevice() function from tutorial 7 is copied into this callback function. The code for device and swap chain creation is omitted, because these functions are handled by DXUT. OnD3D11CreateDevice creates the effect, the vertex/index
 buffers, the textures, and the transformation matrices. The code has been copied from tutorial 7 with minimal alterations.</p>
<h4>OnD3D11DestroyDevice Callback</h4>
<p>This callback function is called immediately before the ID3D11Device is released by DXUT. This callback is used to release resources that were used by the device.</p>
<p>In this tutorial, OnD3D11DestroyDevice releases the resources that were created by the OnD3D11CreateDevice function. These resources include the vertex/index buffers, the layout, the textures, and the effect. The code is copied from the CleanupDevice() function,
 but it has been changed to use the SAFE_RELEASE macro.</p>
<h3>Rendering</h3>
<p>For rendering, DXUT provides two callback functions to initiate rendering for your application. The first, OnFrameMove, is called before each frame is rendered. It advances time in the application. The second, OnD3D11FrameRender, provides rendering for DXUT.</p>
<p>These two functions split the work of the Render() function into logical steps. OnFrameMove updates all the matrices for animation. OnD3D11FrameRender contains the rendering calls.</p>
<h4>OnFrameMove Callback</h4>
<p>This function is called before a frame is rendered. It is used to process the world state. However, its update frequency depends on the speed of the system. On faster systems, it is called more often per second. This means that any state update code must
 be regulated by time. Otherwise, it performs differently on a slower system than on a faster system.</p>
<p>Every time the function is called in the tutorial, the world is updated once, and the mesh color is adjusted. This code is copied directly from the Render() function in tutorial 7. Note that the rendering calls are not included.</p>
<h4>OnD3D11FrameRender Callback</h4>
<p>This function is called whenever a frame is redrawn. Within this function, effects are applied, resources are associated, and the drawing for the scene is called.</p>
<p>In this tutorial, this function contains the calls to clear the back buffer and stencil buffer, set up the matrices, and draw the cubes.</p>
<h3>Message Processing</h3>
<p>Message processing is an intrinsic property of all window applications. DXUT exposes these messages for advanced applications.</p>
<h4>MsgProc Callback</h4>
<p>DXUT invokes this function when window messages are received. The function allows the application to handle messages as it sees fit.</p>
<p>In this tutorial, no additional messages are handled.</p>
<h4>KeyboardProc Callback</h4>
<p>This callback function is invoked by DXUT when a key is pressed. It can be used as a simple function to process keyboard commands.</p>
<p>The KeyboardProc callback is not used in this tutorial, because keyboard interaction is not necessary. However, there is a skeleton case for F1, which you can experiment with. Try to insert code to toggle the rotation of the cubes.</p>
<h3>Summary</h3>
<p>The functions covered in this tutorial can get you started with a project on DXUT. Tutorials 9 and 10 cover more advanced DXUT features.</p>
<p>To start a new project using DXUT, you can use the Sample Browser to copy and rename any sample project in the DirectX SDK. The EmptyProject sample is a good blank starting point for DXUT applications, or you can choose another sample.</p>
<h2>Tutorial09</h2>
<p><img id="96239" src="96239-tutorial09.jpg" alt="" width="200" height="150"></p>
<p>This tutorial introduces the use of meshes to import source art. It&nbsp;demonstrates meshes by using DXUT. However, meshes can also be used without&nbsp;DXUT.&nbsp;</p>
<p>In the tutorial, you replace a cube in the center of the window with a model&nbsp;that is imported from a file. The model already contains a texture with mapped&nbsp; coordinates.&nbsp;</p>
<h3>Meshes</h3>
<p>Listing each vertex within the source code is a tedious and crude method to define source art. Instead, there are methods to import already constructed models into your application.&nbsp;</p>
<p>A mesh is a collection of predefined vertex data which often includes additional information such as normal vectors, colors, materials, and texture coordinates. As long as the format of the mesh file is known, the mesh file can be imported and rendered.</p>
<p>Meshes are used to maintain source art separately from application code, so that the art can be reused. Therefore, meshes are stored in separate files. They are rarely generated in an application itself. Instead, they are created in 3D authoring software.
 The cube that was generated in previous tutorials can be saved into a separate file, and then re-loaded. However, importing can be much more efficient, especially if the mesh scales in complexity. One of the biggest benefits is the ability to import the texture
 coordinates, so that they match up perfectly. These can easily be specified in authoring applications.&nbsp;</p>
<p>DXUT handles meshes by using the CDXUTSDKMesh class. This class includes functions to import, render, and destroy a mesh. The file format we use for importing is the .SDKMESH format. See the&nbsp;<a href="http://go.microsoft.com/fwlink/?LinkId=226208">Samples
 Content Exporter</a> for a utility that can generate these files from Autodesdk FBX files.&nbsp;</p>
<h3>Creating the Mesh</h3>
<p>To import the model, we first create a CDXUTSDKMesh object. It is called g_Mesh in this case, but in general the object name and the source art name should match, for easier association.</p>
<pre>&nbsp;&nbsp;&nbsp; CDXUTSDKMesh g_Mesh;</pre>
<p>Next, we call the Create function to read the&nbsp;SDKMESH file and store it into the object. The Create function requires that we pass in the D3D11Device&nbsp;and&nbsp;the name of the&nbsp;file holding our mesh</p>
<p>In this case, we import a file that is called &quot;tiny.sdkmesh&quot;. The format for the vertices that define this mesh contains vertex coordinates, normals, and texture coordinates. We must specify our input layout to match, as shown in the following example.</p>
<pre>&nbsp;&nbsp;&nbsp; // Define the input layout
&nbsp;&nbsp;&nbsp; const D3D11_INPUT_ELEMENT_DESC layout[] =
&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { L&quot;POSITION&quot;, 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 0, D3D11_INPUT_PER_VERTEX_DATA, 0 },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { L&quot;NORMAL&quot;, 0, DXGI_FORMAT_R32G32B32_FLOAT, 0, 12, D3D11_INPUT_PER_VERTEX_DATA, 0 },
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; { L&quot;TEXCOORD0&quot;, 0, DXGI_FORMAT_R32G32_FLOAT, 0, 24, D3D11_INPUT_PER_VERTEX_DATA, 0 },
&nbsp;&nbsp;&nbsp; };&nbsp;</pre>
<p>After the layout is defined, we call the Create function to import the model.</p>
<pre>&nbsp;&nbsp;&nbsp;&nbsp; // Load the mesh
&nbsp;&nbsp;&nbsp; V_RETURN( g_Mesh.Create( pd3dDevice, L&quot;tiny.sdkmesh&quot; ) );</pre>
<p>If there are no errors, g_Mesh now contains the vertex and index buffer for our newly imported mesh, as well as textures and materials. Next we begin rendering.&nbsp;</p>
<h3>Rendering the Mesh</h3>
<p>In the previous tutorials, because we had explicit control of the vertex buffer and the index buffers, we had to set them up properly before every frame. However, with a mesh, these elements are abstracted. Therefore, we only have to provide the effects
 technique that should be used to render the mesh, and it does all the work.</p>
<p>The difference from the previous tutorial is that we removed the portion of OnD3D11FrameRender where it began rendering the cube. We replaced it with the mesh rendering call. It is always good practice to set the correct input layout before any mesh is rendered.
 This ensures that the layout of the mesh matches the input assembler.</p>
<pre>&nbsp;&nbsp;&nbsp; //
&nbsp;&nbsp;&nbsp; // Set the Vertex Layout
&nbsp;&nbsp;&nbsp; //&nbsp;&nbsp;&nbsp; pd3dDevice-&gt;IASetInputLayout( g_pVertexLayout );</pre>
<p>The actual rendering is done by calling the Render function inside the CDXUTSDKMesh class. After the technique's buffers are correctly associated, it can be rendered.</p>
<pre>&nbsp;&nbsp;&nbsp; //
&nbsp;&nbsp;&nbsp; // Render the mesh
&nbsp;&nbsp;&nbsp; //
&nbsp;&nbsp;&nbsp; UINT Strides[1];
&nbsp;&nbsp;&nbsp; UINT Offsets[1];
&nbsp;&nbsp;&nbsp; ID3D11Buffer* pVB[1];
&nbsp;&nbsp;&nbsp; pVB[0] = g_Mesh.GetVB11( 0, 0 );
&nbsp;&nbsp;&nbsp; Strides[0] = ( UINT )g_Mesh.GetVertexStride( 0, 0 );
&nbsp;&nbsp;&nbsp; Offsets[0] = 0;
&nbsp;&nbsp;&nbsp; pd3dImmediateContext-&gt;IASetVertexBuffers( 0, 1, pVB, Strides, Offsets );
&nbsp;&nbsp;&nbsp; pd3dImmediateContext-&gt;IASetIndexBuffer( g_Mesh.GetIB11( 0 ), g_Mesh.GetIBFormat11( 0 ), 0 );&nbsp;
</pre>
<p>Because we are not using the Effects 11 library, the application is responsible for setting up the shaders and constants. After that is done, we can render the mesh one subset at a time.</p>
<pre>&nbsp;&nbsp;&nbsp; for( UINT subset = 0; subset &lt; g_Mesh.GetNumSubsets( 0 ); &#43;&#43;subset )
&nbsp;&nbsp;&nbsp; {
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; auto pSubset = g_Mesh.GetSubset( 0, subset );&nbsp;</pre>
<pre>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; auto PrimType = g_Mesh.GetPrimitiveType11( ( SDKMESH_PRIMITIVE_TYPE )pSubset-&gt;PrimitiveType );
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pd3dImmediateContext-&gt;IASetPrimitiveTopology( PrimType );&nbsp;</pre>
<pre>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Ignores most of the material information in them mesh to use only a simple shader
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; auto pDiffuseRV = g_Mesh.GetMaterial( pSubset-&gt;MaterialID )-&gt;pDiffuseRV11;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pd3dImmediateContext-&gt;PSSetShaderResources( 0, 1, &amp;pDiffuseRV );&nbsp;</pre>
<pre>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; pd3dImmediateContext-&gt;DrawIndexed( ( UINT )pSubset-&gt;IndexCount, 0, ( UINT )pSubset-&gt;VertexStart );
&nbsp;&nbsp;&nbsp; }</pre>
<p>If the world matrix is properly set for the model, we can now see that the cube in our previous example is replaced by this more complicated mesh. Notice that the mesh is much bigger than the cube. Try applying a scale to the world matrix to get the mesh
 to fit the screen better.&nbsp;</p>
<h3>Destroying the Mesh</h3>
<p>Like all objects, the CDXUTSDKMesh object must be destroyed after usage. This is done by calling the Destroy function.&nbsp;</p>
<pre>&nbsp;&nbsp;&nbsp; g_Mesh.Destroy();&nbsp;&nbsp;</pre>
<h2>Tutorial10</h2>
<p><img id="96240" src="96240-tutorial10.jpg" alt="" width="200" height="150"></p>
<p>This tutorial covers the advanced DXUT concepts. Most of the functionality that is demonstrated in this tutorial is optional. However, it can be used to enhance your application with minimal cost. DXUT provides a simple sprite based GUI system and a device
 settings dialog. In addition, it provides a few types of camera classes.</p>
<p>In this tutorial, you create a fully functional GUI to modify settings by using the device and scene. There will be buttons, sliders, and text to demonstrate these capabilities.</p>
<h3>DXUT Camera</h3>
<p>The CModelViewerCamera class within DXUT is provided to simplify the management of the view and projection transformations. It also provides GUI functionality.</p>
<pre>&nbsp;&nbsp;&nbsp; CModelViewerCamera g_Camera;&nbsp; // A model viewing camera</pre>
<p>The first function that the camera provides is the creation of the view and projection matrices. With the camera, there is no need to worry about these matrices. Instead, specify the viewer location, the view itself, and the size of the window. Then, pass
 these parameters to the camera object, which creates the matrices behind the scene.</p>
<p>The following example sets the view portion of the camera. This includes location and view.</p>
<pre>&nbsp;&nbsp;&nbsp; // Initialize the camera</pre>
<pre>&nbsp;&nbsp;&nbsp; static const XMVECTORF32 s_Eye = { 0.0f, 3.0f, -800.0f, 0.f };<br>&nbsp;&nbsp;&nbsp; static const XMVECTORF32 s_At = { 0.0f, 1.0f, 0.0f, 0.f };<br>&nbsp;&nbsp;&nbsp; g_Camera.SetViewParams( s_Eye, s_At );</pre>
<p>Next, specify the projection portion of the camera. We need to provide the viewing angle, the aspect ratio, and the near and far clipping planes for the view frustum. This is the same information that was required in previous tutorials. However, in this
 tutorial we do not worry about creating the matrices themselves.</p>
<pre>&nbsp;&nbsp;&nbsp; // Setup the camera's projection parameters</pre>
<pre>&nbsp;&nbsp;&nbsp; float fAspectRatio = pBackBufferSurfaceDesc-&gt;Width / ( FLOAT )pBackBufferSurfaceDesc-&gt;Height;<br>&nbsp;&nbsp;&nbsp; g_Camera.SetProjParams( XM_PI / 4, fAspectRatio, 0.1f, 1000.0f );<br>&nbsp;&nbsp;&nbsp; g_Camera.SetWindow( pBackBufferSurfaceDesc-&gt;Width, pBackBufferSurfaceDesc-&gt;Height );</pre>
<p>The camera also creates masks for simple mouse feedback. Here, we specify three mouse buttons to utilize for the mouse operations that are provided&mdash;model rotation, zooming, and camera rotation. Try compiling the project and playing with each button
 to understand what each operation does.</p>
<pre>&nbsp;&nbsp;&nbsp; g_Camera.SetButtonMasks( MOUSE_LEFT_BUTTON, MOUSE_WHEEL, MOUSE_MIDDLE_BUTTON );</pre>
<p>After the buttons are set, the camera listens for mouse inputs and acts accordingly. To respond to user input, add a listener to the MsgProc callback function. This is the function that DXUT routes messages to.</p>
<pre>&nbsp;&nbsp;&nbsp; // Pass all remaining windows messages to camera so it can respond to user input<br>&nbsp;&nbsp;&nbsp; g_Camera.HandleMessages( hWnd, uMsg, wParam, lParam );</pre>
<p>Finally, after all the required data is entered into the camera, we extract the actual matrices for the transformations. We grab the projection matrix and the view matrix, together with the associated functions. The camera object is responsible for computing
 the matrices themselves.</p>
<pre>&nbsp;&nbsp;&nbsp; XMMATRIX mView = g_Camera.GetViewMatrix();<br>&nbsp;&nbsp;&nbsp; XMMATRIX mProj = g_Camera.GetProjMatrix();<br>&nbsp;&nbsp;&nbsp; XMMATRIX mWorldViewProjection = g_World * mView * mProj;</pre>
<h3>DXUT Dialogs</h3>
<p>User interaction can be accomplished by using the CDXUTDialog class. This contains controls in a dialog that accepts user input, and passes it to the application to handle. First, the dialog class is instantiated. Then, individual controls can be added.</p>
<h4>Declarations</h4>
<p>In this tutorial, two dialogs are added. One is called g_HUD, and it contains the same code as the Direct3D 11 samples. The other is called g_SampleUI, and it demonstrates functions that are specific to this tutorial. The second dialog is used to control
 the &quot;puffiness&quot; of the model. It sets a variable that is passed into the shaders.</p>
<pre>&nbsp;&nbsp;&nbsp; CDXUTDialog g_HUD;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // manages the 3D UI<br>&nbsp;&nbsp;&nbsp; CDXUTDialog g_SampleUI; // dialog for sample specific controls</pre>
<p>The dialogs are controlled by a class called CDXUTDialogResourceManager. It passes messages and handles resources that are shared by the dialogs.</p>
<pre>&nbsp;&nbsp;&nbsp; CDXUTDialogResourceManager g_DialogResourceManager; // manager for shared resources of dialogs</pre>
<p>Finally, a new callback function is associated with the events that are processed by the GUI. This function is used to handle the interaction between the controls.</p>
<pre>&nbsp;&nbsp;&nbsp; void CALLBACK OnGUIEvent( UINT nEvent, int nControlID, CDXUTControl* pControl, void* pUserContext );</pre>
<h4>Dialog Initialization</h4>
<p>Because more utilities have been introduced, and need to be initialized, this tutorial moves the initialization of these modules to a separate function, called InitApp().</p>
<p>The controls for each dialog are initialized inside this function. Each dialog calls its Init function, and passes in the resource manager to specify where the control should be placed. It also sets the callback function to process the GUI responses. In
 this case, the associated callback function is OnGUIEvent.</p>
<pre>&nbsp;&nbsp;&nbsp; g_HUD.Init( &amp;g_DialogResourceManager );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.Init( &amp;g_DialogResourceManager );<br>&nbsp;&nbsp;&nbsp; g_HUD.SetCallback( OnGUIEvent );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.SetCallback( OnGUIEvent );</pre>
<p>After each dialog is initialized, it can insert the controls to use. The HUD adds three buttons for the basic functionality: toggle fullscreen, toggle reference (software) renderer, and change device.</p>
<p>To add a button, specify the IDC identifier to use, a string to display, the coordinates, the width and length, and optionally a keyboard shortcut to associate with the button.</p>
<p>Note that the coordinates are relative to the anchor of the dialog.</p>
<pre>&nbsp;&nbsp;&nbsp; int iY = 10;<br>&nbsp;&nbsp;&nbsp; g_HUD.AddButton( IDC_TOGGLEFULLSCREEN, L&quot;Toggle full screen&quot;, 0, iY, 170, 22 );<br>&nbsp;&nbsp;&nbsp; g_HUD.AddButton( IDC_CHANGEDEVICE, L&quot;Change device (F2)&quot;, 0, iY &#43;= 26, 170, 22, VK_F2 );<br>&nbsp;&nbsp;&nbsp; g_HUD.AddButton( IDC_TOGGLEREF, L&quot;Toggle REF (F3)&quot;, 0, iY &#43;= 26, 170, 22, VK_F3 );<br>&nbsp;&nbsp;&nbsp; g_HUD.AddButton( IDC_TOGGLEWARP, L&quot;Toggle WARP (F4)&quot;, 0, iY &#43;= 26, 170, 22, VK_F4 );&nbsp;</pre>
<p>Similarly for the sample UI, three controls are added&mdash;one static text, one slider, and one checkbox.</p>
<p>The static text parameters are the IDC identifier, the string, the coordinates, and the width and height.</p>
<p>The slider parameters are the IDC identifier, the coordinates, the width and height, then the min and max values of the slider, and finally the variable to store the result.</p>
<p>The checkbox parameters are the IDC identifier, a string label, the coordinates, the width and height, and the Boolean variable to store the result.</p>
<pre>&nbsp;&nbsp;&nbsp; iY = 10;<br>&nbsp;&nbsp;&nbsp; WCHAR sz[100];<br>&nbsp;&nbsp;&nbsp; iY &#43;= 24;<br>&nbsp;&nbsp;&nbsp; swprintf_s( sz, 100, L&quot;Puffiness: %0.2f&quot;, g_fModelPuffiness );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.AddStatic( IDC_PUFF_STATIC, sz, 0 , iY &#43;= 26, 170, 22 );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.AddSlider( IDC_PUFF_SCALE, 50, iY &#43;= 26, 100, 22, 0, 2000, ( int )( g_fModelPuffiness * 100.0f ) );</pre>
<pre>&nbsp;&nbsp;&nbsp; iY &#43;= 24;<br>&nbsp;&nbsp;&nbsp; g_SampleUI.AddCheckBox( IDC_TOGGLESPIN, L&quot;Toggle Spinning&quot;, 0, iY &#43;= 26, 170, 22, g_bSpinning );</pre>
<p>After the dialogs are initialized, they must be placed on the screen. This is done during the OnD3D11ResizedSwapChain call, because the screen coordinates can change every time the swap chain is recreated&mdash;for example, if the window is resized.</p>
<pre>&nbsp;&nbsp;&nbsp; g_HUD.SetLocation( pBackBufferSurfaceDesc-&gt;Width-170, 0 );<br>&nbsp;&nbsp;&nbsp; g_HUD.SetSize( 170, 170 );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.SetLocation( pBackBufferSurfaceDesc-&gt;Width-170, pBackBufferSurfaceDesc-&gt;Height-300 );<br>&nbsp;&nbsp;&nbsp; g_SampleUI.SetSize( 170, 300 );</pre>
<p>Finally, the dialogs must be identified in the OnD3D11FrameRender function. This allows the dialogs to be drawn so that the user can actually see them.</p>
<pre>&nbsp;&nbsp;&nbsp; //<br>&nbsp;&nbsp;&nbsp; // Render the UI<br>&nbsp;&nbsp;&nbsp; //<br>&nbsp;&nbsp;&nbsp; g_HUD.OnRender( fElapsedTime ); <br>&nbsp;&nbsp;&nbsp; g_SampleUI.OnRender( fElapsedTime );&nbsp;</pre>
<h3>Resource Manager Initialization</h3>
<p>The resource manager must be initialized at every callback that is associated with initialization and destruction. This is because the GUI must be recreated whenever a device is created, or a swap chain is recreated. The CDXUTDialogResourceManager class
 contains functions that correspond to each callback. Each function has the same name as its corresponding callback. All we need to do to is insert the code to call them in the appropriate places.</p>
<pre>&nbsp;&nbsp;&nbsp; V_RETURN( g_DialogResourceManager.OnD3D11CreateDevice( pd3dDevice, pd3dImmediateContext ) );<br>&nbsp;&nbsp;&nbsp; V_RETURN( g_DialogResourceManager.OnD3D11ResizedSwapChain( pd3dDevice, pBackBufferSurfaceDesc ) );<br>&nbsp;&nbsp;&nbsp; g_DialogResourceManager.OnD3D11ReleasingSwapChain();<br>&nbsp;&nbsp;&nbsp; g_DialogResourceManager.OnD3D11DestroyDevice();</pre>
<h4>Responding to GUI Events</h4>
<p>After everything is initialized, we can write code to handle the GUI interaction. During initialization of the dialogs, we set the callback function to OnGUIEvent. Now we create the OnGUIEvent function, which listens for events that are related to the GUI
 and then processes them. (The GUI is invoked by the framework.)</p>
<p>OnGUIEvent is a simple function that contains a case statement for each IDC identifier that was listed when the dialogs were created. Each case statement contains the handler code, with the assumption that the user interacts with the control. The code here
 is very similar to the Win32 code that handles controls.</p>
<p>The controls that are related to the HUD call functions that are built into DXUT. There is a DXUT function to switch between fullscreen and windowed mode, to switch the reference software renderer on and off, and to change the device settings.</p>
<p>The SampleUI dialog contains custom code to manipulate the variables that are associated with the slider. It gathers the value, updates the associated text, and passes the value to the shader.&nbsp;</p>
<pre style="padding-left:30px">void CALLBACK OnGUIEvent( UINT nEvent, int nControlID, CDXUTControl* pControl, void* pUserContext )<br>{<br>&nbsp;&nbsp;&nbsp; switch( nControlID )<br>&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_TOGGLEFULLSCREEN:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DXUTToggleFullScreen();<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_TOGGLEREF:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DXUTToggleREF();<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_TOGGLEWARP:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DXUTToggleWARP();<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_CHANGEDEVICE:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_SettingsDlg.SetActive( !g_SettingsDlg.IsActive() );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;</pre>
<pre style="padding-left:30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_TOGGLESPIN:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_bSpinning = g_SampleUI.GetCheckBox( IDC_TOGGLESPIN )-&gt;GetChecked();<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</pre>
<pre style="padding-left:30px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; case IDC_PUFF_SCALE:<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; WCHAR sz[100];<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_fModelPuffiness = ( float )( g_SampleUI.GetSlider( IDC_PUFF_SCALE )-&gt;GetValue() * 0.01f );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; swprintf_s( sz, 100, L&quot;Puffiness: %0.2f&quot;, g_fModelPuffiness );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_SampleUI.GetStatic( IDC_PUFF_STATIC )-&gt;SetText( sz );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; break;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</pre>
<pre style="padding-left:30px">&nbsp;&nbsp;&nbsp; }<br>}</pre>
<h4>Updating Message Processing</h4>
<p>Now we have dialog messages and user interactions. Messages that are passed to the application must be handled by the dialogs. The relevant code is handled within the MsgProc callback that is provided by DXUT. In previous tutorials, this section is empty,
 because there are no messages to be processed. Now, we must make sure that messages intended for the resource manager and dialogs are properly routed.</p>
<p>No special message processing code is required. We just call the MsgProcs for each dialog, to ensure that the message is handled. This is done by calling the MsgProc function that corresponds to each class. Note that the function provides a flag to notify
 the framework that no further processing of the message is required, and therefore the framework can exit.</p>
<pre>&nbsp;&nbsp;&nbsp; LRESULT CALLBACK MsgProc( HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam, bool* pbNoFurtherProcessing, void* pUserContext )<br>&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Always allow dialog resource manager calls to handle global messages<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // so GUI state is updated correctly<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *pbNoFurtherProcessing = g_DialogResourceManager.MsgProc( hWnd, uMsg, wParam, lParam );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if( *pbNoFurtherProcessing )<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if( g_D3DSettingsDlg.IsActive() )<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_D3DSettingsDlg.MsgProc( hWnd, uMsg, wParam, lParam );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Give the dialogs a chance to handle the message first<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *pbNoFurtherProcessing = g_HUD.MsgProc( hWnd, uMsg, wParam, lParam );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if( *pbNoFurtherProcessing )<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *pbNoFurtherProcessing = g_SampleUI.MsgProc( hWnd, uMsg, wParam, lParam );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if( *pbNoFurtherProcessing )<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if( uMsg == WM_CHAR &amp;&amp; wParam == '1' )<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DXUTToggleFullScreen();<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp; }</pre>
<h3>3D Settings Dialog</h3>
<p>There is a special built-in dialog that controls the settings of the Direct3D device. This dialog is provided by DXUT as CD3DSettingsDlg. It functions like a custom dialog, but it provides all the options that users need to modify settings.</p>
<pre>&nbsp;&nbsp;&nbsp; CD3DSettingsDlg&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_SettingsDlg;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Device settings dialog</pre>
<p>Initialization is much like other dialogs. Simply call the Init function. However, every time Direct3D changes its swap chain or device, the dialog must also be updated. Therefore, it must include an appropriately named call within OnD3D11CreateDevice and
 OnD3D11ResizedSwapChain. Likewise, changes to destroyed objects must also be notified. Therefore, we need the appropriate calls within OnD3D11DestroyDevice.</p>
<pre>&nbsp;&nbsp;&nbsp; g_SettingsDlg.Init( &amp;g_DialogResourceManager );<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp; V_RETURN( g_SettingsDlg.OnD3D11CreateDevice( pd3dDevice ) );<br>&nbsp;&nbsp;&nbsp; V_RETURN( g_SettingsDlg.OnD3D11ResizedSwapChain( pd3dDevice, pBackBufferSurfaceDesc ) );<br>&nbsp;&nbsp;&nbsp; <br>&nbsp;&nbsp;&nbsp; g_SettingsDlg.OnD3D11DestroyDevice();</pre>
<p>On the rendering side, to switch the appearance of the dialog, we use a flag called IsActive(). If this flag is set to false, then the panel is not rendered. Switching the panel is handled by the HUD dialog. The IDC_CHANGEDEVICE that is associated with the
 HUD controls this flag.</p>
<pre>&nbsp;&nbsp;&nbsp; if( g_SettingsDlg.IsActive() )<br>&nbsp;&nbsp;&nbsp; {<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; g_SettingsDlg.MsgProc( hWnd, uMsg, wParam, lParam );<br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return 0;<br>&nbsp;&nbsp;&nbsp; }</pre>
<p>After the initialization steps are complete, you can include the dialog in your application. Try compiling the tutorial and interacting with the Change Settings panel to see its effect. The reconstruction of the Direct3D device or swap chain is done internally
 by DXUT.</p>
<h3>Text Rendering</h3>
<p>An application is not very interesting if the user has no idea what to do. DXUT includes a utility class to draw 2D text onto the screen, for feedback to the user. This class, CDXUTTextHelper, allows you to draw lines of text anywhere on the screen, by using
 simple string inputs. First, we instantiate the class. Because text rendering can be isolated from most of the initialization procedures, we keep most of the code within RenderText.</p>
<pre style="padding-left:30px">CDXUTTextHelper* g_pTxtHelper = nullptr;</pre>
<pre style="padding-left:30px">g_pTxtHelper = new CDXUTTextHelper( pd3dDevice, pd3dImmediateContext, &amp;g_DialogResourceManager, 15 );</pre>
<h4>Rendering</h4>
<p>The text in this sample includes statistics on the rendering. There is also a help section that explains how to manipulate the model by using the mouse.</p>
<p>The rendering calls must be done within OnD3D11FrameRender. Here, we call RenderText within the frame render call.</p>
<p>The first section is always rendered first. The first call to text rendering is Begin(). This notifies the engine to start sending text to the screen. Next, we set the position of the cursor and the color of the text. Now we can draw.</p>
<p>Text string output is performed by calling DrawTextLine. Pass in the string, and output that corresponds to the string is provided at the current position. The cursor is incremented while text is written. For example, if the string contains &quot;\n&quot;, the cursor
 is automatically moved to the next line.</p>
<pre>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;Begin();<br>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;SetInsertionPos( 5, 5 );<br>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;SetForegroundColor( Colors::Yellow );<br>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;DrawTextLine( DXUTGetFrameStats( DXUTIsVsyncEnabled() ) );<br>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;DrawTextLine( DXUTGetDeviceStats() );</pre>
<p>Because the help text is drawn in the same way, we do not need to review its code.</p>
<p>You can reposition the pointer at any time by calling SetInsertionPos.</p>
<p>When you are satisfied with the text output, call End() to notify the engine.</p>
<pre>&nbsp;&nbsp;&nbsp; g_pTxtHelper-&gt;End();</pre>
<h1>Dependancies</h1>
<p>DXUT-based samples typically make use of runtime HLSL compilation. Build-time compilation is recommended for all production Direct3D applications, but for experimentation and samples development runtime HLSL compiliation is preferred. Therefore, the D3DCompile*.DLL
 must be available in the search path when these programs are executed.</p>
<ul>
<li>When using the Windows 8.x SDK and targeting Windows Vista or later, you can include the D3DCompile_46 or D3DCompile_47 DLL side-by-side with your application copying the file from the REDIST folder.
</li></ul>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.0\Redist\D3D\arm, x86 or x64</pre>
<pre style="padding-left:60px">%ProgramFiles(x86)%\Windows kits\8.1\Redist\D3D\arm, x86 or x64</pre>
<h1>Building with Visual Studio 2010</h1>
<p>The code in these samples can be built using Visual Studio 2010 rather than Visual Studio 2012. The changes required are:</p>
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
<li>July 28, 2014 - Updated for DXUT July 2014 release </li><li>September 16, 2013 - Initial release </li></ul>
<h1>More Information</h1>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2012/03/22/where-is-the-directx-sdk.aspx">Where is the DirectX SDK?</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/07/01/where-is-the-directx-sdk-2013-edition.aspx">Where is the DirectX SDK (2013 Edition)?</a>&nbsp;</p>
<p><a href="http://blogs.msdn.com/b/chuckw/archive/2013/09/14/dxut-for-win32-desktop-update.aspx">DXUT for Win32 Desktop Update</a></p>
<p><a href="http://blogs.msdn.com/b/chuckw/">Games for Windows and DirectX SDK blog</a></p>
