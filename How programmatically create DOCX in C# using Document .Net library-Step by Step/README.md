# How programmatically create DOCX in C# using Document .Net library?-Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Office
- .NET
- .NET Framework 4
- .NET Framework
- .NET Framework 4.0
- C# Language
- Office 2010
- Visual C#
- Office Development
## Topics
- Controls
- C#
- ASP.NET
- custom controls
- Word
- .NET 4
- How to
- Office 2010 101 code samples
## Updated
- 11/09/2016
## Description

<h1>Introduction</h1>
<p><em><span>If you are looking for a solution to programmatically create DOCX in C# or VB.Net, you are in the right place!</span></em></p>
<p><em><span><img id="163340" src="163340-create-docx.png" alt="" width="699" height="319"><br>
</span></em></p>
<p class="CommonText">Document .Net is 100% managed C# assembly (SautinSoft.Document.dll) which gives you API to generate Office Open XML (DOCX) documents.&nbsp;<br>
<br>
Your .Net app will be able to create DOCX documents with any desired formatting, such as:</p>
<ul class="CommonText">
<li>Insert formatted text, paragraphs, images, plain and nested tables. </li><li>Set page size and orientation (height, width, margin vals). </li><li>Set font type/name, style, and size. </li><li>Add page numbering and page breaks, headers and footers. </li><li>Add sections and pages, bookmarks, Table of contents. </li><li>Full Unicode support. </li></ul>
<p class="CommonText">The library is absolutely standalone and does not require Microsoft Office or any others.</p>
<h1>Main Functions</h1>
<p class="CommonText">The library is absolutely standalone and does not require Microsoft Office or any others.</p>
<h2 class="H2Text">Performance</h2>
<p class="CommonText">At a machine with Intel Core i5-3337U and 4GB of RAM the Document .Net generates a simple DOCX document (one page filled by formatted text) without saving it to HDD:</p>
<ul class="CommonText">
<li>1000 documents by 0.45 sec. </li><li>10000 documents by 3.61 sec. </li></ul>
<h2 class="H2Text">Implementation and code samples</h2>
<p class="CommonText">To get the full set of API to operate with DOCX, you have to only add a reference to&nbsp;<em>&quot;Document.Net&quot;</em>.</p>
<h3 class="CommonText">1. Let's see how easy to create DOCX document in C# application:</h3>
<p><img id="163341" src="163341-create-docx-pict1.png" alt="" width="679" height="281"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;simple&nbsp;DOCX&nbsp;document.</span>&nbsp;
DocumentCore&nbsp;docx&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentCore();&nbsp;
&nbsp;
docx.Content.End.Insert(<span class="cs__string">&quot;Hello&nbsp;my&nbsp;Friend!&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">14</span>,&nbsp;FontName&nbsp;=&nbsp;<span class="cs__string">&quot;Arial&quot;</span>});</pre>
</div>
</div>
</div>
<h3 class="CommonText">2. Let's add a table (2x3) in DOCX using for-loop:</h3>
<p><img id="163342" src="163342-create-docx-pict2.png" alt="" width="674" height="222"></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;simple&nbsp;DOCX&nbsp;document.</span>&nbsp;
DocumentCore&nbsp;docx&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentCore();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;new&nbsp;section</span>&nbsp;
Section&nbsp;s&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Section(docx);&nbsp;
docx.Sections.Add(s);&nbsp;
&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;plain&nbsp;table:&nbsp;2x3.</span>&nbsp;
Table&nbsp;t&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Table(docx);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;2&nbsp;rows.</span><span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;r&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;r&nbsp;&lt;&nbsp;<span class="cs__number">2</span>;&nbsp;r&#43;&#43;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TableRow&nbsp;row&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TableRow(docx);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;3&nbsp;columns.</span><span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;c&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;c&nbsp;&lt;&nbsp;<span class="cs__number">3</span>;&nbsp;c&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TableCell&nbsp;cell&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TableCell(docx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Set&nbsp;some&nbsp;cell&nbsp;formatting</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cell.CellFormat.Borders.SetBorders(MultipleBorderTypes.Outside,&nbsp;BorderStyle.Single,&nbsp;Color.Blue,&nbsp;<span class="cs__number">1.0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cell.CellFormat.PreferredWidth&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;TableWidth(<span class="cs__number">60</span>,&nbsp;TableWidthUnit.Point);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row.Cells.Add(cell);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cell.Content.Start.Insert(String.Format(<span class="cs__string">&quot;[{0},&nbsp;{1}]&quot;</span>,&nbsp;r,&nbsp;c));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;t.Rows.Add(row);&nbsp;
}&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;this&nbsp;table&nbsp;to&nbsp;the&nbsp;current&nbsp;section.</span>&nbsp;
s.Blocks.Add(t);</pre>
</div>
</div>
</div>
<p></p>
<h3 class="CommonText">3. If you want to add an image in DOCX in your .Net app:</h3>
<p><img id="163343" src="163343-create-docx-pict3.png" alt=""></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;simple&nbsp;DOCX&nbsp;document.</span>&nbsp;
DocumentCore&nbsp;docx&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DocumentCore();&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Add&nbsp;a&nbsp;new&nbsp;section</span>&nbsp;
Section&nbsp;s&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Section(docx);&nbsp;
docx.Sections.Add(s);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Add&nbsp;the&nbsp;image&nbsp;as&nbsp;a&nbsp;shape&nbsp;with&nbsp;coordinates.</span>&nbsp;
Picture&nbsp;pict1&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Picture(docx,&nbsp;<span class="js__string">&quot;image1.jpg&quot;</span>);&nbsp;
&nbsp;
FloatingLayout&nbsp;fl&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FloatingLayout(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;HorizontalPosition(<span class="js__num">10</span>,&nbsp;LengthUnit.Millimeter,&nbsp;HorizontalPositionAnchor.Page),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;VerticalPosition(<span class="js__num">10</span>,&nbsp;LengthUnit.Millimeter,&nbsp;VerticalPositionAnchor.TopMargin),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Size(<span class="js__num">70</span>,&nbsp;<span class="js__num">70</span>));&nbsp;
DrawingElement&nbsp;drawingElement&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DrawingElement(docx,&nbsp;fl,&nbsp;pict1);&nbsp;
s.Content.End.Insert(drawingElement.Content);</pre>
</div>
</div>
</div>
<p></p>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/docx-document/index.php">Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/docx-document/download.php">Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><span>&nbsp;Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used.</span><br>
<br>
<span>Note that &laquo;Document .Net&raquo; is entirely written in managed C#, which makes it absolutely standalone and an independent library. Of course, No dependency on Microsoft Word.</span></p>
