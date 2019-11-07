# FTP Client for WinForms using Ultimate FTP library
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- .NET
## Topics
- FTP
- FTP/SSL
## Updated
- 05/28/2014
## Description

<h1>Introduction</h1>
<p>This application demonstrates how to write an FTP Client Windows Forms<em>.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>In order to build the sample project, you need the commercial <a href="http://www.componentpro.com/ftp.net/">
Ultimate FTP</a> component which can be downloaded at <a href="http://www.componentpro.com/download/?name=UltimateFtp">
Ultimate FTP Download Page</a>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The examples demonstrates how to</p>
<ul>
<li>Login to an FTP server </li><li>Setup proxy connection </li><li>Setup bandwidth throttling </li><li>List a directory </li><li>Transfers files asynchrounously </li><li>Upload and download multiple files </li><li>Cancel an operation (can be a file transfer or file deletion) </li><li>Handling events of the Ftp class </li><li>Display a progress bar while transferring or doing multi file operation </li><li>Using latest .NET <strong>async</strong> and <strong>await</strong> keywords for asynchronous operations and XXXAsync methods
</li></ul>
<p>More information about the asynchronous Upload methods:</p>
<p>Use <a href="http://www.componentpro.com/doc/ftp/ComponentPro.Net.Ftp.UploadFileAsync.htm">
UploadFileAsync</a> methods to asynchronously&nbsp;upload a file&nbsp;to&nbsp;the&nbsp;FTP server. These methods&nbsp;upload a file&nbsp;to&nbsp;the&nbsp;server&nbsp;asynchronously with execution occurring on a new thread, therefore they allow your next line
 of code to execute immediately.</p>
<p>In Task-based Asynchronous programs, the single asynchronous method represents the initiation and completion of an asynchronous operation.&nbsp;You may create the continuation code either explicitly, through methods on the Task class (for example, ContinueWith)
 or implicitly, by using language support built on top of continuations (for example,
<strong>await</strong> in C#, <strong>Await</strong> in Visual Basic).</p>
<p><em>In .NET 4.5 it is recommended to implement the Task-based Asynchronous Pattern.</em></p>
<p>In Event-based Asynchronous programs, the event <a href="http://www.componentpro.com/doc/ftp/ComponentPro.Net.Ftp.UploadFileCompleted.htm">
UploadFileCompleted</a> is raised when the <a href="http://www.componentpro.com/doc/ftp/ComponentPro.Net.Ftp.UploadFileAsync.htm">
UploadFileAsync</a> completes. In the event handler method of the <a href="http://www.componentpro.com/doc/ftp/ComponentPro.Net.Ftp.UploadFileCompleted.htm">
UploadFileCompleted</a>, you can check if there were any errors by&nbsp;using the&nbsp;<a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.asynccompletedeventargs.error">Error</a> property of the event data object.</p>
<p><br>
The following code snippet demonstrates how to connect to an FTP server.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using ComponentPro.IO;
using ComponentPro.Net;
using ComponentPro;

...

// Create a new instance.
Ftp client = new Ftp();

// Connect to the FTP server.
client.Connect(&quot;localhost&quot;, 21, FtpSecurityMode.Explicit);

// Authenticate.
client.Authenticate(&quot;test&quot;, &quot;test&quot;);

// ...

// Disconnect.
client.Disconnect();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ComponentPro.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ComponentPro.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ComponentPro;&nbsp;
&nbsp;
...&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;instance.</span>&nbsp;
Ftp&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Ftp();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Connect&nbsp;to&nbsp;the&nbsp;FTP&nbsp;server.</span>&nbsp;
client.Connect(<span class="cs__string">&quot;localhost&quot;</span>,&nbsp;<span class="cs__number">21</span>,&nbsp;FtpSecurityMode.Explicit);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Authenticate.</span>&nbsp;
client.Authenticate(<span class="cs__string">&quot;test&quot;</span>,&nbsp;<span class="cs__string">&quot;test&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;...</span>&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Disconnect.</span>&nbsp;
client.Disconnect();</pre>
</div>
</div>
</div>
<p>More example can be found at <a href="http://www.componentpro.com/doc/ftp">http://www.componentpro.com/doc/ftp</a> and
<a href="http://www.ftpcomponent.net">http://www.ftpcomponent.net</a></p>
