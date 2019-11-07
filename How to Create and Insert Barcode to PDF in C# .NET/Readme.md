# How to Create and Insert Barcode to PDF in C# .NET
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET
- Windows Forms
- Visual Studio 2010
- .NET Framework
- Visual Basic .NET
- VB.Net
- .NET Framework 4.0
- C# Language
- WinForms
- Visual C#
- Visual Studio 2012
- Visual Studio 2013
- Visual Studio 2015
## Topics
- Create Barcode to PDF
- Add QR Code to PDF
- Insert Code 128 to PDF
- Add Data Matrix to PDF
- Insert PDF417 to PDF
- Add Code 39 to PDF
- Insert Aztec Code to PDF
- Add UPCA to PDF
- Insert EAN13 to PDF
## Updated
- 12/02/2016
## Description

<p><span style="font-size:small">Free XsPDF create barcodes to PDF .NET library allows developers to quickly and easily generate and add barcode to PDF documents on any .NET applications (ASP.NET, AJAX, MVC, WinForms) with C# and VB.NET language.</span></p>
<p><span style="font-size:small">XsPDF make barcode to PDF for .NET is a &nbsp;professional PDF SDK for&nbsp;commercial and personal use. Developers can create and insert barcode image to PDF document easily with this C# Control. Multiple barcode types are
 supported to be rendered in PDF, such as QRCode, Data Matrix and Code128 etc.&nbsp;This is a C# demo to insert barcode image to PDF document in C#.</span></p>
<p><span style="font-size:small"><span>Free XsPDF Barcode Creator for .NET enables developers to quickly and easily generate and add barcode to PDF page with any position and wanted barcode size. Flexible barcode properties can be modified and customized, includes
 barcode data, bar color and background color.</span><br>
</span></p>
<h2><strong>Supporting Barcode Type</strong></h2>
<ul>
<li><a title="create qrcode to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-qrcode-creating/">Add QR Code to PDF in C#</a>
</li><li><a title="create data matrix to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-datamatrix-creating/">Add Data Matrix to PDF in C#</a>
</li><li><a title="create pdf417 barcode to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-pdf417-creating/">Add PDF417 to PDF in C#</a>
</li><li><a title="create aztec code to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-azteccode-creating/">Add Aztec Code to PDF in C#</a>
</li><li><a title="create code128 to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-code128-creating/">Add Code128 to PDF in C#</a>
</li><li><a title="create code39 to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-code39-creating/">Add Code39 to PDF in C#</a>
</li><li><a title="create ean 13 to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-ean13-creating/">Add EAN13 to PDF in C#</a>
</li><li><a title="create upc-a to pdf in c# .NET" href="http://www.xspdf.com/guide/pdf-upca-creating/">Add UPCA to PDF in C#</a>
</li></ul>
<p>&nbsp;</p>
<p><span><em>Following is a C# sample to add barcode image to PDF.</em><em>&nbsp;&nbsp;</em></span></p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">PdfDocument document = new PdfDocument();
PdfPage page = document.AddPage();
XGraphics g = XGraphics.FromPdfPage(page);

PdfBarcode barcode = new PdfBarcode();
barcode.BarType = BarCodeType.Code128;
barcode.Data = &quot;123456789&quot;;
barcode.BarcodeColor = XColors.Black;
barcode.BackgroundColor = XColors.White;
barcode.Location = new XPoint(100, 100);
barcode.Size = new XSize(200, 100);
barcode.ShowText = true;
            
barcode.DrawBarcode(g);                        
document.Save(&quot;Barcode.pdf&quot;);</pre>
<div class="preview">
<pre class="js">PdfDocument&nbsp;document&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfDocument();&nbsp;
PdfPage&nbsp;page&nbsp;=&nbsp;document.AddPage();&nbsp;
XGraphics&nbsp;g&nbsp;=&nbsp;XGraphics.FromPdfPage(page);&nbsp;
&nbsp;
PdfBarcode&nbsp;barcode&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;PdfBarcode();&nbsp;
barcode.BarType&nbsp;=&nbsp;BarCodeType.Code128;&nbsp;
barcode.Data&nbsp;=&nbsp;<span class="js__string">&quot;123456789&quot;</span>;&nbsp;
barcode.BarcodeColor&nbsp;=&nbsp;XColors.Black;&nbsp;
barcode.BackgroundColor&nbsp;=&nbsp;XColors.White;&nbsp;
barcode.Location&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XPoint(<span class="js__num">100</span>,&nbsp;<span class="js__num">100</span>);&nbsp;
barcode.Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XSize(<span class="js__num">200</span>,&nbsp;<span class="js__num">100</span>);&nbsp;
barcode.ShowText&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
barcode.DrawBarcode(g);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
document.Save(<span class="js__string">&quot;Barcode.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h3><strong>Related Links</strong></h3>
<p><strong>WebSite:&nbsp;<a title="PDF editing SDK, convert pdf to image, add barcode to pdf, add chart to pdf in C#" href="http://www.xspdf.com">http://www.xspdf.com</a></strong></p>
<p><strong>Product&nbsp;<strong>Introduction:&nbsp;<a title="Add barcode image to PDF SDK in .NET" href="http://www.xspdf.com/product/pdf-barcode/">http://www.xspdf.com/product/pdf-barcode/</a></strong></strong></p>
