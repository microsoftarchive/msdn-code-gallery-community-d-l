# How to Read and Scan Barcode From Image in C#
## Requires
- Visual Studio 2005
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Windows Forms
- Windows SDK
- .NET Framework
- VB.Net
- Library
## Topics
- How to
- Read Barcode
- Scan Barcode
## Updated
- 04/25/2015
## Description

<p class="projectSummary"><span style="font-size:small">Free pqScan.BarcodeScanner for .NET enables developers to quickly and easily read and scan barcode from images on any .NET applications (ASP.NET, WinForms and Web Service) and it supports in C#, VB.NET.</span></p>
<p class="projectSummary"><span style="font-size:small">This is a C # example to read barcodes via a Free C# Barcode Reader library. And the code gives you clear information of how to recognize barcode from image in C#.</span></p>
<p class="projectSummary"><span style="font-size:small"><img id="125991" src="125991-barcode%20reader.png" alt="" width="600" height="400"><br>
</span></p>
<p><span style="font-size:small"><a title="read and decode barcode in .net" href="http://www.pqscan.com/barcode-scanner/"><strong><em>Free</em></strong><strong> pqScan.<span style="font-size:small">BarcodeScanner
</span>for .NET</strong></a> is a professional and reliable Barcode SDK for commercial and personal use. It enables developers to quickly and easily read and scan Barcode on any .NET applications (ASP.NET, WinForms and Web Service) and it supports in C#, VB.NET.
 The SDK supports most popular 2D and 1D barcode types, namely QR Code, Data Matrix, PDF-417, EAN, UPC
<span style="font-size:small">and</span> Code 128 <span style="font-size:small">etc. And
<span style="font-size:small">developers can read barcode from common raster images, like bmp, jpeg, png, tiff, and gif.</span></span></span></p>
<h2><strong>Supporting Barcode Type</strong></h2>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2D Barcode<br>
</strong></p>
<ul>
<li><a title="read qrcode in .net" href="http://www.pqscan.com/read-barcode/qrcode.html">Read QR Code
</a></li><li><a title="read data matrix in .net" href="http://www.pqscan.com/read-barcode/datamatrix.html">Read Data Matrix</a>
</li><li><a title="read pdf417 barcode in .net" href="http://www.pqscan.com/read-barcode/pdf417.html">Read PDF 417
</a></li><li>Read Aztec Code </li></ul>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Linear Barcode</strong></p>
<ul>
<li><a title="read code 128 in .net" href="http://www.pqscan.com/read-barcode/code128.html">Read Code 128</a>
</li><li><a title="read upca in .net" href="http://www.pqscan.com/read-barcode/upca.html">Read UPC-A&nbsp;</a>
</li><li><a title="read upc-e in .net" href="http://www.pqscan.com/read-barcode/upce.html">Read UPC-E<br>
</a></li><li><a title="read ean8 in .net" href="http://www.pqscan.com/read-barcode/ean8.html">Read EAN-8
</a></li><li><a title="read ean13 in .net" href="http://www.pqscan.com/read-barcode/ean13.html">Read EAN-13</a>
</li><li><a title="read code39 in .net" href="http://www.pqscan.com/read-barcode/code39.html">Read Code 39</a>
</li><li><a title="read code93 in .net" href="http://www.pqscan.com/read-barcode/code93.html">Read Code 93<br>
</a></li><li><a title="read codabar in .net" href="http://www.pqscan.com/read-barcode/codabar.html">Read Codabar</a>
</li><li><a title="read itf14 in .net" href="http://www.pqscan.com/read-barcode/itf14.html">Read ITF-14</a>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small"><em>&nbsp;Following is a sample to get all barcodes in the image.</em></span><em>&nbsp;
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">BarcodeResult[] results = BarCodeScanner.Scan(&quot;d:/barcode.png&quot;);

foreach (BarcodeResult result in results)
{
    Console.WriteLine(result.BarType.ToString() &#43; &quot;-&quot; &#43; result.Data);
}</pre>
<div class="preview">
<pre class="csharp">BarcodeResult[]&nbsp;results&nbsp;=&nbsp;BarCodeScanner.Scan(<span class="cs__string">&quot;d:/barcode.png&quot;</span>);&nbsp;
&nbsp;
<span class="cs__keyword">foreach</span>&nbsp;(BarcodeResult&nbsp;result&nbsp;<span class="cs__keyword">in</span>&nbsp;results)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(result.BarType.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;-&quot;</span>&nbsp;&#43;&nbsp;result.Data);&nbsp;
}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">Barcode results provide barcode type and data. And the SDK is a</span><span style="font-size:small">vailable for Rotated Barcode Scanning.</span></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Related Links</strong></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Website:</strong><span class="Apple-converted-space">&nbsp;</span><a title="provide .net barcode generate and read SDK, provide .net pdf to image and image to pdf SDK" href="http://www.pqscan.com"><span style="color:#960bb4; text-decoration:none">http://www.pqscan.com</span></a></p>
<p style="color:#000000; font-family:'Segoe UI',Verdana,Arial; font-size:13px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:normal; orphans:auto; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:auto; word-spacing:0px">
<strong>Product Introduction</strong>:<span class="Apple-converted-space">&nbsp;</span><a title=".net barcode reader and scanner" href="http://www.pqscan.com/barcode-scanner/">http://www.pqscan.com/barcode-scanner/</a></p>
<p><strong>Online Demo</strong>:<span class="Apple-converted-space"> </span><a title="read barcode in .net online demo" href="http://www.pqscan.com/online-demo/barcode-scanner/">http://www.pqscan.com/online-demo/barcode-scanner/</a></p>
