# Image Manipulation C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio 2010
- C# Language
## Topics
- Image manipulation
## Updated
- 08/08/2012
## Description

<h1><span style="color:#ff0000">*</span> <em>Version 2.0 - Added Load Image Function</em></h1>
<p>&nbsp;</p>
<h1>Introduction</h1>
<div><em>I have been noticing that for some reason people are developing several projects with pictures in Visual Studio Projects, mainly Windows forms projects. Evern yesterday i helped a guy with an issue of zoom in and out an image within a picture box.
 For those that dont know this visual studio toolbox artifact, it represents a Windows picture box control for displaying an image.
</em></div>
<div><em>After helping this guy i started to google for some related problems and found out many other people asking the same questions. In order to help these people and other that may work with Images in Visual Studio projects i developed this small Demo,
 to show you how simple operations can be done.</em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em>This sample countains controls to mak several manipulations in Images within a picture box, such controls include:</em></div>
<ul>
<li>Zoom in </li><li>Zoom out </li><li>Flip Horizontally </li><li>Flip Vertically </li><li>Resizing </li><li>Rotate Left </li><li>Rotate Right </li><li>Zoom in with a track bar </li><li>Make drawings in the image with a brush </li><li>Saving the manipulated picture </li><li>Moving picture box </li><li>Load images to picture box </li></ul>
<div>These ar as i said, the basics controls to start playing with pictures in Visual Studio. Here is a print screen on this demo with the explanation of the controls:</div>
<div><img id="63232" src="63232-picturedemoprint.png" alt="" width="417" height="358"></div>
<div>&nbsp;</div>
<div>This sample includes just one image and no control to change it dynamcally, hoevr you can change the image to one of your own in the picture box control.</div>
<div>&nbsp;</div>
<div>Snippet of a zoom in&nbsp;</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ZoomIn()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Multiplier&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__number">2</span>,<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;MyImage&nbsp;=&nbsp;pictureBox1.Image;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;MyBitMap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(MyImage,&nbsp;Convert.ToInt32(MyImage.Width&nbsp;*&nbsp;Multiplier.Width),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Convert.ToInt32(MyImage.Height&nbsp;*&nbsp;Multiplier.Height));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphics&nbsp;Graphic&nbsp;=&nbsp;Graphics.FromImage(MyBitMap);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Graphic.InterpolationMode&nbsp;=&nbsp;InterpolationMode.High&nbsp;;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1.Image&nbsp;=&nbsp;MyBitMap;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>&nbsp;</div>
<h1>About Me</h1>
<div><em>Rui Pedro Machado @ 2012 | Portugal&nbsp; <a href="mailto:ruimachado@wordpess.com">
rpmachado.wordpress.com</a></em></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
