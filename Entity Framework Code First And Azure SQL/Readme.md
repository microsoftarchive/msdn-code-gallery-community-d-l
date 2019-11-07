# Entity Framework Code First And Azure SQL
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Microsoft Azure
- Entity Framework
- Entity Framework Code First
- Azure SQL Database
## Topics
- integration
- IoT
## Updated
- 04/09/2016
## Description

<h1>Introduction</h1>
<p><em>This sample&nbsp;will show how</em><em>&nbsp;we can use Entity Framework Code First to set up an Azure Sql database. This sample is part of my blogpost
<a href="http://blog.eldert.net/?p=1314&preview=true" target="_blank">IoT &ndash; Integration of Things: Entity Framework Code First And Azure SQL</a><strong>&nbsp;</strong><em>&nbsp;</em>.<br>
</em></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>First we will create an empty database in Azure.<br>
<br>
<img id="150678" width="529" height="367" src="150678-azure%20sql%20database.png" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<div></div>
<div>As we will be using Entity Framework Code First we need to install the NuGet package for this library.<strong>&nbsp;</strong><em>&nbsp;<br>
</em><em><br>
</em></div>
<div></div>
<div><img id="150679" src="150679-entity%20framework%20nuget%20package.png" alt="" style="margin-right:auto; margin-left:auto; display:block"></div>
<div></div>
<div></div>
<div><br>
Using code first we define the layout of our tables in our code, so let&rsquo;s add a class in the DataTypes project representing the table which will hold the error and warning data we are going to receive from the Service Bus Queue. Note the data annotations,
 this will specify the schema for our database.<br>
<strong>&nbsp;</strong><em>&nbsp;</em></div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
 
namespace Eldert.IoT.Data.DataTypes
{
    [Table(&quot;ErrorAndWarning&quot;)]
    public class ErrorAndWarning
    {
        // By specifying the name ID, entity framework will know this should be an auto-incrementing PK
        public int ID { get; set; }
 
        [StringLength(50)]
        public string ShipName { get; set; }
 
        public string Message { get; set; }
 
        public DateTime CreatedDateTime { get; set; }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.ComponentModel.DataAnnotations;&nbsp;
using&nbsp;System.ComponentModel.DataAnnotations.Schema;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;Eldert.IoT.Data.DataTypes&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Table(<span class="js__string">&quot;ErrorAndWarning&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ErrorAndWarning&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;By&nbsp;specifying&nbsp;the&nbsp;name&nbsp;ID,&nbsp;entity&nbsp;framework&nbsp;will&nbsp;know&nbsp;this&nbsp;should&nbsp;be&nbsp;an&nbsp;auto-incrementing&nbsp;PK</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;ID&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[StringLength(<span class="js__num">50</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;ShipName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Message&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DateTime&nbsp;CreatedDateTime&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>The next step is to create a class which inherits from the DbContext class, which will be used as the context for communication with our database.<br>
<br>
</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Data.Entity;
 
namespace Eldert.IoT.Data.DataTypes
{
    public class IoTDatabaseContext : DbContext
    {
        public IoTDatabaseContext() : base(&quot;name=IoTDatabaseContext&quot;)
        {
        }
 
        public virtual DbSet&lt;errorandwarning&gt; ErrorAndWarningsEntries { get; set; }
    }
}
</pre>
<div class="preview">
<pre class="js">using&nbsp;System.Data.Entity;&nbsp;
&nbsp;&nbsp;
namespace&nbsp;Eldert.IoT.Data.DataTypes&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;IoTDatabaseContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IoTDatabaseContext()&nbsp;:&nbsp;base(<span class="js__string">&quot;name=IoTDatabaseContext&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;virtual&nbsp;DbSet&lt;errorandwarning&gt;&nbsp;ErrorAndWarningsEntries&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>To be able to communicate with the database in Azure we will have to add a connection string to the App.config. The connection string to be used can be found in the Azure portal in the properties of the database we just created.<br>
<br>
</div>
<div></div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;connectionStrings&gt;
  &lt;add name=&quot;IoTDatabaseContext&quot; connectionString=&quot;Server=tcp:yourserver.database.windows.net,1433;Database=yourdatabase;User ID=yourname@yourserver;Password={your_password_here};Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;&quot; providerName=&quot;System.Data.SqlClient&quot;&gt;
&lt;/connectionStrings&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;IoTDatabaseContext&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Server=tcp:yourserver.database.windows.net,1433;Database=yourdatabase;User&nbsp;ID=yourname@yourserver;Password={your_password_here};Encrypt=True;TrustServerCertificate=False;Connection&nbsp;Timeout=30;&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlClient&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_end">&lt;/connectionStrings&gt;</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>All code we need is now in place, we will now go and enable migrations on our project. Migrations are the way of EF Code First to update our database when we make changes to our code. Open the Package Manage Console in Visual Studio (can be found under
 View, Other Windows), make sure the current project is set as default project, and enter the command
<em>Enable-Migrations</em>.<br>
<br>
</div>
<div></div>
<div></div>
<div><img id="150680" width="748" height="124" src="150680-enable%20migrations.png" alt="" style="margin-right:auto; margin-left:auto; display:block"></div>
<div></div>
<div></div>
<div><br>
After enabling the migrations, we have to create an initial migration which will scaffold the setup of the table we just created. On the Package Manager Console, enter the command
<em>Add-Migration CreateErrorAndWarningTable</em>, and wait for scaffolding to be finished. Once done, you will find a new class in the Migrations folder with the code which will create our database.<strong>&nbsp;</strong><em>&nbsp;</em></div>
<div><em><br>
</em></div>
<div></div>
<div><img id="150681" width="838" height="679" src="150681-add%20migration.png" alt="" style="margin-right:auto; margin-left:auto; display:block"></div>
<div></div>
<div></div>
<div><br>
We now have set up our connection to our database, the first time an application uses this library to access the database the table will be created.<strong>&nbsp;</strong><em>&nbsp;</em></div>
<ul>
</ul>
<h1>More Information</h1>
<p><em><span>This sample is part of a series I have written around integration and IoT</span>, which can be found on my
<a href="http://blog.eldert.net/" target="_blank">blog</a>.<strong>&nbsp;</strong><em>&nbsp;</em></em></p>
