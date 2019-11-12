# Lookup with cache file
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server
- SSIS
- SQL Server Integration Services
## Topics
- SsisLookupTransform
## Updated
- 09/29/2011
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use a Lookup component in SQL Server Integration Services that loads its reference data from a cache file.</p>
<h1>Requirements</h1>
<p>This sample requires SQL Server code name Denali CTP3 or later.</p>
<p>&nbsp;</p>
<h1>Important points</h1>
<p>This sample has two packages:</p>
<ul>
<li>Create the cache.dtsx </li><li>Lookup values in the cache.dtsx </li></ul>
<p>The &quot;Create the cache.dtsx&quot; package provides an example of creating the cache file.&nbsp; The &quot;Lookup<br>
values in the cache.dtsx&quot; package provides an example of using the Lookup component with a cache<br>
file.</p>
<p>&nbsp;</p>
<h1>Before running the packages</h1>
<h2>Configuration</h2>
<p>Set the value of the &quot;cacheFileDirectory&quot; project parameter to the path to a directory that you<br>
want to create the cache file in.&nbsp; Don't inclue a trailing path separator.</p>
<h2>External dependencies</h2>
<p>This sample assumes that you have already downloaded and attached to a local, default instance<br>
of SQL Server the AdventureWorks2008 sample database for SQL Server Denali from codeplex.com. If<br>
the instance of the AdventureWorks2008 sample database you want to use is attached to another<br>
instance, edit the AdventureWorks2008R2 project connection manager.</p>
<h2>Side-effects of running the packages&nbsp;</h2>
<p>Running the &quot;Create the cache&quot; package will create a file named &quot;Lookup cache.caw&quot; in the directory<br>
you specified in the &quot;cacheFileDirectory&quot; project parameter.&nbsp; You can safely delete this directory<br>
when you're finished with this sample.</p>
<h2>To run the sample</h2>
<p>1. Execute the &quot;Create the cache&quot; package.&nbsp; This will create the cache file on disk that the<br>
&nbsp;&nbsp; &quot;Lookup values in the cache&quot; package will use.<br>
2. Execute the &quot;Lookup values in the cache&quot; package.&nbsp; View the results in the data viewer.</p>
<h1><em>&nbsp;</em></h1>
