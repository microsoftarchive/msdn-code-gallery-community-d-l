# How to create a PDF/A Compliance document in C# and VB.Net - Step by Step
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- .NET
- Windows Forms
- WPF
- .NET Framework
- VB.Net
- Visual C#
## Topics
- Controls
- Graphics
- C#
- ASP.NET
- User Interface
- WPF
- Drawing
- How to
- PDF
- Portable Document Format (pdf)
- Export to Pdf
- HTML to PDF
- PDF API
- C# PDF
- Html To Pdf Conversion
- ASP.NET Core
## Updated
- 02/18/2018
## Description

<h1>Introduction</h1>
<p><span style="white-space:pre">&nbsp;</span>PDF/A is an ISO-standardized version of the Portable Document Format (PDF) specialized for use in the archiving and long-term preservation of electronic documents.&nbsp;<br>
<span style="white-space:pre">&nbsp;</span>PDF/A differs from PDF by prohibiting features ill-suited to long-term archiving, such as font linking (as opposed to font embedding) and encryption. The ISO requirements for PDF/A file viewers include color management
 guidelines, support for embedded fonts, and a user interface for reading embedded annotations.</p>
<p><span style="white-space:pre">&nbsp;</span>&nbsp;Let's create a simple PDF document from a DOCX file. By the way, this code shows - how to load an existing document and save it as a PDF/A compliant version.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">PdfSaveOptions&nbsp;options&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfSaveOptions()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;PdfComliance&nbsp;supports:&nbsp;PDF/A,&nbsp;PDF/1.5,&nbsp;etc.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Compliance&nbsp;=&nbsp;PdfCompliance.PDF_A&nbsp;
<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>If you need to load an existing document (*.docx, *.rtf, *.pdf, *.html, *.txt, etc) and save it as a PDF/A compliant version, you need to point a path for this file:</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Path&nbsp;to&nbsp;a&nbsp;loadable&nbsp;document.</span>&nbsp;
string&nbsp;loadPath&nbsp;=&nbsp;@<span class="js__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\example.pdf&quot;</span>;&nbsp;
<span class="js__sl_comment">//string&nbsp;loadPath&nbsp;=&nbsp;@&quot;..\..\..\..\..\..\Testing&nbsp;Files\example.html&quot;;</span>&nbsp;
<span class="js__sl_comment">//string&nbsp;loadPath&nbsp;=&nbsp;@&quot;..\..\..\..\..\..\Testing&nbsp;Files\example.rtf&quot;;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><img id="185820" src="185820-pdfa.png" alt="" width="800" height="268"></div>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadAndSaveAsPDFA();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Load&nbsp;an&nbsp;existing&nbsp;document&nbsp;(*.docx,&nbsp;*.rtf,&nbsp;*.pdf,&nbsp;*.html,&nbsp;*.txt,&nbsp;*.pdf)&nbsp;and&nbsp;save&nbsp;it&nbsp;as&nbsp;a&nbsp;PDF/A&nbsp;compliant&nbsp;version.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoadAndSaveAsPDFA()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Path&nbsp;to&nbsp;a&nbsp;loadable&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;loadPath&nbsp;=&nbsp;@<span class="cs__string">&quot;..\..\..\..\..\..\Testing&nbsp;Files\example.docx&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//DocumentCore.Serial&nbsp;=&nbsp;&quot;put&nbsp;your&nbsp;serial&nbsp;here&quot;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;document&nbsp;=&nbsp;DocumentCore.Load(loadPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfSaveOptions&nbsp;options&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfSaveOptions()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;PdfComliance&nbsp;supports:&nbsp;PDF/A,&nbsp;PDF/1.5,&nbsp;etc.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Compliance&nbsp;=&nbsp;PdfCompliance.PDF_A&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;savePath&nbsp;=&nbsp;Path.ChangeExtension(loadPath,&nbsp;<span class="cs__string">&quot;.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.Save(savePath,&nbsp;options);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;file&nbsp;-&nbsp;example.pdf.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(savePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em><span>Install from Nuget: PM&gt; Install-Package sautinsoft.document.</span></em></div>
<div><em><span>&nbsp;</span><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/document/index.php">Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/docx-document/download.php">Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><span>&nbsp;Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used.</span><br>
<br>
<span>Note that &laquo;Document .Net&raquo; is entirely written in managed C#, which makes it absolutely standalone and an independent library. Of course, No dependency on Microsoft Word.</span></p>
