# Locate Blood Donors using Online Maps
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET MVC
- jQuery
- ASP.NET MVC 4
## Topics
- ASP.NET MVC
- HTML5
## Updated
- 05/02/2019
## Description

<h1>&nbsp;Introduction</h1>
<div><span style="font-size:small">
<div style="text-align:left">
<p><span style="font-size:small">This guide&nbsp;will help you&nbsp;to&nbsp;use Web Mapping (APIs) and link it to the database that supports creating, editing, and listing. Below are&nbsp;the screenshots of the application you&rsquo;ll build. It includes a
 page that displays a list of&nbsp;donors and&nbsp;displaying the donor's data&nbsp;on the Maps.</span></p>
<p><span style="font-size:small"><span style="font-size:small">Note: The complete Map Functionality will be&nbsp;available in my next article. Alternatively you can follow this project &#65279;<a href="http://blooddonors.codeplex.com/">here</a></span></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<h1><span style="font-size:medium">What you'll Build</span></h1>
<p><span style="font-size:small">You can download the full tutorial <a href="http://blooddonors.codeplex.com/">
here</a>.</span></p>
<p><span style="font-size:small"><img src="57484-2.jpg" alt="" width="606" height="471"></span></p>
<p><span style="font-size:small"><span style="font-weight:bold">&nbsp;</span><span style="font-weight:bold"><img src="57431-1.jpg" alt="" width="603" height="453"></span></span></p>
<p><span style="font-size:medium; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The&nbsp;Source code is written in C#, CSHTML and JavaScripts is also used in some pages. Microsoft Bing Mapping AJAX API ver 7.0 is used to provide mapping functionality.&nbsp;The purpose of this project is to&nbsp;demonstrate
 the integration of the MVC4 with the BING Map API. The Partial view is used o reduce the code. The Project is designed in Visual Studio 11, ASP.NET MVC 4 and uses Razor view engine with Microsoft SQL Compact. Microsoft Bing Mapping AJAX API ver 7.0 is used
 to provide mapping functionality.&nbsp;The&nbsp;code-first development workflow is used in the Entity Framework 4.5. The purpose of this project is to&nbsp;create a website for&nbsp;locate a particular blood group donor in your&nbsp;area, the users will be
 able to locate a nearest donors using&nbsp;hand held&nbsp;devices.</span></p>
<h1><span style="font-size:medium">Getting Started</span></h1>
<p><span style="font-size:small">Start by running Visual Web Developer 2011 Express&nbsp;and select
<strong>New Project</strong> from the <strong>Start</strong> page.</span></p>
<p><span style="font-size:medium"><strong>Step- 1 Creating Your First Application</strong></span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong>You can create applications using either Visual Basic or Visual C# as the programming language. Select Visual C# on the left and then select
<strong>ASP.NET MVC&nbsp;4 Web Application</strong>. Name your project &quot;BloodDonors&quot; and then click
<strong>OK</strong>.</span></p>
<p><span style="font-size:small"><img src="57485-3.jpg" alt="" width="603" height="325"></span></p>
<p><span style="font-size:small">In the <strong>New ASP.NET MVC&nbsp;4 Project</strong> dialog box, select
<strong>Internet Application</strong>. and use <strong>Razor</strong> as the default view engine.</span></p>
<p><span style="font-size:small"><img src="57486-4.jpg" alt="" width="603" height="360"></span></p>
<p><span style="font-size:small">It will create the <strong>Controller, Model</strong> and
<strong>View</strong> folder in your project and also some other required files.</span></p>
<p><span style="font-size:medium"><strong>Step -2 Create The Model Class</strong></span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong><em>First We will Create a Donor Class. right Click the Model Folder and Click Add - &gt;New Item.
</em><em>Add MVC4 Controller Class and name it Donor.cs and paste the following code in it.</em></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;

namespace BloodDonors.Models
{
    public class Donor
    {
        [HiddenInput(DisplayValue = false)]
        public int DonorID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public string Title { get; set; }
        public DateTime DateSubmit { get; set; }
        public string Description { get; set; }
        public string ContactPhone { get; set; }
        public string CellPhone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
               public double Latitude { get; set; }
               public double Longitude { get; set; }

        [UIHint(&quot;LocationDetail&quot;)]
        [NotMapped]
        public LocationDetail Location
        {
            get
            {
                return new LocationDetail() { Latitude = this.Latitude, Longitude = this.Longitude, Title = this.Title, Address = this.Address };
            }
            set
            {
                this.Latitude = value.Latitude;
                this.Longitude = value.Longitude;
                this.Title = value.Title;
                this.Address = value.Address;
            }
        }
    }

