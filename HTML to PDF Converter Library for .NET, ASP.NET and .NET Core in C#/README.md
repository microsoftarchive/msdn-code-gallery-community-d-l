# HTML to PDF Converter Library for .NET, ASP.NET and .NET Core in C#
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- .NET
- Windows Forms
- WPF
- MVC
## Topics
- HTML to PDF
- HTML to PDF Converter for .NET
- .NET HTML to PDF Converter
- HTML to PDF Converter
## Updated
- 06/30/2018
## Description

<p>&nbsp;</p>
<p>The majority of the websites are already able to produce reports or to present various results in HTML pages. While the HTML content is simple generate and edit it is not suitable for printing or for transmission by email. The de facto standard for printing
 is the PDF format. The <a href="http://www.hiqpdf.com">HiQPdf HTML to PDF Converter for .NET</a>&nbsp;can be used in your .NET applications to transform any HTML page into a PDF document preserving the original aspect of the HTML document.</p>
<h2><span>Building the Sample</span></h2>
<p>The demo is an ASP.NET website in C# offering sample code for the most important features of the software. To build the sample you have to open the Visual Studio solution and build the project. All the necessary files are referenced from NuGet and will be
 automatically copied from there. After build you can run the demo application in a browser. The same demo application is also available online at
<a href="http://www.hiqpdf.com/demo/ConvertHtmlToPdf.aspx">HiQPdf HTML to PDF Demo</a>&nbsp;.</p>
<h2>Description</h2>
<p>This sample shows you how to quickly create PDF reports from existing HTML reports. The HTML report can be any HTML page containing HTML5 code, CSS3, JavaScript or SVG. Additionally you can convert the HTML pages to raster images (JPEG, PNG or BMP) and to
 SVG vector images.</p>
<p>An useful feature for creating reports is the support for @media rules in CSS to have different layouts for Screen and Print.&nbsp;Using CSS media types in a HTML document you can have one layout for screen, one for print and one for handheld devices. The
 @media rule allows different style rules for different media in the same style sheet in a HTML document. By default the HTML to PDF converter will render the HTML document for 'screen', but can layout the document for another media type by simply setting a
 property in your code.</p>
<p>The support for repeating HTML table headers and footers in each PDF page helps you easily create good looking printable tables. The page breaks control using API properties or CSS styles is another key feature when designing your reports.</p>
<p>The HTML to PDF conversion engine is the most important feature, but the HiQPdf software is a complete PDF Library for .NET. You can create new PDF documents and add text and images at the desired positions in pages in a traditional manner, open and edit
 external PDF documents by adding new objects, create PDF documents with interactive forms, fill and submit interactive forms, merge and split PDF documents, extract text and images from PDF documents, search text in PDF documents, rasterize PDF pages to images.</p>
<p>The HiQPdf Library for .NET offers you the fastest and the most precise HTML to PDF conversion technology to use in your Web and Desktop applications. The HTML to PDF Converter can convert to PDF any HTML document or URL that a modern browser can display,
 preserving all the CSS styles and executing all the JavaScript scripts found in the HTML document.</p>
<p>Besides the common features a HTML to PDF Converter must have, the HiQPdf component has some unique features on the market like the support for web fonts in Web Open Font Format (WOFF), the ability to convert only a selected region of the HTML document or
 the possibility to overlap multiple HTML documents in the same PDF while preserving the transparent backgrounds and images from the HTML document<br>
Convert Modern HTML5 Documents with CSS3, SVG, Canvas and JavaScript.</p>
<p>The HTML documents can contain last generation content like Scalar Vector Graphics, Canvas and CSS3 styles. The JavaScript engine is fast, can handle complex scripts and exposes in HTML page objects you can use to manually trigger conversion or to determine
 various information about converter during conversion</p>
<p>The HiQPdf HTML to PDF Converter can render HTML documents using Web Fonts in formats like Web Open Font Format (WOFF), TrueType or OpenType with TrueType Outlines. The Web Fonts offer a great flexibility to web designers to create special effects on text
 in a HTML document because they are not limited anymore to a small set of fonts installed on the client computers displaying the HTML document. The Web Fonts are downloaded on the fly by converter and used to render the HTML document to PDF without installing
 those fonts on the local machine. The location from where the fonts can be downloaded is given in a CSS3 @font-face rule.</p>
<p>The HiQPdf Software does not depend on installed browsers, printer drivers, viewers or any other third party software. The HiQPdf Library for .NET can be deployed by simply copying it on the server. It is also possible to install the library in the .NET
 Framework GAC</p>
