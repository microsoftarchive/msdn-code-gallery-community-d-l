# Inter-process communication with Memory Mapped Files
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- Shared Memory
- Inter-process Communication
## Updated
- 03/17/2012
## Description

<h1>Inter-process communication&nbsp;with Memory Mapped Files</h1>
<div>I have created a library that allows inter-process communication using a shared Memory Mapped File, in which two or more processes can read and write&nbsp;byte arrays. It provides a method to write and&nbsp;an event that is raised every time new data are
 available. Every operation is performed in background, so&nbsp;your&nbsp;application never&nbsp;blocks&nbsp;while waiting for messages.&nbsp;</div>
<div>&nbsp;</div>
<div>
<h1>Building the Sample</h1>
<div>
<div>The code you can download from this page contains a&nbsp;class library, <strong>
MemoryMappedFileManager</strong>,&nbsp;plus&nbsp;a Windows and a Console application (<em>MemoryMappedFileManagerWindowsApp
</em>and <em>MemoryMappedFileManagerConsole</em>, respectively)&nbsp;that show how to use it. Inside the ZIP file you'll find a single Solution that includes these projects.</div>
<br>
<div>To debug them, first right click on <em>MemoryMappedFileManagerConsole </em>
in the Solution Explorer, then select the <strong>Debug | Start new instance</strong> command from the context menu. Repeat this action for the
<em>MemoryMappedFileManagerWindowsApp</em>. In this way, you can execute both the applications within the same instance of Visual Studio and, of course, you can insert breakpoints in any point of the code.</div>
<div></div>
<div><img src="http://i1.code.msdn.s-msft.com/inter-process-communication-e96e94e7/image/file/54352/1/memorymappedfile.png" alt="" width="695" height="469"></div>
<div></div>
<div>You can write what you want in the Console application. When you press ENTER, the message will be written to the Memory Mapped File that is read from the Windows application. The latter, in turn, writes a message that is read from the Console application
 and written in red.</div>
</div>
<br>
<div>
<h1>Description</h1>
<div>Using the library is simple. Just declare a <strong>MemoryMappedFileCommunicator
</strong>object, specifying its name and dimension (in byte). Then, you need to set
<strong>WritePosition </strong>and <strong>ReadPosition </strong>property:</div>
<div></div>
<div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">MemoryMappedFileCommunicator&nbsp;communicator&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryMappedFileCommunicator(<span class="cs__string">&quot;MemoryMappedShare&quot;</span>,&nbsp;<span class="cs__number">4096</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;process&nbsp;reads&nbsp;data&nbsp;that&nbsp;begins&nbsp;in&nbsp;the&nbsp;position&nbsp;2000&nbsp;and&nbsp;writes&nbsp;starting&nbsp;from&nbsp;the&nbsp;position&nbsp;0.</span>&nbsp;
communicator&nbsp;.ReadPosition&nbsp;=&nbsp;<span class="cs__number">2000</span>;&nbsp;
communicator&nbsp;.WritePosition&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">These are the key properties of the class: because we want to share a single Memory Mapped File between two applications, we must specify the position in which each process reads and writes data. So, the other process must declare
 a <strong>MemoryMappedFileCommunicator </strong>with the same name, but inverted values for the properties:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">MemoryMappedFileCommunicator&nbsp;&nbsp;communicator&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryMappedFileCommunicator(<span class="cs__string">&quot;MemoryMappedShare&quot;</span>,&nbsp;<span class="cs__number">4096</span>);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;This&nbsp;process&nbsp;reads&nbsp;data&nbsp;that&nbsp;begins&nbsp;in&nbsp;the&nbsp;position&nbsp;0&nbsp;and&nbsp;writes&nbsp;starting&nbsp;from&nbsp;the&nbsp;position&nbsp;2000.</span>&nbsp;
communicator&nbsp;.ReadPosition&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
communicator&nbsp;.WritePosition&nbsp;=&nbsp;<span class="cs__number">2000</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Then, we can start the&nbsp;Reader thread, that waits in background for&nbsp;new messages:&nbsp;</div>
</div>
</div>
</div>
</div>
</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Creates&nbsp;an&nbsp;handler&nbsp;for&nbsp;the&nbsp;event&nbsp;that&nbsp;is&nbsp;raised&nbsp;when&nbsp;data&nbsp;are&nbsp;available&nbsp;in&nbsp;the&nbsp;MemoryMappedFile.</span>&nbsp;
communicator&nbsp;.DataReceived&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler&lt;MemoryMappedDataReceivedEventArgs&gt;(communicator&nbsp;_DataReceived);&nbsp;
communicator&nbsp;.StartReader();</pre>
</div>
</div>
</div>
</div>
<div>To write to the shared file, simply invoke the <strong>Write </strong>method on
<strong>MemoryMappedFileCommunicator</strong>. It creates a thread to send the message, so the application will never block:</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">communicator&nbsp;.Write(data);&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;data&nbsp;can&nbsp;be&nbsp;a&nbsp;string&nbsp;or&nbsp;a&nbsp;byte&nbsp;array</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;When the other process receives the message, it raises the
<strong>DataReceived </strong>event:</div>
</div>
<div></div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;communicator&nbsp;_DataReceived(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MemoryMappedDataReceivedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;message&nbsp;=&nbsp;System.Text.Encoding.UTF8.GetString(e.Data);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Finally, remember to dipose the object when you don't need it anymore, in order to release the associated resources:</div>
<div class="endscriptcode"></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">communicator.Dispose();&nbsp;
communicator&nbsp;=&nbsp;<span class="cs__keyword">null</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Internally, <strong>MemoryMappedFileCommunicator </strong>
uses the <a href="http://msdn.microsoft.com/it-it/library/system.io.memorymappedfiles.memorymappedviewaccessor.aspx" target="_blank">
MemoryMappedViewAccessor </a>to access the memory mapped file.</div>
<h1><br>
More Information</h1>
<ul>
<li>Introduction to Memory Mapped Files: <a href="http://msdn.microsoft.com/en-us/library/dd997372.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/dd997372.aspx</a> </li><li>Memory Mapped File namespace: <a href="http://msdn.microsoft.com/it-it/library/system.io.memorymappedfiles.aspx">
http://msdn.microsoft.com/en-us/library/system.io.memorymappedfiles.aspx</a> </li></ul>
