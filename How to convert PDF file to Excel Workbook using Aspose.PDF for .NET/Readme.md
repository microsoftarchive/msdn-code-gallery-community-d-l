# How to convert PDF file to Excel Workbook using Aspose.PDF for .NET
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- VB.Net
- PDF
- VB2013
- Aspose.Pdf for .NET
- VB 2013
- VB.NET Examples
- VB NET
- VB2017
## Topics
- Excel
- VB.Net
- Generate Excel Workbook
## Updated
- 09/05/2018
## Description

<h1>Introduction</h1>
<p>Aspose.Pdf for .NET is a PDF manipulation component. This example shows the feature of conversion PDF file to Excel 2003 Spreadsheet&nbsp;XML or Excel 2007 Workbook (XLSX files). During this conversion, the individual pages of the PDF file are converted
 to Excel worksheets.</p>
<h1>Building the Sample</h1>
<p><em>To build the sample you can use any edition of Visual Studio 2015 or later. All the necessary files are referenced from NuGet and will be automatically downloaded from there.
</em></p>
<p><em><strong>Unfortunately, this example can't create correct XLSX file in trial mode, so before running this example please go to
<a href="https://purchase.aspose.com/temporary-license">Aspose website</a> to obtain a temporary license</strong>.</em></p>
<h1>The conversion process</h1>
<p>In order to convert PDF files to XLS format, Aspose.PDF has a class called <strong>
ExcelSaveOptions</strong>. An object of the <strong>ExcelSaveOptions </strong>class is passed as a second argument to the
<strong>Document.Save(..)</strong> constructor. The following code snippet shows the process for converting a PDF file into XLS format.</p>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// Load PDF document
Document pdfDocument = new Document(&quot;input.pdf&quot;);

// Instantiate ExcelSave Option object
Aspose.Pdf.ExcelSaveOptions excelsave = new ExcelSaveOptions();

// Save the output in XLS format
pdfDocument.Save(&quot;PDFToXLS_out.xls&quot;, excelsave);</pre>
<pre class="hidden">// Load PDF document
Dim pdfDocument = New Document(filename:=&quot;input.pdf&quot;)

// Instantiate ExcelSave Option object
Dim excelSaveOption = New Aspose.Pdf.ExcelSaveOptions()

// Save the output in XLS format
pdfDocument.Save(&quot;PDFToXLS_out.xls&quot;, excelSaveOption);
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Load&nbsp;PDF&nbsp;document</span>&nbsp;
Document&nbsp;pdfDocument&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document(<span class="cs__string">&quot;input.pdf&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Instantiate&nbsp;ExcelSave&nbsp;Option&nbsp;object</span>&nbsp;
Aspose.Pdf.ExcelSaveOptions&nbsp;excelsave&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ExcelSaveOptions();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Save&nbsp;the&nbsp;output&nbsp;in&nbsp;XLS&nbsp;format</span>&nbsp;
pdfDocument.Save(<span class="cs__string">&quot;PDFToXLS_out.xls&quot;</span>,&nbsp;excelsave);</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h2>Additional settings</h2>
<p>When converting a PDF to XLS format, a blank column is added to the output file as the first column. The in
<strong>ExcelSaveOptions</strong> class <strong>InsertBlankColumnAtFirst </strong>
option is used to control this column. By default, it set to true.</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// Instantiate ExcelSave Option object
Aspose.Pdf.ExcelSaveOptions excelsave = new ExcelSaveOptions();
excelsave.InsertBlankColumnAtFirst = false;
</pre>
<pre class="hidden">' Instantiate ExcelSave Option object
Dim excelSaveOption = New ExcelSaveOptions()
excelSaveOption.InsertBlankColumnAtFirst = false</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Instantiate&nbsp;ExcelSave&nbsp;Option&nbsp;object</span>&nbsp;
Aspose.Pdf.ExcelSaveOptions&nbsp;excelsave&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ExcelSaveOptions();&nbsp;
excelsave.InsertBlankColumnAtFirst&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>When exporting a PDF file with a lot of pages to XLS, each page is exported to a different sheet in the Excel file. This is because the
<strong>MinimizeTheNumberOfWorksheets </strong>property is set to false by default. To ensure that all pages are exported to one single sheet in the output Excel file, set the
<strong>MinimizeTheNumberOfWorksheets </strong>property to true.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>
<pre class="hidden">// Instantiate ExcelSave Option object
Aspose.Pdf.ExcelSaveOptions excelsave = new ExcelSaveOptions();
excelsave.MinimizeTheNumberOfWorksheets = true;</pre>
<pre class="hidden">'Instantiate ExcelSave Option object
Dim excelSaveOption = New ExcelSaveOptions()
excelSaveOption.MinimizeTheNumberOfWorksheets = true</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Instantiate&nbsp;ExcelSave&nbsp;Option&nbsp;object</span>&nbsp;
Aspose.Pdf.ExcelSaveOptions&nbsp;excelsave&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ExcelSaveOptions();&nbsp;
excelsave.MinimizeTheNumberOfWorksheets&nbsp;=&nbsp;<span class="cs__keyword">true</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:2em">More Information</span></div>
<p>&nbsp;</p>
</div>
</div>
<ul>
<li>Website:&nbsp;<a rel="nofollow" href="http://www.aspose.com/">www.aspose.com</a>
</li><li>Product Home:&nbsp;<a rel="nofollow" href="https://products.aspose.com/pdf/net">Aspose.Pdf for .NET</a>
</li><li>Download:&nbsp;<a rel="nofollow" href="https://www.nuget.org/packages/Aspose.Pdf/">Download Aspose.Pdf for .NET</a>
</li><li>Documentation:&nbsp;<a rel="nofollow" href="https://docs.aspose.com/display/pdfnet/Home">Aspose.Pdf for .NET Documentation</a>
</li><li>Blog:&nbsp;<a rel="nofollow" href="https://blog.aspose.com/category/aspose-products/aspose-pdf-product-family/">Aspose.Pdf for .NET Blog</a>
</li><li>Telegram channel:&nbsp;<a href="https://t.me/asposepdf">Aspose-PDF</a> </li></ul>
