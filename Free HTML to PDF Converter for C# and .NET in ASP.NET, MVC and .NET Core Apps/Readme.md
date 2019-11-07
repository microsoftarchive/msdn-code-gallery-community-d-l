# Free HTML to PDF Converter for C# and .NET in ASP.NET, MVC and .NET Core Apps
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Windows Forms
- WPF
- Microsoft Azure
- ASP.NET MVC
- .NET Framework
## Topics
- Convert
- HTML to PDF
- Html To Pdf Conversion
## Updated
- 06/30/2018
## Description

<p>The <a title="Free HTML to PDF Converter for .NET from HiQPdf Software" href="http://www.hiqpdf.com/free-html-to-pdf-converter.aspx">
Free HTML to PDF Converter for .NET from HiQPdf Software</a> is a fast method to easily create richly-formatted PDF documents directly from HTML pages or HTML strings. The majority of the websites are already able to produce reports or to present various results
 in HTML pages but while the HTML content is simple to generate, edit and display it is not suitable for printing or for transmission by email. The Free HTML to PDF Converter for .NET can accurately convert HTML pages to PDF documents in your ASP.NET websites
 and .NET desktop applications.</p>
<p>Free HTML to PDF Converter Library for .NET is the limited free version of the fully featured
<a title="HiQPdf HTML to PDF Library for .NET" href="http://www.hiqpdf.com/">HiQPdf HTML to PDF Library for .NET</a> from HiQPdf Software. With Free HTML to PDF Converter Library for .NET you can create maximum 3 PDF pages of high quality content for free.</p>
<p>If you want to create larger unlimited PDF documents or you if you need advanced features like live URLs, internal links, outlines, table of contents, headers and footers, PDF forms, edit, merge and split PDF documents, extract text and images from PDF or
 PDF pages rasterization you can use the full version of the software.</p>
<h1><span>HTML to PDF in ASP.NET C# Code Example</span></h1>
<p>The sample is an ASP.NET website in C# offering sample code for the most important features of the free version of the software. To build the sample you have to open the Visual Studio solution and build the project. All the necessary files are referenced
 from<a href="https://www.nuget.org/packages/hiqpdf.free/"> Free HTML to PDF PDF NuGet package</a> and will be automatically copied from there. After build you can run the demo application in a browser. The sample for the fully featured version of the software
 is available online at <a title="Fully Featured HTML to PDF Demo" href="http://www.hiqpdf.com/demo/ConvertHtmlToPdf.aspx">
