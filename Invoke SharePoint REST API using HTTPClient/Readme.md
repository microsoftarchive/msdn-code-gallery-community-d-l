# Invoke SharePoint REST API using HTTPClient
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- REST
- .NET
- Sharepoint Online
- HttpClient
## Topics
- REST
- Sharepoint Online
## Updated
- 04/09/2015
## Description

<h1>Introduction</h1>
<p><em>This example is intended as a simple track using HttpClient to invoke your RESTful services exposed by SharePoint Online.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To build this sample, simply open the project with Visual Studio or Visual Studio 2015 2013 Preview.Special requirements are not required.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Here are the points to watch out for:</p>
<ul>
<li>install the NUGET package for referencing all the items needed to use HttpClient
</li><li>adding reference to the SharePoint Client DLL (Microsoft.SharePoint.Client, Microsoft.SharePoint.Client.Runtime)
</li><li>creating a secure password </li><li>creating&nbsp;SharePointOnlineCredentials </li><li>getting&nbsp;GetAuthenticationCookie </li><li>invoking rest API </li></ul>
<p>In this sample, we'll invoke REST API exposed by SharePoint to get the title of the current web.&nbsp;This call will return a JSON string which must be parsata to obtain the necessary information.The parsing is not covered by this sample.</p>
<p>&nbsp;</p>
<pre><span style="color:#339966">{&quot;odata.metadata&quot;:&quot;https://zsis376.sharepoint.com/_api/$metadata#SP.ApiData.Webs/@Element&amp;select=Title&quot;,&quot;odata.type&quot;:&quot;SP.Web&quot;,&quot;odata.id&quot;:&quot;https://zsis376.sharepoint.com/_api/Web&quot;,&quot;odata.editLink&quot;:&quot;Web&quot;,&quot;Title&quot;:&quot;Sito del team&quot;}</span><br></pre>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> private static async Task&lt;string&gt;getWebTitle(string webUrl)
        {
            //Creating Password
            const string PWD = &quot;softjam.1&quot;;
            const string USER = &quot;bubu@zsis376.onmicrosoft.com&quot;;
            const string RESTURL = &quot;{0}/_api/web?$select=Title&quot;;

            //Creating Credentials
            var passWord = new SecureString();
            foreach (var c in PWD) passWord.AppendChar(c);
            var credential = new SharePointOnlineCredentials(USER, passWord);

            //Creating Handler to allows the client to use credentials and cookie
            using (var handler = new HttpClientHandler() { Credentials = credential })
            {
                //Getting authentication cookies
                Uri uri = new Uri(webUrl);
                handler.CookieContainer.SetCookies(uri, credential.GetAuthenticationCookie(uri));

                //Invoking REST API
                using (var client = new HttpClient(handler))
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(&quot;application/json&quot;));

                    HttpResponseMessage response = await client.GetAsync(string.Format(RESTURL, webUrl)).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();

                    string jsonData = await response.Content.ReadAsStringAsync();

                    return jsonData;
                }
            }
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;getWebTitle(<span class="cs__keyword">string</span>&nbsp;webUrl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Creating&nbsp;Password</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;PWD&nbsp;=&nbsp;<span class="cs__string">&quot;softjam.1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;USER&nbsp;=&nbsp;<span class="cs__string">&quot;bubu@zsis376.onmicrosoft.com&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;RESTURL&nbsp;=&nbsp;<span class="cs__string">&quot;{0}/_api/web?$select=Title&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Creating&nbsp;Credentials</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;passWord&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SecureString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;PWD)&nbsp;passWord.AppendChar(c);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;credential&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointOnlineCredentials(USER,&nbsp;passWord);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Creating&nbsp;Handler&nbsp;to&nbsp;allows&nbsp;the&nbsp;client&nbsp;to&nbsp;use&nbsp;credentials&nbsp;and&nbsp;cookie</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;handler&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClientHandler()&nbsp;{&nbsp;Credentials&nbsp;=&nbsp;credential&nbsp;})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Getting&nbsp;authentication&nbsp;cookies</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Uri&nbsp;uri&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(webUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;handler.CookieContainer.SetCookies(uri,&nbsp;credential.GetAuthenticationCookie(uri));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Invoking&nbsp;REST&nbsp;API</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient(handler))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultRequestHeaders.Accept.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;client.DefaultRequestHeaders.Accept.Add(<span class="cs__keyword">new</span>&nbsp;MediaTypeWithQualityHeaderValue(<span class="cs__string">&quot;application/json&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(<span class="cs__keyword">string</span>.Format(RESTURL,&nbsp;webUrl)).ConfigureAwait(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.EnsureSuccessStatusCode();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;jsonData&nbsp;=&nbsp;await&nbsp;response.Content.ReadAsStringAsync();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;jsonData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p><em>For more information on this sample, take a look at&nbsp;</em></p>
<p><em>http://zsvipullo.blogspot.it/2015/04/invoke-sharepoint-rest-api-using.html<br>
</em></p>
