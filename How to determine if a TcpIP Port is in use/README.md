# How to determine if a Tcp/IP Port is in use
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- WCF
- Diagnostics
- .NET
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- .NET Framework
- Sockets
- .NET Framework 4.0
- Library
- Windows General
- Network
- C# Language
- IO Ports
- Network Monitor
- Networking
- System.Net Namespace
- .NET Framework 4.5
- .NET Framwork
- C# 3.0
- TCP/IP
- Microsoft .NET Framework 3.5 SP1
- HttpClient
- Visual C Sharp .NET
- system.net.sockets
- .NET 4.5
- .NET 2.0
- .NET Development
## Topics
- C#
- Sockets
- Programming Tips
- Network
- Socket
- IP Address
- net.tcp
- ports
- Network Connectivity
- .NET 4
- .NET 2
- Generic C# resuable code
- Networking
- C# Language Features
- Network Interface
- Socket Programming
- I/O Operations On Ports
- .Net Programming
- TCP/IP Client/Server
- WebSockets
- code snippets
- streamsocket
## Updated
- 04/25/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify"><span style="font-size:small">This article features a short illustration of how to determine if a network port is already in use.</span></p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify"><span style="font-size:small">There are&nbsp;no special requirements or instructions for building the sample.</span></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p style="text-align:justify"><span style="font-size:small">When creating a TCP/IP server connection on a Windows based platform you can specify a port number ranging from 1000 to 65535. It would seem unlikely that two applications executing at the same time
 will both attempt to open the same port number, in reality it happens quite often. It is advisable to first determine if a port is already in use before attempting to start a server connection listening on that port.</span>&nbsp;</p>
<h1>Active Tcp Listeners</h1>
<p style="text-align:justify"><span style="font-size:small">The <a title="System.Net.NetworkInformation" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.networkinformation.aspx" target="_blank">
System.Net.NetworkInformation</a> namespace defines an <a title="IPGlobalProperties" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.networkinformation.ipglobalproperties.aspx" target="_blank">
IPGlobalProperties</a> class. Using <a title="IPGlobalProperties" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.networkinformation.ipglobalproperties.aspx" target="_blank">
IPGlobalProperties</a> we can determine the <a title="IPEndPoint" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.ipendpoint.aspx" target="_blank">
IPEndPoint</a> every server connection listens on for incoming connections. Listed below is a code snippet detailing the
<strong><em>PortInUse</em></strong> method.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;PortInUse(<span class="cs__keyword">int</span>&nbsp;port)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;inUse&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IPGlobalProperties&nbsp;ipProperties&nbsp;=&nbsp;IPGlobalProperties.GetIPGlobalProperties();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IPEndPoint[]&nbsp;ipEndPoints&nbsp;=&nbsp;ipProperties.GetActiveTcpListeners();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(IPEndPoint&nbsp;endPoint&nbsp;<span class="cs__keyword">in</span>&nbsp;ipEndPoints)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(endPoint.Port&nbsp;==&nbsp;port)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;inUse&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;inUse;&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify"><span style="font-size:small">The <strong><em>PortInUse</em></strong> method determines all active server connections, then proceeds to iterate an Array of
<a title="IPEndPoint" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.ipendpoint.aspx" target="_blank">
IPEndPoint</a> objects comparing port numbers to the method&rsquo;s only parameter.</span></p>
<h1><span>The Implementation</span></h1>
<p style="text-align:justify"><span style="font-size:small">The <strong><em>PortInUse</em></strong> method is implemented in a Console based application. First the sample source starts up an instance of the
<a title="HttpListner" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx" target="_blank">
HttpListner</a> class on port 8080. The <a title="HttpListner" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.net.httplistener.aspx" target="_blank">
HttpListner</a> definition is followed by determining if port 8080 is in fact being used.</span></p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;HttpListener&nbsp;httpListner&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpListener();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;httpListner.Prefixes.Add(<span class="cs__string">&quot;http://*:8080/&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;httpListner.Start();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Port:&nbsp;8080&nbsp;status:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;(PortInUse(<span class="cs__number">8080</span>)&nbsp;?&nbsp;<span class="cs__string">&quot;in&nbsp;use&quot;</span>&nbsp;:&nbsp;<span class="cs__string">&quot;not&nbsp;in&nbsp;use&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;httpListner.Close();&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>
<p><span style="font-size:small"><em>Program.cs&nbsp;- Contains definition of&nbsp;
<strong>PortInUse()</strong> method and <strong>Main()</strong> implementation</em></span></p>
</li></ul>
<h1>More Information</h1>
<p style="text-align:justify"><span style="font-size:small">This article is based on an article originally posted on my
<a title="http://softwarebydefault.com" href="http://softwarebydefault.com" target="_blank">
blog</a>: <a href="http://softwarebydefault.com/2013/02/22/port-in-use/">http://softwarebydefault.com/2013/02/22/port-in-use/</a>&nbsp;</span></p>
<p style="text-align:justify"><span style="font-size:small">Please remember to rate this article, if you have any questions or comments please make use of the Q&amp;A section on this page.</span></p>
<p style="text-align:justify"><span style="font-size:small"><strong><em><a title="Dewald Esterhuizen" href="http://softwarebydefault.com/about/" target="_blank">Dewald Esterhuizen</a></em></strong></span></p>
