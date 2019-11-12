# Linq2Twitter
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- LINQ to SQL
- C# Language
## Topics
- LINQ
- Console Applications
## Updated
- 02/01/2016
## Description

<p>Sample code for Linq2Twitter in Console application.</p>
<p>It just give you an overview how to use Linq2Twitter API in C#.</p>
<p><span>LINQ to Twitter is an open source 3rd party LINQ Provider for the&nbsp;</span><a href="http://twitter.com/">Twitter</a><span>&nbsp;micro-blogging service. It uses standard LINQ syntax for queries and includes method calls for changes via the&nbsp;</span><a href="http://dev.twitter.com/">Twitter
 API</a><span>.</span></p>
<p>&nbsp;</p>
<p>It will ask for your accessToken , accessTokenSecret, &nbsp;<span style="white-space:pre">
</span>consumerKey, consumerSecret ,twitterAccountToDisplay to get all this start by creating a twitter account that your application will be using to access Twitter. This is easy-peasy. Log on to&nbsp;<a href="https://twitter.com/">https://twitter.com/</a>&nbsp;and
 setup your account.</p>
<p>Once your account is setup, navigate to&nbsp;<a href="https://dev.twitter.com/">https://dev.twitter.com</a>&nbsp;and sign in with your twitter credentails.&nbsp;</p>
<div class="separator">You need to enter your application details. You need a Name, Description &amp; a Website (Your application's publicly accessible home page). You can add a Callback URL but its not really required. (Note: The name can't include the word
 &quot;twitter&quot;.)</div>
<div class="separator"><a href="http://1.bp.blogspot.com/-ldsFSYRXGME/Ux02_MLXGPI/AAAAAAAABXk/BhkYJmZNmuI/s1600/2.PNG"><img src="-2.png" border="0" alt="" width="400" height="230"></a></div>
<p>&nbsp;</p>
<div class="separator"><a href="http://4.bp.blogspot.com/-xV70008u0a8/Ux02_e4QUUI/AAAAAAAABXg/ECISM1eYJw0/s1600/3.PNG"><img src="-3.png" border="0" alt="" width="400" height="230"></a></div>
<div class="separator"></div>
<div class="separator"></div>
<div class="separator"></div>
<div class="separator">Remember to agree to the terms and conditions.</div>
<div class="separator"></div>
<div class="separator">You should now get directed to the application page. By default, the first tab (&quot;Details&quot; tab) is visible. You must click the &quot;Api Keys&quot; tab and then click the &quot;Create my access token&quot; button (you will need to scroll down). This in
 turn generates the access tokens (you may need to refresh the page). Your Keys and Access Tokens should now be available for use.</div>
<div class="separator"></div>
<div class="separator"><a href="http://1.bp.blogspot.com/-GaKCAIUT2w0/Ux07S0RrG8I/AAAAAAAABX0/G51TUd8R7Qg/s1600/1.PNG"><img src="-1.png" border="0" alt="" width="400" height="231"></a></div>
<p>&nbsp;</p>
<div class="separator"><a href="http://2.bp.blogspot.com/-SuvpqryUwKo/Ux07S3DDhrI/AAAAAAAABX4/M26O5jS5Tok/s1600/2.PNG"><img src="-2.png" border="0" alt="" width="400" height="193"></a></div>
<p>&nbsp;</p>
<div class="separator"><a href="http://2.bp.blogspot.com/-LK2lmMJXgq4/Ux07S7g8JsI/AAAAAAAABX8/Qupg3u2RomI/s1600/3.PNG"><img src="-3.png" border="0" alt="" width="400" height="251"></a></div>
<p>&nbsp;</p>
<div class="separator"><a href="http://4.bp.blogspot.com/-JicQOZpZ2zw/Ux07ToB91fI/AAAAAAAABYE/qcat0M9q7XA/s1600/4.PNG"><img src="-4.png" border="0" alt="" width="400" height="356"></a></div>
<div class="separator"></div>
<div class="separator"></div>
<div class="separator"></div>
<div class="separator"></div>
<div class="separator">Once created, navigate to the &quot;OAutth tool&quot; tab to view your OAuth Settings. We will need the generated tokens for our applications. (Note: My tokens are crossed out to maintain their integrity.)</div>
<div class="separator"></div>
<div class="separator">Take note of the following tokens as we will need these later:</div>
<div class="separator"></div>
<ul>
<li>Consumer key </li><li>Consumer secret </li><li>Access token </li><li>Access token secret </li></ul>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;Console.WriteLine(<span class="cs__string">&quot;SECTION&nbsp;D:&nbsp;Get&nbsp;Tweets&nbsp;for&nbsp;user&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;statusTweets&nbsp;=&nbsp;(from&nbsp;tweet&nbsp;<span class="cs__keyword">in</span>&nbsp;twitterContext&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;tweet.Type&nbsp;==&nbsp;SearchType.Search&nbsp;&amp;&amp;&nbsp;tweet.Query&nbsp;==&nbsp;searchTweet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;tweet.Count&nbsp;==&nbsp;tweetCount&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;tweet).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(AggregateException&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;AggregateException&nbsp;{0}&quot;</span>,&nbsp;e.InnerExceptions[<span class="cs__number">0</span>]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;PrintTweets(List&lt;Search&gt;&nbsp;statusTweets)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;statusTweet&nbsp;<span class="cs__keyword">in</span>&nbsp;statusTweets)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;statusTweet.Statuses.ForEach(tweet&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;User:&nbsp;{0},&nbsp;Tweet:&nbsp;{1}&nbsp;\n&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tweet.User.ScreenNameResponse,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tweet.Text));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(<span class="cs__number">1000</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Link for Linq2Twitter :-&nbsp;https://github.com/JoeMayo/LinqToTwitter</p>
<p>StackOverFlow Question &amp; Answer :-&nbsp;http://stackoverflow.com/questions/tagged/linq-to-twitter</p>
