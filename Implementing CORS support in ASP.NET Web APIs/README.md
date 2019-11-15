# Implementing CORS support in ASP.NET Web APIs
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET MVC 4
## Topics
- HTTP
- Web API
- Cross-Domain
## Updated
- 07/01/2012
## Description

<p><em><strong><em>This sample was built with the Beta version of ASP.NET MVC 4. For an updated version (which works with the Release Candidate bits), check the sample at
<a href="http://code.msdn.microsoft.com/CORS-support-in-ASPNET-Web-01e9980a">http://code.msdn.microsoft.com/CORS-support-in-ASPNET-Web-01e9980a</a>.</em></strong></em></p>
<p><em>This sample was introduced in a blog post about <a href="http://blogs.msdn.com/b/carlosfigueira/archive/2012/02/20/implementing-cors-support-in-asp-net-web-apis.aspx">
CORS support in ASP.NET Web APIs</a>. To run the sample, set both projects in the solution as startup projects, then F5. You'll need to use a browser with CORS support and browse to the Mashup project root.</em></p>
<p>By default, a web page cannot make calls to services (APIs) on a domain other than the one where the page came from. This is a security measure against a group of cross-site forgery attacks in which browsing to a bad site could potentially use the browser
 cookies to get data from a good site which the user had previously logged on (think your bank). There are many situations, however, where getting data from different sites is a perfectly valid scenario, such as mash-up applications which need data from different
 sources.</p>
<p>There are a few ways to overcome this limitation. <a href="http://en.wikipedia.org/wiki/JSONP">
JSONP</a> (JSON with Padding) uses the fact that &lt;script&gt; tags don&rsquo;t have the cross-domain restriction, and if the server is willing to send the data back differently (i.e.,
<em>padding</em> the JSON response by wrapping it inside a function call), then the client can create a named function, and add a new &lt;script&gt; tag to the page DOM and that function will be called with the result from the service. It&rsquo;s a very simple
 protocol, and has been used successfully in many applications.</p>
<p>The main problem (or limitation) of JSONP is that it only supports GET requests &ndash; &lt;script&gt; tags will cause the browser to issue a HTTP GET request for the script referenced by its &ldquo;src&rdquo; attribute. In situations where other HTTP verbs
 are required, JSONP simply doesn&rsquo;t work. There are some alternatives to this, such as proxying the requests through a service (the cross-domain restrictions are imposed by the XmlHttpRequest object in the browsers, and don&rsquo;t apply to &ldquo;general&rdquo;,
 server-side, code), but they usually introduce a new component in the system which is error-prone.</p>
<p><a href="http://www.w3.org/TR/cors/">CORS</a> (Cross-Origin Resource Sharing) is a new specification which defines a set of headers which can be exchanged between the client and the server which allow the server to relax the cross-domain restrictions for
 all HTTP verbs, not only GET. Also, since CORS is implemented in the same XmlHttpRequest as &ldquo;normal&rdquo; AJAX calls (in Firefox 3.5 and above, Safari 4 and above, Chrome 3 and above, IE 10 and above &ndash; in IE8/9, the code needs to use the XDomainRequest
 object instead), the JavaScript code doesn&rsquo;t need to worry about &ldquo;un-padding&rdquo; responses or adding dummy functions. The error handling is also improved with CORS, since services can use the full range of the HTTP response codes (instead of
 200, which is required by JSONP) and the code also has access to the full response instead of only its body.</p>
<h3>Cross-domain calls in ASP.NET Web APIs</h3>
<p><strong>Note</strong>: If you are completely new to <a href="http://www.asp.net/web-api">
ASP.NET Web API</a> then I recommend that you check out some of the tutorials.</p>
<p>As of its Beta release, there is no native support for cross-domain calls in ASP.NET Web APIs. It&rsquo;s fairly simple, though, to implement those &ndash; the comments sample has a simple JSONP formatter. This post shows one way to implement CORS in a Web
 API project, using a <a href="http://www.asp.net/web-api/overview/working-with-http/http-message-handlers">
message handler</a>. Message handlers can intercept the requests as they go through the pipeline and either modify them as they go through or respond to the request immediately, bypassing the rest of the pipeline, so they make a good candidate for this scenario.</p>
<p>A very quick CORS intro before diving into the code: requests for cross-domain resources have an additional HTTP header, &ldquo;Origin&rdquo;, which identifies the domain where the page was loaded from. If the server supports CORS, it should respond to such
 requests with an additional response header, &ldquo;Access-Control-Allow-Origin&rdquo;. There is also a special request, the
