# Execute Process Task
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
- SsisExecuteProcessTask
## Updated
- 04/20/2012
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use the Execute Process Task.</p>
<h1><br>
Description</h1>
<p>This sample transfers data from a database table into a file. An Execute Process Task is used toensure that the file is not Read-Only before the data is loaded into the file. The most commonlyused properties of the Execute Process Task are the &quot;Executable&quot;
 property and the &quot;Arguments&quot;&nbsp;property.</p>
<h1><br>
Before running the package</h1>
<h2>External dependencies</h2>
<p>This sample assumes that:</p>
<ul>
<li>You have already downloaded and attached to a local, default instance of SQL Server the&nbsp;AdventureWorks sample database from codeplex.com.
</li><li>The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and your&nbsp;user account has access to the AdventureWorks database.
</li><li>You have attached the database with the name, &quot;AdventureWorks&quot;. If the instance of the&nbsp;AdventureWorks sample database you want to use is attached to another instance and/or the name of&nbsp;the database as attached is not &quot;AdventureWorks&quot; edit the
 AdventureWorks connection manager. </li></ul>
<h2><br>
Configuration</h2>
<ul>
<li>Edit the &quot;Flat File Connection Manager&quot; to specify that path where the file &quot;Department.txt&quot; islocated.
</li><li>Note that, while the &quot;Department.txt&quot; file that is included in this sample is initially read-only, every time the package is run, &quot;Department.txt&quot; will be set read-write. So, if you have already runthe package once, you won't notice any change unless you
 manually change &quot;Department.txt&quot; back to&nbsp;read-only before running the package, again.
</li></ul>
<h1>Side effects</h1>
<p>This sample will insert data to the a file named &quot;Department.txt&quot; located at the path specified inthe &quot;Flat File Connection Manager&quot;. You may modify the path by changing the Flat File ConnectionManager.</p>
<h1>Further reading</h1>
<p>For more information on the Execute Process Task, see this topic:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms141166.aspx">http://msdn.microsoft.com/en-us/library/ms141166.aspx</a></p>
