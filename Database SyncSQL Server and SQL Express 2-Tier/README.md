# Database Sync:SQL Server and SQL Express 2-Tier
## Requires
- Visual Studio 2008
## License
- Custom
## Technologies
- Microsoft Sync Framework 2.0
## Topics
- Database Synchronization
## Updated
- 03/14/2011
## Description

<p class="wikidoc">This Sample shows how to use the Sync Framework 2.1 database providers to configure and execute synchronization between a SQL Server database and one or more SQL Server Express databases. It demonstrates syncing with a central server as
 well as between two clients and is targeted at customers who want to leverage SQL Express on the client instead of SQL Compact to take advantage of features such as stored procedures, XML support, and advanced profiling.</p>
<div class="wikidoc"><br>
<strong>What is Demonstrated in This Sample:</strong></div>
<div class="wikidoc">
<ul>
<li>Synchronizing a server database scope (hosted in a SQL Server or SQL Server Express instance) with multiple client-side instances of SQL Server or SQL Express
</li><li>The new multi-scope change-tracking model on the server </li><li>Full initialization of the client side databases </li><li>Configuration of SqlSyncProvider for both the server and client </li><li>Enabling batched synchronization </li></ul>
<strong>Required Software:</strong><br>
<ul>
<li>Visual Studio 2008 </li><li>.NET Framework 2.0 SP1 or .NET Framework 3.x </li><li>Microsoft Sync Framework 2.1 </li><li>SQL Server Compact 3.5 sp2 </li></ul>
</div>
<p><strong>What is Demonstrated in This Sample?</strong></p>
<p>- Synchronizing a database scope with multiple instances of SQL Server/SQL Express databases.<br>
- Enabling synchronization over a 2-tier model.<br>
- The new multi-scope change-tracking model on the server.<br>
- Configuration of SqlSyncProvider objects.<br>
- Enabling batched synchronization.</p>
<p><strong>How Do I Install the Application?</strong></p>
<ol>
<li>Connect to an instance of SQL Server, and open and execute peer1_setup.sql. </li><li>Open demo.sql and execute the &quot;Insert Sample Data In Tables&quot; sections at the top of the script.
</li><li>In Visual Studio, open the SharingAppDemo-SqlProviderEndToEnd solution . </li><li>Build the project. </li></ol>
<p><br>
<strong>What Do the Individual CS Files Contain?</strong></p>
<ol>
<li>&nbsp;App directory - Contains all the code files for the Windows Form app. </li><li>&nbsp;App\SqlCreationUtilities.cs - Contains utility classes that the app uses to handle string constants and hold peer database information.
</li><li>&nbsp;App\SqlSharingForm.cs - Main entrance point for the Windows Form app. Contains all GUI eventing/OnClick logic.
</li><li>&nbsp;App\NewSqlPeerCreationWizard.cs - New wizard app that is used to gather user information to configure and provision a new SQL Server or SQL Express database.
</li><li>&nbsp;App\ProgressForm.cs - Form app that shows progress information for each SyncOrchestrator.Synchronize() call.
</li><li>&nbsp;App\Resource.resx and App\Resources.Designer.cs - Resource files. </li><li>&nbsp;App\SharingApp.cs - Contains the Main function that launches a new instance of the SqlSharingForm class.
</li><li>&nbsp;App\SynchronizationHelper.cs - The main class that handles configuration SqlSyncProvider instances. Short instructions are included for each method in the class:
</li><li>&nbsp;CheckAndCreateSQLDatabase() - Utility function that creates an empty SQL Server database.
</li><li>&nbsp;CheckIfProviderNeedsSchema() - Sample that demonstrates how a SqlSyncProvider would determine if the underlying database needs a schema or not.
</li><li>&nbsp;ConfigureSqlSyncProvider() - Sample that demonstrates how to configure SqlSyncProvider.
</li><li>&nbsp;provider_*() - Sample client side event registration code that demonstrates how to handle specific events raised by Sync Framework.
</li><li>&nbsp;App\TablesViewControl.cs - Custom user control that displays values from the two sample tables (orders and order_details).
</li><li>Setup directory - Contains the server provisioning .sql files. </li></ol>
<p><br>
<strong>How Do I Use the Sample?</strong></p>
<ol>
<li>Install the application as described in the &quot;How Do I Install&quot; section. </li><li>Run the sample app. It assumes that SQL Server is installed as localhost. If it's not, please replace Environment.MachineName with the correct instance name in SqlSharingForm.SqlSharingForm_Shown().
</li><li>If the sample is correctly installed, values from the orders and order_details tables should display in the datagrid on the &quot;Peer1&quot; tab.
</li><li>The Synchronize button is disabled until at least one new SQL Server peer is added. Add a new SQL Server database by clicking &quot;Add SQL Peer&quot;. SQL Server can be on local or remote machines with Windows NT integrated security or the given username and password.
</li><li>On clicking OK, a new tab with the name &quot;Peer#&quot; should be added to the main form. After the peer is synchronized, clicking that tab displays values for the tables orders and order_details in that SQL Server database.
</li><li>Batching can be enabled by setting a non-zero value in the Batch size text box. By default batching is disabled.<br>
6.a The Batching location can be modified by clicking on the Change button. </li><li>To synchronize, select source and destination providers, and click Synchronize.<br>
Make changes to one or more database tables of different peers and then try to synchronize the peers to confirm that changes are synchronized.
</li></ol>
<p>For more information on synchronizing databases, see <a class="externalLink" href="http://msdn.microsoft.com/en-us/library/ff928676(v=SQL.110).aspx">
Synchronizing SQL Server and SQL Server Compact</a>.</p>
<div class="WikiContent">
<p><strong>Note:</strong>&nbsp;If you use Visual Studio 2010 to compile these samples, you will first need to remove references to the Sync Framework assemblies and then re-add the assembly references to the projects. Otherwise, you will see &quot;type or namespace
 name could not be found&quot; compilation errors.</p>
<hr>
<p><img src="19002-msf_logo.jpg" alt="" width="639" height="56"></p>
</div>
