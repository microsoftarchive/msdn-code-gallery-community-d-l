# Handling Unhandled Exceptions in WPF (The most complete collection of handlers)
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
## Topics
- Exception handling
- Logging
- Event Handling
- Custom Exceptions
- WPF Debugging
- Unhandled Events
- Unhandled Event Handler
- Faultfinding WPF
- Unhandled Exceptions
- WPF Bugs
## Updated
- 09/23/2012
## Description

<h1>Introduction</h1>
<p>This is the ultimate collection of unhandled exception event handlers for WPF. There are FIVE different&nbsp;event handlers you can call upon to catch that ellusive bug, before you application dies. Examples of each are shown, with&nbsp;how to catch, handle,
 log and usually overcome the critical events.</p>
<p><img id="67146" src="67146-exc.png" alt="" width="636" height="335"></p>
<p>&nbsp;</p>
<h1><span>Building &amp; Running the Sample</span></h1>
<p>Just download, unzip, open and build!</p>
<p><span style="color:#ff0000"><strong>Note</strong>: Because this is an exception handling demo, you will need to either:</span></p>
<p><span style="color:#ff0000">A) Keep pressing F5, to continue past&nbsp;each debugger catch</span></p>
<p><span style="color:#ff0000">B) <strong><span style="text-decoration:underline">Build</span> the project and
<span style="text-decoration:underline">run from the exe</span> in bin/debug folder</strong>.</span></p>
<p>&nbsp;</p>
<h1><span style="font-size:20px">Description</span></h1>
<p>This project contains everything you need to handle&nbsp;just about every unhandled exception in WPF.</p>
<p>&nbsp;</p>
<h2>1. AppDomain.CurrentDomain.FirstChanceException</h2>
<p>This is new to .Net 4 and is extremely useful for ensuring that you ALWAYS log SOMETHING. Whenever any kind of exception is fired in your application, a FirstChangeExcetpion is raised, even if the exception was within a Try/Catch block and safely handled.
 This is GREAT for logging every wart and boil, but can often result in too much spam, if your application&nbsp;has a lot of expected/handled exceptions.
<strong>In this example, because&nbsp;this handler&nbsp;is active, it will fire for every example, before the other handler reacts.</strong></p>
<p>&nbsp;</p>
<h2>2. Application.DispatcherUnhandledException</h2>
<p>This is the main exception event for most application unhandled exceptions. It also has a Handled property with which you can try to recover and continue after the exception.</p>
<p>&nbsp;</p>
<h2>3. AppDomain.CurrentDomain.UnhandledException</h2>
<p>Although Application.DispatcherUnhandledException covers most issues in the current AppDomain, in extremely rare circumstances, you may be running a thread on a second AppDomain. This event&nbsp;conveys the other AppDomain unhandled exception, but there
 are no Handled property, just an IsTerminating flag.</p>
<p>&nbsp;</p>
<h2>4. TaskScheduler.UnobservedTaskException</h2>
<p>If you are using Tasks, then you may have &quot;unobserved task exceptions&quot;. This event allows you to trap them. It also has a method called SetObserved, which allows you to try to recover from the issue.</p>
<p>&nbsp;</p>
<h2>5. <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.Application.ThreadException.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.Application.ThreadException">System.Windows.Forms.Application.ThreadException</a></h2>
<p>If you are hosting any WinForm componants in your WPF application, this final event is one to watch. There's no way to influence events thereafter, but at least you get to see what the problem was.</p>
<p>&nbsp;</p>
<h2>Logging Exceptions and Inner Exceptions.</h2>
<p>Inner exceptions are very commonly used in WPF, as XAML errors (like missing resources) are often more meaningfully detailed in the Inner Exception. All of the event handlers for the events above use one logging function, shown below:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;Log&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;Log&nbsp;log;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Log()&nbsp;{&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Log&nbsp;GetInstance()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(log&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;log&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Log();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;log;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ProcessError(Exception&nbsp;exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;error&nbsp;=&nbsp;<span class="cs__string">&quot;LOGGED:&nbsp;Exception&nbsp;=&nbsp;&quot;</span>&nbsp;&#43;&nbsp;exception.Message;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">while</span>&nbsp;(exception.InnerException&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exception&nbsp;=&nbsp;exception.InnerException;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;error&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;&nbsp;:&nbsp;Inner&nbsp;Exception&nbsp;=&nbsp;&quot;</span>&nbsp;&#43;&nbsp;exception.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//This&nbsp;is&nbsp;where&nbsp;you&nbsp;save&nbsp;to&nbsp;file.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p><img src="http://213.163.64.28/aniThanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
