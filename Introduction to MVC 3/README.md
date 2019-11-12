# Introduction to MVC 3
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ADO.NET Entity Framework
- ASP.NET MVC 3
## Topics
- ASP.NET and ADO.NET Entity Framework
- ASP.NET MVC
- ASP.NET MVC Basics
## Updated
- 05/25/2012
## Description

<p><span class="Apple-style-span">&nbsp;</span></p>
<p>This tutorial will teach you the basics of building an ASP.NET MVC Web application using Microsoft Visual Web Developer 2010 Express Service Pack 1, which is a free version of Microsoft Visual Studio. Before you start, make sure you've installed the prerequisites
 listed below. You can install all of them by clicking the following link:<span class="Apple-converted-space">&nbsp;</span><a href="http://www.microsoft.com/web/gallery/install.aspx?appid=VWD2010SP1Pack">Web Platform Installer</a>. Alternatively, you can
 individually install the prerequisites using the following links:</p>
<ul>
<li><a href="http://www.microsoft.com/web/gallery/install.aspx?appid=VWD2010SP1Pack">Visual Studio Web Developer Express SP1 prerequisites</a>
</li><li><a href="http://www.microsoft.com/web/gallery/install.aspx?appsxml=&appid=MVC3">ASP.NET MVC&nbsp;3 Tools Update</a>
</li><li><a href="http://www.microsoft.com/web/gallery/install.aspx?appid=SQLCE;SQLCEVSTools_4_0">SQL Server Compact 4.0<span class="Apple-converted-space">&nbsp;</span></a>(runtime &#43; tools support)
</li></ul>
<p>&nbsp;</p>
<h3>What You'll Build</h3>
<p class="auto-style1">You'll implement a simple movie-listing application that supports creating, editing and listing movies from a database. Below are two screenshots of the application you&rsquo;ll build. It includes a page that displays a list of movies
 from a database:</p>
<p class="auto-style1"><img src="49573-windowslivewriter_introtoasp.netmvc3_e539_movieswithvarioussm_thumb%5b1%5d.png" alt="" width="651" height="412"></p>
<p>&nbsp;</p>
<p>The application also lets you add, edit, and delete movies as well as see details about individual ones. All data-entry scenarios include validation to ensure that the data stored in the database is correct.</p>
<p><img src="49574-windowslivewriter_introtoasp.netmvc3_e539_createerror_thumb_1%5b1%5d.png" alt="" width="623" height="715"></p>
<p>&nbsp;</p>
<h3>Skills You'll Learn</h3>
<p>Here's what you'll learn:</p>
<ul>
<li><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;<a href="http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part1-cs" target="_blank">How to create a new
 ASP.NET MVC project</a>&nbsp; </li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/adding-a-controller" target="_blank"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How
 to add a controller </a></li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/adding-a-view"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How to add a view
</a></li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/adding-a-model"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How to&nbsp;access
 your Model's Data from a controller </a></li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/accessing-your-model's-data-from-a-controller"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How
 to add a create method and create view </a></li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/adding-a-new-field"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How to add a
 new field to a data model and view </a></li><li><a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/adding-validation-to-the-model"><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;How
 to enable data validation </a></li><li><img src="19356-aspnet.png" alt="" width="16" height="16">&nbsp;<a href="http://www.asp.net/mvc/tutorials/getting-started-with-aspnet-mvc3/cs/improving-the-details-and-delete-methods">How
 to&nbsp;implement edit, details, and delete views</a> </li></ul>
<p>&nbsp;</p>
<h3>Getting Started</h3>
<p>Start by completing the&nbsp;<a href="http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part1-cs" target="_blank">How to create a new ASP.NET MVC project</a>&nbsp;tutorial.</p>
