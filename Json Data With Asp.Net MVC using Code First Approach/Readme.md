# Json Data With Asp.Net MVC using Code First Approach
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- JSON
- ASP.NET MVC
- Entity Framework Code First
## Topics
- Performance
## Updated
- 08/14/2016
## Description

<h1>Introduction</h1>
<p><em><span>Today I am going to explain about how to get&nbsp;</span><span>JSON</span><span>&nbsp;data with Asp.Net MVC to make ajax call using jquery. As we know JSON is very light weight as compare to xml or other datasets. So, in this article, I will create
 a blog system as for demo where first you will bind the DropDownList with blog categories and on select on individual category, respective&nbsp;blogs details will be populated. For this demonstration, I have used Code First approach.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p>To create new Asp.Net MVC application, open Visual Studio 2015/2013. Go to&nbsp;<span>File</span>&nbsp;menu and select&nbsp;<span>New</span>&nbsp;and then choose&nbsp;<span>New Project</span>. It will display the following New Project Windows where you can
 choose different types for project. So, from the right panel you need to choose&nbsp;<span>Templates</span>&nbsp;<span>&lt;&nbsp;Visual C#</span>&nbsp;and then select&nbsp;<span>Web</span>.</p>
<p>After that from the left panel, you need to choose&nbsp;<span>Asp.Net Web Application</span>. Give the suitable name for the project as &ldquo;<span>JSONWithAspNetMVCExample</span>&rdquo; and click to&nbsp;<span>OK</span>.</p>
<p><span>After clicking on OK,&nbsp;It will open other windows where can be choose different templates for Asp.Net applications. So, here we need to&nbsp;go with&nbsp;</span><span>MVC</span><span>&nbsp;template and click to&nbsp;</span><span>OK</span><span>.</span></p>
<h5>Create Entity and DataContext Class</h5>
<p>As in this article, we are using two entities to make blog system. So,&nbsp;I am using two entity and these are category and blog. So, basically all the category will display inside the DropDownList&nbsp;and based on DropDownList&nbsp;value selection, blog
 details will be bind with html table using JQuery. So, there are two entities&nbsp;classes required here.</p>
<p><span>Blog.cs</span></p>
<p>Following is blog class where properties are defined.&nbsp;I have used&nbsp;<span>Table&nbsp;</span>attribute with class name and it is because for this it will take same&nbsp;name and&nbsp;a table will be created inside the database when you run the application
 first. Since we are using Code First approach where model or entity creates first and on the basis database and tables are generated.<em>&nbsp;&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JsonWithAspNetMVCExample.Models
{
    [Table(&quot;NextPosts&quot;)]
    public class Blog
    {
        [Key]
        public int PostId { get; set; }

        [MaxLength(500)]
        [Column(TypeName = &quot;varchar&quot;)]
        public string PostTitle { get; set; }

        [MaxLength(1000)]
        [Column(TypeName = &quot;text&quot;)]
        public string ShortPostContent { get; set; }

        [Column(TypeName = &quot;text&quot;)]
        public string FullPostContent { get; set; }

        [MaxLength(255)]
        public string MetaKeywords { get; set; }

        [MaxLength(500)]
        public string MetaDescription { get; set; }
        public DateTime PostAddedDate { get; set; }

        public int CategoryId { get; set; }

        //public virtual int CategoryId { get; set; }
        //[ForeignKey(&quot;CategoryId&quot;)]
        //public virtual Category Categories { get; set; }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel.DataAnnotations.Schema;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.ComponentModel.DataAnnotations;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;JsonWithAspNetMVCExample.Models&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Table(<span class="cs__string">&quot;NextPosts&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Blog&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;PostId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">500</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Column(TypeName&nbsp;=&nbsp;<span class="cs__string">&quot;varchar&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;PostTitle&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">1000</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Column(TypeName&nbsp;=&nbsp;<span class="cs__string">&quot;text&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ShortPostContent&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Column(TypeName&nbsp;=&nbsp;<span class="cs__string">&quot;text&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FullPostContent&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">255</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MetaKeywords&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="cs__number">500</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;MetaDescription&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;PostAddedDate&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;CategoryId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;virtual&nbsp;int&nbsp;CategoryId&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//[ForeignKey(&quot;CategoryId&quot;)]</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//public&nbsp;virtual&nbsp;Category&nbsp;Categories&nbsp;{&nbsp;get;&nbsp;set;&nbsp;}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JsonWithAspNetMVCExample.Models
{
    [Table(&quot;NextCategories&quot;)]
    public class Category
    {
        [Key]
        [Required(ErrorMessage = &quot;Category is required&quot;)]
        public int CategoryId { get; set; }

        [MaxLength(25)]
        public string CategoryName { get; set; }

    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System.ComponentModel.DataAnnotations;&nbsp;
using&nbsp;System.ComponentModel.DataAnnotations.Schema;&nbsp;
&nbsp;
namespace&nbsp;JsonWithAspNetMVCExample.Models&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[Table(<span class="js__string">&quot;NextCategories&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;Category&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Key]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Required(ErrorMessage&nbsp;=&nbsp;<span class="js__string">&quot;Category&nbsp;is&nbsp;required&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;CategoryId&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[MaxLength(<span class="js__num">25</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;CategoryName&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Data.Entity;

namespace JsonWithAspNetMVCExample.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext() : base(&quot;testConnection&quot;)
        {
        }
        public DbSet&lt;Blog&gt; Blogs { get; set; }
        public DbSet&lt;Category&gt; Categories { get; set; }
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System.Data.Entity;&nbsp;
&nbsp;
namespace&nbsp;JsonWithAspNetMVCExample.Models&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;BlogContext&nbsp;:&nbsp;DbContext&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;BlogContext()&nbsp;:&nbsp;base(<span class="js__string">&quot;testConnection&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&lt;Blog&gt;&nbsp;Blogs&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;DbSet&lt;Category&gt;&nbsp;Categories&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><span style="font-size:2em">More Information</span></div>
<p><em>For more information, see full article..</em></p>
<p><em><a title="Dotnet-Tutorial.com" href="http://www.dotnet-tutorial.com/articles/mvc/json-data-with-asp-net-mvc-using-jquery" target="_blank">http://www.dotnet-tutorial.com/articles/mvc/json-data-with-asp-net-mvc-using-jquery</a><br>
</em></p>
