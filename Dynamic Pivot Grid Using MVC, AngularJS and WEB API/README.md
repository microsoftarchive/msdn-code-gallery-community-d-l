# Dynamic Pivot Grid Using MVC, AngularJS and WEB API
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- pivot
- ASP.NET Web API
- AngularJS
## Topics
- ASP.NET MVC
- pivot
- AngularJS
## Updated
- 12/14/2015
## Description

<h1>Introduction</h1>
<p><img id="145074" src="145074-1.gif" alt="" width="608" height="600"></p>
<div>&nbsp;<span>In this Article we will see in detail of how to create a simple MVC Pivot HTML grid using AngularJS. In my previous article I have explained about how to create a Dynamic Project Scheduling &nbsp;</span><span><a href="https://code.msdn.microsoft.com/Dynamic-scheduling-using-35328360" target="_blank"><span>Dynamic
 Project Scheduling</span></a>&nbsp;.In that article I have used Stored Procedure to display the Pivot result from SQL Query.</span>
<p><span>In real time projects we need to generate many type of reports and we need to display the row wise data to be displayed as column wise. In this article I will explain how to create a Pivot Grid to display from actual data in front end using AngularJS.</span></p>
<p><span>For example let&rsquo;s consider the below example here I have Toy Type (Category) and Toys Name with sales price per day.</span></p>
<p><span>In our database we insert every record of toy details with price details. The raw data which inserted in database will be look like this.</span>&nbsp;</p>
</div>
<div>
<p><strong><span>Toy Sales Detail Table</span></strong></p>
</div>
<p><img id="145075" src="145075-01.png" alt="" width="561" height="167"></p>
<p><span>Here we can see there is total 11 Records. There is repeated of Toy Name and Toy Type for each date. Now if I want to see the total sales for each Toy Name of Toy Type, then I need to create a pivot result to display the record with total Sum of each
 Toy Name per Toy Type. The required output will be looks like this.</span><span>&nbsp;</span><strong>&nbsp;</strong></p>
