# DI with WCF using Autofac integration.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WCF
- .NET Framework
## Topics
- WCF
- Language Samples
## Updated
- 06/12/2012
## Description

<h1>Introduction</h1>
<p><em>This sample shows you how to implement dependency injection in WCF using Autofac IOC container and WCF integration provided by Autofac. Sample builds simple WCF service to get cars from the car provider that is injected to WCF service via Autofac.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>What you need is download Autofac DI container and WCF integration. You need only two assemblies, Autofac.dll and Autofac.Integration.Wcf.dll, both are small in size and easy to use. Just reference them and copy to output folder. You can download the
 assemblies from <a href="http://code.google.com/p/autofac/downloads/list" target="_blank">
Autofac download page</a>. I've used the version with .NET 4.0</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>Using dependency injection might be challenging to new WCF developers so this sample shows you how to take advantage the integration provided by DI container, namely Autofac. I selected Autofac because it's familiar to me and integrating it to&nbsp;lightweight
 WCF services is simple at&nbsp;least for me it has been simple. But&nbsp;you can&nbsp;search similar construct in your favourite DI container or&nbsp;ask if you DI container will in future implement similar behavior as Autofac.&nbsp;</em></p>
<p><em>My sample consist of&nbsp;four different projects:</em></p>
<p><em>Ioc.Services.Domain - has&nbsp;the&nbsp;common&nbsp;classes and interfaces used&nbsp;by services. Main interface is the ICarProvider interface that is used by service.</em></p>
<p><em>Ioc.Services.Impl - has the single implementation of ICarProvider interface that provides&nbsp;european cars.</em></p>
<p><em>Ioc.Services - has the&nbsp;single service ICarProviderService that serves the cars provided by ICarProvider interface.</em></p>
<p><em>Ioc.Services.Host&nbsp;- has the&nbsp;host file for the ICarProviderService and it also works as a composition root for the depenedency injection.</em>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// The integration of the Autofac to WCF happens in
// hosting file, CarProviderService.svc where you set 
// the hosted service and Autofac service factory
&lt;%@ ServiceHost 
    Language=&quot;C#&quot; 
    Debug=&quot;true&quot; 
    Service=&quot;Ioc.Services.ICarProviderService, Ioc.Services&quot; 
    Factory=&quot;Autofac.Integration.Wcf.AutofacServiceHostFactory, Autofac.Integration.Wcf&quot; %&gt;

// another important part is the composition root
// where composition will happen, that is the application start
protected void Application_Start(object sender, EventArgs e)
{
    // build and set container in application start
    IContainer container = AutofacContainerBuilder.BuildContainer();
     AutofacHostFactory.Container = container;
}

// configuring and registering types to Autofac
// is set in my own helper class
/// &lt;summary&gt;
/// Class to build Autofac IOC container.
/// &lt;/summary&gt;
public static class AutofacContainerBuilder
{
    /// &lt;summary&gt;
    /// Configures and builds Autofac IOC container.
    /// &lt;/summary&gt;
    /// &lt;returns&gt;&lt;/returns&gt;
    public static IContainer BuildContainer()
    {
        var builder = new ContainerBuilder();

        // register types
        builder.RegisterType&lt;EuropeanCarProvider&gt;().As&lt;ICarProvider&gt;();
        builder.RegisterType&lt;CarProviderService&gt;().As&lt;ICarProviderService&gt;();

        // build container
        return builder.Build();
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;The&nbsp;integration&nbsp;of&nbsp;the&nbsp;Autofac&nbsp;to&nbsp;WCF&nbsp;happens&nbsp;in</span>&nbsp;
<span class="cs__com">//&nbsp;hosting&nbsp;file,&nbsp;CarProviderService.svc&nbsp;where&nbsp;you&nbsp;set&nbsp;</span>&nbsp;
<span class="cs__com">//&nbsp;the&nbsp;hosted&nbsp;service&nbsp;and&nbsp;Autofac&nbsp;service&nbsp;factory</span>&nbsp;
&lt;%@&nbsp;ServiceHost&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Language=<span class="cs__string">&quot;C#&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Debug=<span class="cs__string">&quot;true&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Service=<span class="cs__string">&quot;Ioc.Services.ICarProviderService,&nbsp;Ioc.Services&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Factory=<span class="cs__string">&quot;Autofac.Integration.Wcf.AutofacServiceHostFactory,&nbsp;Autofac.Integration.Wcf&quot;</span>&nbsp;%&gt;&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;another&nbsp;important&nbsp;part&nbsp;is&nbsp;the&nbsp;composition&nbsp;root</span>&nbsp;
<span class="cs__com">//&nbsp;where&nbsp;composition&nbsp;will&nbsp;happen,&nbsp;that&nbsp;is&nbsp;the&nbsp;application&nbsp;start</span>&nbsp;
<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Application_Start(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;build&nbsp;and&nbsp;set&nbsp;container&nbsp;in&nbsp;application&nbsp;start</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IContainer&nbsp;container&nbsp;=&nbsp;AutofacContainerBuilder.BuildContainer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutofacHostFactory.Container&nbsp;=&nbsp;container;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;configuring&nbsp;and&nbsp;registering&nbsp;types&nbsp;to&nbsp;Autofac</span>&nbsp;
<span class="cs__com">//&nbsp;is&nbsp;set&nbsp;in&nbsp;my&nbsp;own&nbsp;helper&nbsp;class</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;Class&nbsp;to&nbsp;build&nbsp;Autofac&nbsp;IOC&nbsp;container.</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;AutofacContainerBuilder&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Configures&nbsp;and&nbsp;builds&nbsp;Autofac&nbsp;IOC&nbsp;container.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IContainer&nbsp;BuildContainer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;builder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContainerBuilder();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;register&nbsp;types</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;builder.RegisterType&lt;EuropeanCarProvider&gt;().As&lt;ICarProvider&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;builder.RegisterType&lt;CarProviderService&gt;().As&lt;ICarProviderService&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;build&nbsp;container</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;builder.Build();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ICarProvider.cs - the interface definition used by the service</em> </li><li><em><em>EuropeanCarProvider.cs - the implementation of the ICarProvider that is injected to the service class.</em></em>
</li><li><em>CarProviderService.cs - the actual service impelementation that will use injected ICarProvider interface to provider cars.</em>
</li><li><em>AutofacContainerBuilder.cs - the class that helps to build the Autofac DI container.</em>
</li></ul>
