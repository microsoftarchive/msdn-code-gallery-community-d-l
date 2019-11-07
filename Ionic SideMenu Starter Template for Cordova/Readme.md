# Ionic SideMenu Starter Template for Cordova
## Requires
- Visual Studio 2015
## License
- Apache License, Version 2.0
## Technologies
- Javascript
- HTML5
- Visual Studio 2013
- AngularJS
- Apache Cordova
- Ionic Framework
## Topics
- User Interface
## Updated
- 07/16/2015
## Description

<h1>Introduction</h1>
<p>This sample provides a version of the Ionic Starter Template for SideMenu that&nbsp;works&nbsp;with&nbsp;Visual Studio Tools for Apache Cordova, Windows 8.1, and Windows Phone 8.1. The template includes the Ionic Framework and AngularJS. The app also targets
 Android and iOS.</p>
<h1>Description</h1>
<p>To see the Ionic Starter Template for SideMenu on github, along with a demo on plinkr, go
<a href="https://github.com/driftyco/ionic-starter-sidemenu">here</a>.</p>
<p>This sample includes the following changes from the original Ionic template:</p>
<ul>
<li>Project is provided as a Visual Studio Tools for Apache Cordova project (some minor changes to the project structure are present in this version, and the ng-app reference is also changed.)
</li><li>Ionic Framework and AngularJS are included in the project. </li><li>In app.js, a call to&nbsp;<strong>aHrefSanitizationWhitelist</strong> method (AngularJS) is included to fix issue with AngularJS routing support on Windows and Windows Phone 8.1. (Without method call, links to partial pages fail.)
</li><li>App calls an updated version of the JavaScript Dynamic Content shim (winstore-compat.js) for Windows Store apps, which fixes incompatibility with Ionic Framework. The incompatibility is due to dynamic injection of &lt;body&gt; and &lt;head&gt; elements.
<a href="https://github.com/MSOpenTech/winstore-jscompat">Link to shim</a> </li><li>The project includes CordovaApp_TemporaryKey.pfx in /res/native/windows folder, which&nbsp;fixes a Cordova issue, described in
<a href="https://msopentech.com/blog/2014/11/11/cordova-certificate-issue-were-working-on-it/">
this page</a>. <strong>If you are using VS 2013 Update 4</strong>, move this file to /res/cert/windows8.
</li></ul>
<p>&nbsp;</p>
<h1>Requirements</h1>
<ul>
<li>Visual Studio 2013 Update 4 </li><li><a href="http://www.visualstudio.com/en-us/explore/cordova-vs.aspx">Visual Studio Tools for Apache Cordova</a> (separate install in VS 2013).
</li></ul>
<p>Note: For VS 2015 RC or later, the sample version is on github: <a href="https://github.com/Mikejo5001/ionic-sidemenu-vstools/">
https://github.com/Mikejo5001/ionic-sidemenu-vstools/</a></p>
<h1>Building the Sample</h1>
<ol>
<li>Download the .zip and extract it. </li><li>In Visual Studio 2013 Update 4, open the .sln file in the extracted zip. </li><li>If you are targeting Windows, and are using VS 2013 CTP 3, move the CordovaApp_TemporaryKey.pfx file to /res/cert/windows8. (For more info, see the link above for the temporary key.
</li><li>Choose a deployment target and press F5.<br>
Note: If you have issues debugging with Ripple, see this StackOverflow <a href="http://stackoverflow.com/questions/28376223/visual-studio-2013-update-4-and-apache-cordova-ctp3-breaking-stopping-on-javascr ">
post</a> </li></ol>
