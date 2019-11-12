# Load Data From Database Using Web API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL Server
- jQuery
- ASP.NET Web API
## Topics
- Database Connectivity
## Updated
- 02/17/2016
## Description

<p><span style="font-size:small">In this article we will learn about Loading Data From Database in&nbsp;<a href="http://sibeeshpassion.com/tag/mvc/" target="_blank">MVC&nbsp;</a>using Web API. We will use&nbsp;<a href="http://sibeeshpassion.com/tag/visual-studio/" target="_blank">Visual
 Studio</a>&nbsp;2015 to create a Web API and performs the operations. In this project we are going to create a<em><a href="http://sibeeshpassion.com/tag/database/" target="_blank">database&nbsp;</a></em>and a table called&nbsp;<em>tbl_Subcribers</em>&nbsp;which
 actually contains a list of data. We will use our normal jQuery ajax to call the Web API, once the data is ready we will format the same in an html table. I hope you will like this.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Background</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small"><strong><em>What is a Web API?</em></strong></span></p>
<p><span style="font-size:small">A Web API is a kind of a framework which makes building HTTP services easier than ever. It can be used almost everywhere including wide range of clients, mobile devices, browsers etc. It contains normal MVC features like Model,
 Controller, Actions, Routing etc. Support all HTTP verbs like POST, GET, DELETE, PUT.</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10874"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Why-Web-API.png"><img class="size-full x_x_x_wp-image-10874" src="-why-web-api.png" alt="Why Web API" width="550" height="377"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Why Web API</span></p>
