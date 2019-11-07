# Dependency Injection Before ASP.NET Core
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Console Application
- ASP.NET Web API
## Topics
- ASP.NET
- Console Applications
- Dependancy Injection
## Updated
- 08/04/2017
## Description

<h1>Introduction</h1>
<p>Wikipedia says: &quot;Dependency injection is a software design pattern in which one or more dependencies (or services) are injected, or passed by reference, into a dependent object (or client) and are made part of the client's state. The pattern separates the
 creation of a client's dependencies from its own behavior, which allows program designs to be loosely coupled and to follow the dependency inversion and single responsibility principles. It directly contrasts the service locator pattern, which allows clients
 to know about the system they use to find dependencies.&quot;.</p>
<p>So, from Wikipedia definition, we resume that Dependency Injection (DI) is a technique used to loose coupling between objects or dependencies.It is a sub-approach forming part of the global concepts of inversion of control. Its principle is such that a subroutine
 must express the dependencies it needs to function. The IoC container is then used to instantiate the subroutine; Taking into account these dependencies. The injection of dependencies can take several forms: via a constructor, via a</p>
<p>property, via a private field, and so on. This depends on the library used and the conceptual choices used in the project.</p>
<p>This technique is used always when we would like to manage dependencies and to develop a modular and well-structured application.</p>
<h1><span style="font-size:1.17em">Dependency Injection in MVC&nbsp;</span></h1>
<p>It is possible to easily transpose the principle of injection of dependencies in the following way. The controller here expresses its dependencies via its constructor.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public class DIController : Controller
{
    private readonly IDependencyInjectionService _dependencyInjectionService;

    public MyController(IDependencyInjectionService dependencyInjectionService)
    {
        _dependencyInjectionService = dependencyInjectionService;
    }

}

//And in the main class 
static void Main(string[] args)
{
    var unityContainer = new UnityContainer();

    unityContainer.RegisterType&lt;IDependencyInjectionService , DependencyInjectionService&gt;();

    var instance = unityContainer.Resolve&lt;DIController&gt;();}</pre>
<div class="preview">
<pre id="codePreview">public class DIController : Controller
{
    private readonly IDependencyInjectionService _dependencyInjectionService;

    public MyController(IDependencyInjectionService dependencyInjectionService)
    {
        _dependencyInjectionService = dependencyInjectionService;
    }

}

//And in the main class 
static void Main(string[] args)
{
    var unityContainer = new UnityContainer();

    unityContainer.RegisterType&lt;IDependencyInjectionService , DependencyInjectionService&gt;();

    var instance = unityContainer.Resolve&lt;DIController&gt;();}</pre>
</div>
</div>
</div>
<h1>Before ASP.NET Core</h1>
<p>The previous example is a bit special. Indeed, if you run it as is, at runtime, the program does not work.</p>
<p>Indeed, the default behavior of the controller factory is to expect that the default constructor (without arguments) is present on the controllers to be instantiated. The factory uses the Activator class of the.NET Framework and its CreateInstance method.</p>
<p>With ASP.NET MVC 4 and 5, the solution usually consists of replacing the dependency resolution mechanism of the library (the DependencyResolver class) with an implementation connected to the IoC container.</p>
<p>With ASP.NET Web API 1 and 2, it is also necessary to replace a service in the library with an implementation plugged into the IoC container. However, the differences in internal operation between the two libraries mean that the service to be replaced is
 not exactly the same.</p>
