# Extending HttpClient with OAuth to Access Twitter
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

<div><span style="font-size:medium"><strong><span style="background-color:#ffff00">This code is no longer maintained. Please see
<a href="http://blogs.msdn.com/b/webdev/archive/2012/08/26/asp-net-web-api-and-httpclient-samples.aspx">
List of ASP.NET Web API and HttpClient Samples</a> for updated samples.</span></strong></span></div>
<div><span style="font-size:medium"><strong><span style="background-color:#ffff00"><br>
</span></strong></span></div>
<div><span style="font-size:medium"><strong><span style="background-color:#ffff00"></span></strong></span>Many popular Web APIs such as the
<a href="https://dev.twitter.com/docs">twitter API</a> use some form of <a href="http://oauth.net/">
OAuth</a> for authentication. HttpClient does not have baked in support for OAuth but using the HttpClient extensibility model you can add OAuth as part of the HttpMessageHandler pipeline.</div>
<p>The HttpMessageHandler pipeline is the main extensibility point for the HTTP object model underlying both HttpClient and ASP.NET Web API (they use the exact same model). The pipeline allows up to insert message handlers that can inspect, modify, and process
 HTTP requests and responses as they pass by. The following diagram shows where HttpMessageHandlers sit in the message path on both client (HttpClient) and server side (ASP.NET Web API). The work like &ldquo;Russian Dolls&rdquo; in that each handler passes
 the request to an inner handler until it hits the network or is short-circuited&quot;:</p>
<p><img src="49677-httpmessagehandlers.png" alt="" width="597" height="126"></p>
<p>Note that there is absolutely no requirement that you have to use the HttpClient with ASP.NET Web API &ndash; it is just to show that the model is symmetric on client and server side.</p>
<p>Our OAuth handler is very simple &ndash; it uses the a <a href="http://oauth.googlecode.com/svn/code/csharp/OAuthBase.cs">
sample from OAuth.Net</a> provided by <a href="http://eran.sandler.co.il">Eran Sandler</a> to do the actual OAuth signing.</p>
<p>To run this sample you first need to sign in at the <a href="https://dev.twitter.com/">
twitter developer site</a> and create an app. That will give you necessary information for performing the OAuth authentication:</p>
<ul>
<li><strong>Consumer Key and Consumer Secret</strong>: identifies your application
</li><li><strong>Access Token and Access Token Secret:</strong> identifies the account your application is acting on behalf of
</li></ul>
<p>Once you have these values then you can continue with the sample.</p>
<h1>More Information</h1>
<ol>
<li>Please see the blog <a href="http://blogs.msdn.com/b/henrikn/archive/2012/02/16/extending-httpclient-with-oauth-to-access-twitter.aspx">
Extending HttpClient with OAuth to Access Twitter</a> for more details on this sample.
</li><li>See <a href="http://www.asp.net/web-api">ASP.NET Web API</a> for more information about the project.
</li></ol>
