# Derived Column
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server Integration Services
- SQL Server Integration Services 2012
## Topics
- SsisDerivedColumnTransform
## Updated
- 04/20/2012
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use the derived column component. In this example we select the&nbsp;names of everyone from the People.People table and then perform the following actions through&nbsp;derived column transforms:</p>
<ol>
<li>Cleanse the 'MiddleName' field by replacing NULL values with an empty string in preparation for&nbsp;the next step.
</li><li>Create a new column named 'FullName' which concatenates the FirstName, MiddleName, and LastName&nbsp;fields.
</li></ol>
<p>Each step can be viewed by placing Data Viewers on the paths between components.</p>
<h1>Before running the package</h1>
<p>&nbsp;</p>
<h2>External dependencies</h2>
<p>This sample assumes that:</p>
<ul>
<li>You have already downloaded and attached to a local, default instance of SQL Server the&nbsp;AdventureWorks sample database from codeplex.com.
</li><li>The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and&nbsp;your user account has access to the AdventureWorks database.
</li><li>You have attached the database with the name, &quot;AdventureWorks&quot;. If the instance of the&nbsp;AdventureWorks sample database you want to use is attached to another instance and/or the name&nbsp;of the database as attached is not &quot;AdventureWorks&quot; edit the
 AdventureWorks connection manager. </li></ul>
<h1>Further reading</h1>
<p>For more information on the Derived Column Transform, see the following topic:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms141069.aspx">http://msdn.microsoft.com/en-us/library/ms141069.aspx</a></p>
