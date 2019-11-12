# Dependency Injection for Web API Controllers
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET Web API
## Topics
- ASP.NET Web API
## Updated
- 02/25/2014
## Description

<p>This sample contains the complete code for the following ASP.NET Web API tutorial:</p>
<p><a href="http://www.asp.net/web-api/overview/extensibility/using-the-web-api-dependency-resolver">Dependency Injection for Web API Controllers</a></p>
<p>[Excerpt]</p>
<h2>The Web API Dependency Resolver</h2>
<p>Web API defines the <strong>IDependencyResolver</strong> interface for resolving dependencies. Here is the definition of the interface:</p>
<pre>public interface IDependencyResolver : IDependencyScope, IDisposable
{
    IDependencyScope BeginScope();
}

public interface IDependencyScope : IDisposable
{
    object GetService(Type serviceType);
    IEnumerable&lt;object&gt; GetServices(Type serviceType);
}
</pre>
<p>The <strong>IDependencyScope</strong> interface has two methods:</p>
<ul>
<li><strong>GetService</strong> creates one instance of a type. </li><li><strong>GetServices</strong> creates a collection of objects of a specified type.
</li></ul>
<p>The <strong>IDependencyResolver</strong> method inherits <strong>IDependencyScope</strong> and adds the
<strong>BeginScope</strong> method. I'll talk about scopes later in this tutorial.</p>
<p>When Web API creates a controller instance, it first calls <strong>IDependencyResolver.GetService</strong>, passing in the controller type. You can use this extensibility hook to create the controller, resolving any dependencies. If
<strong>GetService</strong> returns null, Web API looks for a parameterless constructor on the controller class.</p>
<h2>Dependency Resolution with the Unity Container</h2>
<p>Although you could write a complete <strong>IDependencyResolver</strong> implementation from scratch, the interface is really designed to act as bridge between Web API and existing IoC containers.</p>
<p>An IoC container is a software component that is responsible for managing dependencies. You register types with the container, and then use the container to create objects. The container automatically figures out the dependency relations. Many IoC containers
 also allow you to control things like object lifetime and scope.</p>
<p class="note">Note: &ldquo;IoC&rdquo; stands for &ldquo;inversion of control&rdquo;, which is a general pattern where a framework calls into application code. An IoC container constructs your objects for you, which &ldquo;inverts&rdquo; the usual flow of
 control.</p>
<p>For this tutorial, we'll use <a href="http://msdn.microsoft.com/en-us/library/ff647202.aspx">
Unity</a> from Microsoft Patterns &amp; Practices. (Other popular libraries include
<a href="http://www.castleproject.org/">Castle Windsor</a>, <a href="http://www.springframework.net/">
Spring.Net</a>, <a href="http://code.google.com/p/autofac/">Autofac</a>, <a href="http://www.ninject.org/">
Ninject</a>, and <a href="http://docs.structuremap.net/">StructureMap</a>.) You can use NuGet Package Manager to install Unity. From the
<strong>Tools</strong> menu in Visual Studio, select <strong>Library Package Manager</strong>, then select
<strong>Package Manager Console</strong>. In the Package Manager Console window, type the following command:</p>
<pre class="prettyprint lang-command-line">Install-Package Unity</pre>
