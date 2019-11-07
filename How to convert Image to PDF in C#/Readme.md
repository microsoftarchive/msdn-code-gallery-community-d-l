# How to convert Image to PDF in C#
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Class Library
- Windows Forms
- Windows SDK
- VB.Net
## Topics
- Controls
- How to
- convert image to PDF
- Jpeg to PDF
- Png to PDF
- Bmp to PDF
- Gif to PDF
- Tiff to PDF
## Updated
- 11/20/2014
## Description

<p><span style="font-size:small">Free pqScan.ImageToPDF for .NET enables developers to quickly and easily load and convert images to PDF documents on any .NET applications (web projects, WinForms applications) and it supports in C#, VB.NET.</span></p>
<p><span style="font-size:small">This is a C # example to add images to PDF documents via a Free C# library. And the code gives you clear information of how to convert image files to PDF document in C#.</span></p>
<p><span style="font-size:small"><a title="convert image to pdf in .net" href="http://www.pqscan.com/image-to-pdf/"><strong><em>Free</em></strong><strong> pqScan.ImageToPDF for .NET</strong></a> is a advantage SDK for commercial and personal use. It enables
 developers to quickly and easily load and convert images to PDF documents on any .NET applications (.NET Winforms, Console application and ASP.NET web site) and it supports in C#, VB.NET. The featured function, conversion allows converting images to PDF documents
 with most popular used image formats, such as <a title="convert tiff to pdf in c#" href="http://www.pqscan.com/convert-image/tiff-to-pdf-csharp.html">
TIFF</a>, JPEG, PNG, BMP and GIF etc. Fether more, developers can add image to a new PDF document and
<a title="append image to pdf in C#" href="http://www.pqscan.com/convert-image/append-to-pdf-csharp.html">
append images to the end of an existed PDF document</a>.<br>
</span></p>
<h2><strong>Converting Type</strong></h2>
<ul>
<li>PNG to PDF </li><li>JPEG to PDF </li><li>BMP to PDF </li><li>GIF to PDF </li><li>TIFF to PDF </li><li>Multi-page TIFF to PDF </li></ul>
<h2><strong>Customizing PDF page Size</strong></h2>
<p><span style="font-size:small">Users can simply customize generated PDF page size. The PDF page size can be the standard page layout: such as A4, A3, B4 etc, and it can also be the original image size.
<br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><em>&nbsp;Following is a sample to get the target size of image.</em></span><strong><em>
<br>
</em></strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PDFConverter converter = new PDFConverter();
converter.PageSizeType = PageSizeMode.A4;
string[] imgFiles = new string[3];
imgFiles[0] = &quot;input1.png&quot;;
imgFiles[1] = &quot;input2.bmp&quot;;
imgFiles[2] = &quot;input3.jpg&quot;;

string outFile = &quot;output.pdf&quot;;

converter.CreatePDF(imgFiles, outFile);</pre>
<div class="preview">
<pre class="csharp">PDFConverter&nbsp;converter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PDFConverter();&nbsp;
converter.PageSizeType&nbsp;=&nbsp;PageSizeMode.A4;&nbsp;
<span class="cs__keyword">string</span>[]&nbsp;imgFiles&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">string</span>[<span class="cs__number">3</span>];&nbsp;
imgFiles[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;input1.png&quot;</span>;&nbsp;
imgFiles[<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;input2.bmp&quot;</span>;&nbsp;
imgFiles[<span class="cs__number">2</span>]&nbsp;=&nbsp;<span class="cs__string">&quot;input3.jpg&quot;</span>;&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;outFile&nbsp;=&nbsp;<span class="cs__string">&quot;output.pdf&quot;</span>;&nbsp;
&nbsp;
converter.CreatePDF(imgFiles,&nbsp;outFile);</pre>
</div>
</div>
</div>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Related Links</strong></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Website:</strong><span class="Apple-converted-space">&nbsp;</span><a title="provide .net barcode generate and read SDK, provide .net pdf to image and image to pdf SDK" href="http://www.pqscan.com"><span style="color:#960bb4; text-decoration:none">http://www.pqscan.com</span></a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Product Introduction</strong>:<span class="Apple-converted-space"> </span>
<a title="convert and image files and add them the PDF document .net sdk" href="http://www.pqscan.com/image-to-pdf/">http://www.pqscan.com/image-to-pdf/</a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Online Demo</strong>:<span class="Apple-converted-space"> </span><a title="convert image to pdf in .net online demo" href="http://www.pqscan.com/online-demo/image-to-pdf/">http://www.pqscan.com/online-demo/image-to-pdf/</a></p>
