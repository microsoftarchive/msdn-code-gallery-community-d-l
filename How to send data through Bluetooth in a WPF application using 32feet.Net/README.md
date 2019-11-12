# How to send data through Bluetooth in a WPF application using 32feet.Net
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- Bluetooth
## Topics
- Bluetooth
- Bluetooth communication
## Updated
- 10/15/2014
## Description

<h1>Introduction</h1>
<p>Sample that show how to send data through Bluetooth in a WPF application using 32feet.Net</p>
<p><span>&nbsp;</span></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>You only need Visual Studio 2012/Visual Studio 2013.</em></em></p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>For a complete description please read the following article</p>
<p><a href="http://wp.me/p4LXhq-GG">How to send data through Bluetooth in a WPF application using 32feet.Net</a></p>
<p>&nbsp;</p>
<h1><a class="anchor" name="user-content-running-the-wpf-application" href="https://github.com/saramgsilva/BluetoothSampleUsing32feet.Net#running-the-wpf-application"></a>Running the WPF Application</h1>
<p>For test the application we need two devices, where in the first device we will run as &ldquo;Sender&rdquo; and in the second device we will run as &ldquo;Receiver&rdquo;.</p>
<blockquote>
<h2>The &ldquo;Receiver&rdquo; can start listening</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/c2efc9ef3fa1cb885d31871f53292b7b2efece8c/687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461362e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461362e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<blockquote>
<h2>The &ldquo;Sender&rdquo; is searching for available devices</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/eab4dcee57177c1474b9b8ff4420fbd684312f83/687474703a2f2f69302e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461372e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69302e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461372e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<blockquote>
<h2>The &ldquo;Receiver&rdquo; is starting for listening</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/eab4dcee57177c1474b9b8ff4420fbd684312f83/687474703a2f2f69302e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461372e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69302e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461372e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<blockquote>
<h2>The &ldquo;Sender&rdquo; can select a device for send the message</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/0ab006ed0fc83e4fb1bd8b2d4caa970c7bd8341d/687474703a2f2f69322e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461382e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69322e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461382e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<blockquote>
<h2>The &ldquo;Sender&rdquo; will send a message for the selected device</h2>
</blockquote>
<h2><a href="https://camo.githubusercontent.com/326be1fc6c8419d4d9e0189bf34219ff4537cccd/687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461392e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e646461392e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></h2>
<blockquote>
<h2 style="text-align:left">The &ldquo;Receiver&rdquo; received data sent by &ldquo;Sender&rdquo;</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/28694891ff389ff6d96e553058f44922a73faf45/687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e64646131302e706e673f773d353834" target="_blank"><img src=":-687474703a2f2f69312e77702e636f6d2f7777772e736172616d6773696c76612e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031342f31302f3130303731345f313232355f486f77746f73656e64646131302e706e673f773d353834" alt="" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<p>&nbsp;</p>
<h1><span style="font-size:x-large">Nuget</span></h1>
<p>In&nbsp;<a href="https://www.nuget.org/">Nuget</a>&nbsp;is available the nuget package with the classes created in this sample:</p>
<p style="text-align:left"><a href="https://www.nuget.org/packages/32feet.Net-MVVMServices/">32feet.Net - MVVM Services for Bluetooth communication</a></p>
<p style="text-align:left">&nbsp;</p>
<blockquote>
<h2>Installing the 32feet.Net - MVVM Services for Bluetooth communication</h2>
</blockquote>
<p><a href="https://camo.githubusercontent.com/fa4ac0c7be44468c70e77e630b199400226401e8/687474703a2f2f73392e706f7374696d672e6f72672f36396e616a74356d372f6e756765742e706e67" target="_blank"><img src=":-687474703a2f2f73392e706f7374696d672e6f72672f36396e616a74356d372f6e756765742e706e67" alt="" width="600" height="400" style="display:block; margin-left:NaNpx; margin-right:NaNpx"></a></p>
<h1>Run the sample</h1>
<p>To debug the app and then run it, press F5 or use&nbsp;<strong>Debug</strong>&nbsp;&gt;&nbsp;<strong>Start Debugging</strong>. To run the app without&nbsp;&nbsp; debugging, press Ctrl&#43;F5 or use&nbsp;<strong>Debug</strong>&nbsp;&gt;&nbsp;<strong>Start Without
 Debugging</strong>.</p>
<p>&nbsp;</p>
<h1>See Also</h1>
<ul>
<li><a href="https://github.com/saramgsilva/ModernUISamples">https://github.com/saramgsilva/ModernUISamples</a>
</li><li><a href="http://saramgsilva.github.io/ModernUISamples"><span lang="en-GB">http://saramgsilva.github.io/</span><span lang="pt">ModernUISamples</span></a>
</li></ul>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em><em>Ask me on twitter <a href="https://twitter.com/saramgsilva">@saramgsilva</a></em></em></p>
<p>&nbsp;</p>
<h1>Follow me</h1>
<blockquote>
<p><a href="http://www.saramgsilva.com/">My blog: typeof(saramgsilva)</a></p>
<p><a href="https://twitter.com/saramgsilva">My twitter @saramgsilva</a></p>
</blockquote>
