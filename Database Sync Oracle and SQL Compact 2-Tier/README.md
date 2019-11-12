# Database Sync: Oracle and SQL Compact 2-Tier
## Requires
- Visual Studio 2008
## License
- Custom
## Technologies
- Microsoft Sync Framework 2.1
## Topics
- Database Synchronization
## Updated
- 05/13/2011
## Description

<div class="wikidoc">This application demonstrates how to use Sync Framework 2.0 database synchronization providers to configure and execute peer-to-peer synchronization between an Oracle database and one or more SQL Server Compact databases.
<br>
<br>
<strong>What is Demonstrated in This Sample:</strong><br>
<ul>
<li>Using DbSyncProvider to build a custom Oracle provider to sync with multiple instances of a Compact client database.
</li><li>Povisioning an Oracle database for sync. </li><li>Many of the other features demonstrated in the Sql Server to Sql CE sample, with Oracle instead of Sql Server.Synchronizing an Oracle server database scope with multiple instances of a Compact client database.
</li><li>Two ways to configure and synchronize a Compact database: full initialization and snapshot initialization.
</li><li>Configuration of an Oracle DbSyncProvider and SqlCeSyncAdapter objects. </li><li>A set of queries and stored procedures for Oracle DbSyncProvider commands. </li></ul>
</div>
<div class="wikidoc"><br>
<br>
<strong>Required Software:</strong><br>
<ul>
<li>Visual Studio 2005 or Visual Studio 2008 </li><li>.NET Framework 2.0 SP1 or .NET Framework 3.x </li><li>Microsoft Sync Framework 2.0 </li><li>Oracle client libraries 10g or greater. </li><li>Sql Compact Edition 3.5 SP1 </li></ul>
<br>
<strong>How Do I Install the Application?</strong></div>
<div class="wikidoc">
<ol>
<li>Connect to an instance of Oracle, and open and execute peer1_setup.sql and then peer1_procs.sql.
</li><li>Open demo.sql and execute the &quot;Configure scope members&quot; and &quot;Insert Sample Data In Tables&quot; sections at the top of the script.
</li><li>In Visual Studio, open the SharingAppDemo-OracleToCEProviderEndToEnd solution.&nbsp; You must have the Oracle client libraries installed. The project also references SqlCE 2.5 SP1.
</li><li>Build the project. </li></ol>
<p><strong>What do the Individual CS Files Contain?</strong></p>
<ol>
<li>&nbsp;App directory - Contains all the code files for the Winforms app. </li><li>&nbsp;App\CeCreationUtilities.cs - Contains utility classes that the app uses to handle string constants and hold client database information.
</li><li>&nbsp;App\CESharingForm.cs - Main entrance point for the Winforms app. Contains all GUI eventing/OnClick logic.
</li><li>&nbsp;App\NewCEClientCreationWizard.cs - New wizard app that is used to gather user information to configure and provision a new Compact client database.
</li><li>&nbsp;App\ProgressForm.cs - Form app that shows progress information for each SyncOrchestrator.Synchronize() call.
</li><li>&nbsp;App\OracleDBSyncProvider.cs - The Oracle DbSyncProvider </li><li>&nbsp;App\Resource.resx and App\Resources.Designer.cs - Resource files. </li><li>&nbsp;App\SharinApp.cs - Contains the Main function that launches a new instance of the CESharingForm class.
</li><li>&nbsp;App\SynchronizationHelper.cs - The main class that handles configuration of server side DbSyncProvider and client side SqlCESyncProvider instances. Short instructions are included for each method in the class:
</li><li>&nbsp;CheckAndCreateCEDatabase() - Utility function that creates an empty Compact database.
</li><li>&nbsp;CheckIfProviderNeedsSchema() - Sample that demonstrates how a Compact provider would determine if the underlying database needs schema or not.
</li><li>&nbsp;ConfigureCESyncProvider() - Sample that demonstrates how to configure SqlCeSyncProvider.
</li><li>&nbsp;ConfigureDBSyncProvider() - Sample that demonstrates how to configure the Oracle DbSyncProvider.
</li><li>&nbsp;provider_*() - Sample client side event registration code that demonstrates how to handle specific events raised by the sync runtime.
</li><li>&nbsp;App\TablesViewControl.cs - Custom user control that displays values from the two sample tables (orders and order_details), based on the client&nbsp; and server connections that are passed in.
</li><li>Setup directory - Contains the server provisioning .sql files. </li></ol>
<p><br>
<strong>How Do I Use the Sample?</strong></p>
<ol>
<li>Install the application as described in the &quot;How to install&quot; section. </li><li>Run the sample app and pass in an Oracle connection string as a command line argument.
</li><li>If the sample is correctly installed, values from the orders and order_details should display in the datagrid on the &quot;Server&quot; tab.
</li><li>The Synchronize button is disabled until at least one Compact client is added. Add a new Compact client database by clicking &quot;Add CE Client&quot;. Options for creating a new client in the New CE Creation Wizard:<br>
&nbsp;* Full initialization - Create an empty Compact database, get the schema from the server, create the schema on the client, and get all data from the server on the first Synchronize() call.<br>
&nbsp;* Snapshot initialization - Export an existing Compact database, initialize that snapshot and receive only incremental changes from the server on the first Synchronize() call.
</li><li>For full initialization, select the location and file name Or For snapshot initialization, select the .sdf file of an existing client (in the same scope) and pick the location and name for the exported database.
</li><li>On clicking OK, a new tab with the name &quot;Client#&quot; should be added to the main form. After the client is synchronized, clicking that tab displays values for the tables orders and order_details in that Compact database.&nbsp;
</li><li>Batching can be enabled by setting a non zero value in the Batch size text box. By default batching is turned off.<br>
7.a Batching location can be modified from by clicking on the Change button. </li><li>To synchronize, select source and destination providers, and click Synchronize.
</li><li>Make changes to the server or client database tables and then try to synchronize the peers to confirm that changes are synchronized.
</li></ol>
<br>
For more information on synchronizing databases, see <a class="externalLink" href="http://msdn.microsoft.com/en-us/library/ee617382(SQL.105).aspx">
Synchronizing SQL Server and SQL Server Compact</a>.</div>
<div class="wikidoc"></div>
<div class="wikidoc">
<div class="WikiContent">
<p><strong>Note:</strong>&nbsp;If you use Visual Studio 2010 to compile these samples, you will first need to remove references to the Sync Framework assemblies and then re-add the assembly references to the projects. Otherwise, you will see &quot;type or namespace
 name could not be found&quot; compilation errors.</p>
<hr>
<p><img src="19002-msf_logo.jpg" alt="" width="639" height="56"></p>
</div>
</div>
