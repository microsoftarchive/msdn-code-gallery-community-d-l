# How to replace text in PDF in .NET Standard 2.0
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET
- Windows Forms
- WPF
- .NET Framework
- C# Language
- PDF
- PDF API
- Aspose.Pdf for .NET
- .NET Core
- ASP.NET Core
- .NET PDF API
## Topics
- C#
- ASP.NET
- Windows Forms
- How to
- PDF
- PDF file
- Portable Document Format (pdf)
- C# PDF
- .NET PDF library
- find and replace data
## Updated
- 05/01/2018
## Description

<h1>Introduction</h1>
<p><em><span>Aspose.Pdf for .NET/Core/Standard 2.0 is a PDF manipulation component. This example shows how to you&nbsp;can replace text in PDF&nbsp; using an&nbsp;<strong>Aspose.Pdf.Facades.PdfContentEditor
</strong>class<strong>.</strong></span></em></p>
<h1>Building the Sample</h1>
<p><em><span>To build the sample you can use any edition of Visual Studio 2017. All the necessary files are referenced from NuGet and will be automatically downloaded from there. This sample also can be built in Visual Studio Code. After the build, you can
 run the demo application in console.</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The easiest way to replace text in PDF is using&nbsp;<em><strong>Aspose.Pdf.Facades.PdfContentEditor.ReplaceText()&nbsp;</strong>method.&nbsp;</em></em><em>This sample contains two demonstrations: a&nbsp;simple replacement of one text segment to another
 and a replacement with font settings.</em></p>
<h2>Steps involved</h2>
<ol>
<li>Create an instance of <a href="https://apireference.aspose.com/net/pdf/aspose.pdf/document" target="_blank">
Document</a>&nbsp;class and open the PDF document; </li><li>Create an instance of <a href="https://apireference.aspose.com/net/pdf/aspose.pdf.facades/pdfcontenteditor" target="_blank">
PdfContentEditor</a> and bind the document; </li><li>Set text replacement strategy - find first or find all text occurrences; </li><li>Run the&nbsp;<em><em><strong>ReplaceText </strong>method.</em></em> </li></ol>
<p>In the simplest case, the code will look like it's shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">var&nbsp;pdfDocument&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Aspose.Pdf.Document(@<span class="cs__string">&quot;.\Data\demo.pdf&quot;</span>);&nbsp;
var&nbsp;pdfContentEditor&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Aspose.Pdf.Facades.PdfContentEditor();&nbsp;
&nbsp;
pdfContentEditor.BindPdf(pdfDocument);&nbsp;
pdfContentEditor.TextReplaceOptions.ReplaceScope&nbsp;=&nbsp;TextReplaceOptions.Scope.REPLACE_FIRST;&nbsp;
pdfContentEditor.ReplaceText(<span class="cs__string">&quot;TextToFind&quot;</span>,&nbsp;<span class="cs__string">&quot;TextToReplace&quot;</span>);</pre>
</div>
</div>
</div>
<p>This example uses a PDF document with an invitation template for a music contest. The&nbsp;<strong>ReplaceTextExampleSimple&nbsp;</strong>shows the replacement of single fragments such as dates and general info and repeated fragments such as contest title.</p>
<p>The <strong>ReplaceTextExampleWithFontSettings </strong>method does the same, but some of the text fragments will be decorated as red text with 14pt size.</p>
<h1>More Information</h1>
<ul>
<li>Website:&nbsp;<a rel="nofollow" href="http://www.aspose.com/">www.aspose.com</a>
</li><li>Product Home:&nbsp;<a rel="nofollow" href="https://products.aspose.com/pdf/net">Aspose.Pdf for .NET</a>
</li><li>Download:&nbsp;<a rel="nofollow" href="https://www.nuget.org/packages/Aspose.Pdf/">Download Aspose.Pdf for .NET</a>
</li><li>Documentation:&nbsp;<a rel="nofollow" href="https://docs.aspose.com/display/pdfnet/Home">Aspose.Pdf for .NET Documentation</a>
</li><li>Blog:&nbsp;<a rel="nofollow" href="https://blog.aspose.com/category/aspose-products/aspose-pdf-product-family/">Aspose.Pdf for .NET Blog</a>
</li><li>Telegram channel:&nbsp;<a href="https://t.me/asposepdf">Aspose-PDF</a> </li></ul>
