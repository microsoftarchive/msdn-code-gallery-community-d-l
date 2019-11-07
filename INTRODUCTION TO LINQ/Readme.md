# INTRODUCTION TO LINQ
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- ADO.NET
- Windows Forms
- WPF
- Microsoft Azure
- XAML
- ASP.NET MVC
- .NET Framework
- C# Language
- .NET Development
## Topics
- C#
- ASP.NET
- User Interface
- Microsoft Azure
- Data Access
- XAML
- ASP.NET MVC
- Web Services
- GridView
- MVVM
- C# Language Features
- Windows web services
## Updated
- 12/24/2016
## Description

<h1>Introduction</h1>
<p><strong>In this article, we will see</strong></p>
<ul>
<li>What is LINQ </li><li>Benefits of using LINQ </li><li>LINQ Architecture </li><li>LINQ Providers </li></ul>
<p><strong>What is LINQ?</strong></p>
<p>LINQ stands for Language Integrated Query. LINQ enables us to query any type of data store(SQL Server documents, objects in memory etc.)</p>
<p><br>
LINQ enables us to work with different data sources using similar type of code style like SQL Database, XML Documents, In-memory objects. Another benefit of using LINQ<strong><em> is that it provides intellisense and compile time error checking .</em></strong></p>
<p>&nbsp;</p>
<p><strong>For example:</strong> We are developing a Dot NET Application and this application requires to fetch data from different data sources like Databases, XML and in memory objects like list of customers, lists of orders, list of sales and so on. For
 a developer, who is working on Dot NET Application in order to fetch data from different data sources in order he has to understand the technology and syntax of these different data sources. In order to fetch data from SQL he needs to understand ADO.NET and
 T-SQL that is specific to SQL Database. Similarly, for XML Documents the developer needs to understand XPATH and XSLT syntax. Also, to fetch data from In memory objects developer needs to understand the arrays and generics syntax and code.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden"> protected void Page_Load(object sender, EventArgs e)
        {
            SampleDataContext dataContext = new SampleDataContext();
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //gvData.DataSource = from student in dataContext.Students
            //                    where student.Gender ==&quot;Male&quot;
            //                    select student;
            gvData.DataSource = from number in numbers
                                where (number % 2) == 0
                                select number;
            gvData.DataBind();
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SampleDataContext&nbsp;dataContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SampleDataContext();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>[]&nbsp;numbers&nbsp;=&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">3</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">6</span>,&nbsp;<span class="cs__number">7</span>,&nbsp;<span class="cs__number">8</span>,&nbsp;<span class="cs__number">9</span>,&nbsp;<span class="cs__number">10</span>&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//gvData.DataSource&nbsp;=&nbsp;from&nbsp;student&nbsp;in&nbsp;dataContext.Students</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;student.Gender&nbsp;==&quot;Male&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;student;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvData.DataSource&nbsp;=&nbsp;from&nbsp;number&nbsp;<span class="cs__keyword">in</span>&nbsp;numbers&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;where&nbsp;(number&nbsp;%&nbsp;<span class="cs__number">2</span>)&nbsp;==&nbsp;<span class="cs__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;select&nbsp;number;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gvData.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1>For complete reference of this article :</h1>
<p><strong>http://www.c-sharpcorner.com/members/akshay-phadke</strong></p>
