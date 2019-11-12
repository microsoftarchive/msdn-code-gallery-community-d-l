# jQuery Datatable With Server Side Data
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- ASP.NET
- ASP.NET MVC
- jQuery
## Topics
- Development
- Web Development
## Updated
- 02/19/2016
## Description

<p><span style="font-size:small">In this article we will learn how we can work with jQuery Datatables with server side data. Here we are going to use a MVC application with&nbsp;<a href="http://sibeeshpassion.com/category/jquery/" target="_blank">jQuery&nbsp;</a>&nbsp;and
 other required packages installed in it. If you are new to MVC, You can always get the tips/tricks/blogs about that here<a href="http://sibeeshpassion.com/category/mvc/" target="_blank">MVC Tips, Tricks, Blogs</a>. jQuery Datatables is a client side grid control
 which is lightweight and easy to use. But when it comes to a grid control, it must be usable when it supports the server side loading of data. This control is perfect for that. I guess, it is enough for the introduction. Now we will start using our grid. I
 hope you will like this.</span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:small">Create a MVC application</span></strong></p>
<p><span style="font-size:small">Click File-&gt; New-&gt; Project then select MVC application. Before going to start the coding part, make sure that all the required extensions/references are installed. Below are the required things to start with.</span></p>
<li><span style="font-size:small">Datatables Package</span> </li><li><span style="font-size:small">jQuery</span>
<p><span style="font-size:small">You can all the items mentioned above from NuGet. Right click on your project name and select Manage NuGet packages.</span></p>
<div class="wp-caption x_x_alignnone" id="attachment_11235"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/02/Manage-NuGet-Package-Window-e1455700665396.png"><img class="size-full x_x_wp-image-11235" src="-manage-nuget-package-window-e1455700665396.png" alt="Manage NuGet Package Window" width="650" height="432"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Manage NuGet Package Window</span></p>
</div>
<p><span style="font-size:small">Once you have installed those items, please make sure that all the items(jQuery, Datatables JS files) are loaded in your scripts folder.</span></p>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">Now let us add the needed references.</span></p>
<p><span style="font-size:small"><em>Include the references in your _Layout.cshtml</em></span></p>
<p><span style="font-size:small">As we have already installed all the packages we need, now we need to add the references, right? After adding the reference, your _Layout.cshtml will looks like below.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_601677">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&nbsp;
&lt;html&gt;&nbsp;
&lt;head&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;charset=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;meta&nbsp;name=<span class="js__string">&quot;viewport&quot;</span>&nbsp;content=<span class="js__string">&quot;width=device-width,&nbsp;initial-scale=1.0&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;title&gt;@ViewBag.Title&nbsp;-&nbsp;My&nbsp;ASP.NET&nbsp;Application&lt;/title&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/Site.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/bootstrap.min.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;type=<span class="js__string">&quot;text/css&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;link&nbsp;href=<span class="js__string">&quot;~/Content/DataTables/css/jquery.dataTables.min.css&quot;</span>&nbsp;rel=<span class="js__string">&quot;stylesheet&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/modernizr-2.6.2.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/scripts/jquery-2.2.0.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/scripts/jquery-ui-1.10.2.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/scripts/DataTables/jquery.dataTables.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/scripts/MyScripts.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/Scripts/bootstrap.min.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
&lt;/head&gt;&nbsp;
&lt;body&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar&nbsp;navbar-inverse&nbsp;navbar-fixed-top&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;container&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar-header&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;navbar-toggle&quot;</span>&nbsp;data-toggle=<span class="js__string">&quot;collapse&quot;</span>&nbsp;data-target=<span class="js__string">&quot;.navbar-collapse&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;span&nbsp;class=<span class="js__string">&quot;icon-bar&quot;</span>&gt;&lt;/span&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/button&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@Html.ActionLink(<span class="js__string">&quot;jQuery&nbsp;Datatable&nbsp;With&nbsp;Server&nbsp;Side&nbsp;Data&quot;</span>,&nbsp;<span class="js__string">&quot;Index&quot;</span>,&nbsp;<span class="js__string">&quot;Home&quot;</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;area&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;@class&nbsp;=&nbsp;<span class="js__string">&quot;navbar-brand&quot;</span>&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;navbar-collapse&nbsp;collapse&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&nbsp;class=<span class="js__string">&quot;nav&nbsp;navbar-nav&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;container&nbsp;body-content&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@RenderBody()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;footer&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;&amp;copy;&nbsp;@DateTime.Now.Year&nbsp;-&nbsp;&lt;a&nbsp;href=<span class="js__string">&quot;http://sibeeshpassion.com&quot;</span>&gt;Sibeesh&nbsp;Passion&lt;<span class="js__reg_exp">/a&gt;&lt;/</span>p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/footer&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&lt;/body&gt;&nbsp;
&lt;/html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here&nbsp;<em>MyScripts.js</em>&nbsp;is the JavaScript file where we are going to write our own scripts.</span></p>
<p><span style="font-size:small"><em>Add a normal MVC controller</em></span></p>
<p><span style="font-size:small">Now we will add a normal MVC controller in our app. Once you add that you can see an ActionResult is created for us.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_361154">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Right click on the controller, and click add view, that will create a View for you. Now we will change the view as follows.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_235232">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;jQuery&nbsp;Datatable&nbsp;With&nbsp;Server&nbsp;Side&nbsp;Data&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&lt;h2&gt;jQuery&nbsp;Datatable&nbsp;With&nbsp;Server&nbsp;Side&nbsp;Data&lt;/h2&gt;&nbsp;
&nbsp;&nbsp;
&lt;table&nbsp;id=<span class="js__string">&quot;myGrid&quot;</span>&nbsp;class=<span class="js__string">&quot;table&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;SalesOrderID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;SalesOrderDetailID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;CarrierTrackingNumber&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;OrderQty&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;ProductID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;UnitPrice&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tfoot&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;SalesOrderID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;SalesOrderDetailID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;CarrierTrackingNumber&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;OrderQty&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;ProductID&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;UnitPrice&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tfoot&gt;&nbsp;
&lt;/table&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">So we have set the headers and footer for our grid, where we are going to load the grid control in the table&nbsp;<em>myGrid</em>.</span></p>
<p><span style="font-size:small">So far the UI part is done, now it is time to set up our database and entity model. Are you ready?</span></p>
<p><strong><span style="font-size:small">Create a database</span></strong></p>
<p><span style="font-size:small">The following query can be used to create a database in your SQL Server.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_627714"><br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[master]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Database&nbsp;[TrialsDB]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">17</span>-Feb<span class="js__num">-16</span>&nbsp;<span class="js__num">10</span>:<span class="js__num">21</span>:<span class="js__num">17</span>&nbsp;PM&nbsp;******/&nbsp;
CREATE&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;
&nbsp;CONTAINMENT&nbsp;=&nbsp;NONE&nbsp;
&nbsp;ON&nbsp;&nbsp;PRIMARY&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB.mdf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;3072KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;UNLIMITED,&nbsp;FILEGROWTH&nbsp;=&nbsp;1024KB&nbsp;)&nbsp;
&nbsp;LOG&nbsp;ON&nbsp;
(&nbsp;NAME&nbsp;=&nbsp;N<span class="js__string">'TrialsDB_log'</span>,&nbsp;FILENAME&nbsp;=&nbsp;N<span class="js__string">'C:\Program&nbsp;Files\Microsoft&nbsp;SQL&nbsp;Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TrialsDB_log.ldf'</span>&nbsp;,&nbsp;SIZE&nbsp;=&nbsp;1024KB&nbsp;,&nbsp;MAXSIZE&nbsp;=&nbsp;2048GB&nbsp;,&nbsp;FILEGROWTH&nbsp;=&nbsp;<span class="js__num">10</span>%)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;COMPATIBILITY_LEVEL&nbsp;=&nbsp;<span class="js__num">110</span>&nbsp;
GO&nbsp;
&nbsp;&nbsp;
IF&nbsp;(<span class="js__num">1</span>&nbsp;=&nbsp;FULLTEXTSERVICEPROPERTY(<span class="js__string">'IsFullTextInstalled'</span>))&nbsp;
begin&nbsp;
EXEC&nbsp;[TrialsDB].[dbo].[sp_fulltext_database]&nbsp;@action&nbsp;=&nbsp;<span class="js__string">'enable'</span>&nbsp;
end&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULL_DEFAULT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_NULLS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_PADDING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ANSI_WARNINGS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ARITHABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CLOSE&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_CREATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_SHRINK&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_CLOSE_ON_COMMIT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CURSOR_DEFAULT&nbsp;&nbsp;GLOBAL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;CONCAT_NULL_YIELDS_NULL&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;NUMERIC_ROUNDABORT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;QUOTED_IDENTIFIER&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECURSIVE_TRIGGERS&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;DISABLE_BROKER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;AUTO_UPDATE_STATISTICS_ASYNC&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DATE_CORRELATION_OPTIMIZATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TRUSTWORTHY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;ALLOW_SNAPSHOT_ISOLATION&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PARAMETERIZATION&nbsp;SIMPLE&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;READ_COMMITTED_SNAPSHOT&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;HONOR_BROKER_PRIORITY&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;RECOVERY&nbsp;FULL&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;MULTI_USER&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;PAGE_VERIFY&nbsp;CHECKSUM&nbsp;&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;DB_CHAINING&nbsp;OFF&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;FILESTREAM(&nbsp;NON_TRANSACTED_ACCESS&nbsp;=&nbsp;OFF&nbsp;)&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;TARGET_RECOVERY_TIME&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;SECONDS&nbsp;
GO&nbsp;
&nbsp;&nbsp;
ALTER&nbsp;DATABASE&nbsp;[TrialsDB]&nbsp;SET&nbsp;&nbsp;READ_WRITE&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now we will create a table.&nbsp;</span></p>
<p><strong><span style="font-size:small">Create table in database</span></strong></p>
<p><span style="font-size:small">Below is the query to create table in database.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_932190">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[SalesOrderDetail]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">19</span>-Feb<span class="js__num">-16</span>&nbsp;<span class="js__num">12</span>:<span class="js__num">30</span>:<span class="js__num">55</span>&nbsp;PM&nbsp;******/&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
&nbsp;&nbsp;
CREATE&nbsp;TABLE&nbsp;[dbo].[SalesOrderDetail](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SalesOrderID]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SalesOrderDetailID]&nbsp;[int]&nbsp;IDENTITY(<span class="js__num">1</span>,<span class="js__num">1</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[CarrierTrackingNumber]&nbsp;[nvarchar](<span class="js__num">25</span>)&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[OrderQty]&nbsp;[smallint]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ProductID]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SpecialOfferID]&nbsp;[int]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[UnitPrice]&nbsp;[money]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[UnitPriceDiscount]&nbsp;[money]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[LineTotal]&nbsp;&nbsp;AS&nbsp;(isnull(([UnitPrice]*((<span class="js__num">1.0</span>)-[UnitPriceDiscount]))*[OrderQty],(<span class="js__num">0.0</span>))),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[rowguid]&nbsp;[uniqueidentifier]&nbsp;ROWGUIDCOL&nbsp;&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ModifiedDate]&nbsp;[datetime]&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;CONSTRAINT&nbsp;[PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID]&nbsp;PRIMARY&nbsp;KEY&nbsp;CLUSTERED&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SalesOrderID]&nbsp;ASC,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SalesOrderDetailID]&nbsp;ASC&nbsp;
)WITH&nbsp;(PAD_INDEX&nbsp;=&nbsp;OFF,&nbsp;STATISTICS_NORECOMPUTE&nbsp;=&nbsp;OFF,&nbsp;IGNORE_DUP_KEY&nbsp;=&nbsp;OFF,&nbsp;ALLOW_ROW_LOCKS&nbsp;=&nbsp;ON,&nbsp;ALLOW_PAGE_LOCKS&nbsp;=&nbsp;ON)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
)&nbsp;ON&nbsp;[PRIMARY]&nbsp;
&nbsp;&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><strong><span style="font-size:small">Insert data to table</span></strong></p>
<p><span style="font-size:small">To insert the data, I will attach a database script file along with the download file, you can either run that or insert some data by using the below query. By the way if you would like to know how to generate scripts with data
 in SQL Server, you can check&nbsp;<a href="http://sibeeshpassion.com/generate-database-scripts-with-data-in-sql-server/" target="_blank">here</a>.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_135390">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
