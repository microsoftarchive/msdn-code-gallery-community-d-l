# ExtendedDataGridView Control
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- VB2015
## Topics
- DataGridView
- Extending Controls
- Printing with GDI+
## Updated
- 11/05/2016
## Description

<p><img id="162908" src="162908-31-10-2016%2022.44.13.png" alt="" width="550" height="343"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small">This is an extended DataGridView control that adds three public methods, a&nbsp;ContextMenuStrip, and two custom Events to a standard DataGridView control.&nbsp;The three methods are:</span><br>
<span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Print()</span> </li><li><span style="font-size:small">PreviewPrint()</span> </li><li><span style="font-size:small">SaveasCSV()</span> </li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">with the purposes being fairly self explanatory.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">The ContextMenuStrip has MenuItems for invoking those three methods and a Reveal MenuItem which hosts a UserControl used for revealing hidden columns.&nbsp;The (DataGridView) control uses custom columns which provide an extra property
 to&nbsp;each extended version of the standard DataGridView columns, allowing selection of two&nbsp;custom HeaderCells for the extended DataGridViewCheckBoxCell, which are:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">checkAllHeaderCell</span> </li><li><span style="font-size:small">checkHideColumnHeaderCell</span> </li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small">along with:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Standard - a regular DataGridViewColumnHeaderCell</span>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small">Again the purposes of the HeaderCells are self explanatory.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">All of the other extended DataGridViewColumns don't have the CheckAll option.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">The Printer class called by the Print method is optimized to print any combinations of columns and rows and also prints visual elements, such as ComboBoxes, CheckBoxes, Images, and Cell&nbsp;backcolors.</span></p>
<p><span style="font-size:small">Both the Print and the PreviewPrint methods use a custom PrintDialog, which allows&nbsp;selection of a printer, page ranges, page orientation, number of copies and collating&nbsp;pages in multiple copy print runs.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">The SaveasCSV option allows exporting the DataGridView contents as a CSV file.</span></p>
<p><span style="font-size:small">&nbsp;</span><br>
<span style="font-size:small">The custom Events provided by the extended DataGridView are:</span></p>
<p><br>
<span style="font-size:small"><strong>cellCheckedChanged </strong>- which exposes these properties:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Public columnIndex As Integer &nbsp;&nbsp;</span>
</li><li><span style="font-size:small">Public rowIndex As Integer &nbsp;&nbsp;</span> </li><li><span style="font-size:small">Public newValue As Boolean</span> </li></ul>
<p>&nbsp;</p>
<p><br>
<span style="font-size:small"><strong>cellSelectedIndexChanged </strong>- which exposes these properties:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-size:small">Public columnIndex As Integer</span> </li><li><span style="font-size:small">Public rowIndex As Integer &nbsp;&nbsp;</span> </li><li><span style="font-size:small">Public selectedIndex As Integer &nbsp;&nbsp;</span>
</li><li><span style="font-size:small">Public selectedItem As Object &nbsp;&nbsp;</span>
</li><li><span style="font-size:small">Public selectedValue As Object &nbsp;&nbsp;</span>
</li><li><span style="font-size:small">Public text As String</span> </li></ul>
<p>&nbsp;</p>
<p><br>
<span style="font-size:small">For an example of usage, see:</span><br>
<br>
<span style="font-size:small"><a href="http://social.technet.microsoft.com/wiki/contents/articles/36121.vb-net-extendeddatagridview-control.aspx" target="_blank">http://social.technet.microsoft.com/wiki/contents/articles/36121.vb-net-extendeddatagridview-control.aspx</a></span><br>
<br>
</p>
