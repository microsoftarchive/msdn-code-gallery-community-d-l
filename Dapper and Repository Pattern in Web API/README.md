# Dapper and Repository Pattern in Web API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Repository Pattern
- ASP.NET Web API
- Unit of Work
- Dapper
## Topics
- Performance
## Updated
- 11/29/2017
## Description

<h1>Introduction</h1>
<p><em><span>This article will demonstrate about how to get data using</span><span>&nbsp;Dapper and Repository Pattern in Web API&nbsp;</span><span>and how to use&nbsp;</span><span>Dependency Injection using Unit of Work</span><span>&nbsp;in Web API. I will
 show you how to implement&nbsp;</span><span>Generic Repository with Custom Repository</span><span>&nbsp;for CRUD operations.</span></em></p>
<p><em><span><br>
</span></em></p>
<p><em><span><span>Here we are using&nbsp;</span><span>Dapper.Net</span><span>&nbsp;for accessing the data through .net data access provide. So, first question comes in mind is that what is actually a Dapper and Why we use it. So, let move one by one with example.</span></span></em></p>
<p>&nbsp;</p>
<h5>What is Dapper</h5>
<p>It is an&nbsp;<span>ORM [Object Relational Mapper],</span>&nbsp;basically a open source and lightweight&nbsp;ORM for developers who prefer to work with&nbsp;<span>ADO.Net technology</span>. It is in top most ORM which ensures the<span>&nbsp;high performance.</span>&nbsp;Main
 theme to develop&nbsp;it by Stack OverFlow team is the fastest database transaction. It works with both static and dynamic objects. It extends the<span>IDbConnection</span>&nbsp;interface to make connection and execute the database operations.</p>
<h5>What is Web API</h5>
<p><span>Web API&nbsp;</span>is a framework that is used to make HTTP services. As you know, now&nbsp;days we are using mobiles, tablets, apps and different types of services, so Web API is a simple and reliable platform to create&nbsp;<span>HTTP enabled services</span>&nbsp;that
 can reach wide range of clients. It is used to create complete REST services. To know more just visit my article<span>&nbsp;<a href="http://www.c-sharpcorner.com/UploadFile/8a67c0/who-is-winner-web-api-or-wcf/" target="_blank">Who is the Winner Web API or
 WCF</a></span>&nbsp;article on&nbsp;<span><a href="http://www.c-sharpcorner.com/members/mukesh-kumar23" target="_blank">CsharpCorner</a>.</span></p>
<h5>What is Repository Pattern</h5>
<p><span>Repository Pattern</span>&nbsp;is used to create an abstraction layer between Data Access Layerr and Business Logic Layer of an application. Repository directly communicates with data access layer [DAL] and get the data and provides it to business
 logic layer [BAL]. The main advantage to use repository pattern to isolate the data access logic and business logic. So that if you make changes in any of this logic that can't effect directly on other logic. For more information, please gone through by&nbsp;<span><a href="http://www.dotnet-tutorial.com/articles/mvc/how-to-use-repository-pattern-with-asp-net-mvc-with-entity-framework" target="_blank">Repository
 Pattern</a></span>&nbsp;Article.</p>
<p><em><span><span><br>
</span></span></em></p>
<h1><span>Building the Sample</span></h1>
<h5>Web API Project with Data Access Layer</h5>
<p>Now it is time to practical example how to implement Dapper and Repository Pattern with Web API Project. Create a solution name as&nbsp;<span>&quot;DapperAndWebAPI&quot;&nbsp;</span>with a class library project name as&nbsp;<span>&quot;DataAccess&quot;&nbsp;</span>and make
 following folders for differnet activities.</p>
