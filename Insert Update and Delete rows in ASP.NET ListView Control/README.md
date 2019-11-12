# Insert Update and Delete rows in ASP.NET ListView Control
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server
- ASP.NET
- asp.net 4.0
## Topics
- C#
- ASP.NET
- ListView
## Updated
- 05/30/2013
## Description

<h1>Introduction</h1>
<p style="text-align:left"><span><em>In this Article you can learn how to edit, update and delete &nbsp;in ListView.First drag and drop
<em>ListView</em>.In <em>ListView.</em>Next open Default.aspx source code. To make a columns in Listview use &nbsp;&nbsp;&lt;LayoutTemplate&gt;&nbsp;Here first I created a table name 'Product' in my database.</em></span><em>it contains 5colomns as ProductId,ProductName,ProductLocation,ProductQuantity,</em><em>&nbsp;</em><em>ProductPrice</em></p>
<p><span><em><br>
1)Download My Sample.</em></span></p>
<p><span><em>2)Inside that folder person.sql file will be there execute it in your database<span><em>.</em></span></em></span></p>
<p><span><em><span><em><em><em></p>
<div class="endscriptcode"><span><em>3)Change the connetion string in web.config file.</em></span></div>
</em></em></em></span></em></span>
<p></p>
<p><span><em><span><em><img id="82975" src="82975-1.jpg" alt="" width="656" height="658"><br>
</em></span></em></span></p>
<h1><span>Building the Sample</span></h1>
<p><em></p>
<p><span><em>This sample wrote by three tier architecture so you have to add references.</em></span></p>
<p><span><em>UI-&gt;BusinessLogic</em></span></p>
<p><span><em><em>BusinessLogic-&gt;DataAccess back to BL</em></em></span></p>
</em>
<p></p>
<p><em><span><em><em><em>BusinessLogic-&gt;Commonfunctioon&nbsp;<em><em>back to BL</em></em></em></em></em></span></em></p>
<p><span><em><em><em><em><em><em>BusinessLogic -&gt;&nbsp;<em>UI finally BL return data to UI</em></em></em></em></em></em></em></span></p>
<p><span><em><em><em><em><em><em><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Product]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;05/31/2013&nbsp;10:56:27&nbsp;******/</span>&nbsp;
<span class="sql__mlcom">/******&nbsp;Sathiyamoorthy.S&nbsp;******/</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULLS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">QUOTED_IDENTIFIER</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_PADDING</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Product</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">pk_id</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductId</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">5</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductName</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductPrice</span>]&nbsp;[<span class="sql__keyword">numeric</span>](<span class="sql__number">8</span>,&nbsp;<span class="sql__number">2</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductLocation</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">25</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ProductQuantity</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">10</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;<span class="sql__id">CLUSTERED</span>&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">pk_id</span>]&nbsp;<span class="sql__keyword">ASC</span>&nbsp;
)<span class="sql__keyword">WITH</span>&nbsp;(<span class="sql__id">PAD_INDEX</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">STATISTICS_NORECOMPUTE</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">IGNORE_DUP_KEY</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">ALLOW_ROW_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>,&nbsp;<span class="sql__id">ALLOW_PAGE_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_PADDING</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">select</span>&nbsp;<span class="sql__id">pk_id</span>,<span class="sql__id">ProductId</span>,<span class="sql__id">ProductName</span>,<span class="sql__id">ProductLocation</span>,<span class="sql__id">ProductQuantity</span>,<span class="sql__id">ProductPrice</span>&nbsp;<span class="sql__keyword">from</span>&nbsp;<span class="sql__id">Product</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<img id="82977" src="82977-2.jpg" alt="" width="750" height="561"><br>
</em></em></em></em></em></em></em></span>
<p></p>
<p>&nbsp;</p>
<p><img id="82978" src="82978-3.jpg" alt="" width="757" height="654"></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em></p>
<div dir="ltr">Note:I have used SqlServer 2008</div>
<div>For this article we are going to fill ListView by data from database.</div>
<div>We are going to make perform following operations on data using ListView</div>
<ol>
<li>Add New record into database; here data will directly be added into database table
</li><li>Update Records into database, using edit link. </li><li>Delete Records using delete link </li></ol>
</em>
<p></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;configuration&gt;&nbsp;
&nbsp;&nbsp;&lt;connectionStrings&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;add&nbsp;name=<span class="cs__string">&quot;MyConnection&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectionString=<span class="cs__string">&quot;Data&nbsp;Source=192.169.1.121\sql;Initial&nbsp;Catalog=master;Persist&nbsp;Security&nbsp;Info=True;User&nbsp;ID=Test;Password=Test&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;providerName=<span class="cs__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&lt;/connectionStrings&gt;&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em></p>
<div dir="ltr"></div>
<ol>
</ol>
</em>
<p></p>
<ul>
<li>product.sql </li><li>1.jpeg </li><li>2.jpeg </li><li>3.jpeg </li></ul>
<h1>More Information</h1>
<p>Source :<a href="http://msdn.microsoft.com/en-us/library/bb398790(v=vs.100).aspx">http://msdn.microsoft.com/en-us/library/bb398790(v=vs.100).aspx</a></p>
<p>The ASP.NET&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview(v=vs.100).aspx">ListView</a>&nbsp;control enables you to bind to data items that are returned from a data source and display them. You can display data in
 pages. You can display items individually, or you can group them.</p>
<p>The&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview(v=vs.100).aspx">ListView</a>&nbsp;control displays data in a format that you define by using templates and styles. It is useful for data in any repeating structure,
 similar to the<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.datalist(v=vs.100).aspx">DataList</a>&nbsp;and&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.repeater(v=vs.100).aspx">Repeater</a>&nbsp;controls.
 However, unlike those controls, with the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.listview(v=vs.100).aspx">ListView</a>&nbsp;control you can enable users to edit, insert, and delete data, and to sort and page data, all
 without code.</p>
