# Dependency Injection in ASP.NET MVC 5 using Unity IoC Container.
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Unity
- MVC5
## Topics
- Unity
- Dependency Injection
- Unity IoC Container
## Updated
- 01/19/2018
## Description

<h1></h1>
<p>Introduction</p>
<p><span>A Visual Studio 2015 project which shows how to use the Dependancy Injection in an ASP.NET&nbsp;MVC 5 web application project, using the Unity IOC container.</span></p>
<p><span>Some Basics on Dependacy Injection and IOC</span></p>
<p>The Dependency Injection pattern is a particular implementation of Inversion of Control.&nbsp;<span>Inversion of Control (IoC)</span>&nbsp;means that objects do not create other objects on which they rely to do their work. Instead, they get the objects that
 they need from an outside source (for example, an xml configuration file).</p>
<p><span>Dependency Injection (DI)</span>&nbsp;means that this is done without the object intervention, usually by a framework component that passes constructor parameters and set properties.</p>
<p>The advantages of using Dependency Injection pattern and Inversion of Control are the following:</p>
<ul>
<li>Reduces class coupling </li><li>Increases code reusing </li><li>Improves code maintainability </li><li>Improves application testing </li></ul>
<p>In this Hands-on Lab, I will be doing below high levele steps</p>
<ul>
<li>Integrate ASP.NET MVC 5 with Unity for Dependency Injection using NuGet Packages
</li><li>Use Dependency Injection inside an ASP.NET MVC Controller </li></ul>
<p>You can use the same strategy while implementing the depedency injection on MVC View and MVC Action Filters level as well.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em>Tools requirement</em></p>
<ul>
<li><em>Visual Studio 2015</em> </li><li><em>MVC5</em> </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<h3><em>&nbsp;Step1:&nbsp;</em></h3>
<p>Open Visual Studio and create the MVC 5 web application</p>
<h3>Step2: Install Unity Container.</h3>
<p><span>Now install Unity.Mvc5 Container using NuGet Package Manager Console tool as shown below:</span></p>
<p><span><img id="186308" src="186308-nuget%20install.jpg" alt="" width="660" height="299"><br>
</span></p>
<p><span>You can also do online search for Unity.Mvc5 Container by navigating to Tools=&gt;Extension and Update..=&gt;Online options in Visual Studio 2015 and install it.</span></p>
<p><span><span>When it will be installed successfully, you will be find the following some references add to your project and a UnityConfig.cs class file at project level, as shown below:</span></span></p>
<p><span><span><img id="186310" src="186310-references.jpg" alt="" width="270" height="294"><br>
</span></span></p>
<h3 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Unity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Unity.Mvc5;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UnityConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterComponents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;register&nbsp;all&nbsp;your&nbsp;components&nbsp;with&nbsp;the&nbsp;container&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;it&nbsp;is&nbsp;NOT&nbsp;necessary&nbsp;to&nbsp;register&nbsp;your&nbsp;controllers</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;e.g.&nbsp;container.RegisterType&lt;ITestService,&nbsp;TestService&gt;();</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyResolver.SetResolver(<span class="cs__keyword">new</span>&nbsp;UnityDependencyResolver(container));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</h3>
<h3>&nbsp;Step3: Create Service layer, Domain Models and Interfaces and repositories</h3>
<p>Domain Model</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Product&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;Id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Category&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">decimal</span>&nbsp;Price&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Interfaces</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.DomainModels;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo.Interfaces&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IProductRepository&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;Product&gt;&nbsp;GetAll();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Product&nbsp;Add(Product&nbsp;item);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;Update(Product&nbsp;item);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Repository Service:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.DomainModels;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.Interfaces;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo.Repository&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;ProductRepository&nbsp;:&nbsp;IProductRepository&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;List&lt;Product&gt;&nbsp;products&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Product&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">int</span>&nbsp;_nextId&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ProductRepository()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;products&nbsp;for&nbsp;the&nbsp;Demonstration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="cs__keyword">new</span>&nbsp;Product&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;TV&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="cs__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="cs__number">100</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="cs__keyword">new</span>&nbsp;Product&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Computer&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="cs__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="cs__number">1000</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="cs__keyword">new</span>&nbsp;Product&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Laptop&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="cs__string">&quot;Electronics&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="cs__number">8000</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Add(<span class="cs__keyword">new</span>&nbsp;Product&nbsp;{&nbsp;Name&nbsp;=&nbsp;<span class="cs__string">&quot;Google&nbsp;Pixel&nbsp;2&quot;</span>,&nbsp;Category&nbsp;=&nbsp;<span class="cs__string">&quot;Phone&quot;</span>,&nbsp;Price&nbsp;=&nbsp;<span class="cs__number">150</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;IEnumerable&lt;Product&gt;&nbsp;GetAll()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;get&nbsp;the&nbsp;list&nbsp;of&nbsp;all&nbsp;the&nbsp;records&nbsp;in&nbsp;database</span><span class="cs__keyword">return</span>&nbsp;products;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Product&nbsp;Get(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;find&nbsp;a&nbsp;record&nbsp;in&nbsp;database</span><span class="cs__keyword">return</span>&nbsp;products.Find(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Product&nbsp;Add(Product&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span><span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;item&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;save&nbsp;record&nbsp;into&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;item.Id&nbsp;=&nbsp;_nextId&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;item;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;Update(Product&nbsp;item)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(item&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span><span class="cs__keyword">new</span>&nbsp;ArgumentNullException(<span class="cs__string">&quot;item&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;update&nbsp;record&nbsp;into&nbsp;database</span><span class="cs__keyword">int</span>&nbsp;index&nbsp;=&nbsp;products.FindIndex(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;item.Id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(index&nbsp;==&nbsp;-<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">false</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.RemoveAt(index);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.Add(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">bool</span>&nbsp;Delete(<span class="cs__keyword">int</span>&nbsp;id)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TO&nbsp;DO&nbsp;:&nbsp;Code&nbsp;to&nbsp;remove&nbsp;the&nbsp;records&nbsp;from&nbsp;database</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;products.RemoveAll(p&nbsp;=&gt;&nbsp;p.Id&nbsp;==&nbsp;id);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span><span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h2>Step 4- Register the Dependency in UnityConfig.cs file</h2>
<h3>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.Interfaces;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.Repository;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Unity;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Unity.Mvc5;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UnityConfig&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;RegisterComponents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;container&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UnityContainer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;register&nbsp;all&nbsp;your&nbsp;components&nbsp;with&nbsp;the&nbsp;container&nbsp;here</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;it&nbsp;is&nbsp;NOT&nbsp;necessary&nbsp;to&nbsp;register&nbsp;your&nbsp;controllers</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;e.g.&nbsp;container.RegisterType&lt;ITestService,&nbsp;TestService&gt;();</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>container.RegisterType&lt;IProductRepository,&nbsp;ProductRepository&gt;();&nbsp;
</strong>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DependencyResolver.SetResolver(<span class="cs__keyword">new</span>&nbsp;UnityDependencyResolver(container));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</h3>
<h3>&nbsp;Step5: Create Product Controller and View&nbsp;</h3>
<h3>&nbsp;Step6: Inject Service to Controller</h3>
<p><span>Now inject the dependency for the IProductRepository interface using the Product Controller's constructor as shown below</span></p>
<h3><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.DomainModels;&nbsp;
<span class="cs__keyword">using</span>&nbsp;MVCUnityIOCDemo.Interfaces;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo.Controllers&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span><span class="cs__keyword">class</span>&nbsp;ProductController&nbsp;:&nbsp;Controller&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span><span class="cs__keyword">readonly</span>&nbsp;IProductRepository&nbsp;repository;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//inject&nbsp;dependency</span><span class="cs__keyword">public</span>&nbsp;ProductController(IProductRepository&nbsp;repository)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.repository&nbsp;=&nbsp;repository;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
}</pre>
</div>
</div>
</div>
&nbsp;Step7:&nbsp;</span>Setup Dependency Injection with Unity in Global.asax.cs</h3>
<p><span><span>Now, setup the UnityConfig class with in the Application_Start method so that it can initialize all dependencies. This will be done by calling RegisterComponents() method of the UnityConfig&nbsp;class as shown below:</span></span></p>
<p><span><span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Mvc.aspx" target="_blank" title="Auto generated link to System.Web.Mvc">System.Web.Mvc</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Optimization.aspx" target="_blank" title="Auto generated link to System.Web.Optimization">System.Web.Optimization</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Routing.aspx" target="_blank" title="Auto generated link to System.Web.Routing">System.Web.Routing</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;MVCUnityIOCDemo&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MvcApplication&nbsp;:&nbsp;System.Web.HttpApplication&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AreaRegistration.RegisterAllAreas();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style="font-size:medium"><strong>UnityConfig.RegisterComponents();</strong></span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RouteConfig.RegisterRoutes(RouteTable.Routes);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BundleConfig.RegisterBundles(BundleTable.Bundles);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Thats all. Run the application and see how the application works.&nbsp;</div>
<br>
</span></span>
<p></p>
<h1></h1>
<h1><span>Running the sample</span></h1>
<p><span><img id="186314" src="186314-1.jpg" alt="" width="1198" height="461"></span></p>
<p>&nbsp;</p>
<p><span><img id="186315" src="186315-2.jpg" alt="" width="683" height="461"><br>
</span></p>
