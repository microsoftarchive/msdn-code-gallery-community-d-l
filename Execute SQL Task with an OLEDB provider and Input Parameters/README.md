# Execute SQL Task with an OLEDB provider and Input Parameters
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SSIS
- SQL Server Integration Services
- SSIS 2012
- SQL Server Integration Services 2012
## Topics
- SsisExecuteSqlTask
## Updated
- 04/20/2012
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use the Execute SQL Task with OLE DB Input Parameters</p>
<h1>Description</h1>
<p>This project is broken into two packages:</p>
<ul>
<li>CreateTablePackage.dtsx: Generates a load table with the Execute SQL Task (this is done for convenience to not affect any of your&nbsp;existing AdventureWorks data.)
</li><li>ProcessPackage.dtsx: &nbsp;Deletes all data in the load table older than the date specified in the project parameter &quot;DeleteDate&quot;with an Execute SQL Task and then loads a subset of the data from the&nbsp;AdventureWorks Person.Person table.
</li></ul>
<h1>Before running the packages</h1>
<h2>External dependencies</h2>
<p>This sample assumes that:</p>
<ul>
<li>You have already downloaded and attached to a local, default instance of SQL Server the&nbsp;AdventureWorks sample database from codeplex.com.
</li><li>The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and your&nbsp;user account has access to the AdventureWorks database.
</li><li>You have attached the database with the name, &quot;AdventureWorks&quot;. If the instance of the&nbsp;AdventureWorks sample database you want to use is attached to another instance and/or the name of&nbsp;the database as attached is not &quot;AdventureWorks&quot; edit the
 AdventureWorks connection manager. </li></ul>
<h2>Configuration</h2>
<p>You can change which records are cleared from the table by modifying the value in the &quot;DeleteDate&quot; project parameter, if you so choose.</p>
<h2>To run the sample</h2>
<ol>
<li>Execute the &quot;CreateTablePackage&quot; package. This will create the table that the next step will load data into. If you skip this step, the package executed in the next step will fail.
</li><li>Execute the &quot;ProcessPackage&quot; package. </li></ol>
<p>&nbsp;</p>
<h1>Further reading</h1>
<p>For more information on the Execute SQL Task, see the following topic:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms141003.aspx">http://msdn.microsoft.com/en-us/library/ms141003.aspx</a></p>
