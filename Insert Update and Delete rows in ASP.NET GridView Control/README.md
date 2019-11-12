# Insert Update and Delete rows in ASP.NET GridView Control
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL
- ASP.NET
- GridView
## Topics
- SQL Server
- ASP.NET
- GridView
- inserting tables
- GridView editing
## Updated
- 05/29/2013
## Description

<h1>Introduction</h1>
<p><span style="font-size:small"><em>In this Article you can learn how to edit, update, delete, and cancel in gridview.First drag and drop Gridview.In gridview properties set AutoGenarateColumns to False.Next open Default.aspx source code. To make a columns
 in Gridview use &nbsp;&lt;asp:TemplateField&gt;Here first I created a table name 'Product' in my database.it contains 3 colomns as ProductId,ProductName,ProdcutPrice</em></span></p>
<p><span style="font-size:small"><em><br>
1)Download My Sample.</em></span></p>
<p><span style="font-size:small"><em>2)Inside that folder person.sql file will be there execute it in your database<span style="font-style:normal"><em>.<span style="font-style:normal; font-size:10px"><em><em>&nbsp;<span style="font-style:normal"><em><em>&nbsp;</em></em></span></em></em></span></em></span></em></span></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[Product]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;07/07/2012&nbsp;02:18:07&nbsp;******/</span>&nbsp;
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
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-style:normal; font-size:small"><em><span style="font-style:normal"><em>3)Change the connetion string in web.config file.</em></span></em></span></div>
</em>
<p>&nbsp;</p>
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connectionString=<span class="cs__string">&quot;Data&nbsp;Source=MONISH-PC\MONISH;Initial&nbsp;Catalog=master;Persist&nbsp;Security&nbsp;Info=True;User&nbsp;ID=saty;Password=123&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;providerName=<span class="cs__string">&quot;System.Data.SqlClient&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;/connectionStrings&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:20px; font-weight:bold">Building the Sample</span></p>
<p><span style="font-size:small"><em>This sample wrote by three tier architecture so you have to add references.</em></span></p>
<p><span style="font-size:small"><em>UI-&gt;BusinessLogic</em></span></p>
<p><span style="font-size:small"><em><em>BusinessLogic-&gt;DataAccess back to BL</em></em></span></p>
<p><span style="font-size:small"><em><em><em>BusinessLogic-&gt;Commonfunctioon&nbsp;<em><em>back to BL</em></em></em></em></em></span></p>
<p><span style="font-size:small"><em><em><em><em><em><em>BusinessLogic -&gt;&nbsp;<em>UI finally BL return data to UI</em></em></em></em></em></em></em></span></p>
<p><span style="font-size:small"><em><em><em><em><em><em><em><br>
</em></em></em></em></em></em></em></span></p>
<p><em><em><em><em><em><em><em><span><img id="60729" src="60729-20120707_02.jpg" alt="" width="1274" height="497"><br>
</span></em></em></em></em></em></em></em></p>
<p><img id="60730" src="60730-20120707_01.jpg" alt="" width="1274" height="497"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="color:#000000">In Default.aspx source code we have to add</span></p>
<p><span style="color:#000000">This&nbsp;is used to Edit the Row in Gridview.</span><span style="color:#000000">Here I am going to Edit only two columns name and marks.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;asp:GridView&nbsp;ID=<span class="cs__string">&quot;GridView1&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;CellPadding=<span class="cs__string">&quot;4&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&nbsp;&nbsp;AutoGenerateColumns=<span class="cs__string">&quot;False&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onrowcancelingedit=<span class="cs__string">&quot;GridView1_RowCancelingEdit&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onrowdeleting=<span class="cs__string">&quot;GridView1_RowDeleting&quot;</span>&nbsp;onrowediting=<span class="cs__string">&quot;GridView1_RowEditing&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onrowupdating=<span class="cs__string">&quot;GridView1_RowUpdating&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;AlternatingRowStyle&nbsp;BackColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;Visible=<span class="cs__string">&quot;False&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;lblPk_id&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;pk_id&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;Headertext=<span class="cs__string">&quot;ProductId&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductId&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductId&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductId&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductId&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;lblProductId&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductId&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="cs__string">&quot;ProductName&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductName&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductName&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductName&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductName&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;lblProductName&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductName&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&nbsp;HeaderText=<span class="cs__string">&quot;ProductPrice&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductPrice&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductPrice&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/EditItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TextBox&nbsp;ID=<span class="cs__string">&quot;txtProductPrice&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductPrice&quot;)%&gt;'</span>&gt;&lt;/asp:TextBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Label&nbsp;ID=<span class="cs__string">&quot;lblProductPrice&quot;</span>&nbsp;runat=<span class="cs__string">&quot;server&quot;</span>&nbsp;&nbsp;&nbsp;&nbsp;Text=<span class="cs__string">'&lt;%#Eval(&quot;ProductPrice&quot;)%&gt;'</span>&gt;&lt;/asp:Label&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ItemTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:CommandField&nbsp;ShowDeleteButton=<span class="cs__string">&quot;True&quot;</span>&nbsp;ShowEditButton=<span class="cs__string">&quot;True&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:TemplateField&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterTemplate&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;asp:Button&nbsp;ID=<span class="cs__string">&quot;btnInsert&quot;</span>&nbsp;runat=<span class="cs__string">&quot;Server&quot;</span>&nbsp;Text=<span class="cs__string">&quot;Insert&quot;</span>&nbsp;CommandName=<span class="cs__string">&quot;Insert&quot;</span>&nbsp;UseSubmitBehavior=<span class="cs__string">&quot;False&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/FooterTemplate&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:TemplateField&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;EditRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;FooterStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;HeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#507CD1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;PagerStyle&nbsp;BackColor=<span class="cs__string">&quot;#2461BF&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;White&quot;</span>&nbsp;HorizontalAlign=<span class="cs__string">&quot;Center&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;RowStyle&nbsp;BackColor=<span class="cs__string">&quot;#EFF3FB&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SelectedRowStyle&nbsp;BackColor=<span class="cs__string">&quot;#D1DDF1&quot;</span>&nbsp;Font-Bold=<span class="cs__string">&quot;True&quot;</span>&nbsp;ForeColor=<span class="cs__string">&quot;#333333&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingCellStyle&nbsp;BackColor=<span class="cs__string">&quot;#F5F7FB&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedAscendingHeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#6D95E1&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingCellStyle&nbsp;BackColor=<span class="cs__string">&quot;#E9EBEF&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;SortedDescendingHeaderStyle&nbsp;BackColor=<span class="cs__string">&quot;#4870BE&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/asp:GridView&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:medium"><strong><em>product.sql</em></strong></span> </li></ul>
<p>&nbsp;</p>
<div dir="ltr">
<div><span style="font-size:small">Note:I have used SqlServer 2008</span></div>
</div>
<div><span style="font-size:small">For this article we are going to fill GridView by data from database.</span></div>
<div><span style="font-size:small">We are going to make perform following operations on data using GridView</span></div>
<ol>
<li><span style="font-size:small">Add New record into database; here data will directly be added into database table</span>
</li><li><span style="font-size:small">Update Records into database, using edit link.</span>
</li><li><span style="font-size:small">Delete Records using delete link</span> </li></ol>
<p>&nbsp;</p>
</em>
<p></p>