</div>
<p><span style="font-size:small"><em>Image Courtesy : blogs.msdn.com</em></span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10875"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Why-Web-API1-e1446290457816.png"><img class="size-full x_x_x_wp-image-10875" src="-why-web-api1-e1446290457816.png" alt="Why Web API" width="650" height="454"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Why Web API</span></p>
</div>
<p><span style="font-size:small"><em>Image Courtesy : forums.asp.net</em></span></p>
<p><span style="font-size:small"><em><br>
</em></span></p>
<p><span style="font-size:small"><strong>Using the code</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small">We will create our project in Visual Studio 2015. To create a project click File-&gt; New-&gt; Project.</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10151"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_1-e1440410870120.png"><img class="size-full x_x_x_wp-image-10151" src="-crud_in_mvc_using_web_api_1-e1440410870120.png" alt="CRUD_in_MVC_Using_Web_API" width="650" height="450"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API</span></p>
</div>
<div class="wp-caption x_x_x_alignnone" id="attachment_10161"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_2-e1440410926817.png"><img class="size-full x_x_x_wp-image-10161" src="-crud_in_mvc_using_web_api_2-e1440410926817.png" alt="CRUD_in_MVC_Using_Web_API" width="650" height="590"></a>
</span>
<p class="wp-caption-text"><br>
<span style="font-size:small">CRUD_in_MVC_Using_Web_API</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small"><strong>Create a controller</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small">Now we will create a controller in our project.</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10171"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_Adding_Control.png"><img class="size-full x_x_x_wp-image-10171" src="-crud_in_mvc_using_web_api_adding_control.png" alt="CRUD_in_MVC_Using_Web_API_Adding_Control" width="652" height="596"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API_Adding_Control</span></p>
</div>
<p><span style="font-size:small">Select&nbsp;<em>Empty API Controller</em>&nbsp;as template.</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10191"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_Select_APIControl.png"><img class="size-full x_x_x_wp-image-10191" src="-crud_in_mvc_using_web_api_select_apicontrol.png" alt="CRUD_in_MVC_Using_Web_API_Select_APIControl" width="638" height="430"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API_Select_APIControl</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">As you can notice that we have selected Empty API Controller instead of selecting a normal controller. There are few difference between our normal controller and Empty API Controller.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Controller VS Empty API Controller</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small">A controller normally render your views. But an API controller returns the data which is already serialized. A controller action returns JSON() by converting the data. You can get rid of this by using API controller.</span></p>
<p><span style="font-size:small">Find out more:&nbsp;<a href="http://stackoverflow.com/questions/9494966/difference-between-apicontroller-and-controller-in-asp-net-mvc" target="_blank">Controller VS API Controller</a></span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Create a model</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<p><span style="font-size:small">As you all know, we write logic in a class called model in MVC. So next step what we need to do is creating a model.</span></p>
<p><span style="font-size:small">Right click on Model and click Add new Items and then class. Name it as Subscribers. We are going to handle the subscriber list who all are subscribed to your website.</span></p>
<p><span style="font-size:small">Now we will create a Database to our application.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><strong>Create Database</strong></span></p>
<p><span style="font-size:small"><strong><br>
</strong></span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10201"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_Create_Database-e1440412525937.png"><img class="size-full x_x_x_wp-image-10201" src="-crud_in_mvc_using_web_api_create_database-e1440412525937.png" alt="CRUD_in_MVC_Using_Web_API_Create_Database" width="650" height="449"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API_Create_Database</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">Once you created the database, you can see your database in App_Data folder.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10211"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_Created_DB.png"><img class="size-full x_x_x_wp-image-10211" src="-crud_in_mvc_using_web_api_created_db.png" alt="CRUD_in_MVC_Using_Web_API_Created_DB" width="335" height="135"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API_Created_DB</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">Now will add a new table to our database.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10221"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/08/CRUD_in_MVC_Using_Web_API_Adding_Table.png"><img class="size-full x_x_x_wp-image-10221" src="-crud_in_mvc_using_web_api_adding_table.png" alt="CRUD_in_MVC_Using_Web_API_Adding_Table" width="347" height="294"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">CRUD_in_MVC_Using_Web_API_Adding_Table</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">You can see the query to create a table below.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">SQL</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="js">CREATE&nbsp;TABLE&nbsp;[dbo].[Table]&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SubscriberID]&nbsp;INT&nbsp;NOT&nbsp;NULL&nbsp;PRIMARY&nbsp;KEY,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[MailID]&nbsp;NVARCHAR(<span class="js__num">50</span>)&nbsp;NOT&nbsp;NULL,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[SubscribedDate]&nbsp;DATETIME2&nbsp;NOT&nbsp;NULL&nbsp;
)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter sql" id="highlighter_938460"><span style="font-size:small">It seems our database is ready now.</span></div>
<div class="syntaxhighlighter sql"><span style="font-size:small"><br>
</span></div>
</div>
<div class="wp-caption x_x_x_alignnone" id="attachment_10868"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Load-Data-From-Database-Using-Web-API.png"><img class="size-full x_x_x_wp-image-10868" src="-load-data-from-database-using-web-api.png" alt="Load Data From Database Using Web API" width="261" height="293"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Load Data From Database Using Web API</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">The next thing we need to do is to create a ADO.NET Entity Data Model. SO shall we do that? Right click on your model and click on add new item, in the upcoming dialogue, select ADO.NET Entity Data Model.Name that file, Here
 I have given the name as SP. And in the next steps select the tables, stored procedures, and views you want.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10869"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Load-Data-From-Database-Using-Web-API-2.png"><img class="size-large x_x_x_wp-image-10869" src="-load-data-from-database-using-web-api-2-1024x711.png" alt="Load Data From Database Using Web API " width="634" height="440"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Load Data From Database Using Web API</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<p><span style="font-size:small">So a new file will be created in your model folder.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">Now we will create an ajax call so that you can call the web API. We will use normal Ajax with type GET since we need to just retrieve the data.</span></p>
