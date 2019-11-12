# How To Create Webcam Capture
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- .NET Framework
- Windows General
## Topics
- User Interface
- Graphics and 3D
- How to
## Updated
- 07/19/2011
## Description

<h1 style="text-align:center">Easy Webcam</h1>
<p>&nbsp;</p>
<h2>Introduction</h2>
<p style="text-align:justify">A <strong>webcam</strong> is a video camera which feeds its images in real time to a computer or computer network, often via
<span class="mw-redirect">USB</span>, ethernet or Wi-Fi.</p>
<p style="text-align:justify">Their most popular use is the establishment of video links, permitting computers to act as videophones or
<span class="mw-redirect">videoconference stations</span>. This common use as a video camera for the World Wide Web gave the webcam its name. Other popular uses include security surveillance and computer vision.</p>
<p style="text-align:justify">Webcams are known for their low manufacturing cost and flexibility making them the lowest cost form of videotelephony. They have also become a source of security and privacy issues, as some built-in webcams can be remotely activated
 via spyware.</p>
<p style="text-align:justify">In this sample I will tell you how to activate Webcam Device in .Net Framework Forms.</p>
<p style="text-align:justify">&nbsp;</p>
<h2><span>Output Sample<br>
</span></h2>
<p>http://www.youtube.com/watch?v=6_Aur-JkymQ</p>
<p>&nbsp;</p>
<h2><span style="font-size:20px; font-weight:bold">Description</span></h2>
<h3>The sample is using AVI Capture (API) Function:</h3>
<ul>
<li>SendMessage </li><li>SetWindowPos </li><li>DestroyWindow </li><li>capCreateCaptureWindowA </li><li>capGetDriverDescriptionA </li></ul>
<p>&nbsp;</p>
<h2><span style="font-size:20px; font-weight:bold">Workflow</span></h2>
<h3>Initialize Webcam Device</h3>
<p>This function is used to list all installed Webcam Device</p>
<p>Private Sub LoadDeviceList()<br>
On Error Resume Next<br>
Dim strName As String = Space(100)<br>
Dim strVer As String = Space(100)<br>
Dim bReturn As Boolean<br>
Dim x As Integer = 0<br>
<br>
Do<br>
bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)<br>
If bReturn Then lst1.Items.Add(strName.Trim)<br>
x &#43;= 1<br>
Application.DoEvents()<br>
Loop Until bReturn = False<br>
<br>
End Sub<br>
'Where lst1 = List Item Control</p>
<h3>Start Device Capture</h3>
<p>This function is used to start capture frame.</p>
<p>&nbsp;&nbsp;&nbsp; 'Open View<br>
&nbsp;&nbsp;&nbsp; Private Sub OpenPreviewWindow()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On Error Resume Next<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim iHeight As Integer = pview.Height<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim iWidth As Integer = pview.Width<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Open Preview window in picturebox<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 480, pview.Handle.ToInt32, 0)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Connect to device<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Set the preview scale<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Set the preview rate in milliseconds<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 'Start previewing the image from the camera<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Resize window to fit in picturebox<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, pview.Width, pview.Height, _<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SWP_NOMOVE Or SWP_NOZORDER)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Else<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Error connecting to device close window<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DestroyWindow(hHwnd)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End If<br>
End Sub</p>
<h3>Stop Device Capture</h3>
<p>This function is used to close Capture Function.</p>
<p>&nbsp;&nbsp;&nbsp; Private Sub ClosePreviewWindow()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; On Error Resume Next<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' Disconnect from device<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)<br>
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' close window<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; '<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; DestroyWindow(hHwnd)<br>
&nbsp;&nbsp;&nbsp; End Sub</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Option</span>&nbsp;Explicit&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;
<span class="visualBasic__keyword">Option</span>&nbsp;Strict&nbsp;Off&nbsp;
&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.InteropServices&nbsp;
&nbsp;
<span class="visualBasic__keyword">Module</span>&nbsp;modWebcam&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;&amp;H400S&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_DRIVER_CONNECT&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">10</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_DRIVER_DISCONNECT&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">11</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_EDIT_COPY&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">30</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_SET_PREVIEW&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">50</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_SET_PREVIEWRATE&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">52</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_CAP_SET_SCALE&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;WM_CAP&nbsp;&#43;&nbsp;<span class="visualBasic__number">53</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WS_CHILD&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;&amp;H40000000&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WS_VISIBLE&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;&amp;H10000000&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;SWP_NOMOVE&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;&amp;H2S&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;SWP_NOSIZE&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;SWP_NOZORDER&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;&amp;H4S&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;HWND_BOTTOM&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;iDevice&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__com">'&nbsp;Current&nbsp;device&nbsp;ID</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;hHwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;<span class="visualBasic__com">'&nbsp;Handle&nbsp;to&nbsp;preview&nbsp;window</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;SendMessage&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32&quot;</span>&nbsp;<span class="visualBasic__keyword">Alias</span>&nbsp;<span class="visualBasic__string">&quot;SendMessageA&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wMsg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;MarshalAs(UnmanagedType.AsAny)&gt;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;SetWindowPos&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32&quot;</span>&nbsp;<span class="visualBasic__keyword">Alias</span>&nbsp;<span class="visualBasic__string">&quot;SetWindowPos&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;hWndInsertAfter&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wFlags&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DestroyWindow&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hndw&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;capCreateCaptureWindowA&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;avicap32.dll&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;lpszWindowName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;dwStyle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;nWidth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;nHeight&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;hWndParent&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;nID&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;capGetDriverDescriptionA&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;avicap32.dll&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;wDriver&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Short</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpszName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cbName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpszVer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;cbVer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Module</span>&nbsp;
</pre>
</div>
</div>
</div>
<h2><span>Source Code Files</span></h2>
<ul>
<li><em>Visual Basic Project.</em> </li></ul>
<h2></h2>
<h2>Latest Update (20 July 2011)</h2>
<h2>Module Update:</h2>
<p><a id="25289" href="/How-To-Create-Webcam-bbdcc90f/file/25289/1/Easy_WebcamMotion%20Sensors.zip">Easy_Webcam&#43;Motion Sensors.zip</a></p>
<h2>Author Blog:</h2>
<p>https://sites.google.com/site/pojokduniamaya/</p>
<ul>
</ul>
