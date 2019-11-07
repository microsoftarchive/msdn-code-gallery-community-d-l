# HTML 5 Web Socket Programming
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- Javascript
- HTML5
## Topics
- ASP.NET
- Web Services
## Updated
- 04/04/2013
## Description

<p><span style="font-size:2em">Introduction</span></p>
<p>HTML 5 Web Sockets is a powerful and effective technique for real-time information processing. There exists many techniques such as Poling, Long Poling and Streaming that are said to be better earier days. With web sockets, it shows a better outcome for
 the end user as well as a proper utilization of the server bandwidth.</p>
<p>WebSocket is a web technology providing full-duplex communications channels over a single TCP connection. The WebSocket protocol was standardized by the IETF as RFC 6455 in 2011, and the WebSocket API for in Web IDL is being standardized by the W3C.WebSocket
 is designed to be implemented in web browsers and web servers, but it can be used by any client or server application. The WebSocket Protocol is an independent TCP-based protocol. Its only relationship to HTTP is that its handshake is interpreted by HTTP servers
 as an Upgrade request. The WebSocket protocol makes possible more interaction between a browser and a web site, facilitating live content and the creation of real-time games. This is made possible by providing a standardized way for the server to send content
 to the browser without being solicited by the client, and allowing for messages to be passed back and forth while keeping the connection open. In this way a two-way (bi-directional) ongoing conversation can take place between a browser and the server. A similar
 effect has been achieved in non-standardized ways using stop-gap technologies such as Comet.In addition, the communications are done over TCP port number 80, which is of benefit for those environments which block non-standard Internet connections using a firewall.
 WebSocket protocol is currently supported in several browsers including Google Chrome, Internet Explorer, Firefox, Safari and Opera. WebSocket also requires web applications on the server to support it.</p>
<p>Here goes a comparison of polling vs Web Sockets.</p>
<p><em><img id="79353" src="79353-poll-ws-compare.gif" alt="" width="503" height="360"><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<ul>
<li><em>Create a new Empty Web Application using Visual Studio 2012 with .NEt Framework 4.5</em>
</li><li><em>Add a Web form which will be rendered to client and a Handler that will process web socket request.</em>
</li><li><em>Instal jQuery and Modernizr through Nuget package installer in Visual Studio.</em>
</li><li><em>Add the necessary Javascript code and define a web socket which transfer through TCP.</em>
</li></ul>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">js</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebSocket.JS
{
    /// &lt;summary&gt;
    /// Summary description for WebSocketHandler
    /// &lt;/summary&gt;
    public class WebSocketHandler : IHttpHandler
    {        
        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(DoRespond);
            }
        }

        private async Task DoRespond(AspNetWebSocketContext context)
        {
            System.Net.WebSockets.WebSocket socket = context.WebSocket;
            while (true)
            {
                ArraySegment&lt;byte&gt; buffer = new ArraySegment&lt;byte&gt;(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None);
                if (socket.State == WebSocketState.Open)
                {
                    string userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    userMessage = &quot;Message from client : &quot; &#43; userMessage;
                    buffer = new ArraySegment&lt;byte&gt;(Encoding.UTF8.GetBytes(userMessage));
                    await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        
    }
}</pre>
<pre class="hidden">var socket;

        $(document).ready(function () {
            if (!Modernizr.websockets)
            {
                alert(&quot;This browser does not support web sockets&quot;);
            }

            socket = new WebSocket(&quot;ws://localhost:49464/WebSocketHandler.ashx&quot;);

            socket.addEventListener(&quot;open&quot;, function (evt) {
                $(&quot;#divHistory&quot;).append('&lt;h3&gt;Connection Opened with the server.&lt;/h3&gt;');
            }, false);

            socket.addEventListener(&quot;close&quot;, function (evt) {
                $(&quot;#divHistory&quot;).append('&lt;h3&gt;Connection was closed. :' &#43; evt.reason &#43; '&lt;/h3&gt;');
            }, false);

            socket.addEventListener(&quot;message&quot;, function (evt) {
                $(&quot;#divHistory&quot;).append('&lt;h3&gt;' &#43; evt.data &#43; '&lt;/h3&gt;');
            }, false);

            socket.addEventListener(&quot;error&quot;, function (evt) {
                alert('Error : ' &#43; evt.message);
            }, false);

            $(&quot;#startButton&quot;).click(function () {
                if (socket.readyState == WebSocket.OPEN) {
                    socket.send($(&quot;#myEmail&quot;).val());
                }
                else {
                    $(&quot;#divHistory&quot;).append('&lt;h3&gt;The underlying connection is closed.&lt;/h3&gt;');
                }
            });

            $(&quot;#endButton&quot;).click(function () {
                socket.close();
            });


        });</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.WebSockets;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net.WebSockets;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;WebSocket.JS&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Summary&nbsp;description&nbsp;for&nbsp;WebSocketHandler</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;WebSocketHandler&nbsp;:&nbsp;IHttpHandler&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ProcessRequest(HttpContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(context.IsWebSocketRequest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.AcceptWebSocketRequest(DoRespond);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;async&nbsp;Task&nbsp;DoRespond(AspNetWebSocketContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Net.WebSockets.WebSocket&nbsp;socket&nbsp;=&nbsp;context.WebSocket;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArraySegment&lt;<span class="cs__keyword">byte</span>&gt;&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArraySegment&lt;<span class="cs__keyword">byte</span>&gt;(<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[<span class="cs__number">1024</span>]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebSocketReceiveResult&nbsp;result&nbsp;=&nbsp;await&nbsp;socket.ReceiveAsync(buffer,&nbsp;CancellationToken.None);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(socket.State&nbsp;==&nbsp;WebSocketState.Open)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;userMessage&nbsp;=&nbsp;Encoding.UTF8.GetString(buffer.Array,&nbsp;<span class="cs__number">0</span>,&nbsp;result.Count);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;userMessage&nbsp;=&nbsp;<span class="cs__string">&quot;Message&nbsp;from&nbsp;client&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;userMessage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ArraySegment&lt;<span class="cs__keyword">byte</span>&gt;(Encoding.UTF8.GetBytes(userMessage));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;socket.SendAsync(buffer,&nbsp;WebSocketMessageType.Text,&nbsp;<span class="cs__keyword">true</span>,&nbsp;CancellationToken.None);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsReusable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>WebSocketHandler.ashx - The WebSocket handler from the sever </li><li>Default.aspx - Client side page render </li><li>modernizr-2.6.2.js - Modernizr library </li><li>jquery-1.9.1.min.js - jQuery library </li></ul>
<h1>More Information</h1>
<p><em>Visit the official website on&nbsp;<a href="http://www.websocket.org/">http://www.websocket.org/</a></em></p>
