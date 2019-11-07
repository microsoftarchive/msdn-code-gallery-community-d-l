# Example - How to Enable SharePoint JSOM IntelliSense in Visual Studio 2012\2013
## Requires
- 
## License
- Apache License, Version 2.0
## Technologies
- SharePoint
- Visual Studio 2012
- Visual Studio 2013
## Topics
- SharePoint
- IntelliSense
- SharePoint EcmaScript
## Updated
- 07/25/2013
## Description

<p>Introduction</p>
<div>SharePoint provide a subset of the familiar <strong>server-side object model
</strong>to the client by using the <strong>SharePoint Client Object Model (SCOM)</strong>.
<strong>JSOM </strong>is a part of SharePoint Client Object Model that intended for accessing and manipulating SharePoint objects by using JavaScript in an asynchronous. It&rsquo;s provides a comprehensive set of APIs that can be used to perform operations
 on most SharePoint objects such as<em> Site, Web, List, items, Content Types, User Permission
</em>and so forth.</div>
<div>&nbsp;</div>
<div><img id="92853" src="92853-sharepoint%20javascript%20jsom%20intellisense.png" alt="" width="502" height="308"></div>
<div></div>
<div></div>
<div>Visual Studio <strong>IntelliSense </strong>feature provides a set of options that help developer to make language references easily accessible. When developer write a code, &nbsp;Visual Studio IntelliSense keep context, find the information you need,
 insert language elements directly into the code.</div>
<div>&nbsp;</div>
<h2>Code Description</h2>
<div>This project contains code to helps you to understand how to Enable ECMA Client Object Model (JSOM) IntelliSense in Visual Studio 2012\2013.</div>
<div>&nbsp;</div>
<div>You shloud add <em>reference directive file</em> to your project then add a reference directive in the form of an XML comment as the following:</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>
<pre class="hidden">/// &lt;reference path=&quot;~/_layouts/15/init.js&quot; /&gt;
/// &lt;reference path=&quot;~/_layouts/15/SP.Core.js&quot; /&gt;
/// &lt;reference path=&quot;~/_layouts/15/SP.Runtime.js&quot; /&gt;
/// &lt;reference path=&quot;~/_layouts/15/SP.UI.Dialog.js&quot; /&gt;
/// &lt;reference path=&quot;~/_layouts/15/SP.js&quot; /&gt;</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;~/_layouts/15/init.js&quot;&nbsp;/&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;~/_layouts/15/SP.Core.js&quot;&nbsp;/&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;~/_layouts/15/SP.Runtime.js&quot;&nbsp;/&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;~/_layouts/15/SP.UI.Dialog.js&quot;&nbsp;/&gt;</span>&nbsp;
<span class="js__sl_comment">///&nbsp;&lt;reference&nbsp;path=&quot;~/_layouts/15/SP.js&quot;&nbsp;/&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>A <strong>reference directive (_references.js) </strong>enables Visual Studio to establish a relationship between the script you are currently editing and other scripts. this file should be only one _references.js file for each project and is located should
 be in the scripts directory.</div>
<div>&nbsp;</div>
<h2>Read More:</h2>
<div><a href="http://social.technet.microsoft.com/wiki/contents/articles/18713.enable-ecma-client-object-model-jsom-intellisense-in-visual-studio-20122013.aspx">Read more (step by step) how to Enable ECMA Client Object Model (JSOM) IntelliSense in Visual Studio
 2012\2013</a></div>
<div>&nbsp;</div>
<div>&nbsp;</div>
<div>&nbsp;</div>
