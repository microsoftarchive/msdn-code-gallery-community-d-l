# Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013 - Wingtip Toys
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web Forms
- ASP.NET 4.5
- Visual Studio Express 2013 for Web
## Topics
- ASP.NET 4.5 Web Forms
## Updated
- 04/20/2016
## Description

<h1>Introduction</h1>
<p>This download has been created for the <a title="Getting Started with ASP.NET 4.5 Web Forms" href="http://www.asp.net/web-forms/tutorials/aspnet-45/getting-started-with-aspnet-45-web-forms/introduction-and-overview">
Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013</a> (Wingtip Toys) tutorial series available on the ASP.NET web site. This series of tutorials guides you through the steps required to create an ASP.NET Web Forms application using Visual Studio
 Express 2013 for Web and ASP.NET 4.5.</p>
<p><strong>NOTE:</strong><br>
The Wingtip Toys sample application was designed to show specific ASP.NET concepts and features available to ASP.NET web developers. This sample application was not optimized for all possible circumstances in regard to scalability and security. When working
 with PayPal, consider using the PayPal NuGet package. Additionally, when working with PayPal strings, consider using the SecureString function.</p>
<p><strong>Related&nbsp;resources:</strong></p>
<ul>
<li><a href="http://download.microsoft.com/download/0/F/B/0FBFAA46-2BFD-478F-8E56-7BF3C672DF9D/Getting%20Started%20with%20ASP.NET%204.5%20Web%20Forms%20and%20Visual%20Studio%202013.pdf?cdn_id=2014-01-07-001" target="_blank">E-book (PDF)</a>&nbsp;- Contains
 the complete tutorial series. </li><li><a href="http://quizapp.cloudapp.net/?quiz=ASP.NET&cdn_id=2014-01-07-001" target="_blank">ASP.NET Web Forms Quiz</a>&nbsp;- Review the content by taking the related ASP.NET Web Forms quiz.
</li></ul>
<p>The application you'll create is named <strong>WingtipToys</strong>. It's a simplified example of a store front web site that sells items online. This tutorial series highlights&nbsp;new features available in ASP.NET 4.5 and Visual Studio 2013.</p>
<p>Visit the tutorial series:<br>
<a title="Getting Started with ASP.NET 4.5 Web Forms" href="http://www.asp.net/web-forms/tutorials/aspnet-45/getting-started-with-aspnet-45-web-forms/introduction-and-overview">Getting Started with ASP.NET 4.5 Web Forms and Visual Studio 2013</a></p>
<p>Comments are welcome, and we'll make every effort to update this tutorial series based on your suggestions.</p>
<h1><span>Audience</span></h1>
<p>The intended audience of this tutorial series is experienced developers who are new to ASP.NET Web Forms. A developer interested in this tutorial series should have the following skills:</p>
<ul>
<li>Familiar with an object oriented programming (OOP) language </li><li>Familiar with Web development concepts (HTML, CSS, JavaScript) </li><li>Familiar with relational database concepts </li><li>Familiar with n-tier architecture concepts </li></ul>
<p><span style="font-size:20px; font-weight:bold">Application Features</span></p>
<p>The ASP.NET Web Form features presented in this series include:</p>
<ul>
<li>The Web Application Project (not Web Site Project) </li><li>Web Forms </li><li>Master Pages, Configuration </li><li>Bootstrap </li><li>Entity Framework Code First, LocalDB </li><li>Request Validation </li><li>Strongly Typed Data Controls, Model Binding, Data Annotations, and Value Providers
</li><li>SSL and OAuth </li><li>ASP.NET Identity, Configuration, and Authorization </li><li>Unobtrusive Validation </li><li>Routing </li><li>ASP.NET Error Handling&nbsp; </li></ul>
<h1>Application Scenarios and Tasks</h1>
<p>Tasks demonstrated in this first series include:</p>
<ul>
<li>Creating, reviewing and running the new project </li><li>Creating the database structure </li><li>Initializing and seeding the database </li><li>Customizing the UI using styles, graphics and a master page </li><li>Adding pages and navigation </li><li>Displaying menu details and product data </li><li>Creating a shopping cart </li><li>Adding&nbsp;SSL and OAuth&nbsp;support </li><li>Adding a payment method </li><li>Including an administrator role and a user to the application </li><li>Restricting access to specific pages and folder </li><li>Uploading a file to the web application </li><li>Implementing input validation </li><li>Registering routes for the web application </li><li>Implementing error handling and error logging </li></ul>
<h1>Overview</h1>
<p>If you are new to ASP.NET Web Forms but have familiarity with programming concepts, you have the right tutorial. If you are already familiar with ASP.NET Web Forms, you can benefit from this tutorial series by the new features available in ASP.NET 4.5 and
 Visual Studio 2013. If you are unfamiliar with programming concepts and ASP.NET Web Forms, see
