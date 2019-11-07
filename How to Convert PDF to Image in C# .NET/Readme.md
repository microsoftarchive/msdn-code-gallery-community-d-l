# How to Convert PDF to Image in C# .NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- GDI+
- ASP.NET
- Windows Forms
- Visual Studio 2010
- .NET Framework 4
- .NET Framework
- Visual Basic .NET
- .NET Framework 4.0
- .NET Framwork
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- .NET 4.5
- .NET Development
- Image Processing
- Visual Studio 2015
## Topics
- Convert PDF to Image
- Convert PDF page to Jpeg
- Convert PDF page to png
- Convert PDF page to Tiff
- Convert PDF page to Gif
- Convert PDF page to Bitmap
- Convert whole PDF document to Multi-page tiff file
## Updated
- 12/02/2016
## Description

<p><span>Free XsPDF to Image .NET library allows developers to quickly and easily convert PDF pages and PDF document to image formats on any .NET applications (ASP.NET, AJAX, MVC, WinForms) with C# and VB.NET language.</span></p>
<p><span>XsPDF convert PDF to Image for .NET is a &nbsp;professional PDF SDK for&nbsp;commercial and personal use. Developers can get image converted from PDF pages easily with this C# Control. Multiple image formats are supported to be painted and rendered
 from PDF, such as Jpeg, Png and Tiff etc.&nbsp;This is a C# demo to convert PDF document to images in C#.</span></p>
<p><span>Free XsPDF to Image for .NET SDK enables developers to quickly and easily convert PDF page or whole PDF document to images with any dpi resolution and image size. Developer can modify and customize the wanted width and height to render converted image
 from PDF document directly.&nbsp;</span></p>
<h2><strong>Converting Type</strong></h2>
<ul>
<li><a title="convert pdf page to jpg in c# .NET" href="http://www.xspdf.com/guide/pdf-jpg-converting/">Convert PDF Page to JPEG in C#</a>
</li><li><a title="convert pdf page to png in c# .NET" href="http://www.xspdf.com/guide/pdf-png-converting/">Convert PDF Page to PNG in C#</a>
</li><li><a title="convert pdf page to tiff in c# .NET" href="http://www.xspdf.com/guide/pdf-tiff-converting/">Convert PDF Page to TIFF in C#</a>
</li><li><a title="convert whole pdf document to multiple pages tiff in c# .NET" href="http://www.xspdf.com/guide/pdf-multi-page-tiff-converting/">Convert Whole PDF Document to Multi-page TIFF in C#</a>
</li><li><a title="convert pdf page to bmp in C# .NET" href="http://www.xspdf.com/guide/pdf-bmp-converting/">Convert PDF Page to BMP in C#</a>
</li><li><a title="convert pdf page to gif in c# .NET" href="http://www.xspdf.com/guide/pdf-gif-converting/">Convert PDF Page to GIF in C#</a><br>
<br>
</li></ul>
<p><em>Following is a C# sample to convert PDF to image files.</em><em>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PdfImageConverter pdfConverter = new PdfImageConverter(&quot;sample.pdf&quot;);

pdfConverter.DPI = 96;

for (int i = 0; i &lt; pdfConverter.PageCount; i&#43;&#43;)
{
    Image pageImage = pdfConverter.PageToImage(i, 500, 800);

    pageImage.Save(&quot;Page &quot; &#43; i &#43; &quot;.jpg&quot;, ImageFormat.Jpeg);
}</pre>
<div class="preview">
<pre class="csharp">PdfImageConverter&nbsp;pdfConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfImageConverter(<span class="cs__string">&quot;sample.pdf&quot;</span>);&nbsp;
&nbsp;
pdfConverter.DPI&nbsp;=&nbsp;<span class="cs__number">96</span>;&nbsp;
&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;pdfConverter.PageCount;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pageImage&nbsp;=&nbsp;pdfConverter.PageToImage(i,&nbsp;<span class="cs__number">500</span>,&nbsp;<span class="cs__number">800</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pageImage.Save(<span class="cs__string">&quot;Page&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.jpg&quot;</span>,&nbsp;ImageFormat.Jpeg);&nbsp;
}</pre>
</div>
</div>
</div>
<h3><strong>Related Links</strong></h3>
<p><strong>WebSite:&nbsp;<a title="PDF editing SDK, convert pdf to image, add barcode to pdf, add chart to pdf in C#" href="http://www.xspdf.com/">http://www.xspdf.com</a></strong></p>
<p><strong>Product&nbsp;<strong>Introduction:&nbsp;<a title="convert pdf to image in C# .NET" href="http://www.xspdf.com/product/pdf-to-image/">http://www.xspdf.com/product/pdf-to-image/</a></strong></strong></p>
