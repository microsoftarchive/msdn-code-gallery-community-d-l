# Database Creation Sample
## Requires
- Visual Studio 2008
## License
- MS-LPL
## Technologies
- ADO.NET
## Topics
- Create Database
## Updated
- 11/30/2011
## Description

<h1>Database Creation Sample</h1>
<div id="mainSection">
<div id="mainBody">
<div class="saveHistory" id="allHistory">
<p>&nbsp;</p>
</div>
<div class="introduction">
<p>SQL statements are executed that create a database, a table, a stored procedure, and a view in code. SQL statements are then executed that populate the table with data from the Northwind database. This table is then queried to fill a that is subsequently
 bound to a for display.</p>
<p>To get samples and instructions for installing them, see the following:</p>
<ul>
<li>
<p>Click <span class="ui">Samples</span> on the Visual Studio <span class="ui">
Help</span> menu.</p>
<p>For more information, see .</p>
</li><li>
<p>The most recent versions and the complete list of samples are available on the Visual Studio 2008 Samples Web site.</p>
</li><li>
<p>You can also locate samples on your computer's hard disk. By default, samples and a Readme file are copied to a folder under \Program Files\Visual Studio 9\Samples\. For Visual Studio Express Editions, all samples are located on the Internet.</p>
<div class="alert">
<table width="100%">
</table>
<p>&nbsp;</p>
</div>
</li></ul>
</div>
<h3 class="procedureSubHeading">To run this sample</h3>
<div class="subSection">
<ol>
<li>
<p>Press F5.</p>
</li><li>
<p>If you want to run the application again after you create the database, you will have to close all applications that maintain an active connection to the instance of SQL Server that contains the demo database. This means you will have to close and reopen
 Visual Studio if you opened a connection to the database in the Server Explorer. Other applications, such as SQL Query Analyzer, may also hold an open connection. Alternatively, you can stop and restart the instance of SQL Server by using the SQL Server Service
 Manager in the system tray.</p>
</li></ol>
</div>
<h1 class="heading"><span>Requirements</span></h1>
<div class="section" id="requirementsTitleSection">
<p>This sample requires the Northwind database. For more information, see .</p>
</div>
<h1 class="heading"><span>Demonstrates</span></h1>
<div class="section" id="demonstratesSection">
<p>The application leads you through the steps in creating and populating the database:</p>
<ul>
<li>
<p><span class="label">Create the database</span>&nbsp;&nbsp;&nbsp;The class uses the CREATE DATABASE statement to create the<span class="code"> How to Demo
</span>database.</p>
</li><li>
<p><span class="label">Create the data table</span>&nbsp;&nbsp;&nbsp;The class uses the CREATE TABLE statement to create a table named
<span class="code">NW_Seafood</span>. The table includes fields for product ID, product name, quantity per unit, and unit price.</p>
</li><li>
<p><span class="label">Create a stored procedure</span>&nbsp;&nbsp;&nbsp;The class uses the INSERT INTO statement and the SELECT statement to add code to the new table and retrieve the data from the table.</p>
</li><li>
<p><span class="label">Create a view</span>&nbsp;&nbsp;&nbsp;The class uses the CREATE VIEW statement to select rows in the<span class="code"> NW_Seafood
</span>table.</p>
</li><li>
<p><span class="label">Populate the table</span>&nbsp;&nbsp;&nbsp;The class uses the EXECUTE statement to run a procedure that retrieves rows from the Northwind database and add them to the<span class="code"> NW_Seafood
</span>table.</p>
</li><li>
<p><span class="label">Display the data in the table</span>&nbsp;&nbsp;&nbsp;The class uses the SELECT statement to fill a that is then used as the of a control. Table and column style objects are used to customize the appearance of the .</p>
</li></ul>
</div>
</div>
<div id="footer">
<div class="footerLine"></div>
<a name="feedback"></a><span id="fb" class="feedbackcss">&nbsp;</span></div>
</div>
