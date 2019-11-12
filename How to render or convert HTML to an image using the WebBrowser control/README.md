# How to render or convert HTML to an image using the WebBrowser control
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- WebBrowser
- HTML
- Converter
## Topics
- Convert (X)HTML to an image
- Website snapshot
## Updated
- 05/02/2011
## Description

<h1>Introduction</h1>
<div><em>Want to render a custom HTML or a web page to an image. This sample shows how to implement a HTML to image &quot;converter&quot;.<br>
</em><span style="font-size:20px; font-weight:bold"><br>
Description<br>
<span style="font-size:x-small">&nbsp;</span></span></div>
<div>
<div><em>Want to render a custom HTML or a web page to an image. This sample shows how to implement a HTML to image &quot;converter&quot; using the WebBrowser control and native methods to get the image from it. Now is implemented in a synchronous way but it possible
 to use queues or events to make it asynchronous.<br>
Is possible to convert a custom HTML or a web page passing an url. To export the image from the WebBrowser control I used a native method that allow to get an image from a control using Windows API(s) using GetHdc and Draw functions.<br>
This code sample is similar to Snapshots.com functions.<br>
<br>
To use it you have to instantiate the HtmlToBitmapConverter class, than you can choose between two overloads of the&nbsp;Render
</em></div>
<div><em>method:<br>
1. Render(string html, Size size)<br>
1. Render(Uri uri, Size size)<br>
<br>
The size is used to set the size of the WebBrowser control so you will have a snapshot of the website given at that resolution.<br>
The parser is provided by your version of Internet Explorer installed on your machine. So if you have IE9 the snapshot will be from IE9 and so on.<br>
<br>
That's all.<br>
<br>
</em>
<div>
<div>
<div>
<div>
<div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
</div>
</div>
</div>
</div>
<div><em><em>
<div><em><em>
<div><em><em>
<div><em><em>
<div><em><br>
Here a code snippet:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">Modifica script</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">pictureBox.Image&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;HtmlToBitmapConverter()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Render(<span class="cs__keyword">new</span>&nbsp;Uri(urlTextBox.Text),&nbsp;pictureBox.Size);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
Here the full code of the class:<br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginEditHolderLink">Modifica script</div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">public&nbsp;class&nbsp;HtmlToBitmapConverter&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;<span class="js__statement">const</span>&nbsp;int&nbsp;SleepTimeMiliseconds&nbsp;=&nbsp;<span class="js__num">5000</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Bitmap&nbsp;Render(string&nbsp;html,&nbsp;Size&nbsp;size)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;browser&nbsp;=&nbsp;CreateBrowser(size);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;browser.Navigate(<span class="js__string">&quot;about:blank&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;browser.Document.Write(html);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;GetBitmapFromControl(browser,&nbsp;size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Bitmap&nbsp;Render(Uri&nbsp;uri,&nbsp;Size&nbsp;size)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;browser&nbsp;=&nbsp;CreateBrowser(size);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NavigateAndWaitForLoad(browser,&nbsp;uri,&nbsp;<span class="js__num">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;GetBitmapFromControl(browser,&nbsp;size);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;NavigateAndWaitForLoad(WebBrowser&nbsp;browser,&nbsp;Uri&nbsp;uri,&nbsp;int&nbsp;waitTime)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;browser.Navigate(uri);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;count&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(browser.ReadyState&nbsp;!=&nbsp;WebBrowserReadyState.Complete)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Thread.Sleep(SleepTimeMiliseconds);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.DoEvents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(count&nbsp;&gt;&nbsp;waitTime&nbsp;/&nbsp;SleepTimeMiliseconds)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">break</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;WebBrowser&nbsp;CreateBrowser(Size&nbsp;size)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;WebBrowser&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ScrollBarsEnabled&nbsp;=&nbsp;false,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ScriptErrorsSuppressed&nbsp;=&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Size&nbsp;=&nbsp;size&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;Bitmap&nbsp;GetBitmapFromControl(WebBrowser&nbsp;browser,&nbsp;Size&nbsp;size)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;bitmap&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(size.Width,&nbsp;size.Height);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NativeMethods.GetImage(browser.Document.DomDocument,&nbsp;bitmap,&nbsp;Color.White);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;bitmap;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</em>
<div class="endscriptcode"></div>
</div>
</em>
<div>
<div class="endscriptcode"></div>
</div>
</em>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</em>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</em>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</em>
<div>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</em>
<div>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</div>
</em>
<div>
<div>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</div>
</em>
<div>
<div>
<div>
<div>
<div class="endscriptcode"></div>
</div>
</div>
</div>
</div>
</div>
</div>
