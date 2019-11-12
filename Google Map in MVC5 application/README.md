# Google Map in MVC5 application
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- Javascript
- Google Map
## Topics
- Javascript
- ASP.NET MVC 5
- Google Map
## Updated
- 01/02/2016
## Description

<h1>Introduction</h1>
<p>This sample show you how to integrate Google maps in an MVC 5 application in less than 5 minutes.&nbsp;<span>Google Maps provides directions, location information, and any other kind of stuff provided by the Google Maps API in your web application.&nbsp;</span></p>
<p><span style="color:#993366">Please, rate it if you find it useful :)</span></p>
<h1>Description</h1>
<p style="text-align:justify">In this sample we will discover how to integrate google maps in an MVC5 application. This map includes markers with&nbsp;a nice big popup &quot;info window&quot; when a marker is clicked on the map.</p>
<p style="text-align:justify">You can change also the color of your marker:</p>
<p style="text-align:justify">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifier&nbsp;le&nbsp;script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Make&nbsp;the&nbsp;marker-pin&nbsp;blue!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;marker.setIcon(<span class="js__string">'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'</span>)</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p style="text-align:justify">You might implement other methods in C# later inorder to add other fonctionnalities to your application.</p>
<p style="text-align:justify">This sample covers the basics of using a map:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifier&nbsp;le&nbsp;script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--&nbsp;This&nbsp;code&nbsp;tells&nbsp;the&nbsp;browser&nbsp;to&nbsp;execute&nbsp;the&nbsp;<span class="js__string">&quot;Initialize&quot;</span>&nbsp;method&nbsp;only&nbsp;when&nbsp;the&nbsp;complete&nbsp;document&nbsp;model&nbsp;has&nbsp;been&nbsp;loaded.&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Initialize();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Where&nbsp;all&nbsp;the&nbsp;fun&nbsp;happens</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;Initialize()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Google&nbsp;has&nbsp;tweaked&nbsp;their&nbsp;interface&nbsp;somewhat&nbsp;-&nbsp;this&nbsp;tells&nbsp;the&nbsp;api&nbsp;to&nbsp;use&nbsp;that&nbsp;new&nbsp;UI</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;google.maps.visualRefresh&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Tunisie&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.LatLng(<span class="js__num">36.81881</span>,&nbsp;<span class="js__num">10.16596</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;These&nbsp;are&nbsp;options&nbsp;that&nbsp;set&nbsp;initial&nbsp;zoom&nbsp;level,&nbsp;where&nbsp;the&nbsp;map&nbsp;is&nbsp;centered&nbsp;globally&nbsp;to&nbsp;start,&nbsp;and&nbsp;the&nbsp;type&nbsp;of&nbsp;map&nbsp;to&nbsp;show</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;mapOptions&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;zoom:&nbsp;<span class="js__num">8</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;center:&nbsp;Tunisie,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mapTypeId:&nbsp;google.maps.MapTypeId.G_NORMAL_MAP&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;This&nbsp;makes&nbsp;the&nbsp;div&nbsp;with&nbsp;id&nbsp;&quot;map_canvas&quot;&nbsp;a&nbsp;google&nbsp;map</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;map&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.Map(document.getElementById(<span class="js__string">&quot;map_canvas&quot;</span>),&nbsp;mapOptions);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;a&nbsp;sample&nbsp;list&nbsp;of&nbsp;JSON&nbsp;encoded&nbsp;data&nbsp;of&nbsp;places&nbsp;to&nbsp;visit&nbsp;in&nbsp;Tunisia</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;you&nbsp;can&nbsp;either&nbsp;make&nbsp;up&nbsp;a&nbsp;JSON&nbsp;list&nbsp;server&nbsp;side,&nbsp;or&nbsp;call&nbsp;it&nbsp;from&nbsp;a&nbsp;controller&nbsp;using&nbsp;JSONResult</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Id&quot;</span>:&nbsp;<span class="js__num">1</span>,&nbsp;<span class="js__string">&quot;PlaceName&quot;</span>:&nbsp;<span class="js__string">&quot;Zaghouan&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLong&quot;</span>:&nbsp;<span class="js__string">&quot;36.401081&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLat&quot;</span>:&nbsp;<span class="js__string">&quot;10.16596&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Id&quot;</span>:&nbsp;<span class="js__num">2</span>,&nbsp;<span class="js__string">&quot;PlaceName&quot;</span>:&nbsp;<span class="js__string">&quot;Hammamet&nbsp;&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLong&quot;</span>:&nbsp;<span class="js__string">&quot;36.4&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLat&quot;</span>:&nbsp;<span class="js__string">&quot;10.616667&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Id&quot;</span>:&nbsp;<span class="js__num">3</span>,&nbsp;<span class="js__string">&quot;PlaceName&quot;</span>:&nbsp;<span class="js__string">&quot;Sousse&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLong&quot;</span>:&nbsp;<span class="js__string">&quot;35.8329809&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLat&quot;</span>:&nbsp;<span class="js__string">&quot;10.63875&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;Id&quot;</span>:&nbsp;<span class="js__num">4</span>,&nbsp;<span class="js__string">&quot;PlaceName&quot;</span>:&nbsp;<span class="js__string">&quot;Sfax&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLong&quot;</span>:&nbsp;<span class="js__string">&quot;34.745159&quot;</span>,&nbsp;<span class="js__string">&quot;GeoLat&quot;</span>:&nbsp;<span class="js__string">&quot;10.7613&quot;</span>&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Using&nbsp;the&nbsp;JQuery&nbsp;&quot;each&quot;&nbsp;selector&nbsp;to&nbsp;iterate&nbsp;through&nbsp;the&nbsp;JSON&nbsp;list&nbsp;and&nbsp;drop&nbsp;marker&nbsp;pins</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(data,&nbsp;<span class="js__operator">function</span>&nbsp;(i,&nbsp;item)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;marker&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.Marker(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'position'</span>:&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.LatLng(item.GeoLong,&nbsp;item.GeoLat),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'map'</span>:&nbsp;map,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'title'</span>:&nbsp;item.PlaceName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Make&nbsp;the&nbsp;marker-pin&nbsp;blue!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;marker.setIcon(<span class="js__string">'http://maps.google.com/mapfiles/ms/icons/blue-dot.png'</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;put&nbsp;in&nbsp;some&nbsp;information&nbsp;about&nbsp;each&nbsp;json&nbsp;object&nbsp;-&nbsp;in&nbsp;this&nbsp;case,&nbsp;the&nbsp;opening&nbsp;hours.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;infowindow&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;google.maps.InfoWindow(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;content:&nbsp;<span class="js__string">&quot;&lt;div&nbsp;class='infoDiv'&gt;&lt;h2&gt;&quot;</span>&nbsp;&#43;&nbsp;item.PlaceName&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/div&gt;&lt;/div&gt;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;finally&nbsp;hook&nbsp;up&nbsp;an&nbsp;&quot;OnClick&quot;&nbsp;listener&nbsp;to&nbsp;the&nbsp;map&nbsp;so&nbsp;it&nbsp;pops&nbsp;up&nbsp;out&nbsp;info-window&nbsp;when&nbsp;the&nbsp;marker-pin&nbsp;is&nbsp;clicked!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;google.maps.event.addListener(marker,&nbsp;<span class="js__string">'click'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;infowindow.open(map,&nbsp;marker);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;</pre>
</div>
</div>
</div>
<h1>Building the Sample</h1>
<p style="text-align:justify">You will need to run this sample on Visual Studio 2013 or higher.</p>
<p><img id="146721" src="146721-maps.png" alt="" width="600" height="400"></p>
<p style="text-align:justify">This tool is very used in .NET applications and you will be using it in every application you will develop since you have to use map in any form.</p>
<p style="text-align:justify"><span>There you have it. A relatively straightforward sample application. Granted, the application doesn't really do anything useful, but it does show you how a integrqte Google maps with an MVC5 application . The best way to get
 the hang of it, is to have a go at the source code and play around with it for a bit.</span></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file index.cshtml&nbsp;</em> </li></ul>
<h1>More Information</h1>
<p><em><em>Feel free to contact me on Twitter @Chourouk2013 for any question about this and visit my blog for more code sample :&nbsp;http://hjaiejchourouk.com/</em></em></p>
