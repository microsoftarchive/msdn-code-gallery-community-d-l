# FTP Files to Server Using the WebClient Class UploadFile Method
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- Windows Application
- FTP
## Updated
- 06/28/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Use the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.NET.WebClient.aspx" target="_blank" title="Auto generated link to System.NET.WebClient">System.NET.WebClient</a> UploadFile method to copy files to an FTP server.</span></p>
<h1><span>Running the Sample</span></h1>
<p><span style="font-size:small">The Debug tab in the Visual Studio project has command line arguments set up for running the application in the debugger.</span></p>
<p><span style="font-size:small">Change the switch keys to connect to your FTP site as follows:</span></p>
<p style="padding-left:30px"><span style="font-size:small">-source &quot;&lt;local folder path&gt;&quot;<br>
-ftpdest &quot;ftp://&lt;host&gt;/&lt;directory path&gt;&quot;<br>
-user &lt;user name&gt;<br>
-pwd &lt;password&gt;</span></p>
<p><span style="font-size:small">User and pwd are needed when a user name and password are required with the FTP connection. Remove these arguments if connecting by Anonymous FTP logon.</span></p>
<p><span style="font-size:small">Example of running from the cmd window:<br>
</span></p>
<p><span style="font-size:small">&gt;WebClientFtp -source &quot;C:\test&quot; -ftpdest &quot;ftp://ftp.acme.biz/test&quot; -user ftpuser -pwd passwrd<br>
</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">This sample demonstrates a simple way to create a command-line utility that copies files to your FTP server. The requirement here is that files on the workstation need to be FTP'd to a remote FTP server at scheduled intervals.
</span></p>
<p><span style="font-size:small">All files in the given source path are copied to the FTP server (excluding subfolders). An existing FTP directory path is supplied with the -ftpdest argument. Any existing files on the FTP server that are named the same as the
 source files will be replaced.<br>
