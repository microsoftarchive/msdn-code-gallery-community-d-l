# How to Convert PDF to Jpeg Image in C#
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
- Convert PDF to Image
## Updated
- 06/08/2018
## Description

<p>This is <a href="http://www.iditect.com/product/pdf-to-image/">iDiTect .NET PDF to Image</a> sample code project. Developers are allowed using the full featured trial library to convert PDF to any image format, such as PDF to jpg, PDF to png, and PDF to
 tiff.</p>
<p>As advanced component build by iDiTect, it can convert PDF to high quality image with any DPI, or convert PDF to compressed jpg image. Besides, converting PDF to multi-page tiff image is also support. And some special properties are provided, like grayscale,
 page rotation, batch converting in multi-thread.</p>
<p>The library is thread safe, can be integrate in any Winforms desktop project and ASP.NET web programming. Both 32 and 64 bits support, require .NET framework 4.0&#43;.</p>
<p>This trial package are only allowed to use in evaluation test, any other use need the
<a href="http://www.iditect.com/pricing.html">license</a>.</p>
<p class="text-center">If the trial key in the download package is expired, please go to
<a href="http://www.iditect.com/download/iDiTect.Trial.zip">iditect to download the newest demo zip</a> for the fresh trial key.</p>
<p>&nbsp;</p>
<h1>C# Sample</h1>
<p><em>Following is a C# sample to convert pdf to jpg with customized dpi resolution and compress ratio.</em><span style="font-size:small"><em>&nbsp;</em></span><em>
<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PdfConverter document = new PdfConverter(&quot;sample.pdf&quot;);
//Default is 72, the higher DPI, the bigger size out image will be
document.DPI = 96;
//The value need to be 1-100. If set to 100, the converted image will take the
//original quality with less time and memory. If set to 1, the converted image 
//will be compressed to minimum size with more time and memory.
document.CompressedRatio = 80;

for (int i = 0; i &lt; document.PageCount; i&#43;&#43;)
{
     //The converted image will keep the original size of PDF page
     Image pageImage = document.PageToImage(i);
     //To specific the converted image size by width and height
     //Image pageImage = document.PageToImage(i, 100, 150);
     //You can save this Image object to jpeg, tiff and png format to local file.
     //Or you can make it in memory to other use.
     pageImage.Save(i.ToString() &#43; &quot;.jpg&quot;, ImageFormat.Jpeg);
}</pre>
<div class="preview">
<pre class="csharp">PdfConverter&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfConverter(<span class="cs__string">&quot;sample.pdf&quot;</span>);&nbsp;
<span class="cs__com">//Default&nbsp;is&nbsp;72,&nbsp;the&nbsp;higher&nbsp;DPI,&nbsp;the&nbsp;bigger&nbsp;size&nbsp;out&nbsp;image&nbsp;will&nbsp;be</span>&nbsp;
document.DPI&nbsp;=&nbsp;<span class="cs__number">96</span>;&nbsp;
<span class="cs__com">//The&nbsp;value&nbsp;need&nbsp;to&nbsp;be&nbsp;1-100.&nbsp;If&nbsp;set&nbsp;to&nbsp;100,&nbsp;the&nbsp;converted&nbsp;image&nbsp;will&nbsp;take&nbsp;the</span>&nbsp;
<span class="cs__com">//original&nbsp;quality&nbsp;with&nbsp;less&nbsp;time&nbsp;and&nbsp;memory.&nbsp;If&nbsp;set&nbsp;to&nbsp;1,&nbsp;the&nbsp;converted&nbsp;image&nbsp;</span>&nbsp;
<span class="cs__com">//will&nbsp;be&nbsp;compressed&nbsp;to&nbsp;minimum&nbsp;size&nbsp;with&nbsp;more&nbsp;time&nbsp;and&nbsp;memory.</span>&nbsp;
document.CompressedRatio&nbsp;=&nbsp;<span class="cs__number">80</span>;&nbsp;
&nbsp;
<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;document.PageCount;&nbsp;i&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;converted&nbsp;image&nbsp;will&nbsp;keep&nbsp;the&nbsp;original&nbsp;size&nbsp;of&nbsp;PDF&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pageImage&nbsp;=&nbsp;document.PageToImage(i);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//To&nbsp;specific&nbsp;the&nbsp;converted&nbsp;image&nbsp;size&nbsp;by&nbsp;width&nbsp;and&nbsp;height</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Image&nbsp;pageImage&nbsp;=&nbsp;document.PageToImage(i,&nbsp;100,&nbsp;150);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//You&nbsp;can&nbsp;save&nbsp;this&nbsp;Image&nbsp;object&nbsp;to&nbsp;jpeg,&nbsp;tiff&nbsp;and&nbsp;png&nbsp;format&nbsp;to&nbsp;local&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Or&nbsp;you&nbsp;can&nbsp;make&nbsp;it&nbsp;in&nbsp;memory&nbsp;to&nbsp;other&nbsp;use.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pageImage.Save(i.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.jpg&quot;</span>,&nbsp;ImageFormat.Jpeg);&nbsp;
}</pre>
</div>
</div>
</div>
<p>See full details about converting PDF to images in <a href="http://www.iditect.com/tutorial/pdf-to-image/">
this page</a>, contains converting pdf to jpg and converting pdf to multiple pages tiff in c#. for batch converting in multi-threads, see this page for
<a href="http://www.iditect.com/tutorial/pdf-to-image-multi-threads/">details</a>.</p>
