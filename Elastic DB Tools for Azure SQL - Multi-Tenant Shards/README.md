# Elastic DB Tools for Azure SQL - Multi-Tenant Shards
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Entity Framework
- Windows Azure SQL Database
- Row-Level Security
## Topics
- Security
- Entity Framework
- Scalability
- Sharding
- Multi-Tenant Applications
- Elastic Scale
- Row-Level Security
- Elastic Database
## Updated
- 06/21/2016
## Description

<h1>Introduction</h1>
<p>Elastic Database Tools and Row-Level Security (in preview) offer a powerful set of capabilities for flexibly and efficiently scaling the data tier of a multi-tenant application with Azure SQL Database. This sample shows how you can use these technologies
 to build an application with a highly scalable data tier that supports multi-tenant shards, using ADO.NET SqlClient and/or Entity Framework.</p>
<h1>Building the Sample</h1>
<p>After downloading the sample in Visual Studio, you first need to create three new databases in Azure SQL DB (one shard map manager, and two example shards). Once the databases are up and running in Azure, fill in the placeholders for your Azure SQL DB credentials
 and the database names in the beginning of the file Program.cs. You are then ready to build and run the sample. When building the sample, Visual Studio will download the Elastic Database, Entity Framework, and Transient Fault Handling libraries from NuGet.</p>
<p>By default, tenants will be able to access each other's rows. In order to enable filtering with Row-Level Security, you will need to run the included EnableRLS.sql script to create a security policy on both shards.&nbsp;</p>
<h1>Description</h1>
<p>This sample extends the&nbsp;<a href="https://code.msdn.microsoft.com/Elastic-Scale-with-Azure-bae904ba#content">Elastic DB Tools for Azure SQL - Entity Framework Integration</a>&nbsp;sample by adding support for multi-tenant shards. It builds a simple console
 application for creating blogs and posts, with four tenants and two multi-tenant shard databases.</p>
<p>The most important change to the original Entity Framework sample is in the DbContext subclass. In addition to enabling Data Dependent Routing here, this sample also sets CONTEXT_INFO for the returned connection to the specified sharding key (or TenantId).
 This way, a Row-Level Security policy within each shard database can filter rows based on this value for the connection.</p>
<h1>Next Steps</h1>
<p>For more information, see the&nbsp;<a href="http://go.microsoft.com/?linkid=9862897">Elastic Database Tools Documentation Map</a>&nbsp;or the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/dn765131.aspx">Row-Level Security reference</a>&nbsp;on MSDN.</p>
