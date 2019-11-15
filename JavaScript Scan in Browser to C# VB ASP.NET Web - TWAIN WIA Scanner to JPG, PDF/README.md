# JavaScript Scan in Browser to C# VB ASP.NET Web - TWAIN WIA Scanner to JPG, PDF
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- ASP.NET
- ASP.NET MVC
- jQuery
- Web Services
- Javascript
- Entity Framework
- Web
- ASP.NET Web Forms
- Office 365
- SharePoint Server 2010
- Image manipulation
- Sharepoint Online
- HTML5
- WIA
- ASP.NET Web API
- Image process
- HTML5/JavaScript
- .NET Development
- Image Processing
- Web App Development
- scanner
- Twain
- document scanning
## Topics
- Controls
- Graphics
- ASP.NET
- User Interface
- Graphics and 3D
- SharePoint
- ASP.NET MVC
- Images
- ImageViewer
- Web Services
- Javascript
- Image manipulation
- Image Gallery
- WebBrowser
- Imaging
- WIA
- HTTP
- Sharepoint Web Parts
- Sharepoint 2010 101 code samples
- Web API
- BitmapImage
- Load Image
- Dynamically Image
- AngularJS
- scanner
- Twain
- document scanning
## Updated
- 08/19/2016
## Description

<h1>Introduction</h1>
<p class="projectSummary">The samples illustrates how to use Scanner.js to perform HTML JavaScript scanning in web browsers (Chrome, Edge, Firefox, IE).
<a href="http://asprise.com/document-scan-upload-image-browser/direct-to-server-php-asp.net-overview.html" target="_blank">
Scan documents from TWAIN WIA scanners in browsers and upload to the server side</a>, which can be written in any script (Java, C# VB ASP.NET, PHP, Python, Ruby). JPEG, PDF, TIFF are supported.</p>
<div></div>
<div class="clear"></div>
<h1><span>Building the Sample</span></h1>
<p>Download the zip and unzip it. Open with Visual Studio 2013 or higher. Press F5 to launch it.</p>
<p><img src="http://asprise.com/scan/scannerjs/img/screen-scannerjs.png" alt="Scanner.js" width="500"></p>
<p><em>&nbsp;</em><span style="font-size:20px; font-weight:bold">Scan Images as JPEG from TWAIN WIA Scanners to Web Pages</span></p>
<p>Below is a complete sample <a href="http://asprise.com/document-scan-upload-image-browser/ie-chrome-firefox-scanner-docs.html" target="_blank">
page that scans documents from scanners and displays the scanned images</a> on it:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;!DOCTYPE&nbsp;html&gt;&lt;html&gt;&lt;head&gt;&nbsp;
&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;https://asprise.azureedge.net/scannerjs/scanner.js&quot;</span>&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&lt;/script&gt;&nbsp;
&nbsp;&nbsp;&lt;script&nbsp;type=<span class="js__string">&quot;text/javascript&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;scanRequest&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;use_asprise_dialog&quot;</span>:&nbsp;true,&nbsp;<span class="js__sl_comment">//&nbsp;Whether&nbsp;to&nbsp;use&nbsp;Asprise&nbsp;Scanning&nbsp;Dialog</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;show_scanner_ui&quot;</span>:&nbsp;false,&nbsp;<span class="js__sl_comment">//&nbsp;Whether&nbsp;scanner&nbsp;UI&nbsp;should&nbsp;be&nbsp;shown</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;twain_cap_setting&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__sl_comment">//&nbsp;Optional&nbsp;scanning&nbsp;settings</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;ICAP_PIXELTYPE&quot;</span>:&nbsp;<span class="js__string">&quot;TWPT_RGB&quot;</span>&nbsp;<span class="js__sl_comment">//&nbsp;Color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;output_settings&quot;</span>:&nbsp;[<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;return-base64&quot;</span>,&nbsp;<span class="js__string">&quot;format&quot;</span>:&nbsp;<span class="js__string">&quot;jpg&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>]&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;scan()&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__sl_comment">//&nbsp;Triggers&nbsp;the&nbsp;scan</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;scanner.scan(displayImagesOnPage,&nbsp;scanRequest);&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;displayImagesOnPage(successful,&nbsp;mesg,&nbsp;response)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__sl_comment">//&nbsp;Handler</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;scannedImages&nbsp;=&nbsp;scanner.getScannedImages(response,&nbsp;true,&nbsp;false);&nbsp;<span class="js__sl_comment">//&nbsp;returns&nbsp;an&nbsp;array&nbsp;of&nbsp;ScannedImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(<span class="js__statement">var</span>&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;(scannedImages&nbsp;<span class="js__operator">instanceof</span>&nbsp;<span class="js__object">Array</span>)&nbsp;&amp;&amp;&nbsp;i&nbsp;&lt;&nbsp;scannedImages.length;&nbsp;i&#43;&#43;)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;scannedImage&nbsp;=&nbsp;scannedImages[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;elementImg&nbsp;=&nbsp;scanner.createDomElementFromModel(<span class="js__brace">{</span>&nbsp;<span class="js__string">'name'</span>:&nbsp;<span class="js__string">'img'</span>,&nbsp;<span class="js__string">'attributes'</span>:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">'class'</span>:&nbsp;<span class="js__string">'scanned'</span>,&nbsp;<span class="js__string">'src'</span>:&nbsp;scannedImage.src&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(document.getElementById(<span class="js__string">'images'</span>)&nbsp;?&nbsp;document.getElementById(<span class="js__string">'images'</span>)&nbsp;:&nbsp;document.body).appendChild(elementImg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&lt;<span class="js__reg_exp">/script&gt;&lt;/</span>head&gt;&lt;body&gt;&nbsp;
&nbsp;&nbsp;&lt;button&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;onclick=<span class="js__string">&quot;scan();&quot;</span>&gt;Scan&lt;<span class="js__reg_exp">/button&gt;&nbsp;&lt;div&nbsp;id=&quot;images&quot;/</span>&gt;&nbsp;
&lt;<span class="js__reg_exp">/body&gt;&lt;/</span>html&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<h1>Scan then Upload in Browsers</h1>
</div>
<p>There are two options to implement scan then upload in browsers. You can scan and and later upload the scanned images with an existing&nbsp;<code class="docutils literal"><span class="pre">&lt;form&gt;</span></code>&nbsp;when submitted. Alternatively,
 you can instruct scanner.js to scan and upload directly to the server side.</p>
<div></div>
<div class="section" id="option-1-scan-and-upload-with-a-form"></div>
<h2>Option 1: Scan And Upload With A Form</h2>
<p>We can simply extend the previous example by adding a HTML&nbsp;<code class="docutils literal"><span class="pre">&lt;form&gt;</span></code>&nbsp;element and an optional&nbsp;<code class="docutils literal"><span class="pre">&lt;div&gt;</span></code>&nbsp;to
 display server response as well as a JavaScript function to submit the form:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&gt;&nbsp;
<span class="js__operator">function</span>&nbsp;submitFormWithScannedImages()&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(scanner.submitFormWithImages(<span class="js__string">'form1'</span>,&nbsp;imagesScanned,&nbsp;<span class="js__operator">function</span>&nbsp;(xhr)&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;(xhr.readyState&nbsp;==&nbsp;<span class="js__num">4</span>)&nbsp;<span class="js__brace">{</span><span class="js__sl_comment">//&nbsp;4:&nbsp;request&nbsp;finished&nbsp;and&nbsp;response&nbsp;is&nbsp;ready</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;&lt;h2&gt;Response&nbsp;from&nbsp;the&nbsp;server:&nbsp;&lt;/h2&gt;&quot;</span>&nbsp;&#43;&nbsp;xhr.responseText;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'images'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">''</span>;&nbsp;<span class="js__sl_comment">//&nbsp;clear&nbsp;images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imagesScanned&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>))&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;Submitting,&nbsp;please&nbsp;stand&nbsp;by&nbsp;...&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__statement">else</span><span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">&quot;Form&nbsp;submission&nbsp;cancelled.&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&lt;/script&gt;&nbsp;
&nbsp;
&lt;form&nbsp;id=<span class="js__string">&quot;form1&quot;</span>&nbsp;action=<span class="js__string">&quot;https://asprise.com/scan/applet/upload.php?action=dump&quot;</span>&nbsp;method=<span class="js__string">&quot;POST&quot;</span>&nbsp;enctype=<span class="js__string">&quot;multipart/form-data&quot;</span>&nbsp;target=<span class="js__string">&quot;_blank&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;text&quot;</span>&nbsp;id=<span class="js__string">&quot;sample-field&quot;</span>&nbsp;name=<span class="js__string">&quot;sample-field&quot;</span>&nbsp;value=<span class="js__string">&quot;Test&nbsp;scan&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;button&quot;</span>&nbsp;value=<span class="js__string">&quot;Submit&quot;</span>&nbsp;onclick=<span class="js__string">&quot;submitFormWithScannedImages();&quot;</span>&gt;&nbsp;
&lt;/form&gt;&nbsp;
&nbsp;
&lt;div&nbsp;id=<span class="js__string">&quot;server_response&quot;</span>&gt;&lt;/div&gt;&nbsp;</pre>
</div>
</div>
</div>
<h2>Scan To PDF And Upload Directly Through Scanner.Js</h2>
<p>Scanner.js has the capability of uploading images immediately after scanning. Instead of uploading images through a&nbsp;<code class="docutils literal"><span class="pre">&lt;form&gt;</span></code>, you may instruct scanner.js to upload images directly.</p>
<div></div>
<div class="literal-block-wrapper x_x_container" id="javascript-scan-and-upload-directly">
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;scanAndUploadDirectly()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;scanner.scan(displayServerResponse,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;output_settings&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;type&quot;</span>:&nbsp;<span class="js__string">&quot;upload&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;format&quot;</span>:&nbsp;<span class="js__string">&quot;pdf&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;upload_target&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;url&quot;</span>:&nbsp;<span class="js__string">&quot;https://asprise.com/scan/applet/upload.php?action=dump&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;post_fields&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;sample-field&quot;</span>:&nbsp;<span class="js__string">&quot;Test&nbsp;scan&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;cookies&quot;</span>:&nbsp;document.cookie,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;headers&quot;</span>:&nbsp;[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;Referer:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;window.location.href,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;User-Agent:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;navigator.userAgent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;displayServerResponse(successful,&nbsp;mesg,&nbsp;response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(!successful)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__sl_comment">//&nbsp;On&nbsp;error</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">'Failed:&nbsp;'</span>&nbsp;&#43;&nbsp;mesg;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(successful&nbsp;&amp;&amp;&nbsp;mesg&nbsp;!=&nbsp;null&nbsp;&amp;&amp;&nbsp;mesg.toLowerCase().indexOf(<span class="js__string">'user&nbsp;cancel'</span>)&nbsp;&gt;=&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__sl_comment">//&nbsp;User&nbsp;cancelled.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;<span class="js__string">'User&nbsp;cancelled'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">'server_response'</span>).innerHTML&nbsp;=&nbsp;getUploadResponse(response);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<h1>More Information</h1>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/document-scan-upload-image-browser/direct-to-server-php-asp.net-overview.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="http://asprise.com/res/img/icon-scan-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Learn
 more about Scanner.JS: JavaScript browser based scan from TWAIN WIA Scanners</a></p>
<p style="font-size:15px; line-height:22px; margin-top:0px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="http://asprise.com/document-scan-upload-image-browser/ie-chrome-firefox-scanner-docs.html" target="_blank" style="text-decoration:none; color:#0066aa"><img src="http://asprise.com/res/img/icon-book-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">Access
 to Scanner.js Developer's Guide</a></p>
<p style="font-size:15px; line-height:22px; color:#333333; font-family:proxima_nova_rgregular,&quot;Droid Sans&quot;,sans-serif; font-style:normal; font-weight:normal; letter-spacing:normal; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px; background-color:#ffffff">
<a href="https://github.com/Asprise/scannerjs.javascript-scanner-access-in-browsers-chrome-ie.scanner.js" target="_blank" style="text-decoration:none; color:#0066aa"><img src="http://asprise.com/res/img/icon-github-32.png" alt="" width="28" align="middle" style="border:0px none; margin-right:8px">View
 Scanner.js Samples on Github</a></p>
