# Execute SQL Task and Foreach Loop
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
- SsisScriptTask
- SsisExecuteSqlTask
- SsisForeachLoopContainer
## Updated
- 12/10/2013
## Description

<h1>Introduction</h1>
<p>This sample demonstrates two common scenarios in SSIS:</p>
<ol>
<li>Using an Execute SQL Task to populate an Object variables with a ADO.net recordset
</li><li>Looping over that recordset using a Foreach Loop and carrying out operations on the enumerated values
</li></ol>
<h1><span>Building the Sample</span></h1>
<p><span>Executing the package contained within the attached zip file will cause the sample to be built behind the scenes so there are no extra steps required for you, the developer, in order to view the results of this sample.</span></p>
<h1><span>Pre-Requisites</span></h1>
<p>The package needs to connect to an instance of the <a href="http://msdn.microsoft.com/en-us/library/ms124501.aspx">
[AdventureWorks2008R2] sample database</a>. By default it expects that database to reside on localhost so if it resides elsewhere you will simply have to edit the Connection Manager appropriately prior to execution of the package.</p>
<p>The package is a SSIS 2012 package so you will need SSIS2012 (or later) installed.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample is intended to demonstrate how one might populate an Object variable with a recordset and then loop over that recordset using a Foreach Loop.</p>
<p><img src="http://i1.code.msdn.s-msft.com/execute-sql-task-and-4aaea562/image/file/55006/1/executesqlforeach_controlflow.jpg" alt="" width="674" height="348"></p>
<p>Within the Foreach Loop it then outputs the enumerated data in a Script Task and then extracts some data from the database using the enumerated&nbsp;CustomerID. However, the real purpose of this sample is to demonstrate how an Execute SQL Task and a Foreach
 Loop can work in concert with each other.</p>
<p>Although the primary scenarrio for this sample if populating an object variable and then looping over it there are a number of other concepts explored here:</p>
<ul>
<li>Dynamic SQL statements using SSIS expressions </li><li>Raising information events using a Script Task </li><li>Displaying Message Box using a Script Task </li></ul>
<p>&nbsp;</p>
<p><span>Jamie Thomson</span><br>
<a href="http://sqlblog.com/blogs/jamie_thomson">http://sqlblog.com/blogs/jamie_thomson</a><br>
<a href="http://twitter.com/jamiet">@jamiet</a></p>
