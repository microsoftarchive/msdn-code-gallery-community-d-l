# Export Excel from SQL-Server
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- Excel
- Class Library
- VB.Net
- export to excel
## Topics
- SQL Server
- Excel
- Data Export
## Updated
- 08/28/2018
## Description

<h1>Description</h1>
<p><span style="font-size:small">This code sample explains how to export from a SQL-Server table to an Excel worksheet by first configuring SQL-Server to permit exporting. By default if you used the code provided in the code samples they would fail with something
 like the following or very similar message</span></p>
<p><span style="font-size:small"><em>The requested operation could not be performed because OLE DB provider &quot;Microsoft.ACE.OLEDB.12.0&quot; for linked server &quot;(null)&quot; does not support the required transaction interface</em>.</span></p>
<p><span style="font-size:small">So the first thing needed is to configure a few settings in SQL-Server Management Studio Link Servers. Traverse to the node Microsoft.ACE.OOLEDB.12.0</span></p>
<p><img id="168185" src="168185-fig1.jpg" alt="" width="334" height="251"></p>
<p><span style="font-size:small">Right click, select properties</span></p>
<p><span style="font-size:small"><img id="168186" src="168186-fig2.jpg" alt="" width="252" height="130"></span></p>
<p><span style="font-size:small">Once the dialog appears, select and check these items</span></p>
<p><span style="font-size:small"><img id="168187" src="168187-fig4.jpg" alt="" width="455" height="187"></span></p>
<p><span style="font-size:small">Now select the Database node, right click, select Refresh. This should do it configuration wise yet look out for other issues like the proper library for MS-Access is installed properly and that you don't mix 64 and 32bit with
 the library and SQL-Server install.</span></p>
<p><span style="font-size:small">Once the above is done, create a database named ExcelExporting. Once created run the script SQL_Scripts.sql in the solution from the file or from SQL-Server.</span></p>
<p><span style="font-size:small">Build the project and we are ready to run but first lets go over the operations.</span></p>
<p><span style="font-size:small">Under the Bin\Debug folder there is an Excel file setup with the first row has names of columns which has the same count as the query that runs. Note the names are different than the field names as they are easier for reading.
 By default the CheckBox is checked and indicates to copy the file under Bin\Debug\Files to Bin\Debug.&nbsp;</span></p>
<p><span style="font-size:small">For Export all we keep the same name while for the Export to County we name the file when copying to the country name without spaces or apostrophes.</span></p>
<p><span style="font-size:small">Once either operation completes the row count is displayed or any errors. If you get a long drawn out error like the one at the beginning of this article then SQL-Server is not configured correctly. Point to be made, there are
 literally thousands of web pages with this type of error and they do have one thing in common with one common answer for most, to set two of the three options I showed above, I learned the hard way on this.</span></p>
<p><img id="168188" src="168188-fig5.jpg" alt="" width="398" height="211"></p>
<p><span style="font-size:small">Last thought, many ask how to export from a DataGridView to Excel where the data was read from SQL-Server database table. My train of thought is, update data in the DataGridView then export from the database table rather then
 resorting to either OleDb, Excel automation or creating a CSV file that Excel will read.</span></p>
<p><span style="font-size:small">Example on CSV in VB.NET which got me started on this as the person asking the question indicated they read from SQL-Server but did not set a DataSource for the DataGridView thus the code needed was against the DataGridView.</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Module</span>&nbsp;DataGridViewExtensions&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Export&nbsp;DataGridView&nbsp;rows/cells&nbsp;to&nbsp;csv</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;sender&quot;&gt;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;FileName&quot;&gt;Name&nbsp;of&nbsp;file&nbsp;to&nbsp;save&nbsp;information&nbsp;into&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;UseHeader&quot;&gt;True&nbsp;indicates&nbsp;first&nbsp;row&nbsp;will&nbsp;be&nbsp;column&nbsp;headers,&nbsp;default&nbsp;is&nbsp;not&nbsp;to&nbsp;include&nbsp;header&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Runtime.CompilerServices.Extension()&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ExportRows(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridView,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;FileName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Optional</span>&nbsp;UseHeader&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sbHeader&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Text.StringBuilder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;headers&nbsp;=&nbsp;sender.Columns.Cast(<span class="visualBasic__keyword">Of</span>&nbsp;DataGridViewColumn)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbHeader.Append(<span class="visualBasic__keyword">String</span>.Join(<span class="visualBasic__string">&quot;,&quot;</span>,&nbsp;headers.<span class="visualBasic__keyword">Select</span>(<span class="visualBasic__keyword">Function</span>(column)&nbsp;column.HeaderText)))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Create&nbsp;an&nbsp;array&nbsp;of&nbsp;cell&nbsp;values&nbsp;excludes&nbsp;New&nbsp;Row,&nbsp;if&nbsp;data&nbsp;is&nbsp;null&nbsp;then&nbsp;use&nbsp;an&nbsp;empty&nbsp;string&nbsp;for&nbsp;it's&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;RowsAndCells&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;row&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;sender.Rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;<span class="visualBasic__keyword">DirectCast</span>(row,&nbsp;DataGridViewRow).IsNewRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Let</span>&nbsp;RowItem&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Join(<span class="visualBasic__string">&quot;,&quot;</span>,&nbsp;Array.ConvertAll(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">DirectCast</span>(row,&nbsp;DataGridViewRow).Cells.Cast(<span class="visualBasic__keyword">Of</span>&nbsp;DataGridViewCell).ToArray,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>(c&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewCell)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>(c.Value&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">OrElse</span>&nbsp;IsDBNull(c.Value),&nbsp;<span class="visualBasic__string">&quot;&quot;</span>,&nbsp;<span class="visualBasic__keyword">CStr</span>(c.Value).Trim)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;RowItem&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;).ToList&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;UseHeader&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RowsAndCells.Insert(<span class="visualBasic__number">0</span>,&nbsp;sbHeader.ToString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;This&nbsp;tells&nbsp;Excel&nbsp;how&nbsp;to&nbsp;handle&nbsp;columns</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RowsAndCells.Insert(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__string">&quot;sep=,&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IO.File.WriteAllLines(FileName,&nbsp;RowsAndCells)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Module</span></pre>
</div>
</div>
</div>
<p><span style="font-size:small">Finally even thou the demos are in window form projects the base code can work in other project types.</span></p>
<p><strong><span style="font-size:small">Source code is now VS2017</span></strong></p>
