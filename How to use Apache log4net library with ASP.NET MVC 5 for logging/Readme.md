# How to use Apache log4net library with ASP.NET MVC 5 for logging.
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- .NET Framework
- Logging
- .NET Framework 4.0
- ASP.NET MVC 5
- Log4net
- Visual Studio Express 2013
- Apache log4net library
## Topics
- C#
- ASP.NET
- Logging
- file logging
## Updated
- 10/09/2014
## Description

<p>Introduction</p>
<p>Logging is a method of tracking/monitoring what is going on when an application is in progress/running. Log records will be most needed items when something goes wrong in your application, be it windows forms, mobile or web applications.</p>
<p>Here I will be walking through the basic steps in implementing logging functionality using Apache log4net framework in an ASP.Net MVC 5 application.</p>
<p>I am using Visual Studio Express 2013 for Web as my development environment targeting .Net framework 4.5.</p>
<h1><span>Building the Sample</span></h1>
<p><strong>Step1 :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
Open Visual Studio 2013 for Web and create a new ASP.Net Web application selecting MVC template.</p>
<p><img id="126685" src="126685-1.jpg" alt="" width="512" height="655"></p>
<p><img alt=""></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Step 2 : </strong>Here in this demo application we are going to use Apache log4net framework for logging. We need to add reference of log4net DLL using NuGet package manager.</p>
<ul>
<li>In VS 2013 Solution Explorer -&gt; Right Click on Reference and Select Manage NuGet Packages.
</li><li>Search for &lsquo;log4net&rsquo; and Install. </li></ul>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126686" src="126686-2.png" alt="" width="523" height="321"></p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126687" src="126687-3.png" alt="" width="874" height="576"></p>
<p>Once installation is successful we can see the log4net dll added under the Solution explorer Reference section as shown below.</p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126688" src="126688-4.png" alt="" width="531" height="285"></p>
<p><strong>Step 3:</strong> Next we need to configure our application to use log4net logging framework. Add below line in your startup.cs file in ASP.Net MVC5 Solution folder. The below line of code provides information about log4net configuration file.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[assembly: log4net.Config.XmlConfigurator(ConfigFile = &quot;Web.config&quot;, Watch = true)]   </pre>
<div class="preview">
<pre class="csharp">[assembly:&nbsp;log4net.Config.XmlConfigurator(ConfigFile&nbsp;=&nbsp;<span class="cs__string">&quot;Web.config&quot;</span>,&nbsp;Watch&nbsp;=&nbsp;<span class="cs__keyword">true</span>)]&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<img id="126689" src="126689-5.png" alt="" width="1254" height="476"></div>
<p><img alt=""></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><strong>Step 4 :</strong> Next add the below section to web.config file.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">  &lt;configSections&gt;
    &lt;!-- Add log4net config section--&gt;
    &lt;section name=&quot;log4net&quot; type=&quot;log4net.Config.Log4NetConfigurationSectionHandler, 	log4net&quot; /&gt;
  &lt;/configSections&gt;

  &lt;log4net debug=&quot;true&quot;&gt;
    &lt;appender name=&quot;RollingLogFileAppender&quot; type=&quot;log4net.Appender.RollingFileAppender&quot;&gt;
      &lt;file value=&quot;logs\log.txt&quot; /&gt;
      &lt;appendToFile value=&quot;true&quot; /&gt;
      &lt;rollingStyle value=&quot;Size&quot; /&gt;
      &lt;maxSizeRollBackups value=&quot;10&quot; /&gt;
      &lt;maximumFileSize value=&quot;10MB&quot; /&gt;
      &lt;staticLogFileName value=&quot;true&quot; /&gt;
      &lt;layout type=&quot;log4net.Layout.PatternLayout&quot;&gt;
        &lt;conversionPattern value=&quot;%-5p %d %5rms %-22.22c{1} %-18.18M - %m%n&quot; /&gt;
      &lt;/layout&gt;
    &lt;/appender&gt;

    &lt;root&gt;
      &lt;level value=&quot;DEBUG&quot; /&gt;
      &lt;appender-ref ref=&quot;RollingLogFileAppender&quot; /&gt;
    &lt;/root&gt;
  &lt;/log4net&gt;
</pre>
<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;configSections</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__comment">&lt;!--&nbsp;Add&nbsp;log4net&nbsp;config&nbsp;section--&gt;</span><span class="xml__tag_start">&lt;section</span><span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;log4net&quot;</span><span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;log4net.Config.Log4NetConfigurationSectionHandler,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;log4net&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/configSections&gt;</span><span class="xml__tag_start">&lt;log4net</span><span class="xml__attr_name">debug</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;appender</span><span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;RollingLogFileAppender&quot;</span><span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;log4net.Appender.RollingFileAppender&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;file</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;logs\log.txt&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;appendToFile</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;rollingStyle</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;Size&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;maxSizeRollBackups</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;10&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;maximumFileSize</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;10MB&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;staticLogFileName</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;true&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;layout</span><span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;log4net.Layout.PatternLayout&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;conversionPattern</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;%-5p&nbsp;%d&nbsp;%5rms&nbsp;%-22.22c{1}&nbsp;%-18.18M&nbsp;-&nbsp;%m%n&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/layout&gt;</span><span class="xml__tag_end">&lt;/appender&gt;</span><span class="xml__tag_start">&lt;root</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;level</span><span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;DEBUG&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_start">&lt;appender</span>-ref&nbsp;<span class="xml__attr_name">ref</span>=<span class="xml__attr_value">&quot;RollingLogFileAppender&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/root&gt;</span><span class="xml__tag_end">&lt;/log4net&gt;</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Step 5 :</strong> Next Modify Global.asax.cs and add the below code inside Application_Start() method.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath(&quot;~/Web.config&quot;)));</pre>
<div class="preview">
<pre class="csharp">log4net.Config.XmlConfigurator.Configure(<span class="cs__keyword">new</span>&nbsp;FileInfo(Server.MapPath(<span class="cs__string">&quot;~/Web.config&quot;</span>)));</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>Now our log4net library is ready to use with MVC5 application.</p>
<p><strong>Step 6 :</strong> Add logger declaration in classes for which we want to make logs as below.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">readonly</span>&nbsp;log4net.ILog&nbsp;logger&nbsp;=&nbsp;log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p><strong>Step 7 :</strong> Use the logger.Error() method to log messages when needed.</p>
<p>&nbsp;</p>
<p><img alt=""></p>
<p><img id="126690" src="126690-6.png" alt="" width="1231" height="387"></p>
<p>Run and application and we can see the log file generated under the logs folder under the application root directory as configured in the web config file.</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
