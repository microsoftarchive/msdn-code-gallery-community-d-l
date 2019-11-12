# Getting Started with ASP.NET Web API (Tutorial Sample)
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- Web API
## Updated
- 10/22/2013
## Description

<div>Sample&nbsp;code for the following tutorial on asp.net:</div>
<div></div>
<div></div>
<div><span style="font-size:large"><a href="http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api">Getting Started with ASP.NET Web API</a></span></div>
<div></div>
<div></div>
<div><span style="color:#3366ff; font-size:large">Excerpt from the tutorial:</span></div>
<div>&nbsp;</div>
<div>
<p>HTTP is not just for serving up web pages. It is also a powerful platform for building APIs that expose services and data. HTTP is simple, flexible, and ubiquitous. Almost any platform that you can think of has an HTTP library, so HTTP services can reach
 a broad range of clients, including browsers, mobile devices, and traditional desktop applications.</p>
<p>ASP.NET Web API is a framework for building web APIs on top of the .NET Framework. In this tutorial, you will use ASP.NET Web API to create a web API that returns a list of products. The front-end web page uses jQuery to display the results.</p>
<h3>Requirements</h3>
<p>This tutorial uses <a href="http://go.microsoft.com/fwlink/?LinkId=306566">Visual Studio 2013</a>.</p>
<h3>Create a Web API Project</h3>
<p>Start Visual Studio and select <strong>New Project</strong> from the strong&gt;Start page. Or, from the
<strong>File</strong> menu, select strong&gt;New and then <strong>Project</strong>.</p>
<p>In the <strong>Templates</strong> pane, select <strong>Installed Templates</strong>&nbsp;and expand the
<strong>Visual C#</strong> node. Under <strong>Visual C#</strong>,&nbsp;select <strong>
Web</strong>. In the list of project templates, select <strong>ASP.NET Web Application</strong>. Name the project &quot;ProductsApp&quot; and&nbsp;click
<strong>OK</strong>.</p>
<p>In the <strong>New ASP.NET Project</strong> dialog, select the <strong>Empty</strong> template. Under &quot;Add folders and core references for&quot;, check
<strong>Web API</strong>. Click <strong>OK</strong>.</p>
<h3>Adding a Model</h3>
<p>A <em>model</em> is an object that represents the data in your application ASP.NET Web API can automatically serialize your model to JSON, XML, or some other format, and then write the serialized data into the body of the HTTP response message. As long as
 a client can read the serialization format, it can deserialize the object. Most clients can parse either XML or JSON. Moreover, the client can indicate which format it wants by setting the Accept header in the HTTP request message.</p>
<p>Let's start by creating a simple model that represents a product.</p>
<p>If Solution Explorer is not already visible, click the <strong>View</strong> menu and select
<strong>Solution Explorer</strong>. In Solution Explorer, right-click the Models folder. From the context menu, select
<strong>Add</strong>Class.</p>
</div>
<div>&nbsp;</div>
