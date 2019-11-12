# Identifying and Resolving Shortcuts/Links of files and folders
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- File System
- Visual Basic .NET
- VB.Net
## Topics
- File System
- Shell
- Shortcuts
- Links
## Updated
- 01/22/2015
## Description

<h1>Introduction</h1>
<p>This sample shows how to check and resolve shortcuts.</p>
<p>In Windows file shortcuts can be identified by the file extension.<em> </em>Default file extension for file and folder shortcuts is &quot;.lnk&quot;. But also &quot;.appref-ms&quot; is used as file extension for file shortcuts. Furthermore could it be possible that installed
 applications use the default shortcut file extension for its own application dependent files. So using file extensions as evidence for shortcut is not sufficient.</p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements or instructions for building the sample.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To check if a file is a shortcut and to resolve a shortcut path, the COM Library
<em>Microsoft Shell Controls And Automation</em> is used. This library is added to the References of the Visual Studio project.</p>
<p>The library Microsoft Shell Controls And Automation provides an interop connection to Shell32. It provides access to Shell and Folder objects representing the file system.</p>
<p>Shell object, Folder object, and FolderItem object are used to check if a given file is a shortcut.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">bool</span>&nbsp;IsShortcut(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;directory&nbsp;=&nbsp;Path.GetDirectoryName(path);&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;file&nbsp;=&nbsp;Path.GetFileName(path);&nbsp;
&nbsp;
&nbsp;&nbsp;Shell32.Shell&nbsp;shell&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Shell32.Shell();&nbsp;
&nbsp;&nbsp;Shell32.Folder&nbsp;folder&nbsp;=&nbsp;shell.NameSpace(directory);&nbsp;
&nbsp;&nbsp;Shell32.FolderItem&nbsp;folderItem&nbsp;=&nbsp;folder.ParseName(file);&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">if</span>(folderItem&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;folderItem.IsLink;&nbsp;
&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<p>Shell object, Folder object, FolderItem object, and ShellLinkObject object are used to resolve the file path of a given shortcut file.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">string</span>&nbsp;ResolveShortcut(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
{&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;directory&nbsp;=&nbsp;Path.GetDirectoryName(path);&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;file&nbsp;=&nbsp;Path.GetFileName(path);&nbsp;
&nbsp;
&nbsp;&nbsp;Shell32.Shell&nbsp;shell&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Shell32.Shell();&nbsp;
&nbsp;&nbsp;Shell32.Folder&nbsp;folder&nbsp;=&nbsp;shell.NameSpace(directory);&nbsp;
&nbsp;&nbsp;Shell32.FolderItem&nbsp;folderItem&nbsp;=&nbsp;folder.ParseName(file);&nbsp;
&nbsp;
&nbsp;&nbsp;Shell32.ShellLinkObject&nbsp;link&nbsp;=&nbsp;(Shell32.ShellLinkObject)folderItem.GetLink;&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;link.Path;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name ShortcutHelper.cs - checks and resolves shortcuts.</em>
</li><li><em><em>source code file name MainWindow.xaml(.cs) - startup of application, calls ShortcutHelper, displays results.</em></em>
</li></ul>
<h1>More Information</h1>
<p><strong>For further code samples visit <em><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></p>
<p>For more information on Microsoft Shell Controls And Automation, see <br>
<a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb776890%28v=vs.85%29.aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/bb776890%28v=vs.85%29.aspx</a></p>
<p>For more information on Shell object, see <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb774094%28v=vs.85%29.aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/bb774094%28v=vs.85%29.aspx</a></p>
<p>For more information on Folder object, see <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb787868%28v=vs.85%29.aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/bb787868%28v=vs.85%29.aspx</a></p>
<p>For more information on FolderItem object, see <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb787810%28v=vs.85%29.aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/bb787810%28v=vs.85%29.aspx</a></p>
<p>For more information on ShellLinkObject object, see <a href="http://msdn.microsoft.com/en-us/library/windows/desktop/bb774004%28v=vs.85%29.aspx">
http://msdn.microsoft.com/en-us/library/windows/desktop/bb774004%28v=vs.85%29.aspx</a></p>