<em>preflight</em> request, which is sent prior to the actual request, which uses the HTTP &ldquo;OPTIONS&rdquo; verb, which asks the server which HTTP methods and request headers it supports in cross-domain requests (using the &ldquo;Access-Control-Request-Method&rdquo;
 and &ldquo;Access-Control-Request-Headers&rdquo; request headers, respectively), and the server must respond with the appropriate headers (&ldquo;Access-Control-Allow-Methods&rdquo; and &ldquo;Access-Control-Allow-Headers&rdquo; response headers, respectively).</p>
<p>Let&rsquo;s start with a new ASP.NET MVC 4 / Web API project (add a solution folder, since we&rsquo;ll add a new project to do the cross-domain calls). In order to get something useful out of the controller from the template, I changed it a little to be
 able to test it, by storing the &ldquo;values&rdquo; in an in memory list.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ValuesController&nbsp;:&nbsp;ApiController&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;allValues&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;{&nbsp;<span class="cs__string">&quot;value1&quot;</span>,&nbsp;<span class="cs__string">&quot;value2&quot;</span>&nbsp;};&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;/api/values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;allValues;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;GET&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;allValues[id];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(HttpStatusCode.NotFound);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;POST&nbsp;/api/values</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HttpResponseMessage&nbsp;Post(<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues.Add(<span class="cs__keyword">value</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessage&lt;<span class="cs__keyword">int</span>&gt;(allValues.Count&nbsp;-&nbsp;<span class="cs__number">1</span>,&nbsp;HttpStatusCode.Created);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;PUT&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Put(<span class="cs__keyword">int</span>&nbsp;id,&nbsp;<span class="cs__keyword">string</span>&nbsp;<span class="cs__keyword">value</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues[id]&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(HttpStatusCode.NotFound);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;DELETE&nbsp;/api/values/5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(id&nbsp;&lt;&nbsp;allValues.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;allValues.RemoveAt(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseException(HttpStatusCode.NotFound);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:11e18aec-99e2-4b7b-b195-e36965847517" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<p>Next, let&rsquo;s add a new project to the solution, and ASP.NET Empty Web Application, and add a NuGet reference to the jQuery project. With that, we can add an HTML page and add some controls to test the controller.</p>
<p><img src="http://i1.code.msdn.s-msft.com/implementing-cors-support-a677ab5d/image/file/49864/1/2772.image_3f533a2c.png" alt="" width="392" height="218"><a href="$image[6].png"></a></p>
<p>With that ready, we can bind the &ldquo;click&rdquo; events from the buttons to make calls to the controller, as shown below (this isn&rsquo;t beautiful code by any means, with a little more time I&rsquo;d have combined many of the functions, but for a quick
 sample, this works)</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;valuesAddress&nbsp;=&nbsp;<span class="js__string">&quot;http://localhost:3227/api/Values&quot;</span>;&nbsp;
$(<span class="js__string">&quot;#getAll&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;valuesAddress,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;text&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;result.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(i&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;text&nbsp;=&nbsp;text&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&nbsp;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;text&nbsp;=&nbsp;text&nbsp;&#43;&nbsp;result[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(text);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(textStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
$(<span class="js__string">&quot;#getOne&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#id&quot;</span>).val();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;valuesAddress&nbsp;&#43;&nbsp;id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;GET&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(textStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
$(<span class="js__string">&quot;#post&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#value&quot;</span>).val()&nbsp;&#43;&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;valuesAddress,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;data,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(textStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
$(<span class="js__string">&quot;#put&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#id&quot;</span>).val();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#value&quot;</span>).val()&nbsp;&#43;&nbsp;<span class="js__string">&quot;\&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;valuesAddress&nbsp;&#43;&nbsp;id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;PUT&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;data,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(textStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
$(<span class="js__string">&quot;#delete&quot;</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;id&nbsp;=&nbsp;<span class="js__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;$(<span class="js__string">&quot;#id&quot;</span>).val();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;valuesAddress&nbsp;&#43;&nbsp;id,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;DELETE&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(result)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(result);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(jqXHR,&nbsp;textStatus,&nbsp;errorThrown)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#result&quot;</span>).text(textStatus);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:259f5c55-b03c-4162-80ee-775b857476bc" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<p>Time to test the page. After setting <em>both projects</em> as the startup projects in the Visual Studio solution, we can F5 and start clicking on the buttons. Oops, nothing works &ndash; they all print the error on the result &lt;div&gt; element.</p>
<p><img src="http://i1.code.msdn.s-msft.com/implementing-cors-support-a677ab5d/image/file/49865/1/3463.image_048b9156.png" alt="" width="351" height="207"><a href="$image[10].png"></a></p>
<p>That&rsquo;s where CORS enters the picture. We need to get the controller to return the appropriate headers, otherwise no cross-domain requests will succeed. Let&rsquo;s add a new message handler to deal with those requests. The code is shown below. If the
 request contain the &ldquo;Origin&rdquo; header, we&rsquo;ll treat it as a CORS request, and after dispatching the message through the pipeline (base.SendAsync), we&rsquo;ll add the &ldquo;Access-Control-Allow-Origin&rdquo; header to let the browser know that
 we&rsquo;re fine with that request.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Task&lt;HttpResponseMessage&gt;&nbsp;SendAsync(HttpRequestMessage&nbsp;request,&nbsp;CancellationToken&nbsp;cancellationToken)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;isCorsRequest&nbsp;=&nbsp;request.Headers.Contains(Origin);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isCorsRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.SendAsync(request,&nbsp;cancellationToken).ContinueWith&lt;HttpResponseMessage&gt;(t&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;resp&nbsp;=&nbsp;t.Result;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resp.Headers.Add(AccessControlAllowOrigin,&nbsp;request.Headers.GetValues(Origin).First());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.SendAsync(request,&nbsp;cancellationToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:c014ccfa-54d7-4b8b-b38f-b4e0c5fbd1d6" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<p>We also must deal with <em>preflight</em> requests (OPTIONS). If this is the case, we don&rsquo;t need to send the message through the pipeline, we can respond to it right away, by creating a response message and returning it at the handler itself.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">bool</span>&nbsp;isPreflightRequest&nbsp;=&nbsp;request.Method&nbsp;==&nbsp;HttpMethod.Options;&nbsp;
<span class="cs__keyword">if</span>&nbsp;(isCorsRequest)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(isPreflightRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Task.Factory.StartNew&lt;HttpResponseMessage&gt;(()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpResponseMessage(HttpStatusCode.OK);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(AccessControlAllowOrigin,&nbsp;request.Headers.GetValues(Origin).First());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;accessControlRequestMethod&nbsp;=&nbsp;request.Headers.GetValues(AccessControlRequestMethod).FirstOrDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(accessControlRequestMethod&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(AccessControlAllowMethods,&nbsp;accessControlRequestMethod);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;requestedHeaders&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Join(<span class="cs__string">&quot;,&nbsp;&quot;</span>,&nbsp;request.Headers.GetValues(AccessControlRequestHeaders));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(requestedHeaders))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Add(AccessControlAllowHeaders,&nbsp;requestedHeaders);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;},&nbsp;cancellationToken);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:5a268f93-d97c-4bf6-95b1-b29eac1833a0" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<p>Finally, we add the CORS handler to the list of message handlers in the global configuration of the application (in global.asax.cs):</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AreaRegistration.RegisterAllAreas();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RegisterGlobalFilters(GlobalFilters.Filters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RegisterRoutes(RouteTable.Routes);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BundleTable.Bundles.RegisterTemplateBundles();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;GlobalConfiguration.Configuration.MessageHandlers.Add(<span class="cs__keyword">new</span>&nbsp;CorsHandler());&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="wlWriterEditableSmartContent" id="scid:9ce6104f-a9aa-4a17-a79f-3a39532ebf7c:bcaf3285-378e-4ca6-a8b6-2b7285a1fd97" style="margin:0px; display:inline; float:none; padding:0px">
</div>
<p>That&rsquo;s it. We can now call in any CORS-capable browser, as shown below.</p>
<p><img src="http://i1.code.msdn.s-msft.com/implementing-cors-support-a677ab5d/image/file/49866/1/3060.image_3d363b63.png" alt="" width="465" height="329"><a href="$image[14].png"></a></p>
<h3>Security considerations</h3>
<p>The cross-domain restrictions in many browsers exist for a reason, so please understand the security implications of enabling such requests with CORS (or JSONP) before doing so in production systems.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