<blockquote>
<p><span style="font-size:small">A web API control does not return any action result or any json result, so we need to manually do this. We will use the index.cshtml file as our view</span></p>
<p><span style="font-size:small"><br>
</span></p>
</blockquote>
<p><span style="font-size:small">We are going to call our web API as follows from the view Index.cshtml.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">@section&nbsp;scripts&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">'GET'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">'json'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">'application/json;charset=utf-8'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">'http://localhost:3064/api/Subscribers'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;debugger;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;html&nbsp;=&nbsp;<span class="js__string">'&lt;table&gt;&lt;thead&gt;&lt;th&gt;Mail&nbsp;ID&lt;/th&gt;&lt;th&gt;Subscription&nbsp;ID&lt;/th&gt;&lt;th&gt;Subscription&nbsp;Date&lt;/th&gt;&lt;/thead&gt;&lt;tbody&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.each(data,&nbsp;<span class="js__operator">function</span>&nbsp;(key,&nbsp;val)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;debugger;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;html&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;tr&gt;&lt;td&gt;'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="js__string">'&lt;a&nbsp;'</span>&nbsp;&#43;&nbsp;<span class="js__string">'href=&quot;mailto:'</span>&nbsp;&#43;&nbsp;val.MailID&nbsp;&#43;&nbsp;<span class="js__string">'&quot;&gt;'</span>&nbsp;&#43;&nbsp;val.MailID&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/a&gt;'</span>&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'&lt;/td&gt;&lt;td&gt;'</span>&nbsp;&#43;&nbsp;val.SubscriberID&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;&lt;td&gt;'</span>&nbsp;&#43;&nbsp;val.SubscribedDate&nbsp;&#43;&nbsp;<span class="js__string">'&lt;/td&gt;&lt;/tr&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;html&nbsp;&#43;=&nbsp;<span class="js__string">'&lt;/tbody&gt;&lt;/table&gt;'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#myGrid'</span>).html(html);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">catch</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">'Error&nbsp;while&nbsp;formatting&nbsp;the&nbsp;data&nbsp;:&nbsp;'</span>&nbsp;&#43;&nbsp;e.message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error:&nbsp;<span class="js__operator">function</span>&nbsp;(xhrequest,&nbsp;error,&nbsp;thrownError)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">'Error&nbsp;while&nbsp;ajax&nbsp;call:&nbsp;'</span>&nbsp;&#43;&nbsp;error)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_319978">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"><span style="font-size:small">Once we get the data in the success part of the ajax call we are formulating the data in an HTML table and bind the formatted html to the element myGrid.</span></div>
<div class="line number1 index0 alt2"><span style="font-size:small"><br>
</span></div>
</td>
<td class="code"><br>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<div>
<div class="syntaxhighlighter xml" id="highlighter_824283">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">HTML</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">html</span>

<div class="preview">
<pre class="js"><span style="font-size:small">&lt;div&nbsp;id=<span class="js__string">&quot;myGrid&quot;</span>&gt;&lt;/div&gt;&nbsp;
</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<blockquote>
<p><span style="font-size:small">Please be noted that url you give must be correct, or else you will end up with some errors. Your actions won&rsquo;t work</span></p>
</blockquote>
<p><span style="font-size:small">So we are calling our web api as http://localhost:3064/api/Subscribers. Do you remember we have already created a controller? Now we are going back to that. So we need to create an action which returns the total subscribed list
 from the database, so for that we will write few lines of codes as follows.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;List&lt;tbl_Subscribers&gt;&nbsp;getSubscribers()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SibeeshPassionEntities())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Subscriber&nbsp;sb&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Subscriber();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;(sb.getSubcribers(db).ToList());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_443168">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Here Subscriber is our model class, to get the reference of your model class in controller, you need to include the model namespace. We are getting a list of data in tbl_Subcribers type. Now we will concentrate on model class.</span></p>
<p><span style="font-size:small">You can see the model action codes here.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">C#</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;List&lt;tbl_Subscribers&gt;&nbsp;getSubcribers(SibeeshPassionEntities&nbsp;sb)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(sb&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;sb.tbl_Subscribers.ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_191629">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<p><span style="font-size:small">This will return the data which is available in the table tbl_Subcribers in SibeeshPassion DB. It seems everything is set. Now what else we need to do? Yes we need to create some entries in the table. Please see the insertion
 query here.</span></p>