<p><span>Entities:</span>&nbsp;This will contain all the entity class files.</p>
<p><span>Infrastructure:</span>&nbsp;It will include&nbsp;all data access required file like connection class.</p>
<p><span>Repositories:</span>&nbsp;This will include Generic and Custom Repositories.</p>
<p><span>Services:</span>&nbsp;It includes all the business logic related classes.</p>
<p><span>UnitOfWork:</span>&nbsp;This is important folder for this demonstration which includes UnitOfWork Class for transaction.</p>
<p><span>Test API:&nbsp;</span>It is a Web API project for creating HTTP enabled services.</p>
<p><span>Our project structure will be like as following image shown below.</span></p>
<p><span><img id="158653" src="158653-web%20api%20project.png" alt="" width="315" height="561"></span></p>
<p><span><br>
</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>Inside the Infrastructure folder create an interface named as&nbsp;</span><span>IConnectionFactory</span><span>&nbsp;which contains the GetConnection property which returns IDbConnection type connection.</span><span>Implement IConnectionFactory interface
 with ConnectionFactory class</span><span>.</span><span>IDbConnection&nbsp;</span><span>handles all the database connection related queries.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ConnectionFactory&nbsp;:&nbsp;IConnectionFactory&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;connectionString&nbsp;=&nbsp;ConfigurationManager.ConnectionStrings[<span class="cs__string">&quot;DTAppCon&quot;</span>].ConnectionString;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IDbConnection&nbsp;GetConnection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;factory&nbsp;=&nbsp;DbProviderFactories.GetFactory(<span class="cs__string">&quot;System.Data.SqlClient&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;conn&nbsp;=&nbsp;factory.CreateConnection();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.ConnectionString&nbsp;=&nbsp;connectionString;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;conn.Open();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;conn;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h5>Implementation Dapper with Data Access Project</h5>
<p>For add Dapper is with your project, just open Package Manager Console from Tools menu and&nbsp;<span>install Dapper</span>&nbsp;using this command&nbsp;<span>Install-Package Dapper.&nbsp;</span>It will also add and resolve dependent&nbsp;dependencies for
 Dapper. At last it will show successfully installed message for Dapper.</p>
<p><span>Note: Don't forget to select Default Project name as DataAccess.</span></p>
<p><span><img id="158654" src="158654-dapper.png" alt="" width="963" height="232"><br>
</span></p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px; text-align:justify">
<span style="color:#000000">Custom Repository and Implementation</span></h5>
<p style="text-align:justify; color:#505050; font-family:&quot;Segoe UI&quot;,Tahoma,Arial,Helvetica,sans-serif; font-size:15.4px; line-height:21.56px">
Create a new repository class name as&nbsp;<span style="font-weight:bold">&quot;BlogRepository&quot;&nbsp;</span>which implement<span style="font-weight:bold">GenericRepository and IBlogRepository.&nbsp;</span>For this demonstration, I am using Dependency Injection,
 so for creating the object, I am using constructor dependency injection. I have created a GetAllBlogByPageIndex method which will return list of blog using dapper asynchrony. I am here using very popular feature of C# as&nbsp;<span style="font-weight:bold">&quot;Async&quot;
 and &quot;Await&quot;</span>&nbsp;for asyncronous process.</p>
<p style="text-align:justify; color:#505050; font-family:&quot;Segoe UI&quot;,Tahoma,Arial,Helvetica,sans-serif; font-size:15.4px; line-height:21.56px">
Here&nbsp;<span style="font-weight:bold">SqlMapper</span>&nbsp;is&nbsp;<span style="font-weight:bold">Dapper object</span>&nbsp;which provides variety of methods to perform different operation without writing too much of codes.</p>
<p style="text-align:justify; color:#505050; font-family:&quot;Segoe UI&quot;,Tahoma,Arial,Helvetica,sans-serif; font-size:15.4px; line-height:21.56px">
&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;BlogRepository&nbsp;:&nbsp;GenericRepository&lt;Blog&gt;,&nbsp;IBlogRepository&nbsp;
&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IConnectionFactory&nbsp;_connectionFactory;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;BlogRepository(IConnectionFactory&nbsp;connectionFactory)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_connectionFactory&nbsp;=&nbsp;connectionFactory;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;IEnumerable&lt;Blog&gt;&gt;&nbsp;GetAllBlogByPageIndex(int&nbsp;pageIndex,&nbsp;int&nbsp;pageSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;query&nbsp;=&nbsp;<span class="js__string">&quot;usp_GetAllBlogPostByPageIndex&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;param&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DynamicParameters();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;param.Add(<span class="js__string">&quot;@PageIndex&quot;</span>,&nbsp;pageIndex);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;param.Add(<span class="js__string">&quot;@PageSize&quot;</span>,&nbsp;pageSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;list&nbsp;=&nbsp;await&nbsp;SqlMapper.QueryAsync&lt;Blog&gt;(_connectionFactory.GetConnection,&nbsp;query,&nbsp;param,&nbsp;commandType:&nbsp;CommandType.StoredProcedure);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;list;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em>For more information:&nbsp;</em><span style="color:#0000ee"><em><span style="text-decoration:underline">http://www.mukeshkumar.net/articles/web-api/dapper-and-repository-pattern-in-web-api</span></em></span></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:1945px; width:1px; height:1px; overflow:hidden">
</div>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:1945px; width:1px; height:1px; overflow:hidden">
<div style="font-family:Lato,sans-serif; font-size:14px; line-height:22.75px">
<div class="BlogHead Blog-bg" style="display:flex; color:#ffffff; background:#1c94c6">
<div class="BlogHeadContent" style="padding:40px 25px; display:flex">
<h1 class="BlogHeadTitle" style="margin:0px; font-size:35px; font-family:inherit; font-weight:500; line-height:1.1">
<span><a href="http://www.dotnet-tutorial.com/articles/web-api/dapper-and-repository-pattern-in-web-api" style="color:#ffffff; text-decoration:none; font-size:30px; font-weight:bold; background:0px 0px">Dapper and Repository Pattern in Web API</a></span></h1>
<div class="BlogHeadMetas" style="padding-top:25px"><a class="ArticleHead_meta" href="http://dotnet-tutorial.com/members/MukeshKumar" style="color:#428bca; text-decoration:none; background:0px 0px"><span class="ArticleHead_metaIcon"><img src="-mukeshkumar.jpg" alt="Mukesh Kumar" width="45" height="45" style="vertical-align:middle">&nbsp;</span><span style="font-weight:bold; color:white"><span><span>Mukesh
 Kumar</span></span></span>&nbsp;</a><span><em class="fa fa-calendar x_x_x_2x">&nbsp;</em><span><span style="font-weight:bold">Posted :</span>yesterday</span></span>&nbsp;<span><em class="fa fa-eye">&nbsp;</em><span><span style="font-weight:bold">Views
 :</span>25</span></span>
<div class="pull-right" style="float:right!important">
<div style="float:right"><span class="btn btn-default" style="display:inline-block; padding:6px 12px; margin-bottom:0px; line-height:1.42857; text-align:center; white-space:nowrap; vertical-align:middle; border:1px solid #cccccc; color:#428bca; background-color:#ffffff">Web
 API</span></div>
</div>
</div>
</div>
</div>
<br>
<div class="pull-right" style="float:right!important">
<div><a title="Share on Facebook" href="https://www.facebook.com/sharer/sharer.php?u=http%3a%2f%2fwww.dotnet-tutorial.com%2farticles%2fweb-api%2fdapper-and-repository-pattern-in-web-api" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-facebook.png" alt="" width="32" height="32" style="vertical-align:middle"></a>&nbsp;<a title="Share on Twitter" href="https://twitter.com/intent/tweet?text=Dapper&#43;and&#43;Repository&#43;Pattern&#43;in&#43;Web&#43;API&#43;-&#43;Dotnet&#43;Tutorial&#43;http%3a%2f%2fwww.dotnet-tutorial.com%2farticles%2fweb-api%2fdapper-and-repository-pattern-in-web-api&source=Dotnet%20Tutorial" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-twitter.png" alt="" width="32" height="32" style="vertical-align:middle"></a>&nbsp;<a title="Share on Google&#43;" href="https://plus.google.com/share?url=http%3a%2f%2fwww.dotnet-tutorial.com%2f%2farticles%2fweb-api%2fdapper-and-repository-pattern-in-web-api" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-google.png" alt="" width="32" height="32" style="vertical-align:middle"></a>&nbsp;<a title="Share on LinkedIn" href="http://www.linkedin.com/shareArticle?mini=true&url=http%3a%2f%2fwww.dotnet-tutorial.com%2farticles%2fweb-api%2fdapper-and-repository-pattern-in-web-api&title=Dapper&#43;and&#43;Repository&#43;Pattern&#43;in&#43;Web&#43;API&#43;-&#43;Dotnet&#43;Tutorial&#43;&summary=This&#43;article&#43;will&#43;demonstrate&#43;about&#43;how&#43;to&#43;get&#43;data&#43;using&#43;Dapper&#43;and&#43;Repository&#43;Pattern&#43;in&#43;Web&#43;API&#43;and&#43;how&#43;to&#43;use&#43;Dependency&#43;Injection&#43;using&#43;Unit&#43;of&#43;Work&#43;in&#43;Web&#43;API.&#43;I&#43;will&#43;show&#43;you&#43;how&#43;to&#43;implement&#43;Generic&#43;Repository&#43;with&#43;Custom&#43;Repository&#43;for&#43;CRUD&#43;operations.&source=%20Dotnet%20Tutorial" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-linkedin.png" alt="" width="32" height="32" style="vertical-align:middle"></a>&nbsp;<a title="Share on Pinterest" href="http://pinterest.com/pin/create/button/?url=http%3a%2f%2fwww.dotnet-tutorial.com%2farticles%2fweb-api%2fdapper-and-repository-pattern-in-web-api&description=Dapper&#43;and&#43;Repository&#43;Pattern&#43;in&#43;Web&#43;API&#43;-&#43;Dotnet&#43;Tutorial&#43;" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-pinterest.png" alt="" width="32" height="32" style="vertical-align:middle"></a></div>
</div>
</div>
<span class="articleBody" style="font-family:&quot;Segoe UI&quot;,Tahoma,Arial,Helvetica,sans-serif; font-size:1.1em; line-height:1.4em; color:#505050; text-align:justify">
<p>This article will demonstrate about how to get data using<span style="font-weight:bold">&nbsp;Dapper and Repository Pattern in Web API&nbsp;</span>and how to use&nbsp;<span style="font-weight:bold">Dependency Injection using Unit of Work</span>&nbsp;in Web
 API. I will show you how to implement&nbsp;<span style="font-weight:bold">Generic Repository with Custom Repository</span>&nbsp;for CRUD operations.</p>
<p><a href="http://dotnet-tutorial.com//Upload/Images/270820160510dapper.png" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-270820160510dapper.png" alt="dapper" style="border-width:1px; border-style:solid; vertical-align:middle; height:312.328px; width:616.656px"></a></p>
<p>Here we are using&nbsp;<span style="font-weight:bold">Dapper.Net</span>&nbsp;for accessing the data through .net data access provide. So, first question comes in mind is that what is actually a Dapper and Why we use it. So, let move one by one with example.</p>
<p>&nbsp;</p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
What is Dapper</h5>
<p>It is an&nbsp;<span style="font-weight:bold">ORM [Object Relational Mapper],</span>&nbsp;basically a open source and lightweight&nbsp;ORM for developers who prefer to work with&nbsp;<span style="font-weight:bold">ADO.Net technology</span>. It is in top most
 ORM which ensures the<span style="font-weight:bold">&nbsp;high performance.</span>&nbsp;Main theme to develop&nbsp;it by Stack OverFlow team is the fastest database transaction. It works with both static and dynamic objects. It extends the<span style="font-weight:bold">IDbConnection</span>&nbsp;interface
 to make connection and execute the database operations.</p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
What is Web API</h5>
<p><span style="font-weight:bold">Web API&nbsp;</span>is a framework that is used to make HTTP services. As you know, now&nbsp;days we are using mobiles, tablets, apps and different types of services, so Web API is a simple and reliable platform to create&nbsp;<span style="font-weight:bold">HTTP
 enabled services</span>&nbsp;that can reach wide range of clients. It is used to create complete REST services. To know more just visit my article<span style="font-weight:bold">&nbsp;<a href="http://www.c-sharpcorner.com/UploadFile/8a67c0/who-is-winner-web-api-or-wcf/" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px">Who
 is the Winner Web API or WCF</a></span>&nbsp;article on&nbsp;<span style="font-weight:bold"><a href="http://www.c-sharpcorner.com/members/mukesh-kumar23" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px">CsharpCorner</a>.</span></p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
What is Repository Pattern</h5>
<p><span style="font-weight:bold">Repository Pattern</span>&nbsp;is used to create an abstraction layer between Data Access Layerr and Business Logic Layer of an application. Repository directly communicates with data access layer [DAL] and get the data and
 provides it to business logic layer [BAL]. The main advantage to use repository pattern to isolate the data access logic and business logic. So that if you make changes in any of this logic that can't effect directly on other logic. For more information, please
 gone through by&nbsp;<span style="font-weight:bold"><a href="http://www.dotnet-tutorial.com/articles/mvc/how-to-use-repository-pattern-with-asp-net-mvc-with-entity-framework" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px">Repository
 Pattern</a></span>&nbsp;Article.</p>
<p>&nbsp;</p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
Web API Project with Data Access Layer</h5>
<p>Now it is time to practical example how to implement Dapper and Repository Pattern with Web API Project. Create a solution name as&nbsp;<span style="font-weight:bold">&quot;DapperAndWebAPI&quot;&nbsp;</span>with a class library project name as&nbsp;<span style="font-weight:bold">&quot;DataAccess&quot;&nbsp;</span>and
 make following folders for differnet activities.</p>
<p><span style="font-weight:bold">Entities:</span>&nbsp;This will contain all the entity class files.</p>
<p><span style="font-weight:bold">Infrastructure:</span>&nbsp;It will include&nbsp;all data access required file like connection class.</p>
<p><span style="font-weight:bold">Repositories:</span>&nbsp;This will include Generic and Custom Repositories.</p>
<p><span style="font-weight:bold">Services:</span>&nbsp;It includes all the business logic related classes.</p>
<p><span style="font-weight:bold">UnitOfWork:</span>&nbsp;This is important folder for this demonstration which includes UnitOfWork Class for transaction.</p>
<p><span style="font-weight:bold">Test API:&nbsp;</span>It is a Web API project for creating HTTP enabled services.</p>
<p>&nbsp;</p>
<p>Our project structure will be like as following image shown below.</p>
<p><a href="http://dotnet-tutorial.com//Upload/Images/250820161125web%20api%20project.PNG" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-250820161125web%20api%20project.png" alt="" style="border-width:1px; border-style:solid; vertical-align:middle; height:877px; width:493.313px"></a></p>
<p>&nbsp;</p>
<p>Inside the Infrastructure folder create an interface named as&nbsp;<span style="font-weight:bold">IConnectionFactory</span>&nbsp;which contains the GetConnection property which returns IDbConnection type connection.<span style="font-weight:bold">Implement
 IConnectionFactory interface with ConnectionFactory class</span>.<span style="font-weight:bold">IDbConnection&nbsp;</span>handles all the database connection related queries.</p>
<pre style="overflow:auto; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:14px; margin:0px 0px 10px; line-height:1.42857; color:#333333; word-break:break-all; word-wrap:break-word; border:1px solid #cccccc; background-color:#f5f5f5"><code class="language-cs x_x_x_hljs" style="font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:inherit; padding:1em; color:inherit; white-space:pre-wrap; display:block; overflow-x:auto; line-height:18pt; border-left:5px solid #4466c5; background:#f0f0f0"><span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">class</span> <span class="hljs-title" style="color:#a31515">ConnectionFactory</span> : <span class="hljs-title" style="color:#a31515">IConnectionFactory</span>
{
        <span class="hljs-keyword" style="color:#0000ff">private</span> <span class="hljs-keyword" style="color:#0000ff">readonly</span> <span class="hljs-keyword" style="color:#0000ff">string</span> connectionString = ConfigurationManager.ConnectionStrings[<span class="hljs-string" style="color:#a31515">&quot;DTAppCon&quot;</span>].ConnectionString;
        <span class="hljs-keyword" style="color:#0000ff">public</span> IDbConnection GetConnection
        {
            <span class="hljs-keyword" style="color:#0000ff">get</span>
            {
                <span class="hljs-keyword" style="color:#0000ff">var</span> factory = DbProviderFactories.GetFactory(<span class="hljs-string" style="color:#a31515">&quot;System.Data.SqlClient&quot;</span>);
                <span class="hljs-keyword" style="color:#0000ff">var</span> conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                <span class="hljs-keyword" style="color:#0000ff">return</span> conn;
            }
        }
}</code></pre>
<p>&nbsp;</p>
<p>Create two entity classes as named<span style="font-weight:bold">&nbsp;&quot;Blog&quot;</span>&nbsp;and&nbsp;<span style="font-weight:bold">&quot;Category&quot;</span>&nbsp;inside the Entities folder which contains the characters for Blog and Category classes as following.
 All the sample classes we can find from Download Source.</p>
<pre style="overflow:auto; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:14px; margin:0px 0px 10px; line-height:1.42857; color:#333333; word-break:break-all; word-wrap:break-word; border:1px solid #cccccc; background-color:#f5f5f5"><code class="language-cs x_x_x_hljs" style="font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:inherit; padding:1em; color:inherit; white-space:pre-wrap; display:block; overflow-x:auto; line-height:18pt; border-left:5px solid #4466c5; background:#f0f0f0"> <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">class</span> <span class="hljs-title" style="color:#a31515">Blog</span>
 {
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">int</span> PostId { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> PostTitle { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> ShortPostContent { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> FullPostContent { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> MetaKeywords { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> MetaDescription { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> DateTime PostAddedDate { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> DateTime PostUpdatedDate { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">bool</span> IsCommented { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">bool</span> IsShared { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">bool</span> IsPrivate { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">int</span> NumberOfViews { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }       
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">string</span> PostUrl { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">virtual</span> <span class="hljs-keyword" style="color:#0000ff">int</span> CategoryId { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
        <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">virtual</span> Category Categories { <span class="hljs-keyword" style="color:#0000ff">get</span>; <span class="hljs-keyword" style="color:#0000ff">set</span>; }
      
 }</code></pre>
<p>&nbsp;</p>
<p>Now it is time to create repositories, so first we will create&nbsp;<span style="font-weight:bold">GenericRepository&nbsp;</span>which will include all the common methods which can be used for CRUD operations like Add, Delete and&nbsp;Update etc.</p>
<div style="border:1px solid #cccccc; padding:5px 10px; background:#eeeeee"><span style="font-weight:bold">Note: Best practice when we are working with Repository to create Interface and implement it with class for remove complexity and make methods reusable.</span></div>
<p>&nbsp;</p>
<pre style="overflow:auto; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:14px; margin:0px 0px 10px; line-height:1.42857; color:#333333; word-break:break-all; word-wrap:break-word; border:1px solid #cccccc; background-color:#f5f5f5"><code class="language-cs x_x_x_hljs" style="font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:inherit; padding:1em; color:inherit; white-space:pre-wrap; display:block; overflow-x:auto; line-height:18pt; border-left:5px solid #4466c5; background:#f0f0f0"><span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">interface</span> <span class="hljs-title" style="color:#a31515">IGenericRepository</span>&lt;<span class="hljs-title" style="color:#a31515">TEntity</span>&gt; <span class="hljs-title" style="color:#a31515">where</span> <span class="hljs-title" style="color:#a31515">TEntity</span> : <span class="hljs-title" style="color:#a31515">class</span>
{
        <span class="hljs-function">TEntity <span class="hljs-title" style="color:#a31515">Get</span><span class="hljs-params">(<span class="hljs-keyword" style="color:#0000ff">int</span> Id)</span></span>;
        <span class="hljs-function">IEnumerable&lt;TEntity&gt; <span class="hljs-title" style="color:#a31515">GetAll</span><span class="hljs-params">()</span></span>;
        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Add</span><span class="hljs-params">(TEntity entity)</span></span>;
        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Delete</span><span class="hljs-params">(TEntity entity)</span></span>;
        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Update</span><span class="hljs-params">(TEntity entity)</span></span>;
}</code></pre>
<p>&nbsp;</p>
<p>Following class as name&nbsp;<span style="font-weight:bold">&quot;GenericRepository&quot;</span>&nbsp;is implementing the&nbsp;<span style="font-weight:bold">IGenericRepository</span>. I am not here adding the implementation code here because I am using Custom Repository
 for this demonstration. You can implement it if you require.</p>
<pre style="overflow:auto; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:14px; margin:0px 0px 10px; line-height:1.42857; color:#333333; word-break:break-all; word-wrap:break-word; border:1px solid #cccccc; background-color:#f5f5f5"><code class="language-cs x_x_x_hljs" style="font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace; font-size:inherit; padding:1em; color:inherit; white-space:pre-wrap; display:block; overflow-x:auto; line-height:18pt; border-left:5px solid #4466c5; background:#f0f0f0"> <span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">class</span> <span class="hljs-title" style="color:#a31515">GenericRepository</span>&lt;<span class="hljs-title" style="color:#a31515">TEntity</span>&gt; : <span class="hljs-title" style="color:#a31515">IGenericRepository</span>&lt;<span class="hljs-title" style="color:#a31515">TEntity</span>&gt; <span class="hljs-title" style="color:#a31515">where</span> <span class="hljs-title" style="color:#a31515">TEntity</span> : <span class="hljs-title" style="color:#a31515">class</span>
 {
        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Add</span><span class="hljs-params">(TEntity entity)</span>
        </span>{
            <span class="hljs-keyword" style="color:#0000ff">throw</span> <span class="hljs-keyword" style="color:#0000ff">new</span> NotImplementedException();
        }

        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Delete</span><span class="hljs-params">(TEntity entity)</span>
        </span>{
            <span class="hljs-keyword" style="color:#0000ff">throw</span> <span class="hljs-keyword" style="color:#0000ff">new</span> NotImplementedException();
        }

        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">public</span> <span class="hljs-keyword" style="color:#0000ff">void</span> <span class="hljs-title" style="color:#a31515">Update</span><span class="hljs-params">(TEntity entity)</span>
        </span>{
            <span class="hljs-keyword" style="color:#0000ff">throw</span> <span class="hljs-keyword" style="color:#0000ff">new</span> NotImplementedException();
        }

        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">public</span> TEntity <span class="hljs-title" style="color:#a31515">Get</span><span class="hljs-params">(<span class="hljs-keyword" style="color:#0000ff">int</span> Id)</span>
        </span>{
            <span class="hljs-keyword" style="color:#0000ff">throw</span> <span class="hljs-keyword" style="color:#0000ff">new</span> NotImplementedException();
        }

        <span class="hljs-function"><span class="hljs-keyword" style="color:#0000ff">public</span> IEnumerable&lt;TEntity&gt; <span class="hljs-title" style="color:#a31515">GetAll</span><span class="hljs-params">()</span>
        </span>{
            <span class="hljs-keyword" style="color:#0000ff">throw</span> <span class="hljs-keyword" style="color:#0000ff">new</span> NotImplementedException();
        }
 }</code></pre>
<p>&nbsp;</p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
Implementation Dapper with Data Access Project</h5>
<p>For add Dapper is with your project, just open Package Manager Console from Tools menu and&nbsp;<span style="font-weight:bold">install Dapper</span>&nbsp;using this command&nbsp;<span style="font-weight:bold">Install-Package Dapper.&nbsp;</span>It will also
 add and resolve dependent&nbsp;dependencies for Dapper. At last it will show successfully installed message for Dapper.</p>
<p><span style="font-weight:bold">Note: Don't forget to select Default Project name as DataAccess.</span></p>
<p><a href="http://dotnet-tutorial.com//Upload/Images/250820161153dapper.PNG" target="_blank" style="color:#428bca; text-decoration:none; background:0px 0px"><img src="-250820161153dapper.png" alt="" style="border-width:1px; border-style:solid; vertical-align:middle; height:150.078px; width:616.656px"></a></p>
<p>&nbsp;</p>
<h5 style="font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-weight:normal; line-height:30px; color:#4466c5; margin:10px 0px; font-size:24px; padding-left:0px">
Custom Repository and Implementation</h5>
<p>Create a new repository class name as&nbsp;<span style="font-weight:bold">&quot;BlogRepository&quot;&nbsp;</span>which implement<span style="font-weight:bold">GenericRepository and IBlogRepository.&nbsp;</span>For this demonstration, I am using Dependency Injection,
 so for creating the object, I am using constructor dependency injection. I have created a GetAllBlogByPageIndex method which will return list of blog using dapper asynchrony. I am here using very popular feature of C# as&nbsp;<span style="font-weight:bold">&quot;Async&quot;
 and &quot;Await&quot;</span>&nbsp;for asyncronous process.</p>
<p>Here&nbsp;<span style="font-weight:bold">SqlMapper</span>&nbsp;is&nbsp;<span style="font-weight:bold">Dapper object</span>&nbsp;which provides variety of methods to perform different operation without writing too much of codes.</p>
</span></div>