<p>Using a library such as Unity, it is possible to retrieve a NuGet package adapted to ASP.NET MVC which automatically downloads the Bootstrapper class below. Notice the call to the SetResolver method of the DependencyResolver class. It is this call that makes
 it possible to replace the mechanism of resolution and instantiation of the services for all the ASP.NET MVC part of an application. Let's start with an example:</p>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static class UnityConfig
{
  public static IUnityContainer Initialise()
  {
    var container = BuildUnityContainer();

    DependencyResolver.SetResolver(new UnityDependencyResolver(container));

    return container;
  }

  private static IUnityContainer BuildUnityContainer()
  {
    var container = new UnityContainer();

    RegisterTypes(container);

    return container;
  }

  public static void RegisterTypes(IUnityContainer container)
  {
      container.RegisterType&lt;IDependencyInjectionService , DependencyInjectionService&gt;();
  }
}</pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;class&nbsp;UnityConfig&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;public&nbsp;static&nbsp;IUnityContainer&nbsp;Initialise()&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;BuildUnityContainer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DependencyResolver.SetResolver(<span class="js__operator">new</span>&nbsp;UnityDependencyResolver(container));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;container;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;private&nbsp;static&nbsp;IUnityContainer&nbsp;BuildUnityContainer()&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;UnityContainer();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RegisterTypes(container);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;container;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;RegisterTypes(IUnityContainer&nbsp;container)&nbsp;
&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;IDependencyInjectionService&nbsp;,&nbsp;DependencyInjectionService&gt;();&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
</h1>
<p>The instance passed to SetResolver must simply implement an IDependencyResolver interface, which is present in the System.Web.Mvc namespace.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IDependencyResolver
{
    object GetService(Type serviceType);
    IEnumerable&lt;object&gt; GetServices(Type serviceType);
}
</pre>
<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IDependencyResolver&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;object&nbsp;GetService(Type&nbsp;serviceType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;object&gt;&nbsp;GetServices(Type&nbsp;serviceType);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><em>ref :&nbsp;</em><a rel="nofollow noopener" href="http://%20https//msdn.microsoft.com/en-us/library/system.web.mvc.idependencyresolver(v=vs.118).aspx" target="_blank"><em>https://msdn.microsoft.com/en-us/library/system.web.mvc.idependencyresolver(v=vs.118).aspx</em></a></p>
<p>&nbsp;</p>
<p>And it is at this level that the simple implementation by default and using the Activator class is defined. It is this class that we replace when we use the SetResolver method.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private class DefaultDependencyResolver : IDependencyResolver
{
    public object GetService(Type serviceType)
    {
        if (serviceType.IsInterface || serviceType.IsAbstract)
        {
            return null;
        }
        try
        {
            return Activator.CreateInstance(serviceType);
        }
        catch
        {
            return null;
        }
    }

    public IEnumerable&lt;object&gt; GetServices(Type serviceType)
    {
        return Enumerable.Empty&lt;object&gt;();
    }
}</pre>
<div class="preview">
<pre class="js">private&nbsp;class&nbsp;DefaultDependencyResolver&nbsp;:&nbsp;IDependencyResolver&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;object&nbsp;GetService(Type&nbsp;serviceType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(serviceType.IsInterface&nbsp;||&nbsp;serviceType.IsAbstract)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">try</span><span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;Activator.CreateInstance(serviceType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">catch</span><span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;IEnumerable&lt;object&gt;&nbsp;GetServices(Type&nbsp;serviceType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">return</span>&nbsp;Enumerable.Empty&lt;object&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>With ASP.NET Web API 2, implementation requires the creation of a class that meets the IDependencyResolver contract. The name space of the latter is System.Web.Http.Dependencies.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public interface IDependencyResolver : IDependencyScope, IDisposable
{
    IDependencyScope BeginScope();
}

public interface IDependencyScope : IDisposable
{
    object GetService(Type serviceType);
    IEnumerable&lt;object&gt; GetServices(Type serviceType);
}</pre>
<div class="preview">
<pre class="js">public&nbsp;interface&nbsp;IDependencyResolver&nbsp;:&nbsp;IDependencyScope,&nbsp;IDisposable&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IDependencyScope&nbsp;BeginScope();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
public&nbsp;interface&nbsp;IDependencyScope&nbsp;:&nbsp;IDisposable&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;object&nbsp;GetService(Type&nbsp;serviceType);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IEnumerable&lt;object&gt;&nbsp;GetServices(Type&nbsp;serviceType);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>The instantiation and definition of the Resolver so that it can be used with the Web API controllers is ultimately done in a totally different way.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static void Register(HttpConfiguration config)
{
    var container = new UnityContainer();
    container.RegisterType&lt;IDependencyInjectionService, DependencyInjectionService&gt;();

    config.DependencyResolver = new UnityResolver(unityContainer);

    // Web API routes
    config.MapHttpAttributeRoutes();

    config.Routes.MapHttpRoute(
        name: &quot;DefaultApi&quot;,
        routeTemplate: &quot;api/{controller}/{id}&quot;,
        defaults: new { id = RouteParameter.Optional }
    );
}</pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;Register(HttpConfiguration&nbsp;config)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;container&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;UnityContainer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;container.RegisterType&lt;IDependencyInjectionService,&nbsp;DependencyInjectionService&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;config.DependencyResolver&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;UnityResolver(unityContainer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Web&nbsp;API&nbsp;routes</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;config.MapHttpAttributeRoutes();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;config.Routes.MapHttpRoute(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;name:&nbsp;<span class="js__string">&quot;DefaultApi&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;routeTemplate:&nbsp;<span class="js__string">&quot;api/{controller}/{id}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;defaults:&nbsp;<span class="js__operator">new</span>&nbsp;<span class="js__brace">{</span>&nbsp;id&nbsp;=&nbsp;RouteParameter.Optional&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>Note that both technologies, ASP.NET MVC and ASP.NET Web API have the basics to enable injection of dependencies. The DependencyResolver mechanism is present as a base. However, by default, it is not plugged into an IoC container. In addition, each technology
 uses its own mechanism. For an application that mixes MVC and Web API controllers, it is, therefore, necessary to create two DependencyResolver homes and plug them into the same IoC container.</p>
<p>Note that SignalR, another ASP.NET brick also has its own mechanism, also different from those presented above.</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - DI-ConsoleApp.</em> </li></ul>
