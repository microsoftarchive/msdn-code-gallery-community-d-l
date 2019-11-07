# Database Query From MFC
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- SQL Server
- Visual Studio 2012
## Topics
- User Interface
- Data Access
- Database Synchronization
- Database
- Database Connectivity
## Updated
- 12/03/2013
## Description

<h1><span style="color:#000080; font-size:large">In the name of allah</span></h1>
<h1><span style="color:#000000; font-size:small">Title: Database Query From MFC (Database Viewver)</span><br>
<span style="color:#000000; font-size:small">Author: Mahdi Nejadsahbei</span><br>
<span style="color:#000000; font-size:small">Email: m.nejadsahebi@live.co.uk</span><br>
<span style="color:#000000; font-size:small">Language: Visual C&#43;&#43;</span><br>
<span style="color:#000000; font-size:small">Platform: Windows</span><br>
<span style="color:#000000; font-size:small">Technology: Database,etc.</span><br>
<span style="color:#000000; font-size:small">Level: Intermediate</span><br>
<span style="color:#000000; font-size:small">Description: This article Provideds for us to do query on a database file from MFC Application.</span><br>
<span style="color:#000000; font-size:small">Section Database</span><br>
<span style="color:#000000; font-size:small">SubSection Database</span><br>
<span style="color:#000000; font-size:small">License: CPL</span></h1>
<p>&nbsp;<a id="103925" href="/Database-Query-From-MFC-67682393/file/103925/1/Query%20Database%20From%20MFC-Demo.zip">Query Database From MFC-Demo-98KB.zip</a></p>
<p><a id="103926" href="/Database-Query-From-MFC-67682393/file/103926/1/Query%20Database%20From%20MFC-Source.zip">Query Database From MFC-Source.zip</a></p>
<p><span style="font-size:large"><img id="103922" src="103922-1.png" alt="" width="835" height="567">&nbsp;</span></p>
<p><span style="font-size:large"><strong><span style="color:#ff9900">Introduction</span></strong><br>
<span style="font-size:medium">Todays in many projects, we need a database for our application. Cause of it we have to link to the database file from our application.</span><br>
<span style="font-size:medium">With this article we describe how can we connect to Database from MFC and do query or get report from that.</span><br>
<br>
<strong><span style="color:#ff9900">Background</span></strong><br>
<span style="font-size:medium">To get the information of this subject you can read or search about Connect to databse from appplication.</span><br>
<br>
<strong><span style="color:#ff9900">Algorithm and Simulating of Algorithm in Code</span></strong></span></p>
<p><span style="font-size:large"><strong></strong><span style="font-size:medium">At first, we have to determine that what database is wanted. With the choice of combobox we decide what string connection to database is need.</span><br>
<span style="font-size:medium">If we choose the Access Databae our string connection is like below :</span></span></p>
<p><span style="font-size:large"></p>
<p><br>
<span style="color:#003366; font-size:medium">Driver={Microsoft Access Driver (*.mdb)};Server:.;Dbq=db.mdb;Uid=;Pwd=;</span><br>
<br>
<span style="font-size:medium">and if we choose the &lt;b&gt;Excel Database&lt;/b&gt; that's like :</span></p>
</span>
<p></p>
<p><span style="color:#003366; font-size:medium">Driver={Microsoft Excel Driver (*.xls)};DriverId=790;bq=C:\\DatabasePath\\DBSpreadSheet.xls;DefaultDir=c:\\databasepath;</span><br>
<br>
<span style="font-size:medium">and if choose the &lt;b&gt;SQL Database&lt;/b&gt; that's will be :</span></p>
<p><span style="color:#003366; font-size:medium">Driver={SQL Server Native Client 11.0};Server=.;AttachDbFilename=shop.mdf;Database=shop;Trusted_Connection=Yes;</span></p>
<p><span style="font-size:medium">After that we run a query on the database. We have to care that the querie's type is
<strong>Reporting Query</strong> or <strong>Execute Query</strong>.</span><br>
<span style="font-size:medium">The queries that get information from database, these are
<strong>Reporting Query</strong> like &quot;select * from table&quot;. And another queries that do a work or effect on the
</span><br>
<span style="font-size:medium">databse, these are <strong>Execute Query</strong> like &quot;update id form table1 where name='mahdi'&quot;.</span><br>
<span style="font-size:medium">To determine this algorithm we write a funtion to get the query string and determine that with below code :</span><br>
<br>
<span style="background-color:#ffffff; color:#003366; font-size:medium">bool IsReport(CString code){&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><br>
<span style="background-color:#ffffff; color:#003366; font-size:medium">code.TrimLeft();code.TrimRight();code.MakeLower();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
<span style="background-color:#ffffff; color:#003366; font-size:medium">if(code.Left(6)==_T(&quot;insert&quot;)||code.Left(6)==_T(&quot;update&quot;))return 0;</span><br>
<span style="background-color:#ffffff; color:#003366; font-size:medium">return 1;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
<span style="background-color:#ffffff; color:#003366; font-size:medium">}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><br>
<br>
<span style="font-size:medium">Now we decide that get report form database or send execute query with above funtion. If &quot;IsReport()&quot; funtion returns 0 it means that we have to send the query as a getting report and else we have to send the query as an execute
 query.</span><br>
