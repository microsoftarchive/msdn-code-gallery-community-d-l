# Execute Package Task with parameters
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- SSIS
- SQL Server Integration Services
- SSIS 2012
- SQL Server Integration Services 2012
## Topics
- SsisScriptTask
- SsisExecutePackageTask
- SsisForeachLoopContainer
## Updated
- 04/09/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:medium">This sample demonstrates how to use the Execute&nbsp;Package Task.</span></p>
<p><span style="font-size:small"><strong>This sample requires SQL Server Integration Services (SSIS) 2012. I assume, and am confident, that it will work on future versions too but of course I cannot guarantee that at the time of writing.</strong><br>
</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:medium">Executing the package contained within the attached zip file will cause the sample to be built behind the scenes so there are no extra steps required for you, the developer, in order to view the results of this sample.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:medium">The sample consists of two packages:</span></p>
<ul>
<li><span style="font-size:medium">Parent.dtsx</span> </li><li><span style="font-size:medium">Child.dtsx</span> </li></ul>
<p><span style="font-size:medium">Parent.dtsx contains a Foreach Loop and within that an Execute Pacxkage Task that executes Child.dtsx. The loop will iterate three times thus Child.dtsx will get executed three times, each time putting up a Message Box containing
 a value passed in from Parent.dtsx via the Executer Package Task.</span></p>
<p><span style="font-size:medium">The concepts demonstrated here include:</span></p>
<ul>
<li><span style="font-size:medium">Executing a package using the Execute Package Task</span>
</li><li><span style="font-size:medium">Passing values to package parameters-Foreach Loop using a Foreach Item Enumerator</span>
</li><li><span style="font-size:medium">Locking a variable within a Script Task</span>
</li><li><span style="font-size:medium">Issuing Message Boxes from a Script Task</span>
</li></ul>
<p><span style="font-size:medium">I hope this sample proves useful to you.&nbsp;</span></p>
<p><span style="font-size:medium">Jamie Thomson</span><br>
<span style="font-size:medium">http://sqlblog.com/blogs/jamie_thomson</span><br>
<span style="font-size:medium">@jamiet</span></p>
