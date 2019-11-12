# Image Conversion in VB.NET and Windows Forms
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- GDI+
- Windows Forms
## Topics
- Image manipulation
## Updated
- 08/03/2011
## Description

<h1>Introduction</h1>
<p><span>This sample shows how to convert an image from one type to another using the ImageCodecInfo and EncoderParameters</span></p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements to build this sample. It will work straight out of the box. However this sample will only work on 32bit processes due to the inclusion of the now obsolete DriveListBox and FileListBox. &nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample demonstrates how to look for a BITMAP image&nbsp;on a machine and then convert that image to one of 3 named formats, ie PNG, JPEG&nbsp;or GIF. The image conversion code is detailed and shows how to use the ImageCodecInfo and EncoderParameters
 to save the file in the desired format with a quality level of 100</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="js">Dim&nbsp;image&nbsp;As&nbsp;Bitmap&nbsp;=&nbsp;Drawing.Image.FromFile(ctlFileList.Path&nbsp;&amp;&nbsp;&quot;\&quot;&nbsp;&amp;&nbsp;ctlFileList.FileName)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;encoderParameters&nbsp;As&nbsp;New&nbsp;EncoderParameters(<span class="js__num">1</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;encoderParameters.Param(<span class="js__num">0</span>)&nbsp;=&nbsp;New&nbsp;EncoderParameter(Encoder.Quality,&nbsp;100L)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image.Save(fileName,&nbsp;GetNewEncoder(imageFormat),&nbsp;encoderParameters)</pre>
</div>
</div>
</div>
<p>The image can be saved as PNG, GIF or JPEG and the sample will create a random name for the image in the current directory. As this is only sample code, all error checking is not included.</p>
<p>Below is the ImageFormat function to get the correct image format for the one selected in the combo box</p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetImageFormatForSelectedCombo()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ImageFormat&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;ComboBox1.SelectedItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;JPEG&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;ImageFormat.Jpeg&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;PNG&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;ImageFormat.Png&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__string">&quot;GIF&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;ImageFormat.Gif&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;ImageFormat.Jpeg&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p class="endscriptcode">Finally the GetNewEncoder function. This function was translated from C# from the Stackoverflow post (<a href="http://stackoverflow.com/questions/41665/bmp-to-jpg-png-in-c">http://stackoverflow.com/questions/41665/bmp-to-jpg-png-in-c</a>)
 as suppled by the user Jestro (<a href="http://stackoverflow.com/users/417811/jestro">http://stackoverflow.com/users/417811/jestro</a>)</p>
<div class="endscriptcode"></div>
<h1 class="endscriptcode">More Information</h1>
<p>For more information on the different parts please consult the following MSDN documentation</p>
</div>
<div class="scriptcode">Encoder.Quality field - <a href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.encoder.quality.aspx">
http://msdn.microsoft.com/en-us/library/system.drawing.imaging.encoder.quality.aspx</a></div>
<div class="scriptcode">ImageFormat class - <a href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageformat.aspx">
http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageformat.aspx</a></div>
<div class="scriptcode">ImageCodecInfo class - <a href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imagecodecinfo.aspx">
http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imagecodecinfo.aspx</a></div>
