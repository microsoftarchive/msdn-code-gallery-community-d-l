Purpose
=======
This sample demonstrates how to use the Execute Process Task.

Description
===========
This sample transfers data from a database table into a file. An Execute Process Task is used to
ensure that the file is not Read-Only before the data is loaded into the file. The most commonly
used properties of the Execute Process Task are the "Executable" property and the "Arguments" 
property.

Before running the package
==========================

External dependencies
---------------------

This sample assumes that:

You have already downloaded and attached to a local, default instance of SQL Server the 
AdventureWorks sample database from codeplex.com.
The SQL Server instance hosting the AdventureWorks database uses Windows Authentication, and your 
user account has access to the AdventureWorks database.
You have attached the database with the name, "AdventureWorks". If the instance of the 
AdventureWorks sample database you want to use is attached to another instance and/or the name of 
the database as attached is not "AdventureWorks" edit the AdventureWorks connection manager.

Configuration
-------------
Edit the "Flat File Connection Manager" to specify that path where the file "Department.txt" is
located.
Note that, while the "Department.txt" file that is included in this sample is initially read-only,
every time the package is run, "Department.txt" will be set read-write. So, if you have already run
the package once, you won't notice any change unless you manually change "Department.txt" back to 
read-only before running the package, again.

Side effects
===========
This sample will insert data to the a file named "Department.txt" located at the path specified in
the "Flat File Connection Manager". You may modify the path by changing the Flat File Connection
Manager.