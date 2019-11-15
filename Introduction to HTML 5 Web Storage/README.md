# Introduction to HTML 5 Web Storage
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- HTML 5
- Web Storage
## Topics
- HTML 5
- Web Storage
## Updated
- 07/14/2014
## Description

<div style="text-align:justify">HTML5 has introduced two mechanisms for storing structured data on the client side, similar to HTTP session cookies. HTTP cookies have some drawbacks such as limited to store 4 KB of data etc. Web storage is considered as one
 of the most rising data storage methods is HTML 5 web applications as well as Windows Store Apps.<br>
<br>
</div>
<div style="text-align:justify">Web storage consists of two main web storage types: local storage and session storage, behaving similarly to persistent cookies and session cookies respectively. These two storage types differ from each other based on their scope
 and lifetime.<br>
<br>
</div>
<h2><a name="Local_Storage"></a>Local Storage<br>
<br>
</h2>
<div style="text-align:justify">Data placed in local storage is per domain (it's available to all scripts from the domain that originally stored the data) and persists after the browser is closed. That means if you close the browser and check for the data in
 local storage, it will still be available. There is no expiration date for the data in local storage unless you&nbsp;explicitly&nbsp;delete them. You can access the data in the local storage, may be next day, next month or even after a year.<br>
<br>
</div>
<h2><a name="Session_Storage"></a>Session Storage</h2>
<div style="text-align:justify"><br>
Session storage is per-page-per-window and is limited to the lifetime of the window.</div>
<h5><a name="Programming_Web_Storage"></a><span style="font-size:small">Programming Web Storage</span></h5>
<p><span style="text-decoration:underline">Store Item</span></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:200px; width:97.5%; background-color:#f4f4f4">
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">localStorage.someid = <span style="color:#006080">'somevalue'</span>;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//or</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">localStorage.setItem(<span style="color:#006080">'someid'</span>, <span style="color:#006080">'somevalue'</span>);<span style="font-size:8pt; line-height:12pt; background-color:#f4f4f4">&nbsp;</span></pre>
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">sessionStorage.someid = <span style="color:#006080">'somevalue'</span>;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//or</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">sessionStorage.setItem(<span style="color:#006080">'someid'</span>, <span style="color:#006080">'somevalue'</span>);</pre>
</div>
</div>
<p><span style="text-decoration:underline">Retrieve Item </span></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:200px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">var</span><span style="font-size:8pt; line-height:12pt; background-color:white"> value = localStorage.getItem(</span><span style="font-size:8pt; line-height:12pt; color:#006080">'someid'</span><span style="font-size:8pt; line-height:12pt; background-color:white">);</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//or</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">var</span> value = localStorage.someid</pre>
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">var</span> value = sessionStorage.getItem(<span style="color:#006080">'someid'</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//or</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">var</span> value = sessionStorage.someid</pre>
</div>
</div>
<p><span style="text-decoration:underline">Remove Item</span></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:200px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; background-color:white">localStorage.removeItem(</span><span style="font-size:8pt; line-height:12pt; color:#006080">'someid'</span><span style="font-size:8pt; line-height:12pt; background-color:white">);</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">sessionStorage.removeItem(<span style="color:#006080">'someid'</span>);</pre>
</div>
</div>
<p><span style="text-decoration:underline">Clear Storage</span></p>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:200px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; background-color:white">localStorage.clear();</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">sessionStorage.clear();</pre>
</div>
</div>
<div style="text-align:justify">Now let&rsquo;s see this in an example. In My page I have two text boxes to insert Id and value.</div>
<p>&nbsp;</p>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td><a href="http://lh3.ggpht.com/-MMrqCLaZi1k/UYiPviPE-cI/AAAAAAAABZc/pWGl9l6zupo/s1600-h/image%25255B10%25255D.png" style="margin-left:auto; margin-right:auto"><img title="image" src="http://lh5.ggpht.com/-X_dUWtg58co/UYiPwAYIIwI/AAAAAAAABZk/E2SOpYxtvmA/image_thumb%25255B8%25255D.png?imgmax=800" alt="image" width="494" height="24" style="border-width:0px; float:none; padding-top:0px; padding-left:0px; margin-left:auto; display:block; padding-right:0px; margin-right:auto; border-style:solid"></a></td>
</tr>
<tr>
<td class="tr-caption">Input</td>
</tr>
</tbody>
</table>
<div style="text-align:justify">First what I am doing is check whether the browser supports web storage. You can find the browsers and the versions that support Web Storage&nbsp;<a href="http://www.html5rocks.com/en/features/storage" target="_blank">here</a>.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:400px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:blue">var</span><span style="font-size:8pt; line-height:12pt; background-color:white"> isWebStorageSupported =
</span><span style="font-size:8pt; line-height:12pt; color:blue">false</span><span style="font-size:8pt; line-height:12pt; background-color:white">;</span><span style="font-size:8pt; line-height:12pt">&nbsp;</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">window.onload = <span style="color:blue">function</span> ()</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">{</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">if</span> (<span style="color:blue">typeof</span> (Storage) !== <span style="color:#006080">&quot;undefined&quot;</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        <span style="color:green">//your browser supports web storage.</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        isWebStorageSupported = <span style="color:blue">true</span>;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    <span style="color:blue">else</span> {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        <span style="color:green">//your browser doesn't support web storage.</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        isWebStorageSupported = <span style="color:blue">false</span>;</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<div style="text-align:justify">Now if the browser supports web storage, I am inserting values and storing them in local storage as well as in session storage.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:400px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:green; background-color:white">//check whether the browser supports web storage and</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//and insert to local storage</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">function</span> insertToLocalStorage(id, value) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">if</span> (isWebStorageSupported) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        <span style="color:blue">if</span> (id != <span style="color:#006080">&quot;&quot;</span> &amp;&amp; value != <span style="color:#006080">&quot;&quot;</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">            localStorage.setItem(id, value);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">            alert(<span style="color:#006080">&quot;Saved on Local Storage&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">}</pre>
</div>
</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:400px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:green; background-color:white">//check whether the browser supports web storage and</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//and insert to session storage</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">function</span> insertToSessionStorage(id, value) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">if</span> (isWebStorageSupported) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        <span style="color:blue">if</span> (id != <span style="color:#006080">&quot;&quot;</span> &amp;&amp; value != <span style="color:#006080">&quot;&quot;</span>) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">            sessionStorage.setItem(id, value);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">            alert(<span style="color:#006080">&quot;Saved on Session Storage&quot;</span>);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">    }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">}</pre>
</div>
</div>
<div style="text-align:justify">Then I am retrieving the items stored in both local storage and session storage. I am going to check the data in web storage in the same browser session and after closing and re opening the browser.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:800px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:green; background-color:white">//check whether the browser supports web storage and</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//show all items from local storage</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">function</span> getAllFromLocalStorage() {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">   <span style="color:blue">if</span> (isWebStorageSupported) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">       <span style="color:blue">for</span> (<span style="color:blue">var</span> i = 0, len = localStorage.length; i &lt; len; i&#43;&#43;) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">           <span style="color:blue">var</span> key = localStorage.key(i);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">           <span style="color:blue">var</span> value = localStorage.getItem(key);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">           alert(key &#43; <span style="color:#006080">&quot;=&quot;</span> &#43; value);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">       }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">   }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
<br>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:green">//check whether the browser supports web storage and</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:green">//show all items from session storage</span></pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white"><span style="color:blue">function</span> getAllFromSessionStorage() {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">   <span style="color:blue">if</span> (isWebStorageSupported) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">       <span style="color:blue">for</span> (<span style="color:blue">var</span> i = 0, len = sessionStorage.length; i &lt; len; i&#43;&#43;) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">           <span style="color:blue">var</span> key = sessionStorage.key(i);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">           <span style="color:blue">var</span> value = sessionStorage.getItem(key);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">           alert(key &#43; <span style="color:#006080">&quot;=&quot;</span> &#43; value);</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">       }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">   }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<div style="text-align:justify">After checking, I can see that local storage is not becoming empty even after closing and re opening. But session storage is becoming empty, when the browser has been closed.</div>
<div></div>
<div style="text-align:justify">To clear the local storage and session storage explicitly, you can use the&nbsp;following&nbsp;method.</div>
<div id="codeSnippetWrapper" style="overflow:auto; font-size:8pt; border:1px solid silver; font-family:'Courier New',courier,monospace; padding:4px; direction:ltr; margin:20px 0px 10px; line-height:12pt; max-height:200px; width:97.5%; background-color:#f4f4f4">
<span style="font-size:8pt; line-height:12pt; color:green; background-color:white">//clear all items from session and local storage</span><br>
<div id="codeSnippet" style="border-style:none; overflow:visible; font-size:8pt; color:black; padding:0px; direction:ltr; line-height:12pt; width:100%">
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%"><span style="color:blue">function</span> clearStorage()</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">{</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    <span style="color:blue">if</span> (isWebStorageSupported) {</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        sessionStorage.clear();</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">        localStorage.clear();</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">        alert(<span style="color:#006080">&quot;Local and Session Storage Cleared.&quot;</span>)</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%">    }</pre>
<pre style="border-style:none; overflow:visible; font-size:8pt; font-family:'Courier New',courier,monospace; padding:0px; direction:ltr; margin:0em; line-height:12pt; width:100%; background-color:white">}</pre>
</div>
</div>
<div style="text-align:justify">Now I am going to give you a little hint about a place where you can see the items in the local storage and session storage in
<strong>Google Chrome</strong>. In the page, go to <strong>Inspect element</strong> and then go to
<strong>Resources</strong> tab. There you can find the Local Storage and Session Storage.</div>
<div style="text-align:justify">&nbsp;</div>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td><a href="http://2.bp.blogspot.com/-aKPqjkv0rBQ/UYkoGbvUj5I/AAAAAAAABZ0/YukjAV86dk4/s1600/local.png" style="margin-left:auto; margin-right:auto"><img src="http://2.bp.blogspot.com/-aKPqjkv0rBQ/UYkoGbvUj5I/AAAAAAAABZ0/YukjAV86dk4/s400/local.png" alt="" width="400" height="148" style="border-width:0px; border-style:solid"></a></td>
</tr>
<tr>
<td class="tr-caption">Local Storage</td>
</tr>
</tbody>
</table>
<table class="tr-caption-container" cellspacing="0" cellpadding="0" align="center" style="text-align:center; margin-left:auto; margin-right:auto">
<tbody>
<tr>
<td><a href="http://4.bp.blogspot.com/-nOKMPgbPbn4/UYkoGvb1KtI/AAAAAAAABZ4/E2V9ODIf8Xw/s1600/session.png" style="margin-left:auto; margin-right:auto"><img src="http://4.bp.blogspot.com/-nOKMPgbPbn4/UYkoGvb1KtI/AAAAAAAABZ4/E2V9ODIf8Xw/s400/session.png" alt="" width="400" height="150" style="border-width:0px; border-style:solid"></a></td>
</tr>
<tr>
<td class="tr-caption">Session Storage</td>
</tr>
</tbody>
</table>
