# How to Add Text Watermark and Image Watermark in Word with C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Controls
- C#
- Silverlight
- ASP.NET
- WPF
- .NET Framework
- Visual C#
## Topics
- Controls
- Visual Studio
- Image
- watermark in C#
- add watermark in Word
## Updated
- 11/23/2016
## Description

<h1>Introduction</h1>
<p><em>This sample aims at demonstrating how to add text watermark and image watermark in Word document via free Spire.Doc for .NET with C#.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Text watermark and image watermark are both watermarks in Word document. In general, the watermark is used to indicate status of a document, like confidential, draft, approved, or display a company logo image. This sample will show how easy you can add text
 watermark and image watermark in Word with C#. To achieve this, this solution turns to a powerful .NET Word library &ndash;
<a href="http://www.e-iceblue.com/Introduce/free-doc-component.html">Free Spire.Doc for .NET</a></p>
<p>Before you proceed, you need to download free Spire.Doc for .NET and install it in system. After adding free Spire.Doc dll as a reference to your .NET project assemblies, you&rsquo;re able to add watermark in Word by using just a few lines of code as below.</p>
<p><strong>How to Add Image Watermark in Word with C#</strong><strong>：</strong></p>
<p><strong>Step 1</strong>: Initialize a new instance of Document class and load the Word document from file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Document document = new Document();
document.LoadFromFile (@&quot;E:\Visual Studio\Sample\How to Make a Cake.docx&quot;);
</pre>
<div class="preview">
<pre class="csharp">Document&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document();&nbsp;
document.LoadFromFile&nbsp;(@<span class="cs__string">&quot;E:\Visual&nbsp;Studio\Sample\How&nbsp;to&nbsp;Make&nbsp;a&nbsp;Cake.docx&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Step 2</strong>: Load an image from system.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PictureWatermark picture = new PictureWatermark();
picture.Picture = System.Drawing.Image.FromFile (@&quot;C:\Users\Administrator\Pictures\cake.jpg&quot;);</pre>
<div class="preview">
<pre class="csharp">PictureWatermark&nbsp;picture&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PictureWatermark();&nbsp;
picture.Picture&nbsp;=&nbsp;System.Drawing.Image.FromFile&nbsp;(@<span class="cs__string">&quot;C:\Users\Administrator\Pictures\cake.jpg&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Step 3</strong>: Set the image watermark scaling.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">picture.Scaling = 180;</pre>
<div class="preview">
<pre class="csharp">picture.Scaling&nbsp;=&nbsp;<span class="cs__number">180</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Step 4</strong>: Add the image watermark.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">document.Watermark = picture;</pre>
<div class="preview">
<pre class="csharp">document.Watermark&nbsp;=&nbsp;picture;</pre>
</div>
</div>
</div>
</div>
<p><strong>Step 5</strong>: Save the file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">document.SaveToFile(&quot;result.docx&quot;);</pre>
<div class="preview">
<pre class="csharp">document.SaveToFile(<span class="cs__string">&quot;result.docx&quot;</span>);</pre>
</div>
</div>
</div>
<p><strong>Effective screenshot:</strong></p>
<p><strong><img id="163851" src="163851-111.png" alt="" width="387" height="387"><br>
</strong></p>
<p><strong>How to Add Text Watermark in Word with C#</strong><strong>：</strong></p>
<p>Adding text watermark is as easy as the solution above. Since Free Spire.Doc for .NET allows us to add and design watermark, we can set the property of text watermark as we want. Here is the core code to add text watermark in Word.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Document document = new Document();

document.LoadFromFile(@&quot;E:\Visual Studio\Sample\How to Make a Cake.docx&quot;);

TextWatermark txtWatermark = new TextWatermark();

txtWatermark.Text = &quot;DRAFT&quot;;

txtWatermark.FontSize = 100;

txtWatermark.Color = Color.Red;

txtWatermark.Layout = WatermarkLayout.Diagonal;

document.Watermark = txtWatermark;

document.SaveToFile(&quot;result.docx&quot;);</pre>
<div class="preview">
<pre class="csharp">Document&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document();&nbsp;
&nbsp;
document.LoadFromFile(@<span class="cs__string">&quot;E:\Visual&nbsp;Studio\Sample\How&nbsp;to&nbsp;Make&nbsp;a&nbsp;Cake.docx&quot;</span>);&nbsp;
&nbsp;
TextWatermark&nbsp;txtWatermark&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TextWatermark();&nbsp;
&nbsp;
txtWatermark.Text&nbsp;=&nbsp;<span class="cs__string">&quot;DRAFT&quot;</span>;&nbsp;
&nbsp;
txtWatermark.FontSize&nbsp;=&nbsp;<span class="cs__number">100</span>;&nbsp;
&nbsp;
txtWatermark.Color&nbsp;=&nbsp;Color.Red;&nbsp;
&nbsp;
txtWatermark.Layout&nbsp;=&nbsp;WatermarkLayout.Diagonal;&nbsp;
&nbsp;
document.Watermark&nbsp;=&nbsp;txtWatermark;&nbsp;
&nbsp;
document.SaveToFile(<span class="cs__string">&quot;result.docx&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Effective screenshot<strong>:</strong></strong></div>
<div class="endscriptcode"><strong><strong><img id="163852" src="163852-222.png" alt="" width="391" height="403"><br>
</strong></strong></div>
<h1>More Information</h1>
<p>The above sample only shows how free Sipre.Doc for .NET can be used to add watermark in Word file. In fact, free Spire.Doc for .NET contains much more incredible features that enable you to perform a wide range of document processing tasks, like creation,
 conversion and printing. Besides, free Spire.Doc for .NET is a totally independent .NET library to operate word documents, which doesn't need Microsoft Office to be installed on the system.</p>
<p>Please view the full detailed information at:</p>
<p><strong>Website: </strong><a href="http://www.e-iceblue.com"><strong>www.e-iceblue.com</strong></a><strong>
</strong></p>
<p><strong>Product Home: </strong><a href="http://www.e-iceblue.com/Introduce/free-doc-component.html#.WBwKk8lv7nG"><strong>Free Spire.Doc for .NET</strong></a><strong>
</strong></p>
<p><strong>Download:</strong><a href="http://www.e-iceblue.com/Download/download-word-for-net-free.html"><strong> Free Spire.Doc for .NET</strong></a><strong>
</strong></p>
<p><strong>Forum:</strong><a href="http://www.e-iceblue.com/forum/spire-doc-f6.html"><strong> Free Word Library Forum</strong></a><strong>
</strong><strong>&nbsp;</strong></p>
