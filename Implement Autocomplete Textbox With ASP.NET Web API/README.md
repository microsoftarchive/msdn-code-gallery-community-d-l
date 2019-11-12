# Implement Autocomplete Textbox With ASP.NET Web API
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- ASP.NET MVC 4
- jQuery UI
- ASP.NET Web API
## Topics
- ADO.NET Entity Framework
- ASP.NET Web API
- ASP.NET Web API browser clients
## Updated
- 07/22/2012
## Description

<p>Learn how to implement <a href="http://techbrij.com/category/javascript-jquery">
jQuery</a> UI Autocomplete feature with <a href="http://techbrij.com/category/asp-net-mvc">
ASP.NET</a> Web API and Entity Framework DB First approach. For more information or submitting queries, check following post:</p>
<h1><a title="Permanent Link to Using jQuery UI Autocomplete With ASP.NET Web API" rel="bookmark" href="http://techbrij.com/987/jquery-ui-autocomplete-asp-net-web-api">Using jQuery UI Autocomplete With ASP.NET Web API</a></h1>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1>Getting Started</h1>
<p>To build and run this sample, you must have Visual Studio 2010 or higher and ASP.NET MVC 4.0 installed. Unzip the zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the solution.</p>
<h1>Database:</h1>
<p>The database(MVCMusicStore.mdf) is in App_Data folder having one table 'Artist'. It has 13 rows only for testing.</p>
<h1>Code:</h1>
<p>In the code, Entity Framework is used and WebAPI action returns all artist names and IDs.</p>
<p>This action is called by jQuery method and transformed into required format for jquery autocomplete feature.</p>
<h1>Running the Sample:</h1>
<p>To run the sample, hit F5 or choose the Debug | Start Debugging menu command. You will see search box. You have to type some characters like god then you will get matched name in the list.</p>
<h1>Source Code Overview:</h1>
<ul>
<li><em>App_Data</em> folder - Holds the SQL Server Express database file. </li><li><em>Models </em>folder -&nbsp; Holds the .edmx file. </li><li><em>Properties</em> or <em>MyProject</em> folder - Unchanged from what the project template creates.
</li><li><em>Scripts</em> folder - Unchanged from what the project template creates. </li><li><em>Content </em>folder - Holds the CSS file, which contains minor changes from what the project template creates.
</li><li>Controllers - ValuesController.cs - for apiController </li><li>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; - HomeController.cs - for default view controller
</li><li>Views - It has layout and view files. Index.cshtml is default view having search box and jquery code to consume web api.
</li><li><em>Global.asax</em> file - Unchanged from what the project template creates.
</li><li><em>Site.master</em> - Master page file. Specifies the layout of all site pages.
</li><li>Web.config file - Contains the connection string to the database. </li></ul>
