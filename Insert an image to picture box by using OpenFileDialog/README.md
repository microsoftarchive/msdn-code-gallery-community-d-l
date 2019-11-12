# Insert an image to picture box by using OpenFileDialog
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- Windows Forms
## Topics
- C#
- Windows Forms
- ImageViewer
- Load Image
## Updated
- 09/07/2015
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">This sample identifies how to Insert an image to picture box by using OpenFileDialog</span></em></p>
<h1><span>Building the Sample</span></h1>
<p>1-Create a WF application using Visual Studio.</p>
<p>2-Add PictueBox from toolbox</p>
<p>3-<span>change the SizeMode of your picturebox Properties&nbsp;to &ldquo;StretchImage&rdquo; to fill the picture box with the image(for large images).</span></p>
<p><span><img id="142316" src="142316-capture.png" alt="" width="348" height="227"><br>
</span></p>
<p><span>4-Add Button from toolbox</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong><strong>&nbsp;</strong></strong></p>
<h1 class="title"><strong><strong>Open File Dialog Box</strong></strong></h1>
<p><strong><strong>&nbsp;</strong></strong></p>
<p>&nbsp;</p>
<p><strong>OpenFileDialog</strong> allows users to browse folders and select files. It is available in Windows Forms and can be used with C# code. It displays the standard Windows dialog box. The results of the selection can be read in your C# code.</p>
<p><strong>Properties.</strong> The OpenFileDialog control in Windows Forms has many properties that you can set directly in the designer. You do not need to assign them in your own C# code. This section shows some notes on these properties.</p>
<p><strong>Filter.</strong> Filters make it easier for the user to open a valid file. The OpenFileDialog supports filters for matching file names. The asterisk indicates a wildcard. With an extension, you can filter by a file type.</p>
<p>-----------------------------------------------------------------------------<br>
<span style="font-size:x-large"><strong>PictureBox<br>
<span style="font-size:x-small">provides a rectangular region for an image. It supports many image formats. It has an adjustable size. It can access image files from your disk or from the Internet. It can resize images in several different ways.</span></strong></span></p>
<p><span style="font-size:x-large"><strong><span style="font-size:x-small"><br>
</span></strong></span></p>
<p><span style="font-size:small"><strong><span>Click on the button and insert this code to button1_Click event :</span></strong></span><em>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OpenFileDialog&nbsp;ofd&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OpenFileDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ofd.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;images|&nbsp;*.JPG;&nbsp;*.PNG;&nbsp;*.GJF&quot;</span>;&nbsp;<span class="cs__com">//&nbsp;you&nbsp;can&nbsp;add&nbsp;any&nbsp;other&nbsp;image&nbsp;type</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ofd.ShowDialog()&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pictureBox1.Image&nbsp;=&nbsp;Image.FromFile(ofd.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span style="font-size:small"><strong><span>&nbsp;</span></strong></span></p>
<div class="endscriptcode"><strong>&nbsp;</strong></div>
<p><strong>&nbsp;</strong></p>
<div class="endscriptcode"><strong><strong>
<div class="endscriptcode" style="display:inline!important"><br>
<ol style="display:inline!important">
</ol>
</div>
</strong></strong></div>
<p><strong>&nbsp;</strong></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Enjoy :)<br>
Mohamed Safwat</p>
