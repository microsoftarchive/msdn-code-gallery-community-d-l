# Easy Steps to URL Rewriting in Asp.Net 4.0
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web Forms
## Topics
- Url Rewriting
## Updated
- 08/25/2011
## Description

<h1>Introduction</h1>
<p><em>This sample will show you how to rewrite the urls to remove the .aspx extension.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Change your urls from&nbsp;</em></p>
<p><em><a href="http://localhost/SampleSite/Products.aspx?category=12">http://localhost/SampleSite/Products.aspx?category=12</a></em></p>
<p><em>to SEO friendly url</em></p>
<p><em><a href="http://localhost/SampleSite/Products/Accessories">http://localhost/SampleSite/Products/Accessories</a><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Using the new Asp.net 4.0 features its easy to achieve the URL rewriting.&nbsp;URL is the important part that search engines want to take a look before they crawl the pages of your website. There are enormous open source libraries and ISAPI filter available
 that provides support to help you rewriting your URLs. Here is the easy of achieving this. See the code in the sample file. For more information go to the www.cshandler.com/label/Asp.net for more details.</em></p>
<p><em>&quot;<em>Using the new Asp.net 4.0 features its easy to achieve the URL rewriting.&nbsp;URL is the important part that search engines want to take a look before they crawl the pages of your website. There are enormous open source libraries and ISAPI filter
 available that provides support to help you rewriting your URLs. Here is the easy of achieving this. See the code in the sample file. For more information go to the www.cshandler.com/label/Asp.net for more details.</em>&quot;</em></p>
<p><em><em>Using the new Asp.net 4.0 features its easy to achieve the URL rewriting.&nbsp;URL is the important part that search engines want to take a look before they crawl the pages of your website. There are enormous open source libraries and ISAPI filter
 available that provides support to help you rewriting your URLs. Here is the easy of achieving this. See the code in the sample file. For more information go to the www.cshandler.com/label/Asp.net for more details.</em><br>
</em></p>
<p><em>You can include <em><strong>code snippets,&nbsp;</strong></em><strong>images</strong>,
<strong>videos</strong>. &nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Code&nbsp;that&nbsp;runs&nbsp;on&nbsp;application&nbsp;startup</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RegisterRoute(<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Routing.RouteTable.Routes.aspx" target="_blank" title="Auto generated link to System.Web.Routing.RouteTable.Routes">System.Web.Routing.RouteTable.Routes</a>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterRoute(System.Web.Routing.RouteCollection&nbsp;routes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routes.Add(<span class="cs__string">&quot;Products&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Routing.Route.aspx" target="_blank" title="Auto generated link to System.Web.Routing.Route">System.Web.Routing.Route</a>(<span class="cs__string">&quot;Products/{category}&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CategoryRouteHandler()));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - URL Rewrite SampleSite Source.zip</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
