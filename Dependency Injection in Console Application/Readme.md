# Dependency Injection in Console Application
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- C#
- ADO.NET Entity Framework
- Entity Framework
- Console
- Visual C#
- Ninject
## Topics
- C#
- ADO.NET Entity Framework
- Entity Framework
- Console Applications
- Inversion of Control
- Dependency Inversion Principle
- Dependancy Injection Pattern
## Updated
- 07/23/2016
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">A Visual Studio 2015 project which shows how to use the Dependency Injection with Inversion of Control (Ninject) in the console application project, using generic repository pattern.</span></p>
<p><span style="font-size:small">The code illustrates the following topics:</span></p>
<ul>
<li><span style="font-size:small">The Ninject IoC is used to implement dependency injection.</span>
</li><li><span style="font-size:small">Creating a generic repository for insert collection of entity in database.</span>
</li><li><span style="font-size:small">Read data from json file and deserialize &nbsp;json data to entity/entities.</span>
</li><li><span style="font-size:small">Database first approach is used to perform insert operation.</span>
</li><li><span style="font-size:small">With Dispose pattern.</span> </li></ul>
<h1>Getting Started</h1>
<p><span style="font-size:small">To build and run this sample as-is, you must have Visual Studio 2015 installed. In most cases you can run the application by following these steps:</span></p>
<ol>
<li><span style="font-size:small">Download and extract the .zip file.</span> </li><li><span style="font-size:small">Create table in database as mentioned script in the DbScript.sql file.</span>
</li><li><span style="font-size:small">Open the solution file in Visual Studio.</span>
</li><li><span style="font-size:small">Change connection string in the App.config file.</span>
</li><li><span style="font-size:small">Build the solution, which automatically installs the missing NuGet packages.</span>
</li><li><span style="font-size:small">Run the application.</span> </li></ol>
<h1>Source Code Overview</h1>
<p><img id="157070" src="157070-4.png" alt="" width="571" height="179"></p>
<p><span style="font-size:small">Figure 1: Operation work flow</span></p>
<p><span style="font-size:small">This solution have contains 4 projects which are used in following ways.</span></p>
<p><span style="font-size:small">1. DIConsole: A console application which runs and have json file. It has integration of IoC(Ninject).</span></p>
<p><span style="font-size:small">2. DI.Data: It&rsquo;s a class library which has edmx file whereas database table mapped.</span></p>
<p><span style="font-size:small">3. DI.Repo: It&rsquo;s class library which perform insert operation for entity.</span></p>
<p><span style="font-size:small">4. DI.Service: It&rsquo;s class library which communicate to console application by interface.</span></p>
<p><span style="font-size:small">You can download source code for web application from below link as well.</span></p>
<p><span style="font-size:small"><a href="https://gallery.technet.microsoft.com/CRUD-Operations-Using-0aa46470">https://gallery.technet.microsoft.com/CRUD-Operations-Using-0aa46470</a></span></p>
