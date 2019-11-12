# Import Data from Excel to SQL Server
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- SQL Server
- ASP.NET
- Microsoft Office Excel 2007
- Microsoft Office Excel 2010
- SQL Server 2008
- Office 2010
## Topics
- Excel
- Data Import
- Data Export
- Upload control
## Updated
- 01/06/2017
## Description

<h1>Introduction</h1>
<p>In many time you will find yourself with some Excel file need to be saved or Export to SQL Server,I know it possible by using SQL Server Import and Export Wizard.But this depend on business Scenario itself ,so one&nbsp; of the scenario is creating web application
 or windows application that read Excel file and Move it to SQL SERVER Database,so this sample assume that you have one of those scenarios.</p>
<h1>Sample Demo</h1>
<p><a href="http://dotnetfinder.files.wordpress.com/2012/03/image.png"><img title="image" src="-image_thumb.png" border="0" alt="image" width="244" height="52" style="padding-left:0pt; padding-right:0pt; display:inline; padding-top:0pt; border-width:0pt; margin:0pt"></a></p>
<p>As you can see from the above image the sample contain the page which byself contain three controls</p>
<ol>
<li>FileUpload Control to allow you browse and upload excel file </li><li>Button to Import data from excel and export it to SQL Server </li><li>Label to show the message about uploading status </li></ol>
<h1><span>Building the Sample</span></h1>
<p>Before run and test the sample you need to follow the next steps.</p>
<p><span style="color:#ff0000">Note: before start reading the steps I want let you to know that I haven&rsquo;t test this sample either on ASP.NET 3.5 or 32-bit MS Office,so may be you do not need the step 1 and step 2.</span></p>
<ol>
<li>Create an IIS web site </li><li>Change .Net Framework to 4.0 for Application Pool of this site </li><li>Create Excel file and make sure that file contain the column name as following image
</li></ol>
<p><a href="http://dotnetfinder.files.wordpress.com/2012/03/image1.png"><img title="image" src="-image_thumb1.png" border="0" alt="image" width="169" height="159" style="padding-left:0pt; padding-right:0pt; display:block; padding-top:0pt; border:0pt none; margin:0pt auto"></a></p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 4.Create Table in SQL Server and make sure has the same Columns name with appropriate columns data type.</p>
<p><a href="http://dotnetfinder.files.wordpress.com/2012/03/image2.png"><img title="image" src="-image_thumb2.png" border="0" alt="image" width="240" height="76" style="padding-left:0pt; padding-right:0pt; display:block; padding-top:0pt; border:0pt none; margin-left:auto; margin-right:auto"></a></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample work as I mentioned above by ask user to upload Excel file (*.xsl,*.xslx) and then check the content type of that file then open excel file and save it's data to SQL Server Database.&nbsp;
<br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'if&nbsp;you&nbsp;have&nbsp;Excel&nbsp;2007&nbsp;uncomment&nbsp;this&nbsp;line&nbsp;of&nbsp;code&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;string&nbsp;excelConnectionString&nbsp;=string.Format(&quot;Provider=Microsoft.Jet.OLEDB.4.0;Data&nbsp;Source={0};Extended&nbsp;Properties=Excel&nbsp;8.0&quot;,path);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Define&nbsp;the&nbsp;content&nbsp;type</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ExcelContentType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;application/vnd.ms-excel&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Excel2010ContentType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;application/vnd.openxmlformats-officedocument.spreadsheetml.sheet&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;FileUpload1.HasFile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;FileUpload1.PostedFile.ContentType&nbsp;=&nbsp;ExcelContentType&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;FileUpload1.PostedFile.ContentType&nbsp;=&nbsp;Excel2010ContentType&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Save&nbsp;file&nbsp;path</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;path&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Concat(Server.MapPath(<span class="visualBasic__string">&quot;~/TempFiles/&quot;</span>),&nbsp;FileUpload1.FileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Save&nbsp;File&nbsp;as&nbsp;Temp&nbsp;then&nbsp;you&nbsp;can&nbsp;delete&nbsp;it&nbsp;if&nbsp;you&nbsp;want</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileUpload1.SaveAs(path)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'For&nbsp;Office&nbsp;Excel&nbsp;2010&nbsp;&nbsp;please&nbsp;take&nbsp;a&nbsp;look&nbsp;to&nbsp;the&nbsp;followng&nbsp;link&nbsp;&nbsp;http://social.msdn.microsoft.com/Forums/en-US/exceldev/thread/0f03c2de-3ee2-475f-b6a2-f4efb97de302/#ae1e6748-297d-4c6e-8f1e-8108f438e62e</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;excelConnectionString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Format(<span class="visualBasic__string">&quot;Provider=Microsoft.ACE.OLEDB.12.0;Data&nbsp;Source={0};Extended&nbsp;Properties=Excel&nbsp;8.0&quot;</span>,&nbsp;path)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;Connection&nbsp;to&nbsp;Excel&nbsp;Workbook</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;connection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(excelConnectionString)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Command&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OleDbCommand&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(<span class="visualBasic__string">&quot;Select&nbsp;*&nbsp;FROM&nbsp;[Sheet1$]&quot;</span>,&nbsp;connection)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;connection.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;DbDataReader&nbsp;to&nbsp;Data&nbsp;Worksheet</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;reader&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DbDataReader&nbsp;=&nbsp;Command.ExecuteReader()&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;SQL&nbsp;Server&nbsp;Connection&nbsp;String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sqlConnectionString&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Data&nbsp;Source=.\sqlexpress;Initial&nbsp;Catalog=ExcelDB;Integrated&nbsp;Security=True&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Bulk&nbsp;Copy&nbsp;to&nbsp;SQL&nbsp;Server</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;bulkCopy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlBulkCopy(sqlConnectionString)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bulkCopy.DestinationTableName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Employee&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bulkCopy.WriteToServer(reader)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;The&nbsp;data&nbsp;has&nbsp;been&nbsp;exported&nbsp;succefuly&nbsp;from&nbsp;Excel&nbsp;to&nbsp;SQL&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Text&nbsp;=&nbsp;ex.Message&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Default.aspx sample page written by C#</em> </li><li>defaultVB.aspx sample page written in VB.NET </li><li>DBScript contain SQL script to create database with one table </li><li>TempFiles allow you to save the uploaded excel on it as temp file then read from this file and export it's data to sql server
</li><li><em><em>Excel file contain two excel file first one excel 2007 and other is excel 2010</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information about this topic you can ask me here<br>
</em></p>
