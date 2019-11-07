# How to convert PDF to Image in C#
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Windows Forms
- Windows SDK
- VB.Net
- Library
- .NET Development
## Topics
- Controls
- How to
- Convert PDF to Image
- PDF to Jpeg
- PDF to Tiff
- PDF to Png
- PDF to Gif
- PDF to Bmp
## Updated
- 11/17/2014
## Description

<p class="projectSummary"><span style="font-size:small">Free pqScan.PDFToImage for .NET enables developers to quickly and easily load and convert PDF documents to images on any .NET applications (ASP.NET, WinForms and Web Service) and it supports in C#, VB.NET.</span></p>
<p class="projectSummary"><span style="font-size:small">This is a C # example to manage PDF documents via a Free C# PDF library. And the code gives you clear information of how to convert PDF document to image in C#.</span></p>
<h1><img id="125988" src="125988-pdf%20to%20image.jpg" alt="" width="600" height="400"></h1>
<p><span style="font-size:small"><a title="convert pdf to image in .net" href="http://www.pqscan.com/pdf-to-image/"><strong><em>Free</em></strong><strong> pqScan.PDFToImage for .NET</strong></a> is a professional and reliable PDF SDK for commercial and personal
 use. It enables developers to quickly and easily load and convert PDF documents on any .NET applications (ASP.NET, WinForms and Web Service) and it supports in C#, VB.NET. The featured function, conversion allows converting PDF documents to commonly used image
 formats, such as PNG, JPEG, BMP, GIF and TIFF etc.</span></p>
<h2><strong>Converting Type</strong></h2>
<ul>
<li><a title="convert pdf to png in .net" href="http://www.pqscan.com/convert-pdf/to-png.html">PDF to PNG</a>
</li><li><a title="convert pdf to jpeg in .net" href="http://www.pqscan.com/convert-pdf/to-jpg.html">PDF to JPEG/JPG</a>
</li><li><a title="convert pdf to bmp in .net" href="http://www.pqscan.com/convert-pdf/to-bmp.html">PDF to BMP</a>
</li><li><a title="convert pdf to gif in .net" href="http://www.pqscan.com/convert-pdf/to-gif.html">PDF to GIF
</a></li><li><a title="convert pdf to tiff in .net" href="http://www.pqscan.com/convert-pdf/to-tiff.html">PDF to TIFF/TIF
</a></li><li><a title="convert pdf to multi-page tiff in .net" href="http://www.pqscan.com/convert-pdf/to-multi-tiff.html">PDF to Multi-page TIFF</a>
</li></ul>
<h2><strong>Changing Image Size</strong></h2>
<p><span style="font-size:small">Users can simply customize the conversion of PDF to image in .NET project, especially controlling converted image size. In details, you can easily know the width and height of rendered image in advance depending on defined DPI,
 or customize a suitable size for image output directly.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>&nbsp;Following is a sample to get the target size of image.</em></span><em>&nbsp;
<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PDFDocument doc = new PDFDocument();

doc.LoadPDF(&quot;d:/sample.pdf&quot;);

doc.DPI = 96;

Bitmap bmp = doc.ToImage(0, 500, 500);

bmp.Save(&quot;d:/sample-size.png&quot;, ImageFormat.Png);</pre>
<div class="preview">
<pre class="csharp">PDFDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PDFDocument();&nbsp;
&nbsp;
doc.LoadPDF(<span class="cs__string">&quot;d:/sample.pdf&quot;</span>);&nbsp;
&nbsp;
doc.DPI&nbsp;=&nbsp;<span class="cs__number">96</span>;&nbsp;
&nbsp;
Bitmap&nbsp;bmp&nbsp;=&nbsp;doc.ToImage(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">500</span>,&nbsp;<span class="cs__number">500</span>);&nbsp;
&nbsp;
bmp.Save(<span class="cs__string">&quot;d:/sample-size.png&quot;</span>,&nbsp;ImageFormat.Png);</pre>
</div>
</div>
</div>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Related Links</strong></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Website:</strong><span class="Apple-converted-space">&nbsp;</span><a title="provide .net barcode generate and read SDK, provide .net pdf to image and image to pdf SDK" href="http://www.pqscan.com"><span style="color:#960bb4; text-decoration:none">http://www.pqscan.com</span></a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Product Introduction</strong>:<span class="Apple-converted-space"> </span>
<a title="convert and transform pdf page to image .net sdk" href=" http://www.pqscan.com/pdf-to-image/">http://www.pqscan.com/pdf-to-image/</a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Online Demo</strong>:<span class="Apple-converted-space"> </span><a title="convert pdf to image in .net online demo" href="http://www.pqscan.com/online-demo/pdf-to-image/">http://www.pqscan.com/online-demo/pdf-to-image/</a></p>
