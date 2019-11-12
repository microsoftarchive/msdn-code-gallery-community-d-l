# Extending the Security Application Block - SqlAuthorizationRuleProvider
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- ASP.NET
- ASP.NET MVC
- Extending Security Application Block
## Topics
- Security
- enterprise library
- security application block
- web security
## Updated
- 08/17/2012
## Description

<h1>Introduction</h1>
<p><em>In current enterprise library security application block, all the rules are saved in the configuration file - web.config or app.config. In production environment, system requires to load the rules from the repositories instead and allow to modify the
 rules at run time.&nbsp;Below article explains how to extend the block and read the rules from Sql Server database.</em></p>
<p><em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To run the sample codes, VS2010 is needed.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>First, let's create some rule table into the database--AuthorizationRule and insert 3 rules into the table.</em></p>
<p><em><img src="54457-rules.jpg" alt="" width="563" height="242"></em></p>
<p>&nbsp;</p>
<p><em>DB Script (<em>&nbsp;( Please change the DB name as required)) to create the table and sample rules</em></em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>SQL</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">mysql</span>

<div class="preview">
<pre class="mysql"><span class="sql__keyword">USE</span>&nbsp;[<span class="sql__id">VehicleMDM</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[AuthorizationRule]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;03/20/2012&nbsp;11:34:41&nbsp;******/</span>&nbsp;
<span class="sql__keyword">IF</span>&nbsp;&nbsp;<span class="sql__keyword">EXISTS</span>&nbsp;(<span class="sql__keyword">SELECT</span>&nbsp;*&nbsp;<span class="sql__keyword">FROM</span>&nbsp;<span class="sql__id">sys</span>.<span class="sql__id">objects</span>&nbsp;<span class="sql__keyword">WHERE</span>&nbsp;<span class="sql__id">object_id</span>&nbsp;=&nbsp;<span class="sql__id">OBJECT_ID</span>(<span class="sql__id">N</span><span class="sql__string">'[dbo].[AuthorizationRule]'</span>)&nbsp;<span class="sql__keyword">AND</span>&nbsp;<span class="sql__keyword">type</span>&nbsp;<span class="sql__keyword">in</span>&nbsp;(<span class="sql__id">N</span><span class="sql__string">'U'</span>))&nbsp;
<span class="sql__keyword">DROP</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">AuthorizationRule</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">USE</span>&nbsp;[<span class="sql__id">VehicleMDM</span>]&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__mlcom">/******&nbsp;Object:&nbsp;&nbsp;Table&nbsp;[dbo].[AuthorizationRule]&nbsp;&nbsp;&nbsp;&nbsp;Script&nbsp;Date:&nbsp;03/20/2012&nbsp;11:34:41&nbsp;******/</span>&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">ANSI_NULLS</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">SET</span>&nbsp;<span class="sql__id">QUOTED_IDENTIFIER</span>&nbsp;<span class="sql__keyword">ON</span>&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">CREATE</span>&nbsp;<span class="sql__keyword">TABLE</span>&nbsp;[<span class="sql__id">dbo</span>].[<span class="sql__id">AuthorizationRule</span>](&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__id">IDENTITY</span>(<span class="sql__number">1</span>,<span class="sql__number">1</span>)&nbsp;<span class="sql__keyword">NOT</span>&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__keyword">Name</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">50</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Description</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">200</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Expression</span>]&nbsp;[<span class="sql__keyword">nvarchar</span>](<span class="sql__number">100</span>)&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Parent</span>]&nbsp;[<span class="sql__keyword">int</span>]&nbsp;<span class="sql__value">NULL</span>,&nbsp;
&nbsp;<span class="sql__keyword">CONSTRAINT</span>&nbsp;[<span class="sql__id">PK_AuthorizationRule</span>]&nbsp;<span class="sql__keyword">PRIMARY</span>&nbsp;<span class="sql__keyword">KEY</span>&nbsp;<span class="sql__id">CLUSTERED</span>&nbsp;&nbsp;
(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<span class="sql__id">Id</span>]&nbsp;<span class="sql__keyword">ASC</span>&nbsp;
)<span class="sql__keyword">WITH</span>&nbsp;(<span class="sql__id">PAD_INDEX</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">STATISTICS_NORECOMPUTE</span>&nbsp;&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">IGNORE_DUP_KEY</span>&nbsp;=&nbsp;<span class="sql__id">OFF</span>,&nbsp;<span class="sql__id">ALLOW_ROW_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>,&nbsp;<span class="sql__id">ALLOW_PAGE_LOCKS</span>&nbsp;&nbsp;=&nbsp;<span class="sql__keyword">ON</span>)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
)&nbsp;<span class="sql__keyword">ON</span>&nbsp;[<span class="sql__keyword">PRIMARY</span>]&nbsp;
&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">AuthorizationRule</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([<span class="sql__keyword">Name</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Description</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Expression</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Parent</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'IsAdministrator'</span>,<span class="sql__string">'Is&nbsp;Administrator&nbsp;Check'</span>,<span class="sql__string">'R:Administrator'</span>,<span class="sql__value">null</span>)&nbsp;
&nbsp;
&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">AuthorizationRule</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([<span class="sql__keyword">Name</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Description</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Expression</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Parent</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'IsDataSteward'</span>,<span class="sql__string">'Is&nbsp;DataSteward&nbsp;Check'</span>,<span class="sql__string">'R:Administrator&nbsp;OR&nbsp;R:DataSteward'</span>,<span class="sql__value">null</span>)&nbsp;
&nbsp;
<span class="sql__keyword">INSERT</span>&nbsp;<span class="sql__keyword">INTO</span>&nbsp;[<span class="sql__id">AuthorizationRule</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;([<span class="sql__keyword">Name</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Description</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Expression</span>]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;,[<span class="sql__id">Parent</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="sql__keyword">VALUES</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(<span class="sql__string">'IsUser'</span>,<span class="sql__string">'Is&nbsp;User&nbsp;Check'</span>,<span class="sql__string">'R:User&nbsp;OR&nbsp;R:DataSteward&nbsp;OR&nbsp;R:Administrator'</span>,<span class="sql__value">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="sql__id">GO</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><span>Class Diagram</span></p>
<p><span><img src="54458-class.bmp" alt="" width="624" height="314"><br>
</span></p>
<ul>
<li><em>IAuthorizationRepository: interface for the rule repository, has attributes including&nbsp;<span style="color:#0000ff">Name</span>,&nbsp;<span style="color:#0000ff">Connectionstring</span></em>
</li><li><em>SqlAuthorizationData: class implements the&nbsp;<em>IAuthorizationRepository interface.</em></em>
</li><li><em><em>SqlAuthorizationProviderData: class overrides the method GetRegistrationsof AuthorizationProviderData class and it also holds a collection of&nbsp;SqlAuthorizationData instances<br>
</em></em></li><li><em><em>IAuthorizationRule: interface which contains attributes including&nbsp;<em><span style="color:#0000ff">Name</span>,&nbsp;<span style="color:#0000ff">Expression</span></em></em></em>
</li><li><em><em><em><span style="color:#0000ff"><span style="color:#000000">SqlAuthorizationRule: class implements the interface of&nbsp;<em><em>IAuthorizationRule</em></em></span><br>
</span></em></em></em></li><li><em><em><em><span style="color:#0000ff"><span style="color:#000000"><em><em>SqlAuthorizationRuleProvider: the core of the change, which extends the class of AuthorizationProvider, it reads the
<em><em>SqlAuthorizationProviderData, and translates into connection string and uses ADO.net to initialize a set of
</em></em>&nbsp;<em><em><em><span><span>SqlAuthorizationRule instances.&nbsp;</span></span></em></em></em></em></em></span></span>
</em></em></em></li></ul>
<p>So How to use the security application block? Here are some links</p>
<p><a href="http://msdn.microsoft.com/en-us/library/ff648031.aspx">http://msdn.microsoft.com/en-us/library/ff648031.aspx</a></p>
<p><a href="http://www.education.vic.gov.au/devreskit/appdev/Application%20Blocks/Security/security-standards-details.htm#usage">http://www.education.vic.gov.au/devreskit/appdev/Application%20Blocks/Security/security-standards-details.htm#usage</a></p>
<p><span style="font-size:small">Deployment</span></p>
<p>1) change security configuration in app.config or web.config ( please correctly set the connection string, namespace..)<span style="font-size:xx-small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;securityConfiguration</span>&nbsp;<span class="xml__attr_name">defaultAuthorizationInstance</span>=<span class="xml__attr_value">&quot;RulesProvider&quot;</span>&nbsp;<span class="xml__attr_name">defaultSecurityCacheInstance</span>=<span class="xml__attr_value">&quot;&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;authorizationProviders</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;VehicleMaster.Infrastructure.Common.Utilities.Security.SqlAuthorizationRuleProvider,&nbsp;Utilities&quot;</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;RulesProvider&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;repositories</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;default&quot;</span>&nbsp;<span class="xml__attr_name">connectionstring</span>=<span class="xml__attr_value">&quot;Data&nbsp;Source=10.234.58.172\SQL_DEV;Initial&nbsp;Catalog=VehicleMDM;User&nbsp;Id=sa;Password=Passw0rd;&quot;</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/repositories&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/add&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/authorizationProviders&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/securityConfiguration&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">2) We use the rule check at MVC controller level, below sample codes make sure only users who have administrator role can view the about page.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">&nbsp;&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[RuleAuthorize(<span class="cs__string">&quot;IsAdministrator&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;ActionResult&nbsp;About()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp; If a user does not have administrator role, and when clicking about menu, he/she will get warning message</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><img src="54461-access%20denied.jpg" alt="" width="526" height="163"></div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p>We also used Cache application block to cache the rules. The Cache Manager configuration is shown as below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;cachingConfiguration</span>&nbsp;<span class="xml__attr_name">defaultCacheManager</span>=<span class="xml__attr_value">&quot;CacheManager&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;cacheManagers</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;CacheManager&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager.aspx" target="_blank" title="Auto generated link to Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager">Microsoft.Practices.EnterpriseLibrary.Caching.CacheManager</a>,&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Practices.EnterpriseLibrary.Caching.aspx" target="_blank" title="Auto generated link to Microsoft.Practices.EnterpriseLibrary.Caching">Microsoft.Practices.EnterpriseLibrary.Caching</a>,&nbsp;Version=5.0.414.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=31bf3856ad364e35&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">expirationPollFrequencyInSeconds</span>=<span class="xml__attr_value">&quot;60&quot;</span>&nbsp;<span class="xml__attr_name">maximumElementsInCacheBeforeScavenging</span>=<span class="xml__attr_value">&quot;1000&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">numberToRemoveWhenScavenging</span>=<span class="xml__attr_value">&quot;10&quot;</span>&nbsp;<span class="xml__attr_name">backingStoreName</span>=<span class="xml__attr_value">&quot;Cache&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/cacheManagers&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;backingStores</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;Cache&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Practices.EnterpriseLibrary.Caching.Database.DataBackingStore.aspx" target="_blank" title="Auto generated link to Microsoft.Practices.EnterpriseLibrary.Caching.Database.DataBackingStore">Microsoft.Practices.EnterpriseLibrary.Caching.Database.DataBackingStore</a>,&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/Microsoft.Practices.EnterpriseLibrary.Caching.Database.aspx" target="_blank" title="Auto generated link to Microsoft.Practices.EnterpriseLibrary.Caching.Database">Microsoft.Practices.EnterpriseLibrary.Caching.Database</a>,&nbsp;Version=5.0.414.0,&nbsp;Culture=neutral,&nbsp;PublicKeyToken=31bf3856ad364e35&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__attr_name">encryptionProviderName</span>=<span class="xml__attr_value">&quot;&quot;</span>&nbsp;<span class="xml__attr_name">databaseInstanceName</span>=<span class="xml__attr_value">&quot;CacheDB&quot;</span>&nbsp;<span class="xml__attr_name">partitionName</span>=<span class="xml__attr_value">&quot;AuthorizationCache&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/backingStores&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/cachingConfiguration&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;connectionStrings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;CacheDB&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Data&nbsp;Source=10.234.58.172\SQL_DEV;Initial&nbsp;Catalog=VehicleMDM;Persist&nbsp;Security&nbsp;Info=True;User&nbsp;ID=sa;Password=Passw0rd;MultipleActiveResultSets=True&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;ApplicationServices&quot;</span>&nbsp;<span class="xml__attr_name">connectionString</span>=<span class="xml__attr_value">&quot;Data&nbsp;Source=10.234.58.172\SQL_DEV;Initial&nbsp;Catalog=VehicleMDM;User&nbsp;Id=sa;Password=Passw0rd;&quot;</span>&nbsp;<span class="xml__attr_name">providerName</span>=<span class="xml__attr_value">&quot;System.Data.SqlClient&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/connectionStrings&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Current implementation only read rules from database, &nbsp;developers can also add update function to the rules.</div>
