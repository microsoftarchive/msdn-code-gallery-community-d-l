# Efficiently working with data readers for SQL-Server in VB.NET
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- SQL Server
- Data Access
- VB.Net
- Unit Test
## Topics
- SQL
- SQL Server
- Data Access
- datareader
- Language extensions
- Assertion
## Updated
- 02/17/2018
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">This code sample is all about working with a DataReader to read all records from a table into a list of a concrete class, read a single record and working with multiple statements to one reader. Unlike many code samples found
 on the web, this one also focuses on reading data with null values is may or may not happen yet if it does you will have a pattern to follow if there are null values. Although everything is shown for SQL-Server, the same patterns will work with other data
 providers other than the one sample for running two SELECT statements on a single data reader.</span></p>
<p><span style="font-size:small">Also, this was done in VB.NET yet using a decent converter will work fine in C#.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small"><em>Before running the unit test you need to create the database, tables and populate the data via script.sql in the data project.</em></span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">To set the stage, I created a table of 5,000 records with fields of integer, string, double and date so you can see how to handle each type of data when they contain null values.&nbsp; All data operations are in a class project
 and demonstrated and tested in a unit test project. Why didn&rsquo;t I include a windows form project? Because we are not testing user interface but instead the read methods.</span></p>
<p><span style="font-size:small">The majority of developers will write their data operations directly in a form and that is a bad practice/habit as the code is now constrained to that form and as more forms are added the data access code is spread out where
 it&rsquo;s better to house all data operations in one or more classes.</span></p>
<p><span style="font-size:small">Digging in, here is an example for reading data from a reference table that may populate a ComboBox, a ListBox or perhaps a DataGridViewComboBox. The only assertion is against opening the connection. But you think, are you not
 looking to trap incorrect indexing columns are correct? No, if you are a professional developer any time you change fields you change code and run unit test.</span></p>
<p><span style="font-size:small">Since this is a reference tables and we are doing a fantastic job to ensure there are no null values there are not null checks (but we will later on).</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function GetStates() As List(Of String)
    mHasException = False

    Dim states As New List(Of String)

    Dim selectStatement As String = &quot;SELECT DISTINCT State &quot; &amp;
                                    &quot;FROM dbo.Customer &quot; &amp;
                                    &quot;WHERE [State] IS NOT NULL&quot;

    Using cn = New SqlConnection(ConnectionString)
        Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}

            Try
                cn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader
                '
                ' For a reference table (as this one is) one would assume there are rows
                ' but it can't hurt to be sure so we use HasRows to check. 
                '
                If reader.HasRows Then
                    While reader.Read

                        states.Add(reader.GetStringSafe(&quot;State&quot;))

                    End While
                End If

            Catch ex As Exception
                Dim test = ex.GetType
                mHasException = True
                mLastException = ex
            End Try

        End Using
    End Using

    Return states

