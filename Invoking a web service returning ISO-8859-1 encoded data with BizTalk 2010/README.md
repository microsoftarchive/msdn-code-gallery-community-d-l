# Invoking a web service returning ISO-8859-1 encoded data with BizTalk 2010
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- BizTalk Server
- BizTalk
- BizTalk Server 2010
## Topics
- WCF Adapter
## Updated
- 02/06/2013
## Description

<h1>Introduction</h1>
<p>The&nbsp;TextMessageEncodingBindingElement&nbsp;of WCF supports only the UTF-8, UTF-16 and Big Endean Unicode encodings. If the web service returns response in some other encoding e.g. ISO-8859-1 need to be consumed in BizTalk Server 2010 then the following
 error get logged in the event viewer:</p>
<p><strong><em><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.ServiceModel.ProtocolException.aspx" target="_blank" title="Auto generated link to System.ServiceModel.ProtocolException">System.ServiceModel.ProtocolException</a>: The content type text/xml of the response message does not match the content type of the binding (application/soap&#43;xml; charset=utf-8). If using a custom encoder, be sure that the IsContentTypeSupported
 method is implemented properly.</em></strong></p>
<h1>Description</h1>
<p>The solution to above problem is to create a custom text message encoder binding element capable of handling other encodings. One such element is already provided part of
<a href="http://msdn.microsoft.com/en-us/library/ms751486.aspx">WCF Samples</a>. I have used it to receive response from the web services returing ISO-8859-1 encoded data.&nbsp;The trick was to override the property IsContentTypeSupported (to handle different
 content types with the same media type) in the class CustomTextMessageEncoder in the sample code as shown below:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsContentTypeSupported(<span class="cs__keyword">string</span>&nbsp;contentType)&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">base</span>.IsContentTypeSupported(contentType))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contentType.Length&nbsp;==&nbsp;<span class="cs__keyword">this</span>.MediaType.Length)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;contentType.Equals(<span class="cs__keyword">this</span>.MediaType,&nbsp;StringComparison.OrdinalIgnoreCase);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contentType.StartsWith(<span class="cs__keyword">this</span>.MediaType,&nbsp;StringComparison.OrdinalIgnoreCase)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&amp;&nbsp;(contentType[<span class="cs__keyword">this</span>.MediaType.Length]&nbsp;==&nbsp;<span class="cs__string">';'</span>))&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<h1>Building the Sample</h1>
<p>- Build the code and install the assembly CustomTextMessageEncoder.dll&nbsp;to GAC.</p>
<p>- Update the machine.config at path C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config and add the following element to section &lt;system.serviceModel&gt;/&lt;extensions&gt;/&lt;bindingElementExtensions&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;add name=&quot;customTextMessageEncoding&quot; type=&quot;Microsoft.Samples.CustomTextMessageEncoder.CustomTextMessageEncodingElement, CustomTextMessageEncoder, Version=4.0.0.0, Culture=neutral, PublicKeyToken=71062dbfcab17aa3&quot;/&gt;</p>
<p><strong>Note:</strong> Update the PublicKeyToken as per the key used to create the strong name for the assembly.</p>
<h1>Using the customTextMessageEncoding element</h1>
<p>-After making the required changes in WCF-Custom Transport Proprties dialog box go to Binding tab and choose the customBinding for Binding Type and remove all element. Right click the CustomBindingElemnent and coose Add extension... as shown below:</p>
<p><img id="75602" src="75602-01.png" alt="" width="421" height="580"></p>
<p>-Select customTextMessageEncoding element and repeat the same process for httpTransport element too.</p>
<p><img id="75603" src="75603-02.png" alt=""></p>
<h1><img id="75604" src="75604-02.png" alt="" width="400" height="360"></h1>
<p>-Configure the properties of customTextMessageEncoding element as shown below and now you would be able to received message encoded in encoding as long as the Media Type of response is text/xml.</p>
<p><img id="75605" src="75605-03.png" alt="" width="420" height="580"></p>
<h1><span>Source Code Files</span></h1>
<p><em><em>In the Zip file:</em></em></p>
<ul>
<li><em>the&nbsp;CustomTextMessageEncoder folder contain the C# project for text encoder.</em>
</li><li><em><em>the Config folder contain machine.config containg the details of modification need to be done to machine.config at path&nbsp;C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config</em></em>
</li></ul>
<h1>Abount Me</h1>
<pre><strong><span>Rohit Sharma</span></strong><span>&nbsp;</span></pre>
<pre><strong><span>Microsoft Integration - MVP</span></strong></pre>
<pre><strong><span><a href="http://rohitt-sharma.blogspot.com"><span>http://rohitt-sharma.blogspot.com</span></a></span></strong></pre>