<a href="http://www.asp.net/web-forms">Getting Started</a> on the ASP.NET Web site for&nbsp;additional tutorial information.</p>
<p>In addition to the features mention above, this code sample specifically includes&nbsp;the following ASP.NET 4.5 and Visual Studio 2013 features:</p>
<ul>
<li>A&nbsp;simple UI for creating projects that offer <a href="http://www.asp.net/visual-studio/overview/2013/creating-web-projects-in-visual-studio#add">
support for multiple ASP.NET frameworks</a> (Web Forms, MVC, and Web API). </li><li><a href="http://www.asp.net/visual-studio/overview/2013/creating-web-projects-in-visual-studio#bootstrap">Bootstrap</a>, a layout and theming framework that provides responsive design and theming capabilities.
</li><li><a href="http://www.asp.net/identity">ASP.NET Identity</a>, a new ASP.NET membership system that works the same in all ASP.NET frameworks and works with web hosting software other than IIS.
</li><li><a href="http://msdn.microsoft.com/data/ef.aspx">Entity Framework 6</a>, an update to the Entity Framework which allows you retrieve and manipulate data as strongly typed objects, access data asynchronous, handle transient connection faults, and log SQL
 statements. </li></ul>
<p>For a complete list of ASP.NET 4.5 features, see <a href="http://www.asp.net/visual-studio/overview/2013/release-notes">
ASP.NET and Web Tools for Visual Studio 2013 Release Notes</a>.</p>
<h1>The Wingtip Toys Sample Application</h1>
<p>The following screen shots provide a quick view of the ASP.NET Web forms application that you will create in this tutorial series. When you run the application from Visual Studio&nbsp;Express&nbsp;2013 for Web, you will see the following web Home page.</p>
<p><img id="146998" src="https://i1.code.msdn.s-msft.com/getting-started-with-221c01f5/image/file/146998/1/wingtiptoys.png" alt="" width="1008" height="539" style="width:625px; height:357px"></p>
<p>&nbsp;</p>
<h1>Download the Sample Application</h1>
<p>After installing the prerequisites, you are ready to begin creating the new Web project that is presented in this tutorial series. If you would like to run the sample application that this tutorial series creates, you can download it from the MSDN Samples
 site (here). This download contains the following in the <em>C#</em> folder:</p>
<ul>
<li>The sample application in the <em>WingtipToys</em> folder. </li><li>The resources used to create the sample application in the <em>WingtipToys-Assets</em> folder.
</li></ul>
<p>The download is a <em>.zip</em> file. To see the completed project that this tutorial series creates, find and select the
<em>C#</em> folder in the <em>.zip</em> file. Save the <em>C#</em> folder <strong>
</strong>to your Visual Studio 2013 Projects folder. By default this is the following folder:</p>
<p>C:\Users\<em>&lt;username&gt;</em>\Documents\Visual Studio 2013\Projects</p>
<p>Rename the <em>C#</em> folder to <em>WingtipToys</em>.</p>
<p><strong>Note</strong></p>
<p>If you already have a folder named <em>WingtipToys</em> in your <strong>Projects</strong> folder, temporarily rename that existing folder before&nbsp;renaming the
<em>C#</em>&nbsp;folder.</p>
<p>To run the completed project, open the <em>WingtipToys</em> folder and double-click the
<em>WingtipToys.sln</em> file. Visual Studio&nbsp;Express 2013 for Web will open the project. Next, right-click the
<em>Default.aspx</em> file in the <strong>Solution Explorer</strong> window and click
<strong>View In Browser</strong> from the right-click menu.</p>
<p>To use PayPal with this sample, you must modify this sample by adding&nbsp;the
<strong>API Username</strong>, the <strong>API Password</strong>, and the <strong>
Signature</strong>. See the <strong>Integrating PayPal</strong> section of the <strong>
Checkout and Payment with PayPal</strong> tutorial. Also, you must update the LoalHost port number. See the
<strong>Update the LocalHost Port Number in the PayPal Class </strong>section of the
<strong>Checkout and Payment with PayPal </strong>tutorial.</p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:711px; width:1px; height:1px; overflow:hidden">
</div>
