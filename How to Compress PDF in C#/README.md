# How to Compress PDF in C#
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET
- Windows Forms
- VB.Net
## Topics
- PDF API
- compress pdf
## Updated
- 06/08/2018
## Description

<p>This is <a href="http://www.iditect.com/product/pdf-compress/">iDiTect .NET PDF Compressor</a> sample code project. Developers are allowed using the full featured trial library to compress PDF file size in C#.</p>
<p>As advanced component build by iDiTect, it can compress image and text content in PDF files. For compressing images in PDF, CCITT and JPEG compression help to decrease image size without losing high quality. For compressing text content in PDF, white space
 and any uncompressed content will be reduce by LZW encoding. Besides, you can delete the unwanted annotations and metadata in PDF document. All the optimizing processing will downsize the PDF size withhigh compressing ratio.</p>
<p>The library is thread safe, can be integrate in any Winforms desktop project and ASP.NET web programming. Both 32 and 64 bits support, require .NET framework 4.0&#43;.</p>
<p>This trial package are only allowed to use in evaluation test, any other use need the
<a href="http://www.iditect.com/pricing.html">license</a>.</p>
<p class="text-center">If the trial key in the download package is expired, please go to
<a href="http://www.iditect.com/download/iDiTect.Trial.zip">iditect to download the newest demo zip</a> for the fresh trial key.</p>
<p>&nbsp;</p>
<h1>C# Sample</h1>
<p><em>Following is a C# sample to compress pdf document.</em><span style="font-size:small"><em>&nbsp;&nbsp;</em></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Load&nbsp;PDF&nbsp;document</span>&nbsp;
PdfCompressor&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfCompressor(<span class="cs__string">&quot;sample.pdf&quot;</span>);&nbsp;&nbsp;
<span class="cs__com">//Whether&nbsp;compress&nbsp;text&nbsp;content</span>&nbsp;
document.CompressContent&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
<span class="cs__com">//Whether&nbsp;compress&nbsp;image&nbsp;embedded&nbsp;</span>&nbsp;
document.CompressImage&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
<span class="cs__com">//Whether&nbsp;delete&nbsp;the&nbsp;annotations</span>&nbsp;
document.RemoveAnnotations&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
<span class="cs__com">//Whether&nbsp;delete&nbsp;the&nbsp;customized&nbsp;meta&nbsp;data</span>&nbsp;
document.RemoveMetaData&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
<span class="cs__com">//Compress&nbsp;document</span>&nbsp;
document.Compress(<span class="cs__string">&quot;compressed.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<p>See full details about compressing pdf in C# in <a href="http://www.iditect.com/tutorial/compress-pdf/">
this page</a>, it's fast and easy to use in any of your .net applicaton. Reduce PDF size programmatically much more quickly than other PDF compressor.</p>
