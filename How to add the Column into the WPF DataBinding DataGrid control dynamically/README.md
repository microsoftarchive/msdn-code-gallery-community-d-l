# How to add the Column into the WPF DataBinding DataGrid control dynamically
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- DataGrid
- Data Binding
- WPF Data Binding
- dynamic Type
- DataGrid Binding
## Updated
- 09/11/2011
## Description

<h1>Introduction</h1>
<p>This sample DEMOs how to add the column into the DataGrid which is bound to one Collection or one DataTable.</p>
<h1><span>Building the Sample</span></h1>
<p>There are two projects in this sample, one for binding the Collection object on the DataGrid, and the other for binding the DataTable to the DataGrid. In the Collection object, I use the dynamic type, so you have to build the first project in the .Net 4
 Framework and work in WPF 4. The second project can work in the .Net 3.5 and 4 both, in the .Net 3.5 Framework, we could use the WPF Toolkit DataGrid to replace the build-in DataGrid control in WPF 4.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample DEMOs how to add the column into the DataGrid which is bound to one Collection or one DataTable.</p>
<p>As we knoe, in WPF, DataGird is one ItemsControl and it only supports the DataGridRows, (the DataGridRow supports to contain the DataGridCells in it). So we cannot get the columns in the DataGrid at the run-time, the DataGrid does not have the column structure
 in its Visual Tree. But we could generate the column automatically by setting the property<span style="color:#000000"> AutoGenerateColumns to True</span><em><span style="color:#000000">.</span></em><span style="color:#000000"> So if we could dynamically add
 the Column into the bound DataTable, the DataGrid should show the changes by refresh its DataBinding.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;AddRow_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataRow&nbsp;dr&nbsp;=&nbsp;dt.NewRow();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;columIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;columIndex&nbsp;&lt;&nbsp;dt.Columns.Count;&nbsp;columIndex&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr[columIndex]&nbsp;=&nbsp;<span class="js__string">&quot;New&nbsp;Row&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;columIndex.ToString();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add(dr);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;newColumnIndex&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;AddColumn_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="js__operator">new</span>&nbsp;DataColumn(<span class="js__string">&quot;New&nbsp;Column&quot;</span>&nbsp;&#43;&nbsp;newColumnIndex&#43;&#43;));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;dt.Rows.Count;&nbsp;i&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows[i][dt.Columns.Count&nbsp;-&nbsp;<span class="js__num">1</span>]&nbsp;=&nbsp;i.ToString()&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;-&nbsp;New&nbsp;Column&quot;</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Refresh&nbsp;the&nbsp;DataGrid&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.ItemsSource&nbsp;=&nbsp;null;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.ItemsSource&nbsp;=&nbsp;dt.DefaultView;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span style="color:#000000">&nbsp;</span></p>
<hr>
<p>&nbsp;</p>
<p>If you want to bind the object collection to the DataGrid, not use the DataTable. I could recommend you use reference the new freature of .Net 4-- dynamic type:
<a href="http://msdn.microsoft.com/en-us/library/dd264736.aspx">http://msdn.microsoft.com/en-us/library/dd264736.aspx</a>&nbsp;and WPF 4 alose supports to bind the dynamic object:
<a href="http://blogs.msdn.com/b/llobo/archive/2009/11/02/new-wpf-feature-binding-to-dynamic-objects.aspx">
http://blogs.msdn.com/b/llobo/archive/2009/11/02/new-wpf-feature-binding-to-dynamic-objects.aspx</a>&nbsp;</p>
<p>In the dynamic object, we could add the new properties at run-time, and add the new column into the DataGrid to bind to the new property.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;IEnumerable&lt;string&gt;&nbsp;PropertyNames;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainWindow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyNames&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;string&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;<span class="js__num">5</span>;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;item&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DynamicObjectClass();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.A&nbsp;=&nbsp;<span class="js__string">&quot;Property&nbsp;A&nbsp;value&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.B&nbsp;=&nbsp;<span class="js__string">&quot;Property&nbsp;B&nbsp;value&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;i.ToString();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyNames&nbsp;=&nbsp;item.GetDynamicMemberNames();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Add&nbsp;Columns</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.Columns.Add(<span class="js__operator">new</span>&nbsp;DataGridTextColumn()&nbsp;<span class="js__brace">{</span>Header=<span class="js__string">&quot;A&quot;</span>,&nbsp;Binding&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Binding(<span class="js__string">&quot;A&quot;</span>)&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.Columns.Add(<span class="js__operator">new</span>&nbsp;DataGridTextColumn()&nbsp;<span class="js__brace">{</span>Header=<span class="js__string">&quot;B&quot;</span>,&nbsp;Binding&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Binding(<span class="js__string">&quot;B&quot;</span>)&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.ItemsSource&nbsp;=&nbsp;items;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;AddRow_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamic&nbsp;item&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DynamicObjectClass();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(string&nbsp;PropertyName&nbsp;<span class="js__operator">in</span>&nbsp;PropertyNames)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.TrySetMember(<span class="js__operator">new</span>&nbsp;SetPropertyBinder(PropertyName),&nbsp;<span class="js__string">&quot;New&nbsp;Item&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;PropertyName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;items.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;newColumnIndex&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;AddColumn_Click(object&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(DynamicObjectClass&nbsp;item&nbsp;<span class="js__operator">in</span>&nbsp;items)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.TrySetMember(<span class="js__operator">new</span>&nbsp;SetPropertyBinder(<span class="js__string">&quot;NewColumn&quot;</span>&nbsp;&#43;&nbsp;newColumnIndex),&nbsp;<span class="js__string">&quot;New&nbsp;Column&nbsp;Value&nbsp;-&nbsp;&quot;</span>&nbsp;&#43;&nbsp;newColumnIndex.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PropertyNames&nbsp;=&nbsp;item.GetDynamicMemberNames();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataGrid.Columns.Add(<span class="js__operator">new</span>&nbsp;DataGridTextColumn()&nbsp;<span class="js__brace">{</span>&nbsp;Header&nbsp;=&nbsp;<span class="js__string">&quot;New&nbsp;Column&quot;</span>&nbsp;&#43;&nbsp;newColumnIndex,&nbsp;Binding&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Binding(<span class="js__string">&quot;NewColumn&quot;</span>&nbsp;&#43;&nbsp;newColumnIndex)&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;newColumnIndex&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<h1>More Information</h1>
<p>&nbsp;And in this sample, I use one DynamicObjectClass, please refer to: <a href="http://blogs.msdn.com/b/llobo/archive/2009/11/02/new-wpf-feature-binding-to-dynamic-objects.aspx">
http://blogs.msdn.com/b/llobo/archive/2009/11/02/new-wpf-feature-binding-to-dynamic-objects.aspx</a></p>
