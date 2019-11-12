# Extract images from web address like Facebook using ASP.NET  and jQuery
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- ASP.NET MVC
- jQuery
- Web Services
- Javascript
- ASP.NET Web Forms
- HTML
- ASP.NET Web API
## Topics
- parsing
- Image
- Load Image
- web scraping
## Updated
- 06/11/2014
## Description

<h1>Introduction</h1>
<p>In this sample I am going to show you how to build a similar functionality that used in
<strong>Facebook </strong>,<strong>Google Plus</strong> and <strong>Linkedin</strong>, this functionality or technique called
<a href="http://en.wikipedia.org/wiki/Web_scraping">web scraping.</a> Web scraping allow you to extract the information that you want&nbsp; from Url itself, this information could be images,texts and even CSS.See the following demo.</p>
<p><img id="115331" src="115331-untitled.gif" alt="" width="802" height="443"></p>
<h1><span>Building the Sample</span></h1>
<p><strong>You need a<em><a id="ProjectTitle1" href="http://htmlagilitypack.codeplex.com/"> Html Agility Pack</a></em> To build a sample successfully, you can find the pack through
<em>Nuget</em>.</strong><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>after digging a little with facebook i realized that facebook depend on <a href="http://ogp.me/">
open graph protocol </a>to check the metadata like og:image ,so if the site contain og:image tag facebook will show you the image immediately from &lt;og:image../&gt; otherwise it will show you set of images (&lt;img .../&gt;) to select one of them</p>
<p>In this samplen I tried to follow the same approach by checking the response data and see if og:image exist or not. Thanks to&nbsp; HTML Agility Pack.</p>
<p>In this sample I used using ASP.NET(webform,MVC), ASP.NET Web APi ,jQuery and HTML Agility Pack.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;HttpWebRequest&nbsp;request&nbsp;=&nbsp;HttpWebRequest.Create(<span class="cs__keyword">value</span>)&nbsp;<span class="cs__keyword">as</span>&nbsp;HttpWebRequest;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpWebResponse&nbsp;response&nbsp;=&nbsp;request.GetResponse()&nbsp;<span class="cs__keyword">as</span>&nbsp;HttpWebResponse;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ResponseStream&nbsp;=&nbsp;response.GetResponseStream();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HtmlDocument&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.Load(ResponseStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;imgSrc&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ogMeta&nbsp;=&nbsp;document.DocumentNode.SelectNodes(<span class="cs__string">&quot;//meta[@property]&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;if&nbsp;contain&nbsp;Open&nbsp;graph&nbsp;element</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ogMeta&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ogImage&nbsp;=&nbsp;document.DocumentNode.SelectNodes(<span class="cs__string">&quot;//meta[@property]&quot;</span>).Where(x&nbsp;=&gt;&nbsp;x.Attributes[<span class="cs__string">&quot;property&quot;</span>].Value&nbsp;==&nbsp;<span class="cs__string">&quot;og:image&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ogImage.Count()&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;<span class="cs__com">//check&nbsp;og:image&nbsp;found</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Concat(<span class="cs__string">&quot;&lt;li&gt;&nbsp;&lt;img&nbsp;src=&quot;</span>,&nbsp;ogImage.FirstOrDefault().Attributes[<span class="cs__string">&quot;content&quot;</span>].Value,&nbsp;<span class="cs__string">&quot;&nbsp;/&gt;&lt;/li&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;<span class="cs__com">//return&nbsp;some&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetImages(document.DocumentNode.SelectNodes(<span class="cs__string">&quot;//img&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;GetImages(document.DocumentNode.SelectNodes(<span class="cs__string">&quot;//img&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;GetImages(HtmlNodeCollection&nbsp;DOM)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;Images&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(DOM&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;img&nbsp;<span class="cs__keyword">in</span>&nbsp;DOM)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Images.AppendFormat(<span class="cs__string">&quot;&lt;li&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Images.AppendFormat(img.OuterHtml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Images.AppendFormat(<span class="cs__string">&quot;&lt;/li&gt;&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Images.ToString();</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ScrapeController.cs - ASP.NET Web API. </li><li>Index.aspx - ASP.NET webform page. </li><li>mvcDemo.cshtml - ASP.NET MVC Page. </li><li>Prgressbar : Folder contain progress image ,it will be displayed when loading data.
</li></ul>
<h1>More Information</h1>
<p><em>you are welcome to ask me here In Q &amp; A section</em></p>
