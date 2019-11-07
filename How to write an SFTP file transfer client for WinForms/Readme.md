# How to write an SFTP file transfer client for WinForms
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- .NET Framework
## Topics
- SFTP
- SSH
## Updated
- 05/28/2014
## Description

<h1>Introduction</h1>
<p>This application demonstrates how to write an SFTP Client Windows Forms<em>.</em><em></em></p>
<h1><span>Building the Sample</span></h1>
<p>In order to build the sample project, you need the commercial <a href="http://www.componentpro.com/ftp.net/">
Ultimate SFTP</a> component which can be downloaded at <a href="http://www.componentpro.com/download/?name=UltimateFtp">
Ultimate SFTP Download Page</a>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The examples demonstrates how to</p>
<ul>
<li>Login to an SFTP server </li><li>Setup proxy connection </li><li>Setup bandwidth throttling </li><li>List a directory </li><li>Transfers files asynchrounously </li><li>Upload and download multiple files </li><li>Cancel an operation (can be a file transfer or file deletion) </li><li>Handling events of the Sftp class </li><li>Display a progress bar while transferring or doing multi file operation<em></em>
</li><li>Using latest .NET <strong>async</strong> and <strong>await</strong> keywords for asynchronous operations and XXXAsync methods
</li></ul>
<p>More information about the asynchronous Download methods:</p>
<p>Use <a href="http://www.componentpro.com/doc/sftp/ComponentPro.Net.Sftp.DownloadFileAsync.htm">
DownloadFileAsync</a> methods to asynchronously download a remote file from the SFTP server. These methods download a remote file from the SFTP server asynchronously with execution occurring on a new thread, therefore they allow your next line of code to execute
 immediately.</p>
<p>In Task-based Asynchronous programs, the single asynchronous method represents the initiation and completion of an asynchronous operation. You may create the continuation code either explicitly, through methods on the Task class (for example, ContinueWith)
 or implicitly, by using language support built on top of continuations (for example,
<strong>await</strong> in C#, <strong>Await</strong> in Visual Basic).</p>
<p>In .NET 4.5 it is recommended to implement the Task-based Asynchronous Pattern.</p>
<p>In Event-based Asynchronous programs, the event <a href="http://www.componentpro.com/doc/sftp/ComponentPro.Net.Sftp.DownloadFileCompleted.htm">
DownloadFileCompleted</a> is raised when the <a href="http://www.componentpro.com/doc/sftp/ComponentPro.Net.Sftp.DownloadFileAsync.htm">
DownloadFileAsync</a> completes. In the event handler method of the <a href="http://www.componentpro.com/doc/sftp/ComponentPro.Net.Sftp.DownloadFileCompleted.htm">
DownloadFileCompleted</a>, you can check if there were any errors by using the <a href="http://msdn.microsoft.com/en-us/library/system.componentmodel.asynccompletedeventargs.error">
Error</a> property of the event data object.</p>
<p>The following code snippet demonstrates how to connect to an SFTP server.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using ComponentPro.Net;

...

// Create a new instance.
Sftp client = new Sftp();

// Connect to the SFTP server.
client.Connect(&quot;localhost&quot;);

// Authenticate.
client.Authenticate(&quot;test&quot;, &quot;test&quot;);

// ... 
 
// Download remote file '/test.dat' to 'c:\test.dat' 
long transferred = await client.DownloadFileAsync(&quot;/test.dat&quot;, &quot;c:\\test.dat&quot;);

// ...

Console.WriteLine(&quot;Bytes transferred: &quot; &#43; transferred);

// Disconnect.
client.Disconnect();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ComponentPro.Net;&nbsp;
&nbsp;
...&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;new&nbsp;instance.</span>&nbsp;
Sftp&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Sftp();&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Connect&nbsp;to&nbsp;the&nbsp;SFTP&nbsp;server.</span>&nbsp;
client.Connect(<span class="cs__string">&quot;localhost&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Authenticate.</span>&nbsp;
client.Authenticate(<span class="cs__string">&quot;test&quot;</span>,&nbsp;<span class="cs__string">&quot;test&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;...&nbsp;</span>&nbsp;
&nbsp;&nbsp;
<span class="cs__com">//&nbsp;Download&nbsp;remote&nbsp;file&nbsp;'/test.dat'&nbsp;to&nbsp;'c:\test.dat'&nbsp;</span>&nbsp;
<span class="cs__keyword">long</span>&nbsp;transferred&nbsp;=&nbsp;await&nbsp;client.DownloadFileAsync(<span class="cs__string">&quot;/test.dat&quot;</span>,&nbsp;<span class="cs__string">&quot;c:\\test.dat&quot;</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;...</span>&nbsp;
&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Bytes&nbsp;transferred:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;transferred);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Disconnect.</span>&nbsp;
client.Disconnect();</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p>More example can be found at <a href="http://www.componentpro.com/doc/sftp">http://www.componentpro.com/doc/sftp</a> and
<a href="http://www.sftpcomponent.net">http://www.sftpcomponent.net</a></p>
