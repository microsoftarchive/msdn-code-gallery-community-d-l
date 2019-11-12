# Interprocess Communication Using .NET 3.5 Named Pipes IO
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- WPF
- .NET Framework
## Topics
- Interop
- Multithreading
- Named Pipe
## Updated
- 05/06/2012
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Use the .NET 3.5 Named Pipes IO for Inter-process communication by implementing a pipe listener on a separate thread. The first sample is a WPF project. It can also be done just as easily in Windows forms. By request, I have
 added a VB.NET Windows Forms sample.<br>
</span></p>
<h1><span>Running the Sample</span></h1>
<p><span style="font-size:small">The <strong>PipeClient</strong> and <strong>PipeServer</strong> are two separate projects in the
<strong>NamedPipes</strong> solution sample. Run the <strong>PipeServer.exe</strong>, before sending strings from
<strong>PipeClient</strong></span>.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The sample demonstrates how to pass string data from clients to a pipe server application that contains a pipe listener that runs on a separate thread within the server application. The main requirement here is that the clients
 are collecting string data and the other application wants to use the string data too, but it needs to collect the information in a background thread.</span></p>
<p><span style="font-size:small">The code snippet below shows the main window class that starts the
<strong>Pipeserve</strong>r thread in the <strong>Window_Loaded</strong> event handler. In Forms, it is the
<strong>Form1_Load</strong> event.<br>
</span></p>
<p><span style="font-size:small">I like to package the thread-owner attributes into a class of all static members. Then it is easy for this class to operate on owner objects.</span></p>
<p><span style="font-size:small">I create an Invoker object for WPF. In Windows Forms this is already implemented for each Form.
</span></p>
<h1><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO.Pipes&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Threading&nbsp;
&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;PipeServer&nbsp;creates&nbsp;a&nbsp;listener&nbsp;thread&nbsp;and&nbsp;waits&nbsp;for&nbsp;messages&nbsp;from&nbsp;clients.</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;Received&nbsp;messages&nbsp;are&nbsp;displayed&nbsp;in&nbsp;Textbox&nbsp;&quot;tbox&quot;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="visualBasic__com">'''&nbsp;&lt;remarks&gt;&lt;/remarks&gt;</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbox.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeServer.pipeName&nbsp;=&nbsp;<span class="visualBasic__string">&quot;testpipe&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeServer.owner&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;pipeThread&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ThreadStart&nbsp;=&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ThreadStart(<span class="visualBasic__keyword">AddressOf</span>&nbsp;PipeServer.createPipeServer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;listenerThread&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Thread&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Thread(pipeThread)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listenerThread.SetApartmentState(ApartmentState.STA)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listenerThread.IsBackground&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listenerThread.Start()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</span></h1>
<p><span style="font-size:small"><strong>Pipeserver.createPipeServer</strong> is the static thread method that is attached to the
<strong>pipeThread</strong> delegate. Once the thread starts, </span><span style="font-size:small"><strong>createPipeServer
</strong>runs in a continuous while loop which waits for a connection and processes data coming in on the pipe's stream.</span></p>
<p><span style="font-size:small">The <strong>NamedPipeServerStream</strong> class has a complex set of constructors and properties. I'm using the 6th constructor and setting all the properties in this constructor. Here are the details on the class:
</span><a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeserverstream.aspx">http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeserverstream.aspx</a></p>
<p><span style="font-size:small"><strong>SetTextbox</strong> is the delegate that gets invoked on the main thread to update Textbox control.</span></p>
<p><span style="font-size:small">I'm using a low-level read hear for flexibility. You could just as well be processing binary data (such as images) with it instead of text.</span></p>
<p><span style="font-size:small">Note that it is important to <strong>Disconnect</strong> the
<strong>PipeServerStream</strong> after processing each incomming message. Otherwise an error will be thrown when the process loops back to wait for the next connection.</span></p>
<p><span style="font-size:small">After all of the bytes are collected as chars in the
<strong>StringBuilder</strong>, the message is posted as a string using the Invoker class. Invoker has an
<strong>Action&lt;string&gt;</strong> delegate (<strong>sDel</strong>) that runs a method delegate that takes a string parameter and is set to
<strong>SetTexbox</strong></span>. <span style="font-size:small">In Windows Forms the
<strong>doSetTextBox </strong>delegate object does the callback to run <strong>SetTexbox</strong> on the owner thread.</span></p>
<h1><span>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;PipeServer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;owner&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;pipeName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;pipeServer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;NamedPipeServerStream&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;BufferSize&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">256</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Delegate</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;SetTextboxDelegate(<span class="visualBasic__keyword">ByVal</span>&nbsp;text&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;doSetTextBox&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SetTextboxDelegate&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;SetTextbox(<span class="visualBasic__keyword">ByVal</span>&nbsp;text&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;TextBox&nbsp;=&nbsp;owner.tbox&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.Text&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Concat(tb.Text,&nbsp;text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;Scroll&nbsp;to&nbsp;the&nbsp;bottom&nbsp;of&nbsp;the&nbsp;textbox</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.SelectionStart&nbsp;=&nbsp;tb.Text.Length&nbsp;-&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.ScrollToCaret()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;createPipeServer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;decdr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Decoder&nbsp;=&nbsp;Encoding.<span class="visualBasic__keyword">Default</span>.GetDecoder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;bytes(BufferSize)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Byte</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;chars(BufferSize)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Char</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;numBytes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;msg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doSetTextBox&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SetTextboxDelegate(<span class="visualBasic__keyword">AddressOf</span>&nbsp;SetTextbox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pipeServer&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NamedPipeServerStream(pipeName,&nbsp;PipeDirection.<span class="visualBasic__keyword">In</span>,&nbsp;<span class="visualBasic__number">1</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeTransmissionMode.Message,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeOptions.Asynchronous)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pipeServer.WaitForConnection()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg.Length&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Do</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;numBytes&nbsp;=&nbsp;pipeServer.Read(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;BufferSize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;numBytes&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;numChars&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decdr.GetCharCount(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;numBytes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decdr.GetChars(bytes,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;numBytes,&nbsp;chars,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;msg.Append(chars,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;numChars)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Loop</span>&nbsp;Until&nbsp;(numBytes&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;(pipeServer.IsMessageComplete)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;decdr.Reset()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;numBytes&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;owner.Invoke(doSetTextBox,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{msg.ToString()})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Loop</span>&nbsp;Until&nbsp;numBytes&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pipeServer.Disconnect()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</div>
</span></h1>
<p><span style="font-size:medium"><strong>PipeClient</strong></span></p>
<p><span style="font-size:small">Here is the <strong>button1_Click</strong> code snippet from the client project. All of the work in the demo client is done on the button click. A
<strong>StreamWriter</strong> is simply connected to the <strong>NamedPipeClientStream</strong>, and the contents of the Textblock are written to the pipe stream for each button click.<br>
</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System.IO&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.IO.Pipes&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;button1.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;pipeClient&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;NamedPipeClientStream&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;NamedPipeClientStream(<span class="visualBasic__string">&quot;.&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;testpipe&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeDirection.Out,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PipeOptions.Asynchronous)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Attempting&nbsp;to&nbsp;connect&nbsp;to&nbsp;pipe...&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pipeClient.Connect(<span class="visualBasic__number">2000</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;The&nbsp;Pipe&nbsp;server&nbsp;must&nbsp;be&nbsp;started&nbsp;in&nbsp;order&nbsp;to&nbsp;send&nbsp;data&nbsp;to&nbsp;it.&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Connected&nbsp;to&nbsp;pipe.&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;sw&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StreamWriter&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StreamWriter(pipeClient)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sw.WriteLine(tbClientText.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tbStatus.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;btnClose_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnClose.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Close()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1><span>Source Code Files</span></h1>
<p><span><strong><span style="font-size:small">WPF<strong> C# </strong></span></strong><span style="font-size:small">sample</span><br>
</span></p>
<ul>
<li><span style="font-size:small">PipeServer\Windows1.xaml(.cs) - implements the PipeServer app</span><em>&nbsp;</em>
</li><li><span style="font-size:small">PipeClient\Windows1.xaml(.cs) - implements the PipeClient test app</span>
</li></ul>
<p><span style="font-size:small"><strong>Windows Forms VB.NET </strong>sample<strong><br>
</strong></span></p>
<ul>
<li><span style="font-size:small">PipeServer\Form1.vb - implements the PipeServer app</span>
</li><li><span style="font-size:small">PipeClient\Form1.vb - implements the PipeClient test app<br>
</span></li></ul>
<h1>More Information</h1>
<p><span style="font-size:x-small"><strong>NamedPipeServerStream Class</strong> -
</span><a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeserverstream.aspx">http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeserverstream.aspx</a></p>
<p><strong><span style="color:#000000; font-family:Arial,Helvetica,sans-serif; font-size:x-small; font-style:normal; font-variant:normal; letter-spacing:normal; line-height:normal; orphans:2; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff; display:inline!important; float:none">NamedPipeClientStream
 Class - </span></strong><a href="http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeclientstream.aspx">http://msdn.microsoft.com/en-us/library/system.io.pipes.namedpipeclientstream.aspx</a></p>
