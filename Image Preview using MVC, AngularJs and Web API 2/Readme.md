# Image Preview using MVC, AngularJs and Web API 2
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- WebAPI
- AngularJS
## Topics
- ASP.NET MVC
- WebAPI
- AngularJS
## Updated
- 08/31/2015
## Description

<h1>Introduction</h1>
<p><img id="141974" src="141974-1.jpg" alt="" width="600" height="400"></p>
<p>In my previous article I explained AngualrJS with MVC and WCS Rest service. This article explains in detail how to create a simple Image Slideshow using MVC&nbsp;and AngularJs and using Web API 2.<br>
<br>
You can also view my previous articles related to AngularJs using MVC and the WCF Rest Serice.</p>
<ul>
<li><em><a href="https://code.msdn.microsoft.com/Dynamic-scheduling-using-35328360" target="_blank">https://code.msdn.microsoft.com/Dynamic-scheduling-using-35328360</a></em>
</li><li><a href="https://code.msdn.microsoft.com/MVC-Angular-JS-CRUD-using-b4845edc" target="_blank">https://code.msdn.microsoft.com/MVC-Angular-JS-CRUD-using-b4845edc</a>
</li><li><a href="https://code.msdn.microsoft.com/AngularJS-Shopping-Cart-8d4dde90" target="_blank">https://code.msdn.microsoft.com/AngularJS-Shopping-Cart-8d4dde90</a>
</li><li><a href="https://code.msdn.microsoft.com/MVC-AngularJS-and-WCF-Rest-27d239b4" target="_blank">https://code.msdn.microsoft.com/MVC-AngularJS-and-WCF-Rest-27d239b4</a>
</li><li><a href="https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919" target="_blank">https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919</a>
</li></ul>
<ul>
<li><a href="https://code.msdn.microsoft.com/AngularJS-Filter-Sorting-1fe023c3" target="_blank">https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919</a>
</li></ul>
<p><span style="font-size:2em">Building the Sample</span></p>
<p><strong>Prerequisites<br>
</strong><br>
Visual Studio 2015. You can download it from <a rel="nofollow" href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx">
here</a>. (In my example I have used Visual Studio Community 2015 RC.)</p>
<p>Note :You can download and use the New Visual Studio 2015.<br>
<br>
This article explains the following in detail:</p>
<ol>
<li>Select Image details from the database using EF and WEB API. </li><li>Upload Image to our root folder using AngularJs and MVC Controller method. </li><li>Insert uploaded image details to the database using AngularJs , MVC and the WEB API.
</li><li>Display animated images by clicking on Preview Image. </li></ol>
<p>The base idea for this article was from my article on Windows Forms Based Image Slideshow Application. You can also have a look at that article.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>1. Create Database and Table<br>
</strong><br>
We will create a ImageDetails table under the database ImageDB. The following is the script to create a database, table and sample insert query. Run this script in your SQL Server. I have used SQL Server 2012.<br>
<br>
<strong>Note:</strong> In my project folder I have all the images for a sample display.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>
<pre class="hidden">-- =============================================                                
-- Author      : Shanu                                
-- Create date : 2015-05-15                                  
-- Description : To Create Database,Table and Sample Insert Query                             
-- Latest                                
-- Modifier    : Shanu                                
-- Modify date : 2015-05-15                            
-- =============================================
--Script to create DB,Table and sample Insert data
USE MASTER
GO
-- 1) Check for the Database Exists .If the database is exist then drop and create new DB
IF EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'ImageDB' )
DROP DATABASE DynamicProject
GO

CREATE DATABASE ImageDB
GO

USE ImageDB
GO

-- 1) //////////// ItemMasters

IF EXISTS ( SELECT [name] FROM sys.tables WHERE [name] = 'ImageDetails' )
DROP TABLE ImageDetails
GO

CREATE TABLE [dbo].[ImageDetails](
	[ImageID] INT IDENTITY PRIMARY KEY,
	[Image_Path] [varchar](100) NOT NULL,	
	[Description] [varchar](200) NOT NULL)
 

INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('1.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('2.jpg','Purple Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('3.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('4.jpg','Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('5.jpg','Tulip')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('6.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('7.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('8.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('9.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('10.jpg','Flowers')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('11.jpg','Afraz&amp;Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('12.jpg','LoveLock')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('13.jpg','Rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('14.jpg','Yellow Rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('15.jpg','Red rose')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('16.jpg','Cherry blossom')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('17.jpg','Afreen')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('18.jpg','fish Market')
INSERT INTO [ImageDetails] ([Image_Path],[Description])  VALUES    ('19.jpg','Afraz')

                 
select * from [ImageDetails]
</pre>
<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date&nbsp;:&nbsp;2015-05-15&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Description&nbsp;:&nbsp;To&nbsp;Create&nbsp;Database,Table&nbsp;and&nbsp;Sample&nbsp;Insert&nbsp;Query&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Latest&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Modifier&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;2015-05-15&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================</span>&nbsp;
--<span class="sql__id">Script</span>&nbsp;<span class="sql__keyword">to</span>&nbsp;<span class="sql__keyword">create</span>&nbsp;<span class="sql__id">DB</span>,<span class="sql__keyword">Table</span>&nbsp;<span class="sql__keyword">and</span>&nbsp;<span class="sql__id">sample</span>&nbsp;<span class="sql__keyword">Insert</span>&nbsp;<span class="sql__keyword">data</span>&nbsp;
<span class="sql__keyword">USE</span>&nbsp;<span class="sql__keyword">MASTER</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
<span class="sql__com">--&nbsp;1)&nbsp;Check&nbsp;for&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;new&nbsp;DB</span>&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__keyword">EXISTS</span>&nbsp;(<span class="sql__keyword">SELECT</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">sys</span>.<span class="sql__keyword">databases</span>&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'ImageDB'</span>&nbsp;)&nbsp;
<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;<span class="sql__id">DynamicProject</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">DATABASE</span>&nbsp;<span class="sql__id">ImageDB</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">USE</span>&nbsp;<span class="sql__id">ImageDB</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__com">--&nbsp;1)&nbsp;////////////&nbsp;ItemMasters</span>&nbsp;
&nbsp;
<span class="sql__keyword">IF</span>&nbsp;<span class="sql__keyword">EXISTS</span>&nbsp;(&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">sys</span>.<span class="sql__keyword">tables</span>&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'ImageDetails'</span>&nbsp;)&nbsp;
<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;<span class="sql__id">ImageDetails</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">ImageDetails</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">ImageID</span>]&nbsp;<span class="sql__keyword">INT</span>&nbsp;<span class="sql__id">IDENTITY</span>&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Image_Path</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Description</span>]&nbsp;[<span class="sql__keyword">varchar</span>](<span class="sql__number">200</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>)&nbsp;
&nbsp;&nbsp;
&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'1.jpg'</span>,<span class="sql__string">'Afreen'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'2.jpg'</span>,<span class="sql__string">'Purple&nbsp;Tulip'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'3.jpg'</span>,<span class="sql__string">'Afreen'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'4.jpg'</span>,<span class="sql__string">'Tulip'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'5.jpg'</span>,<span class="sql__string">'Tulip'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'6.jpg'</span>,<span class="sql__string">'Flowers'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'7.jpg'</span>,<span class="sql__string">'Flowers'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'8.jpg'</span>,<span class="sql__string">'Flowers'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'9.jpg'</span>,<span class="sql__string">'Flowers'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'10.jpg'</span>,<span class="sql__string">'Flowers'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'11.jpg'</span>,<span class="sql__string">'Afraz&amp;Afreen'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'12.jpg'</span>,<span class="sql__string">'LoveLock'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'13.jpg'</span>,<span class="sql__string">'Rose'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'14.jpg'</span>,<span class="sql__string">'Yellow&nbsp;Rose'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'15.jpg'</span>,<span class="sql__string">'Red&nbsp;rose'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'16.jpg'</span>,<span class="sql__string">'Cherry&nbsp;blossom'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'17.jpg'</span>,<span class="sql__string">'Afreen'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'18.jpg'</span>,<span class="sql__string">'fish&nbsp;Market'</span>)&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;([<span class="sql__id">Image_Path</span>],[<span class="sql__id">Description</span>])&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'19.jpg'</span>,<span class="sql__string">'Afraz'</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">select</span>&nbsp;*&nbsp;<span class="sql__keyword">from</span>&nbsp;[<span class="sql__id">ImageDetails</span>]&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>2. Create our First MVC Web Application in Visual Studio 2015</strong></p>
<p>Now to create our first MVC web application in Visual Studio 2015.<br>
<br>
After installing Visual Studio 2015, click Start then select Programs then select Visual Studio 2015. Then click Visual Studio 2015 RC.</p>
<p><img id="141975" src="141975-2.jpg" alt="" width="251" height="75"></p>
<p>Click New -&gt; Project - &gt; Select Web -&gt; ASP.NET Web Application. Select your project's location and enter your web application's name.<br>
<img id="141976" src="141976-3.jpg" alt="" width="606" height="300"></p>
<p>Select MVC and in &quot;Add Folders and Core reference for:&quot; select the Web API (as in the following) and click OK.<br>
<img id="141977" src="141977-4.jpg" alt="" width="500" height="300"></p>
<p>Now we have created our MVC application. As a next step we will add our SQL Server database as an Entity Data Model to our application.<br>
<br>
<strong>Add Database using ADO.NET Entity Data Model<br>
</strong><br>
Right-click our project and click Add -&gt; New Item.<br>
Select Data -&gt; Select ADO.NET Entity Data Model then provide the name for our EF and click Add.<br>
<img id="141978" src="141978-6.jpg" alt="" width="501" height="300"></p>
<p>Select EF Designer from database and click Next.<br>
Here click New Connection and provide your SQL-Server Server Name and connect to your database.</p>
<p><img id="141979" src="141979-8.jpg" alt="" width="400" height="300"></p>
<p>Here we can see I have given my SQL Server name, Id and PWD. After the connection, the database is selected as ImageDB since we have created the database using my SQL Script.<br>
<img id="141980" src="141980-9.jpg" alt="" width="500" height="350"></p>
<p>Click Next and select the table to be used and click Finish.<br>
Here we can see I have selected our table Imagedetails. This table will be used to get and insert all our images.<br>
<img id="141981" src="141981-11.jpg" alt="" width="500" height="350"></p>
<p>Once our entity has been created the next step is to add a WEB API to our controller and write a function to get and insert records.<br>
<br>
<strong>Procedure to add our WEB API Controller<br>
</strong><br>
Right-click the Controllers folder then click Add then click Controller.<br>
Since we will create our WEB API Controller, select Controller and Add Empty WEB API 2 Controller. Provide your name to the Web API controller and click OK. Here for my Web API Controller I have given the name as &ldquo;ImageController&rdquo;.<br>
<img id="141982" src="141982-14.jpg" alt="" width="500" height="350"></p>
<p>As we all know, the Web API is a simple and easy way to build HTTP Services for Browsers and Mobiles. Web APIs has the four methods
<strong>Get/Post/Put and Delete</strong> where:</p>
<ul>
<li><strong>Get</strong> is to request data. (Select) </li><li><strong>Post</strong> is to create data. (Insert) </li><li><strong>Put</strong> is to update data. </li><li><strong>Delete</strong> is to delete data. </li></ul>
<p>In our example we will use both <strong>Get</strong> and <strong>Post</strong> since we need to get all the image names and descriptions from the database and to insert a new Image Name and Image Description into the database.<br>
<br>
<strong>Get Method<br>
</strong><br>
Now as a next step we need to create an object for our entity and write our Get and Post methods.
<br>
<br>
We will use a get method to get all the details of the ImageDetails table using an entity object and we will return the result as an IEnumerable. We will use this method in our AngularJs and display the result in a MVC page from the AngularJs controller using
 Ng-Repeat. We can see the details step-by-step as follows.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ImageController : ApiController
        {
            ImageDBEntities objAPI = new ImageDBEntities();


 //get all Images
        [HttpGet]
        public IEnumerable&lt;ImageDetails&gt; Get()
        {
            return objAPI.ImageDetails.AsEnumerable();
            //return objAPI.ImageDetails.AsEnumerable().OrderByDescending(item =&gt; item.ImageID );

        }


    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ImageController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageDBEntities&nbsp;objAPI&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImageDBEntities();&nbsp;
&nbsp;
&nbsp;
&nbsp;<span class="cs__com">//get&nbsp;all&nbsp;Images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;ImageDetails&gt;&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objAPI.ImageDetails.AsEnumerable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//return&nbsp;objAPI.ImageDetails.AsEnumerable().OrderByDescending(item&nbsp;=&gt;&nbsp;item.ImageID&nbsp;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Post Method<br>
</strong><br>
Using the post method we will insert the Image details into the database. If HttpResponseMessage is used in the Action result, the Web API will convert the return value into a HTTP response message.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class ImageController : ApiController
    {
        ImageDBEntities objAPI = new ImageDBEntities();

        //get all Images
        [HttpGet]
        public IEnumerable&lt;ImageDetails&gt; Get()
        {
           return objAPI.ImageDetails.AsEnumerable();
            //return objAPI.ImageDetails.AsEnumerable().OrderByDescending(item =&gt; item.ImageID );

        }

        //insert Image
        public HttpResponseMessage Post(ImageDetails imagedetails)
        {
            if (ModelState.IsValid)
            {
                objAPI.ImageDetails.Add(imagedetails);
                objAPI.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, imagedetails);
                response.Headers.Location = new Uri(Url.Link(&quot;DefaultApi&quot;, new { id = imagedetails.Image_Path}));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ImageController&nbsp;:&nbsp;ApiController&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageDBEntities&nbsp;objAPI&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ImageDBEntities();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//get&nbsp;all&nbsp;Images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;ImageDetails&gt;&nbsp;Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objAPI.ImageDetails.AsEnumerable();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//return&nbsp;objAPI.ImageDetails.AsEnumerable().OrderByDescending(item&nbsp;=&gt;&nbsp;item.ImageID&nbsp;);</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//insert&nbsp;Image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;HttpResponseMessage&nbsp;Post(ImageDetails&nbsp;imagedetails)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ModelState.IsValid)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objAPI.ImageDetails.Add(imagedetails);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objAPI.SaveChanges();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;Request.CreateResponse(HttpStatusCode.Created,&nbsp;imagedetails);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;response.Headers.Location&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(Url.Link(<span class="cs__string">&quot;DefaultApi&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;{&nbsp;id&nbsp;=&nbsp;imagedetails.Image_Path}));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;response;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Request.CreateErrorResponse(HttpStatusCode.BadRequest,&nbsp;ModelState);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Now we have created our Web API Controller Class. The next step is to create our AngularJs Module and Controller. Let us see how to create our AngularJs Controller. In Visual Studio 2015 it's much easier to add our AngularJs
 Controller. Let us see see step-by-step how to create and write our AngularJs Controller.<br>
<br>
<strong>Creating AngularJs Controller</strong><br>
<br>
First create a folder inside the Script Folder and I have named the folder &ldquo;MyAngular&rdquo;.</div>
<p><img id="141983" src="141983-16.jpg" alt="" width="313" height="286"></p>
<p>&nbsp;</p>
<p>Now add your Angular Controller inside the folder.</p>
<p><br>
Right-click the MyAngular folder and click Add and New Item. Select Web. Select AngularJs Controller and provide a name to the Controller. I have given my AngularJs Controller the name &ldquo;Controller.js&rdquo;.<br>
<img id="141984" src="141984-19.jpg" alt="" width="600" height="350"></p>
<p>Once the AngularJs Controller is created, we can see that, by default, the controller will have the code with the default module definition.&nbsp;<br>
<br>
If the AngularJs package is missing then add the package to your project.<br>
<br>
Right-click your MVC project and click Manage NuGet Packages. Search for AngularJs and click Install.</p>
<p><img id="141986" src="141986-19.jpg" alt="" width="600" height="350"></p>
<p>In my previous articles related to AngularJs I explained the use of AngularJs ng-repeat to display the data from AngularJs and how to receive data from WCF to Angular Services, how to do simple animation in AngularJs and how to upload images using AnngularJS
 and a MVC Controller. To see more details about each, kindly refer to my previous article, you can find a link of each at the top of this article.<br>
<br>
Now in my controller I will change the code with my Module and Controller as in the following.<br>
<br>
First we will add all the references to AngularJs and then we will create a module. I have given my module the name &ldquo;RESTClientModule&rdquo;. Since we need to use simple Animation we will add the &quot;ngAnimate&quot; to our Module.<br>
<br>
In the controller for using the animation I used $timeout and for the file upload I uses the service FileUploadService. First we start with following.<br>
<br>
<strong>1. Variable declarations<br>
</strong><br>
First I declared all the local variables that need to be used and the current date and store the date using and same, like this I have declared all the variables &nbsp;that need to be used.<br>
<br>
$scope.date.<br>
<br>
<strong>2. Methods<br>
</strong><br>
To get the image details from our Web API we will use the $http.get method as in the following:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$http.get('/api/Image/').success(function (data)</pre>
<div class="preview">
<pre class="js">$http.get(<span class="js__string">'/api/Image/'</span>).success(<span class="js__operator">function</span>&nbsp;(data)</pre>
</div>
</div>
</div>
<div class="endscriptcode">In this we will receive all the data and store the result in:&nbsp;</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$scope.Images = data;   </pre>
<div class="preview">
<pre class="js">$scope.Images&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;I will use these images in ng-repeat to display the images one by one.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">/// &lt;reference path=&quot;../angular.js&quot; /&gt;  
/// &lt;reference path=&quot;../angular.min.js&quot; /&gt;   
/// &lt;reference path=&quot;../angular-animate.js&quot; /&gt;   
/// &lt;reference path=&quot;../angular-animate.min.js&quot; /&gt;   

var app;

(function () {
    app = angular.module(&quot;RESTClientModule&quot;, ['ngAnimate']);
})();
app.controller(&quot;AngularJs_ImageController&quot;, function ($scope, $timeout, $rootScope, $window, $http, FileUploadService) {
    $scope.date = new Date();
    $scope.MyName = &quot;Shanu&quot;;
    $scope.Imagename = &quot;&quot;;
    $scope.ShowImage = false;
    $scope.Description = &quot;&quot;;
    $scope.AnimationImageName = &quot;1.jpg&quot;;
    $scope.ImagesALLVal=[];
    $scope.icountval = 0


    //get all image Details
    $http.get('/api/Image/').success(function (data) {
        $scope.Images = data;    
        if ($scope.Images.length &gt; 0) {
            $scope.onShowImage($scope.Images[0].Image_Path);
        }
    })
    .error(function () {
        $scope.error = &quot;An Error has occured while loading posts!&quot;;

    });
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular.js&quot;&nbsp;/&gt;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;app;&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">&quot;RESTClientModule&quot;</span>,&nbsp;[<span class="js__string">'ngAnimate'</span>]);&nbsp;
<span class="js__brace">}</span>)();&nbsp;
app.controller(<span class="js__string">&quot;AngularJs_ImageController&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;$timeout,&nbsp;$rootScope,&nbsp;$window,&nbsp;$http,&nbsp;FileUploadService)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.date&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__object">Date</span>();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MyName&nbsp;=&nbsp;<span class="js__string">&quot;Shanu&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.Imagename&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ShowImage&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.Description&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.AnimationImageName&nbsp;=&nbsp;<span class="js__string">&quot;1.jpg&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ImagesALLVal=[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.icountval&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//get&nbsp;all&nbsp;image&nbsp;Details</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/Image/'</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Images&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.Images.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.onShowImage($scope.Images[<span class="js__num">0</span>].Image_Path);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;To preview the image click to display the actual image with simple animation. I will call this method in the Image Click event of AngularJs as ng-Click= onShowImage(currentImage).</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">$scope.onShowImage = function (Image_Path) {
        $scope.ShowImage = false;
        $scope.AnimationImageName = Image_Path
      
        $timeout(function () {
            $scope.ShowImage = true;
        }, 400);
       
    }.
</pre>
<div class="preview">
<pre class="js">$scope.onShowImage&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(Image_Path)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ShowImage&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.AnimationImageName&nbsp;=&nbsp;Image_Path&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$timeout(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ShowImage&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__num">400</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>.&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Here we can see that when the user clicks on an image with simple animation I will display the animated image.</div>
<p><img id="141987" src="141987-21.jpg" alt="" width="600" height="400"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>To upload an image and to insert an image name and image description to the database in the save Item button click I will call this function.<br>
<br>
In this method I will check that a valid image was uploaded and if all is true then I will pass the image to the service FileUploadService. If the upload is a success then I will insert the Image details of ImageName and Image Description into the database
 by calling the Web API post method and pass the data for insert. $http.post('/api/Image/', ItmDetails).</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">//Save File
    $scope.SaveFile = function () {
        $scope.IsFormSubmitted = true;

        $scope.Message = &quot;&quot;;

        $scope.ChechFileValid($scope.SelectedFileForUpload);

        if ($scope.IsFormValid &amp;&amp; $scope.IsFileValid) {

            FileUploadService.UploadFile($scope.SelectedFileForUpload).then(function (d) {

                var ItmDetails = {
                    Image_Path: $scope.Imagename,
                    Description: $scope.Description
                };
                $http.post('/api/Image/', ItmDetails).success(function (data) {
                    alert(&quot;Added Successfully!!&quot;);
                    $scope.addMode = false;
                    $scope.Images.push(data);
                    $scope.loading = false;
                }).error(function (data) {
                    $scope.error = &quot;An Error has occured while Adding Customer! &quot; &#43; data;
                    $scope.loading = false;
                });
                alert(d.Message &#43; &quot; Item Saved!&quot;);
                $scope.IsFormSubmitted = false;
                ClearForm();

            }, function (e) {
                alert(e);
            });
        }
        else {
            $scope.Message = &quot;All the fields are required.&quot;;
        }

    };
</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//Save&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.SaveFile&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormSubmitted&nbsp;=&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ChechFileValid($scope.SelectedFileForUpload);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.IsFormValid&nbsp;&amp;&amp;&nbsp;$scope.IsFileValid)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileUploadService.UploadFile($scope.SelectedFileForUpload).then(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ItmDetails&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image_Path:&nbsp;$scope.Imagename,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description:&nbsp;$scope.Description&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.post(<span class="js__string">'/api/Image/'</span>,&nbsp;ItmDetails).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Added&nbsp;Successfully!!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.addMode&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Images.push(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>).error(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;Adding&nbsp;Customer!&nbsp;&quot;</span>&nbsp;&#43;&nbsp;data;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loading&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(d.Message&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;Item&nbsp;Saved!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.IsFormSubmitted&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearForm();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(e);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.Message&nbsp;=&nbsp;<span class="js__string">&quot;All&nbsp;the&nbsp;fields&nbsp;are&nbsp;required.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<em>fac.UploadFile = function (file)</em>
<div><em>&nbsp;</em><br>
In this method we are using $http.post.</div>
<div>Here I have passed our image file to the MVC Home Controller and our HTTPost method is as in the following:</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">.factory('FileUploadService', function ($http, $q) {
    var fac = {};
    fac.UploadFile = function (file) {
        var formData = new FormData();
        formData.append(&quot;file&quot;, file);
        var defer = $q.defer();
        $http.post(&quot;/Home/UploadFile&quot;, formData,
            {
                withCredentials: true,
                headers: { 'Content-Type': undefined },
                transformRequest: angular.identity
            })
        .success(function (d) {
            defer.resolve(d);
        })
        .error(function () {
            defer.reject(&quot;File Upload Failed!&quot;);
        });
        return defer.promise;

    }
</pre>
<div class="preview">
<pre class="js">.factory(<span class="js__string">'FileUploadService'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http,&nbsp;$q)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fac&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fac.UploadFile&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formData&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formData.append(<span class="js__string">&quot;file&quot;</span>,&nbsp;file);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;defer&nbsp;=&nbsp;$q.defer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.post(<span class="js__string">&quot;/Home/UploadFile&quot;</span>,&nbsp;formData,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;withCredentials:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__property">undefined</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transformRequest:&nbsp;angular.identity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.success(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defer.resolve(d);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defer.reject(<span class="js__string">&quot;File&nbsp;Upload&nbsp;Failed!&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;defer.promise;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Note: For $http.post(&ldquo;&rdquo;) we need to provide our MVC Controller name and our HTTPost method name, where we uploaded the image to our root folder. The following is the code that is used to upload an image in our
 MVC Controller.</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">[HttpPost]
        public JsonResult UploadFile()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath(&quot;~/Images&quot;), fileName));
                    Message = &quot;File uploaded&quot;;
                    flag = true;
                }
                catch (Exception)
                {
                    Message = &quot;File upload failed! Please try again&quot;;
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
        }
</pre>
<div class="preview">
<pre class="js">[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;JsonResult&nbsp;UploadFile()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;Message,&nbsp;fileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;=&nbsp;fileName&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;flag&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(Request.Files&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;file&nbsp;=&nbsp;Request.Files[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileName&nbsp;=&nbsp;file.FileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.SaveAs(Path.Combine(Server.MapPath(<span class="js__string">&quot;~/Images&quot;</span>),&nbsp;fileName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;=&nbsp;<span class="js__string">&quot;File&nbsp;uploaded&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;=&nbsp;<span class="js__string">&quot;File&nbsp;upload&nbsp;failed!&nbsp;Please&nbsp;try&nbsp;again&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;JsonResult&nbsp;<span class="js__brace">{</span>&nbsp;Data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;Message&nbsp;=&nbsp;Message,&nbsp;Status&nbsp;=&nbsp;flag&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;We can see an example to upload an image to our application. Browse and select an image to be uploaded to our root folder.</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="141988" src="141988-22.jpg" alt="" width="600" height="400"></p>
<p>Enter the description of the image and click Save Item to upload the image and save the item to the database. Once the image has been saved we can see the success message as in the following.<br>
<img id="141989" src="141989-23.jpg" alt="" width="600" height="282"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>ShanuMVCWebAPIAngular.zip</span> </li></ul>
<h1>More Information</h1>
<p><em>Supported Browsers: Chrome and Firefox.</em></p>
