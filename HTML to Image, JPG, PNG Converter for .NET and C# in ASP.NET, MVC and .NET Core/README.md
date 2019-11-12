# HTML to Image, JPG, PNG Converter for .NET and C# in ASP.NET, MVC and .NET Core
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
- ASP.NET Web Forms
- HTML to Image Converter
- HTML to Jpeg Converter
- HTML to PNG Converter
- HTML to BMP Converter
## Topics
- HTML to Image Conversion
- HTML to PNG Conversion
- HTML to JPG Conversion
- HTML to JPEG Conversion
- HTML to TIFF Conversion
## Updated
- 06/30/2018
## Description

<p>This sample project shows you how to integrate a HTML to Image Converter Library for .NET in your application to convert HTML documents, web pages and HTML code to various image formats.&nbsp;</p>
<p>The <a href="http://www.hiqpdf.com">HTML to Image Converter for .NET</a> allows you quickly take screenshots of your HTML documents and web pages. It can be easily integrated into any .NET application, either ASP.NET and MVC web applications or Windows Forms
 and WPF desktop applications to convert HTML to JPG, PNG, BMP or to TIFF.</p>
<p>When you convert to PNG you also have the option to create an image with transparent background. You can see a
<a href="http://www.hiqpdf.com/demo/ConvertHtmlToImage.aspx">HTML to Image for .NET live demo</a> where you can see all the converter settings at work.</p>
<h1><span>Building and Running the Sample</span></h1>
<p>To build the sample you have to open the Visual Studio solution and build the project. All the necessary files are referenced from NuGet and will be automatically copied from there. After build you can run the demo application in a browser.</p>
<p>The HTML to Image Converter is part of the HiQPdf HTML to PDF Converter Library for .NET and the project contains sample code for both usage scenarios.</p>
<p>&nbsp;</p>
<h1><em>HTML to Image Converter for .NET Features</em></h1>
<ul>
<li>Convert any HTML5 document or web pages to images </li><li>Convert HTML to JPEG, PNG, BMP or TIFF output formats </li><li>Option to create transparent PNG images </li><li>Easy to integrate in any .NET application </li><li>Fast response and very accurate output images </li><li>Options to select the output image width and height </li><li>Full support for JavaScript, CSS3, SVG and Web Fonts </li><li>Zero external dependencies </li></ul>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">C# Code Sample for ASP.NET to Convert HTML to Images</span></p>
<p>The minimal C# code to convert HTML to various image formats in ASP.NET will create a
<em>HtmlToImage </em>object and then it will call the <em>ConvertUrlToImage </em>
method to convert a HTML page from a given URL to image or will call the <em>ConvertHtmlToImage
</em>to convert a HTML code from a string to an image. The <em>ConvertHtmlToImage
</em>method also requires a base URL parameter to resolve the relative links to images and other files. The result of conversion is a
<em><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Image.aspx" target="_blank" title="Auto generated link to System.Drawing.Image">System.Drawing.Image</a></em> object which is saved to a memory buffer in one of the image formats supported by the .NET framework and then sent to browser for download.&nbsp; &nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;create&nbsp;the&nbsp;HTML&nbsp;to&nbsp;Image&nbsp;converter</span>&nbsp;
HtmlToImage&nbsp;htmlToImageConverter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToImage();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;width</span>&nbsp;
htmlToImageConverter.BrowserWidth&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserWidth.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;browser&nbsp;height&nbsp;if&nbsp;specified,&nbsp;otherwise&nbsp;use&nbsp;the&nbsp;default</span>&nbsp;
<span class="cs__keyword">if</span>&nbsp;(textBoxBrowserHeight.Text.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlToImageConverter.BrowserHeight&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxBrowserHeight.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;HTML&nbsp;Load&nbsp;timeout</span>&nbsp;
htmlToImageConverter.HtmlLoadedTimeout&nbsp;=&nbsp;<span class="cs__keyword">int</span>.Parse(textBoxLoadHtmlTimeout.Text);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;set&nbsp;whether&nbsp;the&nbsp;resulted&nbsp;image&nbsp;is&nbsp;transparent&nbsp;(has&nbsp;effect&nbsp;only&nbsp;when&nbsp;the&nbsp;output&nbsp;format&nbsp;is&nbsp;PNG)</span>&nbsp;
htmlToImageConverter.TransparentImage&nbsp;=&nbsp;(dropDownListImageFormat.SelectedValue&nbsp;==&nbsp;<span class="cs__string">&quot;PNG&quot;</span>)&nbsp;?&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;checkBoxTransparentImage.Checked&nbsp;:&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;convert&nbsp;to&nbsp;image</span>&nbsp;
System.Drawing.Image&nbsp;imageObject&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;imageFormatName&nbsp;=&nbsp;dropDownListImageFormat.SelectedValue.ToLower();&nbsp;
<span class="cs__keyword">string</span>&nbsp;imageFileName&nbsp;=&nbsp;String.Format(<span class="cs__string">&quot;HtmlToImage.{0}&quot;</span>,&nbsp;imageFormatName);&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(radioButtonConvertUrl.Checked)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;URL</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;textBoxUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imageObject&nbsp;=&nbsp;htmlToImageConverter.ConvertUrlToImage(url)[<span class="cs__number">0</span>];&nbsp;
}&nbsp;
<span class="cs__keyword">else</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;convert&nbsp;HTML&nbsp;code</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;htmlCode&nbsp;=&nbsp;textBoxHtmlCode.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;baseUrl&nbsp;=&nbsp;textBoxBaseUrl.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imageObject&nbsp;=&nbsp;htmlToImageConverter.ConvertHtmlToImage(htmlCode,&nbsp;baseUrl)[<span class="cs__number">0</span>];&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;get&nbsp;the&nbsp;image&nbsp;buffer&nbsp;in&nbsp;the&nbsp;selected&nbsp;image&nbsp;format</span>&nbsp;
<span class="cs__keyword">byte</span>[]&nbsp;imageBuffer&nbsp;=&nbsp;GetImageBuffer(imageObject);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;the&nbsp;image&nbsp;object&nbsp;rturned&nbsp;by&nbsp;converter&nbsp;can&nbsp;be&nbsp;disposed</span>&nbsp;
imageObject.Dispose();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;inform&nbsp;the&nbsp;browser&nbsp;about&nbsp;the&nbsp;binary&nbsp;data&nbsp;format</span>&nbsp;
<span class="cs__keyword">string</span>&nbsp;mimeType&nbsp;=&nbsp;imageFormatName&nbsp;==&nbsp;<span class="cs__string">&quot;jpg&quot;</span>&nbsp;?&nbsp;<span class="cs__string">&quot;jpeg&quot;</span>&nbsp;:&nbsp;imageFormatName;&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Type&quot;</span>,&nbsp;<span class="cs__string">&quot;image/&quot;</span>&nbsp;&#43;&nbsp;mimeType);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;let&nbsp;the&nbsp;browser&nbsp;know&nbsp;how&nbsp;to&nbsp;open&nbsp;the&nbsp;image&nbsp;and&nbsp;the&nbsp;image&nbsp;name</span>&nbsp;
HttpContext.Current.Response.AddHeader(<span class="cs__string">&quot;Content-Disposition&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String.Format(<span class="cs__string">&quot;attachment;&nbsp;filename={0};&nbsp;size={1}&quot;</span>,&nbsp;imageFileName,&nbsp;imageBuffer.Length.ToString()));&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;write&nbsp;the&nbsp;image&nbsp;buffer&nbsp;to&nbsp;HTTP&nbsp;response</span>&nbsp;
HttpContext.Current.Response.BinaryWrite(imageBuffer);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;call&nbsp;End()&nbsp;method&nbsp;of&nbsp;HTTP&nbsp;response&nbsp;to&nbsp;stop&nbsp;ASP.NET&nbsp;page&nbsp;processing</span>&nbsp;
HttpContext.Current.Response.End();Click&nbsp;here&nbsp;to&nbsp;add&nbsp;your&nbsp;code&nbsp;snippet.</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ConvertHtmlToImage.aspx.cs - </em>contains the C# code to convert HTML to Image from where the sample code above was copied
</li></ul>
<h1>More Information</h1>
<p>You can <a href="http://www.hiqpdf.com">download the HTML to Image .NET library</a> from software website. You can read more about the HTML to Image and HTML to PDF converter software on
<a href="https://hiqpdf-html-to-pdf.com/">HiQPdf HTML to PDF for .NET Blog</a> page.</p>
