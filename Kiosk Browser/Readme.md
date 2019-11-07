# Kiosk Browser
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- WinForms
## Topics
- Web Browser
## Updated
- 07/03/2012
## Description

<h1>Introduction</h1>
<p>This application is developed in WPF with .Net 4 Framework. The purpose of this application is to convert your PC into public web browser with one click, just by opening the app. It runs on full screen mode and disables some of the features of normal browsers.
 There is a time limit of 10 minutes set for each session, and it automatically ends the session of there is no activity in 2 minutes.</p>
<p>Kiosk Browser uses Internet Explorer&rsquo;s engine for browsing sites. This ensures compatibility when browsing already common sites, SharePoint sites, and other windows authentications sites.</p>
<p>When the session ends all the previous activity is deleted (opened page, logins).</p>
<p>Features:</p>
<ul>
<li>Internet Explorer engine, </li><li>Customize home screen and message, </li><li>Full Screen Mode, </li><li>Support for windows authentication, </li><li>Hide Start Menu and Taskbar, </li><li>Set time limit for usage (default 10 min), </li><li>Set time limit for mouse and keyboard inactivity (default 2 min), </li><li>Disable file download. </li></ul>
<h1>Building the Sample</h1>
<p>To build and run this sample, you must have Visual Studio 2010 installed. Unzip the BulkEmail.zip file into your Visual Studio Projects directory (My Documents\Visual Studio 2010\Projects) and open the AJAXFileUploadSQL.sln solution.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">//When the application is started, the taskbar is hidden
Taskbar.Hide();

//You can implement you logic to close the application and re-show the taskbar
Taskbar.Show();</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//When&nbsp;the&nbsp;application&nbsp;is&nbsp;started,&nbsp;the&nbsp;taskbar&nbsp;is&nbsp;hidden</span>&nbsp;
Taskbar.Hide();&nbsp;
&nbsp;
<span class="cs__com">//You&nbsp;can&nbsp;implement&nbsp;you&nbsp;logic&nbsp;to&nbsp;close&nbsp;the&nbsp;application&nbsp;and&nbsp;re-show&nbsp;the&nbsp;taskbar</span>&nbsp;
Taskbar.Show();</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><em>Screenshot of the Web Application:</em></p>
<p><img id="60416" src="60416-kiosk.png" alt="" width="1366" height="768"></p>
