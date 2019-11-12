# Database Sync:SQL Server and SQL Express N-Tier with WCF
## Requires
- Visual Studio 2008
## License
- Custom
## Technologies
- WCF
- Microsoft Sync Framework 2.1
## Topics
- Database Synchronization
## Updated
- 03/14/2011
## Description

<p class="wikidoc">Shows how to use the Sync Framework 2.1 database providers to configure and execute synchronization between a SQL Server database and one or more SQL Server Express databases. This sample demonstrates syncing with a central server as well
 as between two clients using a web service implemented using WCF. This sample is targeted at customers who want to leverage SQL Express on the client instead of SQL Compact to take advantage of features such as stored procedures, XML support, and advanced
 profiling. This application demonstrates how to use Sync Framework database synchronization providers to configure and execute peer-to-peer synchronization between SQL Server or SQL Express databases via a remote WCF service.</p>
<p class="wikidoc">It also demonstrates an n-tier architecture where the clients synchronize with the server as well as with one another using a web service implemented using WCF.</p>
<div class="wikidoc"><strong>&nbsp;</strong></div>
<div class="wikidoc"><strong>What is Demonstrated in This Sample:</strong></div>
<div class="wikidoc">
<ul>
<li>Synchronizing a server database scope (hosted in a SQL Server or SQL Server Express instance) with multiple client-side instances of SQL Server or SQL Express
</li><li>Enabling synchronization over an n-tier model by using WCF as an endpoint </li><li>The new multi-scope change-tracking model on the server </li><li>Full initialization of the client side databases </li><li>Configuration of SqlSyncProvider for both the server and client </li><li>Enabling batched synchronization </li></ul>
</div>
<p><strong>Required Software:</strong></p>
<ul>
<li>Visual Studio 2008 </li><li>.NET Framework 2.0 SP1 or .NET Framework 3.x </li><li>Microsoft Sync Framework 2.1 </li><li>SQL Server Compact 3.5 sp2 </li></ul>
<div class="wikidoc"><strong>How Do I Install the Application?</strong></div>
<div class="wikidoc">
<ol>
<li>Connect to an instance of SQL Server, and open and execute peer1_setup.sql. </li><li>Open demo.sql and execute the &quot;Insert Sample Data In Tables&quot; sections at the top of the script.
</li><li>Install WCF components - Refer to <a href="http://msdn.microsoft.com/en-us/library/aa751792.aspx">
http://msdn.microsoft.com/en-us/library/aa751792.aspx</a> section&nbsp; &quot;Ensure That IIS and WCF Are Correctly Installed and Registered&quot; to install and configure .Net 3.0.
</li><li>In Visual Studio, open the WebSharingAppDemo-SqlProviderEndToEnd solution with ADMIN privileges. Admin privileges are necessary to start the self hosted WCF service sample.
</li><li>Build the project. </li></ol>
<p><strong>What Do the Individual CS Files Contain?</strong></p>
<ol>
<li>&nbsp;App directory - Contains all the code files for the Windows Form app. </li><li>&nbsp;App\SqlCreationUtilities.cs - Contains utility classes that the app uses to handle string constants and hold peer database information.
</li><li>&nbsp;App\SqlSharingForm.cs - Main entrance point for the Windows Form app. Contains all GUI eventing/OnClick logic.&nbsp;
</li><li>&nbsp;App\NewSqlPeerCreationWizard.cs - New wizard app that is used to gather user information to configure and provision a new SQL Server or SQL&nbsp;&nbsp; Express database.
</li><li>&nbsp;App\ProgressForm.cs - Form app that shows progress information for each SyncOrchestrator.Synchronize() call.
</li><li>&nbsp;App\Resource.resx and App\Resources.Designer.cs - Resource files.&nbsp;
</li><li>&nbsp;App\SharingApp.cs - Contains the Main function that launches a new instance of the SqlSharingForm class.
</li><li>&nbsp;App\SynchronizationHelper.cs - The main class that handles configuration SqlSyncProvider instances. Short instructions are included for each method in the class:<br>
&nbsp;CheckAndCreateSQLDatabase() - Utility function that creates an empty SQL Server database.<br>
&nbsp;CheckIfProviderNeedsSchema() - Sample that demonstrates how a SqlSyncProvider would determine if the underlying database needs a schema&nbsp;&nbsp; or not.<br>
&nbsp;ConfigureSqlSyncProvider() - Sample that demonstrates how to configure SqlSyncProvider.<br>
&nbsp;provider_*() - Sample client side event registration code that demonstrates how to handle specific events raised by Sync Framework.<br>
&nbsp;App\TablesViewControl.cs - Custom user control that displays values from the two sample tables (orders and order_details).
</li><li>WebSyncContract directory - Contains all files related to the WCF service. Some important files are
</li><li>WebSyncContract\WebSyncContract\IRelationalSyncContract.cs - Interface declaring the base WCF service and operations.
</li><li>WebSyncContract\WebSyncContract\ISqlSyncContract.cs - Interface declaring the Sql Server specific operations such as GetSchema.
</li><li>WebSyncContract\WebSyncContract\RelationalWebSyncService.cs - Implementation of IRelationalSyncContract.
</li><li>WebSyncContract\WebSyncContract\SqlWebSyncService.cs - Implementation of ISqlSyncContract.
</li><li>WebSyncContract\WebSyncContract\RelationalProviderProxy.cs - Base WCF Proxy class implementation.
</li><li>WebSyncContract\WebSyncContract\SqlSyncProviderProxy.cs - Sql Server specific Proxy class implementation.
</li><li>WebSyncContract\WebSyncContract\WebServiceHostLauncher.cs - Simple class that self-hosts the WCF services.
</li><li>WebSyncContract\WebSyncContract\App.config - Contains information on WCF endpoints and binding informations.
</li></ol>
<p>&nbsp;<br>
Setup directory - Contains the server provisioning .sql files.</p>
<p><br>
<strong>How Do I Use the Sample?</strong></p>
<ol>
<li>Install the application as described in the &quot;How Do I Install&quot; section. </li><li>Run the sample app. It assumes that SQL Server is installed as localhost. If it's not, please replace Environment.MachineName with the correct instance name in SqlSharingForm.SqlSharingForm_Shown(). It also launches the self-hosted WCF service.
</li><li>If the sample is correctly installed, values from the orders and order_details tables should display in the datagrid on the &quot;Peer1&quot; tab.
</li><li>The Synchronize button is disabled until at least one new SQL Server peer is added. Add a new SQL Server database by clicking &quot;Add SQL Peer&quot;. SQL Server can be on local or remote machines with Windows NT integrated security or the given username and password.
</li><li>On clicking OK, a new tab with the name &quot;Peer#&quot; should be added to the main form. After the peer is synchronized, clicking that tab displays values for the tables orders and order_details in that SQL Server database.
</li><li>Batching can be enabled by setting a non-zero value in the Batch size text box. By default batching is disabled.<br>
6.a&nbsp; The Batching location can be modified by clicking on the Change button.
</li><li>To synchronize, select source and destination providers, and click Synchronize.
</li><li>Make changes to one or more database tables of different peers and then try to synchronize the peers to confirm that changes are synchronized.
</li></ol>
<p><strong>How Do I Debug the sample?</strong></p>
<ol>
<li>Ensure that the WCF service host project is configured to start. </li><li>Open the solution Properties. Select the Startup Project pane under Common Properties in the left hand side list. Ensure that &quot;Multiple Startup Projects&quot;&nbsp; is selected, and set Action to &quot;Start&quot; for the WebSyncContract and WebSharingAppDemo-SqlProviderEndToEnd
 projects. </li><li>Ensure that WebSyncContract is started before the WebSharingAppDemo-SqlProviderEndToEnd project
