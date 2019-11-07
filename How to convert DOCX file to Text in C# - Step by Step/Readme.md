# How to convert DOCX file to Text in C# - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Office
- .NET Framework 4.0
- Library
- Office 2010
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- How to
- Office 2010 101 code samples
## Updated
- 04/27/2016
## Description

<h1>Introduction</h1>
<p><em>This is a C# example to convert any DOCX files in Text files via a free C# &laquo;Document .Net&raquo; library. You will be able to do with DOCX documents all what you want:</em></p>
<ul class="LiText">
<li><em>Generate new document on fly and fill it by necessary data.</em> </li><li><em>Load existing document and get all it's structure as tree of objects.</em>
</li><li><em>Modify paragraph formatting, text, tables, TOC and other elements in existing document.</em>
</li><li><em>Parse the document and get the tree of its objects.</em> </li><li><em>Replace, merge any data in documents and save as new DOCX, Text or RTF.</em>
</li><li><em>Convert between PDF, DOCX, RTF and Text.</em> </li></ul>
<h1><img id="152382" src="152382-document-scheme.png" alt="" width="533" height="309" style="display:block; margin-left:auto; margin-right:auto"></h1>
<p><em>Only the .Net platform and nothing else, 32 and 64-bit support, Medium Trust level.</em></p>
<p class="CommonText"><em>Product Highlights:</em></p>
<ul class="LiText">
<li><em>Created in 100% managed C#.</em> </li><li><em>No Microsoft Office automation.</em> </li><li><em>Has own DOCX parser and renderer according to ECMA-376 specification.</em>
</li><li><em>Has own RTF parser and renderer according to RTF 1.8 specification.</em> </li><li><em>Has own PDF parser according to PDF reference 1.7.</em> </li></ul>
<h1><strong>Main Functions</strong></h1>
<p><strong><img id="152383" src="152383-docx%20to%20text.png" alt=""><br>
</strong></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            SaveAsText();
        }
        /// &lt;summary&gt;
        /// Load an existing .docx file and save it as Text.
        /// &lt;/summary&gt;
        public static void SaveAsText()
        {
            // Working directory
            string workingDir = Path.GetFullPath(@&quot;d:\Tempos\&quot;);
            string docxFile = Path.Combine(workingDir, &quot;romeo.docx&quot;);
            string textFile = Path.ChangeExtension(docxFile, &quot;.txt&quot;);

           
            DocumentCore docx = DocumentCore.Load(docxFile);
            // You may download the latest version of SDK here:    
            // http://sautinsoft.com/products/docx-document/download.php  

            docx.Save(textFile, SaveOptions.TxtDefault);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(textFile);
        }
 
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SaveAsText();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Load&nbsp;an&nbsp;existing&nbsp;.docx&nbsp;file&nbsp;and&nbsp;save&nbsp;it&nbsp;as&nbsp;Text.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SaveAsText()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Working&nbsp;directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;workingDir&nbsp;=&nbsp;Path.GetFullPath(@&quot;d:\Tempos\&quot;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;docxFile&nbsp;=&nbsp;Path.Combine(workingDir,&nbsp;<span class="cs__string">&quot;romeo.docx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;textFile&nbsp;=&nbsp;Path.ChangeExtension(docxFile,&nbsp;<span class="cs__string">&quot;.txt&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;docx&nbsp;=&nbsp;DocumentCore.Load(docxFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://sautinsoft.com/products/docx-document/download.php&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Save(textFile,&nbsp;SaveOptions.TxtDefault);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;the&nbsp;result&nbsp;for&nbsp;demonstation&nbsp;purposes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(textFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
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