<p><span style="font-size:small"><br>
</span></p>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<div>
<div class="syntaxhighlighter sql" id="highlighter_437623">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">SQL</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">mysql</span>

<div class="preview">
<pre class="js"><span style="font-size:small">INSERT&nbsp;INTO&nbsp;[dbo].[tbl_Subscribers]&nbsp;([SubscriberID],&nbsp;[MailID],&nbsp;[SubscribedDate])&nbsp;VALUES&nbsp;(<span class="js__num">1</span>,&nbsp;N<span class="js__string">'sibikv4u@gmail.com'</span>,&nbsp;N<span class="js__string">'2015-10-30&nbsp;00:00:00'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[tbl_Subscribers]&nbsp;([SubscriberID],&nbsp;[MailID],&nbsp;[SubscribedDate])&nbsp;VALUES&nbsp;(<span class="js__num">2</span>,&nbsp;N<span class="js__string">'sibeesh.venu@gmail.com'</span>,&nbsp;N<span class="js__string">'2015-10-29&nbsp;00:00:00'</span>)&nbsp;
INSERT&nbsp;INTO&nbsp;[dbo].[tbl_Subscribers]&nbsp;([SubscriberID],&nbsp;[MailID],&nbsp;[SubscribedDate])&nbsp;VALUES&nbsp;(<span class="js__num">3</span>,&nbsp;N<span class="js__string">'ajaybhasy@gmail.com'</span>,&nbsp;N<span class="js__string">'2015-10-28&nbsp;00:00:00'</span>)</span></pre>
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
<p><span style="font-size:small">So the data is inserted. Isn&rsquo;t it?</span></p>
<p><span style="font-size:small"><br>
</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10870"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Load-Data-From-Database-Using-Web-API-3.png"><img class="size-full x_x_x_wp-image-10870" src="-load-data-from-database-using-web-api-3.png" alt="Load Data From Database Using Web API " width="517" height="200"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Load Data From Database Using Web API</span></p>
<p class="wp-caption-text"><span style="font-size:small"><br>
</span></p>
</div>
<blockquote>
<p><span style="font-size:small">Do you know?</span><br>
<span style="font-size:small">Like we have RouteConfig.cs in MVC, we have another class file called WebApiConfig.cs in Web API which actually sets the routes.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_219259">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp</span>

<div class="preview">
<pre class="js"><span style="font-size:small">routes.MapRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;Default&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;{controller}/{action}/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;controller&nbsp;=&nbsp;<span class="js__string">&quot;Home&quot;</span>,&nbsp;action&nbsp;=&nbsp;<span class="js__string">&quot;Index&quot;</span>,&nbsp;id&nbsp;=&nbsp;UrlParameter.Optional&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
</blockquote>
<p><span style="font-size:small">So shall we run our project and see the output? Before going to run, I suggest you to style the HTML table by applying some CSSs as follows.</span></p>
<div>
<div class="syntaxhighlighter css" id="highlighter_602334">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">CSS</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">css</span>

<div class="preview">
<pre class="js"><span style="font-size:small"><style><!--mce:1--></style></span></pre>
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
<p><span style="font-size:small">If everything goes fine, you will get the output as follows.</span></p>
<div class="wp-caption x_x_x_alignnone" id="attachment_10871"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2015/10/Load-Data-From-Database-Using-Web-API-4-e1446288898428.png"><img class="size-full x_x_x_wp-image-10871" src="-load-data-from-database-using-web-api-4-e1446288898428.png" alt="Load Data From Database Using Web API" width="650" height="497"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Load Data From Database Using Web API</span></p>
</div>
<p><span style="font-size:small">That is all. We did it. Have a happy coding.</span></p>
