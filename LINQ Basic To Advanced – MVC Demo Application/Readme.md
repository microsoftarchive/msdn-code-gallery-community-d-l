# LINQ Basic To Advanced – MVC Demo Application
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- LINQ
- ASP.NET MVC
## Topics
- C#
- LINQ
- ASP.NET MVC
## Updated
- 05/14/2017
## Description

<h3><span id="introduction">Introduction</span></h3>
<p>Here, in this post we are going to a see some&nbsp;<a rel="noopener noreferrer" href="http://sibeeshpassion.com/tag/LINQ" target="_blank">LINQ</a>&nbsp;queries, which covers both basics and advanced. LINQ queries are introduced few years back to offer a
 consistent way for working with data across many datasources and formats. In LINQ queries, you will always work with objects, which makes it simple to write. I hope you would have already written lots of LINQ queries already, if you haven&rsquo;t, I strongly
 reccommend you to read this&nbsp;<a href="https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/concepts/linq/introduction-to-linq-queries" target="_blank">blog&nbsp;</a>where you can find the answer for, why do we need to use LINQ?. Here
 I am going to create a&nbsp;<a href="http://sibeeshpassion.com/category/mvc/">MVC</a>&nbsp;demo application. I hope you will like this. Now let&rsquo;s begin.</p>
<h3><span id="background">Background</span></h3>
<p>Whenever I get a chance to write some server side codes in&nbsp;<a href="http://sibeeshpassion.com/category/csharp/" target="_blank">C#</a>, I always write it using LINQ. And few weeks back, I was assigned to a training programme where my job was to teach
 LINQ, hence this post covers the the queries I have written for the training programme. Hope you will find it useful.</p>
<h3><span id="using-the-code">Using the code</span></h3>
<p>A LINQ query can be written in two ways.</p>
<li>Query Syntax </li><li>Method Chain or Using dot(.) operator
<p>There are so many articles available in the Internet on the topic LINQ, but most of them dont cover the differences of writing the queries in two possible ways, the motive of this article is to write the queries in both ways, so that you can understand the
 differnces.</p>
<p>As I mentioned, we are going to create an MVC application, we need to create it first and then configure the entity. Let&rsquo;s go and do that.</p>
<h4><span id="create-a-database">Create a database</span></h4>
<p>To get started with we need to configure our database first. To do so, either you can download the Wild World Importers from&nbsp;<a href="https://github.com/Microsoft/sql-server-samples/releases/tag/wide-world-importers-v1.0" target="_blank">here</a>&nbsp;or
 you can run the script file included in the downlaod link above.</p>
<p>Once after you created the database, you can create your MVC application and Entity Data Model in it.</p>
<h4><span id="configuring-mvc-application-with-entity-data-model">Configuring MVC application with Entity Data Model</span></h4>
<p>By this time, I hope you would have configured your MVC application with Entity Data Model. Now it is time to create a controller and Entity object.</p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_354008">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using LINQ_B_to_A.Models;
namespace LINQ_B_to_A.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
 
        public MyDataModel DtContext { get; set; } = new MyDataModel();
    }
}</pre>
<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;
using&nbsp;System.Collections.Generic;&nbsp;
using&nbsp;System.Data.Entity;&nbsp;
using&nbsp;System.Linq;&nbsp;
using&nbsp;System.Web;&nbsp;
using&nbsp;System.Web.Mvc;&nbsp;
using&nbsp;System.Windows.Forms;&nbsp;
using&nbsp;LINQ_B_to_A.Models;&nbsp;
namespace&nbsp;LINQ_B_to_A.Controllers&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;Home</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MyDataModel&nbsp;DtContext&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MyDataModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p>Now we can write some LINQ queries as everything is set to get started.</p>
<h4><span id="setting-up-the-index-view-with-possible-actions">Setting up the Index view with possible actions</span></h4>
<p>This is just to call the actions we are going write. Let&rsquo;s see the Index page now.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>
<pre class="hidden">@{
    ViewBag.Title = &quot;Index&quot;;
    Layout = &quot;~/Views/Shared/_Layout.cshtml&quot;;
}
 
&lt;h2&gt;Index&lt;/h2&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;LoadAll&quot;,&quot;Home&quot;)'&quot; value=&quot;Load All - Query Expression&quot;/&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;JoinWithWhere&quot;,&quot;Home&quot;)'&quot; value=&quot;Join With Where&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;LeftJoin&quot;,&quot;Home&quot;)'&quot; value=&quot;Left Join&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;DistinctSample&quot;,&quot;Home&quot;)'&quot; value=&quot;Distinct Sample&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;EqualsSamples&quot;,&quot;Home&quot;)'&quot; value=&quot;Equals Sample&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;NotEqualsSamples&quot;,&quot;Home&quot;)'&quot; value=&quot;Not Equals&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;PagingQueries&quot;,&quot;Home&quot;)'&quot; value=&quot;Paging Queries&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;MathQueries&quot;,&quot;Home&quot;)'&quot; value=&quot;Math Queries&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;StringQueries&quot;,&quot;Home&quot;)'&quot; value=&quot;String Queries&quot; /&gt;
&lt;input type=&quot;button&quot; class=&quot;btn-info&quot; onclick=&quot;location.href='@Url.Action(&quot;SelectMany&quot;,&quot;Home&quot;)'&quot; value=&quot;Select Many&quot; /&gt;</pre>
<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Index&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Layout&nbsp;=&nbsp;<span class="js__string">&quot;~/Views/Shared/_Layout.cshtml&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&lt;h2&gt;Index&lt;/h2&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>LoadAll<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Load&nbsp;All&nbsp;-&nbsp;Query&nbsp;Expression&quot;</span>/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>JoinWithWhere<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Join&nbsp;With&nbsp;Where&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>LeftJoin<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Left&nbsp;Join&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>DistinctSample<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Distinct&nbsp;Sample&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>EqualsSamples<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Equals&nbsp;Sample&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>NotEqualsSamples<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Not&nbsp;Equals&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>PagingQueries<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Paging&nbsp;Queries&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>MathQueries<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Math&nbsp;Queries&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>StringQueries<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;String&nbsp;Queries&quot;</span>&nbsp;/&gt;&nbsp;
&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;class=<span class="js__string">&quot;btn-info&quot;</span>&nbsp;onclick=<span class="js__string">&quot;location.href='@Url.Action(&quot;</span>SelectMany<span class="js__string">&quot;,&quot;</span>Home<span class="js__string">&quot;)'&quot;</span>&nbsp;value=<span class="js__string">&quot;Select&nbsp;Many&quot;</span>&nbsp;/&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_767973">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
</div>
</div>
<div class="wp-caption x_alignnone" id="attachment_12367"><a href="http://sibeeshpassion.com/wp-content/uploads/2017/05/LINQ-Basic-to-Advanced-Index-View-e1494741059608.png"><img class="size-full x_wp-image-12367" src="-linq-basic-to-advanced-index-view-e1494741059608.png" alt="LINQ Basic to Advanced Index View" width="634" height="197"></a>
<p class="wp-caption-text">LINQ Basic to Advanced Index View</p>
</div>
</li>