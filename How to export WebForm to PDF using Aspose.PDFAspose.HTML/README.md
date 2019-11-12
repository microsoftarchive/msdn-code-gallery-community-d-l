# How to export WebForm to PDF using Aspose.PDF/Aspose.HTML
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- ASP.NET
## Topics
- C#
- ASP.NET
- Export Gridview to Pdf
## Updated
- 06/22/2018
## Description

<h1>Introduction</h1>
<p><em>Generally, to convert WebForm to PDF document uses additional tools. This sample shows how to use Aspose.PDF or Aspose.HTML library to render WebForm to PDF. The&nbsp;Aspose Export GridView To Pdf Control is also included in this sample to show how to
 render&nbsp;<em>GridView control to PDF document.</em></em></p>
<h1>How to render WebForm to PDF</h1>
<p><em>The original idea for render WebForm to PDF is to create helper class, which inherited from <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.UI.Page.aspx" target="_blank" title="Auto generated link to System.Web.UI.Page">System.Web.UI.Page</a>, and overriding a Render method.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Render(HtmlTextWriter&nbsp;writer)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(RenderToPDF)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;render&nbsp;web&nbsp;page&nbsp;for&nbsp;PDF&nbsp;document&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;render&nbsp;web&nbsp;page&nbsp;in&nbsp;browser</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.Render(writer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>There are two Aspose tools can be used for render HTML to PDF: <a href="https://products.aspose.com/pdf/net">
Aspose.PDF for .NET</a> and <a href="https://products.aspose.com/html/net">Aspose.HTML for .NET</a>. The first library is designed for manipulating with PDF documents, and the second one - for manipulating with HTML documents, but both can be used for conversion
 HTML to PDF.</p>
<h1>Source Files</h1>
<p>In this sample we have 3 demo reports.</p>
<ul>
<li>Default.aspx demonstrate export to PDF using&nbsp;<em>Aspose.HTML</em> </li><li><em>Report2.aspx d</em>emonstrate export to PDF using&nbsp;<em>Aspose.PDF</em>
</li><li><em>Report3.aspx&nbsp;</em><em>d</em>emonstrate export to PDF using&nbsp;<em>Aspose Export GridView control (based on Aspose.PDF)</em>
</li></ul>
<p>Additional files:</p>
<ul>
<li><em>Helpers\HtmlPage.cs - contains a helper class, which shows how to use Aspose.HTML API.</em>
</li><li><em>Helpers\PdfPage.cs - contains a helper class, which shows how to use Aspose.HTML API.</em>
</li></ul>
<p>The&nbsp;Aspose.Pdf.GridViewExport project contains extened GridView control for demonstration in&nbsp;<em>Report3.aspx&nbsp;</em></p>
<h1>More Information</h1>
<ul>
<li>Website:&nbsp;<a rel="nofollow" href="http://www.aspose.com/">www.aspose.com</a>
</li><li>Product Home:&nbsp;<a rel="nofollow" href="https://products.aspose.com/pdf/net">Aspose.Pdf for .NET</a>
</li><li>Download:&nbsp;<a rel="nofollow" href="https://www.nuget.org/packages/Aspose.Pdf/">Download Aspose.Pdf for .NET</a>
</li><li>Documentation:&nbsp;<a rel="nofollow" href="https://docs.aspose.com/display/pdfnet/Home">Aspose.Pdf for .NET Documentation</a>
</li><li>Blog:&nbsp;<a rel="nofollow" href="https://blog.aspose.com/category/aspose-products/aspose-pdf-product-family/">Aspose.Pdf for .NET Blog</a>
</li><li>Telegram channel: <a href="https://t.me/asposepdf">Aspose-PDF</a> </li></ul>