&nbsp;&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[SalesOrderDetail]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([SalesOrderID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[CarrierTrackingNumber]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[OrderQty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[ProductID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[SpecialOfferID]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[UnitPrice]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[UnitPriceDiscount]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[rowguid]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[ModifiedDate])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VALUES&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&lt;SalesOrderID,&nbsp;int,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;CarrierTrackingNumber,&nbsp;nvarchar(<span class="js__num">25</span>),&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;OrderQty,&nbsp;smallint,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;ProductID,&nbsp;int,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;SpecialOfferID,&nbsp;int,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;UnitPrice,&nbsp;money,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;UnitPriceDiscount,&nbsp;money,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;rowguid,&nbsp;uniqueidentifier,&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,&lt;ModifiedDate,&nbsp;datetime,&gt;)&nbsp;
GO</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Along with this, we can create a new stored procedure which will fetch the data. Following is the query to create the stored procedure.</span></p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_335318">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">USE&nbsp;[TrialsDB]&nbsp;
GO&nbsp;
/******&nbsp;Object:&nbsp;&nbsp;StoredProcedure&nbsp;[dbo].[usp_Get_SalesOrderDetail]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;<span class="js__num">19</span>-Feb<span class="js__num">-16</span>&nbsp;<span class="js__num">12</span>:<span class="js__num">33</span>:<span class="js__num">43</span>&nbsp;PM&nbsp;******/&nbsp;
SET&nbsp;ANSI_NULLS&nbsp;ON&nbsp;
GO&nbsp;
SET&nbsp;QUOTED_IDENTIFIER&nbsp;ON&nbsp;
GO&nbsp;
--&nbsp;=============================================&nbsp;
--&nbsp;Author:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Author,Sibeesh&nbsp;Venu&gt;&nbsp;
--&nbsp;Create&nbsp;date:&nbsp;&lt;Create&nbsp;<span class="js__object">Date</span>,&nbsp;<span class="js__num">18</span>-Feb<span class="js__num">-2016</span>&gt;&nbsp;
--&nbsp;Description:&nbsp;&lt;Description,To&nbsp;fetch&nbsp;SalesOrderDetail&gt;&nbsp;
--&nbsp;=============================================&nbsp;
ALTER&nbsp;PROCEDURE&nbsp;[dbo].[usp_Get_SalesOrderDetail]&nbsp;
AS&nbsp;
BEGIN&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;SET&nbsp;NOCOUNT&nbsp;ON&nbsp;added&nbsp;to&nbsp;prevent&nbsp;extra&nbsp;result&nbsp;sets&nbsp;from&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;interfering&nbsp;<span class="js__statement">with</span>&nbsp;SELECT&nbsp;statements.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SET&nbsp;NOCOUNT&nbsp;ON;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;--&nbsp;Select&nbsp;statements&nbsp;<span class="js__statement">for</span>&nbsp;procedure&nbsp;here&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SELECT&nbsp;top(<span class="js__num">100</span>)&nbsp;SalesOrderID,SalesOrderDetailID,CarrierTrackingNumber,OrderQty,ProductID,UnitPrice,ModifiedDate&nbsp;from&nbsp;dbo.SalesOrderDetail&nbsp;
END</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Next thing we are going to do is creating a ADO.NET Entity Data Model.</span></p>
<p><span style="font-size:small">Create Entity Data Model</span></p>
<p><span style="font-size:small">Right click on your model folder and click new, select ADO.NET Entity Data Model. Follow the steps given. Once you have done the processes, you can see the edmx file and other files in your model folder.</span></p>
<p><span style="font-size:small">Now we will go back to our controller and add a new JsonResult which can be called via a new&nbsp;<a href="http://sibeeshpassion.com/tag/jquery-ajax/" target="_blank">jQuery Ajax</a>&nbsp;request. No worries, we will create
 that Ajax request later. Once you add the Jsonresult action, I hope your controller will looks like this.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_404397">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.aspx" target="_blank" title="Auto generated link to System.Web">System.Web</a>;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
using&nbsp;jQuery_Datatable_With_Server_Side_Data.Models;&nbsp;
namespace&nbsp;jQuery_Datatable_With_Server_Side_Data.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TrialsDBEntities&nbsp;tdb;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Sales&nbsp;sa&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Sales();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;JsonResult&nbsp;GetGata()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(tdb&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;TrialsDBEntities())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myList&nbsp;=&nbsp;sa.GetSales(tdb);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;Json(myList,&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here&nbsp;<em>TrialsDBEntities&nbsp;</em>is our entity class. Please be noted that to use the model classes in your controller, you must add the reference as follows.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_34382">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;jQuery_Datatable_With_Server_Side_Data.Models;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">I know all you are familiar with this, I am just saying!. Now can we create a function&nbsp;<em>GetSales</em>&nbsp;in our model class&nbsp;<em>Sales&nbsp;</em>?.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_913140">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;object&nbsp;GetSales(TrialsDBEntities&nbsp;tdb)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myList&nbsp;=&nbsp;((from&nbsp;l&nbsp;<span class="js__operator">in</span>&nbsp;tdb.SalesOrderDetails&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;<span class="js__operator">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SalesOrderID&nbsp;=&nbsp;l.SalesOrderID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SalesOrderDetailID&nbsp;=&nbsp;l.SalesOrderDetailID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CarrierTrackingNumber&nbsp;=&nbsp;l.CarrierTrackingNumber,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrderQty&nbsp;=&nbsp;l.OrderQty,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProductID&nbsp;=&nbsp;l.ProductID,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UnitPrice&nbsp;=&nbsp;l.UnitPrice&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).OrderBy(l&nbsp;=&gt;&nbsp;l.SalesOrderID)).Take(<span class="js__num">100</span>).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;myList;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">We uses normal LINQ queries here, and we take only 100 records to load for now. If you don&rsquo;t want to use this method you can call our stored procedure which we have created while creating our database. You can call this
 as explained in the below function.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_661818">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;List&lt;SalesOrderDetail&gt;&nbsp;GetSalesSP(TrialsDBEntities&nbsp;tdb)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;myList&nbsp;=&nbsp;tdb.Database.SqlQuery&lt;SalesOrderDetail&gt;(<span class="js__string">&quot;EXEC&nbsp;usp_Get_SalesOrderDetail&quot;</span>).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;myList;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>&nbsp;<span class="js__operator">new</span>&nbsp;NotImplementedException();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Now only thing pending is to call our controller JsonResult action right? We will do some code in our MyScript.js file.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_830931">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#myGrid'</span>).DataTable(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;ajax&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;url&quot;</span>:&nbsp;<span class="js__string">&quot;../Home/GetGata/&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;dataSrc&quot;</span>:&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;columns&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;SalesOrderID&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;SalesOrderDetailID&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;OrderQty&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;ProductID&quot;</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">&quot;data&quot;</span>:&nbsp;<span class="js__string">&quot;UnitPrice&quot;</span>&nbsp;<span class="js__brace">}</span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Here&nbsp;<em>&ldquo;dataSrc&rdquo;: &ldquo;&rdquo;&nbsp;</em>should be used if you have a plain&nbsp;<a href="http://sibeeshpassion.com/tag/json/" target="_blank">JSON&nbsp;</a>data. The sample data can be find below.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_315828">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">[<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">2</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">776</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2024.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">3</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">3</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">777</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2024.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">4</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">778</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2024.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">5</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">771</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2039.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">6</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">772</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2039.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">7</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">2</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">773</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2039.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">8</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">774</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">2039.994</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">9</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">3</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">714</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">28.8404</span><span class="js__brace">}</span>,<span class="js__brace">{</span><span class="js__string">&quot;SalesOrderID&quot;</span>:<span class="js__num">43659</span>,<span class="js__string">&quot;SalesOrderDetailID&quot;</span>:<span class="js__num">10</span>,<span class="js__string">&quot;CarrierTrackingNumber&quot;</span>:<span class="js__string">&quot;4911-403C-98&quot;</span>,<span class="js__string">&quot;OrderQty&quot;</span>:<span class="js__num">1</span>,<span class="js__string">&quot;ProductID&quot;</span>:<span class="js__num">716</span>,<span class="js__string">&quot;UnitPrice&quot;</span>:<span class="js__num">28.8404</span><span class="js__brace">}</span>]&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">We have done everything!. Can we see the output now?</span></p>
<p><strong><span style="font-size:small">Output</span></strong></p>
<div class="wp-caption x_x_alignnone" id="attachment_11267"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/02/jQuery-Datatable-With-Server-Side-Data.png"><img class="size-large x_x_wp-image-11267" src="-jquery-datatable-with-server-side-data-1024x596.png" alt="jQuery Datatable With Server Side Data" width="634" height="369"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">jQuery Datatable With Server Side Data</span></p>
</div>
<div class="wp-caption x_x_alignnone" id="attachment_11268"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2016/02/jQuery-Datatable-With-Server-Side-Data-Search.png"><img class="size-large x_x_wp-image-11268" src="-jquery-datatable-with-server-side-data-search-1024x379.png" alt="jQuery Datatable With Server Side Data Search" width="634" height="235"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">jQuery Datatable With Server Side Data Search</span></p>
</div>
<p><span style="font-size:small">Have a happy coding.</span></p>
</li>