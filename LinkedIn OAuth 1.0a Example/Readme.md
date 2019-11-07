# LinkedIn OAuth 1.0a Example
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- XAML
- HttpClient
## Topics
- OAuth
- LinkedIn
## Updated
- 03/26/2013
## Description

<p><span style="text-decoration:underline"><strong><span style="font-size:large">Introduction</span></strong></span></p>
<p><span style="font-size:small">&nbsp;An example of how to have an app communicating with LinkedIn API through OAuth.</span></p>
<p><span style="text-decoration:underline"><strong><span style="font-size:large">Description</span></strong></span></p>
<p><span style="font-size:small">LinkedIn is using a strict OAuth 1.0a and requires HTTP Header-based Authorization. Before we start coding, let&rsquo;s talk briefly what our application (i.e., LinkedIn consumer) has to do to be able to consume LinkedIn information
 with user authorization.</span></p>
<p><span style="font-size:small">1. Our application has to have a LinkedIn consumer key and consumer secret key. We can get it by registering your app thru LinkedIn Developer Network.</span></p>
<p><span style="font-size:small">2. Our application starts talking with LinkedIn by asking LinkedIn for a request token (and request token secret key). In this step, our application has to give Linkedin, the consumer key and other OAuth information like nonce,
 signature method, version, and so on. The application also needs to provide a signature which is signed with the consumer secret key.</span></p>
<p><span style="font-size:small">3. Beside the request token and the request token secret key, LinkedIn will also give us an authorize link which allows users to (authenticate himself/herself if necessary) authorize our application.</span></p>
<p><span style="font-size:small">4. As our application is not a web application (as specified when we register our application), our application has to provide a way for user to enter a PIN code that LinkedIn gives the user in authorization process.</span></p>
<p><span style="font-size:small">5. Now our application should have the request token, the request token secret key, the PIN code (oauth_verifier). Our application will use above information to request LinkedIn for an access token and an access token secret
 key. The application also needs to provide a signature which is signed with the consumer secret and request token secret keys.</span></p>