HiQPdf HTML to PDF Demo</a> .</p>
<p>This sample shows how easy you can create the PDF documents from existing HTML pages or HTML strings. The HTML page containing HTML5 code, CSS3, JavaScript or SVG. With just a few lines of code you can get richly formatted PDF document.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">protected void buttonConvertToPdf_Click(object sender, EventArgs e)
{
    // create the HTML to PDF converter
    HtmlToPdf htmlToPdfConverter = new HtmlToPdf();

    // set browser width
    htmlToPdfConverter.BrowserWidth = int.Parse(textBoxBrowserWidth.Text);

    // set browser height if specified, otherwise use the default
    if (textBoxBrowserHeight.Text.Length &gt; 0)
        htmlToPdfConverter.BrowserHeight = int.Parse(textBoxBrowserHeight.Text);

    // set HTML Load timeout
    htmlToPdfConverter.HtmlLoadedTimeout = int.Parse(textBoxLoadHtmlTimeout.Text);

    // set PDF page size and orientation
    htmlToPdfConverter.Document.PageSize = GetSelectedPageSize();
    htmlToPdfConverter.Document.PageOrientation = GetSelectedPageOrientation();

    // set PDF page margins
    htmlToPdfConverter.Document.Margins = new PdfMargins(0);

    // set a wait time before starting the conversion
    htmlToPdfConverter.WaitBeforeConvert = int.Parse(textBoxWaitTime.Text);

    // convert HTML to PDF
    byte[] pdfBuffer = null;

    if (radioButtonConvertUrl.Checked)
    {
        // convert URL to a PDF memory buffer
        string url = textBoxUrl.Text;

        pdfBuffer = htmlToPdfConverter.ConvertUrlToMemory(url);
    }
    else
    {
        // convert HTML code
        string htmlCode = textBoxHtmlCode.Text;
        string baseUrl = textBoxBaseUrl.Text;

        // convert HTML code to a PDF memory buffer
        pdfBuffer = htmlToPdfConverter.ConvertHtmlToMemory(htmlCode, baseUrl);
    }

    // inform the browser about the binary data format
    HttpContext.Current.Response.AddHeader(&quot;Content-Type&quot;, &quot;application/pdf&quot;);

    // let the browser know how to open the PDF document, attachment or inline, and the file name
    HttpContext.Current.Response.AddHeader(&quot;Content-Disposition&quot;, String.Format(&quot;{0}; filename=HtmlToPdf.pdf; size={1}&quot;,
        checkBoxOpenInline.Checked ? &quot;inline&quot; : &quot;attachment&quot;, pdfBuffer.Length.ToString()));

    // write the PDF buffer to HTTP response
    HttpContext.Current.Response.BinaryWrite(pdfBuffer);

    // call End() method of HTTP response to stop ASP.NET page processing
    HttpContext.Current.Response.End();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;buttonConvertToPdf_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;create&nbsp;the&nbsp;HTML&nbsp;to&nbsp;PDF&nbsp;converter</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HtmlToPdf&nbsp;htmlToPdfConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToPdf();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;width</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.BrowserWidth&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserWidth.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;height&nbsp;if&nbsp;specified,&nbsp;otherwise&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(textBoxBrowserHeight.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.BrowserHeight&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserHeight.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;HTML&nbsp;Load&nbsp;timeout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.HtmlLoadedTimeout&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxLoadHtmlTimeout.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;PDF&nbsp;page&nbsp;size&nbsp;and&nbsp;orientation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.Document.PageSize&nbsp;=&nbsp;GetSelectedPageSize();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.Document.PageOrientation&nbsp;=&nbsp;GetSelectedPageOrientation();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;PDF&nbsp;page&nbsp;margins</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.Document.Margins&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfMargins(<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;set&nbsp;a&nbsp;wait&nbsp;time&nbsp;before&nbsp;starting&nbsp;the&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToPdfConverter.WaitBeforeConvert&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxWaitTime.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;to&nbsp;PDF</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;pdfBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(radioButtonConvertUrl.Checked)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;URL&nbsp;to&nbsp;a&nbsp;PDF&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;textBoxUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertUrlToMemory(url);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlCode&nbsp;=&nbsp;textBoxHtmlCode.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseUrl&nbsp;=&nbsp;textBoxBaseUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code&nbsp;to&nbsp;a&nbsp;PDF&nbsp;memory&nbsp;buffer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfBuffer&nbsp;=&nbsp;htmlToPdfConverter.ConvertHtmlToMemory(htmlCode,&nbsp;baseUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;inform&nbsp;the&nbsp;browser&nbsp;about&nbsp;the&nbsp;binary&nbsp;data&nbsp;format</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Type&quot;</span>,&nbsp;<span class="cs__string">&quot;application/pdf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;let&nbsp;the&nbsp;browser&nbsp;know&nbsp;how&nbsp;to&nbsp;open&nbsp;the&nbsp;PDF&nbsp;document,&nbsp;attachment&nbsp;or&nbsp;inline,&nbsp;and&nbsp;the&nbsp;file&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;String.Format(<span class="cs__string">&quot;{0};&nbsp;filename=HtmlToPdf.pdf;&nbsp;size={1}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;checkBoxOpenInline.Checked&nbsp;?&nbsp;<span class="cs__string">&quot;inline&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;attachment&quot;</span>,&nbsp;pdfBuffer.Length.ToString()));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;write&nbsp;the&nbsp;PDF&nbsp;buffer&nbsp;to&nbsp;HTTP&nbsp;response</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.BinaryWrite(pdfBuffer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;call&nbsp;End()&nbsp;method&nbsp;of&nbsp;HTTP&nbsp;response&nbsp;to&nbsp;stop&nbsp;ASP.NET&nbsp;page&nbsp;processing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpContext.Current.Response.End();&nbsp;
}</pre>
</div>
</div>
</div>
<h1>Free HTML to PDF Converter for .NET Features</h1>
<ul>
<li>Convert HTML and HTML5 Documents and Web Pages to PDF </li><li>Convert URLs and HTML Strings to PDF Files or Memory Buffers </li><li>Set the PDF Page Size and Orientation </li><li>Fit HTML Content in PDF Page Size </li><li>Advanced Support for Web Fonts in .WOFF and .TTF Formats </li><li>Advanced Support for Scalar Vector Graphics (SVG) </li><li>Advanced Support for HTML5 and CSS3 </li><li>Delayed Conversion Triggering Mode </li><li>Control PDF page breaks with page-break CSS attributes in HTML </li><li>Repeat HTML Table Header and Footer on Each PDF Page </li><li>Packaged and Delivered as a Zip Archive </li><li>No External Dependencies </li><li>Direct Copy Deployment Supported </li><li>ASP.NET and Windows Forms Samples, Complete Documentation </li><li>Supported on All Windows Versions </li><li>Create for Free Maximum 3 Pages of High Quality PDF Content </li></ul>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Default.aspx.cs<em>&nbsp;-&nbsp;</em>contains sample code for the most important features of the HiQPdf HTML to PDF Converter
</li></ul>
<h1>More Information</h1>
<p>For more HTML to PDF Conversion features see&nbsp;the&nbsp;<a href="http://www.hiqpdf.com/html-to-pdf-library.aspx">Full Version of HiQPdf HTML to PDF Converter for .NET</a>&nbsp;and the&nbsp;<a href="http://www.hiqpdf.com/documentation/index.aspx">Online
 HTML to PDF Converter Documentation</a>&nbsp;&nbsp;</p>
