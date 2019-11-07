# Data Flow File to File
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SQL Server Integration Services
- SQL Server Integration Services 2012
## Topics
- SsisDataflowTask
## Updated
- 04/20/2012
## Description

<h1>Purpose</h1>
<p>This sample demonstrates how to use the Flat file connection manager and Flat fileSource/Destination adapter to transfer data between two files.&nbsp;The project contains one package and one txt file.</p>
<p>The package contains a dataflow composed of one flat file source and one flat file destination.</p>
<p>The flat file source uses a flat file connection manager that pulls data from the text file,&nbsp;and is configured to use the | character as column delimiter.</p>
<p>The flat file destination uses a flat file connection manager that is configured to use Tab ascolumn delimiter, and specify that the first row is column names.</p>
<h1>Configuration</h1>
<p>You will need to change the file path of the &quot;Flat File Src&quot; connection manager to the path of the &quot;Address.txt&quot; file contained in this project on your computer, and configure the path of the &quot;Flat File Dest&quot; connection manager to where you want the package
 to generate the desintation file.</p>
<h1>Further reading</h1>
<p>For more information on the Flat File Source adapter, see this topic:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms139941.aspx">http://msdn.microsoft.com/en-us/library/ms139941.aspx</a></p>
<p>For more information on the Flat File Destination adapter, see this topic:&nbsp;<a href="http://msdn.microsoft.com/en-us/library/ms141668.aspx">http://msdn.microsoft.com/en-us/library/ms141668.aspx</a></p>
