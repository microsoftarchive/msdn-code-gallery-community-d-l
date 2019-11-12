# How to Generate PDF Table in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- .NET
- Windows Forms
- WPF
- .NET Framework
- VB.Net
## Topics
- Controls
- C#
- ASP.NET
- Windows Forms
- How to
- .Net Programming
- PDF API
- Generate pdf table
- Create table in pdf file
## Updated
- 02/05/2017
## Description

<h1>Introduction</h1>
<p>Do you want to generate PDF table in C#.NET application? Well, here you can save all the troubles by using a free .NET library -
<a href="https://www.e-iceblue.com/Introduce/free-pdf-component.html#.WGDMbX3HrhM">
Free Spire.PDF for .NET</a>, with which you may easily create new pdf document with table inside according to your needs.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Free Spire.PDF for .NET is a professional PDF component, which enables developers to quickly and easily perform a wide range of PDF processing tasks entirely through C#/VB.NET without installing Adobe Acrobat.</p>
<p>This sample focuses on demonstrating its feature of how to generate PDF table.</p>
<p><strong>Building the Sample </strong></p>
<ul>
<li>Download <a href="https://www.e-iceblue.com/Download/download-pdf-for-net-now.html">
Free Spire.PDF for .NET</a> and extract the zip file; </li><li>Create a Visual C#/.NET application project such as Console Application; </li><li>Now add the reference of Spire.PDF.dll in the bin folder into your assemblies;
</li><li>Add these namespaces </li></ul>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Spire.Pdf;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Graphics;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Spire.Pdf.Tables&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Using the Code</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;pdf&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;doc&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//margin</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfUnitConvertor&nbsp;unitCvtr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfUnitConvertor();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfMargins&nbsp;margin&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfMargins();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;margin.Top&nbsp;=&nbsp;unitCvtr.ConvertUnits(<span class="cs__number">2</span>.54f,&nbsp;PdfGraphicsUnit.Centimeter,&nbsp;PdfGraphicsUnit.Point);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;margin.Bottom&nbsp;=&nbsp;margin.Top;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;margin.Left&nbsp;=&nbsp;unitCvtr.ConvertUnits(<span class="cs__number">3</span>.17f,&nbsp;PdfGraphicsUnit.Centimeter,&nbsp;PdfGraphicsUnit.Point);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;margin.Right&nbsp;=&nbsp;margin.Left;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;new&nbsp;page</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfPageBase&nbsp;page&nbsp;=&nbsp;doc.Pages.Add(PdfPageSize.A4,&nbsp;margin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;y&nbsp;=&nbsp;<span class="cs__number">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//title</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfBrush&nbsp;brush1&nbsp;=&nbsp;PdfBrushes.Black;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfTrueTypeFont&nbsp;font1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfTrueTypeFont(<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;Arial&quot;</span>,&nbsp;16f,&nbsp;FontStyle.Bold));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfStringFormat&nbsp;format1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfStringFormat(PdfTextAlignment.Center);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.Canvas.DrawString(<span class="cs__string">&quot;Country&nbsp;List&quot;</span>,&nbsp;font1,&nbsp;brush1,&nbsp;page.Canvas.ClientSize.Width&nbsp;/&nbsp;<span class="cs__number">2</span>,&nbsp;y,&nbsp;format1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;y&nbsp;&#43;&nbsp;font1.MeasureString(<span class="cs__string">&quot;Country&nbsp;List&quot;</span>,&nbsp;format1).Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;y&nbsp;&#43;&nbsp;<span class="cs__number">5</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;data&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Name;Capital;Continent;Area;Population&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Argentina;Buenos&nbsp;Aires;South&nbsp;America;2777815;32300003&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Bolivia;La&nbsp;Paz;South&nbsp;America;1098575;7300000&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Brazil;Brasilia;South&nbsp;America;8511196;150400000&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;Canada;Ottawa;North&nbsp;America;9976147;26500000&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[][]&nbsp;dataSource&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;String[data.Length][];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;data.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataSource[i]&nbsp;=&nbsp;data[i].Split(<span class="cs__string">';'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfTable&nbsp;table&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfTable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Style.CellPadding&nbsp;=&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Style.HeaderSource&nbsp;=&nbsp;PdfHeaderSource.Rows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Style.HeaderRowCount&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.Style.ShowHeader&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;table.DataSource&nbsp;=&nbsp;dataSource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfLayoutResult&nbsp;result&nbsp;=&nbsp;table.Draw(page,&nbsp;<span class="cs__keyword">new</span>&nbsp;PointF(<span class="cs__number">0</span>,&nbsp;y));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;y&nbsp;&#43;&nbsp;result.Bounds.Height&nbsp;&#43;&nbsp;<span class="cs__number">5</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfBrush&nbsp;brush2&nbsp;=&nbsp;PdfBrushes.Gray;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PdfTrueTypeFont&nbsp;font2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfTrueTypeFont(<span class="cs__keyword">new</span>&nbsp;Font(<span class="cs__string">&quot;Arial&quot;</span>,&nbsp;9f));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;page.Canvas.DrawString(String.Format(<span class="cs__string">&quot;*&nbsp;{0}&nbsp;countries&nbsp;in&nbsp;the&nbsp;list.&quot;</span>,&nbsp;data.Length&nbsp;-&nbsp;<span class="cs__number">1</span>),&nbsp;font2,&nbsp;brush2,&nbsp;<span class="cs__number">5</span>,&nbsp;y);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;pdf&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.SaveToFile(<span class="cs__string">&quot;SimpleTable.pdf&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(<span class="cs__string">&quot;SimpleTable.pdf&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Effective Screenshot:</strong></p>
<p>Finally the table is created in bin/Debug folder. Check from there.</p>
<p><img id="169234" src="169234-%e8%bf%87%e5%88%86.png" alt="" width="495" height="339"></p>
<h1>More Information</h1>
<p>Free Spire.PDF for .NET is a PDF component which contains an incredible wealth of features to create, read, edit and manipulate PDF documents on .NET, Silverlight and WPF Platform.
<strong></strong></p>
<p><strong>Overview of detailed features</strong></p>
<p>Main Features:</p>
<ul>
<li>High quality Conversion </li><li>Merge/Split PDF documents </li><li>Text, Image Extract from PDF documents </li><li>Encrypt, Decrypt, Create PDF Digital Signature from PDF documents </li><li>Add PDF Header and Footer </li><li>Add Text and Image Watermark </li><li>Print PDF documents </li></ul>
<p>Technical Features:</p>
<ul>
<li>Fully written in C# and also support VB.NET </li><li>Applied on .NET Framework 2.0, 3.5, 3.5 Client Profile, 4.0, 4.0 Client Profile and 4.5
</li><li>Support Windows Forms and ASP.NET Applications </li><li>Support 32-bit OS </li><li>Support 64-bit OS </li><li>Support PDF Version 1.2, 1.3, 1.4, 1.5, 1.6 and 1.7 </li><li>PDF API reference in HTML </li><li>Be Independent and do not need Adobe Acrobat or other third party pdf libraries&nbsp;
</li></ul>
<p>Welcome to visit complete details and start a free trial at:</p>
<p><strong>Website: </strong><a href="http://www.e-iceblue.com">www.e-iceblue.com</a><strong>
</strong></p>
<p><strong>Download: </strong><a href="https://www.e-iceblue.com/Introduce/free-pdf-component.html#.WGDMbX3HrhM">Free Spire.PDF for .NET</a></p>
<p><strong>Forum: </strong><a href="https://www.e-iceblue.com/forum/spire-pdf-f7.html">Free PDF Library Forum</a></p>
