# Demo showing the MFC Web Browser control stops working
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- MFC
- Web Browser
## Topics
- Web Browser
## Updated
- 08/15/2017
## Description

<h1>Introduction</h1>
<p><em>The aim of this project is to show a problem with the Web Browser control in MFC.</em></p>
<p><em>Sometimes this control becomes locked and is unable to navigate to other web pages.&nbsp; I think this is an issue with ActiveX/COM as I have tried calling every function that is accessible.&nbsp; It would be great if anyone can help me find a solution
 to unlock a web browser in this state.</em></p>
<p><em>I know that the context menu is one way of locking the web control, but it does seem to happen randomly so there are other causes.&nbsp;
<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You will a version of VS with MFC.&nbsp; <em>I built this project using VS2012, so you will need to use this version or later.<br>
</em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>These first steps show the browser control working correctly:<br>
</em></p>
<p><em>1. Run the program, examine the 'Class View' pane which should automatically load www.google.com
</em></p>
<p><em>2. Click the 'New Folder' button (the right most button in the toolbar of the 'Class View' pane), this navigates the web control to www.bing.com</em></p>
<p><em>To reproduce the problem:</em></p>
<p><em>1. Restart the program, <em>examine the 'Class View' pane which should automatically load www.google.com
</em></em></p>
<p><em>2. Right click the 'Class View' pane title bar, this should show the dockable pane context menu</em></p>
<p><em>3. With the context menu still displayed, left click in the web browser control.</em></p>
<p><em>4. The web browser control is now in a 'locked' state.&nbsp; <em>Click the 'New Folder' button, this should navigate the web control to www.bing.com but nothing happens.&nbsp;
</em></em></p>
