# Extensibility for the Microsoft Dynamics NAV Tablet Client
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Javascript
- Dynamics NAV
- C/AL
## Topics
- Dynamics NAV client extensibility
## Updated
- 12/03/2014
## Description

<h1>Get in touch</h1>
<p>The touch interface on tablet devices opens for a few new cool scenarios. One of the obvious usage of touch is to allow users to write directly on the tablet, for example to sign documents.</p>
<p><img id="125226" src="125226-signatureaddin.png" alt="" width="375" height="249"></p>
<p>With this sample, I will walk you through how to develop a client control add-in with JavaScript that you will be able to add to any Microsoft Dynamics NAV page. This add-in shows a box in which the user can write with a tablet pen or just with his finger.
 It also demonstrates how to save the image into a Microsoft Dynamics NAV table as a BLOB.</p>
<p>If you are not familiar with JavaScript client add-ins or if you just need a refresher, take a look at
<a href="http://go.microsoft.com/fwlink/?LinkId=511931">this walkthrough</a> for your classic &lsquo;Hello World&rsquo; example.</p>
<p>I am referring to this add-in as the &lsquo;Signature Add-in&rsquo; and to the graphical data as &lsquo;the signature&rsquo;, but it could really be any type of hand-drawn graphics.</p>
<p>So, let&rsquo;s get started.</p>
<h1>Creating the C# class library</h1>
<p>In Visual Studio, create a new C# class library project and add a reference to the
<code>Microsoft.Dynamics.Framework.UI.Extensibility.dll</code> assembly. You will find this assembly in a directory similar to C:\Program Files (x86)\Microsoft Dynamics NAV\80\RoleTailored Client.</p>
<p>If you are already familiar with Microsoft Dynamics NAV HTML/JavaScript add-ins, you know that the purpose of this class library is merely to specify the interface and make the C/AL compiler happy. It does not contain any actual executing code.</p>
<p>On the server side, besides the usual <strong>AddInReady </strong>event, we will need two more events; one to write the signature data: the
<strong>SaveSignature </strong>and one to read the signature from the Microsoft Dynamics NAV table to trigger an update on the page; the
<strong>UpdateSignature</strong>.</p>
<p>On the client side, that is in the JavaScript code, we also need a method to actually draw the graphics and we also want to be able to clear the content.</p>
<p>To specify this API, create a single public interface looking like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;SignatureAddin&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Dynamics.Framework.UI.Extensibility.aspx" target="_blank" title="Auto generated link to Microsoft.Dynamics.Framework.UI.Extensibility">Microsoft.Dynamics.Framework.UI.Extensibility</a>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Interface&nbsp;definition&nbsp;for&nbsp;the&nbsp;signature&nbsp;addin.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ControlAddInExport(<span class="cs__string">&quot;SignatureControl&quot;</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;ISignatureAddin&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ApplicationVisible]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">event</span>&nbsp;ApplicationEventHandler&nbsp;AddInReady;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ApplicationVisible]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">event</span>&nbsp;ApplicationEventHandler&nbsp;UpdateSignature;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ApplicationVisible]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">event</span>&nbsp;SaveSignatureEventHandler&nbsp;SaveSignature;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ApplicationVisible]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;ClearSignature();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ApplicationVisible]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">void</span>&nbsp;PutSignature(<span class="cs__keyword">string</span>&nbsp;signatureData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">delegate</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;SaveSignatureEventHandler(<span class="cs__keyword">string</span>&nbsp;signatureData);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Notice that the SaveSignatureEventHandler delegate takes a string parameter, which will contain the actual serialized data representing the image.</div>
<p>Build your assembly to make sure you did not forget a semicolon somewhere.</p>
<p>Next, you will need to sign your assembly, obtain its public key&nbsp;token and copy it to the client add-ins folder. To do that, follow the steps as described in the
<a href="http://go.microsoft.com/fwlink/?LinkId=511931">walkthrough</a>.</p>
<h1>Creating the manifest file</h1>
<p>In the manifest of an add-in, which is just regular XML file, we specify the resources that the control will use. The client side code consists of one single JavaScript file
<strong>signature.js</strong> and use a single CSS file to style the HTML. We will also add a call to an initialization method in our script. The manifest is a good place to do that as the framework ensures that it gets called only when the browser is ready.</p>
<p>That makes our manifest look like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;Manifest</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;Resources</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;Script</span><span class="xml__tag_start">&gt;</span>signature.js<span class="xml__tag_end">&lt;/Script&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;StyleSheet</span><span class="xml__tag_start">&gt;</span>signature.css<span class="xml__tag_end">&lt;/StyleSheet&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Resources&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;ScriptUrls</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_end">&lt;/ScriptUrls&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;Script</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__unParsedSection">&lt;![CDATA[&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;init();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;]]&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/Script&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;RequestedHeight</span><span class="xml__tag_start">&gt;</span>200<span class="xml__tag_end">&lt;/RequestedHeight&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;RequestedWidth</span><span class="xml__tag_start">&gt;</span>700<span class="xml__tag_end">&lt;/RequestedWidth&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;VerticalStretch</span><span class="xml__tag_start">&gt;</span>false<span class="xml__tag_end">&lt;/VerticalStretch&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;HorizontalStretch</span><span class="xml__tag_start">&gt;</span>false<span class="xml__tag_end">&lt;/HorizontalStretch&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/Manifest&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>Creating the CSS file</h1>
<p>No big deal here, just create a file named <strong>signature.css</strong> (the name needs to match the one in the manifest) with the following content:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>

