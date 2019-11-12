# Jump List with Windows Forms
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- Windows 7
## Topics
- Windows Forms
- Jump List
## Updated
- 02/25/2012
## Description

<h1>Jump List Helpers: create and manage Jump List with Windows Forms</h1>
<div>Jump List Helpers is a library that allows to&nbsp;add&nbsp;Jump List to&nbsp;Windows Forms Applications and to be notified&nbsp;when a command&nbsp;is selected (instead of starting a new application instance, that is the default behaviour).</div>
<p>The library is available on <a href="https://www.nuget.org/packages/JumpListHelpers" target="_blank">
NuGet</a>&nbsp;too.</p>
<p>For more information, you can refer to the article&nbsp;<a href="http://www.dotnettoscana.org/jump-list-con-windows-forms.aspx" target="_blank">Jump List con Windows Forms</a>&nbsp;(in Italian) that I have written for
<a href="http://www.dotnettoscana.org" target="_blank">DotNetToscana</a>.<br>
<br>
</p>
<h1>Building the Sample</h1>
<div></div>
<div>The code you can download from this page contains a Class Library, named<strong> JumpListHelpers</strong>, that provides all you need to add and manage Jump List to your applications. It also includes a&nbsp;Windows Forms&nbsp;Application,
<strong>JumpListManagerExample</strong>, that shows some examples of its usage:</div>
<p>&nbsp;</p>
<div><img src="49885-jumplist.png" alt="" width="746" height="410"></div>
<div></div>
<div>&nbsp;</div>
<h1>Description</h1>
<div></div>
<div>
<p>WPF 4 provides a native support for Jump List. Instead, if we use Windows Forms, we must adopt the
<a href="http://archive.msdn.microsoft.com/WindowsAPICodePack" target="_blank">Windows API Code Pack</a>, a managed wrapper that allows to access to the Windows API functions. Available on
<a href="http://nuget.org/packages/Windows7APICodePack-Shell" target="_blank">NuGet</a>&nbsp;too, it provides all you need to manage Jump Lists within our Windows Forms Applications.</p>
<p>Unfortunately, a limit of Jump Lists (no matter the technology we use) is that the commands shown are able to start programs, URLs and files only: it isn't possible to send command directly to the application instance that owns the Jump List.</p>
<p>So, I developed&nbsp;<strong>Jump List&nbsp;Helpers</strong>, a library built on top of Windows API Code Pack that is able to overcome this limitation. It allows to add commands to the Jump List that start external programs and commands that can be received
 by the application itself via a normal event.</p>
</div>
<div>Its usage is very simple. For example, the following code creates&nbsp;the Jump List shown in the previous screenshot:</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;MainForm_Shown(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddCategorySelfLink(<span class="cs__string">&quot;Commands&quot;</span>,&nbsp;<span class="cs__string">&quot;First&nbsp;command&quot;</span>,&nbsp;<span class="cs__string">&quot;Command1&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddCategorySelfLink(<span class="cs__string">&quot;Commands&quot;</span>,&nbsp;<span class="cs__string">&quot;Second&nbsp;command&quot;</span>,&nbsp;<span class="cs__string">&quot;Command2&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddCategorySelfLink(<span class="cs__string">&quot;Commands&quot;</span>,&nbsp;<span class="cs__string">&quot;Third&nbsp;command&quot;</span>,&nbsp;<span class="cs__string">&quot;Command3&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddCategoryLink(<span class="cs__string">&quot;Links&quot;</span>,&nbsp;<span class="cs__string">&quot;Around&nbsp;and&nbsp;About&nbsp;.NET&nbsp;World&quot;</span>,&nbsp;<span class="cs__string">&quot;http://blogs.ugidotnet.org/marcom&quot;</span>,&nbsp;<span class="cs__string">&quot;shell32.dll&quot;</span>,&nbsp;<span class="cs__number">220</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddTaskLink(<span class="cs__string">&quot;Start&nbsp;Notepad&quot;</span>,&nbsp;<span class="cs__string">&quot;notepad.exe&quot;</span>,&nbsp;<span class="cs__string">&quot;notepad.exe&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddTaskLink(<span class="cs__string">&quot;Start&nbsp;Calculator&quot;</span>,&nbsp;<span class="cs__string">&quot;calc.exe&quot;</span>,&nbsp;<span class="cs__string">&quot;calc.exe&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.AddTaskLink(<span class="cs__string">&quot;Start&nbsp;Paint&quot;</span>,&nbsp;<span class="cs__string">&quot;mspaint.exe&quot;</span>,&nbsp;<span class="cs__string">&quot;mspaint.exe&quot;</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;JumpListManager.Refresh();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Note that Jump Lists require a visible form when they are created, otherwise we'll get an exception. So, we can define then inside the form
<strong>Shown </strong>event handler. The first threed methods include the term Self in the name, so they define commands that belong to our application. The others are normal command that starts external program or open an Internet address.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
The next step is to modify our program so that it receives the selected command (<em>Command1</em>,
<em>Command2 </em>and <em>Command3 </em>in the example), instead of starting a new instance. So, when the program starts, we must check&nbsp;if a previous instance is already running and, in&nbsp;such a situation,&nbsp;send it the selected&nbsp;command.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
<strong>Jump List&nbsp;Helpers </strong>provides a series of methods and events that makes these checks really simple.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
First of all, we must open the <em>Program.cs </em>file and modify the <strong>Main
</strong>method so it looks like the following:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[STAThread]&nbsp;
<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ProgramManager.Run(<span class="cs__keyword">typeof</span>(MainForm),&nbsp;<span class="cs__string">&quot;JumpListManager&nbsp;Example&quot;</span>);&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The <strong>ProgramManager.Run </strong>method requires the type of the application main form and its title. Internally, it verifies whether we are starting the program for the first time: in this case, it behaves like the standard
<strong>Main </strong>method. Otherwise, if retrieves the existing instance and pass to it the command line&nbsp;arguments: if the application has been started through the Jump List, they are the commands that we have set when we have created it (<em>Command1</em>,
<em>Command2 </em>or <em>Command3</em>).</div>
<br>
<div>Now, we need to modify our application main form so that it is able to receive Jump List command. Let's change its declaration so that it inherits from
<strong>JumpListMainFormBase </strong>(contained in <strong>Jump List Helpers</strong>) and then add an handler for the
<strong>JumpListCommandReceived </strong>event:</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Modifica script</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainForm&nbsp;:&nbsp;JumpListMainFormBase&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainForm()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.JumpListCommandReceived&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EventHandler(MainForm_JumpListCommandReceived);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;MainForm_JumpListCommandReceived(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;CommandEventArgs&nbsp;e)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="cs__string">&quot;Comando&nbsp;ricevuto:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;e.CommandName,&nbsp;<span class="cs__string">&quot;JumpListManager&nbsp;Example&quot;</span>,&nbsp;MessageBoxButtons.OK,&nbsp;MessageBoxIcon.Information);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;...</span>&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">That's it: now, when we select one of the&nbsp;&quot;self&quot; command in the Jump List, the
<strong>JumpListCommandReceived </strong>event handler will be called with the right parameter.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"><br>
You can find a more complex example in the Windows Forms&nbsp;Application that is available in the ZIP file.</div>
</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<ul>
<li><a href="https://www.nuget.org/packages/JumpListHelpers" target="_blank">Jump List Helpers on NuGet
</a></li><li><a href="http://www.dotnettoscana.org/jump-list-con-windows-forms.aspx" target="_blank">My article on DotNetToscana&nbsp;(in Italian)&nbsp;</a>
</li></ul>
