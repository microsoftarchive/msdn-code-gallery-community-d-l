# Dynamic Splash Screen in WPF
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
- WPF
- WPF forms
## Topics
- Splash Screen
- wpf splash screen
- windows splash screen
## Updated
- 02/26/2014
## Description

<h1>Introduction</h1>
<p><em>This article describes creating Dynamic splash screen for WPF Application.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>.NET 3.5 SP1 WPF toolkit contains some implementation of splash screen. You can
</em></p>
<p><em><a href="https://wpf.codeplex.com/releases/view/14962"><span style="color:#0000ff">download</span></a> Here<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Here there are two method to display splash screen.</p>
<p>I) Static and II) Daynamic</p>
<p><strong>I) Static Method <br>
</strong></p>
<p><em>If you want to create simple flash screen then follow these steps.</em></p>
<p><em>step 1) Add Static image in your project, which you want to display as a splash screen.</em></p>
<p><em>step 2) Click on the properties of that image.</em></p>
<p><em>step 3) select <strong>Build Action</strong> as Splash Screen.</em></p>
<p><em><img id="109414" src="109414-splash.jpg" alt="" width="295" height="193"><br>
</em></p>
<p>step 4) Add image in resources.</p>
<p><img id="109415" src="109415-resources.jpg" alt=""></p>
<p>step 5) Press F5 or run your project.</p>
<p>This is the easiest way to create splash screen.</p>
<p><strong>II) Dynamic Method</strong></p>
<p>Create dynamic Flash Screen. which display the following information.</p>
<p>1) Loading Initial Data.</p>
<p>2) Plugin Information.</p>
<p>3) Software Version info.</p>
<p>4) Message</p>
<p>Replace first image &quot;<strong>StaticSplashScreen.png</strong>&quot; with your <strong>
Logo</strong>.</p>
<p><img id="109468" src="109468-doc2pdf.gif" alt="" width="506" height="310"></p>
<p>1) Create Startup Folder in your project and add static Splash Image, Dynamic Splash Class File and Static Flash Screen.</p>
<p>You can define animation and progress bar on splash Screen Window.</p>
<p>The DynamicSplashScreen.cs which require the namespace,</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.aspx" target="_blank" title="Auto generated link to System.Windows.Media">System.Windows.Media</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Imaging.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Imaging">System.Windows.Media.Imaging</a>;</pre>
</div>
</div>
</div>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DynamicSplashScreen:Window&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DynamicSplashScreen()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ShowInTaskbar&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WindowStartupLocation&nbsp;=&nbsp;WindowStartupLocation.Manual;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ResizeMode&nbsp;=&nbsp;ResizeMode.NoResize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WindowStyle&nbsp;=&nbsp;WindowStyle.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Topmost&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Loaded&nbsp;&#43;=&nbsp;OnLoaded;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnLoaded(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//calculate&nbsp;it&nbsp;manually&nbsp;since&nbsp;CenterScreen&nbsp;substracts&nbsp;taskbar&nbsp;height&nbsp;from&nbsp;available&nbsp;area</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Left&nbsp;=&nbsp;(SystemParameters.PrimaryScreenWidth&nbsp;-&nbsp;<span class="cs__keyword">this</span>.Width)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Top&nbsp;=&nbsp;(SystemParameters.PrimaryScreenHeight&nbsp;-&nbsp;<span class="cs__keyword">this</span>.Height)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//....&nbsp;see&nbsp;implementaion&nbsp;above&nbsp;..</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Capture(<span class="cs__keyword">string</span>&nbsp;filePath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Capture(filePath,&nbsp;<span class="cs__keyword">new</span>&nbsp;PngBitmapEncoder());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Capture(<span class="cs__keyword">string</span>&nbsp;filePath,&nbsp;BitmapEncoder&nbsp;encoder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RenderTargetBitmap&nbsp;bmp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;RenderTargetBitmap((<span class="cs__keyword">int</span>)<span class="cs__keyword">this</span>.Width,&nbsp;(<span class="cs__keyword">int</span>)<span class="cs__keyword">this</span>.Height,&nbsp;<span class="cs__number">96</span>,&nbsp;<span class="cs__number">96</span>,&nbsp;PixelFormats.Pbgra32);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.Render(<span class="cs__keyword">this</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encoder.Frames.Add(BitmapFrame.Create(bmp));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Stream&nbsp;stm&nbsp;=&nbsp;File.Create(filePath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encoder.Save(stm);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</span><em></em><br>
<span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
