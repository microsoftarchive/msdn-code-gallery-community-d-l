# How to create DOCX document in C# (without MS Word installed) - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Office
- Windows Forms
- Microsoft Azure
- .NET Framework
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- custom controls
- Word
- How to
- Office 2010 101 code samples
- User Control
## Updated
- 04/19/2016
## Description

<h1>Introduction</h1>
<p><em>This is a C# example to generate a DOCX file via a free C# &laquo;DOCX Document .Net&raquo; library. You will be able to create DOCX document on fly and fill it by necessary data.</em></p>
<p><img id="151061" src="151061-docx-document-scheme.png" alt="" width="487" height="281" style="display:block; margin-left:auto; margin-right:auto"><br>
<em>If you are searching for a solution to create DOCX in C#, stop the searching - you're in the right place! The DOCX Document.Net is only the one library designed for this purpose.</em></p>
<p><br>
<em>Only the .Net platform and nothing else, 32 and 64-bit support, Medium Trust level.</em></p>
<p><em>You will be able to do with DOCX documents all what you want:&nbsp;</em></p>
<ul class="LiText">
<li><em>Create a DOCX document on fly and fill it by necessary data.</em> </li><li><em>Load a DOCX document and get all it's structure as tree of objects.</em> </li><li><em>Modify text, tables and other data in an existing DOCX document.</em> </li><li><em>Parse the current content and structure and Save/Render it as a new DOCX.</em>
</li><li><em>Replace data in a DOCX document.</em> </li></ul>
<p><strong style="font-size:2em">Main Functions</strong></p>
<p>The simple code sample:</p>
<p><img id="151060" src="151060-code_docx.png" alt=""></p>
<p>The result (Docx file):</p>
<p><em><img id="151067" src="151067-docx.png" alt="" width="610" height="323"><br>
</em></p>
<p>&nbsp;</p>
<h1><span>How to do it:</span></h1>
<p><em>So, here we'll show you in details how to create DOCX document on fly and fill it by necessary data.</em></p>
<p><em><span><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we need to generate a simple DOCX document with 2 paragraphs.</span></em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;simple DOCX&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;Document.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to create a simple DOCX file with name: Result.docx</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><span><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the Docx Document .Net library we've created an editable Word document.</em></span></p>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDocx();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateDocx()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Working&nbsp;directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;workingDir&nbsp;=&nbsp;Path.GetFullPath(Directory.GetCurrentDirectory()&nbsp;&#43;&nbsp;@<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;docxFilePath&nbsp;=&nbsp;Path.Combine(workingDir,&nbsp;<span class="cs__string">&quot;Result.docx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;simple&nbsp;DOCX&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;docx&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentCore();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://sautinsoft.com/products/docx-document/download.php&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;new&nbsp;section.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Section&nbsp;section&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Section(docx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Sections.Add(section);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;set&nbsp;page&nbsp;size&nbsp;A4.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;section.PageSetup.PaperType&nbsp;=&nbsp;PaperType.A4;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;two&nbsp;paragraphs&nbsp;using&nbsp;different&nbsp;ways:</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Way&nbsp;1:&nbsp;Add&nbsp;1st&nbsp;paragraph.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;section.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(docx,&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;first&nbsp;line&nbsp;in&nbsp;1st&nbsp;paragraph!&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Paragraph&nbsp;par1&nbsp;=&nbsp;section.Blocks[<span class="cs__number">0</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;Paragraph;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.ParagraphFormat.Alignment&nbsp;=&nbsp;HorizontalAlignment.Center;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;add&nbsp;a&nbsp;second&nbsp;line.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.Inlines.Add(<span class="cs__keyword">new</span>&nbsp;SpecialCharacter(docx,&nbsp;SpecialCharacterType.LineBreak));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.Inlines.Add(<span class="cs__keyword">new</span>&nbsp;Run(docx,&nbsp;<span class="cs__string">&quot;Let's&nbsp;type&nbsp;a&nbsp;second&nbsp;line.&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;change&nbsp;font&nbsp;name,&nbsp;size&nbsp;and&nbsp;color.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CharacterFormat&nbsp;cf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;FontName&nbsp;=&nbsp;<span class="cs__string">&quot;Verdana&quot;</span>,&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">16</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.Orange&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Inline&nbsp;inline&nbsp;<span class="cs__keyword">in</span>&nbsp;par1.Inlines)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(inline&nbsp;<span class="cs__keyword">is</span>&nbsp;Run)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(inline&nbsp;<span class="cs__keyword">as</span>&nbsp;Run).CharacterFormat&nbsp;=&nbsp;cf.Clone();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Way&nbsp;2&nbsp;(easy):&nbsp;Add&nbsp;2nd&nbsp;paragarph&nbsp;using&nbsp;another&nbsp;way.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Content.End.Insert(<span class="cs__string">&quot;\nThis&nbsp;is&nbsp;a&nbsp;first&nbsp;line&nbsp;in&nbsp;2nd&nbsp;paragraph.&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">25</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.Blue,&nbsp;Bold&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SpecialCharacter&nbsp;lBr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpecialCharacter(docx,&nbsp;SpecialCharacterType.LineBreak);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Content.End.Insert(lBr.Content);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Content.End.Insert(<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;second&nbsp;line.&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">20</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.DarkGreen,&nbsp;UnderlineStyle&nbsp;=&nbsp;UnderlineType.Single&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Save&nbsp;DOCX&nbsp;to&nbsp;a&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;docx.Save(docxFilePath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;the&nbsp;result&nbsp;for&nbsp;demonstation&nbsp;purposes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(docxFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
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
Product Home: <a href="http://sautinsoft.com/products/docx-document/index.php">Docx Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/docx-document/download.php">Docx Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that DOCX Document.Net is entirely written in managed C#, which makes it
 absolutely standalone and an independent library</em></p>
