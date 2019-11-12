# Entity Framework Core Code  First Approach
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- Entity Framework Code First
- ASP.NET MVC Core
## Topics
- ADO.NET Entity Framework Code First
## Updated
- 05/12/2017
## Description

<h1>Introduction</h1>
<p><em><span>In this article we will discuss how to create an Application using Entity Framework Code First Approach. In Code First approach&nbsp;</span><span>&nbsp;</span><span>rather than designing your database first we create context classes and Code-First
 APIs maps classes to database and</span><span>&nbsp;create database on fly&nbsp;</span><span>using default code-first conventions.</span><br>
</em></p>
<h1>Description</h1>
<p class="firstpara">In this article we will discuss how to create an Application using Entity Framework Code First Approach. In Code First approach&nbsp;<span>&nbsp;</span><span>rather than designing your database first we create context classes and Code-First
 APIs maps classes to database and</span>&nbsp;create database on fly&nbsp;<span>using default code-first conventions.</span></p>
<h5><span><span>Create MVC Core Project-&gt;</span></span></h5>
<h5><span><span>Select Web Application Template with No Authentication and hit OK</span>.</span></h5>
<ol>
<li>Right click on the<span>&nbsp;Solution Explorer</span>&nbsp;and select&nbsp;<span>Add&nbsp;</span>-&gt;&nbsp;<span>New Folder</span>&nbsp;and &nbsp;Enter&nbsp;<span>Models&nbsp;</span>as the name of the folder.
</li><li>Right click on the&nbsp;<span>Models&nbsp;</span>folder and select&nbsp;<span>Add&nbsp;</span>-&gt;&nbsp;<span>Class&nbsp;</span>and&nbsp;Enter&nbsp;<span>Article.cs</span>&nbsp;as the name of class and click OK.
</li><li>Paste Following code in&nbsp;<span>Article.cs</span>. </li></ol>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;EFCodeFirstCore.Model&nbsp;
{&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Article&nbsp;
{&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ArticleText&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}&nbsp;
}</pre>
</div>
</div>
</div>
<p><span>Click on&nbsp;</span><span>Tools</span><span>-&gt;</span><span>NuGet Package Manager</span><span>&nbsp;-&gt;</span><span>Package Manager Console</span></p>
<p><span>Install following package in your application.&nbsp;</span></p>
<p><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">Install-Package&nbsp;Microsoft.EntityFrameworkCore.SqlServer&nbsp;
Install-Package&nbsp;Microsoft.EntityFrameworkCore.Tools</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<ol class="orderlist">
<li>Right click on the<span>&nbsp;Solution Explorer</span>&nbsp;and select&nbsp;<span>Add&nbsp;</span>-&gt;&nbsp;<span>New Folder</span>&nbsp;and &nbsp;Enter&nbsp;<span>Data&nbsp;</span>as the name of the folder.
</li><li>Right click on the&nbsp;<span>Models&nbsp;</span>folder and select&nbsp;<span>Add&nbsp;</span>-&gt;&nbsp;<span>Class&nbsp;</span>and&nbsp;Enter&nbsp;<span>ApplicationDBContext</span><span>.cs</span>&nbsp;as the name of class and click OK.
</li><li>Paste Following code in&nbsp;<span>ApplicationDBContext.cs</span>. </li></ol>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">namespace&nbsp;EFCodeFirstCore.Data&nbsp;
<span class="js__brace">{</span>&nbsp;
public&nbsp;class&nbsp;ApplicationDBContext:&nbsp;DbContext&nbsp;
<span class="js__brace">{</span>&nbsp;
public&nbsp;ApplicationDBContext(DbContextOptions&lt;ApplicationDBContext&gt;&nbsp;options)&nbsp;:&nbsp;base(options)&nbsp;
<span class="js__brace">{</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
public&nbsp;DbSet&lt;Article&gt;&nbsp;Articles&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<p><span>To use&nbsp;</span><span><span>ApplicationDBContext&nbsp;</span>you have to register this in&nbsp;</span><span style="color:#333333; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace"><span><span>Startup.cs</span>&nbsp;class in&nbsp;<span>ConfigureServices&nbsp;</span>methods.</span></span></p>
<p><span style="color:#333333; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace"><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;ConfigureServices(IServiceCollection&nbsp;services)&nbsp;
<span class="js__brace">{</span>&nbsp;
services.AddMvc();&nbsp;
<span class="js__statement">var</span>&nbsp;connection&nbsp;=&nbsp;@<span class="js__string">&quot;Server=(localdb)\\mssqllocaldb;Database=EFCodeFirstCore;Trusted_Connection=True;MultipleActiveResultSets=true&quot;</span>;&nbsp;
services.AddDbContext&lt;ApplicationDBContext&gt;(options&nbsp;=&gt;&nbsp;options.UseSqlServer(connection));&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="color:#333333; font-family:Menlo,Monaco,Consolas,&quot;Courier New&quot;,monospace"><span>Now Go to Package Manager Console and Add Migration with name&nbsp;</span></span><span>FirstMigration</span><span>&nbsp;</span>&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">Add-Migration&nbsp;FirstMigration</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span>Now Update you Database.</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">update-database&nbsp;-Verbose</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Your Database is created.</div>
<br>
</span></span>
<p></p>
</div>
<br>
</span>
<p></p>
