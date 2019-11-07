Purpose
=======
This sample demonstrates how to use the derived column component. In this example we select the
names of everyone from the People.People table and then perform the following actions through
derived column transforms:

1.) Cleanse the 'MiddleName' field by replacing NULL values with an empty string in preparation for
the next step.
2.) Create a new column named 'FullName' which concatenates the FirstName, MiddleName, and LastName
fields.

Each step can be viewed by placing Data Viewers on the paths between components.

Before running the package
==========================

External dependencies
---------------------
This sample assumes that:
- You have already downloaded and attached to a local, default instance of SQL Server the
AdventureWorks sample database from codeplex.com.
- The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and
your user account has access to the AdventureWorks database.
- You have attached the database with the name, "AdventureWorks". If the instance of the
AdventureWorks sample database you want to use is attached to another instance and/or the name
of the database as attached is not "AdventureWorks" edit the AdventureWorks connection manager.