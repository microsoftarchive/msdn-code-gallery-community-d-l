# Introduction to HttpClient
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- ASP.NET
- .NET Framework
- ASP.NET Web API
- HttpClient
## Topics
- REST
- HTTP
- Web API
## Updated
- 09/01/2012
## Description

<div>
<div><span style="font-size:medium"><strong><span style="background-color:#ffff00">This code is no longer maintained. Please see
<a href="http://blogs.msdn.com/b/webdev/archive/2012/08/26/asp-net-web-api-and-httpclient-samples.aspx">
List of ASP.NET Web API and HttpClient Samples</a> for updated samples.</span></strong></span></div>
<div><span style="font-size:medium"><strong><span style="background-color:#ffff00"><br>
</span></strong></span></div>
</div>
<div></div>
<div>HttpClient is a modern HTTP client for .NET. It provides a flexible and extensible API for accessing all things exposed through HTTP. HttpClient has been available for a while as part of
<a href="http://nuget.org/packages/HttpClient">WCF Web API preview 6</a> but is now shipping as part of
<a href="http://www.asp.net/web-api">ASP.NET Web API</a> and directly in .NET 4.5. You can also download it using
<a href="http://nuget.org/">NuGet</a> &ndash; we just use the following three NuGet packages in this sample:</div>
<ol>
<li><strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Http.aspx" target="_blank" title="Auto generated link to System.Net.Http">System.Net.Http</a></strong>: The main NuGet package providing the basic HttpClient and related classes
</li><li><strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Http.Formatting.aspx" target="_blank" title="Auto generated link to System.Net.Http.Formatting">System.Net.Http.Formatting</a></strong>: Adds support for serialization, deserialization as well as for many additional features building on top of <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Http.aspx" target="_blank" title="Auto generated link to System.Net.Http">System.Net.Http</a>
</li><li><strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Json.aspx" target="_blank" title="Auto generated link to System.Json">System.Json</a></strong>: Adds support for JsonVaue which is a mechanism for reading and manipulating JSON documents
</li></ol>
<div>In case you haven&rsquo;t played with HttpClient before, here is a quick overview of how it works:</div>
<div>HttpClient is the main class for sending and receiving HttpRequestMessages and HttpResponseMessages. If you are used to using WebClient or HttpWebRequest then it is worth noting that HttpClient differs in some interesting ways &ndash; here&rsquo;s how
 to think about an HttpClient:</div>
<ol>
<li>An HttpClient instance is the place to configure extensions, set default headers, cancel outstanding requests and more.
</li><li>You can issue as many requests as you like through a single HttpClient instance.
</li><li>HttpClients are not tied to particular HTTP server or host; you can submit any HTTP request using the same HttpClient instance.
</li><li>You can derive from HttpClient to create specialized clients for particular sites or patterns
</li><li>HttpClient uses the new Task-oriented pattern for handling asynchronous requests making it dramatically easier to manage and coordinate multiple outstanding requests.
</li></ol>
<h1>Kicking the Tires</h1>
<div>We will be diving into lots of details in the near-future around features, extensibility, serialization, and more but let&rsquo;s first kick the tires by sending a request to the
<a href="http://data.worldbank.org/">World Bank Data Web API</a>. The service provides all kinds of information about countries around the world. It exposes the data both as XML and as JSON but in this sample we download it as JSON and use JsonValue to traverse
 the request for interesting information without having to create a CLR type on the client side:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Create&nbsp;an&nbsp;HttpClient&nbsp;instance</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpClient&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Send&nbsp;a&nbsp;request&nbsp;asynchronously&nbsp;continue&nbsp;when&nbsp;complete</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.GetAsync(_address).ContinueWith(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(requestTask)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Get&nbsp;HTTP&nbsp;response&nbsp;from&nbsp;completed&nbsp;task.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;requestTask.Result;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;that&nbsp;response&nbsp;was&nbsp;successful&nbsp;or&nbsp;throw&nbsp;exception</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.EnsureSuccessStatusCode();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Read&nbsp;response&nbsp;asynchronously&nbsp;as&nbsp;JsonValue&nbsp;and&nbsp;write&nbsp;out&nbsp;top&nbsp;facts&nbsp;for&nbsp;each&nbsp;country</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Content.ReadAsAsync&lt;JsonArray&gt;().ContinueWith(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(readTask)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;First&nbsp;50&nbsp;countries&nbsp;listed&nbsp;by&nbsp;The&nbsp;World&nbsp;Bank...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;country&nbsp;<span class="cs__keyword">in</span>&nbsp;readTask.Result[<span class="cs__number">1</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;&nbsp;&nbsp;&nbsp;{0},&nbsp;Country&nbsp;Code:&nbsp;{1},&nbsp;Capital:&nbsp;{2},&nbsp;Latitude:&nbsp;{3},&nbsp;Longitude:&nbsp;{4}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country.Value[<span class="cs__string">&quot;name&quot;</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country.Value[<span class="cs__string">&quot;iso2Code&quot;</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country.Value[<span class="cs__string">&quot;capitalCity&quot;</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country.Value[<span class="cs__string">&quot;latitude&quot;</span>],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;country.Value[<span class="cs__string">&quot;longitude&quot;</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Hit&nbsp;ENTER&nbsp;to&nbsp;exit...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The HttpResponseMessage contains information about the response including the status code, headers, and any entity body. The entity body is encapsulated in HttpContent which captures content headers such as Content-Type, Content-Encoding,
 etc. as well as the actual content. The content can be read using any number of ReadAs* methods depending on how you would like to consume the data. In the sample above, we read the content as JsonArray so that we can navigate the data and get the information
 we want.</div>
<div class="endscriptcode"></div>
</div>
<h1>More Information</h1>
<ol>
<li>Please see the blog <a href="http://blogs.msdn.com/b/henrikn/archive/2012/02/11/httpclient-is-here.aspx">
HttpClient is Here!</a> for detailed information about this sample </li><li>See <a href="http://www.asp.net/web-api">ASP.NET Web API</a> for more information on the project
</li></ol>