</span></p>
<p><span style="font-size:small">FTP\UploadFiles.cs holds the UploadFiles class. The UploadFiles constructor takes the args array and copies the arguments as Key-Value pairs&lt;string, string&gt; to
<strong>ArgList</strong>. If requried arguments are missing, this is reported and the application exits. Otherwise, a member instance of WebClient (<strong>_webClient</strong>) is created.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;args()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;key&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;arg&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;args&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;arg(<span class="visualBasic__number">0</span>)&nbsp;=&nbsp;<span class="visualBasic__string">&quot;-&quot;</span>c&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;key&nbsp;=&nbsp;arg.ToLower&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;key&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;ArgList.ContainsKey(key)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArgList.Add(key,&nbsp;arg)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;ArgList.ContainsKey(<span class="visualBasic__string">&quot;-source&quot;</span>))&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;(<span class="visualBasic__keyword">Not</span>&nbsp;ArgList.ContainsKey(<span class="visualBasic__string">&quot;-ftpdest&quot;</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Usage:&nbsp;WebClientFtp&nbsp;-source&nbsp;&lt;path-to-local-folder&gt;&nbsp;-ftpdest&nbsp;&lt;uri-ftp-directory&gt;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[&nbsp;-user&nbsp;&lt;userName&gt;&nbsp;-pwd&nbsp;&lt;password&gt;&nbsp;]&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;-source&nbsp;and&nbsp;-ftpdest&nbsp;are&nbsp;required&nbsp;arguments&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey(<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Environment.<span class="visualBasic__keyword">Exit</span>(<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_webClient&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;WebClient()&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
<p><span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;<span style="font-size:small">Next (in Main), call the <strong>CopyFolderFiles</strong> method to copy files from -source to -ftpdest</span>.
<span style="font-size:small">CopyFolderFiles uses System.IO.Directory.GetFile to collect an array of files to be copied. Then
<strong>ftpUpFile</strong> is called once for each file to upload these files to the
<strong>ftpDest</strong> URI path. If ftpUpFile returns false, then the application waits for the time in milliseconds&nbsp;specified in the
</span><span style="font-size:small"><strong>WaitInterval </strong>settings property.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CopyFolderFiles()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sPath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sPath&nbsp;=&nbsp;ArgList(<span class="visualBasic__string">&quot;-source&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Directory.Exists(sPath)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'get&nbsp;all&nbsp;files&nbsp;in&nbsp;path</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;files()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;files&nbsp;=&nbsp;Directory.GetFiles(sPath,&nbsp;<span class="visualBasic__string">&quot;*.*&quot;</span>,&nbsp;SearchOption.TopDirectoryOnly)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'if&nbsp;user&nbsp;and&nbsp;password&nbsp;exist,&nbsp;set&nbsp;credentials</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(ArgList.ContainsKey(<span class="visualBasic__string">&quot;-user&quot;</span>))&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;(ArgList.ContainsKey(<span class="visualBasic__string">&quot;-pwd&quot;</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_webClient.Credentials&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NetworkCredential(ArgList(<span class="visualBasic__string">&quot;-user&quot;</span>),&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ArgList(<span class="visualBasic__string">&quot;-pwd&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;UploadCompleted&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;wait&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;My.Settings.WaitInterval&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ftpDest&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;ArgList(<span class="visualBasic__string">&quot;-ftpdest&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'loop&nbsp;through&nbsp;files&nbsp;in&nbsp;folder&nbsp;and&nbsp;upload</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;file&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;files&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UploadCompleted&nbsp;=&nbsp;ftpUpFile(file,&nbsp;ftpDest)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;UploadCompleted&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(wait)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wait&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1000</span>&nbsp;<span class="visualBasic__com">'wait&nbsp;an&nbsp;extra&nbsp;second&nbsp;after&nbsp;each&nbsp;failed&nbsp;attempt</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Loop</span>&nbsp;Until&nbsp;UploadCompleted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;&nbsp;</div>
<p><span style="font-size:small">Finally, <strong>ftpUpFile</strong> calls the <strong>
UploadFile</strong> method to FTP the file to the server. The FTP STOR command is called by UploadFile in this case. The same method can also be used with an HTTP URI. HTTP POST is used to transfer to a site that has write permissions set.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ftpUpFile(<span class="visualBasic__keyword">ByVal</span>&nbsp;filePath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;ftpUri&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Uploading&nbsp;file:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;filePath&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&nbsp;To:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ftpUri)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'create&nbsp;full&nbsp;uri&nbsp;path</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;file&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;ftpUri&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;/&quot;</span>&nbsp;&#43;&nbsp;Path.GetFileName(filePath)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'ftp&nbsp;the&nbsp;file&nbsp;to&nbsp;Uri&nbsp;path&nbsp;via&nbsp;the&nbsp;ftp&nbsp;STOR&nbsp;command</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'(ignoring&nbsp;the&nbsp;the&nbsp;Byte[]&nbsp;array&nbsp;return&nbsp;since&nbsp;it&nbsp;is&nbsp;always&nbsp;empty&nbsp;in&nbsp;this&nbsp;case)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_webClient.UploadFile(file,&nbsp;filePath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="visualBasic__string">&quot;Upload&nbsp;complete.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'WebException&nbsp;is&nbsp;frequenty&nbsp;thrown&nbsp;for&nbsp;this&nbsp;condition:&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&quot;An&nbsp;error&nbsp;occurred&nbsp;while&nbsp;uploading&nbsp;the&nbsp;file&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:small">So there you have it. A command-line utility best used in a scheduled task for copying (updating) files to a remote FTP server.</span></p>
<h1>Source Code Files</h1>
<p><strong><span style="font-size:small">C#</span></strong></p>
<ul>
<li><span style="font-size:small">Program.cs - Main entry point</span> </li><li><span style="font-size:small">FTP\UploadFiles.cs - UploadFiles class</span> <strong>
?</strong> </li></ul>
<p><strong><span style="font-size:small">VB.NET</span></strong></p>
<ul>
<li><span style="font-size:small">Module1.vb</span> </li><li><span style="font-size:small">FTP\UploadFiles.vb - UploadFiles class</span> <strong>
?</strong> </li></ul>
<p><strong><span style="font-size:medium">More Information</span></strong></p>
<p><span style="font-size:small">For more information on WebClient: </span><br>
<a title="WebClient" href="http://msdn.microsoft.com/en-us/library/system.net.webclient.aspx">http://msdn.microsoft.com/en-us/library/system.net.webclient.aspx</a></p>
<p><span style="font-size:small">The interesting note about the UploadFile method is that on a production FTP site there will be failed file uploads. About 1 in 200 files fail in my experience. This will cause UploadFile to throw an exception. I find that if
 you pause some number of seconds, and then retry the upload, it works the next try.</span></p>
<div class="endscriptcode"><span style="font-size:small">&nbsp;</span></div>
<p>&nbsp;</p>
