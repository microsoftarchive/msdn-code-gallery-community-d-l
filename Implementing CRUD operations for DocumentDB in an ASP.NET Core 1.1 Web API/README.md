# Implementing CRUD operations for DocumentDB in an ASP.NET Core 1.1 Web API
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- ASP.NET Web API
- Azure DocumentDB
- ASP.NET Core
- Visual Studio 2017
## Topics
- ASP.NET Web API
- Dependancy Injection
- ASP.NET Core
- Visual Studio 2017
## Updated
- 03/03/2017
## Description

<h1>Introduction</h1>
<p>This sample is a .NET Core 1.1 Web API that uses the NuGet DocumentDB.Core client library to &nbsp;Create, Read, Update and Delete orders. The project is created in Visual Studio 2017. The sample can easy be modified for other type of objects.&nbsp;</p>
<p>The DocumentDB.Core client library enables client applications targeting .NET Core to connect to the Azure DocumentDB service. Azure DocumentDB is a NoSQL document database hosted in Microsoft Azure and delivered as a service.&nbsp;</p>
<p>&nbsp;</p>
<h2>Add a model class</h2>
<p>A model is an object that represents the data in your application. In this case, the models used are a Server Order and a Client Order.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ServerOrder&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;id&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Customer&nbsp;customer&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Item&nbsp;item&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;OrderStatus&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;ModifiedDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;CreationDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<ul>
</ul>
<h2>Add a repository class</h2>
<p>A repository is an object that encapsulates the data layer. The repository contains logic for retrieving and mapping data to an entity model. This sample uses DocumentDB as database.</p>
<p><br>
Defining a repository interface named IOrderRepository. The interface defines basic CRUD operations.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IOrderRepository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Add(ClientOrder&nbsp;order);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServerOrder&nbsp;Find(<span class="cs__keyword">string</span>&nbsp;key);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Update(<span class="cs__keyword">string</span>&nbsp;id,&nbsp;ClientOrder&nbsp;order);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Remove(<span class="cs__keyword">string</span>&nbsp;id);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">Add a OrderRepository class that implements IOrderRepository:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;OrderRepository&nbsp;:&nbsp;IOrderRepository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;DocumentClient&nbsp;client;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;OrderDbSettings&nbsp;_settings;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;OrderRepository(IOptions&lt;OrderDbSettings&gt;&nbsp;settings)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_settings&nbsp;=&nbsp;settings.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;AddOrderToCollection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;async&nbsp;Task&lt;<span class="cs__keyword">string</span>&gt;&nbsp;Add(ClientOrder&nbsp;order)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;a&nbsp;server&nbsp;order&nbsp;with&nbsp;extra&nbsp;properties</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServerOrder&nbsp;s&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServerOrder();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.customer&nbsp;=&nbsp;order.customer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.item&nbsp;=&nbsp;order.item;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Add&nbsp;meta&nbsp;data&nbsp;to&nbsp;the&nbsp;order</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.OrderStatus&nbsp;=&nbsp;<span class="cs__string">&quot;in&nbsp;progress&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;s.CreationDate&nbsp;=&nbsp;DateTime.UtcNow;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Get&nbsp;a&nbsp;Document&nbsp;client</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentClient(<span class="cs__keyword">new</span>&nbsp;Uri(_settings.EndpointUrl),&nbsp;_settings.AuthorizationKey))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pathLink&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Format(<span class="cs__string">&quot;dbs/{0}/colls/{1}&quot;</span>,&nbsp;_settings.DatabaseId,&nbsp;_settings.CollectionId);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResourceResponse&lt;Document&gt;&nbsp;doc&nbsp;=&nbsp;await&nbsp;client.CreateDocumentAsync(pathLink,&nbsp;s);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Return&nbsp;the&nbsp;created&nbsp;id</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;id&nbsp;=&nbsp;doc.Resource.Id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;id;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;
....</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h2 class="endscriptcode">Register the repository</h2>
<div class="endscriptcode">By defining a repository interface, we can decouple the repository class from the MVC controller that uses it. Instead of instantiating a OrderRepository inside the controller, an IOrderRepository is injected using the built-in
 support in ASP.NET.<br>
In the ConfigureServices method in the Startup class, the following code is added:</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;This&nbsp;method&nbsp;gets&nbsp;called&nbsp;by&nbsp;the&nbsp;runtime.&nbsp;Use&nbsp;this&nbsp;method&nbsp;to&nbsp;add&nbsp;services&nbsp;to&nbsp;the&nbsp;container.</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;framework&nbsp;services.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.Configure&lt;OrderDbSettings&gt;(Configuration.GetSection(<span class="cs__string">&quot;DocumentDbSettings&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddMvc();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;services.AddScoped&lt;IOrderRepository,&nbsp;OrderRepository&gt;();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<h1 class="endscriptcode">Testing</h1>
<div class="endscriptcode">Use a tool&nbsp;<span>like Postman to test the API App.</span></div>
<div class="endscriptcode"><img id="170608" src="170608-postman%20post%20request.png" alt="" width="1209" height="1053"></div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>More Information</h1>
<p><em>For more information on building a Web API with ASP.NET Core MVC and Visual Studio, see:</em></p>
<p><em><a title="Building Your First Web API with ASP.NET Core MVC and Visual Studio" href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api">https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api</a><br>
</em></p>
