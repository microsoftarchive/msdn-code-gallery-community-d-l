# Loop Reference handling in Web API
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- ASP.NET Web API
## Updated
- 09/05/2012
## Description

<h2>The Issue</h2>
<p>It's very common to have circular reference in models. For example, the following models shows a bidirection navigation property:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> <span>public</span> <span>class</span> Category </pre>
<pre><span id="lnum2">   2:</span> { </pre>
<pre><span id="lnum3">   3:</span>     <span>public</span> Category() </pre>
<pre><span id="lnum4">   4:</span>     { </pre>
<pre><span id="lnum5">   5:</span>         Products = <span>new</span> Collection&lt;Product&gt;(); </pre>
<pre><span id="lnum6">   6:</span>     } </pre>
<pre><span id="lnum7">   7:</span>     </pre>
<pre><span id="lnum8">   8:</span>     <span>public</span> <span>int</span> Id { get; set; } </pre>
<pre><span id="lnum9">   9:</span>     <span>public</span> <span>string</span> Name { get; set; } </pre>
<pre><span id="lnum10">  10:</span>     <span>public</span> <span>virtual</span> ICollection&lt;Product&gt; Products { get; set; } </pre>
<pre><span id="lnum11">  11:</span> } </pre>
<pre><span id="lnum12">  12:</span>&nbsp; </pre>
<pre><span id="lnum13">  13:</span> <span>public</span> <span>class</span> Product </pre>
<pre><span id="lnum14">  14:</span> { </pre>
<pre><span id="lnum15">  15:</span>     <span>public</span> <span>int</span> Id { get; set; } </pre>
<pre><span id="lnum16">  16:</span>     <span>public</span> <span>string</span> Name { get; set; } </pre>
<pre><span id="lnum17">  17:</span>     <span>public</span> <span>virtual</span> Category Category { get; set; } </pre>
<pre><span id="lnum18">  18:</span> } </pre>
</div>
</div>
<p>When using with Web Api by generating an EF scaffolding api controller, it won't work by default, however. The following error will occur when serializing with json.net serializer:</p>
<pre><code>Self referencing loop detected for property 'Category' with type </code></pre>
<pre><code>'System.Data.Entity.DynamicProxies.Category_A97AC61AD05BA6A886755C779FD3F96E86FE903ED7C9BA9400E79162C11BA719'. </code></pre>
<pre><code>Path '[0].Products[0]' </code></pre>
<p>The error occurs because the serializer doesn't know how to handle cirular reference. (Similar error occurs in xml serializer as well)</p>
<h2>Disable proxy and include reference</h2>
<p>EF proxy doesn't work well with POCO data serialization. There are several&nbsp;<a href="http://blogs.msdn.com/b/adonet/archive/2010/01/05/poco-proxies-part-2-serializing-poco-proxies.aspx">workarounds</a>. For simplicity, we just disable it in the data
 context class:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> <span>public</span> CircularReferenceSampleContext() : <span>base</span>(<span>&quot;name=CircularReferenceSampleContext&quot;</span>) </pre>
