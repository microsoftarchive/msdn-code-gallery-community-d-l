Copyright (c) Microsoft Corporation.  All rights reserved.


Oracle to CE End-To-End SharingAppDemo Sample Application

This application demonstrates how to use Sync Services for ADO.NET v3 to configure and execute peer-to-peer sychronization between an Oracle database and one or more SQL Server Compact databases.

What is Demonstrated in This Sample?

- Using DbSyncProvider to write a custom Oracle provider that can be synced with other Sync Services db providers.
- Synchronizing an Oracle server database scope with multiple instances of a Compact client database.
- Two ways to configure and synchronize a Compact database: full initialization and snapshot initialization.
- Configuration of an Oracle DbSyncProvider and SqlCeSyncAdapter objects.
- A set of queries and stored procedures for Oracle DbSyncProvider commands.
 

How Do I Install the Application?

1- Connect to an instance of Oracle, and open and execute peer1_setup.sql and then peer1_procs.sql.
2- Open demo.sql and execute the "Configure scope members" and "Insert Sample Data In Tables" sections at the top of the script.
4- In Visual Studio, open the SharingAppDemo-OracleToCEProviderEndToEnd solution.  You must have the Oracle client libraries installed. The project also references SqlCE 2.5 SP1.
5- Build the project.
6- You are ready to go.


What do the Individual CS Files Contain? 

App directory - Contains all the code files for the Winforms app.
 App\CeCreationUtilities.cs - Contains utility classes that the app uses to handle string constants and hold client database information.
 App\CESharingForm.cs - Main entrance point for the Winforms app. Contains all GUI eventing/OnClick logic. 
 App\NewCEClientCreationWizard.cs - New wizard app that is used to gather user information to configure and provision a new Compact client database.
 App\ProgressForm.cs - Form app that shows progress information for each SyncOrchestrator.Synchronize() call.
 App\OracleDBSyncProvider.cs - The Oracle DbSyncProvider
 App\Resource.resx and App\Resources.Designer.cs - Resource files. 
 App\SharinApp.cs - Contains the Main function that launches a new instance of the CESharingForm class.
 App\SynchronizationHelper.cs - The main class that handles configuration of server side DbSyncProvider and client side SqlCESyncProvider instances. Short instructions are included for each method in the class:
	CheckAndCreateCEDatabase() - Utility function that creates an empty Compact database.
	CheckIfProviderNeedsSchema() - Sample that demonstrates how a Compact provider would determine if the underlying database needs schema or not.
	ConfigureCESyncProvider() - Sample that demonstrates how to configure SqlCeSyncProvider.
	ConfigureDBSyncProvider() - Sample that demonstrates how to configure the Oracle DbSyncProvider.
	provider_*() - Sample client side event registration code that demonstrates how to handle specific events raised by the sync runtime.
 App\TablesViewControl.cs - Custom user control that displays values from the two sample tables (orders and order_details), based on the client and server connections that are passed in. 
 
Setup directory - Contains the server provisioning .sql files.


How Do I Use the Sample?

1. Install the application as described in the "How to install" section.
2. Run the sample app and pass in an Oracle connection string as a command line argument. 
3. If the sample is correctly installed, values from the orders and order_details should display in the datagrid on the "Server" tab.
4. The Synchronize button is disabled until at least one Compact client is added. Add a new Compact client database by clicking "Add CE Client". Options for creating a new client in the New CE Creation Wizard:
	* Full initialization - Create an empty Compact database, get the schema from the server, create the schema on the client, and get all data from the server on the first Synchronize() call.
	* Snapshot initialization - Export an existing Compact database, initialize that snapshot and receive only incremental changes from the server on the first Synchronize() call.
5a. For full initialization, select the location and file name. 
5b. For snapshot initialization, select the .sdf file of an existing client (in the same scope) and pick the location and name for the exported database.
6. On clicking OK, a new tab with the name "Client#" should be added to the main form. After the client is synchronized, clicking that tab displays values for the tables orders and order_details in that Compact database.
7. Batching can be enabled by setting a non zero value in the Batch size text box. By default batching is turned off.
7.a Batching location can be modified from by clicking on the Change button.
8. To synchronize, select source and destination providers, and click Synchronize.
9. Make changes to the server or client database tables and then try to synchronize the peers to confirm that changes are synchronized.
