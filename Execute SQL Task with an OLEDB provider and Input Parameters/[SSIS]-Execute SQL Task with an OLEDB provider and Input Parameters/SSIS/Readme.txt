Execute SQL Task - Input Parameters OLE DB Sample

===========
Description
===========
This sample demonstrates how to use the Execute SQL Task with OLE DB Input Parameters

This project is broken into two packages:

Package 1 (CreateTablePackage.dtsx): Generates a load table with the Execute SQL Task (this is done for convenience to not affect any of your 
existing AdventureWorks data.)

Package 2 (ProcessPackage.dtsx):  Deletes all data in the load table older than the date specified in the project parameter "DeleteDate"
with an Execute SQL Task and then loads a subset of the data from the AdventureWorks Person.Person

===========
Settings
===========
1.) The project parameter AdventureWorks_ConnectionString contains the connection string that points to the adventure works database.
2.) The queries used in the SQL Statements also assume your AdventureWorks database is named 'AdventureWorks'
3.) You must run the CreateTablePackage first, do this by right-clicking the package in Solution Explorer and selecting 'Execute Package'