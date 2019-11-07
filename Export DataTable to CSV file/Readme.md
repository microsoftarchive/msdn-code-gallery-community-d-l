# Export DataTable to CSV file ..
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- CSV
- VB NET
## Topics
- CSV
- VB.NET Examples
## Updated
- 04/25/2018
## Description

<h3>Introduction</h3>
<p>WEB application - how to export Data Table to CSV file.<br>
Logic working with ANY chars in the column(s), it uses StringBuilder for build output string, this approach radically increases performance.</p>
<p>SEE ALSO:&nbsp;<span style="background-color:#ffff00"><a href="https://code.msdn.microsoft.com/windowsapps/Export-DataSet-to-Excel-d555b6ba">Export DataSet to Excel file with multiple sheets (NO &quot;3d&quot; party libraries).</a></span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:1.17em">Description&nbsp;</span></strong></p>
<p>Select button [Export To CSV] and [Save] or [Open] file.</p>
<p>&nbsp;</p>
<p><img id="164057" src="164057-csv1.png" alt="" width="388" height="299"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="164058" src="164058-csv2.png" alt="" width="378" height="305"></p>
<p>See Example below.</p>
<p>&nbsp;</p>
<p><img id="164059" src="164059-csv3.png" alt="" width="437" height="371"></p>
<p>&nbsp;</p>
<p><em>&nbsp;</em></p>
<h3><span>Build the Sample<br>
</span></h3>
<ol>
<li>Start Visual Studio Express&nbsp;2012 for Windows&nbsp;8 and select <strong>File</strong> &gt;<strong>Open</strong> &gt;
<strong>Project/Solution</strong>. </li><li>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Visual Studio Express&nbsp;2012 for Windows&nbsp;8 Solution (.sln) file.
</li><li>Press F7 or use <strong>Build</strong> &gt; <strong>Build Solution</strong> to build the sample.
</li></ol>
<p>&nbsp;</p>
<h3><span>&nbsp;Run the sample</span></h3>
<p>To debug the app and then run it, press F5 or use <strong>Debug</strong> &gt; <strong>
Start Debugging</strong>. To execute the app without debugging, press Ctrl&#43;F5 or use
<strong>Debug</strong> &gt; <strong>Start Without Debugging</strong>.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Function csvBytesWriter(ByRef dTable As DataTable) As Byte()

        '--------Columns Name---------------------------------------------------------------------------

        Dim sb As StringBuilder = New StringBuilder()
        Dim intClmn As Integer = dTable.Columns.Count

        Dim i As Integer = 0
        For i = 0 To intClmn - 1 Step i &#43; 1
            sb.Append(&quot;&quot;&quot;&quot; &#43; dTable.Columns(i).ColumnName.ToString() &#43; &quot;&quot;&quot;&quot;)
            If i = intClmn - 1 Then
                sb.Append(&quot; &quot;)
            Else
                sb.Append(&quot;,&quot;)
            End If
        Next
        sb.Append(vbNewLine)

        '--------Data By  Columns---------------------------------------------------------------------------

        Dim row As DataRow
        For Each row In dTable.Rows

            Dim ir As Integer = 0
            For ir = 0 To intClmn - 1 Step ir &#43; 1
                sb.Append(&quot;&quot;&quot;&quot; &#43; row(ir).ToString().Replace(&quot;&quot;&quot;&quot;, &quot;&quot;&quot;&quot;&quot;&quot;) &#43; &quot;&quot;&quot;&quot;)
                If ir = intClmn - 1 Then
                    sb.Append(&quot; &quot;)
                Else
                    sb.Append(&quot;,&quot;)
                End If

            Next
            sb.Append(vbNewLine)
        Next

        Return System.Text.Encoding.UTF8.GetBytes(sb.ToString)

    End Function</pre>
<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;csvBytesWriter(<span class="visualBasic__keyword">ByRef</span>&nbsp;dTable&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataTable)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'--------Columns&nbsp;Name---------------------------------------------------------------------------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;intClmn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;dTable.Columns.Count&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;intClmn&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;i&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>&nbsp;&#43;&nbsp;dTable.Columns(i).ColumnName.ToString()&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;i&nbsp;=&nbsp;intClmn&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;&nbsp;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(vbNewLine)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'--------Data&nbsp;By&nbsp;&nbsp;Columns---------------------------------------------------------------------------</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;row&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;dTable.Rows&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ir&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;ir&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;intClmn&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Step</span>&nbsp;ir&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>&nbsp;&#43;&nbsp;row(ir).ToString().Replace(<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>)&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ir&nbsp;=&nbsp;intClmn&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;&nbsp;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sb.Append(vbNewLine)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;System.Text.Encoding.UTF8.GetBytes(sb.ToString)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li>Function csvBytesWriter(ByRef dTable As DataTable) As Byte() </li><li>'--------Columns Name---------------------------------------------------------------------------
</li><li>Dim sb As StringBuilder = New StringBuilder() </li><li>Dim intClmn As Integer = dTable.Columns.Count </li><li>Dim i As Integer = 0&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>For i = 0 To intClmn - 1 Step i &#43; 1&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>sb.Append(&quot;&quot;&quot;&quot; &#43; dTable.Columns(i).ColumnName.ToString() &#43; &quot;&quot;&quot;&quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>If i = intClmn - 1 Then&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>sb.Append(&quot; &quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>Else&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>sb.Append(&quot;,&quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>End If&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>Next&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>sb.Append(vbNewLine) </li><li>'--------Data By &nbsp;Columns---------------------------------------------------------------------------
</li><li>Dim row As DataRow&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>For Each row In dTable.Rows </li><li>Dim ir As Integer = 0&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>For ir = 0 To intClmn - 1 Step ir &#43; 1&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>sb.Append(&quot;&quot;&quot;&quot; &#43; row(ir).ToString().Replace(&quot;&quot;&quot;&quot;, &quot;&quot;&quot;&quot;&quot;&quot;) &#43; &quot;&quot;&quot;&quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>If ir = intClmn - 1 Then&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>sb.Append(&quot; &quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>Else&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
</li><li>sb.Append(&quot;,&quot;)&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>End If </li><li>Next&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>sb.Append(vbNewLine)&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; </li><li>Next </li><li>Return System.Text.Encoding.UTF8.GetBytes(sb.ToString) </li><li>End Function </li></ul>
<h1>More Information</h1>
<p><em><span>As always, please take the time to rate this example if you found it helpful. I'll endeavour to answer any questions in the Questions &#43; Answers section of this web page. Thanks</span></em></p>
