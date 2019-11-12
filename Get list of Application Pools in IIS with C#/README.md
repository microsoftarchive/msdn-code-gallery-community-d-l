# Get list of Application Pools in IIS with C#
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- IIS
- Windows Forms
## Topics
- IIS Admin
- Windows Forms
## Updated
- 08/15/2011
## Description

<h1>Introduction</h1>
<p>This sample shows how to list the application pools on a named machine using an IIS metabase query</p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements to build the sample. However if you wish to use this tool against servers running IIS 7&#43; you need to install the IIS 6 Metabase compatibility options within the IIS setup.</p>
<p>To install IIS 6 compatibility with IIS 7 please use the following</p>
<p>Install the IIS 6.0 Management Compatibility Components in Windows Server 2008 R2 or in Windows Server by using the Server Manager tool</p>
<ol>
<li>
<p>Click <strong>Start</strong>, click <strong>Administrative Tools</strong>, and then click
<strong>Server Manager</strong>.</p>
</li><li>
<p>In the navigation pane, expand <strong>Roles</strong>, right-click <strong>Web Server (IIS)</strong>, and then click
<strong>Add Role Services</strong>.</p>
</li><li>
<p>In the <strong>Select Role Services</strong> pane, scroll down to <strong>IIS 6 Management Compatibility</strong>.</p>
</li><li>
<p>Click to select the <strong>IIS 6 Metabase Compatibility</strong> and <strong>
IIS 6 Management Console</strong> check boxes.</p>
</li><li>
<p>In the <strong>Select Role Services</strong> pane, click <strong>Next</strong>, and then click
<strong>Install</strong> at the <strong>Confirm Installations Selections</strong> pane.</p>
</li><li>
<p>Click <strong>Close</strong> to exit the Add Role Services wizard.</p>
</li></ol>
<p>Install the IIS 6.0 Management Compatibility Components in Windows 7 or in Windows Vista from Control Panel</p>
<ol>
<li>
<p>Click <strong>Start</strong>, click <strong>Control Panel</strong>, click <strong>
Programs and Features</strong>, and then click <strong>Turn Windows features on or off</strong>.</p>
</li><li>
<p>Open <strong>Internet Information Services</strong>.</p>
</li><li>
<p>Open <strong>Web Management Tools</strong>.</p>
</li><li>
<p>Open <strong>IIS 6.0 Management Compatibility</strong>.</p>
</li><li>
<p>Select the check boxes for <strong>IIS 6 Metabase and IIS 6 configuration compatibility</strong> and
<strong>IIS 6 Management Console</strong>.</p>
</li><li>
<p>Click <strong>OK</strong>.</p>
</li></ol>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample shows how to get a list of application pools for a given server using different Windows credentials. It uses an IIS metabase query to get the list of the current application pools and shows them in a ListBox</p>
<p>First you need to create a DirectoryEntry object with the required specifications (Current Computer, current username and password for example)&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DirectoryEntry&nbsp;GetDirectoryEntry(<span class="cs__keyword">string</span>&nbsp;path)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryEntry&nbsp;root&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;root&nbsp;=&nbsp;chkUseCurrentUser.Checked&nbsp;?&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryEntry(path)&nbsp;:&nbsp;<span class="cs__keyword">new</span>&nbsp;DirectoryEntry(path,&nbsp;txtUsername.Text,&nbsp;txtPassword.Text,&nbsp;AuthenticationTypes.Secure);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>(Exception&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lblErrors.Text&nbsp;=&nbsp;e.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;root;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
To run the query we use a piece of LINQ</div>
<div class="scriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;GetApplicationPools(<span class="cs__keyword">string</span>&nbsp;computerName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryEntry&nbsp;root&nbsp;=&nbsp;GetDirectoryEntry(@<span class="cs__string">&quot;IIS://&quot;</span>&nbsp;&#43;&nbsp;computerName&nbsp;&#43;&nbsp;<span class="cs__string">&quot;/W3SVC/AppPools&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(root&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;items&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(from&nbsp;DirectoryEntry&nbsp;entry&nbsp;<span class="cs__keyword">in</span>&nbsp;root.Children&nbsp;let&nbsp;properties&nbsp;=&nbsp;entry.Properties&nbsp;select&nbsp;entry.Name).ToList();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;items;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<div class="endscriptcode">The resultset of strings is data bound to the ListBox control and&nbsp;displayed&nbsp;</div>
</div>
<h1>More Information</h1>
<p>For more information on the different aspects of this sample please see the following links</p>
<ul>
<li>DirectoryEntry - <a href="http://msdn.microsoft.com/en-us/library/system.directoryservices.directoryentry.aspx">
http://msdn.microsoft.com/en-us/library/system.directoryservices.directoryentry.aspx</a>
</li><li>IIS 6 MetaBase - <a href="http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/44a57859-8fbb-4238-a7b5-f10c34cf8fe8.mspx?mfr=true">
http://www.microsoft.com/technet/prodtechnol/WindowsServer2003/Library/IIS/44a57859-8fbb-4238-a7b5-f10c34cf8fe8.mspx?mfr=true</a>
</li><li>LINQ - <a href="http://msdn.microsoft.com/en-us/netframework/aa904594">http://msdn.microsoft.com/en-us/netframework/aa904594</a>
</li></ul>
<p>&nbsp;</p>
