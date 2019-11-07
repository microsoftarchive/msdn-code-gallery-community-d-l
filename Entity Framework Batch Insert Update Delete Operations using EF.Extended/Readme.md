# Entity Framework: Batch Insert Update Delete Operations using EF.Extended
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- SQL Server
- ASP.NET
- .NET
- LINQ
- .NET Framework
- Entity Framework
- Entity Framework Code First
- .NET Development
## Topics
- Performance
- Extensibility
## Updated
- 04/05/2016
## Description

<h1>Introduction</h1>
<p>Entity Framework is a well-known Microsoft open source (from EF 5) data access technology for .NET applications. Entity Framework is a new framework which completely replaces traditional ADO.NET data access techniques. Entity Framework enables new approaches
 to work with relational databases. It will reduce line of code that developers uses for data access. This article will briefly describe how to perform batch CRUD operations using entity framework and its extensions.</p>
<p><span>To implement Bulk operation, we need to add some base classes.</span></p>
<p><span><strong>Customer class</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class Customer   
{  
    [Key]  
    public int Id  
    {  
        get;  
        set;  
    }  
  
    public string Name  
    {  
        get;  
        set;  
    }  
  
    public string Country  
    {  
        get;  
        set;  
    }  
  
    public bool Status  
    {  
        get;  
        set;  
    }  
}  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Customer&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Country&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;Status&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><strong>DataContext</strong></p>
<p><span>I used entityframework 6 for data access.</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DataContext: DbContext  
{  
    public DbSet &lt; Customer &gt; Customers   
    {  
        get;  
        set;  
    }  
}  </pre>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;DataContext:&nbsp;DbContext&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&nbsp;&lt;&nbsp;Customer&nbsp;&gt;&nbsp;Customers&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>GetCustomers method is used to get all customers, which we will use for performing batch Insert operation.</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static List &lt; Customer &gt; GetCustomers()  
{  
    var customers = new List &lt; Customer &gt;  
        {  
        new Customer()  
          {  
            Name = &quot;John&quot;, Country = &quot;IN&quot;, Status = true  
        },  
          
        new Customer()  
        {  
            Name = &quot;Tom&quot;, Country = &quot;USA&quot;, Status = true  
        },  
        new Customer()  
        {  
            Name = &quot;Eric&quot;, Country = &quot;USA&quot;, Status = false  
        },  
        new Customer()   
        {  
            Name = &quot;Sam&quot;, Country = &quot;CHINA&quot;, Status = true  
        },  
        new Customer()  
        {  
            Name = &quot;Rick&quot;, Country = &quot;IN&quot;, Status = false  
        },  
        new Customer()   
        {  
            Name = &quot;Addy&quot;, Country = &quot;IN&quot;, Status = true  
        },  
        new Customer()  
        {  
            Name = &quot;Chang&quot;, Country = &quot;CHINA&quot;, Status = false  
        },  
    };  
  
    return customers;  
}  </pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;List&nbsp;&lt;&nbsp;Customer&nbsp;&gt;&nbsp;GetCustomers()&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;customers&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&nbsp;&lt;&nbsp;Customer&nbsp;&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;John&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;IN&quot;</span>,&nbsp;Status&nbsp;=&nbsp;true&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Tom&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;USA&quot;</span>,&nbsp;Status&nbsp;=&nbsp;true&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Eric&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;USA&quot;</span>,&nbsp;Status&nbsp;=&nbsp;false&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Sam&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;CHINA&quot;</span>,&nbsp;Status&nbsp;=&nbsp;true&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Rick&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;IN&quot;</span>,&nbsp;Status&nbsp;=&nbsp;false&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Addy&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;IN&quot;</span>,&nbsp;Status&nbsp;=&nbsp;true&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Chang&quot;</span>,&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;CHINA&quot;</span>,&nbsp;Status&nbsp;=&nbsp;false&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;customers;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Insert&nbsp;<br>
<br>
</strong><span>After a couple of improvements in Entity Framework that makes adding many rows to a SQL Server Compact database via Entity Framework feasible. AddRange is in built function to perform batch operation.</span></div>
<div class="endscriptcode"><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)   
{  
    using(var db = new DataContext())  
    {  
        // Insert  
        var customers = GetCustomers();  
        db.Customers.AddRange(customers);  
        db.SaveChanges();  
  
        foreach(var customer in db.Customers.ToList())  
        {  
            Console.WriteLine(&quot;CustomerInfo - {0}-{1}-{2}&quot;, customer.Name, customer.Country, customer.Status);  
        }  
    }  
  
    Console.ReadLine();  
} </pre>
<div class="preview">
<pre class="js">static&nbsp;<span class="js__operator">void</span>&nbsp;Main(string[]&nbsp;args)&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using(<span class="js__statement">var</span>&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataContext())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Insert&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;customers&nbsp;=&nbsp;GetCustomers();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Customers.AddRange(customers);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.SaveChanges();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach(<span class="js__statement">var</span>&nbsp;customer&nbsp;<span class="js__operator">in</span>&nbsp;db.Customers.ToList())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;CustomerInfo&nbsp;-&nbsp;{0}-{1}-{2}&quot;</span>,&nbsp;customer.Name,&nbsp;customer.Country,&nbsp;customer.Status);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Output<br>
<br>
</strong><span>It will insert all records on a single database call.</span></div>
<div class="endscriptcode"><span><img id="150458" src="150458-output.jpg" alt="" width="979" height="514"><br>
</span></div>
</span></div>
<p>&nbsp;</p>
<p style="text-align:justify"><strong>Update and Delete</strong><br>
<br>
<span>A current limitation of the Entity Framework is that in order to update or delete an entity you have to first retrieve it into memory. Also, for single deletes, the object must be retrieved before it can be deleted requiring two calls to the database.
 To overcome this problem we have to extend the current entity framework using EntityFramework.Extended. EntityFramework.Extended have useful features like Batch Update and Delete, Audit log, Query Result cache, Future Queries. Batch update and delete eliminates
 the need to retrieve and load an entity before modifying it. Here are a few lines of code to demonstrate how to delete, update.</span></p>
