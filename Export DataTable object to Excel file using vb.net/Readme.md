# Export DataTable object to Excel file using vb.net
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- VB.Net
- Excel 2010
- DataTable
## Topics
- Excel
- VB.Net
- COM Interop
- DataTable
- Data Export
## Updated
- 10/17/2012
## Description

<h1>Introduction</h1>
<p><em>The sample applciation demonstrates that how you can export the datatable object in c# to excel format.</em></p>
<h1><span>How to use</span></h1>
<p><em>1. Download the sample project.</em></p>
<p><em>2. Open with your visual studio.</em></p>
<p><em>3. Build the project and Run.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Let's say we have a datatable object that contains the emoloyees' details ( employee id, name and age). And we need to export this data to an excel file. For it firstly i create a datatable object of the employees' details at runtime. I am using DataGrodVoew
 cxontrol to show this data with the help of its DataSource property.</em></p>
<p><em>The sample application allows you to chosse the your excel file name and the option for inserting the column names in to excel file ot not.</em></p>
<p><em>We need to add the reference of the Microsoft.Office.Interop.excel library.</em></p>
<h1>Code</h1>
<p><strong>Create the datatable and set datasource to datagridview.</strong></p>
<p>The following code shows how to create the data table object at runtime.</p>
<p><strong></strong></p>
<div class="scriptcode"><strong>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataSource = GetDatatable()
    End Sub
    Private Function GetDatatable() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(&quot;id&quot;)
        dt.Columns.Add(&quot;Name&quot;)

        dt.Rows.Add()
        dt.Rows(0)(0) = &quot;1&quot;
        dt.Rows(0)(1) = &quot;David&quot;

        dt.Rows.Add()
        dt.Rows(1)(0) = &quot;2&quot;
        dt.Rows(1)(1) = &quot;Ram&quot;

        dt.Rows.Add()
        dt.Rows(2)(0) = &quot;3&quot;
        dt.Rows(2)(1) = &quot;John&quot;
        Return dt
    End Function</pre>