<p>The code below shows how configure the basic options of the converter when converting a web page or a HTML code to PDF.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;create&nbsp;the&nbsp;HTML&nbsp;to&nbsp;PDF&nbsp;converter</span>&nbsp;
HtmlToPdf&nbsp;htmlToPdfConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdf();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;width</span>&nbsp;
htmlToPdfConverter.BrowserWidth&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserWidth.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;height&nbsp;if&nbsp;specified,&nbsp;otherwise&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(textBoxBrowserHeight.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.BrowserHeight&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserHeight.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;HTML&nbsp;Load&nbsp;timeout</span>&nbsp;
htmlToPdfConverter.HtmlLoadedTimeout&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxLoadHtmlTimeout.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;PDF&nbsp;page&nbsp;size&nbsp;and&nbsp;orientation</span>&nbsp;
htmlToPdfConverter.Document.PageSize&nbsp;=&nbsp;GetSelectedPageSize();&nbsp;
htmlToPdfConverter.Document.PageOrientation&nbsp;=&nbsp;GetSelectedPageOrientation();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;the&nbsp;PDF&nbsp;standard&nbsp;used&nbsp;by&nbsp;the&nbsp;document</span>&nbsp;
htmlToPdfConverter.Document.PdfStandard&nbsp;=&nbsp;checkBoxPdfA.Checked&nbsp;?&nbsp;PdfStandard.PdfA&nbsp;:&nbsp;PdfStandard.Pdf;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;PDF&nbsp;page&nbsp;margins</span>&nbsp;
htmlToPdfConverter.Document.Margins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfMargins(<span class="cs__number">5</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;triggering&nbsp;mode;&nbsp;for&nbsp;WaitTime&nbsp;mode&nbsp;set&nbsp;the&nbsp;wait&nbsp;time&nbsp;before&nbsp;convert</span>&nbsp;
<span class="cs__keyword">switch</span>&nbsp;(dropDownListTriggeringMode.SelectedValue)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;Auto&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.TriggerMode&nbsp;=&nbsp;ConversionTriggerMode.Auto;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;WaitTime&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.TriggerMode&nbsp;=&nbsp;ConversionTriggerMode.WaitTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.WaitBeforeConvert&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxWaitTime.Text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;Manual&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.TriggerMode&nbsp;=&nbsp;ConversionTriggerMode.Manual;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">default</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.TriggerMode&nbsp;=&nbsp;ConversionTriggerMode.Auto;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;header&nbsp;and&nbsp;footer</span>&nbsp;
SetHeader(htmlToPdfConverter.Document);&nbsp;
SetFooter(htmlToPdfConverter.Document);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;to&nbsp;PDF</span>&nbsp;
<span class="cs__keyword">byte</span>[]&nbsp;pdfBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(radioButtonConvertUrl.Checked)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;URL&nbsp;to&nbsp;a&nbsp;PDF&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;textBoxUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertUrlToMemory(url);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlCode&nbsp;=&nbsp;textBoxHtmlCode.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseUrl&nbsp;=&nbsp;textBoxBaseUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code&nbsp;to&nbsp;a&nbsp;PDF&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertHtmlToMemory(htmlCode,&nbsp;baseUrl);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;inform&nbsp;the&nbsp;browser&nbsp;about&nbsp;the&nbsp;binary&nbsp;data&nbsp;format</span>&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Type&quot;</span>,&nbsp;<span class="cs__string">&quot;application/pdf&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;let&nbsp;the&nbsp;browser&nbsp;know&nbsp;how&nbsp;to&nbsp;open&nbsp;the&nbsp;PDF&nbsp;document,&nbsp;attachment&nbsp;or&nbsp;inline,&nbsp;and&nbsp;the&nbsp;file&nbsp;name</span>&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;String.Format(<span class="cs__string">&quot;{0};&nbsp;filename=HtmlToPdf.pdf;&nbsp;size={1}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;checkBoxOpenInline.Checked&nbsp;?&nbsp;<span class="cs__string">&quot;inline&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;attachment&quot;</span>,&nbsp;pdfBuffer.Length.ToString()));&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;write&nbsp;the&nbsp;PDF&nbsp;buffer&nbsp;to&nbsp;HTTP&nbsp;response</span>&nbsp;
HttpContext.Current.Response.BinaryWrite(pdfBuffer);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;call&nbsp;End()&nbsp;method&nbsp;of&nbsp;HTTP&nbsp;response&nbsp;to&nbsp;stop&nbsp;ASP.NET&nbsp;page&nbsp;processing</span>&nbsp;
HttpContext.Current.Response.End();</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ConvertHtmlToPdf.aspx.cs<em> - </em>contains sample code for the most important features of the HiQPdf HTML to PDF Converter
</li><li>ConvertHtmlToImage.aspx.cs<em><em> - </em></em>contains sample code for converting HTML to raster images (JPEG, PNG, BMP)
</li><li>ConvertHtmlToSvg.aspx.cs - contains sample code for converting HTML to SVG vector images
</li></ul>
<h1>More Information</h1>
<p>For more details see&nbsp;a complete list of the <a href="http://www.hiqpdf.com/html-to-pdf-library.aspx">
HiQPdf HTML to PDF Features</a>&nbsp;and the <a href="http://www.hiqpdf.com/documentation/index.aspx">
Online HTML to PDF Converter Documentation</a>&nbsp;&nbsp;</p>
