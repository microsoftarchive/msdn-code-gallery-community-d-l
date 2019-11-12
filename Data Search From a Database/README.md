# Data Search From a Database
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- .NET Framework 4.0
## Topics
- Data Access
- Search
## Updated
- 05/25/2011
## Description

<h1>Introduction</h1>
<p><span id="ctl00_ctl00_Content_TabContentPanel_Content_wikiSourceLabel">Demonstrates how to display a subset of data from within your database.</span></p>
<h1 class="procedureSubHeading">To run this sample</h1>
<div class="subSection">
<ul>
<li>
<p>Press F5.</p>
</li></ul>
</div>
<h1 class="heading"><span>Requirements</span></h1>
<div class="section" id="requirementsTitleSection">
<p>This sample requires the Northwind sample database. For more information, see <a href="http://msdn.microsoft.com/en-us/library/5ey0sd99%28VS.80%29.aspx" target="_blank">
How to: Install and Troubleshoot Database Components for Samples</a>.</p>
</div>
<h1>Description</h1>
<p>Most of this form was created using the designer tools in Visual Basic. The following is a summary of how you could create this form from scratch.</p>
<h3 class="procedureSubHeading">To create this sample</h3>
<div class="subSection">
<ol>
<li>
<p>Create a new <span class="ui">Windows Application</span> project.</p>
</li><li>
<p>Using the Data Source Configuration Wizard, create a connection to the Northwind database, selecting the
<span class="code">Customers</span> table, and saving the connection string in the application configuration file.</p>
</li><li>
<p>Open the Data Sources Window and drag the <span class="code">Customers</span> table onto the form. DataGridView and BindingNavigator controls are added to the form and configured for the
<span class="code">Customers</span> table.</p>
</li><li>
<p>On the smart tag for the DataGridView, click <span class="ui">Add Query</span>. In the dialog box, change the
<span class="ui">New Query Name</span> to <span class="input">FillByLastName</span>. In the
<span class="ui">Query Text</span>, add <span class="code">WHERE LastName LIKE @lastName &#43; '%'</span> to the end of the
<span class="code">Select</span> statement. A ToolStrip control for searching is added to the form.</p>
</li><li>
<p>Double-click <span class="ui">NorthwindDataSet</span> in <span class="ui">
Solution Explorer</span>. This opens the code file NorthwindDataSet.xsd. Notice the
<span class="code">FillByLastName</span> method is added to the CustomersTableAdapter.</p>
</li></ol>
</div>
<h1>Sample Code</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre id="codePreview" class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;DataSearchForm&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;bindingNavigatorSaveItem_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;bindingNavigatorSaveItem.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CustomersBindingSource.EndEdit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CustomersTableAdapter.Update(<span class="visualBasic__keyword">Me</span>.NorthwindDataSet.Customers)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ExitToolStripMenuItem_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;ExitToolStripMenuItem.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;searchToolStripButton_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;searchToolStripButton.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CustomersTableAdapter.FillByCompanyName(<span class="visualBasic__keyword">Me</span>.NorthwindDataSet.Customers,&nbsp;searchToolStripTextBox.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;showAllToolStripButton_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;showAllToolStripButton.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.CustomersTableAdapter.Fill(<span class="visualBasic__keyword">Me</span>.NorthwindDataSet.Customers)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CustomersDataGridView_DoubleClick(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;CustomersDataGridView.DoubleClick&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;NorthwindDataSet.CustomersRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;row&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(<span class="visualBasic__keyword">CType</span>(<span class="visualBasic__keyword">Me</span>.CustomersBindingSource.Current,&nbsp;DataRowView).Row,&nbsp;NorthwindDataSet.CustomersRow)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Forms.CustomersForm.Show(row.CustomerID)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=1974932208">app.config</a>
</li><li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=1921370579">CustomersForm.Designer.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=1501887047">CustomersForm.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=1129575238">DataSearchForm.Designer.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=305185400">DataSearchForm.vb</a>
</li><li><a href="http://code.msdn.microsoft.com/Data-Search-From-a-Database-90f2bacd/sourcecode?fileId=22492&pathId=1115577975">NorthwindDataSet.Designer.vb</a>
</li></ul>