<p><span style="font-size:small">6. Once our application has the access token and the access token secret key, then our application can make LinkedIn API call and get information from LinkedIn.</span></p>
<p><span style="font-size:small">Here are screenshots of the app.</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">a. Get RequestToken</span></p>
<p>&nbsp;<img id="65100" src="65100-first-screen.jpg" alt="" width="683" height="384"></p>
<p><span><em>&nbsp;</em></span><span style="font-size:small">&nbsp;b. Get AccesToken</span></p>
<p><img id="65101" src="65101-second-screen.jpg" alt="" width="683" height="384"></p>
<p><span style="font-size:small"><em>c. Access LinkedIn API</em></span></p>
<p><span><em><img id="65102" src="65102-third-screen.jpg" alt="" width="683" height="384"></em></span></p>
<p><span><em></em></span>&nbsp;</p>
<p><span><em>2. Show&nbsp;code&nbsp;that communicates with LinkedIn through OAuth. Several OAuth helper methods are from Web authentication broker sample.</em></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private async void getRequestToken_Click_1(object sender, RoutedEventArgs e)
{
    string nonce = oAuthUtil.GetNonce();
    string timeStamp = oAuthUtil.GetTimeStamp();

    string sigBaseStringParams = &quot;oauth_consumer_key=&quot; &#43; consumerKey.Text;

    sigBaseStringParams &#43;= &quot;&amp;&quot; &#43; &quot;oauth_nonce=&quot; &#43; nonce;
    sigBaseStringParams &#43;= &quot;&amp;&quot; &#43; &quot;oauth_signature_method=&quot; &#43; &quot;HMAC-SHA1&quot;;
    sigBaseStringParams &#43;= &quot;&amp;&quot; &#43; &quot;oauth_timestamp=&quot; &#43; timeStamp;
    sigBaseStringParams &#43;= &quot;&amp;&quot; &#43; &quot;oauth_version=1.0&quot;;
    string sigBaseString = &quot;POST&amp;&quot;;
    sigBaseString &#43;= Uri.EscapeDataString(_linkedInRequestTokenUrl) &#43; &quot;&amp;&quot; &#43; Uri.EscapeDataString(sigBaseStringParams);

    string signature = oAuthUtil.GetSignature(sigBaseString, consumerSecretKey.Text);

    var responseText = await oAuthUtil.PostData(_linkedInRequestTokenUrl, sigBaseStringParams &#43; &quot;&amp;oauth_signature=&quot; &#43; Uri.EscapeDataString(signature));

    if (!string.IsNullOrEmpty(responseText))
    {
        string oauth_token = null;
        string oauth_token_secret = null;
        string oauth_authorize_url = null;
        string[] keyValPairs = responseText.Split('&amp;');

        for (int i = 0; i &lt; keyValPairs.Length; i&#43;&#43;)
        {
            String[] splits = keyValPairs[i].Split('=');
            switch (splits[0])
            {
                case &quot;oauth_token&quot;:
                    oauth_token = splits[1];
                    break;
                case &quot;oauth_token_secret&quot;:
                    oauth_token_secret = splits[1];
                    break;
                case &quot;xoauth_request_auth_url&quot;:
                    oauth_authorize_url = splits[1];
                    break;
            }
        }

        requestToken.Text = oauth_token;
        requestTokenSecretKey.Text = oauth_token_secret;
        oAuthAuthorizeLink.Content = Uri.UnescapeDataString(oauth_authorize_url &#43; &quot;?oauth_token=&quot; &#43; oauth_token);
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;getRequestToken_Click_1(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;nonce&nbsp;=&nbsp;oAuthUtil.GetNonce();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;timeStamp&nbsp;=&nbsp;oAuthUtil.GetTimeStamp();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sigBaseStringParams&nbsp;=&nbsp;<span class="cs__string">&quot;oauth_consumer_key=&quot;</span>&nbsp;&#43;&nbsp;consumerKey.Text;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sigBaseStringParams&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;oauth_nonce=&quot;</span>&nbsp;&#43;&nbsp;nonce;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sigBaseStringParams&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;oauth_signature_method=&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;HMAC-SHA1&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sigBaseStringParams&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;oauth_timestamp=&quot;</span>&nbsp;&#43;&nbsp;timeStamp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sigBaseStringParams&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;<span class="cs__string">&quot;oauth_version=1.0&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;sigBaseString&nbsp;=&nbsp;<span class="cs__string">&quot;POST&amp;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sigBaseString&nbsp;&#43;=&nbsp;Uri.EscapeDataString(_linkedInRequestTokenUrl)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&amp;&quot;</span>&nbsp;&#43;&nbsp;Uri.EscapeDataString(sigBaseStringParams);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;signature&nbsp;=&nbsp;oAuthUtil.GetSignature(sigBaseString,&nbsp;consumerSecretKey.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;responseText&nbsp;=&nbsp;await&nbsp;oAuthUtil.PostData(_linkedInRequestTokenUrl,&nbsp;sigBaseStringParams&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&amp;oauth_signature=&quot;</span>&nbsp;&#43;&nbsp;Uri.EscapeDataString(signature));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">string</span>.IsNullOrEmpty(responseText))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;oauth_token&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;oauth_token_secret&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;oauth_authorize_url&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;keyValPairs&nbsp;=&nbsp;responseText.Split(<span class="cs__string">'&amp;'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;keyValPairs.Length;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;splits&nbsp;=&nbsp;keyValPairs[i].Split(<span class="cs__string">'='</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(splits[<span class="cs__number">0</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;oauth_token&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oauth_token&nbsp;=&nbsp;splits[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;oauth_token_secret&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oauth_token_secret&nbsp;=&nbsp;splits[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;<span class="cs__string">&quot;xoauth_request_auth_url&quot;</span>:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oauth_authorize_url&nbsp;=&nbsp;splits[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestToken.Text&nbsp;=&nbsp;oauth_token;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestTokenSecretKey.Text&nbsp;=&nbsp;oauth_token_secret;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oAuthAuthorizeLink.Content&nbsp;=&nbsp;Uri.UnescapeDataString(oauth_authorize_url&nbsp;&#43;&nbsp;<span class="cs__string">&quot;?oauth_token=&quot;</span>&nbsp;&#43;&nbsp;oauth_token);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainPage.xaml and MainPage.xaml.cs&nbsp;- xaml and code-behind that drives the app.</em>
</li><li><em><em>OAuthUtil.cs&nbsp;- A utility class with OAuth helper methods (some are from Web authentication broker sample).</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on the app, see <a href="http://cyanbyfuchsia.wordpress.com/2012/08/04/connect-your-metro-style-app-to-linkedin-via-oauth/">
http://cyanbyfuchsia.wordpress.com/2012/08/04/connect-your-metro-style-app-to-linkedin-via-oauth/</a></em></p>
