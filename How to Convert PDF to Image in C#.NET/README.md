# How to Convert PDF to Image in C#.NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET
- Visual Studio 2010
- ASP.NET MVC
- .NET Framework
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- .NET Framework 4.0
- C# Language
- WinForms
- Visual C#
- Visual Studio 2013
- .NET 4.5
- .NET Development
- Visual Studio 2015
## Topics
- Class Library
- PDF to Tiff
- PDF to Png
- PDF to Gif
- PDF to Image
- PDF to jpg
- PDF to multi-page tiff
- PDF to bitmap
## Updated
- 12/01/2016
## Description

<p><span style="font-size:small">Free XsPDF PDF to image .NET library allows developers to quickly and easily import and convert PDF documents to images on any .NET applications (ASP.NET, AJAX, MVC, WinForms) with C# and VB.NET language.</span></p>
<p><span style="font-size:small">XsPDF PDF to image converter for .NET is a &nbsp;<span>professional PDF SDK for
<span>commercial and personal use. Developers can read and convert PDF document easily with this C# Control. Multiple image formats are supported to be converted from PDF, such as JPEG, PNG and TIFF etc.
</span></span>This is a C# demo to convert PDF document to images in C#.</span></p>
<h2><strong>Converting Type</strong></h2>
<ul>
<li><a title="convert pdf to jpg in c# .net" href="http://www.xspdf.com/guide/pdf-jpg-converting/">Convert PDF page to JPEG in C#</a>
</li><li><a title="convert pdf to png in c# .net" href="http://www.xspdf.com/guide/pdf-png-converting/">Convert PDF page to PNG in C#</a>
</li><li><a title="convert pdf to tif in c# .NET" href="http://www.xspdf.com/guide/pdf-tiff-converting/">Convert PDF page to TIFF in C#</a>
</li><li><a title="convert pdf to bmp in c# .NET" href="http://www.xspdf.com/guide/pdf-bmp-converting/">Convert PDF page to BMP in C#</a>
</li><li><a title="convert pdf to gif in c# .NET" href="http://www.xspdf.com/guide/pdf-gif-converting/">Convert PDF page to GIF in C#</a>
</li><li><a title="convert pdf to multiple pages tiff in C# .NET" href="http://www.xspdf.com/guide/pdf-multi-page-tiff-converting/">Convert Whole PDF to Multi-page TIFF in C#</a>
</li></ul>
<h2><strong>Changing Image Size and DPI</strong></h2>
<p><span style="font-size:small">Developers can simply modify the conversion of PDF to image processing in .NET project, such as converted image size and image resolution. In details, you can easily customize the image size to target width and height, and defind
 the converted image's DPI resolution directly.&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>Following is a C# sample to set the target size of image and DPI.</em><em>&nbsp;&nbsp;</em></span></p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">PdfImageConverter&nbsp;pdfConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfImageConverter(<span class="cs__string">&quot;sample.pdf&quot;</span>);&nbsp;
&nbsp;
pdfConverter.DPI&nbsp;=&nbsp;<span class="cs__number">96</span>;&nbsp;
&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;pdfConverter.PageCount;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pageImage&nbsp;=&nbsp;pdfConverter.PageToImage(i,&nbsp;<span class="cs__number">500</span>,&nbsp;<span class="cs__number">800</span>);&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageImage.Save(<span class="cs__string">&quot;Page&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.jpg&quot;</span>,&nbsp;ImageFormat.Jpeg);&nbsp;
}</pre>
</div>
</div>
</div>
<h3><strong>Related Links</strong></h3>
<p><strong>WebSite:&nbsp;<a title="PDF editing SDK, convert pdf to image, add barcode to pdf, add chart to pdf in C#" href="http://www.xspdf.com">http://www.xspdf.com</a></strong></p>
<p><strong>Product <strong>Introduction:&nbsp;<a title="Convert pdf to image SDK in .NET" href="http://www.xspdf.com/product/pdf-to-image/">http://www.xspdf.com/product/pdf-to-image/</a></strong></strong></p>
