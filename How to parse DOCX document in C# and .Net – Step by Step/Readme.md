# How to parse DOCX document in C# and .Net – Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- .NET
- Windows Forms
- WPF
- XML
- Microsoft Azure
- .NET Framework
- .NET Framework 4.0
- C# Language
- ASP.NET MVC 4
- .NET Framework 4.5
- Visual C#
- ASP.NET Web API
- Visual Studio 2012
- SharePoint Server 2013
- Visual Studio 2013
- .NET 4.5
- .NET Development
## Topics
- Controls
- C#
- ASP.NET
- Class Library
- Microsoft Azure
- custom controls
- Code Sample
- How to
## Updated
- 01/25/2016
## Description

<h1>Introduction</h1>
<p>This C# example shows how to parse DOCX document using a free &quot;DOCX Document .Net&quot; library. Using this library your application can do following with DOCX: parse, create, edit and save.</p>
<p><strong style="font-size:2em">Main Functions</strong></p>
<ul>
<li>Create DOCX document on fly and fill it by necessary data. </li><li>Load DOCX document and get all it's structure as tree of objects. </li><li>Modify text, tables and other data in existing DOCX document. </li><li>Parse current content and structure and Save/Render it as new DOCX. </li><li>Replace data in DOCX document. </li></ul>
<p><strong><img id="147727" src="147727-parse-docx.png" alt="" width="796" height="406"><br>
</strong></p>
<h1><span>How to do it:</span></h1>
<p><em>So, here we'll show you in details how to parse an existing DOCX document in C#.</em></p>
<p><em><span style="color:#000000"><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we've the DOCX file: example.docx (please see in att. file). Let's extrace all text from it and render to Console.</span></em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio. Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;Parse Docx document&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;SautinSoft.Document.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to parse &quot;example.docx&quot;.</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><span><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the &quot;DOCX Document .Net&quot; library we've parsed our DOCX and extracted all text from it.</em></span><span class="pluginEditHolderLink">&nbsp;</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using System.Text;
using SautinSoft.Document;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to Docx file.
            FileInfo pathToDocx = new FileInfo(@&quot;c:\example.docx&quot;);

            // Let's parse docx docuemnt and get all text from it.
            DocumentCore docx = DocumentCore.Load(pathToDocx.FullName);

            StringBuilder text = new StringBuilder();

            foreach (Paragraph par in docx.GetChildElements(true, ElementType.Paragraph))
            {
                foreach (Run run in par.GetChildElements(true, ElementType.Run))
                {
                    text.Append(run.Text);
                }
                text.AppendLine();
            }

            // Show extracted text.
            Console.WriteLine(text);
            Console.ReadLine();

        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Path&nbsp;to&nbsp;Docx&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileInfo&nbsp;pathToDocx&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FileInfo(@<span class="cs__string">&quot;c:\example.docx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;parse&nbsp;docx&nbsp;docuemnt&nbsp;and&nbsp;get&nbsp;all&nbsp;text&nbsp;from&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;docx&nbsp;=&nbsp;DocumentCore.Load(pathToDocx.FullName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;text&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Paragraph&nbsp;par&nbsp;<span class="cs__keyword">in</span>&nbsp;docx.GetChildElements(<span class="cs__keyword">true</span>,&nbsp;ElementType.Paragraph))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Run&nbsp;run&nbsp;<span class="cs__keyword">in</span>&nbsp;par.GetChildElements(<span class="cs__keyword">true</span>,&nbsp;ElementType.Run))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text.Append(run.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text.AppendLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Show&nbsp;extracted&nbsp;text.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h1><span>Source Code Files</span></h1>
<div><em>Related Links:</em></div>
<div><em><br>
Website: <a href="http://www.sautinsoft.com">www.sautinsoft.com</a><br>
Product Home: <a href="http://sautinsoft.com/products/docx-document/index.php">DOCX Document .Net</a><br>
Download: <a href="http://sautinsoft.com/products/docx-document/download.php">DOCX Document .Net</a><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that DOCX Document .Net is entirely written in managed C#, which makes it
 absolutely standalone and an independent library.</em></p>