End Function</pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;GetStates()&nbsp;As&nbsp;List(Of&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;states&nbsp;As&nbsp;New&nbsp;List(Of&nbsp;<span class="js__object">String</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;selectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;DISTINCT&nbsp;State&nbsp;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;FROM&nbsp;dbo.Customer&nbsp;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;WHERE&nbsp;[State]&nbsp;IS&nbsp;NOT&nbsp;NULL&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;=&nbsp;New&nbsp;SqlConnection(ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;=&nbsp;New&nbsp;SqlCommand()&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;selectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reader&nbsp;As&nbsp;SqlDataReader&nbsp;=&nbsp;cmd.ExecuteReader&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;For&nbsp;a&nbsp;reference&nbsp;table&nbsp;(as&nbsp;<span class="js__operator">this</span>&nbsp;one&nbsp;is)&nbsp;one&nbsp;would&nbsp;assume&nbsp;there&nbsp;are&nbsp;rows&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">'&nbsp;but&nbsp;it&nbsp;can'</span>t&nbsp;hurt&nbsp;to&nbsp;be&nbsp;sure&nbsp;so&nbsp;we&nbsp;use&nbsp;HasRows&nbsp;to&nbsp;check.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;reader.HasRows&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;reader.Read&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;states.Add(reader.GetStringSafe(<span class="js__string">&quot;State&quot;</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;test&nbsp;=&nbsp;ex.GetType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mLastException&nbsp;=&nbsp;ex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;states&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">Suppose we want to read and populate a list for all customers we could load them into a DataTable but the focus here is for using a data reader.&nbsp;</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Our table</div>
<div class="endscriptcode"><img id="186493" src="186493-1.jpg" alt="" width="278" height="218"></div>
<div class="endscriptcode"><span style="color:#ffffff; font-size:small">.</span></div>
<div class="endscriptcode"><span style="font-size:small">When creating the table I allowed a good deal of null values. Many developers will not write business rules to prevent null values and if left unchecked when reading data with code such as the following
 exceptions will be thrown because the code has no null checks or way to assign values when it reads data.</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function TypicalGetCustomersWithNullsUnChecked() As List(Of Customer)
    mHasException = False

    Dim customerList = New List(Of Customer)

    Dim selectStatement As String = &quot;SELECT Id,FirstName,LastName,Address&quot; &amp;
                                    &quot;,City,State,ZipCode,JoinDate,Pin,Balance &quot; &amp;
                                    &quot;FROM dbo.Customer&quot;

    Try
        Using cn = New SqlConnection(ConnectionString)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                cn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read
                    customerList.Add(New Customer With
                        {
                            .Id = reader.GetInt32(0),
                            .FirstName = reader.GetString(1),
                            .LastName = reader.GetString(2),
                            .Address = reader.GetString(3),
                            .City = reader.GetString(4),
                            .State = reader.GetString(5),
                            .ZipCode = reader.GetString(6),
                            .JoinDate = reader.GetDateTime(7),
                            .Pin = reader.GetInt32(8),
                            .Balance = reader.GetDouble(9)
                        })
                End While
            End Using
        End Using
    Catch ex As Exception
        mHasException = True
        mLastException = ex
    End Try

    Return customerList

End Function</pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;TypicalGetCustomersWithNullsUnChecked()&nbsp;As&nbsp;List(Of&nbsp;Customer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;customerList&nbsp;=&nbsp;New&nbsp;List(Of&nbsp;Customer)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;selectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;Id,FirstName,LastName,Address&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;,City,State,ZipCode,JoinDate,Pin,Balance&nbsp;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;FROM&nbsp;dbo.Customer&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;=&nbsp;New&nbsp;SqlConnection(ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;=&nbsp;New&nbsp;SqlCommand()&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;selectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reader&nbsp;As&nbsp;SqlDataReader&nbsp;=&nbsp;cmd.ExecuteReader&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;reader.Read&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(New&nbsp;Customer&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Id&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">0</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FirstName&nbsp;=&nbsp;reader.GetString(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.LastName&nbsp;=&nbsp;reader.GetString(<span class="js__num">2</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Address&nbsp;=&nbsp;reader.GetString(<span class="js__num">3</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.City&nbsp;=&nbsp;reader.GetString(<span class="js__num">4</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.State&nbsp;=&nbsp;reader.GetString(<span class="js__num">5</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ZipCode&nbsp;=&nbsp;reader.GetString(<span class="js__num">6</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.JoinDate&nbsp;=&nbsp;reader.GetDateTime(<span class="js__num">7</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Pin&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">8</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Balance&nbsp;=&nbsp;reader.GetDouble(<span class="js__num">9</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mLastException&nbsp;=&nbsp;ex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;customerList&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"><span style="font-size:small">To prevent exceptions being thrown we might use</span></div>
<div class="endscriptcode"><span style="font-size:small; color:#ffffff">.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">If(TypeOf pReader(&quot;FirstName&quot;) Is DBNull, Nothing, pReader(&quot;FirstName&quot;).ToString())</pre>
<div class="preview">
<pre class="js">If(TypeOf&nbsp;pReader(<span class="js__string">&quot;FirstName&quot;</span>)&nbsp;Is&nbsp;DBNull,&nbsp;Nothing,&nbsp;pReader(<span class="js__string">&quot;FirstName&quot;</span>).ToString())</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">But that is tedious writing this for each field that may be null. So I have provided the following extension methods.</span></div>
<div class="endscriptcode"><img id="186494" src="186494-2.jpg" alt="" width="337" height="156"></div>
<div class="endscriptcode"><span style="font-size:small">Which are used as follows.</span></div>
<div class="endscriptcode"><span style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function TypicalGetCustomersWithNullsChecks() As List(Of Customer)
    mHasException = False

    Dim customerList = New List(Of Customer)

    Dim selectStatement As String = &quot;SELECT Id,FirstName,LastName,Address&quot; &amp;
                                    &quot;,City,State,ZipCode,JoinDate,Pin,Balance &quot; &amp;
                                    &quot;FROM dbo.Customer&quot;

    Try
        Using cn = New SqlConnection(ConnectionString)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                cn.Open()
                Dim reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read
                    customerList.Add(New Customer With
                        {
                            .Id = reader.GetInt32(0),
                            .FirstName = reader.GetStringSafe(&quot;FirstName&quot;),
                            .LastName = reader.GetStringSafe(&quot;LastName&quot;),
                            .Address = reader.GetStringSafe(&quot;Address&quot;),
                            .City = reader.GetStringSafe(&quot;City&quot;),
                            .State = reader.GetStringSafe(&quot;State&quot;),
                            .ZipCode = reader.GetStringSafe(&quot;ZipCode&quot;),
                            .JoinDate = reader.GetDateTimeSafe(&quot;JoinDate&quot;),
                            .Pin = reader.GetInt32Safe(&quot;Pin&quot;),
                            .Balance = reader.GetDoubleSafe(&quot;Balance&quot;)
                        })
                End While
            End Using
        End Using
    Catch ex As Exception
        mHasException = True
        mLastException = ex
    End Try

    Return customerList

End Function</pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;TypicalGetCustomersWithNullsChecks()&nbsp;As&nbsp;List(Of&nbsp;Customer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;customerList&nbsp;=&nbsp;New&nbsp;List(Of&nbsp;Customer)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;selectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;Id,FirstName,LastName,Address&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;,City,State,ZipCode,JoinDate,Pin,Balance&nbsp;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;FROM&nbsp;dbo.Customer&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;=&nbsp;New&nbsp;SqlConnection(ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;=&nbsp;New&nbsp;SqlCommand()&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;selectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reader&nbsp;As&nbsp;SqlDataReader&nbsp;=&nbsp;cmd.ExecuteReader&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;reader.Read&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customerList.Add(New&nbsp;Customer&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Id&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">0</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FirstName&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;FirstName&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.LastName&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;LastName&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Address&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;Address&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.City&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;City&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.State&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;State&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ZipCode&nbsp;=&nbsp;reader.GetStringSafe(<span class="js__string">&quot;ZipCode&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.JoinDate&nbsp;=&nbsp;reader.GetDateTimeSafe(<span class="js__string">&quot;JoinDate&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Pin&nbsp;=&nbsp;reader.GetInt32Safe(<span class="js__string">&quot;Pin&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Balance&nbsp;=&nbsp;reader.GetDoubleSafe(<span class="js__string">&quot;Balance&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mLastException&nbsp;=&nbsp;ex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;customerList&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Note that the normal .NET method for getting a integer is GetInt32 while the extension method is GetInt32Safe so it's easy to remember. Now (and this is more featured in another one of my recent
<a href="https://code.msdn.microsoft.com/Working-smarter-with-base-29c09bb2?redir=0">
code samples</a>) we can clean up the above and keep the null checking. In this case we will deal with one customer record.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">    Public Function GetCustomerWithNullCheckes(ByVal pIdentifier As Integer) As Customer
        mHasException = False

        Dim customer As Customer = Nothing

        Dim selectStatement As String = &quot;SELECT FirstName,LastName,Address&quot; &amp;
                                        &quot;,City,State,ZipCode,JoinDate,Pin,Balance &quot; &amp;
                                        &quot;FROM dbo.Customer WHERE Id = @Id&quot;

        Try
            Using cn = New SqlConnection(ConnectionString)
                Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                    cmd.Parameters.AddWithValue(&quot;@Id&quot;, pIdentifier)
                    cn.Open()

                    Dim reader As SqlDataReader = cmd.ExecuteReader

                    If reader.HasRows Then

                        reader.Read()

                        customer = CustomerBuilder(reader, pIdentifier)

                    End If
                End Using
            End Using
        Catch ex As Exception
            mHasException = True
            mLastException = ex
        End Try

        Return customer

    End Function</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;<span class="js__object">Function</span>&nbsp;GetCustomerWithNullCheckes(ByVal&nbsp;pIdentifier&nbsp;As&nbsp;Integer)&nbsp;As&nbsp;Customer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;customer&nbsp;As&nbsp;Customer&nbsp;=&nbsp;Nothing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;selectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;FirstName,LastName,Address&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;,City,State,ZipCode,JoinDate,Pin,Balance&nbsp;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;FROM&nbsp;dbo.Customer&nbsp;WHERE&nbsp;Id&nbsp;=&nbsp;@Id&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;=&nbsp;New&nbsp;SqlConnection(ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;=&nbsp;New&nbsp;SqlCommand()&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;selectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cmd.Parameters.AddWithValue(<span class="js__string">&quot;@Id&quot;</span>,&nbsp;pIdentifier)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reader&nbsp;As&nbsp;SqlDataReader&nbsp;=&nbsp;cmd.ExecuteReader&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;reader.HasRows&nbsp;Then&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader.Read()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;customer&nbsp;=&nbsp;CustomerBuilder(reader,&nbsp;pIdentifier)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mLastException&nbsp;=&nbsp;ex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;customer&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">CustomerBuilder first draft (no language extension)</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Function CustomerBuilder(
    ByVal pReader As SqlDataReader,
    Optional ByVal pIdentifier As Integer = 0) As Customer

    Dim Identifier As Integer = 0

    If pIdentifier &gt; 0 Then
        Identifier = pIdentifier
    Else
        Identifier = Integer.Parse(pReader(&quot;id&quot;).ToString())
    End If

    Return New Customer With
{
    .Id = Identifier,
    .FirstName = If(TypeOf pReader(&quot;FirstName&quot;) Is DBNull, Nothing, pReader(&quot;FirstName&quot;).ToString()),
    .LastName = If(TypeOf pReader(&quot;Lastname&quot;) Is DBNull, Nothing, pReader(&quot;Lastname&quot;).ToString()),
    .Address = If(TypeOf pReader(&quot;Address&quot;) Is DBNull, Nothing, pReader(&quot;Address&quot;).ToString()),
    .City = If(TypeOf pReader(&quot;City&quot;) Is DBNull, Nothing, pReader(&quot;City&quot;).ToString()),
    .State = If(TypeOf pReader(&quot;State&quot;) Is DBNull, Nothing, pReader(&quot;State&quot;).ToString()),
    .ZipCode = If(TypeOf pReader(&quot;Zipcode&quot;) Is DBNull, Nothing, pReader(&quot;Zipcode&quot;).ToString()),
    .JoinDate = If(TypeOf pReader(&quot;JoinDate&quot;) Is DBNull, Nothing, CDate(pReader(&quot;JoinDate&quot;).ToString)),
    .Pin = If(TypeOf pReader(&quot;Pin&quot;) Is DBNull, Nothing, CInt(pReader(&quot;Pin&quot;).ToString)),
    .Balance = If(TypeOf pReader(&quot;Balance&quot;) Is DBNull, Nothing, CDbl(pReader(&quot;Balance&quot;).ToString))
}

End Function</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;CustomerBuilder(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;pReader&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SqlDataReader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Optional</span>&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;pIdentifier&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Customer&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Identifier&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;pIdentifier&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier&nbsp;=&nbsp;pIdentifier&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier&nbsp;=&nbsp;<span class="visualBasic__keyword">Integer</span>.Parse(pReader(<span class="visualBasic__string">&quot;id&quot;</span>).ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Customer&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Id&nbsp;=&nbsp;Identifier,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.FirstName&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;FirstName&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;FirstName&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.LastName&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;Lastname&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;Lastname&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Address&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;Address&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;Address&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.City&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;City&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;City&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.State&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;State&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;State&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.ZipCode&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;Zipcode&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;pReader(<span class="visualBasic__string">&quot;Zipcode&quot;</span>).ToString()),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.JoinDate&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;JoinDate&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;<span class="visualBasic__keyword">CDate</span>(pReader(<span class="visualBasic__string">&quot;JoinDate&quot;</span>).ToString)),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Pin&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;Pin&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;<span class="visualBasic__keyword">CInt</span>(pReader(<span class="visualBasic__string">&quot;Pin&quot;</span>).ToString)),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.Balance&nbsp;=&nbsp;<span class="visualBasic__keyword">If</span>(<span class="visualBasic__keyword">TypeOf</span>&nbsp;pReader(<span class="visualBasic__string">&quot;Balance&quot;</span>)&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;DBNull,&nbsp;<span class="visualBasic__keyword">Nothing</span>,&nbsp;<span class="visualBasic__keyword">CDbl</span>(pReader(<span class="visualBasic__string">&quot;Balance&quot;</span>).ToString))&nbsp;
}&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Using extension methods</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Private Function CustomerBuilder1(
    ByVal pReader As SqlDataReader,
    Optional ByVal pIdentifier As Integer = 0) As Customer

    Dim Identifier As Integer = 0

    If pIdentifier &gt; 0 Then
        Identifier = pIdentifier
    Else
        Identifier = Integer.Parse(pReader(&quot;id&quot;).ToString())
    End If

    Return New Customer With
    {
        .Id = Identifier,
        .FirstName = pReader.GetStringSafe(&quot;FirstName&quot;),
        .LastName = pReader.GetStringSafe(&quot;LastName&quot;),
        .Address = pReader.GetStringSafe(&quot;Address&quot;),
        .City = pReader.GetStringSafe(&quot;City&quot;),
        .State = pReader.GetStringSafe(&quot;State&quot;),
        .ZipCode = pReader.GetStringSafe(&quot;ZipCode&quot;),
        .JoinDate = pReader.GetDateTimeSafe(&quot;JoinDate&quot;, Now),
        .Pin = pReader.GetInt32Safe(&quot;Pin&quot;, 999),
        .Balance = pReader.GetDoubleSafe(&quot;Balance&quot;, -1)
    }

End Function</pre>
<div class="preview">
<pre class="js">Private&nbsp;<span class="js__object">Function</span>&nbsp;CustomerBuilder1(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ByVal&nbsp;pReader&nbsp;As&nbsp;SqlDataReader,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Optional&nbsp;ByVal&nbsp;pIdentifier&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>)&nbsp;As&nbsp;Customer&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Identifier&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;pIdentifier&nbsp;&gt;&nbsp;<span class="js__num">0</span>&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier&nbsp;=&nbsp;pIdentifier&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Else&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Identifier&nbsp;=&nbsp;Integer.Parse(pReader(<span class="js__string">&quot;id&quot;</span>).ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;New&nbsp;Customer&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Id&nbsp;=&nbsp;Identifier,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FirstName&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;FirstName&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.LastName&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;LastName&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Address&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;Address&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.City&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;City&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.State&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;State&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ZipCode&nbsp;=&nbsp;pReader.GetStringSafe(<span class="js__string">&quot;ZipCode&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.JoinDate&nbsp;=&nbsp;pReader.GetDateTimeSafe(<span class="js__string">&quot;JoinDate&quot;</span>,&nbsp;Now),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Pin&nbsp;=&nbsp;pReader.GetInt32Safe(<span class="js__string">&quot;Pin&quot;</span>,&nbsp;<span class="js__num">999</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Balance&nbsp;=&nbsp;pReader.GetDoubleSafe(<span class="js__string">&quot;Balance&quot;</span>,&nbsp;-<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><img id="186495" src="186495-lb.jpg" alt="" width="24" height="24">&nbsp;Even though the second one is cleaner, the first is the better one if dealing with hundreds of thousands of records while anything below
 say 100,000 records either one is fine.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Another thing I wanted to show off is reading multiple tables with one reader. The best use of this is to read several references tables say when first creating the class. Here I want to read categories and products into list of
 concrete classes</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function GetReferenceTables() As SqlServerReferenceTables
    mHasException = False

    Dim selectStatement As String = &quot;SELECT ProductID,ProductName,CategoryID  FROM dbo.Products;&quot; &amp;
        &quot;SELECT CategoryID,CategoryName,Description  FROM dbo.Categories&quot;

    Dim refTables As New SqlServerReferenceTables

    Try
        Using cn = New SqlConnection(ConnectionString)
            Using cmd = New SqlCommand() With {.Connection = cn, .CommandText = selectStatement}
                cn.Open()

                Dim reader As SqlDataReader = cmd.ExecuteReader
                While reader.Read

                    refTables.Products.Add(New Product With
                        {
                            .ProductId = reader.GetInt32(0),
                            .ProductName = reader.GetString(1),
                            .CategoryID = reader.GetInt32(2)
                        })

                End While

                If reader.NextResult Then

                    While reader.Read

                        refTables.Catagories.Add(New Category With
                            {
                                .CategoryID = reader.GetInt32(0),
                                .CategoryName = reader.GetString(1),
                                .Description = reader.GetString(2)
                                })

                    End While
                End If
            End Using
        End Using
    Catch ex As Exception
        mHasException = True
        mLastException = ex
    End Try

    Return refTables

End Function</pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;GetReferenceTables()&nbsp;As&nbsp;SqlServerReferenceTables&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;False&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;selectStatement&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;ProductID,ProductName,CategoryID&nbsp;&nbsp;FROM&nbsp;dbo.Products;&quot;</span>&nbsp;&amp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;SELECT&nbsp;CategoryID,CategoryName,Description&nbsp;&nbsp;FROM&nbsp;dbo.Categories&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;refTables&nbsp;As&nbsp;New&nbsp;SqlServerReferenceTables&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Try&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cn&nbsp;=&nbsp;New&nbsp;SqlConnection(ConnectionString)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Using&nbsp;cmd&nbsp;=&nbsp;New&nbsp;SqlCommand()&nbsp;With&nbsp;<span class="js__brace">{</span>.Connection&nbsp;=&nbsp;cn,&nbsp;.CommandText&nbsp;=&nbsp;selectStatement<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cn.Open()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;reader&nbsp;As&nbsp;SqlDataReader&nbsp;=&nbsp;cmd.ExecuteReader&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;reader.Read&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;refTables.Products.Add(New&nbsp;Product&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ProductId&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">0</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ProductName&nbsp;=&nbsp;reader.GetString(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CategoryID&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;reader.NextResult&nbsp;Then&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;While&nbsp;reader.Read&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;refTables.Catagories.Add(New&nbsp;Category&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CategoryID&nbsp;=&nbsp;reader.GetInt32(<span class="js__num">0</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CategoryName&nbsp;=&nbsp;reader.GetString(<span class="js__num">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Description&nbsp;=&nbsp;reader.GetString(<span class="js__num">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;While&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Using&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Catch&nbsp;ex&nbsp;As&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mHasException&nbsp;=&nbsp;True&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mLastException&nbsp;=&nbsp;ex&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Try&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;refTables&nbsp;
&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The return type (if this was C# 7 we could use named Tuples)</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class SqlServerReferenceTables
    Public Property Catagories As List(Of Category)
    Public Property Products As List(Of Product)
    Public Sub New()
        Catagories = New List(Of Category)
        Products = New List(Of Product)
    End Sub
End Class
</pre>
<div class="preview">
<pre class="js">Public&nbsp;Class&nbsp;SqlServerReferenceTables&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Property&nbsp;Catagories&nbsp;As&nbsp;List(Of&nbsp;Category)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Property&nbsp;Products&nbsp;As&nbsp;List(Of&nbsp;Product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;New()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Catagories&nbsp;=&nbsp;New&nbsp;List(Of&nbsp;Category)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Products&nbsp;=&nbsp;New&nbsp;List(Of&nbsp;Product)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">So that are the basics. Note the unit test below is how to try the various things that I described above.&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="color:#ffffff">.</span></div>
</div>
<div class="endscriptcode"><img id="186496" src="186496-3.jpg" alt="" width="305" height="370">&nbsp;</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">The solution layout</div>
<div class="endscriptcode"><img id="186497" src="186497-4.jpg" alt="" width="241" height="450"></div>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">&nbsp;</div>
<br>
</span></div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
</span></p>
