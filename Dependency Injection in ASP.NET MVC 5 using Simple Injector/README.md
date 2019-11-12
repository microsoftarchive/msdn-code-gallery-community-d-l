# Dependency Injection in ASP.NET MVC 5 using Simple Injector
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET MVC 5
- Simple Injector
## Topics
- Dependancy Injection
- Simple Injector
## Updated
- 02/04/2018
## Description

<h1></h1>
<h1>Introduction</h1>
<p>A Visual Studio 2015 project which shows how to use the Dependancy Injection in an ASP.NET&nbsp;MVC 5 web application project, using the simple Injector libarary.</p>
<p>Some Basics on Dependacy Injection and IOC</p>
<p>The Dependency Injection pattern is a particular implementation of Inversion of Control.&nbsp;Inversion of Control (IoC)&nbsp;means that objects do not create other objects on which they rely to do their work. Instead, they get the objects that they need
 from an outside source (for example, an xml configuration file).</p>
<p>Dependency Injection (DI)&nbsp;means that this is done without the object intervention, usually by a framework component that passes constructor parameters and set properties.</p>
<p>The advantages of using Dependency Injection pattern and Inversion of Control are the following:</p>
<ul>
<li>Reduces class coupling </li><li>Increases code reusing </li><li>Improves code maintainability </li><li>Improves application testing </li></ul>
<p>In this Hands-on Lab, I will be doing below high levele steps</p>
<ul>
<li>Integrate ASP.NET MVC 5 with Unity for Dependency Injection using NuGet Packages
</li><li>Use Dependency Injection inside an ASP.NET MVC Controller </li></ul>
<p>You can use the same strategy while implementing the depedency injection on MVC View and MVC Action Filters level as well.</p>
<h1>Building the Sample</h1>
<p><em>Tools requirement</em></p>
<ul>
<li><em>Visual Studio 2015</em> </li><li><em>MVC5</em> </li></ul>
<p><span>Description</span></p>
<h3><em>&nbsp;Step1:&nbsp;</em></h3>
<p>Open Visual Studio and create the MVC 5 web application</p>
<h3>Step2: Install Unity Container.</h3>
<p>Now install <span>Install-Package <strong>SimpleInjector and&nbsp;</strong></span><strong><span class="nn">SimpleInjector.Integration.Web.Mvc
</span></strong>Container using NuGet Package Manager Console.</p>
<p>You can also do online search for <strong>SimpleInjector and&nbsp;<strong><span class="nn">SimpleInjector.Integration.Web.Mvc&nbsp;</span></strong></strong> Container by navigating to Tools=&gt;Extension and Update..=&gt;Online options in Visual Studio
 2015 and install it.</p>