<div class="preview">
<pre class="css"><span class="css__class">.signatureArea</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span>&nbsp;<span class="css__number">300px</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="css__class">.signatureCanvas</span>&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border:</span>&nbsp;<span class="css__value">solid</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border-width:</span>&nbsp;<span class="css__number">1px</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">border-color:</span>&nbsp;<span class="css__color">#777777</span>;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#fff</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="css__property">width:</span>&nbsp;<span class="css__number">100%</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;touch-action:&nbsp;<span class="css__value">none</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="css__class">.signatureButton</span>&nbsp;{&nbsp;
&nbsp;&nbsp;<span class="css__property">width:</span>&nbsp;<span class="css__number">100px</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">height:</span>&nbsp;<span class="css__number">40px</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">color:</span>&nbsp;<span class="css__color">white</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">background-color:</span>&nbsp;<span class="css__color">#666666</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">font-size:</span>&nbsp;<span class="css__number">12pt</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">outline:</span>&nbsp;<span class="css__number">0</span>;&nbsp;
&nbsp;&nbsp;<span class="css__property">border-color:</span>&nbsp;<span class="css__color">white</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Notice the 'touch-action: none;' directive. This is necessary on Windows/IE. It means that the touch gestures should only be&nbsp;handled by this HTML element&nbsp;and not by the entire browser. If you do not have this,&nbsp;moving
 your finger in the area will trigger a scroll instead.</div>
