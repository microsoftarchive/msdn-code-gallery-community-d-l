# Elastic DB Tools for Azure SQL - Getting Started
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Windows Azure SQL Database
## Topics
- Scalability
- Sharding
- Elastic Scale
- Elastic Database
## Updated
- 06/21/2016
## Description

<h1>Introduction</h1>
<p>Elastic database tools for Azure SQL DB enable the data-tier of an application to scale out and in using database sharding patterns, significantly streamlining the development and management of cloud database applications. This sample application is the
 companion to the Getting Started document for elastic database tools (<a href="http://go.microsoft.com/fwlink/?LinkID=510913">http://go.microsoft.com/fwlink/?LinkID=510913</a>) and illustrates the developer experience working with the client library.</p>
<h1>Building the Sample</h1>
<p>After downloading the sample project and its code, you first need to edit the configuration settings in the app.config file. This is needed so that the sample has the connection information for your Azure SQL Database server where it will create three sample
 databases for you. Once you have added your connection information to the file, build and run the solution from within Visual Studio. When building the sample, Visual Studio will download the elastic database client library using NuGet. &nbsp;</p>
<p>For a step-by-step tutorial, please see the following <a href="http://channel9.msdn.com/Blogs/Windows-Azure/Elastic-Scale-with-Azure-SQL-Database-Getting-Started">
video</a>.</p>
<h1>Technologies Illustrated</h1>
<p>This sample illustrates some of the main aspects of application development with the elastic database client library. The code sample will introduce you to the following technologies from the library.</p>
<ul>
<li><strong>Shard Map Management</strong>: Shard map management is the ability for an application to manage its shard metadata as it scales in and out across several databases. The sample uses this technology to create and register two Azure SQL DB databases
 as shards that the application will scale across. </li><li><strong>Data Dependent Routing</strong>: Imagine a request coming into the application. Assume that the request contains a sharding key value such as a customer ID or a tenant key. The sample application shows you how to open a database connection from
 your shard map to process the request on the right shard. </li><li><strong>Multi-Shard Queries</strong>: Multi-shard querying helps when several or all shards need to contribute to the overall query result. The sample application shows you how you can easily retrieve aggregate results across shardlets into a single overall
 result set using UNION ALL semantics. </li><li><strong>Adding Capacity</strong>: Increasing capacity at the data tier as your business grows is a common requirement of cloud applications. This sample illustrates how you can provision new capacity for your data tier by using simple shard map operations.
</li></ul>
<h1>Outcome</h1>
<p>Once you have the sample running, the application and its data seamlessly stretch across two Azure SQL DB databases. The fact that some customersIDs map to the first database and some to the second is abstracted from the developer so that you can focus on
 the business logic instead. Clearly, just two shards is not a lot - but we did not want you to pay for more than what the sample minimally needs. You can now easily expand the sample to include a third shard - or even scale the application to stretch across
 100 shards.</p>
<h1>Next Steps</h1>
<p>Elastic database tools for Azure SQL DB provide you with powerful capabilities to scale the data tier of your cloud applications in tandem with the changing capacity needs of your business. If you enjoyed this sample application, continue further exploring
 elastic database tools and capabilities here: <a href="http://go.microsoft.com/?linkid=9862897">
http://go.microsoft.com/?linkid=9862897</a>.</p>
