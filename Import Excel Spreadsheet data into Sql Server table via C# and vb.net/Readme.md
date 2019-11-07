# Import Excel Spreadsheet data into Sql Server table via C# and vb.net
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- SQL Server
- VB.Net
- Excel 2013
## Topics
- Import Excel data into SQL Server
## Updated
- 10/17/2014
## Description

<h1>Introduction</h1>
<p><em>Import Data from SpreadSheet into SQL Server.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>You can import Data from Excel sheet into SQL Server by C# or VB.NET.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<p>Two namespace is required for this process.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports System.Data.SqlClient
Imports System.Data.OleDb</pre>
<pre class="hidden">using System.Data.OleDb;
using System.Data.SqlClient;</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.Data.SqlClient&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Data.OleDb</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Assume that your sample of data on Sheet1 and it contains valid data for the Table1 which is created in SQL Server. The datatype should match with Sheet1 data. This method first delete the data from table1 which is used for
 import purpose and copy all the data from sheet1 by using SqlBulkCopy command.</div>
<div class="endscriptcode">For more details.</div>
<div class="endscriptcode"><a title="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlbulkcopy(v=vs.110).aspx" href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlbulkcopy(v=vs.110).aspx">http://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlbulkcopy(v=vs.110).aspx</a></div>
<div class="endscriptcode"><strong>OleDbConnection </strong>and <strong>OleDbCommand
</strong>is used for Excel Sheet operation.</div>
<div class="endscriptcode"><a title="OleDbConnection" href="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbconnection%28v=vs.110%29.aspx">OleDbConnection</a></div>
<div class="endscriptcode"><a title="OleDbCommand" href="http://msdn.microsoft.com/en-us/library/system.data.oledb.oledbcommand%28v=vs.110%29.aspx">OleDbCommand</a></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">You can modify the code if you want to merge the data from sheet1 into sql server.</div>
<div class="endscriptcode">Replace excelConnection string and SQLConnection String with your connection.</div>
<div class="endscriptcode">Create Table in SQL Server by using this query.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Table1](
	[student] [varchar](50) NULL,
	[rollno] [int] NULL,
	[course] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULLS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">QUOTED_IDENTIFIER</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_PADDING</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">Table1</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">student</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">rollno</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">course</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_PADDING</span>&nbsp;<span class="sql__id">OFF</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Make sure that your data should match with data type which you have created in SQL Server.</div>
</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Public Sub ImportDataFromExcel(excelFilePath As String)
        'declare variables - edit these based on your particular situation
        Dim ssqltable As String = &quot;Table1&quot;
        ' make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different
        Dim myexceldataquery As String = &quot;select student,rollno,course from [sheet1$]&quot;
        Try
            'create our connection strings
            Dim sexcelconnectionstring As String = (Convert.ToString(&quot;provider=microsoft.jet.oledb.4.0;data source=&quot;) &amp; excelFilePath) &#43; &quot;;extended properties=&quot; &#43; &quot;&quot;&quot;excel 8.0;hdr=yes;&quot;&quot;&quot;
            Dim ssqlconnectionstring As String = &quot;Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True&quot;
            'execute a query to erase any previous data from our destination table
            Dim sclearsql As String = Convert.ToString(&quot;delete from &quot;) &amp; ssqltable
            Dim sqlconn As New SqlConnection(ssqlconnectionstring)
            Dim sqlcmd As New SqlCommand(sclearsql, sqlconn)
            sqlconn.Open()
            sqlcmd.ExecuteNonQuery()
            sqlconn.Close()
            'series of commands to bulk copy data from the excel file into our sql table
            Dim oledbconn As New OleDbConnection(sexcelconnectionstring)
            Dim oledbcmd As New OleDbCommand(myexceldataquery, oledbconn)
            oledbconn.Open()
            Dim dr As OleDbDataReader = oledbcmd.ExecuteReader()
            Dim bulkcopy As New SqlBulkCopy(ssqlconnectionstring)
            bulkcopy.DestinationTableName = ssqltable
            While dr.Read()
                bulkcopy.WriteToServer(dr)
            End While
            dr.Close()
            oledbconn.Close()
            Label1.Text = &quot;File imported into sql server.&quot;
            'handle exception
        Catch ex As Exception
        End Try
    End Sub</pre>
<pre class="hidden"> public void ImportDataFromExcel(string excelFilePath)
        {
            //declare variables - edit these based on your particular situation
            string ssqltable = &quot;Table1&quot;;
            // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have    different
            string myexceldataquery = &quot;select student,rollno,course from [Sheet1$]&quot;;
            try
            {
                //create our connection strings
                string sexcelconnectionstring = @&quot;provider=microsoft.jet.oledb.4.0;data source=&quot; &#43; excelFilePath &#43;
                &quot;;extended properties=&quot; &#43; &quot;\&quot;excel 8.0;hdr=yes;\&quot;&quot;;
                string ssqlconnectionstring = &quot;Data Source=SAYYED;Initial Catalog=SyncDB;Integrated Security=True&quot;;
                //execute a query to erase any previous data from our destination table
                string sclearsql = &quot;delete from &quot; &#43; ssqltable;
                SqlConnection sqlconn = new SqlConnection(ssqlconnectionstring);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, sqlconn);
                sqlconn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlconn.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = ssqltable;
                while (dr.Read())
                {
                    bulkcopy.WriteToServer(dr);
                }
                dr.Close();
                oledbconn.Close();
                Label1.Text = &quot;File imported into sql server.&quot;;
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ImportDataFromExcel(excelFilePath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'declare&nbsp;variables&nbsp;-&nbsp;edit&nbsp;these&nbsp;based&nbsp;on&nbsp;your&nbsp;particular&nbsp;situation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ssqltable&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Table1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;make&nbsp;sure&nbsp;your&nbsp;sheet&nbsp;name&nbsp;is&nbsp;correct,&nbsp;here&nbsp;sheet&nbsp;name&nbsp;is&nbsp;sheet1,&nbsp;so&nbsp;you&nbsp;can&nbsp;change&nbsp;your&nbsp;sheet&nbsp;name&nbsp;if&nbsp;have&nbsp;&nbsp;&nbsp;&nbsp;different</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myexceldataquery&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;select&nbsp;student,rollno,course&nbsp;from&nbsp;[sheet1$]&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'create&nbsp;our&nbsp;connection&nbsp;strings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sexcelconnectionstring&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;(Convert.ToString(<span class="visualBasic__string">&quot;provider=microsoft.jet.oledb.4.0;data&nbsp;source=&quot;</span>)&nbsp;&amp;&nbsp;excelFilePath)&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;;extended&nbsp;properties=&quot;</span>&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;excel&nbsp;8.0;hdr=yes;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ssqlconnectionstring&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Data&nbsp;Source=SAYYED;Initial&nbsp;Catalog=SyncDB;Integrated&nbsp;Security=True&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'execute&nbsp;a&nbsp;query&nbsp;to&nbsp;erase&nbsp;any&nbsp;previous&nbsp;data&nbsp;from&nbsp;our&nbsp;destination&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sclearsql&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;Convert.ToString(<span class="visualBasic__string">&quot;delete&nbsp;from&nbsp;&quot;</span>)&nbsp;&amp;&nbsp;ssqltable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sqlconn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlConnection(ssqlconnectionstring)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sqlcmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlCommand(sclearsql,&nbsp;sqlconn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlconn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlcmd.ExecuteNonQuery()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sqlconn.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'series&nbsp;of&nbsp;commands&nbsp;to&nbsp;bulk&nbsp;copy&nbsp;data&nbsp;from&nbsp;the&nbsp;excel&nbsp;file&nbsp;into&nbsp;our&nbsp;sql&nbsp;table</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oledbconn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbConnection(sexcelconnectionstring)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;oledbcmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;OleDbCommand(myexceldataquery,&nbsp;oledbconn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oledbconn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;OleDbDataReader&nbsp;=&nbsp;oledbcmd.ExecuteReader()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bulkcopy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SqlBulkCopy(ssqlconnectionstring)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bulkcopy.DestinationTableName&nbsp;=&nbsp;ssqltable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;dr.Read()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bulkcopy.WriteToServer(dr)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dr.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;oledbconn.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Label1.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;File&nbsp;imported&nbsp;into&nbsp;sql&nbsp;server.&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'handle&nbsp;exception</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - <a id="127160" href="/site/view/file/127160/1/Book1.xlsx">
Book1.xlsx</a><br>
</em></li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