</li><li>Ensure that the service is started and running. </li><li>Right-click the &quot;WCF Service Host&quot; icon in the system tray and ensure that WebSyncContract.SqlWebSyncService status report &quot;Started&quot;. If not, then ensure that the VS project is run under Admin rights.
</li><li>If VS is running with the appropriate priveleges, then check to ensure that WCF is installed and configured properly. Refer to the &quot;How Do I Install&quot; section.
</li><li>Ensure that port 8000 is unblocked in your Firewall. </li><li>You can also ensure the service is running by opening a browser and navigating to these links:
<a href="http://localhost:8000/RelationalSyncContract/SqlSyncService/">http://localhost:8000/RelationalSyncContract/SqlSyncService/</a>. You should see the default page showing the &quot;You have created a service&quot; message.
</li></ol>
<p>For more information on synchronizing databases, see <a class="externalLink" href="http://msdn.microsoft.com/en-us/library/ff928676(v=SQL.110).aspx">
Synchronizing SQL Server and SQL Server Compact</a>.</p>
<div class="WikiContent">
<p><strong>Note:</strong>&nbsp;If you use Visual Studio 2010 to compile these samples, you will first need to remove references to the Sync Framework assemblies and then re-add the assembly references to the projects. Otherwise, you will see &quot;type or namespace
 name could not be found&quot; compilation errors.</p>
<hr>
<p><img src="19002-msf_logo.jpg" alt="" width="639" height="56"></p>
</div>
</div>
