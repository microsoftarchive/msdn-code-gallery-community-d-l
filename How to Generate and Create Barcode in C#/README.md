# How to Generate and Create Barcode in C#
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Class Library
- Windows Forms
- .NET Framework
- VB.Net
## Topics
- How to
- Generate Barcode
- Create Barcode
- Encode Barcode
## Updated
- 11/20/2014
## Description

<p class="projectSummary"><span style="font-size:small">Free pqScan.BarcodeCreator for .NET enables developers to quickly and easily generate and create barcode in any .NET applications (ASP.NET, WinForms and Console application) and it supports in C#, VB.NET.
 To save your time, you can use pqScan Barcode Creator WinForms Control to generate barcodes on Windows Forms directly. Besides, generating barcodes on aspx web page with pqScan Barcode Creator WebForm Control is also supplied.<br>
</span></p>
<p><span style="font-size:small">This is a C # example to create barcodes via a Free C# Barcode Generator library. And the code gives you clear information of how to encode and draw barcode in C#.</span><br>
<em>&nbsp; </em></p>
<p><span style="font-size:small"><a title="encode and create barcode in .net" href="http://www.pqscan.com/barcode-creator/"><strong><em>Free</em></strong><strong> pqScan.<span style="font-size:small">BarcodeCreator
</span>for .NET</strong></a> is a professional and reliable Barcode SDK for commercial and personal use. It enables developers to quickly and easily encode and paint Barcode in any .NET applications and it supports in C#, VB.NET. The SDK supports most commonly
 used 2D and 1D barcode types, such as QR Code Aztec Code, PDF-417, EAN/UPC <span style="font-size:small">
and</span> Code 128 <span style="font-size:small">etc. And <span style="font-size:small">
developers can generate barcode to common raster images, like jpeg, bmp, tiff, png, and gif.</span></span></span></p>
<h2><strong>Supporting Barcode Type</strong></h2>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2D Barcode<br>
</strong></p>
<ul>
<li><a title="create qrcode in .net" href="http://www.pqscan.com/generate-barcode/qrcode.html">Generate QR Code
</a></li><li><a title="create aztec code in .net" href="http://www.pqscan.com/generate-barcode/aztec.html">Generate Aztec Code</a>
</li><li><a title="create data matrix in .net" href="http://www.pqscan.com/generate-barcode/datamatrix.html">Generate Data Matrix</a>
</li><li><a title="create pdf417 barcode in .net" href="http://www.pqscan.com/generate-barcode/pdf417.html">Generate PDF 417
</a></li></ul>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Linear Barcode</strong></p>
<ul>
<li><a title="create code 128 in .net" href="http://www.pqscan.com/generate-barcode/code128.html">Generate Code 128</a>
</li><li><a title="create upca in .net" href="http://www.pqscan.com/generate-barcode/upca.html">Generate UPC-A
</a></li><li><a title="create ean8 in .net" href="http://www.pqscan.com/generate-barcode/ean8.html">Generate EAN-8
</a></li><li><a title="create ean13 in .net" href="http://www.pqscan.com/generate-barcode/ean13.html">Generate EAN-13</a>
</li><li><a title="create code39 in .net" href="http://www.pqscan.com/generate-barcode/code39.html">Generate Code 39</a>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>&nbsp;Following is a sample to get all barcodes in the image.</em></span><em>
<br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Barcode&nbsp;barcode&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Barcode();&nbsp;
&nbsp;
barcode.BarType&nbsp;=&nbsp;BarCodeType.QRCode;&nbsp;
&nbsp;
barcode.Data&nbsp;=&nbsp;<span class="cs__string">&quot;11123456789ABC&quot;</span>;&nbsp;
&nbsp;
barcode.Width&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
barcode.Height&nbsp;=&nbsp;<span class="cs__number">200</span>;&nbsp;
&nbsp;
barcode.QRCodeECL&nbsp;=&nbsp;ErrorCorrectionLevelMode.L;&nbsp;
&nbsp;
barcode.PictureFormat&nbsp;=&nbsp;ImageFormat.Jpeg;&nbsp;
&nbsp;
barcode.CreateBarcode(<span class="cs__string">&quot;qrcode.jpeg&quot;</span>);</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Just a few lines C# code, you will get a perfect barcode image</span><span style="font-size:small">.</span></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Related Links</strong></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Website:</strong><span class="Apple-converted-space">&nbsp;</span><a title="provide .net barcode generate and read SDK, provide .net pdf to image and image to pdf SDK" href="http://www.pqscan.com"><span style="color:#960bb4; text-decoration:none">http://www.pqscan.com</span></a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Product Introduction</strong>:<span class="Apple-converted-space">&nbsp;</span><a title=".net barcode generator and creator" href="http://www.pqscan.com/barcode-creator/">http://www.pqscan.com/barcode-creator/</a></p>
<p><strong>Online Demo</strong>:<span class="Apple-converted-space"> </span><a title="generate barcode in .net online demo" href="http://www.pqscan.com/online-demo/barcode-creator/">http://www.pqscan.com/online-demo/barcode-creator/</a></p>
