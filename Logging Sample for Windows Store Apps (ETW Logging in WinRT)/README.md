# Logging Sample for Windows Store Apps (ETW Logging in WinRT)
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- XAML
- Visual Basic .NET
- Windows RT
## Topics
- C#
- Diagnostics
- XAML
- Visual Basic .NET
- Windows RT
- ETW
- StorageFile Logging
## Updated
- 10/10/2012
## Description

<h1>Introduction</h1>
<p>One of the biggest issues with Windows Store Apps (aka Metro Applications) was the removal of the TraceListeners from the windows runtime. Log4Net community has not yet took a step forward to port at least some of the functionality to .NET for Windows Store
 Apps Framework either. So most of the developers were complaining about the lack of logging functionality in WinRT.</p>
<p>Here is a small sample that shows how to use the ETW (Event Tracing for Windows) namespaces to write application events to a storage file on the application local storage.</p>
<p><span><span class="input"><br>
</span></span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span><span class="input"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.aspx" target="_blank" title="Auto generated link to System.Diagnostics">System.Diagnostics</a></span> </span>and its child namespaces (<span><span class="input"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.CodeAnalysis.aspx" target="_blank" title="Auto generated link to System.Diagnostics.CodeAnalysis">System.Diagnostics.CodeAnalysis</a></span></span>,
<span><span class="input"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Contracts.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Contracts">System.Diagnostics.Contracts</a></span></span>, and <span>
<span class="input"><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Diagnostics.Tracing.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Tracing">System.Diagnostics.Tracing</a></span></span>) contain types that enable you to interact with system processes, event logs, and performance counters.</p>
<p>With the help of the Tracing namespace, we can define a simple EventSource to send diffent type of events in different severities.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;MetroEventSource&nbsp;:&nbsp;EventSource&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;MetroEventSource&nbsp;Log&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MetroEventSource();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Event(<span class="cs__number">1</span>,&nbsp;Level&nbsp;=&nbsp;EventLevel.Verbose)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Debug(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WriteEvent(<span class="cs__number">1</span>,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Event(<span class="cs__number">2</span>,&nbsp;Level&nbsp;=&nbsp;EventLevel.Informational)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Info(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WriteEvent(<span class="cs__number">2</span>,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Event(<span class="cs__number">3</span>,&nbsp;Level&nbsp;=&nbsp;EventLevel.Warning)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Warn(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WriteEvent(<span class="cs__number">3</span>,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Event(<span class="cs__number">4</span>,&nbsp;Level&nbsp;=&nbsp;EventLevel.Error)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Error(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WriteEvent(<span class="cs__number">4</span>,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[Event(<span class="cs__number">5</span>,&nbsp;Level&nbsp;=&nbsp;EventLevel.Critical)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Critical(<span class="cs__keyword">string</span>&nbsp;message)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.WriteEvent(<span class="cs__number">5</span>,&nbsp;message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>After creating our event source we will need a event listener that simply creates either opens an existing file in the local storage:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;This&nbsp;is&nbsp;an&nbsp;advanced&nbsp;usage,&nbsp;where&nbsp;you&nbsp;want&nbsp;to&nbsp;intercept&nbsp;the&nbsp;logging&nbsp;messages&nbsp;and&nbsp;devert&nbsp;them&nbsp;somewhere</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;besides&nbsp;ETW.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">sealed</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;StorageFileEventListener&nbsp;:&nbsp;EventListener&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Storage&nbsp;file&nbsp;to&nbsp;be&nbsp;used&nbsp;to&nbsp;write&nbsp;logs</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;StorageFile&nbsp;m_StorageFile&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Name&nbsp;of&nbsp;the&nbsp;current&nbsp;event&nbsp;listener</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;m_Name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;StorageFileEventListener(<span class="cs__keyword">string</span>&nbsp;name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.m_Name&nbsp;=&nbsp;name;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.WriteLine(<span class="cs__string">&quot;StorageFileEventListener&nbsp;for&nbsp;{0}&nbsp;has&nbsp;name&nbsp;{1}&quot;</span>,&nbsp;GetHashCode(),&nbsp;name);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AssignLocalFile();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;AssignLocalFile()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_StorageFile&nbsp;=&nbsp;await&nbsp;ApplicationData.Current.LocalFolder.CreateFileAsync(m_Name.Replace(<span class="cs__string">&quot;&nbsp;&quot;</span>,&nbsp;<span class="cs__string">&quot;_&quot;</span>)&nbsp;&#43;&nbsp;<span class="cs__string">&quot;.log&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreationCollisionOption.OpenIfExists);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;WriteToFile(IEnumerable&lt;<span class="cs__keyword">string</span>&gt;&nbsp;lines)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnEventWritten(EventWrittenEventArgs&nbsp;eventData)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnEventSourceCreated(EventSource&nbsp;eventSource)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;TODO:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>and finally initialize the EventListener and start logging:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;First&nbsp;time&nbsp;execution,&nbsp;initialize&nbsp;the&nbsp;logger</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EventListener&nbsp;verboseListener&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StorageFileEventListener(<span class="cs__string">&quot;MyListenerVerbose&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;EventListener&nbsp;informationListener&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StorageFileEventListener(<span class="cs__string">&quot;MyListenerInformation&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;verboseListener.EnableEvents(MetroEventSource.Log,&nbsp;EventLevel.Verbose);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;informationListener.EnableEvents(MetroEventSource.Log,&nbsp;EventLevel.Informational);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>the log calls look something like below and the result view of the above defined listeners:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">MetroEventSource.Log.Info(<span class="cs__string">&quot;Current&nbsp;Window&nbsp;is&nbsp;activating&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><img id="67473" src="67473-loggingfiles.png" alt="" width="693" height="374"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li>
<p>Log\MetroEventSource.cs - This file defines a simple event source to be able to write different types of events to the local storage file.</p>
</li><li>
<p>Log\StorageFileEventListener.cs - Simple storage file listener that makes use of a Semaphore slim to control the access to the storage file.</p>
</li></ul>
<h1>More Information</h1>
<p><em>Wait for the blog entry on </em><a href="http://canbilgin.wordpress.com/" target="_blank">http://canbilgin.wordpress.com/</a></p>
