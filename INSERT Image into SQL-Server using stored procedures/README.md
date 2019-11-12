# INSERT Image into SQL-Server using stored procedures
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SQL
- SQL Server
- Data Access
- Stored Procedures
- DataGridView
- Image Processing
## Topics
- Data Access
- Images
- DataGridView
- Load Image
## Updated
- 09/18/2016
## Description

<h1>Description</h1>
<p><span style="font-size:small">Many times a developer would like to include images into their project stored in a database. When just starting out they may gravitate to using TableAdapters because TableAdapters are fairly easy to work with. The problem is
 you lose control over how data wizards work. This code sample will show how to insert images and read image back using a class coupled with stored procedures in a SQL-Server database, not an attached database but with modifications to the connection string
 the methods shown will work with an attached database.</span></p>
<p><span style="font-size:small">I have included a SQL script that must be executed before using the code along with altering the connection string to the database as currently it points to my database server. Please note that in the code I broke out two variables
 that need to change. So KARENS-PC needs to change to the name of your SQL-Server or perhaps it's SQLEXPRESS.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="js"><span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;This&nbsp;points&nbsp;to&nbsp;your&nbsp;database&nbsp;server&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
Private&nbsp;databaseServer&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;KARENS-PC&quot;</span>&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;summary&gt;&nbsp;
<span class="js__string">''</span>'&nbsp;Name&nbsp;of&nbsp;database&nbsp;containing&nbsp;required&nbsp;tables&nbsp;
<span class="js__string">''</span>'&nbsp;&lt;/summary&gt;&nbsp;
Private&nbsp;defaultCatalog&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;NORTHWND_NEW.MDF&quot;</span>&nbsp;
Private&nbsp;Property&nbsp;ConnectionString&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;$<span class="js__string">&quot;Data&nbsp;Source={databaseServer};Initial&nbsp;Catalog={defaultCatalog};Integrated&nbsp;Security=True&quot;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Running through the class. First off, there are a few methods not used but think you will find them of service, HasRecords, indicates if there are records in the image table an overload of the insert
 method, the one used wants a byte array, a description and by ref, an integer to return the new primary key while the other overload takes an image, description and by ref an integer for the new primary key.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:small">In form load, data is loaded, if no data and empty DataGridView is shown.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;MainForm_Load(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;Handles&nbsp;MyBase.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.AutoGenerateColumns&nbsp;=&nbsp;False&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bs.DataSource&nbsp;=&nbsp;ops.DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.DataSource&nbsp;=&nbsp;bs&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;ImageBinding&nbsp;As&nbsp;New&nbsp;Binding(<span class="js__string">&quot;Image&quot;</span>,&nbsp;bs,&nbsp;<span class="js__string">&quot;ImageData&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AddHandler&nbsp;ImageBinding.Format,&nbsp;AddressOf&nbsp;BindImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;PictureBox1.DataBindings.Add(ImageBinding)&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Note the data binding, a picture box displays the current DataGridView row picture, in the underlying DataTable the column for the image is a byte array so the event BindingImage converts the byte array to an image on the
 fly.</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;BindImage(ByVal&nbsp;sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;ConvertEventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;e.DesiredType&nbsp;Is&nbsp;GetType(Image)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;ms&nbsp;As&nbsp;New&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.MemoryStream.aspx" target="_blank" title="Auto generated link to System.IO.MemoryStream">System.IO.MemoryStream</a>(CType(e.Value,&nbsp;Byte()))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Logo&nbsp;As&nbsp;Image&nbsp;=&nbsp;Image.FromStream(ms)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Value&nbsp;=&nbsp;Logo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">To insert an image (in C#) a dialog is displayed where the user selects a file (I don't check the type, you can do this in your project), writes a description and presses the OK button to continue. In VB.NET I simple prompt for
 a file and insert a canned comment.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js"><span class="js__operator">void</span>&nbsp;cmdInsertImage_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SelectImageForm&nbsp;f&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SelectImageForm();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(f.ShowDialog()&nbsp;==&nbsp;DialogResult.OK)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;Identifier&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fileBytes&nbsp;=&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.IO.File.ReadAllBytes.aspx" target="_blank" title="Auto generated link to System.IO.File.ReadAllBytes">System.IO.File.ReadAllBytes</a>(f.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(ops.InsertImage(fileBytes,&nbsp;f.Description,&nbsp;ref&nbsp;Identifier)&nbsp;==&nbsp;Success.Okay)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((DataTable)bs.DataSource).Rows.Add(<span class="js__operator">new</span>&nbsp;object[]&nbsp;<span class="js__brace">{</span>&nbsp;Identifier,&nbsp;fileBytes,&nbsp;f.Description&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;index&nbsp;=&nbsp;bs.Find(<span class="js__string">&quot;ImageId&quot;</span>,&nbsp;Identifier);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(index&nbsp;&gt;&nbsp;-<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bs.Position&nbsp;=&nbsp;index;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Once the image has been selected the code inserts the image using SqlClient data provider in tangent with a Stored Procedure, returns the new key then adds a DataRow to the DataTable which is the DataSource of a BindingSource component
 followed by traversing to the new row in the DataGridView.&nbsp;</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">That is the basics, although the work is presented in a DataGridView you could easily take the classes and place them into a class project and use the methods on other project types.</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">In the screenshot below there is a ID column which we would not normally show but it's there for you to see and to validate can run a SQL SELECT in SQL-Server Management Studio or in a SQL SELECT right in Visual Studio (see
<a href="https://code.msdn.microsoft.com/Writing-SQL-Statements-00fe697f" target="_blank">
my code sample/article for how to</a> in Visual Studio).</div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The image is my current beauty.</div>
<div class="endscriptcode"><img id="159847" src="159847-figure1.jpg" alt="" width="525" height="241"></div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
<div class="endscriptcode"></div>
Hope this helps you with working with images in your projects.&nbsp;</div>
</div>
</span></div>