<p>When it will be installed successfully, you will be find the following some references add to your project.</p>
<p><img id="187874" src="187874-s1.jpg" alt="" width="276" height="153"></p>
<h3>Step3: Create a class for registring the depedancy.</h3>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;SimpleInjector;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVCSimpleInjectorDemo.Interfaces;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVCSimpleInjectorDemo.Repository;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SimpleInjector.Integration.Web.Mvc;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCSimpleInjectorDemo.App_Start&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;SimpleInjectorConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">static</span><span class="cs__keyword">void</span>&nbsp;RegisterComponents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Container();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;register&nbsp;all&nbsp;your&nbsp;components&nbsp;with&nbsp;the&nbsp;container&nbsp;here</span><span class="cs__com">//&nbsp;it&nbsp;is&nbsp;NOT&nbsp;necessary&nbsp;to&nbsp;register&nbsp;your&nbsp;controllers</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h3>Step4: Create Service layer, Domain Models and Interfaces and repositories</h3>
<p>Domain Models:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;Product&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;Id&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Name&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;string&nbsp;Category&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;decimal&nbsp;Price&nbsp;<span class="js__brace">{</span>&nbsp;get;&nbsp;set;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Interfaces;</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IProductRepository&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;Product&gt;&nbsp;GetAll();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;Get(int&nbsp;id);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;Add(Product&nbsp;item);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;Update(Product&nbsp;item);&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;Delete(int&nbsp;id);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span>Repository Service:</span></div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;MVCSimpleInjectorDemo.DomainModels;&nbsp;
using&nbsp;MVCSimpleInjectorDemo.Interfaces;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
namespace&nbsp;MVCSimpleInjectorDemo.Repository&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ProductRepository&nbsp;:&nbsp;IProductRepository&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;List&lt;Product&gt;&nbsp;products&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Product&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;int&nbsp;_nextId&nbsp;=&nbsp;<span class="js__num">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ProductRepository()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;Add&nbsp;products&nbsp;for&nbsp;the&nbsp;Demonstration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="js__operator">new</span>&nbsp;Product&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;TV&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="js__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="js__num">100</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="js__operator">new</span>&nbsp;Product&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Computer&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="js__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="js__num">1000</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="js__operator">new</span>&nbsp;Product&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Laptop&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="js__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="js__num">8000</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="js__operator">new</span>&nbsp;Product&nbsp;<span class="js__brace">{</span>&nbsp;Name&nbsp;=&nbsp;<span class="js__string">&quot;Google&nbsp;Pixel&nbsp;2&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="js__string">&quot;Phone&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="js__num">150</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;Product&gt;&nbsp;GetAll()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;get&nbsp;the&nbsp;list&nbsp;of&nbsp;all&nbsp;the&nbsp;records&nbsp;in&nbsp;database</span><span class="js__statement">return</span>&nbsp;products;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Product&nbsp;Get(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;find&nbsp;a&nbsp;record&nbsp;in&nbsp;database</span><span class="js__statement">return</span>&nbsp;products.Find(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Product&nbsp;Add(Product&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(item&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">throw</span><span class="js__operator">new</span>&nbsp;ArgumentNullException(<span class="js__string">&quot;item&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;save&nbsp;record&nbsp;into&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.Id&nbsp;=&nbsp;_nextId&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;item;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;bool&nbsp;Update(Product&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(item&nbsp;==&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">throw</span><span class="js__operator">new</span>&nbsp;ArgumentNullException(<span class="js__string">&quot;item&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__sl_comment">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;update&nbsp;record&nbsp;into&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;index&nbsp;=&nbsp;products.FindIndex(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;item.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(index&nbsp;==&nbsp;-<span class="js__num">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.RemoveAt(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;bool&nbsp;Delete(int&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;remove&nbsp;the&nbsp;records&nbsp;from&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.RemoveAll(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>Step 5- Register the Dependency in SimpleInjectorConfig.cs file</h2>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;SimpleInjector;&nbsp;
using&nbsp;MVCSimpleInjectorDemo.Interfaces;&nbsp;
using&nbsp;MVCSimpleInjectorDemo.Repository;&nbsp;
using&nbsp;SimpleInjector.Integration.Web.Mvc;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
namespace&nbsp;MVCSimpleInjectorDemo.App_Start&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;SimpleInjectorConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;RegisterComponents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Container();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;register&nbsp;all&nbsp;your&nbsp;components&nbsp;with&nbsp;the&nbsp;container&nbsp;here</span><span class="js__sl_comment">//&nbsp;it&nbsp;is&nbsp;NOT&nbsp;necessary&nbsp;to&nbsp;register&nbsp;your&nbsp;controllers.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container.Register&lt;IProductRepository,&nbsp;ProductRepository&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//DependencyResolver.SetResolver(new&nbsp;UnityDependencyResolver(container));</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container.Verify();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyResolver.SetResolver(<span class="js__operator">new</span>&nbsp;SimpleInjectorDependencyResolver(container));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h3>Step6: Create Product Controller and View&nbsp;</h3>
<h3>Step7: Inject Service to Controller</h3>
<p><span>Now inject the dependency for the IProductRepository interface using the Product Controller's constructor as shown below</span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;public&nbsp;class&nbsp;ProductController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;readonly&nbsp;IProductRepository&nbsp;repository;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>&nbsp;<span class="js__sl_comment">//inject&nbsp;dependency</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ProductController(IProductRepository&nbsp;repository)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.repository&nbsp;=&nbsp;repository;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></strong><span class="js__sl_comment">//&nbsp;GET:&nbsp;Product</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;data&nbsp;=&nbsp;repository.GetAll();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View(data);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h3>Step8:&nbsp;Setup Dependency Injection with Simple injector settings in Global.asax.cs</h3>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;protected&nbsp;<span class="js__operator">void</span>&nbsp;Application_Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AreaRegistration.RegisterAllAreas();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>SimpleInjectorConfig.RegisterComponents();&nbsp;</strong>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouteConfig.RegisterRoutes(RouteTable.Routes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BundleConfig.RegisterBundles(BundleTable.Bundles);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><span>Thats all. Run the application and see how the application works.&nbsp;</span></p>
<h1><span>Running the Sample.</span></h1>
<p><span><img id="187875" src="187875-1.jpg" alt="" width="1198" height="461"></span></p>
<p>&nbsp;</p>
<p><span><img id="187876" src="187876-2.jpg" alt="" width="683" height="461"><br>
</span></p>
<p>&nbsp;</p>
<p>To learn more on Simple Injector, please go through below link.</p>
<p>http://simpleinjector.readthedocs.io/en/latest/</p>
