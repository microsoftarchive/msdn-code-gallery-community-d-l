# Intro to ASP.NET MVC 4
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Web Services
## Topics
- Web Services
## Updated
- 05/12/2014
## Description

<h1>Introduction</h1>
<p><em>We highly recommend you follow the MVC 5 tutorial&nbsp;available <a href="http://www.asp.net/mvc/tutorials/mvc-5/introduction/getting-started">
here</a></em></p>
<p><em>If you can't update to MVC 5, follow the MVC 4 tutorial <a href="http://www.asp.net/mvc/tutorials/mvc-4/getting-started-with-aspnet-mvc4/intro-to-aspnet-mvc-4">
here</a>.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The following text is just pasted here to meet the minimum text requirements. Please follow the links above where the tutorial is maintained and rich comments are found.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>F5 causes Visual Studio to start IIS Express and run your web application. Visual Studio then launches a browser and opens the application's home page. Notice that the address bar of the browser says
<code>localhost</code> and not something like <code>example.com</code>. That's because
<code>localhost</code> always points to your own local computer, which in this case is running the application you just built. When Visual Studio runs a web project, a random port is used for the web server. In the image below, the port number is 41788. When
 you run the application, you'll probably see a different port number.</p>
<p>MVC stands for&nbsp;<em>model-view-controller</em>. MVC is a pattern for developing applications that are well architected, testable and easy to maintain. MVC-based applications contain:</p>
<ul class="auto-style1">
<li><strong>M</strong>odels: Classes that represent the data of the application and that use validation logic to enforce business rules for that data.
</li><li><strong>V</strong>iews: Template files that your application uses to dynamically generate HTML responses.
</li><li><strong>C</strong>ontrollers: Classes that handle incoming browser requests, retrieve model data, and then specify view templates that return a response to the browser.
</li></ul>
<p>We'll be covering all these concepts in this tutorial series and show you how to use them to build an application.</p>
<p>Let's begin by creating a controller class. In&nbsp;<strong>Solution Explorer</strong>, right-click the&nbsp;<em>Controllers</em>&nbsp;folder and then select&nbsp;<strong>Add Controller</strong>.</p>
