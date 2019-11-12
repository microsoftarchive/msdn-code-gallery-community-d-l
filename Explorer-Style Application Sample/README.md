# Explorer-Style Application Sample
## Requires
- Visual Studio 2008
## License
- MS-LPL
## Technologies
- WinForms
## Topics
- Explorer Style Application
## Updated
- 11/28/2011
## Description

<h1>Explorer-Style Application Sample</h1>
<div id="mainSection">
<div id="mainBody">
<div class="saveHistory" id="allHistory">
<p>&nbsp;</p>
</div>
<div class="introduction">
<p>To get samples and instructions for installing them, see the following:</p>
<ul>
<li>
<p>Click <span class="ui">Samples</span> on the Visual Studio <span class="ui">
Help</span> menu.</p>
<p>For more information, see .</p>
</li><li>
<p>The most recent versions and the complete list of samples are available on the Visual Studio 2008 Samples Web site.</p>
</li><li>
<p>You can also locate samples on your computer's hard disk. By default, samples and a Readme file are copied to a folder under \Program Files\Visual Studio 9\Samples\. For Visual Studio Express Editions, all samples are located on the Internet.</p>
<div class="alert">
<table width="100%">
</table>
<p>&nbsp;</p>
</div>
</li></ul>
</div>
<h3 class="procedureSubHeading">To run this sample</h3>
<div class="subSection">
<ul>
<li>
<p>Press F5.</p>
</li></ul>
</div>
<h1 class="heading"><span>Demonstrates</span></h1>
<div class="section" id="demonstratesSection">
<p>This sample contains two forms with an Explorer-like interface: a directory scanner and an Explorer-style viewer. The files that support the two forms are contained in separate folders of the project.</p>
<ul>
<li>
<p><span class="label">DirectoryScanner</span>&nbsp;&nbsp;&nbsp;This is a simple application that scans all directories and sub-directories in either all logical drives or a user-selected starting directory. The list of drives is obtained by using the method.
 A tree view control displays the directory structure reflecting the latest scan. Directories are colored green, yellow, or red based on their total size inclusive of all sub-directories and files. The method is used to retrieve the list of files, and the class
 is used to receive the file size.</p>
</li><li>
<p><span class="label">ExplorerStyleViewer</span>&nbsp;&nbsp;&nbsp;This is a simpler version of the
<span class="ui">Windows Explorer</span> application. The <span class="code">
ExplorerStyleViewer</span> displays more file information than <span class="code">
DirectoryScanner</span> by using the property. It demonstrates how to associate icons with file types by using the property. It enables the user to run an application associated with the file type (if an association exists) by double-clicking the file (just
 like in <span class="ui">Windows Explorer</span>). Applications are started by using the method.</p>
</li></ul>
</div>
</div>
<div id="footer">
<div class="footerLine"></div>
<a name="feedback"></a><span id="fb" class="feedbackcss">&nbsp;</span></div>
</div>
