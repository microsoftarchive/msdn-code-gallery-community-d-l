# Getting Started with Entity Framework 5 using MVC 4
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC 4
- Visual Studio 2012
- .NET 4.5
- Entity Framework 5
- Azure SDK 2.1
## Topics
- Repository Pattern
- Paging
- Concurrency
- Unit of Work Pattern
- Sorting
- ADO.NET Entity Framework Code First
- CRUD
- Filtering
- Complex Data Model
- Inheritance in Data Model
- Advanced Entity Framework Scenarios
## Updated
- 06/12/2014
## Description

<p>This Contoso University application is used by the tutorial series at <a href="http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application">
http://www.asp.net/mvc/tutorials/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application</a>.</p>
<p>The download package includes the application code at the completion of the tutorial series (CU10). It also includes application state at the end of each chapter (CU#), in case you only want to follow a specific chapter in the series.</p>
<h2>Building the Chapter Downloads</h2>
<ol>
<li>Right click on the zip file, click <strong>Properties</strong>, and click the
<strong>Unblock</strong> button.<br>
<br>
<img src="http://i1.asp.net/media/4356708/unblock.PNG?cdn_id=2014-05-21-001" alt="" width="377" height="516"><br>
<br>
</li><li>Unzip the file. </li><li>Double-click the <em>CUx.sln</em> file to launch Visual Studio. </li><li>From the <strong>Tools</strong> menu, click <strong>Library Package Manager</strong>, then
<strong>Package Manager Console</strong>.<br>
<br>
<img src="http://i2.asp.net/media/4356702/PMC.png?cdn_id=2014-05-21-001" alt="" width="652" height="309"><br>
<br>
</li><li>In the Package Manager Console (PMC), click <strong>Restore</strong>.<br>
<br>
<img src="http://i3.asp.net/media/4356696/PMC2.PNG?cdn_id=2014-05-21-001" alt="" width="591" height="226"><br>
<br>
</li><li>Exit Visual Studio. </li><li>Restart Visual Studio, opening the solution file you closed in the step above.
</li><li>In the Package Manager Console (PMC), enter the <code>Update-Database</code> command:<br>
<br>
<img src="http://i3.asp.net/media/4356690/upDb.PNG?cdn_id=2014-05-21-001" alt="" width="589" height="225"><br>
<br>
<div class="note">
<p>Note: If you get the following error:<br>
<br>
&nbsp;&nbsp;&nbsp; <em>The term 'Update-Database' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again.<br>
</em><br>
Exit and restart Visual Studio.</p>
</div>
<p>Each migration will run, then the seed method will run. You can now run the app.</p>
<img src="http://i3.asp.net/media/4356684/pmc3.PNG?cdn_id=2014-05-21-001" alt="" width="589" height="300">
</li></ol>