<p><strong><span>Pivot with Price Sum by Toy Name</span></strong></p>
<p><img id="145076" src="145076-02.png" alt="" width="761" height="91"></p>
<div><span>Here we can see this is much easier to view the total Sales per Toy Name. Here in Pivot we can also add the Column and row Total. By adding the Total it will be easy to find which item has the highest sales.</span>
<p><span>Pivot result has many kind, we can see one more pivot report with Toy Sales Monthly per year. Here we display he pivot result Monthly starting from 07(July) to 11 (November)</span></p>
</div>
<div>&nbsp;<strong><span>Pivot with Price Sum by Monthly</span></strong></div>
<p><img id="145077" src="145077-03.png" alt="" width="767" height="161"></p>
<p>In this article we will see 2 kind of Pivot report.</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp;1)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pivot result to display the Price Sum by Toy Name for each Toy Type</p>
<div>&nbsp; &nbsp; &nbsp; &nbsp; 2)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Pivot result to display the Price Sum by Monthly for each Toy Name</div>
<p><strong>Prerequisites</strong></p>
<p><strong>Visual Studio 2015</strong>&nbsp;- You can download it from&nbsp;<a href="https://www.visualstudio.com/en-us/downloads/visual-studio-2015-downloads-vs.aspx">here</a>.</p>
<p>You can also view my previous articles related to AngularJS using MVC and the WCF Rest Service.</p>
<ul>
<li><em><a href="https://code.msdn.microsoft.com/Dynamic-scheduling-using-35328360" target="_blank">https://code.msdn.microsoft.com/Dynamic-scheduling-using-35328360</a></em>
</li><li><a href="https://code.msdn.microsoft.com/MVC-Angular-JS-CRUD-using-b4845edc" target="_blank">https://code.msdn.microsoft.com/MVC-Angular-JS-CRUD-using-b4845edc</a>
</li><li><a href="https://code.msdn.microsoft.com/AngularJS-Shopping-Cart-8d4dde90" target="_blank">https://code.msdn.microsoft.com/AngularJS-Shopping-Cart-8d4dde90</a>
</li><li><a href="https://code.msdn.microsoft.com/MVC-AngularJS-and-WCF-Rest-27d239b4" target="_blank">https://code.msdn.microsoft.com/MVC-AngularJS-and-WCF-Rest-27d239b4</a>
</li><li><a href="https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919" target="_blank">https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919</a>
</li><li><a href="https://code.msdn.microsoft.com/AngularJS-Filter-Sorting-1fe023c3" target="_blank">https://code.msdn.microsoft.com/MVC-Web-API-and-Angular-JS-36302919</a>
</li><li><a href="https://code.msdn.microsoft.com/Image-Preview-using-MVC-792d881c" target="_blank">https://code.msdn.microsoft.com/Image-Preview-using-MVC-792d881c</a>
</li><li><a href="https://code.msdn.microsoft.com/MVC-AngularJS-MasterDetail-7598c3a7" target="_blank">https://code.msdn.microsoft.com/MVC-AngularJS-MasterDetail-7598c3a7&nbsp;</a>
</li></ul>
<h1><span>Building the Sample</span></h1>
<p><strong><span>Create Database and Table</span></strong></p>
<p><span>First Step we create a Sample Database and Table to be used in our project .</span><span>The following is the script to create a database, table and sample insert query.</span></p>
<p><span>Run this script in your SQL Server. I have used SQL Server 2014.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Create&nbsp;date&nbsp;:&nbsp;2015-11-20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Description&nbsp;:&nbsp;To&nbsp;Create&nbsp;Database,Table&nbsp;and&nbsp;Sample&nbsp;Insert&nbsp;Query&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Latest&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Modifier&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;2015-11-20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span class="sql__com">--&nbsp;=============================================</span>&nbsp;
--<span class="sql__id">Script</span><span class="sql__keyword">to</span><span class="sql__keyword">create</span><span class="sql__id">DB</span>,<span class="sql__keyword">Table</span><span class="sql__keyword">and</span><span class="sql__id">sample</span><span class="sql__keyword">Insert</span><span class="sql__keyword">data</span><span class="sql__keyword">USE</span><span class="sql__keyword">MASTER</span>;&nbsp;
<span class="sql__com">--&nbsp;1)&nbsp;Check&nbsp;for&nbsp;the&nbsp;Database&nbsp;Exists&nbsp;.If&nbsp;the&nbsp;database&nbsp;is&nbsp;exist&nbsp;then&nbsp;drop&nbsp;and&nbsp;create&nbsp;new&nbsp;DB</span><span class="sql__keyword">IF</span><span class="sql__keyword">EXISTS</span>&nbsp;(<span class="sql__keyword">SELECT</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span><span class="sql__id">sys</span>.<span class="sql__keyword">databases</span><span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'ToysDB'</span>&nbsp;)&nbsp;
<span class="sql__keyword">BEGIN</span><span class="sql__keyword">ALTER</span><span class="sql__keyword">DATABASE</span><span class="sql__id">ToysDB</span><span class="sql__keyword">SET</span><span class="sql__id">SINGLE_USER</span><span class="sql__keyword">WITH</span><span class="sql__keyword">ROLLBACK</span><span class="sql__id">IMMEDIATE</span><span class="sql__keyword">DROP</span><span class="sql__keyword">DATABASE</span><span class="sql__id">ToysDB</span>&nbsp;;&nbsp;
<span class="sql__keyword">END</span><span class="sql__keyword">CREATE</span><span class="sql__keyword">DATABASE</span><span class="sql__id">ToysDB</span><span class="sql__id">GO</span><span class="sql__keyword">USE</span><span class="sql__id">ToysDB</span><span class="sql__id">GO</span><span class="sql__com">--&nbsp;1)&nbsp;////////////&nbsp;ToysDetails&nbsp;table</span><span class="sql__com">--&nbsp;Create&nbsp;Table&nbsp;&nbsp;ToysDetails&nbsp;,This&nbsp;table&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;store&nbsp;the&nbsp;details&nbsp;like&nbsp;Toys&nbsp;Information</span><span class="sql__keyword">IF</span><span class="sql__keyword">EXISTS</span>&nbsp;(&nbsp;<span class="sql__keyword">SELECT</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;<span class="sql__keyword">FROM</span><span class="sql__id">sys</span>.<span class="sql__keyword">tables</span><span class="sql__keyword">WHERE</span>&nbsp;[<span class="sql__keyword">name</span>]&nbsp;=&nbsp;<span class="sql__string">'ToysSalesDetails'</span>&nbsp;)&nbsp;
<span class="sql__keyword">DROP</span><span class="sql__keyword">TABLE</span><span class="sql__id">ToysSalesDetails</span><span class="sql__id">GO</span><span class="sql__keyword">CREATE</span><span class="sql__keyword">TABLE</span><span class="sql__id">ToysSalesDetails</span>&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_ID</span><span class="sql__keyword">int</span><span class="sql__id">identity</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>),&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_Type</span><span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_Name</span><span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_Price</span><span class="sql__keyword">int</span><span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">Image_Name</span><span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">SalesDate</span><span class="sql__keyword">DateTime</span><span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;<span class="sql__id">AddedBy</span><span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;<span class="sql__keyword">NOT</span><span class="sql__value">NULL</span>,&nbsp;
<span class="sql__keyword">CONSTRAINT</span>&nbsp;[<span class="sql__id">PK_ToysSalesDetails</span>]&nbsp;<span class="sql__keyword">PRIMARY</span><span class="sql__keyword">KEY</span><span class="sql__id">CLUSTERED</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;[<span class="sql__id">Toy_ID</span>]&nbsp;<span class="sql__keyword">ASC</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)<span class="sql__keyword">WITH</span>&nbsp;(<span class="sql__id">PAD_INDEX</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">STATISTICS_NORECOMPUTE</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">IGNORE_DUP_KEY</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">ALLOW_ROW_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>,&nbsp;<span class="sql__id">ALLOW_PAGE_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
--<span class="sql__keyword">delete</span><span class="sql__keyword">from</span><span class="sql__id">ToysSalesDetails</span><span class="sql__com">--&nbsp;Insert&nbsp;the&nbsp;sample&nbsp;records&nbsp;to&nbsp;the&nbsp;ToysDetails&nbsp;Table</span><span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Spiderman'</span>,<span class="sql__number">1650</span>,<span class="sql__string">'ASpiderman.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Spiderman'</span>,<span class="sql__number">1250</span>,<span class="sql__string">'ASpiderman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">6</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Superman'</span>,<span class="sql__number">1450</span>,<span class="sql__string">'ASuperman.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Superman'</span>,<span class="sql__number">850</span>,<span class="sql__string">'ASuperman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">4</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Thor'</span>,<span class="sql__number">1350</span>,<span class="sql__string">'AThor.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Thor'</span>,<span class="sql__number">950</span>,<span class="sql__string">'AThor.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">8</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Wolverine'</span>,<span class="sql__number">1250</span>,<span class="sql__string">'AWolverine.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Wolverine'</span>,<span class="sql__number">450</span>,<span class="sql__string">'AWolverine.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">3</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'CaptainAmerica'</span>,<span class="sql__number">1100</span>,<span class="sql__string">'ACaptainAmerica.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Spiderman'</span>,<span class="sql__number">250</span>,<span class="sql__string">'ASpiderman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">120</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Spiderman'</span>,<span class="sql__number">1950</span>,<span class="sql__string">'ASpiderman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">40</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Superman'</span>,<span class="sql__number">1750</span>,<span class="sql__string">'ASuperman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">40</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Thor'</span>,<span class="sql__number">900</span>,<span class="sql__string">'AThor.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">100</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Thor'</span>,<span class="sql__number">850</span>,<span class="sql__string">'AThor.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">50</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Wolverine'</span>,<span class="sql__number">250</span>,<span class="sql__string">'AWolverine.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">80</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'CaptainAmerica'</span>,<span class="sql__number">800</span>,<span class="sql__string">'ACaptainAmerica.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">60</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Superman'</span>,<span class="sql__number">1950</span>,<span class="sql__string">'ASuperman.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">80</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Thor'</span>,<span class="sql__number">1250</span>,<span class="sql__string">'AThor.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">30</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Action'</span>,<span class="sql__string">'Wolverine'</span>,<span class="sql__number">850</span>,<span class="sql__string">'AWolverine.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">20</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Lion'</span>,<span class="sql__number">1250</span>,<span class="sql__string">'Lion.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Lion'</span>,<span class="sql__number">950</span>,<span class="sql__string">'Lion.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">4</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Tiger'</span>,<span class="sql__number">1900</span>,<span class="sql__string">'Tiger.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Tiger'</span>,<span class="sql__number">600</span>,<span class="sql__string">'Tiger.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">2</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Panda'</span>,<span class="sql__number">650</span>,<span class="sql__string">'Panda.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Panda'</span>,<span class="sql__number">1450</span>,<span class="sql__string">'Panda.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">1</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Dog'</span>,<span class="sql__number">200</span>,<span class="sql__string">'Dog.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Lion'</span>,<span class="sql__number">450</span>,<span class="sql__string">'Lion.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">20</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Tiger'</span>,<span class="sql__number">400</span>,<span class="sql__string">'Tiger.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">90</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Panda'</span>,<span class="sql__number">550</span>,<span class="sql__string">'Panda.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">120</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Dog'</span>,<span class="sql__number">1200</span>,<span class="sql__string">'Dog.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">60</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Lion'</span>,<span class="sql__number">450</span>,<span class="sql__string">'Lion.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">90</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Animal'</span>,<span class="sql__string">'Tiger'</span>,<span class="sql__number">400</span>,<span class="sql__string">'Tiger.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">30</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Owl'</span>,<span class="sql__number">600</span>,<span class="sql__string">'BOwl.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Greenbird'</span>,<span class="sql__number">180</span>,<span class="sql__string">'BGreenbird.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Thunderbird'</span>,<span class="sql__number">550</span>,<span class="sql__string">'BThunderbird-v2.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Owl'</span>,<span class="sql__number">600</span>,<span class="sql__string">'BOwl.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">50</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Greenbird'</span>,<span class="sql__number">180</span>,<span class="sql__string">'BGreenbird.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">90</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Bird'</span>,<span class="sql__string">'Thunderbird'</span>,<span class="sql__number">550</span>,<span class="sql__string">'BThunderbird-v2.png'</span>,<span class="sql__id">getdate</span>()-<span class="sql__number">120</span>,<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Car'</span>,<span class="sql__string">'SingleSeater'</span>,<span class="sql__number">1600</span>,<span class="sql__string">'CSingleSeater.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Car'</span>,<span class="sql__string">'Mercedes'</span>,<span class="sql__number">2400</span>,<span class="sql__string">'CMercedes.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Car'</span>,<span class="sql__string">'FordGT'</span>,<span class="sql__number">1550</span>,<span class="sql__string">'CFordGT.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
<span class="sql__keyword">Insert</span><span class="sql__keyword">into</span><span class="sql__id">ToysSalesDetails</span>(<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Toy_Price</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span>,<span class="sql__id">AddedBy</span>)&nbsp;<span class="sql__keyword">values</span>(<span class="sql__string">'Car'</span>,<span class="sql__string">'Bus'</span>,<span class="sql__number">700</span>,<span class="sql__string">'CBus.png'</span>,<span class="sql__id">getdate</span>(),<span class="sql__string">'Shanu'</span>)&nbsp;
&nbsp;
<span class="sql__keyword">select</span>&nbsp;*,&nbsp;
<span class="sql__function">SUBSTRING</span>(<span class="sql__string">'JAN&nbsp;FEB&nbsp;MAR&nbsp;APR&nbsp;MAY&nbsp;JUN&nbsp;JUL&nbsp;AUG&nbsp;SEP&nbsp;OCT&nbsp;NOV&nbsp;DEC&nbsp;'</span>,&nbsp;(<span class="sql__id">DATENAME</span>(<span class="sql__keyword">month</span>,&nbsp;<span class="sql__id">SalesDate</span>)&nbsp;&nbsp;*&nbsp;<span class="sql__number">4</span>)&nbsp;-&nbsp;<span class="sql__number">3</span>,&nbsp;<span class="sql__number">3</span>)&nbsp;<span class="sql__keyword">as</span><span class="sql__string">'Month'</span><span class="sql__keyword">from</span><span class="sql__id">ToysSalesDetails</span><span class="sql__keyword">Where</span><span class="sql__keyword">YEAR</span>(<span class="sql__id">SalesDate</span>)=<span class="sql__keyword">YEAR</span>(<span class="sql__id">getdate</span>())&nbsp;
&nbsp;&nbsp;<span class="sql__keyword">Order</span><span class="sql__keyword">by</span><span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">Image_Name</span>,<span class="sql__id">SalesDate</span></pre>
</div>
</div>
</div>
<p>After creating our Table we will create a Stored Procedure get all the data from database to create our Pivot Grid from our MVC application using AngularJS and Web API.</p>
<p><span>Script to create Stored Procedure</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__com">--&nbsp;1)&nbsp;Stored&nbsp;procedure&nbsp;to&nbsp;Select&nbsp;ToysSalesDetails</span>&nbsp;
<span class="sql__com">--&nbsp;Author&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Create&nbsp;date&nbsp;:&nbsp;2015-11-20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Description&nbsp;:&nbsp;Toy&nbsp;Sales&nbsp;Details&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Tables&nbsp;used&nbsp;:&nbsp;&nbsp;ToysSalesDetails&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Modifier&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;Shanu&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;Modify&nbsp;date&nbsp;:&nbsp;2015-11-20&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;</span>&nbsp;
<span class="sql__com">--&nbsp;exec&nbsp;USP_ToySales_Select&nbsp;'',''</span>&nbsp;
<span class="sql__com">--&nbsp;=============================================&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">PROCEDURE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">USP_ToySales_Select</span>]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;(&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Toy_Type</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="sql__string">''</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Toy_Name</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VARCHAR</span>(<span class="sql__number">100</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="sql__string">''</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">AS</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">BEGIN</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">select</span>&nbsp;&nbsp;<span class="sql__id">Toy_Type</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__id">ToyType</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__id">Toy_Name</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__id">ToyName</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__id">Image_Name</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__id">ImageName</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__id">Toy_Price</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__id">Price</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__id">AddedBy</span>&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__string">'User'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,<span class="sql__id">DATENAME</span>(<span class="sql__keyword">month</span>,&nbsp;<span class="sql__id">SalesDate</span>)&nbsp;<span class="sql__keyword">as</span>&nbsp;<span class="sql__string">'Month'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">ToysSalesDetails</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">Where</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_Type</span>&nbsp;<span class="sql__keyword">like</span>&nbsp;&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Toy_Type</span>&nbsp;&#43;<span class="sql__string">'%'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">AND</span>&nbsp;<span class="sql__id">Toy_Name</span>&nbsp;<span class="sql__keyword">like</span>&nbsp;<span class="sql__keyword">@</span><span class="sql__variable">Toy_Name</span>&nbsp;&#43;<span class="sql__string">'%'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">AND</span>&nbsp;<span class="sql__keyword">YEAR</span>(<span class="sql__id">SalesDate</span>)=<span class="sql__keyword">YEAR</span>(<span class="sql__id">getdate</span>())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">ORDER</span>&nbsp;<span class="sql__keyword">BY</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__id">Toy_Type</span>,<span class="sql__id">Toy_Name</span>,<span class="sql__id">SalesDate</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__keyword">END</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:20px; font-weight:bold">Description</span></div>
<p><strong>Create your MVC Web Application in Visual Studio 2015.</strong></p>
<p><span>After installing our Visual Studio 2015 click Start, then Programs and select Visual Studio 2015- Click Visual Studio 2015.</span><span>Click New, then Project, select Web and click ASP.NET Web Application. Select your project location and enter your
 web application name.</span></p>
<p><img id="145078" src="145078-1.png" alt="" width="493" height="254"></p>
<p><span>Select&nbsp;</span><em>MVC&nbsp;</em><span>and in&nbsp;</span><em>Add Folders and Core reference for s</em><span>elect the&nbsp;</span><em>Web API</em><span>&nbsp;and click&nbsp;</span><em>OK</em><span>.</span></p>
<p><img id="145079" src="145079-2.png" alt="" width="589" height="317"></p>
<p><span>&nbsp;</span><strong><span>Add Database using ADO.NET Entity Data Model</span></strong></p>
<p><span>Right click our project and click&nbsp;<em>Add,&nbsp;</em>then&nbsp;<em>New Item</em>.</span></p>
<p><img id="145080" src="145080-3.png" alt="" width="438" height="552"></p>
<p><span>Select&nbsp;</span><em>Data</em><span>, then&nbsp;</span><em>ADO.NET Entity Data Model&nbsp;</em><span>and give the name for our EF and click&nbsp;</span><em>Add</em><span>.</span></p>
<p><img id="145081" src="145081-4.png" alt="" width="495" height="254"></p>
<p><span>Select EF Designer from the database and click&nbsp;</span><em>Next</em></p>
<p><img id="145082" src="145082-5.png" alt="" width="487" height="313"></p>
<p><span>Here click New Connection and provide your SQL Server - Server Name and connect to your database.</span></p>
<p><img id="145083" src="145083-6.png" alt="" width="428" height="373"></p>
<p><span>Here we can see I have given my SQL server name, Id and PWD and after it connected I selected the database as ToysDB as we have created the Database using my SQL Script.</span></p>
<p><img id="145084" src="145084-7.png" alt="" width="490" height="324"></p>
<p><span>Click next and select the tables and all Stored Procedures need to be used and click finish.</span></p>
<p><img id="145085" src="145085-8.png" alt="" width="283" height="181"></p>
<p><span>Here we can see now we have created our&nbsp;</span><em>ToySalesModel</em><span>.</span></p>
<p><img id="145086" src="145086-9.png" alt="" width="314" height="414"></p>
<p><span>Once the Entity has been created the next step is to add a Web API to our controller and write function to Select/Insert/Update and Delete.</span><br>
<br>
<strong>Procedure to add our Web API Controller<br>
</strong><span>Right-click the Controllers folder, click Add and then click Controller.</span></p>
<p><img id="145087" src="145087-10.png" alt="" width="603" height="461"></p>
<p>&nbsp;</p>
<p><span>Select Controller and add an Empty Web API 2 Controller. Provide your name to the Web API controller and click OK. Here for my Web API Controller I have given the name &ldquo;ToyController&rdquo; .In this demo project I have created 2 different controller
 for Order master and order Detail.</span></p>
<p><img id="145088" src="145088-11.png" alt="" width="482" height="315"></p>
<p><span>As we have created Web API controller, we can see our controller has been inherited with ApiController.</span></p>
<p><span>As we all know Web API is a simple and easy way to build HTTP Services for Browsers and Mobiles.<br>
Web API has the following four methods as&nbsp;<strong>Get/Post/Put and Delete</strong>&nbsp;where:</span></p>
<ul type="disc">
<li><strong><span>Get</span></strong><span>&nbsp;is to request for the data. (Select)</span>
</li><li><strong><span>Post</span></strong><span>&nbsp;is to create a data. (Insert)</span>
</li><li><strong><span>Put</span></strong><span>&nbsp;is to update the data.</span> </li><li><strong><span>Delete</span></strong><span>&nbsp;is to delete data.</span> </li></ul>
<p><strong><span>Get Method<br>
</span></strong><span><br>
In our example I have used only a Get method since I am using only a Stored Procedure to get the data and bind to our MVC page using AngularJS.<br>
<strong>Select Operation<br>
</strong>We use a get method to get all the details of the&nbsp;<strong>ToysSalesDetails</strong>&nbsp;table using an entity object and we return the result as an IEnumerable. We use this method in our AngularJs and display the result in an MVC page from the
 AngularJs controller. Using Ng-Repeat we can bind the details.<br>
<br>
Here we can see in the get method I have passed the search parameter to the&nbsp;</span><span>USP_ToySales_Select</span><span>&nbsp;Stored Procedure. In the Stored Procedure I used like &quot;%&quot; to return all the records if the search parameter is empty.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ToyController&nbsp;:&nbsp;ApiController&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ToysDBEntities&nbsp;objAPI&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ToysDBEntities();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;to&nbsp;Search&nbsp;Student&nbsp;Details&nbsp;and&nbsp;display&nbsp;the&nbsp;result&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;USP_ToySales_Select_Result&gt;&nbsp;Get(<span class="cs__keyword">string</span>&nbsp;ToyType,&nbsp;<span class="cs__keyword">string</span>&nbsp;ToyName)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ToyType&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ToyType&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ToyName&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ToyName&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;objAPI.USP_ToySales_Select(ToyType,&nbsp;ToyName).AsEnumerable();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Now we have created our Web API Controller Class. The next step is to create our AngularJs Module and Controller. Let's see how to create our AngularJs Controller. In Visual Studio 2015 it's much easier to add our AngularJs
 Controller. Let's see step-by-step how to create and write our AngularJs Controller.</span><span><br>
<br>
<strong><span>Creating AngularJs Controller</span></strong><br>
<br>
<span>First create a folder inside the Script Folder and I have given the folder name as &ldquo;MyAngular&rdquo;.</span></span></div>
<p><img id="145090" src="145090-13.png" alt="" width="241" height="305"></p>
<p>&nbsp;</p>
<p><span>Now add your Angular Controller inside the folder.</span><span><br>
<br>
<span>Right-click the MyAngular folder and click Add and New Item. Select Web and then AngularJs Controller and provide a name for the Controller. I have named my AngularJs Controller &ldquo;Controller.js&rdquo;.</span></span></p>
<p><img id="145091" src="145091-14.png" alt=""></p>
<p><span>Once the AngularJs Controller is created, we can see by default the controller will have the code with the default module definition and all.&nbsp;</span></p>
<p><img id="145092" src="145092-15.png" alt="" width="360" height="308"></p>
<p><span>I have changed the preceding code like adding a Module and controller as in the following.</span><span><br>
<br>
<span>If the AngularJs package is missing, then add the package to your project.</span><br>
<br>
<span>Right-click your MVC project and click Manage NuGet Packages. Search for AngularJs and click Install.</span></span></p>
<p><img id="145093" src="145093-16.png" alt="" width="493" height="297"></p>
<p><span>Now we can see all the AngularJs packages have been installed and we can see all the files in the Script folder.</span></p>
<p><span><strong><span>Procedure to Create AngularJs Script Files</span></strong><br>
<br>
<strong><span>Modules.js:</span></strong>&nbsp;<span>Here we will add the reference to the AngularJs JavaScript and create an Angular Module named &ldquo;OrderModule&rdquo;.</span></span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;&lt;reference&nbsp;path=&quot;../angular.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;../angular-animate.min.js&quot;&nbsp;/&gt;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;app;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;app&nbsp;=&nbsp;angular.module(<span class="js__string">&quot;OrderModule&quot;</span>,&nbsp;[<span class="js__string">'ngAnimate'</span>]);&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>)();&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Controllers:</span></strong><span>&nbsp;</span><span>In AngularJs Controller I have done all the business logic and returned the data from Web API to our MVC HTML page.</span>
<p><span><strong><span>1. Variable declarations</span></strong><strong><span><br>
</span></strong><br>
<span>First I declared all the local variables that need to be used.</span></span>&nbsp;</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">indow,&nbsp;$http)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.date&nbsp;=&nbsp;<span class="js__operator">new</span><span class="js__object">Date</span>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.MyName&nbsp;=&nbsp;<span class="js__string">&quot;shanu&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;Order&nbsp;Master&nbsp;Search&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ToyType&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ToyName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;1)&nbsp;Item&nbsp;List&nbsp;Arrays.This&nbsp;arrays&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;display&nbsp;.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.itemType&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColNames&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;2)&nbsp;Item&nbsp;List&nbsp;Arrays.This&nbsp;arrays&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;display&nbsp;.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.items&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColMonths&nbsp;=&nbsp;[];&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p>&nbsp;<strong>2. Methods</strong></p>
<p><span><strong>Select Method</strong><strong>&nbsp;</strong><strong><br>
</strong><br>
In the select method I have used&nbsp;<strong>$http.get</strong>&nbsp;to get the details from Web API. In the get method I will provide our API Controller name and method to get the details. Here we can see I have passed the search parameter of&nbsp;</span><span>OrderNO</span><span>&nbsp;and&nbsp;</span><span>TableID</span><span>using:</span></p>
<p><span>&nbsp;</span><span style="color:#0000ff">{&nbsp;params:&nbsp;{&nbsp;ToyType:&nbsp;ToyType,&nbsp;ToyName:&nbsp;ToyName&nbsp;} &nbsp;</span></p>
<p><span>The function will be called during each page load. During the page load I will get all the details and to create our Pivot result first I will store the each Unique Toy name in Array to display the Pivot report by Toy Name as Column and Month Number
 in Array to display the Pivot report by Monthly sum.</span></p>
<p><span>After storing the Unique Values of Toy Name and Month Number I will call the&nbsp;</span><span>$scope.getMonthDetails();</span><span>&nbsp;and<span>$scope.getToyNameDetails();</span>&nbsp;to generate Pivot report and bind the result.</span>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;get&nbsp;all&nbsp;details&nbsp;from&nbsp;Database&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;selectToySalesDetails($scope.ToyType,&nbsp;$scope.ToyName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;get&nbsp;all&nbsp;details&nbsp;from&nbsp;Database&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;selectToySalesDetails(ToyType,&nbsp;ToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$http.get(<span class="js__string">'/api/Toy/'</span>,&nbsp;<span class="js__brace">{</span>&nbsp;params:&nbsp;<span class="js__brace">{</span>&nbsp;ToyType:&nbsp;ToyType,&nbsp;ToyName:&nbsp;ToyName&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>).success(<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ToyDetails&nbsp;=&nbsp;data;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.ToyDetails.length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//alert($scope.ToyDetails.length);&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;uniqueMonth&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,uniqueToyName&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;i;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&nbsp;&#43;=&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Column&nbsp;wise&nbsp;Month&nbsp;add&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uniqueMonth[$scope.ToyDetails[i].Month]&nbsp;=&nbsp;$scope.ToyDetails[i];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//For&nbsp;column&nbsp;wise&nbsp;Toy&nbsp;Name&nbsp;add&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uniqueToyName[$scope.ToyDetails[i].ToyName]&nbsp;=&nbsp;$scope.ToyDetails[i];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Column&nbsp;wise&nbsp;Month&nbsp;add&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;<span class="js__operator">in</span>&nbsp;uniqueMonth)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColMonths.push(uniqueMonth[i]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;For&nbsp;Column&nbsp;wise&nbsp;ToyName&nbsp;add&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;<span class="js__operator">in</span>&nbsp;uniqueToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColNames.push(uniqueToyName[i]);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;disply&nbsp;the&nbsp;&nbsp;Month&nbsp;wise&nbsp;Pivot&nbsp;result&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getMonthDetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;To&nbsp;disply&nbsp;the&nbsp;&nbsp;Month&nbsp;wise&nbsp;Pivot&nbsp;result&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getToyNameDetails();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;.error(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.error&nbsp;=&nbsp;<span class="js__string">&quot;An&nbsp;Error&nbsp;has&nbsp;occured&nbsp;while&nbsp;loading&nbsp;posts!&quot;</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span>&nbsp;</span><span>First I will bind all the Actual data from database. Here we can see all the data from database has been displayed total of nearly 43 records. We will create a Dynamic Pivot report from this actual data.</span></div>
<div class="endscriptcode"><img id="145094" src="https://i1.code.msdn.s-msft.com/dynamic-pivot-grid-using-b7e15f2c/image/file/145094/1/17.png" alt="" width="569" height="461"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span>&nbsp;</span><strong><span>Pivot result to display the Price Sum by Toy Name for each Toy Type</span></strong>
<p><span>In this pivot report .I will display the Toy Type in rows and Toy Name as Columns. In our form Load method we already stored all the Unique Toy Name in Array which will be bind as Column. Now in this method I will add the Unique Toy Type to be displayed
 as rows.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;Display&nbsp;Toy&nbsp;Details&nbsp;as&nbsp;Toy&nbsp;Name&nbsp;Pivot&nbsp;Cols&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.getToyNameDetails&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;UniqueItemName&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>,&nbsp;i&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&nbsp;&#43;=&nbsp;<span class="js__num">1</span>)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UniqueItemName[$scope.ToyDetails[i].ToyType]&nbsp;=&nbsp;$scope.ToyDetails[i];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;<span class="js__operator">in</span>&nbsp;UniqueItemName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ItmDetails&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ToyType:&nbsp;UniqueItemName[i].ToyType&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.itemType.push(ItmDetails);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>Here we can see now I have added all the Unique ToyType ion Arrays which will be bind in our MVC page.</span>
<p><span>Here in Html Table creation we can see that first I will create the Grid Header .In Grid header I display the Toy Type and all other Toy Name as column dynamically using&nbsp;</span><span style="color:#0000ff">data-ng-repeat=&quot;Cols in ColNames | orderBy:'ToyName':false&quot;</span></p>
</div>
<strong><span>HTML Part:</span></strong><span>&nbsp;</span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;tr</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;height:&nbsp;30px;&nbsp;background-color:#336699&nbsp;;&nbsp;color:#FFFFFF&nbsp;;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;20&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;200&quot;</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;</span>ToyType<span class="html__tag_end">&lt;/b&gt;</span><span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span>&nbsp;<span class="html__attr_name">data-ng-repeat</span>=<span class="html__attr_value">&quot;Cols&nbsp;in&nbsp;ColNames&nbsp;|&nbsp;orderBy:'ToyName':false&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#FFFFFF;&nbsp;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;80&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;{</span>{Cols.ToyName}}<span class="html__tag_end">&lt;/b&gt;</span><span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;60&quot;</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_start">&lt;b</span><span class="html__tag_start">&gt;</span>Total<span class="html__tag_end">&lt;/b&gt;</span><span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>After binding the Columns I will bind all the Toy Type as rows and for each Type type and Toy name I will display the summery of price in each appropriate columns</span><span>&nbsp;</span>
<p><strong>&nbsp;</strong></p>
<p><strong><span>HTML Part:</span></strong>&nbsp;</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;tbody</span>&nbsp;<span class="html__attr_name">data-ng-repeat</span>=<span class="html__attr_value">&quot;itm&nbsp;in&nbsp;itemType&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">width</span>=<span class="html__attr_value">&quot;20&quot;</span><span class="html__tag_start">&gt;{</span>{$index&#43;1}}<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;left&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;color:#9F000F&quot;</span>&nbsp;<span class="html__tag_start">&gt;{</span>{itm.ToyType}}<span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;center&quot;</span>&nbsp;<span class="html__attr_name">data-ng-repeat</span>=<span class="html__attr_value">&quot;ColsNew&nbsp;in&nbsp;ColNames&nbsp;|&nbsp;orderBy:'ToyName':false&quot;</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;right&quot;</span>&nbsp;<span class="html__attr_name">style</span>=<span class="html__attr_value">&quot;border:&nbsp;solid&nbsp;1px&nbsp;#659EC7;&nbsp;padding:&nbsp;5px;table-layout:fixed;&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;table</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;tr</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;right&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">ng-bind-html</span>=<span class="html__attr_value">&quot;showToyItemDetails(itm.ToyType,ColsNew.ToyName)&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/table&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;td</span>&nbsp;<span class="html__attr_name">align</span>=<span class="html__attr_value">&quot;right&quot;</span><span class="html__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_start">&lt;span</span>&nbsp;<span class="html__attr_name">ng-bind-html</span>=<span class="html__attr_value">&quot;showToyColumnGrandTotal(itm.ToyType,ColsNew.ToyName)&quot;</span><span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/span&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/td&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tr&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="html__tag_end">&lt;/tbody&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>AngularJS part:</span></strong>
<p><span>From MVC page I will call this method to bind the resultant Summery price in each row after calculation.</span>&nbsp;</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;Display&nbsp;Toy&nbsp;Details&nbsp;as&nbsp;Toy&nbsp;Name&nbsp;wise&nbsp;Pivot&nbsp;Price&nbsp;Sum&nbsp;calculate&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showToyItemDetails&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(colToyType,&nbsp;colToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getItemPrices&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(colToyType&nbsp;==&nbsp;$scope.ToyDetails[i].ToyType)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(colToyName&nbsp;==&nbsp;$scope.ToyDetails[i].ToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getItemPrices&nbsp;=&nbsp;<span class="js__function">parseInt</span>($scope.getItemPrices)&nbsp;&#43;&nbsp;<span class="js__function">parseInt</span>($scope.ToyDetails[i].Price);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__function">parseInt</span>($scope.getItemPrices)&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$sce.trustAsHtml(<span class="js__string">&quot;&lt;font&nbsp;color='red'&gt;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;$scope.getItemPrices.toString().replace(<span class="js__reg_exp">/\B(?=(\d{3})&#43;(?!\d))/g</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;&lt;/font&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$sce.trustAsHtml(<span class="js__string">&quot;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;$scope.getItemPrices.toString().replace(<span class="js__reg_exp">/\B(?=(\d{3})&#43;(?!\d))/g</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="145097" src="https://i1.code.msdn.s-msft.com/dynamic-pivot-grid-using-b7e15f2c/image/file/145097/1/18.png" alt="" width="886" height="190"></div>
<span>&nbsp;</span><strong><span>Column Total:</span></strong>
<p>To display the Column Total at each row end .In this method I will calculate each row result and return the value to bind in MVC page.&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;Display&nbsp;Toy&nbsp;Details&nbsp;as&nbsp;Toy&nbsp;Name&nbsp;wise&nbsp;Pivot&nbsp;Column&nbsp;wise&nbsp;Total&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showToyColumnGrandTotal&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(colToyType,&nbsp;colToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getColumTots&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(colToyType&nbsp;==&nbsp;$scope.ToyDetails[i].ToyType)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getColumTots&nbsp;=&nbsp;<span class="js__function">parseInt</span>($scope.getColumTots)&nbsp;&#43;&nbsp;<span class="js__function">parseInt</span>($scope.ToyDetails[i].Price);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$sce.trustAsHtml(<span class="js__string">&quot;&lt;font&nbsp;color='#203e5a'&gt;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;$scope.getColumTots.toString().replace(<span class="js__reg_exp">/\B(?=(\d{3})&#43;(?!\d))/g</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;&lt;/font&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Row Total:</span></strong>
<p>To display the Row Total at each Column end .In this method I will calculate each Column result and return the value to bind in MVC page.&nbsp;</p>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;Display&nbsp;Toy&nbsp;Details&nbsp;as&nbsp;Month&nbsp;wise&nbsp;Pivot&nbsp;Row&nbsp;wise&nbsp;Total&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showToyRowTotal&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(colToyType,&nbsp;colToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getrowTotals&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(colToyName&nbsp;==&nbsp;$scope.ToyDetails[i].ToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getrowTotals&nbsp;=&nbsp;<span class="js__function">parseInt</span>($scope.getrowTotals)&nbsp;&#43;&nbsp;<span class="js__function">parseInt</span>($scope.ToyDetails[i].Price);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$sce.trustAsHtml(<span class="js__string">&quot;&lt;font&nbsp;color='#203e5a'&gt;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;$scope.getrowTotals.toString().replace(<span class="js__reg_exp">/\B(?=(\d{3})&#43;(?!\d))/g</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;&lt;/font&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Row and Column Grand Total:</span></strong><span>To Calculate both Row and Column Grand Total.</span><span>&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;To&nbsp;Display&nbsp;Toy&nbsp;Details&nbsp;as&nbsp;Month&nbsp;wise&nbsp;Pivot&nbsp;Row&nbsp;&amp;&nbsp;Column&nbsp;Grand&nbsp;Total&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.showToyGrandTotals&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(colToyType,&nbsp;colToyName)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getGrandTotals&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($scope.ToyDetails&nbsp;&amp;&amp;&nbsp;$scope.ToyDetails.length)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;$scope.ToyDetails.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.getGrandTotals&nbsp;=&nbsp;<span class="js__function">parseInt</span>($scope.getGrandTotals)&nbsp;&#43;&nbsp;<span class="js__function">parseInt</span>($scope.ToyDetails[i].Price);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$sce.trustAsHtml(<span class="js__string">&quot;&lt;b&gt;&quot;</span>&nbsp;&#43;&nbsp;$scope.getGrandTotals.toString().replace(<span class="js__reg_exp">/\B(?=(\d{3})&#43;(?!\d))/g</span>,&nbsp;<span class="js__string">&quot;,&quot;</span>)&nbsp;&#43;&nbsp;<span class="js__string">&quot;&lt;/b&gt;&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong><span>Pivot result to display the Price Sum by Monthly for each Toy Name</span></strong>
<p><strong>&nbsp;</strong>The same logic as above has been used to calculate and bind the Pivot report for Monthly Toy Name summery details. Here we can see the final put will be looks like this as in Rows I will bind Toy Type (Toy Category) Toy Name, Toy Image
 as static and all the Month Number in Columns Dynamically. Same like above function I will calculate all the Toy Summery price per Month and display in each row with Row Total, Column Total and Grand Total.</p>
</div>
<img id="145098" src="https://i1.code.msdn.s-msft.com/dynamic-pivot-grid-using-b7e15f2c/image/file/145098/1/19.png" alt="" width="562" height="488"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><strong><span>Search Button Click</span></strong>
<p><span>In the search button click I will call the SearchMethod to bind the result. In Search method I will clear all the array value and rebind all the Pivot Grid with new result.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;name=<span class="js__string">&quot;txtToyType&quot;</span>&nbsp;ng-model=<span class="js__string">&quot;ToyType&quot;</span>&nbsp;value=<span class="js__string">&quot;&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;name=<span class="js__string">&quot;txtToyName&quot;</span>&nbsp;ng-model=<span class="js__string">&quot;ToyName&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;submit&quot;</span>&nbsp;value=<span class="js__string">&quot;Search&quot;</span>&nbsp;style=<span class="js__string">&quot;background-color:#336699;color:#FFFFFF&quot;</span>&nbsp;ng-click=<span class="js__string">&quot;searchToySales()&quot;</span>&nbsp;/&gt;&nbsp;&nbsp;&nbsp;
<span class="js__sl_comment">//Search&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.searchToySales&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;1)&nbsp;Item&nbsp;List&nbsp;Arrays.This&nbsp;arrays&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;display&nbsp;.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.itemType&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColNames&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;2)&nbsp;Item&nbsp;List&nbsp;Arrays.This&nbsp;arrays&nbsp;will&nbsp;be&nbsp;used&nbsp;to&nbsp;display&nbsp;.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.items&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.ColMonths&nbsp;=&nbsp;[];&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;selectToySalesDetails($scope.ToyType,&nbsp;$scope.ToyName);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="145099" src="https://i1.code.msdn.s-msft.com/dynamic-pivot-grid-using-b7e15f2c/image/file/145099/1/20.png" alt="" width="559" height="464"></div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:2em">Source Code Files</span></div>
<ul>
<li><span>shanuAngularMVCPivotGridS.zip</span> </li></ul>
<h1>More Information</h1>
<p><em><span><strong>Note:&nbsp;</strong>Download the Code,Run all the SQL script files.In&nbsp;</span><span>he WebConfig change the connection String with your SQL Server connection .</span></em></p>
