# Getting Started with SignalR 2.0 and MVC 5
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- SignalR
- ASP.NET MVC 5
## Topics
- Getting Started
## Updated
- 04/18/2014
## Description

<h1>Introduction</h1>
<p><em><em>This is the application created in the&nbsp;<a title="Getting Started with SignalR 2.0 and MVC 5" href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-getting-started-with-signalr-20-and-mvc-5" target="_blank">Getting
 Started with SignalR 2.0 and MVC 5</a> tutorial.</em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>After opening the project in Visual Studio 2013, open the Package Manager Console and click&nbsp;<strong>Restore</strong>&nbsp;to install the required SignalR components.</em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This tutorial introduces you to real-time web application development with ASP.NET SignalR 2.0 and ASP.NET MVC 5. The tutorial uses the same chat application code as the&nbsp;<a href="http://www.asp.net/signalr/overview/signalr-20/getting-started-with-signalr-20/tutorial-getting-started-with-signalr-20">SignalR
 Getting Started tutorial</a>, but shows how to add it to an MVC 5 application.</p>
<p>In this topic you will learn the following SignalR development tasks:</p>
<ul>
<li>Adding the SignalR library to an MVC 5 application. </li><li>Creating hub and OWIN startup classes to push content to clients. </li><li>Using the SignalR jQuery library in a web page to send messages and display updates from the hub.
</li></ul>
<p><em>&nbsp; &nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }
}

using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.AspNet.SignalR;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRChat&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ChatHub&nbsp;:&nbsp;Hub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Send(<span class="cs__keyword">string</span>&nbsp;name,&nbsp;<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Call&nbsp;the&nbsp;addNewMessageToPage&nbsp;method&nbsp;to&nbsp;update&nbsp;clients.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clients.All.addNewMessageToPage(name,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Owin;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.Owin;&nbsp;
[assembly:&nbsp;OwinStartup(<span class="cs__keyword">typeof</span>(SignalRChat.Startup))]&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;SignalRChat&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Startup&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Configuration(IAppBuilder&nbsp;app)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Any&nbsp;connection&nbsp;or&nbsp;hub&nbsp;wire&nbsp;up&nbsp;and&nbsp;configuration&nbsp;should&nbsp;go&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;app.MapSignalR();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ChatHub.cs - This is a implementation of a SignalR hub, which provides the server functionality for the application.</em>
</li><li><em>Startup.cs - This is an implementation of an OWIN startup class, which configures the SignalR route when the application starts.</em>
</li><li><em>Chat.cshtml - This is the web page which hosts the SignalR JavaScript client, which interacts with the server</em>
</li></ul>
<h1>More Information</h1>
<p><em><span>For more information on SignalR and the Getting Started tutorial, see http://www.asp.net/signalr.</span></em></p>
