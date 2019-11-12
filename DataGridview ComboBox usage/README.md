# DataGridview ComboBox usage
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- DataGridView
## Topics
- DataGridView
- DataGridViewComboBoxColumn
## Updated
- 11/17/2015
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This article focuses on how setup a <a title="MSDN Documentation" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridviewcomboboxcolumn(v=vs.110).aspx">
DataGridViewComboBox</a> column and retrieving the current selection&nbsp; with the majority of samples included are populated by table or tables from a database while one example is populated via straight to the DataGridView, no data source.<br>
<br>
<strong><span style="font-size:medium">Important note</span></strong>: While writing this article the editor caused some problems which are beyond my control with code snipplets so bare that in mind.<br>
</span></p>
<p><span style="font-size:small"><strong>Update 3/9/2014</strong> in the VB.NET/C# solution I added a very simple version of using ComboBox columns for&nbsp;VB and C. This came out of a question on Microsoft Social forumns.</span></p>
<p><span style="font-size:small"><strong>Update 7/21/2015</strong>: Added a <a href="https://code.msdn.microsoft.com/DataGridView-ComboBox-83c70321">
companion sample</a> which shows how to allow navigation for auto-complete feature of a ComboBox using a custom DataGridView.<br>
<br>
<strong>Update 11/17/2015</strong>: Added Demo1_C which is the base of Demo1 done in VB.NET.<br>
</span></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><span style="font-size:small">What they all have in common is we subscribe to a DataGridView
<a title="MSDN Documentation" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datagridview.editingcontrolshowing(v=vs.110).aspx">
EditingControlShowing </a>event, determine if the column type is ComboBox then check if the column is one we are interested in. Example, we have one ComboBox column, we need only check the type as shown below where IsComboBoxCell is a language extension included
 in the samples.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DataGridView1EditingControlShowing(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;&nbsp;
<span class="visualBasic__keyword">Handles</span>&nbsp;DataGridView1.EditingControlShowing&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;we&nbsp;have&nbsp;a&nbsp;ComboBox&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;DataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;object&nbsp;sender,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewEditingControlShowingEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(DataGridView1.CurrentCell.IsComboBoxCell())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;we&nbsp;have&nbsp;a&nbsp;combobox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Next we will determine if the current column is the one we are interested in by checking the current column name to the one we want by asking if the current cell column name is, in this case ContactPosition.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DataGridView1EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;
<span class="visualBasic__keyword">Handles</span>&nbsp;DataGridView1.EditingControlShowing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ContactPosition&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;We&nbsp;have&nbsp;the&nbsp;column&nbsp;we&nbsp;are&nbsp;interested&nbsp;in</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;<span class="js__operator">void</span>&nbsp;DataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;object&nbsp;sender,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewEditingControlShowingEventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(DataGridView1.CurrentCell.IsComboBoxCell())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name&nbsp;==&nbsp;<span class="js__string">&quot;ContactsColumn&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;we&nbsp;have&nbsp;the&nbsp;column&nbsp;we&nbsp;are&nbsp;interested&nbsp;in&nbsp;now</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Once we have established this we will cast e.Control (the second parameter to the EditingControlShowing event of the DataGridView) to a CombBox then subscribe to it's SelectionChangeCommitted event.</span>&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;DataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewEditingControlShowingEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(DataGridView1.CurrentCell.IsComboBoxCell())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name&nbsp;==&nbsp;<span class="cs__string">&quot;ContactsColumn&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox&nbsp;cb&nbsp;=&nbsp;e.Control&nbsp;<span class="cs__keyword">as</span>&nbsp;ComboBox;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(cb&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.SelectionChangeCommitted&nbsp;-=&nbsp;_SelectionChangeCommitted;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.SelectionChangeCommitted&nbsp;&#43;=&nbsp;_SelectionChangeCommitted;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DataGridView1EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;
<span class="visualBasic__keyword">Handles</span>&nbsp;DataGridView1.EditingControlShowing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ContactPosition&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ComboBox&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(e.Control,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">RemoveHandler</span>&nbsp;cb.SelectionChangeCommitted,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;cb.SelectionChangeCommitted,&nbsp;<span class="visualBasic__keyword">AddressOf</span>&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small; color:#000000">In the SelectionChangedCommitted event we do what we want, here we simple show the value in a MessageBox.</span></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;_SelectionChangeCommitted(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Value&nbsp;is&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__keyword">CType</span>(sender,&nbsp;DataGridViewComboBoxEditingControl).Text)&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">A more real life example, a user makes a selection in one ComboBox column and we when change the value of another cell (also a ComboBox column in this case) on the same row.</span><br>
<br>
</div>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;_SelectionChangeCommitted(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;CheckBox1.Checked&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__keyword">CType</span>(sender,&nbsp;DataGridViewComboBoxEditingControl).Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;bsPositions.Current&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Index&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;=&nbsp;bsPositions.Find(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;ContactPosition&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">CType</span>(sender,&nbsp;DataGridViewComboBoxEditingControl).Text)&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Index&nbsp;&lt;&gt;&nbsp;-<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsBadges.Position&nbsp;=&nbsp;Index&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.CurrentRow.Cells(DataGridView1.Columns(<span class="visualBasic__string">&quot;BadgeColumn&quot;</span>).Index).Value&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">CType</span>(bsBadges.Current,&nbsp;DataRowView).Row.Field(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)(<span class="visualBasic__string">&quot;Badge&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:small; color:#000000">We could also affect other controls, in this case based on the selection made another DataGridView will be populated using the selection as a filter.</span></div>
</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;_SelectionChangeCommitted(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;bsPositions.Current&nbsp;IsNot&nbsp;Nothing&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Value&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;CType(sender,&nbsp;DataGridViewComboBoxEditingControl).Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bsOther.Filter&nbsp;=&nbsp;<span class="js__string">&quot;ContactPosition&nbsp;='&quot;</span>&nbsp;&amp;&nbsp;Value&nbsp;&amp;&nbsp;<span class="js__string">&quot;'&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;bsOther.Count&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Nothing&nbsp;to&nbsp;filter&nbsp;Contact&nbsp;Position&nbsp;for&nbsp;'&quot;</span>&nbsp;&amp;&nbsp;Value&nbsp;&amp;&nbsp;<span class="js__string">&quot;'&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
End&nbsp;Sub&nbsp;
Private&nbsp;Sub&nbsp;DataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;e&nbsp;As&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;
Handles&nbsp;DataGridView1.EditingControlShowing&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name&nbsp;=&nbsp;<span class="js__string">&quot;ContactsColumn&quot;</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;cb&nbsp;As&nbsp;ComboBox&nbsp;=&nbsp;TryCast(e.Control,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;cb&nbsp;IsNot&nbsp;Nothing&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RemoveHandler&nbsp;cb.SelectionChangeCommitted,&nbsp;AddressOf&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddHandler&nbsp;cb.SelectionChangeCommitted,&nbsp;AddressOf&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
End&nbsp;Sub&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Something else, perhaps dependent on a selection we want to change the colors of a ComboBox, still use the same events.</span></div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;dataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;
Handles&nbsp;DataGridView1.EditingControlShowing&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;cb&nbsp;As&nbsp;ComboBox&nbsp;=&nbsp;TryCast(e.Control,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RemoveHandler&nbsp;cb.SelectionChangeCommitted,&nbsp;AddressOf&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name&nbsp;=&nbsp;<span class="js__string">&quot;ColorsColumn&quot;</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddHandler&nbsp;cb.SelectionChangeCommitted,&nbsp;AddressOf&nbsp;_SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;
End&nbsp;Sub&nbsp;
Private&nbsp;Sub&nbsp;_SelectionChangeCommitted(sender&nbsp;As&nbsp;<span class="js__object">Object</span>,&nbsp;e&nbsp;As&nbsp;EventArgs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;comboBox1&nbsp;As&nbsp;ComboBox&nbsp;=&nbsp;CType(sender,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;comboBox1.BackColor&nbsp;=&nbsp;CType(comboBox1.SelectedItem,&nbsp;Color)&nbsp;
End&nbsp;Sub&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><span style="font-size:small">With the above you should be able to get a handle on how to do common things with a DataGridView ComboBox column. Lastly, from time to time I see developers asking about multi-column DataGridViewComboBox
 columns and felt I should toss one in but not code it myself as I am a firm believer that one should first see if it has already been done (not saying it's 100 percent). So I found one done in C# on Code Project. I ran the demo then created a C# class project
 and dumped the custom column in followed by using it in a new VB.NET project. Well I lie a little, mimicking how the original author wired up the demo was not how I do things so I used their database and hand coded everything and woohoo it works. So no code
 changed to his custom column at all.<br>
&nbsp;</span></div>
<div class="endscriptcode"><span style="font-size:small">Hopefully this article and code will help you with DataGridViewComboBox task.<br>
<br>
</span></div>
<div class="endscriptcode"><span style="font-size:small">Some screenshots from the solution<br>
&nbsp;</span></div>
<div class="endscriptcode"><img id="108287" src="108287-f1.png" alt="" width="419" height="494">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;.</p>
<p><img id="108290" src="108290-f2.png" alt="" width="638" height="381"></p>
