# How to Create and Insert Chart to PDF in C# .NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET
- Class Library
- Windows Forms
- .NET Framework
- Visual Basic .NET
- Visual Basic.NET
- VB.Net
- .NET Framework 4.0
- C# Language
- .NET Framework 4.5
- Visual C#
- Visual C Sharp .NET
- Visual Studio 2012
- Visual Studio 2013
- .NET 4.5
- Visual Studio 2015
## Topics
- Create Chart to PDF
- Add Bar Chart to PDF
- Insert Column Chart to PDF
- Add Pie Chart to PDF
- Insert Exploded Pie Chart to PDF
- Add Line Chart to PDF
- Insert Area Chart to PDF
- Add Stacked Bar Chart to PDF
- Insert Stacked Column Chart to PDF
## Updated
- 12/02/2016
## Description

<p><span>Free XsPDF create charts to PDF .NET library allows developers to quickly and easily generate and add chart to PDF documents on any .NET applications (ASP.NET, AJAX, MVC, WinForms) with C# and VB.NET language.</span></p>
<p><span>XsPDF make graphs to PDF for .NET is a &nbsp;professional PDF SDK for&nbsp;commercial and personal use. Developers can create and insert chart graphics to PDF document easily with this C# Control. Multiple chart types are supported to be rendered in
 PDF, such as Bar chart, line chart and pie chart etc.&nbsp;This is a C# demo to add charts to &nbsp;PDF page in C#.</span></p>
<p><span>Free XsPDF Chart Creator for .NET enables developers to quickly and easily generate and add graphs to PDF page with any position and wanted plot size. Flexible chart properties can be modified and customized, includes chart data, series, grid line,
 plot area and color.</span></p>
<h2><strong>Supporting Barcode Type</strong></h2>
<ul>
<li><a title="create line chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-line-chart/">Add Line Chart to PDF in C#</a>
</li><li><a title="create pie chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-pie-chart/">Add Pie Chart to PDF in C#</a>
</li><li><a title="create bar chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-bar-chart/">Add Bar Chart to PDF in C#</a>
</li><li><a title="create column chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-column-chart/">Add Column Chart to PDF in C#</a>
</li><li><a title="create area chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-area-chart/">Add Area Chart to PDF in C#</a>
</li><li><a title="create stacked bar chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-stacked-bar-chart/">Add Stacked Bar Chart to PDF in C#</a>
</li><li><a title="create ean 13 to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-stacked-column-chart/">Add Stacked Column Chart to PDF in C#</a>
</li><li><a title="create exploded pie chart to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-exploded-pie-chart/">Add Exploded Pie Chart to PDF in C#</a>
</li></ul>
<p>&nbsp;</p>
<p><em>Following is a C# sample to add chart to PDF.</em><em>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;AddColumnChartToPDF()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfDocument();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PdfPage&nbsp;page&nbsp;=&nbsp;document.AddPage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Chart&nbsp;chart&nbsp;=&nbsp;ColumnChart();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ChartFrame&nbsp;chartFrame&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChartFrame();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartFrame.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XPoint(<span class="cs__number">30</span>,&nbsp;<span class="cs__number">30</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartFrame.Size&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XSize(<span class="cs__number">500</span>,&nbsp;<span class="cs__number">600</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartFrame.Add(chart);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;XGraphics&nbsp;g&nbsp;=&nbsp;XGraphics.FromPdfPage(page);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chartFrame.Draw(g);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;document.Save(<span class="cs__string">&quot;ColumnChart.pdf&quot;</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">static</span>&nbsp;Chart&nbsp;ColumnChart()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Chart&nbsp;chart&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Chart(ChartType.Column2D);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Series&nbsp;series&nbsp;=&nbsp;chart.SeriesCollection.AddSeries();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;series.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Series&nbsp;1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;series.Add(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[]&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;<span class="cs__number">20</span>,&nbsp;<span class="cs__number">11</span>&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;series&nbsp;=&nbsp;chart.SeriesCollection.AddSeries();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;series.Name&nbsp;=&nbsp;<span class="cs__string">&quot;Series&nbsp;2&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;series.Add(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[]&nbsp;{&nbsp;<span class="cs__number">22</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">8</span>,&nbsp;<span class="cs__number">12</span>&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.XAxis.TickLabels.Format&nbsp;=&nbsp;<span class="cs__string">&quot;00&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.XAxis.MajorTickMark&nbsp;=&nbsp;TickMarkType.Outside;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.XAxis.Title.Caption&nbsp;=&nbsp;<span class="cs__string">&quot;X-Axis&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.YAxis.MajorTickMark&nbsp;=&nbsp;TickMarkType.Outside;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.YAxis.HasMajorGridlines&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.PlotArea.LineFormat.Color&nbsp;=&nbsp;XColors.DarkGray;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.PlotArea.LineFormat.Width&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.PlotArea.LineFormat.Visible&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.Legend.Docking&nbsp;=&nbsp;DockingType.Right;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.DataLabel.Type&nbsp;=&nbsp;DataLabelType.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;chart.DataLabel.Position&nbsp;=&nbsp;DataLabelPosition.OutsideEnd;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;chart;&nbsp;
}</pre>
</div>
</div>
</div>
<h3><strong>Related Links</strong></h3>
<p><strong>WebSite:&nbsp;<a title="PDF editing SDK, convert pdf to image, add barcode to pdf, add chart to pdf in C#" href="http://www.xspdf.com/">http://www.xspdf.com</a></strong></p>
<p><strong>Product&nbsp;<strong>Introduction:&nbsp;<a title="generate and insert chart graphs to pdf document in c# .NET" href="http://www.xspdf.com/product/pdf-chart/">http://www.xspdf.com/product/pdf-chart/</a></strong></strong></p>
