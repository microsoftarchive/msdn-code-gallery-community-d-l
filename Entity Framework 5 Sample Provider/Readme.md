# Entity Framework 5 Sample Provider
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- SQL Server
- ADO.NET Entity Framework
- Entity Framework
## Topics
- ADO.NET Entity Framework
- Entity Framework Provider
## Updated
- 12/16/2014
## Description

<h1>This sample only applies to&nbsp;Entity Framework 5</h1>
<p><em>Entity Framework 6&nbsp;introduces some changes&nbsp;for providers, in particular namespace changes and some new optimizations that providers can optionally implement, such as a more efficient translation for Enumerable.Contains(), among others.
</em></p>
<p><em>Rather than working with a separate sample, for EF6 we recommend&nbsp;looking at the actual implementation of the providers for SQL Server and SQL Server CE, which&nbsp;are included in our open source repository at
<a href="http://entityframework.codeplex.com">http://entityframework.codeplex.com</a>.
<em>For more information about implementing Entity Framework 6 providers,&nbsp;consult the EF documentation at
</em><a href="http://msdn.com/EF"><em>http://msdn.com/EF</em></a><em>. </em></em></p>
<p><em>Information about Entity Framework 7 and its new provider&nbsp;API can be currently found in the EF7 open source repository at
<a href="https://github.com/aspnet/entityframework/">https://github.com/aspnet/entityframework/</a>.
</em></p>
<h1>Introduction</h1>
<p>This is a sample Entity Framework&nbsp;provider for SQL Server that demonstrates how to&nbsp;create a custom provider that supports the new features introduced in Entity Framework 5 -&nbsp;spatial types, table valued functions and stored procedures with
 multiple result sets.</p>
<h1><span>Building the Sample</span></h1>
<p>Visual Studio 11 and .NET Framework 4.5 are required to build this sample. Tests are using xUnit testing framework. Required packages will be downloaded from nuget automatically if needed when building the project.</p>
<h1><span style="font-size:20px">Testing the Sample</span></h1>
<p>Tests require the NorthwindEF5 database. To create the database use the CreateNorthwindEFDB.sql script from the NorthwindEFModel\Database folder (e.g. sqlcmd -S .\sqlexpress -E -i CreateNorthwindEFDB.sql)</p>
<p>Tests are using xUnit testing framework. To be able to run tests inside the Visual Studio 11 you need&nbsp;to install a test runner. You can get one here:&nbsp;<a href="http://visualstudiogallery.msdn.microsoft.com/463c5987-f82b-46c8-a97e-b1cde42b9099">http://visualstudiogallery.msdn.microsoft.com/463c5987-f82b-46c8-a97e-b1cde42b9099</a></p>
<h1><span style="font-size:20px">Description</span></h1>
<p>The sample Entity Framework ADO.NET provider for SQL server shows how to build your own provider for Entity Framework in particular,</p>
<ul>
<li>Creating a povider factory </li><li>Implementing provider services </li><li>Implementing spatial services </li><li>Writing a provider manifest </li><li>Generating&nbsp;SQL queries and commands </li><li>Implementing schema views for reverse engineering (including TFVs) </li></ul>
<p>The project contains also a sample Data Designer Extensibility (DDEX) provider that can plug-in into the Entity Framework Designer design time experience in Visual Studio.</p>
<h1><span>Projects included in the sample</span></h1>
<ul>
<li>SampleEntityFrameworkProvider - Entity Framework Sample Provider </li><li>ProviderTests - tests for the Sample Entity Framework Provider </li><li>NorthwindEFModel - Entity Framework model shared by projects. Based on Northwind database.
</li><li>FunctionStubGenerator - Used to generate SampleEntityFrameworkProvider\SampleProviderFunctions.cs file
</li><li>EdmGenTests - Reverse-engineer the database using the Entity Framework Sample Provider
</li><li>DdexProvider - Sample Data Designer Extensibility (DDEX) provider </li></ul>
<h1>More Information</h1>
<p>Useful links:</p>
<ul>
<li><a href="http://blogs.msdn.com/b/adonet/">http://blogs.msdn.com/b/adonet/</a>&nbsp;ADO.NET team blog
</li><li><a href="http://archive.msdn.microsoft.com/EFSampleProvider">http://archive.msdn.microsoft.com/EFSampleProvider</a> - Sample provider for Entity Framework 4
</li><li><a href="http://blogs.msdn.com/b/adonet/archive/2011/01/05/writing-an-ef-enabled-ado-net-provider.aspx">http://blogs.msdn.com/b/adonet/archive/2011/01/05/writing-an-ef-enabled-ado-net-provider.aspx</a>
</li><li><a href="http://blogs.msdn.com/b/adonet/archive/2007/03/16/ado-net-orcas-sample-provider.aspx">http://blogs.msdn.com/b/adonet/archive/2007/03/16/ado-net-orcas-sample-provider.aspx</a>&nbsp;
</li></ul>
