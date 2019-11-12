# How to Convert PDF to SVG in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Controls
- C#
- Silverlight
- ASP.NET
- Windows Forms
- WPF
- .NET Framework
- Visual C#
## Topics
- Controls
- ASP.NET
- .Net Programming
- PDF API
- Office Component
- Convert PDF to SVG
- convert to SVG in C#
## Updated
- 01/10/2017
## Description

<h1>Introduction</h1>
<p>As we know, there is always a requirement of converting PDF document pages to SVG images, especially for C# .NET application development, but it's not an easy work. For this reason, this sample application presents a quick C# solution to convert PDF to SVG
 via <a href="https://www.e-iceblue.com/Introduce/pdf-for-net-introduce.html#.WHMqEn3JWBk">
Spire.PDF for .NET</a>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Spire.PDF for .NET is a professional PDF component, which enables developers to quickly and easily load and convert PDF documents entirely through C#/VB.NET without installing Adobe Acrobat. With the help of Spire.PDF for .NET, this sample will help you
 learn its key features of how to convert a PDF document into SVG images with high quality.</p>
<p>Please follow these guidance below.</p>
<p><strong>Building the Sample </strong></p>
<p>&Yuml;&nbsp; Download <em><a href="https://www.e-iceblue.com/Download/download-pdf-for-net-now.html">Spire.PDF for .NET</a>
</em>and unzip it;</p>
<p>&Yuml;&nbsp; Create a Visual C#/.NET application project such as Console Application;</p>
<p>&Yuml;&nbsp; Now add the reference of Spire.PDF.dll in the bin folder into your assemblies;</p>
<p><strong>Using the Code </strong></p>
<p>By adding Visual C# sample code below to your project, you will get perfect SVG images from PDF file pages.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Convert_PDF_to_SVG&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(<span class="cs__string">&quot;baby.pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.SaveToFile(<span class="cs__string">&quot;Result.svg&quot;</span>,&nbsp;FileFormat.SVG);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Effective Screenshot:</strong><strong></strong></p>
<p><img id="166905" src="166905-baby.png" alt="" width="384" height="384"></p>
<h1>More Information</h1>
<p>Spire.PDF for .NET also allows users to quickly accomplish most conversion tasks below generally by providing
<strong>document.LoadFromFile</strong> as input document and <strong>document.SaveToFile</strong> object for output Document Options.</p>
<p>Converting Type:</p>
<p>&Yuml;&nbsp; Convert Webpage HTML, HTML ASPX to PDF</p>
<p>&Yuml;&nbsp; Convert Image(Jpeg, Jpg, Png, Bmp, Tiff, Gif, EMF, Ico) to PDF</p>
<p>&Yuml;&nbsp; Convert Text to PDF</p>
<p>&Yuml;&nbsp; Convert RTF to PDF</p>
<p>&Yuml;&nbsp; Convert XPS to PDF</p>
<p>&Yuml;&nbsp; Convert PDF to XPS</p>
<p>&Yuml;&nbsp; Convert PDF to Image</p>
<p>&Yuml;&nbsp; Convert PDF to Word</p>
<p>In addition to the conversion feature, Spire.PDF for .NET contains much more incredible wealth of features including:</p>
<p>&Yuml;&nbsp; Merge/Split PDF documents</p>
<p>&Yuml;&nbsp; Text, Image Extract from PDF documents</p>
<p>&Yuml;&nbsp; Encrypt, Decrypt, Create PDF Digital Signature from PDF documents</p>
<p>&Yuml;&nbsp; Add PDF Header and Footer</p>
<p>&Yuml;&nbsp; Add and delete bookmark</p>
<p>&Yuml;&nbsp; Generate Table and Set Table Style</p>
<p>&Yuml;&nbsp; Add Text and Image Watermark</p>
<p>&Yuml;&nbsp; Print PDF documents</p>
<p>Welcome to view detailed tutorials and product information at:</p>
<p><strong>Tutorials:</strong> <a href="https://www.e-iceblue.com/Tutorials/Spire.PDF/Spire.PDF-Program-Guide/Spire.PDF-Program-Guide-Content.html">
Spire.PDF Program Guide</a></p>
<p><strong>Website:</strong> <a href="http://www.e-iceblue.com">www.e-iceblue.com</a></p>
