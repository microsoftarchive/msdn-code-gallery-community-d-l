# DataGridView Helper Class
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- C#
- DataGridView
- WinForms
## Topics
- C#
- DataGridView
- WinForms
## Updated
- 11/18/2015
## Description

<h1>Introduction</h1>
<p><em><img id="140417" src="140417-1.jpg" alt="" width="648" height="233"></em></p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
In this article I will explain about how to create a Helper Class for DataGridView in Winform Application. In one of my web project I want to create the datagridview Dynamically at runtime. When i start my project I was looking for a Helper Class for DataGridView
 and used Google for get one Helper Class. But i couldn&rsquo;t found any helper class for DataGridView. So I plan to create a Helper Class for DataGridView. As a result I have created a helper class for DataGridView. I want to share my helper class with others
 so that they can use my class in there project and make a code simple and easy.</p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">WHY WE NEED HELPER CLASS:</strong></p>
<ul style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; margin:10px 0px; padding:0px 0px 0px 40px; border:0px currentColor; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Helper Class will make our code part Simple and Standard. </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
All the Events of DataGridview can be defined in the helperClass . In our form we can call the method from helper class and make our code simple.
</li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
One Time Design in Class can be used for the whole project. </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
This will be useful if we change design only in Class File and no need to redesign in each form.
</li></ul>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">WHAT WE HAVE IN HELPER CLASS:</strong></p>
<ul style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; margin:10px 0px; padding:0px 0px 0px 40px; border:0px currentColor; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Design your Datagridview ,Add the Datagridview to your controls like Panel,Tab or in your form.
</li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Bound Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
CheckBox Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
TextBox Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Numeric TextBox Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
ComboBox Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
DateTimePicker Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Button Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Colour Dialog Column </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
DataGridView Events like CellClick,CellContentClick and etc.&nbsp; </li></ul>
<h1><span>Building the Sample</span></h1>
<p><em>Here is an sample with Color Dialog from button Column.<img id="140418" src="140418-2.jpg" alt="" width="636" height="341"></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
First we can start with the helper class and then we can see how to use the helper class in Winform. In my helper class I have the fallowing function to make the design and bind simple.</p>
<ul style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; margin:10px 0px; padding:0px 0px 0px 40px; border:0px currentColor; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Layout </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Generategrid </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
Templatecolumn </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
NumeriTextboxEvents </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
DateTimePickerEvents </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
DGVClickEvents </li><li style="margin:0px; padding:0px; border:0px currentColor; color:#111111; line-height:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px">
colorDialogEvents </li></ul>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
We can see few important functions of the class and then i will paste my full class Code here.</p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">Layout:</strong><span>&nbsp;</span>This method will be setting the BackgroundColor, BackColor,AllowUserToAddRows and etc for the datagridView. In this method we pass our Datagridview and setting
 all the design part for grid.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Set&nbsp;all&nbsp;the&nbsp;DGV&nbsp;layout</span><span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Layout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Layouts(DataGridView&nbsp;ShanuDGV,&nbsp;Color&nbsp;BackgroundColor,&nbsp;Color&nbsp;RowsBackColor,&nbsp;Color&nbsp;AlternatebackColor,&nbsp;Boolean&nbsp;AutoGenerateColumns,&nbsp;Color&nbsp;HeaderColor,&nbsp;Boolean&nbsp;HeaderVisual,&nbsp;Boolean&nbsp;RowHeadersVisible,&nbsp;Boolean&nbsp;AllowUserToAddRows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Grid&nbsp;Back&nbsp;ground&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.BackgroundColor&nbsp;=&nbsp;BackgroundColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Grid&nbsp;Back&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.RowsDefaultCellStyle.BackColor&nbsp;=&nbsp;RowsBackColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//GridColumnStylesCollection&nbsp;Alternate&nbsp;Rows&nbsp;Backcolr</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AlternatingRowsDefaultCellStyle.BackColor&nbsp;=&nbsp;AlternatebackColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Auto&nbsp;generated&nbsp;here&nbsp;set&nbsp;to&nbsp;tru&nbsp;or&nbsp;false.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AutoGenerateColumns&nbsp;=&nbsp;AutoGenerateColumns;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;ShanuDGV.DefaultCellStyle.Font&nbsp;=&nbsp;new&nbsp;Font(&quot;Verdana&quot;,&nbsp;10.25f,&nbsp;FontStyle.Regular);</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;ShanuDGV.ColumnHeadersDefaultCellStyle.Font&nbsp;=&nbsp;new&nbsp;Font(&quot;Calibri&quot;,&nbsp;11,&nbsp;FontStyle.Regular);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Column&nbsp;Header&nbsp;back&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.ColumnHeadersDefaultCellStyle.BackColor&nbsp;=&nbsp;HeaderColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//header&nbsp;Visisble</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.EnableHeadersVisualStyles&nbsp;=&nbsp;HeaderVisual;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Enable&nbsp;the&nbsp;row&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.RowHeadersVisible&nbsp;=&nbsp;RowHeadersVisible;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;to&nbsp;Hide&nbsp;the&nbsp;Last&nbsp;Empty&nbsp;row&nbsp;here&nbsp;we&nbsp;use&nbsp;false.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AllowUserToAddRows&nbsp;=&nbsp;AllowUserToAddRows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span></pre>
</div>
</div>
</div>
<h1><span><strong style="margin:0px; padding:0px; border:0px currentColor; color:#111111; text-transform:none; line-height:normal; text-indent:0px; letter-spacing:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">Generategrid:</strong><span style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">&nbsp;In
 this method we pass our Datagridview and set the height,width,position and bind the datagriview to our selected control.</span></span></h1>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Generategrid(DataGridView&nbsp;ShanuDGV,&nbsp;Control&nbsp;cntrlName,&nbsp;int&nbsp;width,&nbsp;int&nbsp;height,&nbsp;int&nbsp;xval,&nbsp;int&nbsp;yval)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Location&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Point(xval,&nbsp;yval);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Size(width,&nbsp;height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//ShanuDGV.Dock&nbsp;=&nbsp;docktyope.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cntrlName.Controls.Add(ShanuDGV);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</span></h1>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">TemplateColumn:</strong>&nbsp;This is the important method in the helperclass,Here we pass the Datagriview and define the column as Bound ,Checkbox,Textbox DateTimePicker and etc.Here we set each
 column width, Alignment,&nbsp;<span lang="EN-US" style="margin:0px; padding:0px; border:0px currentColor; font-family:&quot;Segoe UI&quot;,sans-serif; font-size:11.5pt">Visibility</span>, BackColor,Font Color and etc.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Templatecolumn(DataGridView&nbsp;ShanuDGV,&nbsp;ShanuControlTypes&nbsp;ShanuControlTypes,&nbsp;String&nbsp;cntrlnames,&nbsp;String&nbsp;Headertext,&nbsp;String&nbsp;ToolTipText,&nbsp;Boolean&nbsp;Visible,&nbsp;<span class="cs__keyword">int</span>&nbsp;width,&nbsp;DataGridViewTriState&nbsp;Resizable,&nbsp;DataGridViewContentAlignment&nbsp;cellAlignment,&nbsp;DataGridViewContentAlignment&nbsp;headerAlignment,&nbsp;Color&nbsp;CellTemplateBackColor,&nbsp;DataTable&nbsp;dtsource,&nbsp;String&nbsp;DisplayMember,&nbsp;String&nbsp;ValueMember,&nbsp;Color&nbsp;CellTemplateforeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">switch</span>&nbsp;(ShanuControlTypes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ShanuControlTypes.CheckBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewCheckBoxColumn&nbsp;dgvChk&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewCheckBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.ValueType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">bool</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="cs__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvChk);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ShanuControlTypes.BoundColumn:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewColumn&nbsp;col&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewTextBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="cs__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(col);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ShanuControlTypes.TextBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewTextBoxColumn&nbsp;dgvText&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewTextBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.ValueType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">decimal</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="cs__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ShanuControlTypes.ComboBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewComboBoxColumn&nbsp;dgvcombo&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewComboBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.ValueType&nbsp;=&nbsp;<span class="cs__keyword">typeof</span>(<span class="cs__keyword">decimal</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DataSource&nbsp;=&nbsp;dtsource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DisplayMember&nbsp;=&nbsp;DisplayMember;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.ValueMember&nbsp;=&nbsp;ValueMember;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="cs__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvcombo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">case</span>&nbsp;ShanuControlTypes.Button:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewButtonColumn&nbsp;dgvButtons&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewButtonColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.FlatStyle&nbsp;=&nbsp;FlatStyle.Popup;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="cs__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvButtons);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong style="margin:0px; padding:0px; border:0px currentColor; color:#111111; text-transform:none; line-height:normal; text-indent:0px; letter-spacing:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">NumerictextBoxEvent:</strong><span style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">&nbsp;In
 this method we pass the Datagridview and list of ColumnIndex which need to be set as NumbericTextbox Column.Using the EditingControlShowing Event of Gridview ,I check for all the columns which need to be accept only numbers from the textbox.</span>&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;NumeriTextboxEvents(DataGridView&nbsp;ShanuDGV,List&lt;<span class="cs__keyword">int</span>&gt;&nbsp;columnIndexs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs&nbsp;=&nbsp;ShanuDGV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listcolumnIndex=columnIndexs;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.EditingControlShowing&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataGridViewEditingControlShowingEventHandler(dShanuDGV_EditingControlShowing);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;grid&nbsp;Editing&nbsp;Control&nbsp;Showing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;dShanuDGV_EditingControlShowing(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;DataGridViewEditingControlShowingEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Control.KeyPress&nbsp;-=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeyPressEventHandler(itemID_KeyPress);<span class="cs__com">//This&nbsp;line&nbsp;of&nbsp;code&nbsp;resolved&nbsp;my&nbsp;issue</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(listcolumnIndex.Contains(shanuDGVs.CurrentCell.ColumnIndex))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox&nbsp;itemID&nbsp;=&nbsp;e.Control&nbsp;<span class="cs__keyword">as</span>&nbsp;TextBox;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(itemID&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;itemID.KeyPress&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;KeyPressEventHandler(itemID_KeyPress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Grid&nbsp;Kyey&nbsp;press&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;itemID_KeyPress(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;KeyPressEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!<span class="cs__keyword">char</span>.IsControl(e.KeyChar)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;!<span class="cs__keyword">char</span>.IsDigit(e.KeyChar))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p class="endscriptcode">&nbsp;<strong style="margin:0px; padding:0px; border:0px currentColor; color:#111111; text-transform:none; line-height:normal; text-indent:0px; letter-spacing:normal; font-family:&quot;Segoe UI&quot;,Arial,sans-serif; font-size:14px; font-style:normal; font-variant:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">DatagridView
 helperClass Full Source Code :</strong><span style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff"><span>&nbsp;</span>&nbsp;Here
 is the full source code of the Datagridview helper class. I have created all the necessary methods which need to be used. if user need more functions they can add those functions as well here in this class and use in your projects.</span></p>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">class&nbsp;ShanuDGVHelper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Variables&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DataGridView&nbsp;shanuDGVs&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridView();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;int&gt;&nbsp;listcolumnIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;DateColumnIndex=<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;ColorColumnIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;ClickColumnIndex&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateTimePicker&nbsp;shanuDateTimePicker;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;EventFucntions;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#&nbsp;endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Set&nbsp;all&nbsp;the&nbsp;Grid&nbsp;layout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Layout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Layouts(DataGridView&nbsp;ShanuDGV,&nbsp;Color&nbsp;BackgroundColor,&nbsp;Color&nbsp;RowsBackColor,&nbsp;Color&nbsp;AlternatebackColor,&nbsp;<span class="js__object">Boolean</span>&nbsp;AutoGenerateColumns,&nbsp;Color&nbsp;HeaderColor,&nbsp;<span class="js__object">Boolean</span>&nbsp;HeaderVisual,&nbsp;<span class="js__object">Boolean</span>&nbsp;RowHeadersVisible,&nbsp;<span class="js__object">Boolean</span>&nbsp;AllowUserToAddRows)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//Grid&nbsp;Back&nbsp;ground&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.BackgroundColor&nbsp;=&nbsp;BackgroundColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Grid&nbsp;Back&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.RowsDefaultCellStyle.BackColor&nbsp;=&nbsp;RowsBackColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//GridColumnStylesCollection&nbsp;Alternate&nbsp;Rows&nbsp;Backcolr</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AlternatingRowsDefaultCellStyle.BackColor&nbsp;=&nbsp;AlternatebackColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Auto&nbsp;generated&nbsp;here&nbsp;set&nbsp;to&nbsp;tru&nbsp;or&nbsp;false.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AutoGenerateColumns&nbsp;=&nbsp;AutoGenerateColumns;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&nbsp;ShanuDGV.DefaultCellStyle.Font&nbsp;=&nbsp;new&nbsp;Font(&quot;Verdana&quot;,&nbsp;10.25f,&nbsp;FontStyle.Regular);</span><span class="js__sl_comment">//&nbsp;ShanuDGV.ColumnHeadersDefaultCellStyle.Font&nbsp;=&nbsp;new&nbsp;Font(&quot;Calibri&quot;,&nbsp;11,&nbsp;FontStyle.Regular);</span><span class="js__sl_comment">//Column&nbsp;Header&nbsp;back&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.ColumnHeadersDefaultCellStyle.BackColor&nbsp;=&nbsp;HeaderColor;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//header&nbsp;Visisble</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.EnableHeadersVisualStyles&nbsp;=&nbsp;HeaderVisual;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Enable&nbsp;the&nbsp;row&nbsp;header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.RowHeadersVisible&nbsp;=&nbsp;RowHeadersVisible;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;to&nbsp;Hide&nbsp;the&nbsp;Last&nbsp;Empty&nbsp;row&nbsp;here&nbsp;we&nbsp;use&nbsp;false.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.AllowUserToAddRows&nbsp;=&nbsp;AllowUserToAddRows;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Add&nbsp;your&nbsp;grid&nbsp;to&nbsp;your&nbsp;selected&nbsp;Control&nbsp;and&nbsp;set&nbsp;height,width,position&nbsp;of&nbsp;your&nbsp;grid.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Variables&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Generategrid(DataGridView&nbsp;ShanuDGV,&nbsp;Control&nbsp;cntrlName,&nbsp;int&nbsp;width,&nbsp;int&nbsp;height,&nbsp;int&nbsp;xval,&nbsp;int&nbsp;yval)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Location&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Point(xval,&nbsp;yval);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Size(width,&nbsp;height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//ShanuDGV.Dock&nbsp;=&nbsp;docktyope.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cntrlName.Controls.Add(ShanuDGV);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Template&nbsp;Column&nbsp;In&nbsp;<span class="js__operator">this</span>&nbsp;column&nbsp;we&nbsp;can&nbsp;add&nbsp;Textbox,Lable,Check&nbsp;Box,Dropdown&nbsp;box&nbsp;and&nbsp;etc&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Templatecolumn&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Templatecolumn(DataGridView&nbsp;ShanuDGV,&nbsp;ShanuControlTypes&nbsp;ShanuControlTypes,&nbsp;<span class="js__object">String</span>&nbsp;cntrlnames,&nbsp;<span class="js__object">String</span>&nbsp;Headertext,&nbsp;<span class="js__object">String</span>&nbsp;ToolTipText,&nbsp;<span class="js__object">Boolean</span>&nbsp;Visible,&nbsp;int&nbsp;width,&nbsp;DataGridViewTriState&nbsp;Resizable,&nbsp;DataGridViewContentAlignment&nbsp;cellAlignment,&nbsp;DataGridViewContentAlignment&nbsp;headerAlignment,&nbsp;Color&nbsp;CellTemplateBackColor,&nbsp;DataTable&nbsp;dtsource,&nbsp;<span class="js__object">String</span>&nbsp;DisplayMember,&nbsp;<span class="js__object">String</span>&nbsp;ValueMember,&nbsp;Color&nbsp;CellTemplateforeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">switch</span>&nbsp;(ShanuControlTypes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">case</span>&nbsp;ShanuControlTypes.CheckBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewCheckBoxColumn&nbsp;dgvChk&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewCheckBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.ValueType&nbsp;=&nbsp;<span class="js__operator">typeof</span>(bool);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="js__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvChk.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvChk);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;ShanuControlTypes.BoundColumn:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewColumn&nbsp;col&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewTextBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="js__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;col.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(col);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;ShanuControlTypes.TextBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewTextBoxColumn&nbsp;dgvText&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewTextBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.ValueType&nbsp;=&nbsp;<span class="js__operator">typeof</span>(decimal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.HeaderText&nbsp;=&nbsp;Headertext;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.ToolTipText&nbsp;=&nbsp;ToolTipText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="js__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvText.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvText);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;ShanuControlTypes.ComboBox:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewComboBoxColumn&nbsp;dgvcombo&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewComboBoxColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.ValueType&nbsp;=&nbsp;<span class="js__operator">typeof</span>(decimal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DataSource&nbsp;=&nbsp;dtsource;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DisplayMember&nbsp;=&nbsp;DisplayMember;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.ValueMember&nbsp;=&nbsp;ValueMember;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="js__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvcombo.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvcombo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">case</span>&nbsp;ShanuControlTypes.Button:&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridViewButtonColumn&nbsp;dgvButtons&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewButtonColumn();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Name&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.FlatStyle&nbsp;=&nbsp;FlatStyle.Popup;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DataPropertyName&nbsp;=&nbsp;cntrlnames;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Visible&nbsp;=&nbsp;Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Width&nbsp;=&nbsp;width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.Automatic;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.Resizable&nbsp;=&nbsp;Resizable;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DefaultCellStyle.Alignment&nbsp;=&nbsp;cellAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.HeaderCell.Style.Alignment&nbsp;=&nbsp;headerAlignment;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CellTemplateBackColor.Name.ToString()&nbsp;!=&nbsp;<span class="js__string">&quot;Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.CellTemplate.Style.BackColor&nbsp;=&nbsp;CellTemplateBackColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dgvButtons.DefaultCellStyle.ForeColor&nbsp;=&nbsp;CellTemplateforeColor;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.Columns.Add(dgvButtons);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//Numeric&nbsp;Textbox&nbsp;event&nbsp;and&nbsp;check&nbsp;<span class="js__statement">for</span>&nbsp;key&nbsp;press&nbsp;event&nbsp;<span class="js__statement">for</span>&nbsp;accepting&nbsp;only&nbsp;numbers&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;selected&nbsp;column&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Numeric&nbsp;Textbox&nbsp;Events&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;&nbsp;<span class="js__operator">void</span>&nbsp;NumeriTextboxEvents(DataGridView&nbsp;ShanuDGV,List&lt;int&gt;&nbsp;columnIndexs)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs&nbsp;=&nbsp;ShanuDGV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listcolumnIndex=columnIndexs;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.EditingControlShowing&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewEditingControlShowingEventHandler(dShanuDGV_EditingControlShowing);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;grid&nbsp;Editing&nbsp;Control&nbsp;Showing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;dShanuDGV_EditingControlShowing(object&nbsp;sender,&nbsp;DataGridViewEditingControlShowingEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Control.KeyPress&nbsp;-=&nbsp;<span class="js__operator">new</span>&nbsp;KeyPressEventHandler(itemID_KeyPress);<span class="js__sl_comment">//This&nbsp;line&nbsp;of&nbsp;code&nbsp;resolved&nbsp;my&nbsp;issue</span><span class="js__statement">if</span>&nbsp;(listcolumnIndex.Contains(shanuDGVs.CurrentCell.ColumnIndex))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox&nbsp;itemID&nbsp;=&nbsp;e.Control&nbsp;as&nbsp;TextBox;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(itemID&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;itemID.KeyPress&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;KeyPressEventHandler(itemID_KeyPress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span><span class="js__sl_comment">//Grid&nbsp;Kyey&nbsp;press&nbsp;event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;itemID_KeyPress(object&nbsp;sender,&nbsp;KeyPressEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(!char.IsControl(e.KeyChar)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;!char.IsDigit(e.KeyChar))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e.Handled&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;Add&nbsp;an&nbsp;datTime&nbsp;Picker&nbsp;control&nbsp;to&nbsp;existing&nbsp;Textbox&nbsp;Column&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;DateTimePicker&nbsp;control&nbsp;to&nbsp;textbox&nbsp;column&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;DateTimePickerEvents(DataGridView&nbsp;ShanuDGV,&nbsp;int&nbsp;columnIndexs,ShanuEventTypes&nbsp;eventtype)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs&nbsp;=&nbsp;ShanuDGV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateColumnIndex&nbsp;=&nbsp;columnIndexs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.CellClick&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewCellEventHandler(shanuDGVs_CellClick);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//switch&nbsp;(eventtype)</span><span class="js__sl_comment">//{</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;case&nbsp;ShanuEventTypes.CellClick:</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.CellClick&nbsp;&#43;=new&nbsp;DataGridViewCellEventHandler(shanuDGVs_CellClick);</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;case&nbsp;ShanuEventTypes.cellContentClick:</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.CellContentClick&nbsp;&#43;=new&nbsp;DataGridViewCellEventHandler(shanuDGVs_CellContentClick);</span><span class="js__sl_comment">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;break;</span><span class="js__sl_comment">//}</span><span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;In&nbsp;this&nbsp;cell&nbsp;click&nbsp;event,DateTime&nbsp;Picker&nbsp;Control&nbsp;will&nbsp;be&nbsp;added&nbsp;to&nbsp;the&nbsp;selected&nbsp;column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;shanuDGVs_CellClick(object&nbsp;sender,&nbsp;DataGridViewCellEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(e.ColumnIndex&nbsp;==&nbsp;DateColumnIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDateTimePicker&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DateTimePicker();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs.Controls.Add(shanuDateTimePicker);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDateTimePicker.Format&nbsp;=&nbsp;DateTimePickerFormat.Short;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rectangle&nbsp;dgvRectangle&nbsp;=&nbsp;shanuDGVs.GetCellDisplayRectangle(e.ColumnIndex,&nbsp;e.RowIndex,&nbsp;true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDateTimePicker.Size&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Size(dgvRectangle.Width,&nbsp;dgvRectangle.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDateTimePicker.Location&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Point(dgvRectangle.X,&nbsp;dgvRectangle.Y);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;shanuDateTimePicker.Visible&nbsp;=&nbsp;true;</span><span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;Button&nbsp;Click&nbsp;evnet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Button&nbsp;Click&nbsp;Event&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;DGVClickEvents(DataGridView&nbsp;ShanuDGV,&nbsp;int&nbsp;columnIndexs,&nbsp;ShanuEventTypes&nbsp;eventtype)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs&nbsp;=&nbsp;ShanuDGV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClickColumnIndex&nbsp;=&nbsp;columnIndexs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.CellContentClick&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewCellEventHandler(shanuDGVs_CellContentClick_Event);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;shanuDGVs_CellContentClick_Event(object&nbsp;sender,&nbsp;DataGridViewCellEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(e.ColumnIndex&nbsp;==&nbsp;ClickColumnIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Button&nbsp;Clicked&nbsp;&quot;</span>&nbsp;&#43;&nbsp;shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;Button&nbsp;Click&nbsp;Event&nbsp;to&nbsp;show&nbsp;Color&nbsp;Dialog&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Button&nbsp;Click&nbsp;Event&nbsp;to&nbsp;show&nbsp;Color&nbsp;Dialog&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;colorDialogEvents(DataGridView&nbsp;ShanuDGV,&nbsp;int&nbsp;columnIndexs,&nbsp;ShanuEventTypes&nbsp;eventtype)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs&nbsp;=&nbsp;ShanuDGV;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ColorColumnIndex&nbsp;=&nbsp;columnIndexs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGV.CellContentClick&nbsp;&#43;=&nbsp;<span class="js__operator">new</span>&nbsp;DataGridViewCellEventHandler(shanuDGVs_CellContentClick);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__operator">void</span>&nbsp;shanuDGVs_CellContentClick(object&nbsp;sender,&nbsp;DataGridViewCellEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(e.ColumnIndex&nbsp;==&nbsp;ColorColumnIndex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Button&nbsp;Clicked&nbsp;&quot;</span>&nbsp;&#43;&nbsp;shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ColorDialog&nbsp;cd&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ColorDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cd.ShowDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGVs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor&nbsp;=&nbsp;cd.Color;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</span></h1>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span lang="EN-US" style="margin:0px; padding:0px; border:0px currentColor; font-family:&quot;Segoe UI&quot;,sans-serif; font-size:11.5pt">Now let&rsquo;s see how to use this Helper Class in our winform project.&lt;!--?xml:namespace prefix = &quot;o&quot; /--&gt;</span></p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span lang="EN-US" style="margin:0px; padding:0px; border:0px currentColor; font-family:&quot;Segoe UI&quot;,sans-serif; font-size:11.5pt">1) Add the helperClass file in to your project.</span></p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span lang="EN-US" style="margin:0px; padding:0px; border:0px currentColor; font-family:&quot;Segoe UI&quot;,sans-serif; font-size:11.5pt">2) In your form Load call a Method to create your Datagridview Dynamically and call the functions to design, bind and set the each
 column of your grid.</span></p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<span lang="EN-US" style="margin:0px; padding:0px; border:0px currentColor; font-family:&quot;Segoe UI&quot;,sans-serif; font-size:11.5pt">Here we can see I have created a method called &quot;generatedgvColumns&rdquo; and called this method in my Form Load Event.</span></p>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;<span class="js__operator">void</span>&nbsp;generatedgvColumns()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//First&nbsp;generate&nbsp;the&nbsp;grid&nbsp;Layout&nbsp;Design</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Layouts(shanuDGV,&nbsp;Color.LightSteelBlue,&nbsp;Color.AliceBlue,&nbsp;Color.WhiteSmoke,&nbsp;false,&nbsp;Color.SteelBlue,&nbsp;false,&nbsp;false,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Set&nbsp;Height,width&nbsp;and&nbsp;add&nbsp;panel&nbsp;to&nbsp;your&nbsp;selected&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Generategrid(shanuDGV,&nbsp;pnlShanuGrid,&nbsp;<span class="js__num">1000</span>,&nbsp;<span class="js__num">600</span>,&nbsp;<span class="js__num">10</span>,&nbsp;<span class="js__num">10</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;CheckboxColumn&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.CheckBox,&nbsp;<span class="js__string">&quot;Chk&quot;</span>,&nbsp;<span class="js__string">&quot;ChkCol&quot;</span>,&nbsp;<span class="js__string">&quot;Check&nbsp;Box&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">60</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;Color.Transparent,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;BoundColumn&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.BoundColumn,&nbsp;<span class="js__string">&quot;DGVBoundColumn&quot;</span>,&nbsp;<span class="js__string">&quot;DGVBoundColumn&quot;</span>,&nbsp;<span class="js__string">&quot;Bound&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">120</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;Color.Transparent,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;TextboxColumn&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.TextBox,&nbsp;<span class="js__string">&quot;DGVTXTColumn&quot;</span>,&nbsp;<span class="js__string">&quot;DGVTXTColumn&quot;</span>,&nbsp;<span class="js__string">&quot;textBox&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">130</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleLeft,&nbsp;DataGridViewContentAlignment.MiddleLeft,&nbsp;Color.White,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;NumerictextColumn&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.TextBox,&nbsp;<span class="js__string">&quot;DGVNumericTXTColumn&quot;</span>,&nbsp;<span class="js__string">&quot;NCol&quot;</span>,&nbsp;<span class="js__string">&quot;textBox&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">60</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleRight,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;Color.MistyRose,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;BoundColumn&nbsp;creation&nbsp;which&nbsp;will&nbsp;be&nbsp;used&nbsp;as&nbsp;Datetime&nbsp;picker</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.BoundColumn,&nbsp;<span class="js__string">&quot;DGVDateTimepicker&quot;</span>,&nbsp;<span class="js__string">&quot;DGVDateTimepicker&quot;</span>,&nbsp;<span class="js__string">&quot;For&nbsp;Datetime&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">160</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleLeft,&nbsp;DataGridViewContentAlignment.MiddleLeft,&nbsp;Color.Transparent,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;ComboBox&nbsp;Column&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.ComboBox,&nbsp;<span class="js__string">&quot;DGVComboColumn&quot;</span>,&nbsp;<span class="js__string">&quot;ComboCol&quot;</span>,&nbsp;<span class="js__string">&quot;Combo&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">160</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;DataGridViewContentAlignment.MiddleRight,&nbsp;Color.Transparent,&nbsp;dtName,&nbsp;<span class="js__string">&quot;Name&quot;</span>,&nbsp;<span class="js__string">&quot;Value&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Button&nbsp;Column&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.Button,&nbsp;<span class="js__string">&quot;DGVButtonColumn&quot;</span>,&nbsp;<span class="js__string">&quot;ButtonCol&quot;</span>,&nbsp;<span class="js__string">&quot;Button&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">120</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;DataGridViewContentAlignment.MiddleRight,&nbsp;Color.Transparent,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Color&nbsp;Dialog&nbsp;Column&nbsp;creation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ShanuDGVHelper.Templatecolumn(shanuDGV,&nbsp;ShanuControlTypes.Button,&nbsp;<span class="js__string">&quot;DGVColorDialogColumn&quot;</span>,&nbsp;<span class="js__string">&quot;ButtonCol&quot;</span>,&nbsp;<span class="js__string">&quot;Button&nbsp;&nbsp;Column&quot;</span>,&nbsp;true,&nbsp;<span class="js__num">120</span>,&nbsp;DataGridViewTriState.True,&nbsp;DataGridViewContentAlignment.MiddleCenter,&nbsp;DataGridViewContentAlignment.MiddleRight,&nbsp;Color.Transparent,&nbsp;null,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;Color.Black);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Numeric&nbsp;Textbox&nbsp;Setting&nbsp;and&nbsp;add&nbsp;the&nbsp;Numeric&nbsp;Textbox&nbsp;column&nbsp;index&nbsp;to&nbsp;list</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstNumericTextBoxColumns&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;int&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lstNumericTextBoxColumns.Add(shanuDGV.Columns[<span class="js__string">&quot;DGVNumericTXTColumn&quot;</span>].Index);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Numeric&nbsp;textbox&nbsp;events&nbsp;to&nbsp;allow&nbsp;only&nbsp;numeric&nbsp;is&nbsp;that&nbsp;column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objshanudgvHelper.NumeriTextboxEvents(shanuDGV,&nbsp;lstNumericTextBoxColumns);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Datetime&nbsp;Picker&nbsp;Bind&nbsp;to&nbsp;an&nbsp;existing&nbsp;textbox&nbsp;Column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objshanudgvHelper.DateTimePickerEvents(shanuDGV,&nbsp;shanuDGV.Columns[<span class="js__string">&quot;DGVDateTimepicker&quot;</span>].Index,&nbsp;ShanuEventTypes.CellClick);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Add&nbsp;Color&nbsp;Dialog&nbsp;to&nbsp;Button&nbsp;Column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objshanudgvHelper.colorDialogEvents(shanuDGV,&nbsp;shanuDGV.Columns[<span class="js__string">&quot;DGVColorDialogColumn&quot;</span>].Index,&nbsp;ShanuEventTypes.cellContentClick);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;DGV&nbsp;button&nbsp;Click&nbsp;Event</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objshanudgvHelper.DGVClickEvents(shanuDGV,&nbsp;shanuDGV.Columns[<span class="js__string">&quot;DGVButtonColumn&quot;</span>].Index,&nbsp;ShanuEventTypes.cellContentClick);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Bind&nbsp;data&nbsp;to&nbsp;DGV.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;shanuDGV.DataSource&nbsp;=&nbsp;objDGVBind;&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</span></h1>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">&quot;&nbsp;ShanuDGVHelper.Layouts()&quot;</strong>&nbsp;this &nbsp;method is used to set the layout of grid like autogenrated or not, BackgroundColor, &nbsp;AlternatebackColor, RowHeadersVisible&nbsp;and
 etc.</p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">&quot;ShanuDGVHelper.Generategrid()&quot;</strong>&nbsp;this method is used to set the Height, Width and add the datagridview to our selected control, for example here i have added the DGV to a panel control.</p>
<p style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; white-space:normal; widows:1; background-color:#ffffff">
<strong style="margin:0px; padding:0px; border:0px currentColor">&quot;&nbsp;ShanuDGVHelper.Templatecolumn&quot;&nbsp;</strong>this method is used to define our Column type as Checkbox ,Textbox, Combobox and etc. To this method we pass the Column Name,Column Header Text,Column
 Width,Column Back Color and etc.<span><br>
</span></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>ShanuDGVHelperV1.0.zip<em><em>&nbsp;</em></em> </li></ul>
<h1>More Information</h1>
<p><em><span style="font:14px/normal &quot;Segoe UI&quot;,Arial,sans-serif; color:#111111; text-transform:none; text-indent:0px; letter-spacing:normal; word-spacing:0px; float:none; display:inline!important; white-space:normal; widows:1; background-color:#ffffff">Hope
 this Datagridview Helper Class will be useful for the readers.</span></em></p>