<p style="text-align:justify"><span><strong>Install via nuget<br>
<br>
</strong><span>PM&gt; Install-Package EntityFramework.Extended</span></span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span><span><strong>Update<br>
<br>
Scenario:</strong><span>&nbsp;Update customers which have country USA.&nbsp;</span><br>
<span>If we do this without any extensions, we have to fetch all customers which have country USA, modify the list and update it using loops. Using Entity Framework.Exdended we don&rsquo;t need to fetch the list of customers, simply add where condition, set
 update data and execute query.</span></span></span></p>
<p style="text-align:justify">&nbsp;</p>
<p style="text-align:justify"><span><span><span>&nbsp;</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)  
{  
    using(var db = new DataContext())  
    {  
        db.Customers.Where(c =&gt; c.Country == &quot;USA&quot;).Update(c =&gt; new Customer()  
        {  
            Country = &quot;IN&quot;  
        });  
  
        foreach(var customer in db.Customers.ToList())   
        {  
            Console.WriteLine(&quot;CustomerInfo - {0}-{1}-{2}&quot;, customer.Name, customer.Country, customer.Status);  
        }  
    }  
  
    Console.ReadLine();  
}  </pre>
<div class="preview">
<pre class="js">static&nbsp;<span class="js__operator">void</span>&nbsp;Main(string[]&nbsp;args)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using(<span class="js__statement">var</span>&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataContext())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Customers.Where(c&nbsp;=&gt;&nbsp;c.Country&nbsp;==&nbsp;<span class="js__string">&quot;USA&quot;</span>).Update(c&nbsp;=&gt;&nbsp;<span class="js__operator">new</span>&nbsp;Customer()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Country&nbsp;=&nbsp;<span class="js__string">&quot;IN&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach(<span class="js__statement">var</span>&nbsp;customer&nbsp;<span class="js__operator">in</span>&nbsp;db.Customers.ToList())&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;CustomerInfo&nbsp;-&nbsp;{0}-{1}-{2}&quot;</span>,&nbsp;customer.Name,&nbsp;customer.Country,&nbsp;customer.Status);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Output<br>
<br>
</strong><span>All customers (Tom and Eric) which have country USA will update to IN.</span></div>
<div class="endscriptcode"><span><img id="150459" src="150459-output1.jpg" alt="" width="979" height="514"><br>
</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div><strong>Delete</strong></div>
<div>&nbsp;</div>
<p>&nbsp;</p>
<p><strong>Scenario:</strong><span>&nbsp;Delete customers which have country China. Batch update and delete operation are almost same. Add where condition to both Delete and Update call EntityFramework.Extended function.&nbsp;</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)  
{  
    using(var db = new DataContext())  
    {  
        db.Customers.Where(c =&gt; c.Country == &quot;CHINA&quot;).Delete();  
  
        foreach(var customer in db.Customers.ToList())  
        {  
            Console.WriteLine(&quot;CustomerInfo - {0}-{1}-{2}&quot;, customer.Name, customer.Country, customer.Status);  
        }  
    }  
  
    Console.ReadLine();  
}  </pre>
<div class="preview">
<pre class="js">static&nbsp;<span class="js__operator">void</span>&nbsp;Main(string[]&nbsp;args)&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using(<span class="js__statement">var</span>&nbsp;db&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DataContext())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;db.Customers.Where(c&nbsp;=&gt;&nbsp;c.Country&nbsp;==&nbsp;<span class="js__string">&quot;CHINA&quot;</span>).Delete();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach(<span class="js__statement">var</span>&nbsp;customer&nbsp;<span class="js__operator">in</span>&nbsp;db.Customers.ToList())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="js__string">&quot;CustomerInfo&nbsp;-&nbsp;{0}-{1}-{2}&quot;</span>,&nbsp;customer.Name,&nbsp;customer.Country,&nbsp;customer.Status);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>Output:</strong><span>&nbsp;Two records are deleted having a customer name Chang and Sam.</span></div>
<div class="endscriptcode"><span><img id="150460" src="150460-output2.jpg" alt="" width="979" height="514"><br>
</span></div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Conclusion<br>
</strong><br>
<span>Entity framework is improving day by day. But Entity framework extensions and utilities make developer&rsquo;s life easy. They enhances and optimizes Entity Framework's performance, add more capabilities, add more features and extend current version limitation.
 Hope Microsoft will include Batch insert, update and delete facility in Entity Framework version.</span></p>
<p><strong>More Information</strong></p>
<p>http://www.c-sharpcorner.com/UploadFile/55d96a/entity-framework-batch-insert-update-delete-operations/</p>
<p>http://www.dotnetspan.com</p>
<p><span><br>
</span></p>
