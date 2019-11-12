# Download file from SharePoint Online
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- Sharepoint Online
## Topics
- Sharepoint Online
## Updated
- 11/30/2014
## Description

<h1>Introduction</h1>
<p><em>Sample DOwnload a file which is inside SharePoint Online</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Prior to work with the sample you must have an SharePoint online Site.&nbsp;</em></p>
<p><em>A File uploaded anywhere on SharePoint.</em></p>
<p><em>Run the Sample and ENter the info</em></p>
<p><em>1. SiteUrl: Url of SharePoint Site.</em></p>
<p><em>2. User Name : Name of the authenticated user who has permission on sharePoint.</em></p>
<p><em>3. Password: Password of the User specified above.</em></p>
<p><em>4. File Url Url of file to be downloaded</em></p>
<p>&nbsp;</p>
<p><em><img id="130576" src="130576-capture.jpg" alt="" width="553" height="300"></em></p>
<p>&nbsp;</p>
<p><em>Click Download.</em></p>
<p><em>file will be downloaded in the exe folder.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample includes the SharePoint Client dll Inside SharepointClient2013&nbsp;folder.</em></p>
<p>&nbsp;</p>
<p><em>It uses this dll to make a requst to the SharePoint passing thje Credential object which is created by username and password.</em></p>
<p>&nbsp;</p>
<p><em>1. It initialized the ClientContext object of SharePoint Client dll.</em></p>
<p><em>by assigning the SharePointOnlineCredential object&nbsp;</em></p>
<p>&nbsp;</p>
<p><em>It read the userName and password.</em></p>
<p><em>Convert password into a secur<em>e string than initilizes the SharePointOnlineCredential object.</em></em></p>
<p><em><em>This object is than assigned to ClientContext.Credentials object.</em></em></p>
<p>&nbsp;</p>
<p>Now to download a file from URL you must initialize the Web Object and than pass the ServerRelativeURl of file.</p>
<p>&nbsp;</p>
<p>To get the File ServerRelativeURL sample first get the Web ServerRelativeUrl.</p>
<p>to get the Properties you must load it in client context</p>
<p>&nbsp; &nbsp; Web web = clientContext.Web;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
<p>clientContext.Load(web, website =&gt; website.ServerRelativeUrl);&nbsp; &nbsp;</p>
<p>&nbsp;</p>
<p>after loading youmust execute it as query. &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;</p>
<p>&nbsp; clientContext.ExecuteQuery();</p>
<h2 class="heading">Now once you have the ServerRelativeURL use regex to get File Relative URL</h2>
<p>&nbsp;Regex regex = new Regex(SiteUrl, RegexOptions.IgnoreCase);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; string strSiteRelavtiveURL = regex.Replace(FileUrl, string.Empty);&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; string strServerRelativeURL
 = CombineUrl(web.ServerRelativeUrl, strSiteRelavtiveURL);</p>
<h2 class="heading">Build the sample</h2>
<div class="section" id="sectionSection4">
<p>Press the F5 key to build and deploy the app.</p>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Get&nbsp;file&nbsp;information&nbsp;from&nbsp;Sharepoint.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;documentUrl&quot;&gt;Document&nbsp;Url.&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;Returns&nbsp;file&nbsp;information&nbsp;object.&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Stream&nbsp;GetFile()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(ClientContext&nbsp;clientContext&nbsp;=&nbsp;GetContextObject())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Web&nbsp;web&nbsp;=&nbsp;clientContext.Web;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientContext.Load(web,&nbsp;website&nbsp;=&gt;&nbsp;website.ServerRelativeUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientContext.ExecuteQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Regex&nbsp;regex&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Regex(SiteUrl,&nbsp;RegexOptions.IgnoreCase);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strSiteRelavtiveURL&nbsp;=&nbsp;regex.Replace(FileUrl,&nbsp;<span class="cs__keyword">string</span>.Empty);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;strServerRelativeURL&nbsp;=&nbsp;CombineUrl(web.ServerRelativeUrl,&nbsp;strSiteRelavtiveURL);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.SharePoint.Client.File&nbsp;oFile&nbsp;=&nbsp;web.GetFileByServerRelativeUrl(strServerRelativeURL);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientContext.Load(oFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientResult&lt;Stream&gt;&nbsp;stream&nbsp;=&nbsp;oFile.OpenBinaryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clientContext.ExecuteQuery();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">this</span>.ReadFully(stream.Value);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;ClientContext&nbsp;GetContextObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClientContext&nbsp;context&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ClientContext(SiteUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.Credentials&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SharePointOnlineCredentials(UserName,&nbsp;Password);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;context;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;SecureString&nbsp;GetPasswordFromConsoleInput(<span class="cs__keyword">string</span>&nbsp;password)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;the&nbsp;user's&nbsp;password&nbsp;as&nbsp;a&nbsp;SecureString</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SecureString&nbsp;securePassword&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SecureString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">char</span>[]&nbsp;arrPassword&nbsp;=&nbsp;password.ToCharArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">char</span>&nbsp;c&nbsp;<span class="cs__keyword">in</span>&nbsp;arrPassword)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;securePassword.AppendChar(c);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;securePassword;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
