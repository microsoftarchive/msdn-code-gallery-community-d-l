# How to convert PDF to DOCX document in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Office
- Microsoft Azure
- .NET Framework
- Office 2010
## Topics
- Controls
- Graphics
- C#
- User Interface
- How to
- Office 2010 101 code samples
## Updated
- 06/14/2018
## Description

<h1>Introduction</h1>
<p><em>This is a C# example to convert any PDF files in DOCX files via a free C# &laquo;Document .Net&raquo; library. You will be able to do with PDF documents all what you want:</em></p>
<ul class="LiText">
<li><em>Generate new document on fly and fill it by necessary data.</em> </li><li><em>Load existing document and get all it's structure as tree of objects.</em>
</li><li><em>Modify paragraph formatting, text, tables, TOC and other elements in existing document.</em>
</li><li><em>Parse the document and get the tree of its objects.</em> </li><li><em>Replace, merge any data in documents and save as new DOCX, Text or RTF.</em>
</li><li><em>Convert between PDF, DOCX, RTF and Text.</em> </li></ul>
<p><img id="151288" src="151288-document-scheme.png" alt="" width="533" height="309" style="display:block; margin-left:auto; margin-right:auto"></p>
<p><em>Only the .Net platform and nothing else, 32 and 64-bit support, Medium Trust level.</em></p>
<p class="CommonText"><em>Product Highlights:</em></p>
<ul class="LiText">
<li><em>Created in 100% managed C#.</em> </li><li><em>No Microsoft Office automation.</em> </li><li><em>Has own DOCX parser and renderer according to ECMA-376 specification.</em>
</li><li><em>Has own RTF parser and renderer according to RTF 1.8 specification.</em> </li><li><em>Has own PDF parser according to PDF reference 1.7.</em> </li></ul>
<p>&nbsp;</p>
<ul class="LiText">
</ul>
<p><strong>Main Functions</strong></p>
<p>The simple code sample:</p>
<p><img id="151289" src="151289-source.png" alt="" width="475" height="389" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Input PDF file/Output DOCX file:</p>
<p><img id="151290" src="151290-pdf%20to%20docx.png" alt=""></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.aspx" target="_blank" title="Auto generated link to System.IO">System.IO</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ConvertPdfToDocx();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConvertPdfToDocx()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Working&nbsp;directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;workingDir&nbsp;=&nbsp;Path.GetFullPath(@<span class="cs__string">&quot;Tempos&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pdfFile&nbsp;=&nbsp;Path.Combine(workingDir,&nbsp;<span class="cs__string">&quot;example.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;docxFile&nbsp;=&nbsp;Path.Combine(workingDir,&nbsp;<span class="cs__string">&quot;Example-result.docx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://sautinsoft.com/products/docx-document/download.php&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfLoadOptions&nbsp;pdfOptions&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfLoadOptions();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfOptions.ConversionMode&nbsp;=&nbsp;PdfConversionMode.Flowing;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfOptions.DetectTables&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfOptions.RasterizeVectorGraphics&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfOptions.FromPage&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;pdf&nbsp;=&nbsp;DocumentCore.Load(pdfFile,&nbsp;pdfOptions);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdf.Save(docxFile);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;resulting&nbsp;DOCX.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(docxFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/docx-document/index.php">Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/docx-document/download.php">Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that Document.Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
