# Intro to ASP.NET MVC 4
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
- ASP.NET MVC 4
## Topics
- Data Access
- HTML5
- HTTP
## Updated
- 02/21/2012
## Description

<h1>What You'll Build</h1>
<p>The full tutorial is <a href="http://www.asp.net/mvc/tutorials/mvc-4/getting-started-with-aspnet-mvc4/intro-to-aspnet-mvc-4">
here</a>.</p>
<p>You'll implement a simple movie-listing application that supports creating, editing, and listing movies from a database. Below are two screenshots of the application you&rsquo;ll build. It includes a page that displays a list of movies from a database:</p>
<p><img src="49852-windowslivewriter_introtoasp.netmvc3_e539_movieswithvarioussm_thumb%5b1%5d.png" alt="" width="651" height="412"></p>
<p><img src="http://i1.asp.net/umbraco-beta-media/2578258/WindowsLiveWriter_IntrotoASP.NETMVC3_E539_createError_thumb_1.png" alt=""></p>
<h2>Skills You'll Learn</h2>
<p>Here's what you'll learn:</p>
<ul>
<li>How to create a new ASP.NET MVC project. </li><li>How to create ASP.NET MVC controllers and views. </li><li>How to create a new database using the Entity Framework Code First paradigm. </li><li>How to retrieve and display data. </li><li>How to edit data and enable data validation. </li></ul>
<h2>Getting Started</h2>
<p>Start by running Visual Web Developer 2010 Express (&quot;Visual Web Developer&quot; for short) and select
<strong>New Project</strong> from the <strong>Start</strong> page.</p>
<p>Visual Web Developer is an IDE, or integrated development environment. Just like you use Microsoft Word to write documents, you'll use an IDE to create applications. In Visual Web Developer there's a toolbar along the top showing various options available
 to you. There's also a menu that provides another way to perform tasks in the IDE. (For example, instead of selecting
<strong>New Project</strong> from the <strong>Start</strong> page, you can use the menu and select
<strong>File</strong> &gt; <strong>New Project</strong>.)</p>
<p><a href="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/VWD.PNG"><img src="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/VWDsm.PNG" alt=""></a></p>
<h2>Creating Your First Application</h2>
<p>You can create applications using either Visual Basic or Visual C# as the programming language. Select Visual C# on the left and then select
<strong>ASP.NET MVC 3 Web Application</strong>. Name your project &quot;MvcMovie&quot; and then click
<strong>OK</strong>. (If you prefer Visual Basic, switch to the <a href="http://www.asp.net/mvc/tutorials/getting-started-with-mvc3-part1-vb" target="_blank">
Visual Basic version</a> of this tutorial.)</p>
<p><img src="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/NewProjectSm.PNG" alt=""></p>
<p>In the <strong>New ASP.NET MVC 3 Project</strong> dialog box, select <strong>Internet Application</strong>. Check
<strong>Use HTML5 markup</strong> and leave <strong>Razor</strong> as the default view engine.</p>
<p><img src="http://i1.asp.net/umbraco-beta-media/2578264/WindowsLiveWriter_IntrotoASP.NETMVC3_E539_NewMVC3project_10.png" alt="" width="530" height="480"></p>
<p>Click <strong>OK</strong>. Visual Web Developer used a default template for the ASP.NET MVC project you just created, so you have a working application right now without doing anything! This is a simple &quot;Hello World!&quot; project, and it's a good place to start
 your application.</p>
<p><a href="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/VisualStudioMvcMovie.png"><img class="auto" src="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/VisualStudioMvcMovieSm.PNG" alt=""></a></p>
<p>From the <strong>Debug</strong> menu, select <strong>Start Debugging</strong>.</p>
<p><img src="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/StartWithoutDebug.png" alt=""></p>
<p>Notice that the keyboard shortcut to start debugging is F5.</p>
<p>F5 causes Visual Web Developer to start a development web server and run your web application. Visual Web Developer then launches a browser and opens the application's home page. Notice that the address bar of the browser says
<code>localhost</code> and not something like <code>example.com</code>. That's because
<code>localhost</code> always points to your own local computer, which in this case is running the application you just built. When Visual Web Developer runs a web project, a random port is used for the web server. In the image below, the random port number
 is 43246. When you run the application, you'll probably see a different port number.</p>
<p><img src="http://i3.asp.net/common/www-css/i//MVC3/MVC3_gettingStarted_CS/img/YourProjectWillHave.PNG" alt=""></p>