<div class="endscriptcode">Feel free to play with the styles, this will only affect your add-in and will not affect the Microsoft Dynamics NAV pages whatsoever.</div>
<p>&nbsp;</p>
<h1>The interesting part</h1>
<p>All of what has been described so far is boilerplate stuff, which you will have to do for any Microsoft Dynamics NAV HTML client add-in. We are now getting to the interesting piece, which is the JavaScript code.</p>
<p>Create a file named <strong>signature.js</strong>. Again here, the name has to match the one you declared in the manifest.</p>
<p>Let&rsquo;s start with the implementation of the interface contract that we previously defined in the C# class library:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;signature;&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;init()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ns.SignatureControl();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.init();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RaiseAddInReady();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;will&nbsp;be&nbsp;fired&nbsp;when&nbsp;the&nbsp;control&nbsp;add-in&nbsp;is&nbsp;ready&nbsp;for&nbsp;communication&nbsp;through&nbsp;its&nbsp;API.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseAddInReady()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'AddInReady'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;raised&nbsp;when&nbsp;the&nbsp;update&nbsp;signature&nbsp;has&nbsp;been&nbsp;called.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseUpdateSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'UpdateSignature'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;raised&nbsp;when&nbsp;the&nbsp;save&nbsp;signature&nbsp;has&nbsp;been&nbsp;called.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseSaveSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'SaveSignature'</span>,&nbsp;[signatureData]);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;PutSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.updateSignature(signatureData);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;ClearSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.clearSignature();&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">As you can see the SignatureControl object in the ns namespace is doing all the work, so let&rsquo;s take a closer look at it.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">(<span class="js__operator">function</span>&nbsp;(ns)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ns.SignatureControl&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;init()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createControlElements();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wireButtonEvents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wireTouchEvents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
...</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">Here we declare the SignatureControl class in the ns namespace and the init()method . The createControlElements() creates the various HTML elements that the control is made off.</div>
<div class="endscriptcode"></div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;createControlElements()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;signatureArea&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvasDiv&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonClear&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;canvas&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas.id&nbsp;=&nbsp;<span class="js__string">&quot;signatureCanvas&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas.clientWidth&nbsp;=&nbsp;<span class="js__string">&quot;100%&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas.clientHeight&nbsp;=&nbsp;<span class="js__string">&quot;100%&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvas.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureCanvas&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.id&nbsp;=&nbsp;<span class="js__string">&quot;btnClear&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Clear&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.id&nbsp;=&nbsp;<span class="js__string">&quot;btnAccept&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Accept&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.id&nbsp;=&nbsp;<span class="js__string">&quot;btnDraw&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Draw&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;canvasDiv.appendChild(canvas);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonDraw);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonAccept);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonClear);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureArea&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.appendChild(canvasDiv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.appendChild(buttonsContainer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">&quot;controlAddIn&quot;</span>).appendChild(signatureArea);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Besides plain old divs and buttons, the canvas is where we will actually be able to draw. Canvas has been supported in most browsers for a while and you can read more about it
<a href="http://www.w3schools.com/html/html5_canvas.asp">here</a>.</div>
<div class="endscriptcode"></div>
<p>The control has three buttons. One to accept the signature, which will save it to the database, one to clear the field and one to redraw the signature from the database, mostly for test purposes, as you would probably not need it in most real-life scenarios.
 Let&rsquo;s wire these buttons so do something useful:</p>
&nbsp;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;wireButtonEvents()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;btnClear&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnClear&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnAccept&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnAccept&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnDraw&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnDraw&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnClear.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnAccept.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;signatureImage&nbsp;=&nbsp;getSignatureImage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseSaveSignature(signatureImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnDraw.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseUpdateSignature();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;false);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Notice that we use the drawing context ctx, that we obtained during initialization to clear the content of the canvas. We will see what the getSignatureImage() exactly does to obtain the data in a sec but before that let&rsquo;s
 wire the touch events.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<h1>The touch events</h1>
<p>In order to be able draw, we want to react to touch events. In this example, we also hook up mouse events, which is convenient if you want to test your add-in on a non-touch device with an old-fashioned mouse.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;wireTouchEvents()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointerdown&quot;</span>,&nbsp;pointerDown,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchstart&quot;</span>,&nbsp;pointerDown,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchend&quot;</span>,&nbsp;pointerUp,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointerup&quot;</span>,&nbsp;pointerUp,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.drawing&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<p>Touchstart and touchend are the events for&nbsp;Webkit based browser such as&nbsp;Safari or Chrome. PointerUp and PointerDown are Microsoft unified event model. They work for both touch and mouse indifferently.</p>
<p>Once we have detected a touchstart, the trick is to start listening to touchmove and draw in the canvas to the current position of the &lsquo;touching&rsquo;. Once we get a touchend, we will then stop the listening and the drawing:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;pointerDown(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;drawingOn&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;evt.preventDefault();&nbsp;
&nbsp;&nbsp;evt.stopPropagation();&nbsp;
&nbsp;&nbsp;ctx.beginPath();&nbsp;
&nbsp;
&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchmove&quot;</span>,&nbsp;paint,&nbsp;false);&nbsp;
&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointermove&quot;</span>,&nbsp;paint,&nbsp;false)&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;pointerUp(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;drawingOn&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;canvas.removeEventListener(<span class="js__string">&quot;touchmove&quot;</span>,&nbsp;paint);&nbsp;
&nbsp;&nbsp;canvas.removeEventListener(<span class="js__string">&quot;pointermove&quot;</span>,&nbsp;paint);&nbsp;
&nbsp;&nbsp;paint(evt);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;paint(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!drawingOn)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;evt.preventDefault();&nbsp;
&nbsp;&nbsp;evt.stopPropagation();&nbsp;
&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cursorX;&nbsp;
&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cursorY;&nbsp;
&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(window.event&nbsp;!=&nbsp;null&nbsp;&amp;&amp;&nbsp;window.event.targetTouches&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;touch&nbsp;=&nbsp;window.event.targetTouches[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cursorX&nbsp;=&nbsp;touch.pageX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cursorY&nbsp;=&nbsp;touch.pageY;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorX&nbsp;=&nbsp;evt.pageX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorY&nbsp;=&nbsp;evt.pageY;&nbsp;
&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;ctx.lineTo(cursorX,&nbsp;cursorY);&nbsp;
&nbsp;&nbsp;ctx.stroke();&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
&nbsp;
<h1 class="endscriptcode">Canvas image data</h1>
<p>We want to be able to serialize and de-serialize the image data from the canvas, so we can send it back and forth to the server in a string. The HTML canvas has built-in functionalities to do that through the context:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;updateSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;img&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;img.src&nbsp;=&nbsp;signatureData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(img,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;getSignatureImage()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;canvas.toDataURL();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;clearSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>The toDataURL() method converts the image into a (rather long) URL encoded string containing all the pixels. To convert it back, we only need to create an image and set its src property to this URL encoded string and pass this image to the method drawImage
 on the canvas context. This is pretty convenient as it allows us to use a simple string rather than more complex data structure such as arrays.</p>
<p>&nbsp;</p>
<p>We are now done with the JavaScript part and the entire file looks like this:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;signature;&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;init()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ns.SignatureControl();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.init();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RaiseAddInReady();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;will&nbsp;be&nbsp;fired&nbsp;when&nbsp;the&nbsp;control&nbsp;add-in&nbsp;is&nbsp;ready&nbsp;for&nbsp;communication&nbsp;through&nbsp;its&nbsp;API.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseAddInReady()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'AddInReady'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;raised&nbsp;when&nbsp;the&nbsp;update&nbsp;signature&nbsp;has&nbsp;been&nbsp;called.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseUpdateSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'UpdateSignature'</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Event&nbsp;raised&nbsp;when&nbsp;the&nbsp;save&nbsp;signature&nbsp;has&nbsp;been&nbsp;called.</span>&nbsp;
<span class="js__operator">function</span>&nbsp;RaiseSaveSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Dynamics.NAV.InvokeExtensibilityMethod(<span class="js__string">'SaveSignature'</span>,&nbsp;[signatureData]);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;PutSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.updateSignature(signatureData);&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
<span class="js__operator">function</span>&nbsp;ClearSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;signature.clearSignature();&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
(<span class="js__operator">function</span>&nbsp;(ns)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ns.SignatureControl&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;drawingOn&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;init()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;createControlElements();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wireButtonEvents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;wireTouchEvents();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx&nbsp;=&nbsp;canvas.getContext(<span class="js__string">&quot;2d&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;createControlElements()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;signatureArea&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvasDiv&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;div&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonClear&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;button&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;canvas&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.id&nbsp;=&nbsp;<span class="js__string">&quot;signatureCanvas&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.clientWidth&nbsp;=&nbsp;<span class="js__string">&quot;100%&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.clientHeight&nbsp;=&nbsp;<span class="js__string">&quot;100%&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureCanvas&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.id&nbsp;=&nbsp;<span class="js__string">&quot;btnClear&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Clear&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonClear.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.id&nbsp;=&nbsp;<span class="js__string">&quot;btnAccept&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Accept&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonAccept.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.id&nbsp;=&nbsp;<span class="js__string">&quot;btnDraw&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.textContent&nbsp;=&nbsp;<span class="js__string">&quot;Draw&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonDraw.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureButton&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvasDiv.appendChild(canvas);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonDraw);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonAccept);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;buttonsContainer.appendChild(buttonClear);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.className&nbsp;=&nbsp;<span class="js__string">&quot;signatureArea&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.appendChild(canvasDiv);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;signatureArea.appendChild(buttonsContainer);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.getElementById(<span class="js__string">&quot;controlAddIn&quot;</span>).appendChild(signatureArea);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;wireTouchEvents()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointerdown&quot;</span>,&nbsp;pointerDown,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchstart&quot;</span>,&nbsp;pointerDown,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchend&quot;</span>,&nbsp;pointerUp,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointerup&quot;</span>,&nbsp;pointerUp,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.drawing&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;pointerDown(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawingOn&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">&quot;pointer&nbsp;down.&nbsp;Drawing:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;drawingOn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;evt.preventDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;evt.stopPropagation();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.beginPath();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;touchmove&quot;</span>,&nbsp;paint,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.addEventListener(<span class="js__string">&quot;pointermove&quot;</span>,&nbsp;paint,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;pointerUp(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">&quot;pointer&nbsp;up.&nbsp;Drawing:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;drawingOn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawingOn&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.removeEventListener(<span class="js__string">&quot;touchmove&quot;</span>,&nbsp;paint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.removeEventListener(<span class="js__string">&quot;pointermove&quot;</span>,&nbsp;paint);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint(evt);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;paint(evt)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(<span class="js__string">&quot;paint.&nbsp;Drawing:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;drawingOn);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!drawingOn)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;evt.preventDefault();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;evt.stopPropagation();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cursorX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;cursorY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(window.event&nbsp;!=&nbsp;null&nbsp;&amp;&amp;&nbsp;window.event.targetTouches&nbsp;!=&nbsp;null)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;touch&nbsp;=&nbsp;window.event.targetTouches[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorX&nbsp;=&nbsp;touch.pageX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorY&nbsp;=&nbsp;touch.pageY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;<span class="js__statement">else</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorX&nbsp;=&nbsp;evt.pageX;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cursorY&nbsp;=&nbsp;evt.pageY;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.lineTo(cursorX,&nbsp;cursorY);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.stroke();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;wireButtonEvents()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;btnClear&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnClear&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnAccept&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnAccept&quot;</span>),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnDraw&nbsp;=&nbsp;document.getElementById(<span class="js__string">&quot;btnDraw&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnClear.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;clearSignature,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnAccept.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;signatureImage&nbsp;=&nbsp;getSignatureImage();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseSaveSignature(signatureImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;false);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnDraw.addEventListener(<span class="js__string">&quot;click&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RaiseUpdateSignature();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;false);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;updateSignature(signatureData)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;img&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Image();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.src&nbsp;=&nbsp;signatureData;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.drawImage(img,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;getSignatureImage()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;canvas.toDataURL();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;clearSignature()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;drawingOn&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ctx.clearRect(<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;canvas.width,&nbsp;canvas.height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;init:&nbsp;init,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;updateSignature:&nbsp;updateSignature,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;getSignatureImage:&nbsp;getSignatureImage,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;clearSignature:&nbsp;clearSignature&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>)(<span class="js__operator">this</span>.ns&nbsp;=&nbsp;<span class="js__operator">this</span>.ns&nbsp;||&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>);&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp; &nbsp;</div>
<h1>Packaging your add-in</h1>
<p>Now that we have all the parts of the component, we need to zip it together and import it in Microsoft Dynamics NAV. This is again as you would do for any other add-in.</p>
<p>Create a zip file with the following structure:</p>
<p>&nbsp;</p>
<p><img id="125229" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125229/1/folders.png" alt="" width="276" height="95"></p>
<p>Put the manifest at the root, the JavaScript file in the script folder and the CSS file in the Stylesheet folder.</p>
<p>Open any of the Microsoft Dynamics NAV clients (Windows, Web or Tablet) and go to the Control Add-ins page. Create a new entry named SignatureControl and enter the public key token that you saved earlier. Import the zip file.</p>
<p>&nbsp;</p>
<p><img id="125230" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125230/1/addinspage.png" alt="" width="665" height="307"></p>
&nbsp; &nbsp;
<h1>The C/SIDE side of things</h1>
<p>Now that our add-in is sitting comfortably within the confines of the Microsoft Dynamics NAV database, we need to add it to page. But before that, we want a place to save the signature image data. In this fabricated example, I will add the signature to the
 Sales Invoice card page from the Mini app (1304) which is based on the Sales Header table.</p>
<p>In Object Designer, open the Sales Header table and add BLOB field called &lsquo;SignatureImage&rsquo;</p>
&nbsp; &nbsp;
<p><img id="125231" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125231/1/tablet.png" alt="" width="611" height="455"></p>
<p>&nbsp;</p>
<p>Now&nbsp;add the actual control page by opening page 1304 and add the control into a separate group.</p>
<p>&nbsp;</p>
<p>&nbsp; &nbsp; <img id="125232" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125232/1/page.png" alt="" width="665" height="330"></p>
<p>&nbsp;<img id="125233" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125233/1/pageprops.png" alt="" width="535" height="290"></p>
<p>By now you should be able to fire up this page and see how our control looks like. To do that open the client of your choice in the mini app. Navigate to the Sales Invoices and open the Sales Invoice card page.</p>
<p>&nbsp;</p>
<p>You should see the signature control. Try to draw in with the mouse or with your finger if you are on a touch enabled device.</p>
<p>&nbsp;</p>
<p><img id="125235" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125235/1/controlonpage.png" alt="" width="489" height="351"></p>
&nbsp; &nbsp;
<p>Even the clear button works already and allows you to delete your doodles.</p>
<p>The last part that we are missing is to save and retrieve the pixels to the Microsoft Dynamics NAV database. To do that we need to write a bit of C/AL code</p>
<h1>The C/AL code</h1>
<p>If you recall how we defined the add-in interface, we have three triggers to take care of: AddInReady, UpdateSignature and SignatureSaved.</p>
<p>&nbsp;</p>
<p>&nbsp; &nbsp;<img id="125236" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125236/1/calcode1.png" alt="" width="640" height="401"></p>
<p>Nothing surprising here. The really interesting methods are <strong>SaveSignature</strong> and
<strong>GetDataUriFromImage</strong>.</p>
<p>This is where the conversion from between the URL encoded image string and a Microsoft Dynamics NAV BLOB occurs.</p>
<p>The most convenient way to do this is to use the power of .NET for regular expressions matching and memory streams.</p>
<p>So, let&rsquo;s create a <strong>SaveSignature</strong> method and add the following .NET type variables to the locals:</p>
<p>&nbsp;</p>
<p>&nbsp;<img id="125237" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125237/1/calcode2.png" alt="" width="583" height="274"></p>
<p>&nbsp;</p>
<p>The URL encoded representation of the image contains some goo around the actual pixel information. With .NET regular expressions, we strip the header by matching it and preserving the rest.</p>
<p>What is left is a base 64 encoded string, which we can convert to a byte array using the .net Convert utility class. We then pass it to the memory stream and save it to the Microsoft Dynamics NAV table as a BLOB.</p>
<p>&nbsp;<img id="125238" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125238/1/calcode3.png" alt="" width="665" height="177"></p>
<p>&nbsp;</p>
<p>Obtaining the encoded URI is obviously the reverse operation. This is somewhat simpler; after reading the BLOB, we just need to re-add the header.&nbsp;</p>
<p><img id="125239" src="http://i1.code.msdn.s-msft.com/extensibility-for-the-7600738d/image/file/125239/1/calcode4.png" alt="" width="631" height="162"></p>
<p>Finally, we want to update the drawing, when we navigate the records:</p>
<p>&nbsp;</p>
<h1>That&rsquo;s it!</h1>
<p>Now you should be able to save the graphics and when you close and re-open the page or navigate through the Sales Invoices, the picture gets updated accordingly.</p>
<p>Even though the most obvious usage scenarios are on the tablet, this add-in works on all three clients (Windows, Web and Tablet).</p>
&nbsp;