# JQuery Notification and Status messages SharePoint Add In
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- SharePoint
- jQuery
- Javascript
- Sharepoint Online
- HTML5
- SharePoint 2013
- SharePoint 2016
## Topics
- SharePoint
- jQuery
- Javascript
- Notifications
- SharePoint 2013
- SharePoint 2016
## Updated
- 02/26/2016
## Description

<h1>Introduction</h1>
<p>IntroductionThere are multiple ways we can show notifications or status from SharePoint Add In, in this article we can find more detail about SharePoint Out of box notification, status and JQuery notification implementation logic</p>
<p><img id="148772" src="148772-main%20notification%20-%20copy.jpg" alt="" width="683" height="324"></p>
<p><br>
<strong>Solution compatibility</strong></p>
<p>This sample is tested with SharePoint Online</p>
<p>This sample also compatible with SharePoint 2013 and SharePoint 2016</p>
<p><br>
<strong>To Modify and deploy this solution</strong></p>
<p>Open visual studio 2015</p>
<p>On the file menu select Open -&gt; Project (Ctrl &#43; Shift &#43; o)</p>
<p>In the Open Project window navigate the directory and select solution file (.sln)</p>
<p>Open solution explorer windows and select project solution and click (F4) to open project propertiesChange the site URL property on the property window&nbsp;</p>
<p>Edit the code if required and click play button or (F5) in visual studio&nbsp;</p>
<p>&nbsp;</p>
<p><strong>To add new resource file (.js or .css or Images) into project</strong></p>
<p>Select a folder from solution explorer based on your file type (Images or Scripts or Content for CSS)</p>
<p>Right click and select &ldquo;Open Folder in File Explorer&rdquo; option</p>
<p>Now paste your files into the folderAgain in the solution explorer window at the top, click &ldquo;Show All Files&rdquo; icon</p>
<p>Now you can find the file without active icon, right click and select &ldquo;Include in Project&rdquo; Option</p>
<p><strong>Notification and Status messages</strong></p>
<p>In the App.js file (which is located under scripts folder) cleanup all unnecessary code,&nbsp;and using css selector select buttons and write functions inside click event.</p>
<p><strong>SharePoint Out of Box Status&nbsp;</strong></p>
<p>SP.UI.Status class provides methods for managing status messages. while we pass the color name as parameter to methods use lower&nbsp;case,&nbsp;Ex: red, green... if you pass it as &quot;Red&quot; then JavaScript won't recognize it,because JavaScript is case sensitive.</p>
<p><strong>SharePoint Out of Box Notification</strong></p>
<p>SP.UI.Notify calss provides methods for managing notifications, we can pass notification message as HTML and by default, notifications appear for five seconds also we have option to adjusting&nbsp;this time</p>
<p><strong>JQuery Notification</strong></p>
<p><a href="https://notifyjs.com/" target="_blank">Notify.min.js</a>&nbsp;used for JQuery notification, we can get extreme level of flexibility when we use JQuery notification also it is very simple to call with varies parameter. We can call any corner of the
 window or any side of the element</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">html</span>


<div class="preview">
<pre class="js"><span class="js__string">'use&nbsp;strict'</span>;&nbsp;
&nbsp;
ExecuteOrDelayUntilScriptLoaded(initializePage,&nbsp;<span class="js__string">&quot;sp.js&quot;</span>);&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;initializePage()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//This&nbsp;function&nbsp;creates&nbsp;a&nbsp;new&nbsp;notification&nbsp;on&nbsp;your&nbsp;this&nbsp;Add-In</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnAddNotification'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;message&nbsp;inside&nbsp;the&nbsp;notification.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;strHtml&nbsp;=&nbsp;<span class="js__string">&quot;&lt;img&nbsp;width='15px'&nbsp;src=\&quot;../Images/loading.gif\&quot;&nbsp;/&gt;&nbsp;Loading&nbsp;&lt;b&gt;please&nbsp;wait...&lt;/b&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Specifies&nbsp;whether&nbsp;the&nbsp;notification&nbsp;stays&nbsp;on&nbsp;the&nbsp;page&nbsp;until&nbsp;removed.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bSticky&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Adds&nbsp;a&nbsp;notification&nbsp;to&nbsp;the&nbsp;page.&nbsp;By&nbsp;default,&nbsp;notifications&nbsp;appear&nbsp;for&nbsp;five&nbsp;seconds.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Notify.addNotification(strHtml,&nbsp;bSticky);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;ID&nbsp;of&nbsp;the&nbsp;status&nbsp;to&nbsp;update.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;spstatus;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//this&nbsp;function&nbsp;Adds&nbsp;a&nbsp;status&nbsp;message&nbsp;to&nbsp;the&nbsp;Add-in&nbsp;page.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnAddStatus'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;title&nbsp;of&nbsp;the&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;strTitle&nbsp;=&nbsp;<span class="js__string">&quot;SPTECHNET&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;contents&nbsp;of&nbsp;the&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;strHtml&nbsp;=&nbsp;<span class="js__string">&quot;New&nbsp;Status&nbsp;&lt;b&gt;massage&lt;/b&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Specifies&nbsp;whether&nbsp;the&nbsp;status&nbsp;message&nbsp;will&nbsp;appear&nbsp;at&nbsp;the&nbsp;beginning&nbsp;of&nbsp;the&nbsp;list.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;atBegining&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;spstatus&nbsp;=&nbsp;SP.UI.Status.addStatus(strTitle,&nbsp;strHtml,&nbsp;atBegining);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;color&nbsp;to&nbsp;set&nbsp;for&nbsp;the&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Status.setStatusPriColor(spstatus,&nbsp;<span class="js__string">&quot;green&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnModifyStatus'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;new&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;strHtml&nbsp;=&nbsp;<span class="js__string">&quot;Modified&nbsp;Status&nbsp;&lt;b&gt;massage&lt;/b&gt;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Updates&nbsp;the&nbsp;specified&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Status.updateStatus(spstatus,&nbsp;strHtml);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;color&nbsp;to&nbsp;set&nbsp;for&nbsp;the&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Status.setStatusPriColor(spstatus,&nbsp;<span class="js__string">&quot;blue&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnStatusColour'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;strColor&nbsp;=&nbsp;<span class="js__string">&quot;red&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//The&nbsp;color&nbsp;to&nbsp;set&nbsp;for&nbsp;the&nbsp;status&nbsp;message.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Status.setStatusPriColor(spstatus,&nbsp;strColor);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnRemoveStatus'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Removes&nbsp;all&nbsp;status&nbsp;messages&nbsp;from&nbsp;the&nbsp;page.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SP.UI.Status.removeAllStatus(true);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#btnJQueryStatus'</span>).click(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Show&nbsp;JQuery&nbsp;status&nbsp;messages&nbsp;from&nbsp;the&nbsp;page.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.notify(<span class="js__string">&quot;Access&nbsp;granted&quot;</span>,&nbsp;<span class="js__string">&quot;success&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.notify(<span class="js__string">&quot;Warning:&nbsp;Self-destruct&nbsp;in&nbsp;3..&nbsp;2..&quot;</span>,&nbsp;<span class="js__string">&quot;warn&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#txtName'</span>).notify(<span class="js__string">&quot;This&nbsp;field&nbsp;is&nbsp;required&quot;</span>,&nbsp;<span class="js__string">&quot;info&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.notify(<span class="js__string">&quot;BOOM!&quot;</span>,&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;whether&nbsp;to&nbsp;hide&nbsp;the&nbsp;notification&nbsp;on&nbsp;click</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clickToHide:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;whether&nbsp;to&nbsp;auto-hide&nbsp;the&nbsp;notification</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;autoHide:&nbsp;false,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;if&nbsp;autoHide,&nbsp;hide&nbsp;after&nbsp;milliseconds</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;autoHideDelay:&nbsp;<span class="js__num">5000</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;show&nbsp;the&nbsp;arrow&nbsp;pointing&nbsp;at&nbsp;the&nbsp;element</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;arrowShow:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;arrow&nbsp;size&nbsp;in&nbsp;pixels</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;arrowSize:&nbsp;<span class="js__num">5</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;position&nbsp;defines&nbsp;the&nbsp;notification&nbsp;position&nbsp;though&nbsp;uses&nbsp;the&nbsp;defaults&nbsp;below</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;position:&nbsp;<span class="js__string">'top&nbsp;right'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;positions</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elementPosition:&nbsp;<span class="js__string">'top&nbsp;right'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;globalPosition:&nbsp;<span class="js__string">'top&nbsp;right'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;style</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;style:&nbsp;<span class="js__string">'bootstrap'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;default&nbsp;class&nbsp;(string&nbsp;or&nbsp;[string])</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;className:&nbsp;<span class="js__string">'error'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;show&nbsp;animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;showAnimation:&nbsp;<span class="js__string">'slideDown'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;show&nbsp;animation&nbsp;duration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;showDuration:&nbsp;<span class="js__num">400</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;hide&nbsp;animation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hideAnimation:&nbsp;<span class="js__string">'slideUp'</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;hide&nbsp;animation&nbsp;duration</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;hideDuration:&nbsp;<span class="js__num">200</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;padding&nbsp;between&nbsp;element&nbsp;and&nbsp;notification</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gap:&nbsp;<span class="js__num">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div>
<p>*****************************************************************************************************</p>
<p>Hope you find this sample helpful, check out my other samples too.</p>
<p>Give five stars if you wish to appreciate my work.</p>
<p>Facebook page URL: <a title="https://www.facebook.com/sptechnet2016/" href="https://www.facebook.com/sptechnet2016/" target="_blank">
https://www.facebook.com/sptechnet2016/</a></p>
<p>Blog URL: <a title="https://sptechnet.wordpress.com/" href="https://sptechnet.wordpress.com/" target="_blank">
https://sptechnet.wordpress.com/</a></p>
<p>*****************************************************************************************************</p>
</div>