<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;Form1_Load(ByVal&nbsp;sender&nbsp;As&nbsp;System.<span class="js__object">Object</span>,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;System.EventArgs)&nbsp;Handles&nbsp;MyBase.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.DataSource&nbsp;=&nbsp;GetDatatable()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;<span class="js__object">Function</span>&nbsp;GetDatatable()&nbsp;As&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dt&nbsp;As&nbsp;New&nbsp;DataTable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="js__string">&quot;id&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Columns.Add(<span class="js__string">&quot;Name&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">0</span>)(<span class="js__num">0</span>)&nbsp;=&nbsp;<span class="js__string">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">0</span>)(<span class="js__num">1</span>)&nbsp;=&nbsp;<span class="js__string">&quot;David&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">1</span>)(<span class="js__num">0</span>)&nbsp;=&nbsp;<span class="js__string">&quot;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">1</span>)(<span class="js__num">1</span>)&nbsp;=&nbsp;<span class="js__string">&quot;Ram&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows.Add()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">2</span>)(<span class="js__num">0</span>)&nbsp;=&nbsp;<span class="js__string">&quot;3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dt.Rows(<span class="js__num">2</span>)(<span class="js__num">1</span>)&nbsp;=&nbsp;<span class="js__string">&quot;John&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;dt&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</strong></div>
<p><strong></p>
<div class="endscriptcode">&nbsp;Exmport to Excel</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Private Sub ExportToExcel(ByVal dtTemp As DataTable, ByVal filepath As String)
        Dim strFileName As String = filepath
        If System.IO.File.Exists(strFileName) Then
            If (MessageBox.Show(&quot;Do you want to replace from the existing file?&quot;, &quot;Export to Excel&quot;, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = System.Windows.Forms.DialogResult.Yes) Then
                System.IO.File.Delete(strFileName)
            Else
                Return
            End If
       
        End If
        Dim _excel As New Excel.Application
        Dim wBook As Excel.Workbook
        Dim wSheet As Excel.Worksheet

        wBook = _excel.Workbooks.Add()
        wSheet = wBook.ActiveSheet()

        Dim dt As System.Data.DataTable = dtTemp
        Dim dc As System.Data.DataColumn
        Dim dr As System.Data.DataRow
        Dim colIndex As Integer = 0
        Dim rowIndex As Integer = 0
        If CheckBox1.Checked Then
            For Each dc In dt.Columns
                colIndex = colIndex &#43; 1
                wSheet.Cells(1, colIndex) = dc.ColumnName
            Next
        End If
        For Each dr In dt.Rows
            rowIndex = rowIndex &#43; 1
            colIndex = 0
            For Each dc In dt.Columns
                colIndex = colIndex &#43; 1
                wSheet.Cells(rowIndex &#43; 1, colIndex) = dr(dc.ColumnName)
            Next
        Next
        wSheet.Columns.AutoFit()
        wBook.SaveAs(strFileName)

        ReleaseObject(wSheet)
        wBook.Close(False)
        ReleaseObject(wBook)
        _excel.Quit()
        ReleaseObject(_excel)
        GC.Collect()

        MessageBox.Show(&quot;File Export Successfully!&quot;)
    End Sub
    Private Sub ReleaseObject(ByVal o As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(o) &gt; 0)
            End While
        Catch
        Finally
            o = Nothing
        End Try
    End Sub</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;ExportToExcel(ByVal&nbsp;dtTemp&nbsp;As&nbsp;DataTable,&nbsp;ByVal&nbsp;filepath&nbsp;As&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;strFileName&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;filepath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;System.IO.File.Exists(strFileName)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;(MessageBox.Show(<span class="js__string">&quot;Do&nbsp;you&nbsp;want&nbsp;to&nbsp;replace&nbsp;from&nbsp;the&nbsp;existing&nbsp;file?&quot;</span>,&nbsp;<span class="js__string">&quot;Export&nbsp;to&nbsp;Excel&quot;</span>,&nbsp;MessageBoxButtons.YesNo,&nbsp;MessageBoxIcon.Question,&nbsp;MessageBoxDefaultButton.Button2)&nbsp;=&nbsp;System.Windows.Forms.DialogResult.Yes)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.IO.File.Delete(strFileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;_excel&nbsp;As&nbsp;New&nbsp;Excel.Application&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;wBook&nbsp;As&nbsp;Excel.Workbook&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;wSheet&nbsp;As&nbsp;Excel.Worksheet&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wBook&nbsp;=&nbsp;_excel.Workbooks.Add()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wSheet&nbsp;=&nbsp;wBook.ActiveSheet()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dt&nbsp;As&nbsp;System.Data.DataTable&nbsp;=&nbsp;dtTemp&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dc&nbsp;As&nbsp;System.Data.DataColumn&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;dr&nbsp;As&nbsp;System.Data.DataRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;colIndex&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;rowIndex&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;CheckBox1.Checked&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;dc&nbsp;In&nbsp;dt.Columns&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colIndex&nbsp;=&nbsp;colIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wSheet.Cells(<span class="js__num">1</span>,&nbsp;colIndex)&nbsp;=&nbsp;dc.ColumnName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;dr&nbsp;In&nbsp;dt.Rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowIndex&nbsp;=&nbsp;rowIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colIndex&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;dc&nbsp;In&nbsp;dt.Columns&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colIndex&nbsp;=&nbsp;colIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wSheet.Cells(rowIndex&nbsp;&#43;&nbsp;<span class="js__num">1</span>,&nbsp;colIndex)&nbsp;=&nbsp;dr(dc.ColumnName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wSheet.Columns.AutoFit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wBook.SaveAs(strFileName)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseObject(wSheet)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wBook.Close(False)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseObject(wBook)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_excel.Quit()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ReleaseObject(_excel)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GC.Collect()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;File&nbsp;Export&nbsp;Successfully!&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Sub&nbsp;ReleaseObject(ByVal&nbsp;o&nbsp;As&nbsp;<span class="js__object">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;(System.Runtime.InteropServices.Marshal.ReleaseComObject(o)&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Finally&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;o&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
</strong>
<p></p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Form1.vb contains all code for creating data table at run time and export to excel.
</li></ul>
<h1>More Information</h1>
<p><em>When you works with any office component programming, some time </em>Office application does not quit after automation:&nbsp;</p>
<p><a href="http://support.microsoft.com/kb/317109">http://support.microsoft.com/kb/317109</a>&nbsp;</p>
<p>How ever i hope you will not face this problem with the above sample code.</p>
