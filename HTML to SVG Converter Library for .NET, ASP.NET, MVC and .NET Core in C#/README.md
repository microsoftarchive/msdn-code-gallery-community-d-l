# HTML to SVG Converter Library for .NET, ASP.NET, MVC and .NET Core in C#
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- Windows Forms
- WPF
- ASP.NET MVC
- .NET Development
## Topics
- HTML to SVG Converter
## Updated
- 06/30/2018
## Description

<p>This example project for Visual Studio shows you how to use a HTML to SVG Converter for .NET in an ASP.NET application to convert HTML documents to SVG vector images.&nbsp;</p>
<p>The <a href="http://www.hiqpdf.com">HTML to SVG Converter for .NET</a> allows you quickly save your HTML documents and web pages to Scalable Vector Images (SVG). The great advanatge of SVG documents compared to raster images like JPEG, PNG or BMP is that
 the vector images keep their quality when you zoom in document. You can run a <a href="http://www.hiqpdf.com/demo/ConvertHtmlToSvg.aspx">
HTML to SVG &nbsp;Converter for .NET online demo</a> where to test the converter feature.</p>
<h1><span>Building and Running the HTML to SVG Project</span></h1>
<p>To build the HTML to SVG project you have to open the Visual Studio solution and build the project. The HTML to SVG Converter is part of the HiQPdf HTML to PDF Converter Library for .NET and the project contains sample code for both usage scenarios.</p>
<p>The <a href="https://www.nuget.org/packages/hiqpdf/">HTML to SVG NuGet Package</a> is refeenced in project and will be automatically downloaded from there. After build you can run the demo application in a browser.</p>
<h1><em>HTML to SVG Converter for .NET Features</em></h1>
<ul>
<li>Convert any HTML5 document or web pages to SVG vector images </li><li>Easy to integrate in any .NET application </li><li>Fast response and very accurate output images </li><li>Options to select the output image width and height </li><li>Full support for JavaScript, CSS3, SVG and Web Fonts </li><li>Zero external dependencies </li></ul>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">C# Code Sample for ASP.NET to Convert HTML to SVG</span></p>
<p>The C# code to convert HTML to SVG in ASP.NET will create a <em>HtmlToSvg&nbsp;</em>object and then it will call the
<em>ConvertUrlToMemory&nbsp;</em>method to convert a HTML page from a given URL to SVG or will call the
<em>ConvertHtmlToMemory&nbsp;</em>to convert a HTML code from a string to an image. The
<em>ConvertHtmlToMemory&nbsp;</em>method also requires a base URL parameter to resolve the relative links to images and other files. The result of conversion is a memory buffer contiaining the SVG document whihc can be sent to browser for download.&nbsp; &nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;create&nbsp;the&nbsp;HTML&nbsp;to&nbsp;SVG&nbsp;converter</span>&nbsp;
HtmlToSvg&nbsp;htmlToSvgConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToSvg();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;width</span>&nbsp;
htmlToSvgConverter.BrowserWidth&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserWidth.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;height&nbsp;if&nbsp;specified,&nbsp;otherwise&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(textBoxBrowserHeight.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToSvgConverter.BrowserHeight&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserHeight.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;HTML&nbsp;Load&nbsp;timeout</span>&nbsp;
htmlToSvgConverter.HtmlLoadedTimeout&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxLoadHtmlTimeout.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;convert&nbsp;to&nbsp;SVG</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;svgFileName&nbsp;=&nbsp;<span class="cs__string">&quot;HtmlToSvg.svg&quot;</span>;&nbsp;
<span class="cs__keyword">byte</span>[]&nbsp;svgBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(radioButtonConvertUrl.Checked)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;URL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;textBoxUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;svgBuffer&nbsp;=&nbsp;htmlToSvgConverter.ConvertUrlToMemory(url);&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlCode&nbsp;=&nbsp;textBoxHtmlCode.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseUrl&nbsp;=&nbsp;textBoxBaseUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;svgBuffer&nbsp;=&nbsp;htmlToSvgConverter.ConvertHtmlToMemory(htmlCode,&nbsp;baseUrl);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;inform&nbsp;the&nbsp;browser&nbsp;about&nbsp;the&nbsp;data&nbsp;format</span>&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Type&quot;</span>,&nbsp;<span class="cs__string">&quot;image/svg&#43;xml&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;let&nbsp;the&nbsp;browser&nbsp;know&nbsp;how&nbsp;to&nbsp;open&nbsp;the&nbsp;SVG&nbsp;and&nbsp;the&nbsp;SVG&nbsp;file&nbsp;name</span>&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format(<span class="cs__string">&quot;attachment;&nbsp;filename={0};&nbsp;size={1}&quot;</span>,&nbsp;svgFileName,&nbsp;svgBuffer.Length.ToString()));&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;write&nbsp;the&nbsp;SVG&nbsp;buffer&nbsp;to&nbsp;HTTP&nbsp;response</span>&nbsp;
HttpContext.Current.Response.BinaryWrite(svgBuffer);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;call&nbsp;End()&nbsp;method&nbsp;of&nbsp;HTTP&nbsp;response&nbsp;to&nbsp;stop&nbsp;ASP.NET&nbsp;page&nbsp;processing</span>&nbsp;
HttpContext.Current.Response.End();</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ConvertHtmlToSvg.aspx.cs - </em>contains the C# code to convert HTML to SVG from where the sample code above was copied
</li></ul>
<h1>More Information</h1>
<p>You can <a href="http://www.hiqpdf.com">download the HTML to SVG .NET library</a> from software website. You can read more about the HTML to SVG and HTML to PDF converter software on
<a href="https://hiqpdf-html-to-pdf.com/">HiQPdf HTML to PDF for .NET Blog</a> page.</p>
