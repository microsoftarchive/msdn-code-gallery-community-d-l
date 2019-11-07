Purpose
=======
This sample demonstrates how to use a Lookup component that loads its reference data from a cache file.

Important points
================
This sample has two packages:
* Create the cache.dtsx
* Lookup values in the cache.dtsx

The "Create the cache.dtsx" package provides an example of creating the cache file.  The "Lookup
values in the cache.dtsx" package provides an example of using the Lookup component with a cache
file.

Before running the packages
===========================

Configuration
-------------
Set the value of the "cacheFileDirectory" project parameter to the path to a directory that you
want to create the cache file in.  Don't inclue a trailing path separator.

External dependencies
---------------------
This sample assumes that you have already downloaded and attached to a local, default instance
of SQL Server the AdventureWorks2008 sample database for SQL Server Denali from codeplex.com. If
the instance of the AdventureWorks2008 sample database you want to use is attached to another
instance, edit the AdventureWorks2008R2 project connection manager.

Side-effects of running the packages
------------------------------------
Running the "Create the cache" package will create a file named "Lookup cache.caw" in the directory
you specified in the "cacheFileDirectory" project parameter.  You can safely delete this directory
when you're finished with this sample.

To run the sample
-----------------
1. Execute the "Create the cache" package.  This will create the cache file on disk that the
   "Lookup values in the cache" package will use.
2. Execute the "Lookup values in the cache" package.  View the results in the data viewer.