<pre><span id="lnum2">   2:</span> { </pre>
<pre><span id="lnum3">   3:</span>     Database.SetInitializer(<span>new</span> CircularReferenceDataInitializer()); </pre>
<pre><span id="lnum4">   4:</span>     <span>this</span>.Configuration.LazyLoadingEnabled = <span>false</span>; </pre>
<pre><span id="lnum5">   5:</span>     <span>this</span>.Configuration.ProxyCreationEnabled = <span>false</span>; </pre>
<pre><span id="lnum6">   6:</span> } </pre>
</div>
</div>
<p>However, after disable proxy, the navigation property won't be lazy loaded. So you have to include the reference when retrieving data from database. Change the scaffolding controller code to:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> <span>public</span> IEnumerable&lt;Product&gt; GetProducts() </pre>
<pre><span id="lnum2">   2:</span> { </pre>
<pre><span id="lnum3">   3:</span>     <span>return</span> db.Products.Include(p =&gt; p.Category).AsEnumerable(); </pre>
<pre><span id="lnum4">   4:</span> } </pre>
</div>
</div>
<p>The include call will include the reference data for all records.</p>
<h2>Fix 1: Ignoring circular reference globally</h2>
<p>json.net serializer supports to ignore circular reference on global setting. A quick fix is to put following code in WebApiConfig.cs file:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; </pre>
</div>
</div>
<p>The simple fix will make serializer to ignore the reference which will cause a loop. However, it has limitations:</p>
<ul>
<li>The data loses the looping reference information </li><li>The fix only applies to JSON.net </li><li>The level of references can't be controlled if there is a deep reference chain
</li></ul>
<h2>Fix 2: Preserving circular reference globally</h2>
<p>This second fix is similar to the first. Just change the code to:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling </pre>
<pre><span id="lnum2">   2:</span>     = Newtonsoft.Json.ReferenceLoopHandling.Serialize; </pre>
<pre><span id="lnum3">   3:</span> config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling </pre>
<pre><span id="lnum4">   4:</span>     = Newtonsoft.Json.PreserveReferencesHandling.Objects; </pre>
</div>
</div>
<p>The data shape will be changed after applying this setting.</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> [{<span>&quot;$id&quot;</span>:<span>&quot;1&quot;</span>,<span>&quot;Category&quot;</span>:{<span>&quot;$id&quot;</span>:<span>&quot;2&quot;</span>,<span>&quot;Products&quot;</span>:[{<span>&quot;$id&quot;</span>:<span>&quot;3&quot;</span>,<span>&quot;Category&quot;</span>:{<span>&quot;$ref&quot;</span>:<span>&quot;2&quot;</span>},<span>&quot;Id&quot;</span>:2,<span>&quot;Name&quot;</span>:<span>&quot;Yogurt&quot;</span>},{<span>&quot;$ref&quot;</span>:<span>&quot;1&quot;</span>}],<span>&quot;Id&quot;</span>:1,<span>&quot;Name&quot;</span>:<span>&quot;Diary&quot;</span>},<span>&quot;Id&quot;</span>:1,<span>&quot;Name&quot;</span>:<span>&quot;Whole Milk&quot;</span>},{<span>&quot;$ref&quot;</span>:<span>&quot;3&quot;</span>}] </pre>
</div>
</div>
<p>The $id and $ref keeps the all the references and makes the object graph level flat, but the client code needs to know the shape change to consume the data and it only applies to JSON.NET serializer as well.</p>
<h2>Fix 3: Ignore and preserve reference attributes</h2>
<p>This fix is decorate attributes on model class to control the serialization behavior on model or property level. To ignore the property:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> <span>public</span> <span>class</span> Category </pre>
<pre><span id="lnum2">   2:</span> { </pre>
<pre><span id="lnum3">   3:</span>     <span>public</span> <span>int</span> Id { get; set; } </pre>
<pre><span id="lnum4">   4:</span>     <span>public</span> <span>string</span> Name { get; set; } </pre>
<pre><span id="lnum5">   5:</span>     </pre>
<pre><span id="lnum6">   6:</span>     [JsonIgnore] </pre>
<pre><span id="lnum7">   7:</span>     [IgnoreDataMember] </pre>
<pre><span id="lnum8">   8:</span>     <span>public</span> <span>virtual</span> ICollection&lt;Product&gt; Products { get; set; } </pre>
<pre><span id="lnum9">   9:</span> } </pre>
</div>
</div>
<p>JsonIgnore is for JSON.NET and IgnoreDataMember is for XmlDCSerializer.&nbsp;<br>
To preserve reference:</p>
<div id="codeSnippetWrapper">
<div id="codeSnippet">
<pre><span id="lnum1">   1:</span> <span>// Fix 3 </span></pre>
<pre><span id="lnum2">   2:</span> [JsonObject(IsReference = <span>true</span>)] </pre>
<pre><span id="lnum3">   3:</span> <span>public</span> <span>class</span> Category </pre>
<pre><span id="lnum4">   4:</span> { </pre>
<pre><span id="lnum5">   5:</span>     <span>public</span> <span>int</span> Id { get; set; } </pre>
<pre><span id="lnum6">   6:</span>     <span>public</span> <span>string</span> Name { get; set; } </pre>
<pre><span id="lnum7">   7:</span>&nbsp; </pre>
<pre><span id="lnum8">   8:</span>     <span>// Fix 3 </span></pre>
<pre><span id="lnum9">   9:</span>     <span>//[JsonIgnore] </span></pre>
<pre><span id="lnum10">  10:</span>     <span>//[IgnoreDataMember] </span></pre>
<pre><span id="lnum11">  11:</span>     <span>public</span> <span>virtual</span> ICollection&lt;Product&gt; Products { get; set; } </pre>
<pre><span id="lnum12">  12:</span> } </pre>
<pre><span id="lnum13">  13:</span>&nbsp; </pre>
<pre><span id="lnum14">  14:</span> [DataContract(IsReference = <span>true</span>)] </pre>
<pre><span id="lnum15">  15:</span> <span>public</span> <span>class</span> Product </pre>
<pre><span id="lnum16">  16:</span> { </pre>
<pre><span id="lnum17">  17:</span>     [Key] </pre>
<pre><span id="lnum18">  18:</span>     <span>public</span> <span>int</span> Id { get; set; } </pre>
<pre><span id="lnum19">  19:</span>&nbsp; </pre>
<pre><span id="lnum20">  20:</span>     [DataMember] </pre>
<pre><span id="lnum21">  21:</span>     <span>public</span> <span>string</span> Name { get; set; } </pre>
<pre><span id="lnum22">  22:</span>&nbsp; </pre>
<pre><span id="lnum23">  23:</span>     [DataMember] </pre>
<pre><span id="lnum24">  24:</span>     <span>public</span> <span>virtual</span> Category Category { get; set; } </pre>
<pre><span id="lnum25">  25:</span> } </pre>
</div>
</div>
<p>[JsonObject(IsReference = true)] is for JSON.NET and [DataContract(IsReference = true)] is for XmlDCSerializer. Note that: after applying DataContract on class, you need to add DataMember to properties that you want to serialize.</p>
<p>The attributes can be applied on both json and xml serializer and gives more controls on model class.</p>
