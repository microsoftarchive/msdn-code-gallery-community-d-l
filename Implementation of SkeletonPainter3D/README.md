# Implementation of SkeletonPainter3D
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- WPF
- Kinect
- Kinect SDK
## Topics
- Controls
- User Interface
- Graphics and 3D
## Updated
- 11/13/2014
## Description

<h1>Introduction</h1>
<p><em>Recently I've built a UserControl that can be use to show the Skeletons, tracked by the Kinect camera in a three-dimensional, interactive viewport. Additional 3D objects can be added to the drawing as well.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Visual Studio 2012 is required.</em></p>
<p><em>The SkeletonPainter3D UserControls is available via a NuGet package. (<a href="http://blog.mosthege.net/2012/07/15/exploring-nuget/" target="_parent">What is NuGet?</a>) You'll probably need the NuGet Package Mangaer Visual Studio extension!</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The purpose of the control is to be useful in debugging, and development scenarios, where a better understanding of what's going on in the virtual 3D environment is required. The
<a href="http://helixtoolkit.codeplex.com/">Helix 3D&nbsp;Toolkit</a>&nbsp;is used for the underlying 3D control. It's performance is okay, but not enough for advanced simulations! An experimental 3d Anaglyph mode is available.</em></p>
<p><em>To implement the control, you can construct it in XAML:</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml">xmlns:kinect=&quot;clr-namespace:TCD.Kinect.Controls;assembly=TCD.Kinect.Controls&quot;&nbsp;
&nbsp;
<span class="xaml__tag_start">&lt;kinect</span>:SkeletonPainter3D&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;painter&quot;</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;Black&quot;</span>&nbsp;<span class="xaml__attr_name">IsAnaglyphEnabled</span>=<span class="xaml__attr_value">&quot;False&quot;</span>&nbsp;<span class="xaml__attr_name">CameraFieldOfView</span>=<span class="xaml__attr_value">&quot;70&quot;</span>&nbsp;<span class="xaml__attr_name">CameraPosition</span>=<span class="xaml__attr_value">&quot;0,0.5,-1&quot;</span>&nbsp;<span class="xaml__attr_name">CameraLookAt</span>=<span class="xaml__attr_value">&quot;0,0,2&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Then you can provide a Skeleton[]&nbsp;using the SkeletonPainter3D.Draw() method:&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">painter.Draw(skeletons);</pre>
</div>
</div>
</div>
<address><span>This it what it looks like:</span></address>
<h1><span><img id="67950" src="67950-tcd.kinect.sample_1.png" alt="" width="525" height="350"></span></h1>
<address><span>The 3D view can be easily manipulated:<img id="67951" src="67951-tcd.kinect.sample_2.png" alt="" width="525" height="350"></span></address>
<address></address>
<address><span>Additional 3D objects can be added as well. TCD.Kinect.Model3DExtensions provides a few basic geometric objects, like box and cylinder, that can be added to a Model3DCollection, which is than passed to the Draw() method. For example you may want
 to simulate a sword in the users hand and you need to test how to calculate the lenght, or orientation.</span></address>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>TCD.Kinect.Sample.zip&nbsp;- Sample implementation (like in the picture above)</em>
</li><li><a title="Kinect Sword Solution" href="http://dl.dropbox.com/u/7813771/Blog/CodeSamples/KinectSword.zip">KinectSword.zip</a> - Complete SourceCode of the 'game' demonstrated in this video:
<a href="http://www.youtube.com/watch?v=2j6GCd4M1bA">http://www.youtube.com/watch?v=2j6GCd4M1bA</a>&nbsp;(uses SkeletonPainter3D)
</li></ul>
<h1>More Information</h1>
<p><em>For more information on TCD.Kinect, see <a href="http://blog.mosthege.net">
http://blog.mosthege.net</a>.</em></p>