    public class LocationDetail
    {
        public double Latitude;
        public double Longitude;
        public string Title;
        public string Address;
    }
    }
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel.DataAnnotations;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Mvc;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BloodDonors.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Donor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[HiddenInput(DisplayValue&nbsp;=&nbsp;<span class="cs__keyword">false</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;DonorID&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;LastName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;BloodGroup&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Title&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;DateSubmit&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Description&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ContactPhone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;CellPhone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Country&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;Latitude&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;Longitude&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[UIHint(<span class="cs__string">&quot;LocationDetail&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[NotMapped]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;LocationDetail&nbsp;Location&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;LocationDetail()&nbsp;{&nbsp;Latitude&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Latitude,&nbsp;Longitude&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Longitude,&nbsp;Title&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Title,&nbsp;Address&nbsp;=&nbsp;<span class="cs__keyword">this</span>.Address&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Latitude&nbsp;=&nbsp;<span class="cs__keyword">value</span>.Latitude;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Longitude&nbsp;=&nbsp;<span class="cs__keyword">value</span>.Longitude;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Title&nbsp;=&nbsp;<span class="cs__keyword">value</span>.Title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Address&nbsp;=&nbsp;<span class="cs__keyword">value</span>.Address;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;LocationDetail&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;Latitude;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;Longitude;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Title;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Address;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
Donor.cs</div>
<div class="scriptcode"><span style="font-size:medium"><strong>Step-3 Create DataBase Context Class</strong></span></div>
<div class="scriptcode"><span style="font-size:small">The main class that coordinates Entity Framework functionality for a given data model is the
<em>database context</em> class. You create this class by deriving from the System.Data.Entity.DbContext class. In your code you specify which entities are included in the data model. You can also customize certain Entity Framework behaviour. In the code for
 this project, the class is named <strong>DonorDBContext.cs</strong></span></div>
<div class="scriptcode"><span style="font-size:small"><span style="font-size:small"><em>Create a
<em>DAL</em> folder. In that folder create a new class file named <em>DonorDBContext.cs</em>, and replace the existing code with the following code</em><em>.</em>
</span></span></div>
</div>
<p><span style="font-size:small"><span style="font-size:small"><em>&nbsp;</em></span></span><span style="font-size:small">&nbsp;</span><span style="font-size:small">In the DAL folder, create a new class file name DonorInitializer.cs replace the existing code
 with the following code, which causes a database to be created when needed and loads test data into the new database</span></p>
</span></div>
<div class="endscriptcode">
<div class="endscriptcode" style="text-align:center">
<h1 class="scriptcode" style="text-align:left"><span style="font-size:medium"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Data.Entity;
using BloodDonors.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BloodDonors.Models
{
    public class DonorDBContext : DbContext
    {
        public DbSet&lt;Donor&gt; Donor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove&lt;PluralizingTableNameConvention&gt;();
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;BloodDonors.Models;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity.ModelConfiguration.Conventions;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BloodDonors.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DonorDBContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DbSet&lt;Donor&gt;&nbsp;Donor&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnModelCreating(DbModelBuilder&nbsp;modelBuilder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;modelBuilder.Conventions.Remove&lt;PluralizingTableNameConvention&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</strong></span></h1>
<h1 class="scriptcode" style="text-align:left"><span style="font-size:medium"><strong>Step-4 Initializing the database with test data</strong></span></h1>
<div class="endscriptcode" style="text-align:left">In the DAL Folder, create a new class file name DonorInitializer.cs and replace the existing code with the following code, which causes the database to be created when needed and loads the test data into
 the new database.</div>
<div class="endscriptcode" style="text-align:left">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 
using BloodDonors.Models;

namespace BloodDonors.DAL
{
    public class DonorInitializer : DropCreateDatabaseIfModelChanges&lt;DonorDBContext&gt;
    {
        protected override void Seed(DonorDBContext context)
        {
            var donors = new List&lt;Donor&gt; 
            { 
                new Donor { FirstName = &quot;A&quot;, LastName = &quot;Sara&quot;, Title = &quot;First Donor&quot;, BloodGroup = &quot;A&#43;&quot;, Description = &quot;test description-1&quot;, DateSubmit = DateTime.Parse(&quot;2005-09-01&quot;), ContactPhone =&quot;12122323&quot;, Address = &quot;Address-1&quot;, Country =&quot;USA&quot;  }, 
           
            };
            donors.ForEach(s =&gt; context.Donor.Add(s));
            context.SaveChanges();

        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data.Entity;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;BloodDonors.Models;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;BloodDonors.DAL&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;DonorInitializer&nbsp;:&nbsp;DropCreateDatabaseIfModelChanges&lt;DonorDBContext&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Seed(DonorDBContext&nbsp;context)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;donors&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Donor&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Donor&nbsp;{&nbsp;FirstName&nbsp;=&nbsp;<span class="cs__string">&quot;A&quot;</span>,&nbsp;LastName&nbsp;=&nbsp;<span class="cs__string">&quot;Sara&quot;</span>,&nbsp;Title&nbsp;=&nbsp;<span class="cs__string">&quot;First&nbsp;Donor&quot;</span>,&nbsp;BloodGroup&nbsp;=&nbsp;<span class="cs__string">&quot;A&#43;&quot;</span>,&nbsp;Description&nbsp;=&nbsp;<span class="cs__string">&quot;test&nbsp;description-1&quot;</span>,&nbsp;DateSubmit&nbsp;=&nbsp;DateTime.Parse(<span class="cs__string">&quot;2005-09-01&quot;</span>),&nbsp;ContactPhone&nbsp;=<span class="cs__string">&quot;12122323&quot;</span>,&nbsp;Address&nbsp;=&nbsp;<span class="cs__string">&quot;Address-1&quot;</span>,&nbsp;Country&nbsp;=<span class="cs__string">&quot;USA&quot;</span>&nbsp;&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;donors.ForEach(s&nbsp;=&gt;&nbsp;context.Donor.Add(s));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;context.SaveChanges();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode" style="text-align:left">Make the following changes in the Global.asax.cs file to cause this initializer code to run when the application begins.</div>
<div class="endscriptcode" style="text-align:left">&nbsp;</div>
<div class="endscriptcode" style="text-align:left">Add the following <strong>using statements:</strong></div>
<div class="endscriptcode" style="text-align:left"><strong>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Data.Entity;
using BloodDonors.Models;
using BloodDonors.DAL;</pre>
<div class="preview">
<pre class="css"><span class="css__element">using</span>&nbsp;<span class="css__element">System</span><span class="css__class">.Data</span><span class="css__class">.Entity</span>;&nbsp;
<span class="css__element">using</span>&nbsp;<span class="css__element">BloodDonors</span><span class="css__class">.Models</span>;&nbsp;
<span class="css__element">using</span>&nbsp;<span class="css__element">BloodDonors</span><span class="css__class">.DAL</span>;</pre>
</div>
</div>
</div>
</strong></div>
</div>
</div>
<div class="scriptcode">
<div class="endscriptcode" style="text-align:left">In the Application_Start method, call an Entity Framework method that runs the database initializer code:&nbsp;</div>
<div class="endscriptcode" style="text-align:left">&nbsp;</div>
<div class="endscriptcode" style="text-align:left">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">Database.SetInitializer&lt;DonorDBContext&gt;(new DonorInitializer());</pre>
<div class="preview">
<pre class="css"><span class="css__element">Database</span><span class="css__class">.SetInitializer</span>&lt;<span class="css__element">DonorDBContext</span>&gt;(<span class="css__element">new</span>&nbsp;<span class="css__element">DonorInitializer</span>());</pre>
</div>
</div>
</div>
</div>
</div>
<div class="scriptcode" style="text-align:left">Note: When you deploy an application to a production web server, you must remove this code that seeds the database.</div>
<h1>Step-5&nbsp;Add a Controller<span style="font-size:small"><em>&nbsp;</em></span></h1>
<h1 class="scriptcode">Right-Click the Controller folder and create a new <strong>
DonorsController.</strong></h1>
<p class="scriptcode"><strong><img src="57512-5.jpg" alt="" width="513" height="322"></strong></p>
<p>Click <strong>Add</strong>. Visual Web Developer creates the following files and folders:</p>
<ul>
<li><em>A DonorController.cs</em> file in the project's <em>Controllers</em> folder.
</li><li>A <em>Donors</em> folder in the project's <em>Views</em> folder. </li><li><em>Create.cshtml, Delete.cshtml, Details.cshtml, Edit.cshtml</em>, and <em>Index.cshtml</em> in the new
<em>Views\Donors </em>folder. </li></ul>
<p>Run the application and browse to the Donors controller by appending <em>/Donors</em> to the URL in the address bar of your browser</p>
<p><img src="57511-6.jpg" alt="" width="593" height="419"></p>
<div class="scriptcode"><span style="font-size:small"><em>For more information and complete source code&nbsp;, see
<a href="http://blooddonors.codeplex.com/">http://blooddonors.codeplex.com/</a></em></span></div>
<p>&nbsp;</p>
<div class="scriptcode"><span style="font-size:small">&nbsp;</span></div>
<div class="scriptcode">&nbsp;</div>
<div class="scriptcode">&nbsp;</div>
<p>&nbsp;</p>
<div class="endscriptcode">&nbsp;</div>
