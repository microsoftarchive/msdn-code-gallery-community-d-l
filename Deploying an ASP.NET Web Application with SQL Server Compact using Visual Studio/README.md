# Deploying an ASP.NET Web Application with SQL Server Compact using Visual Studio
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- SQL Server Compact
- Visual Studio 2012
## Topics
- ASP.NET Code Sample Downloads
- web application deployment
## Updated
- 06/13/2014
## Description

<p>This Contoso University application is used by the ASP.NET tutorial series <a href="http://social.technet.microsoft.com/wiki/contents/articles/11608.e-book-gallery-for-microsoft-technologies.aspx#GettingStartedwiththeEntityFramework4.1usingASP.NETMVC">
</a><a href="http://www.asp.net/web-forms/tutorials/deployment/deployment-to-a-hosting-provider/deployment-to-a-hosting-provider-introduction-1-of-12">Deploying an ASP.NET Web Application with SQL Server Compact using Visual Studio</a>. Part of the introductory
 chapter is reproduced below:</p>
<h2>Prerequisites</h2>
<p>Before you start, make sure that you have Windows 7 or later and one of the following products installed on your computer:</p>
<ul>
<li><a href="http://www.microsoft.com/web/gallery/install.aspx?appsxml=&appid=VS2010SP1Pack">Visual Studio 2010 SP1</a>
</li><li><a href="http://www.microsoft.com/web/gallery/install.aspx?appsxml=&appid=VWD2010SP1Pack">Visual Web Developer Express 2010 SP1</a>
</li><li><a href="http://go.microsoft.com/fwlink/?LinkId=240162">Visual Studio 2012 RC or Visual Studio Express 2012 RC for Web</a>
</li></ul>
<p>If you have Visual Studio 2010 SP1 or Visual Web Developer Express 2010 SP1, install the following products also:</p>
<ul>
<li><a href="http://go.microsoft.com/fwlink/?LinkID=208120">Windows Azure SDK for .NET (VS 2010 SP1)</a> (includes the Web Publish Update)
</li><li><a href="http://www.microsoft.com/web/gallery/install.aspx?appid=SQLCEVSTools">Microsoft Visual Studio 2010 SP1 Tools for SQL Server Compact 4.0</a>
</li></ul>
<p>Some other software is required in order to complete the tutorial, but you don't have to have that loaded yet. The tutorial will walk you through the steps for installing it when you need it.</p>
<h2>Downloading the Sample Application</h2>
<p>The application you'll deploy is named Contoso University and has already been created for you. It's a simplified version of a university web site, based loosely on the Contoso University application described in the
<a href="http://asp.net/entity-framework/tutorials">Entity Framework tutorials on the ASP.NET site</a>.</p>
<p>When you have the prerequisites installed, download the <a href="http://archive.msdn.microsoft.com/Project/Download/FileDownload.aspx?ProjectName=aspnetmsdnexamples&DownloadId=16098">
Contoso University web application</a>. The <em>.zip</em> file contains multiple versions of the project and a PDF file that contains all 12 tutorials. To work through the steps of the tutorial, start with ContosoUniversity-Begin. To see what the project looks
 like at the end of the tutorials, open ContosoUniversity-End. To see what the project looks like before the migration to full SQL Server in tutorial 10, open ContosoUniversity-AfterTutorial09.</p>
<p>To prepare to work through the tutorial steps, save ContosoUniversity-Begin to whatever folder you use for working with Visual Studio projects. By default this is the following folder:</p>
<p><code>C:\Users\<em>&lt;username&gt;</em>\Documents\Visual Studio 2012\Projects</code></p>
<p>(For the screen shots in this tutorial, the project folder is located in the root directory on the
<code>C</code>: drive.)</p>
<p>Start Visual Studio, open the project, and press CTRL-F5 to run it.</p>
<p><a href="http://i3.asp.net/media/2872421/Windows-Live-Writer_Deployment-to-a-Hosting-Provider-Deployi_97F1_Home_page_4.png?cdn_id=2014-05-21-001"><img src="-windows-live-writer_deployment-to-a-hosting-provider-deployi_97f1_home_page_thumb_1.png?cdn_id=2014-05-21-001" border="0" alt="Home_page" width="634" height="185"></a></p>
<p>The website pages are accessible from the menu bar and let you perform the following functions:</p>
<ul>
<li>Display student statistics (the About page). </li><li>Display, edit, delete, and add students. </li><li>Display and edit courses. </li><li>Display and edit instructors. </li><li>Display and edit departments. </li></ul>
<p>Following are screen shots of a few representative pages.</p>
<p><a href="http://i2.asp.net/media/2872433/Windows-Live-Writer_Deployment-to-a-Hosting-Provider-Deployi_97F1_Students_Page_1.png?cdn_id=2014-05-21-001"><img src="-windows-live-writer_deployment-to-a-hosting-provider-deployi_97f1_students_page_thumb_1.png?cdn_id=2014-05-21-001" border="0" alt="Students_Page" width="638" height="292"></a></p>
<p><a href="http://i3.asp.net/media/2872445/Windows-Live-Writer_Deployment-to-a-Hosting-Provider-Deployi_97F1_Add_Students_Page_1.png?cdn_id=2014-05-21-001"><img src="-windows-live-writer_deployment-to-a-hosting-provider-deployi_97f1_add_students_page_thumb_1.png?cdn_id=2014-05-21-001" border="0" alt="Add_Students_Page" width="637" height="222"></a></p>
<h2>Reviewing Application Features that Affect Deployment</h2>
<p>The following features of the application affect how you deploy it or what you have to do to deploy it. Each of these is explained in more detail in the following tutorials in the series.</p>
<ul>
<li>Contoso University uses a SQL Server Compact database to store application data such as student and instructor names. The database contains a mix of test data and production data, and when you deploy to production you need to exclude the test data.&nbsp;
 Later in the tutorial series you'll migrate from SQL Server Compact to SQL Server.
</li><li>The application uses the ASP.NET membership system, which stores user account information in a SQL Server Compact database. The application defines an administrator user who has access to some restricted information. You need to deploy the membership database
 without test accounts but with one administrator account. </li><li>Because the application database and the membership database use SQL Server Compact as the database engine, you have to deploy the database engine to the hosting provider, as well as the databases themselves.
</li><li>The application uses ASP.NET universal membership providers so that the membership system can store its data in a SQL Server Compact database. The assembly that contains the universal membership providers must be deployed with the application.
</li><li>The application uses the Entity Framework 5.0 to access data in the application database. The assembly that contains Entity Framework 5.0 must be deployed with the application.
</li><li>The application uses a third-party error logging and reporting utility. This utility is provided in an assembly which must be deployed with the application.
</li><li>The error logging utility writes error information in XML files to a file folder. You have to make sure that the account that ASP.NET runs under in the deployed site has write permission to this folder, and you have to exclude this folder from deployment.
 (Otherwise, error log data from the test environment might be deployed to production and/or production error log files might be deleted.)
</li><li>The application includes some settings that must be changed in in the deployed
<em>Web.config</em> file depending on the destination environment (test or production), and other settings that must be changed depending on the build configuration (Debug or Release).
</li><li>The Visual Studio solution includes a class library project. Only the assembly that this project generates should be deployed, not the project itself.
</li></ul>
