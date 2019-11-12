# Get a list of Installed Software using vb or c# and the wmi
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Visual Basic .NET
## Topics
- Windows Management Interface (WMI)
## Updated
- 06/01/2013
## Description

<h1>Introduction</h1>
<div><em>Gets a list of Software installed on the local computer&nbsp;</em></div>
<h1><span>Building the Sample</span></h1>
<div><em>Uses Visual Studio 2012 or Visual Studio 2012 Express for Windows Desktop,&nbsp; The code listed below can be compiled with earlier versions of visual studio, visual basic express edition,&nbsp; or c# express edition</em></div>
<div><em>&nbsp;</em></div>
<div><em><a href="http://www.microsoft.com/visualstudio/eng/downloads">http://www.microsoft.com/visualstudio/eng/downloads</a></em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div>&nbsp;</div>
<div><em>
<div>Uses the windows managment interface and visual basic&nbsp;to get a list of the installed installed software on the computer.&nbsp;&nbsp;The name of&nbsp;the installed software will be displayed in an windows forms list box. You can use the classes in
 <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Management.aspx" target="_blank" title="Auto generated link to System.Management">System.Management</a> to query the&nbsp;windows managment interface to get information about the local computer.&nbsp; In this case we&nbsp;query the Win32_Product class to get the installed software on the computer.&nbsp;&nbsp; The name property in the returned
 data is what we will display in a windows form&nbsp;listbox.</div>
<div></div>
<div>The Win32_Product class returns the name, install location, install date, etc..&nbsp; The Win32_Product class also function for unistalling the software</div>
<div></div>
<div></div>
<div><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx</a></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;Form1&nbsp;:&nbsp;Form&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;LoadSoftwareList()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listBox1.Items.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectCollection&nbsp;moReturn;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ManagementObjectSearcher&nbsp;moSearch;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moSearch&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ManagementObjectSearcher(<span class="cs__string">&quot;Select&nbsp;*&nbsp;from&nbsp;Win32_Product&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;moReturn&nbsp;=&nbsp;moSearch.Get();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>(ManagementObject&nbsp;mo&nbsp;<span class="cs__keyword">in</span>&nbsp;moReturn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listBox1.Items.Add(mo[<span class="cs__string">&quot;Name&quot;</span>].ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Form1_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LoadSoftwareList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
</em></div>
<div><em><em>&nbsp;</em></em>&nbsp;</div>
<h1>More Information</h1>
<p><a href="http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx</a></p>
<div><em><a href="http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/7159b57c-f6a8-4a6a-ab8c-dd65f4d7973a/">http://social.msdn.microsoft.com/Forums/en-US/vbgeneral/thread/7159b57c-f6a8-4a6a-ab8c-dd65f4d7973a/</a></em></div>