<span style="font-size:medium">The statements like &quot;insert&quot; , &quot;update&quot; ,.... effect on the database, so these are execute queries and we send these queries in
<strong>CDatabse </strong>and another statements are getting report and we send these with
<strong>CRecordset</strong> Classes.</span><br>
<span style="font-size:medium">The <strong>CDatabase</strong> class can do execute and
<strong>CReordset</strong> can fields of queries. With this code you can get betther :</span><br>
<br>
<span style="color:#003366; font-size:medium">CString query;</span><br>
<span style="color:#003366; font-size:medium">tquery.GetWindowText(query);</span><br>
<span style="color:#003366; font-size:medium">list.ResetContent();</span><br>
<span style="color:#003366; font-size:medium">if(IsReport(query)){//this is a report command</span><br>
<span style="color:#003366; font-size:medium">CRecordset recordset(&amp;database);</span><br>
<span style="color:#003366; font-size:medium">CString temp,record;</span><br>
<span style="color:#003366; font-size:medium">recordset.Open(CRecordset::forwardOnly,query,CRecordset::readOnly);</span><br>
<span style="color:#003366; font-size:medium">while(!recordset.IsEOF()){//is null</span><br>
<span style="color:#003366; font-size:medium">record=_T(&quot;&quot;);</span><br>
<span style="color:#003366; font-size:medium">register int len=recordset.GetODBCFieldCount();</span><br>
<span style="color:#003366; font-size:medium">for(register int i=0; i &lt; len ; i&#43;&#43;){</span><br>
<span style="color:#003366; font-size:medium">recordset.GetFieldValue(i,temp);</span><br>
<span style="color:#003366; font-size:medium">record&#43;=temp&#43;_T(&quot; | &quot;);</span><br>
<span style="color:#003366; font-size:medium">}</span><br>
<span style="color:#003366; font-size:medium">list.AddString(record);</span><br>
<span style="color:#003366; font-size:medium">recordset.MoveNext();</span><br>
<span style="color:#003366; font-size:medium">}</span><br>
<span style="color:#003366; font-size:medium">}else{</span><br>
<span style="color:#003366; font-size:medium">database.ExecuteSQL(query);</span><br>
<span style="color:#003366; font-size:medium">}</span><br>
<span style="color:#003366; font-size:medium">MessageBox(_T(&quot;Query done.&quot;),0,0);</span></p>
<p><span style="font-size:large">&nbsp;<img id="103923" src="103923-2.png" alt="" width="831" height="567"></span></p>
<p><span style="font-size:large"><span style="font-size:medium">&nbsp;I Hope it will be usefull for you. thanks in advance.</span><br>
</span></p>
