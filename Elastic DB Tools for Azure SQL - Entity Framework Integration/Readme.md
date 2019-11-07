# Elastic DB Tools for Azure SQL - Entity Framework Integration
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Entity Framework
- Windows Azure SQL Database
## Topics
- Entity Framework
- Scalability
- Sharding
- Elastic Scale
- Elastic Database
## Updated
- 06/21/2016
## Description

<h1>Introduction</h1>
<p>Elastic database tools for Azure SQL DB enable the data-tier of an application to scale out and in using database sharding patterns, significantly streamlining the development and management of cloud database applications. This sample shows how applications
 you develop with Entity Framework can benefit from sharding using elastic database tools.</p>
<h1>Building the Sample</h1>
<p>After downloading the sample in Visual Studio, you first need to create three new databases in Azure SQL DB. Once the databases are up and running in Azure,&nbsp;fill in the place holders for your Azure SQL DB credentials and the database names in the beginning
 of the file Program.cs. You are then ready to build and run the sample. When building the sample, Visual Studio will download the libraries for elastic database lient, Entity Framework and Transient Fault Handling.</p>
<h1>Description</h1>
<p>The sample adopts the popular blogging example from Entity Framework and highlights the changes that are necessary to embrace sharding at the data tier for your Entity Framework application. The most important changes are about creating your DbContext instances.
 Instead of using the default DbContext subclasses, the sample introduces a different overload of the DbContext constructors in the DbContext subclass. That constructor now also takes the information about the sharding metadata by means of the ShardMap input
 parameter. This allows the new DbContext subclass to broker connections across many separate Azure SQL Db databases using shard maps maintained by the client library. With this limited set of changes to the places in your code where you create new DbContext,
 you can enable Data Dependent Routing through the elastic database client library for your EF applications.</p>
<p>Another important aspect of Entity Framework is its ability to bootstrap the schema of the application on an empty new database using Entity Framework migrations. This is particularly compelling in the context of a sharded data tier approach where new databases
 are created as the application needs more capacity. This sample also illustrates how you can combine Entity Framework migrations with the registration of new shards using elastic database tools. That way, you do not have to worry about creating the database
 schema manually on new shards, just like with regular EF applications.</p>
<h1>Next Steps</h1>
<p>Elastic database tools for Azure SQL DB provide you with powerful capabilities to scale the data tier of your cloud applications in tandem with the changing capacity needs of your business. If you enjoyed this sample application, continue further exploring
 elastic database tools and theircapabilities here: <a href="http://go.microsoft.com/?linkid=9862897">
http://go.microsoft.com/?linkid=9862897</a>.</p>
