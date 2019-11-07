# How to use jQuery Grid with ASP.NET MVC
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET MVC
- jQuery
- Javascript
- Bootstrap
## Topics
- jQuery
## Updated
- 04/19/2015
## Description

<h1>Introduction</h1>
<p><em><span>This article is going to show how you can easily implement paging, sorting, filtering and CRUD operations with jQuery Grid Plugin in ASP.NET MVC with bootstrap.</span></em></p>
<p><em><span><img id="136634" src="136634-jquerygrid.png" alt="" width="965" height="370"><br>
</span></em></p>
<h1><span>Background</span></h1>
<p><em><span>In the sample project that you can download from this article I'm using&nbsp;</span><a href="http://gijgo.com/" target="_blank">jQuery Grid</a><span>&nbsp;0.4.3 by gijgo.com,&nbsp;</span><a href="http://jquery.com/" target="_blank">jQuery</a><span>&nbsp;2.1.3,&nbsp;</span><a target="_blank">Bootstrap</a><span>&nbsp;3.3.4
 and&nbsp;</span><a href="http://www.asp.net/mvc" target="_blank">AspNet.Mvc</a><span>&nbsp;5.2.3.</span></em></p>
<h1>A Few Words about jQuery Grid by gijgo.com</h1>
<p>Since the other libraries, that are in use are pretty popular compared to the grid plugin, I'm going to give you some info about this plugin.</p>
<ul>
<li>Stylish and Featured Tabular data presentation control. </li><li>JavaScript control for representing and manipulating tabular data on the web.
</li><li>Ajax Enabled. </li><li>Can be integrated with any of the server-side technologies like ASP, JavaServelets, JSP, PHP etc.
</li><li>Very simple to integrate with ASP.NET. </li><li>Support pagination, javascript and server side data sources. </li><li>Support jQuery UI and Bootstrap. </li><li>Free open source tool distributed under MIT License. </li></ul>
<p><span>You can find the documentation about the version of the plugin that is in use in this article at&nbsp;</span><a href="http://gijgo.com/version_0_4/Documentation" target="_blank">http://gijgo.com/version_0_4/Documentation</a><span>.</span></p>
<p><em>&nbsp;</em></p>
<h1>Integrating jQuery Grid with ASP.NET MVC - Step By Step</h1>
<p>&nbsp;</p>
<li>Create new ASP.NET MVC project in visual studio. </li><li>I assume that jquery and bootstrap would be added to your ASP.NET MVC project by default. If they are not added you can find and add them to your project via nuget.
</li><li>Add jQuery Grid by gijgo.com via nuget. You can find more info at&nbsp;<a href="https://www.nuget.org/packages/jQuery.Grid/" target="_blank">https://www.nuget.org/packages/jQuery.Grid/</a>
</li><li>Make sure that you have a reference to jquery.js, bootstrap.css, grid.css and grid.js files in the pages where you are planning to use the jquery grid.
<p>&nbsp;</p>
<p><img id="136632" src="136632-jquerygridreferences.png" alt="" width="601" height="125"></p>
<p><span>In order to use the grid plugin you will need a html table tag for a base element of the grid. I recommend to use the &quot;data-source&quot; attribute of the table as identification for the location of source url on the server side.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title">HTML</div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<div class="preview">
<pre class="html"><span class="html__tag_start">&lt;table</span>&nbsp;<span class="html__attr_name">id</span>=<span class="html__attr_value">&quot;grid&quot;</span>&nbsp;<span class="html__attr_name">data-source</span>=<span class="html__attr_value">&quot;@Url.Action(&quot;</span>GetPlayers&quot;)&quot;<span class="html__tag_start">&gt;</span><span class="html__tag_end">&lt;/table&gt;</span></pre>
</div>
</div>
</div>
<p><span>After that, we have to initialize the table as jquery grid with the fields which we are planning to display in the Grid.</span></p>
<p><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">  grid = $(&quot;#grid&quot;).grid({
    dataKey: &quot;ID&quot;,
    uiLibrary: &quot;bootstrap&quot;,
    columns: [
      { field: &quot;ID&quot;, width: 50, sortable: true },
      { field: &quot;Name&quot;, sortable: true },
      { field: &quot;PlaceOfBirth&quot;, title: &quot;Place Of Birth&quot;, sortable: true },
      { field: &quot;DateOfBirth&quot;, title: &quot;Date Of Birth&quot;, sortable: true },
      { field: &quot;Edit&quot;, title: &quot;&quot;, width: 34, type: &quot;icon&quot;, icon: &quot;glyphicon-pencil&quot;, tooltip: &quot;Edit&quot;, events: { &quot;click&quot;: Edit } },
      { field: &quot;Delete&quot;, title: &quot;&quot;, width: 34, type: &quot;icon&quot;, icon: &quot;glyphicon-remove&quot;, tooltip: &quot;Delete&quot;, events: { &quot;click&quot;: Remove } }
    ],
    pager: { enable: true, limit: 5, sizes: [2, 5, 10, 20] }
  });</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;grid&nbsp;=&nbsp;$(<span class="js__string">&quot;#grid&quot;</span>).grid(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dataKey:&nbsp;<span class="js__string">&quot;ID&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;uiLibrary:&nbsp;<span class="js__string">&quot;bootstrap&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;columns:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;ID&quot;</span>,&nbsp;width:&nbsp;<span class="js__num">50</span>,&nbsp;sortable:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;Name&quot;</span>,&nbsp;sortable:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;PlaceOfBirth&quot;</span>,&nbsp;title:&nbsp;<span class="js__string">&quot;Place&nbsp;Of&nbsp;Birth&quot;</span>,&nbsp;sortable:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;DateOfBirth&quot;</span>,&nbsp;title:&nbsp;<span class="js__string">&quot;Date&nbsp;Of&nbsp;Birth&quot;</span>,&nbsp;sortable:&nbsp;true&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;Edit&quot;</span>,&nbsp;title:&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;width:&nbsp;<span class="js__num">34</span>,&nbsp;type:&nbsp;<span class="js__string">&quot;icon&quot;</span>,&nbsp;icon:&nbsp;<span class="js__string">&quot;glyphicon-pencil&quot;</span>,&nbsp;tooltip:&nbsp;<span class="js__string">&quot;Edit&quot;</span>,&nbsp;events:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;click&quot;</span>:&nbsp;Edit&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;field:&nbsp;<span class="js__string">&quot;Delete&quot;</span>,&nbsp;title:&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;width:&nbsp;<span class="js__num">34</span>,&nbsp;type:&nbsp;<span class="js__string">&quot;icon&quot;</span>,&nbsp;icon:&nbsp;<span class="js__string">&quot;glyphicon-remove&quot;</span>,&nbsp;tooltip:&nbsp;<span class="js__string">&quot;Delete&quot;</span>,&nbsp;events:&nbsp;<span class="js__brace">{</span><span class="js__string">&quot;click&quot;</span>:&nbsp;Remove&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;pager:&nbsp;<span class="js__brace">{</span>&nbsp;enable:&nbsp;true,&nbsp;limit:&nbsp;<span class="js__num">5</span>,&nbsp;sizes:&nbsp;[<span class="js__num">2</span>,&nbsp;<span class="js__num">5</span>,&nbsp;<span class="js__num">10</span>,&nbsp;<span class="js__num">20</span>]&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<p>If you want to be able to sort by particular column you need to set the sortable option of the colum to true. When you do that, the grid plugin is going to send information to the server about the field name that needs to be sorted. In order to configure
 paging you have to use the pager option from where you can control the paging.</p>
<p>In the sample project I use the following code to implement simple CRUD operations over the data inside the grid.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">  function Add() {
    $(&quot;#playerId&quot;).val(&quot;&quot;);
    $(&quot;#name&quot;).val(&quot;&quot;);
    $(&quot;#placeOfBirth&quot;).val(&quot;&quot;);
    $(&quot;#dateOfBirth&quot;).val(&quot;&quot;);
    $(&quot;#playerModal&quot;).modal(&quot;show&quot;);
  }
  function Edit(e) {
    $(&quot;#playerId&quot;).val(e.data.id);
    $(&quot;#name&quot;).val(e.data.record.Name);
    $(&quot;#placeOfBirth&quot;).val(e.data.record.PlaceOfBirth);
    $(&quot;#dateOfBirth&quot;).val(e.data.record.DateOfBirth);
    $(&quot;#playerModal&quot;).modal(&quot;show&quot;);
  }
  function Save() {
    var player = {
      ID: $(&quot;#playerId&quot;).val(),
      Name: $(&quot;#name&quot;).val(),
      PlaceOfBirth: $(&quot;#placeOfBirth&quot;).val(),
      DateOfBirth: $(&quot;#dateOfBirth&quot;).val()
    };
    $.ajax({ url: &quot;Home/Save&quot;, type: &quot;POST&quot;, data: { player: player } })
      .done(function () {
        grid.reload();
        $(&quot;#playerModal&quot;).modal(&quot;hide&quot;);
      })
      .fail(function () {
        alert(&quot;Unable to save.&quot;);
        $(&quot;#playerModal&quot;).modal(&quot;hide&quot;);
      });
  }
  function Remove(e) {
    $.ajax({ url: &quot;Home/Remove&quot;, type: &quot;POST&quot;, data: { id: e.data.id } })
      .done(function () {
        grid.reload();
      })
      .fail(function () {
        alert(&quot;Unable to remove.&quot;);
      });
  }
  function Search() {
    grid.reload({ searchString: $(&quot;#search&quot;).val() });
  }</pre>
<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;Add()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerId&quot;</span>).val(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#name&quot;</span>).val(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#placeOfBirth&quot;</span>).val(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#dateOfBirth&quot;</span>).val(<span class="js__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerModal&quot;</span>).modal(<span class="js__string">&quot;show&quot;</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__operator">function</span>&nbsp;Edit(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerId&quot;</span>).val(e.data.id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#name&quot;</span>).val(e.data.record.Name);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#placeOfBirth&quot;</span>).val(e.data.record.PlaceOfBirth);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#dateOfBirth&quot;</span>).val(e.data.record.DateOfBirth);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerModal&quot;</span>).modal(<span class="js__string">&quot;show&quot;</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__operator">function</span>&nbsp;Save()&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;player&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ID:&nbsp;$(<span class="js__string">&quot;#playerId&quot;</span>).val(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:&nbsp;$(<span class="js__string">&quot;#name&quot;</span>).val(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PlaceOfBirth:&nbsp;$(<span class="js__string">&quot;#placeOfBirth&quot;</span>).val(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DateOfBirth:&nbsp;$(<span class="js__string">&quot;#dateOfBirth&quot;</span>).val()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;url:&nbsp;<span class="js__string">&quot;Home/Save&quot;</span>,&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;data:&nbsp;<span class="js__brace">{</span>&nbsp;player:&nbsp;player&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.done(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grid.reload();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerModal&quot;</span>).modal(<span class="js__string">&quot;hide&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.fail(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unable&nbsp;to&nbsp;save.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">&quot;#playerModal&quot;</span>).modal(<span class="js__string">&quot;hide&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__operator">function</span>&nbsp;Remove(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;url:&nbsp;<span class="js__string">&quot;Home/Remove&quot;</span>,&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;data:&nbsp;<span class="js__brace">{</span>&nbsp;id:&nbsp;e.data.id&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.done(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grid.reload();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.fail(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;alert(<span class="js__string">&quot;Unable&nbsp;to&nbsp;remove.&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__operator">function</span>&nbsp;Search()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;grid.reload(<span class="js__brace">{</span>&nbsp;searchString:&nbsp;$(<span class="js__string">&quot;#search&quot;</span>).val()&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h2>Server Side</h2>
<p>In the Controller we need only 4 method. Index, GetPlayers, Save and Remove.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  [NoCache]
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      return View();
    }

    [HttpGet]
    public JsonResult GetPlayers(int? page, int? limit, string sortBy, string direction, string searchString = null)
    {
      int total;
      var records = new GridModel().GetPlayers(page, limit, sortBy, direction, searchString, out total);
      return Json(new { records, total }, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public JsonResult Save(Player player)
    {
      new GridModel().Save(player);
      return Json(true);
    }

    [HttpPost]
    public JsonResult Remove(int id)
    {
      new GridModel().Remove(id);
      return Json(true);
    }
  }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;[NoCache]&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;HomeController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult&nbsp;GetPlayers(<span class="cs__keyword">int</span>?&nbsp;page,&nbsp;<span class="cs__keyword">int</span>?&nbsp;limit,&nbsp;<span class="cs__keyword">string</span>&nbsp;sortBy,&nbsp;<span class="cs__keyword">string</span>&nbsp;direction,&nbsp;<span class="cs__keyword">string</span>&nbsp;searchString&nbsp;=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;total;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;records&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;GridModel().GetPlayers(page,&nbsp;limit,&nbsp;sortBy,&nbsp;direction,&nbsp;searchString,&nbsp;<span class="cs__keyword">out</span>&nbsp;total);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__keyword">new</span>&nbsp;{&nbsp;records,&nbsp;total&nbsp;},&nbsp;JsonRequestBehavior.AllowGet);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult&nbsp;Save(Player&nbsp;player)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;GridModel().Save(player);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;JsonResult&nbsp;Remove(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;GridModel().Remove(id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Json(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span>Please note that I'm using custom &quot;[NoCache]&quot; attribute for the controller, that is going to resolve some issues with the caching. I recommend the usage of such attribute or similar mechanism for prevention of bugs related to caching.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
  public sealed class NoCacheAttribute : ActionFilterAttribute
  {
    public override void OnResultExecuting(ResultExecutingContext filterContext)
    {
      filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
      filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
      filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
      filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
      filterContext.HttpContext.Response.Cache.SetNoStore();
      base.OnResultExecuting(filterContext);
    }
  }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;[AttributeUsage(AttributeTargets.Class&nbsp;|&nbsp;AttributeTargets.Method)]&nbsp;
&nbsp;&nbsp;public&nbsp;sealed&nbsp;class&nbsp;NoCacheAttribute&nbsp;:&nbsp;ActionFilterAttribute&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;override&nbsp;<span class="js__operator">void</span>&nbsp;OnResultExecuting(ResultExecutingContext&nbsp;filterContext)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-<span class="js__num">1</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterContext.HttpContext.Response.Cache.SetNoStore();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base.OnResultExecuting(filterContext);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">In the data model of this example I use xml as data store in order to simplify the logic in the model. You can customize the date model as you want and replace my implementation with code that is using relational databases like
 MS SQL Server, My Sql or other services that are specific for your project.</div>
<p>I hope that this article is going to be useful for your project.</p>
</li>