# How to transform XML using XSLT, all parameters as strings. No file system.
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- XML
- XSLT
- XmlSerializer
## Topics
- XML Serialization
- XSL
- XSLT transformation
## Updated
- 05/04/2011
## Description

<h1>
<p>How to transform XML using XSLT, all parameters as strings. No file system.</p>
</h1>
<p>Follow this steps to serialize an object as XML and transform it as another format through XSLT:<br>
1. create an object<br>
2. serialize it in XML using the class XmlSerializerHelper<br>
3. load the XSLT transform document as string using the class ResourcesReader (or what you prefer)<br>
4. transform the XML using the class XsltTransformer</p>
<p>For example you can create a Person object instance, get its XML and then have an HTML to present in a webpage a formatted structure using CSS also.</p>
<p>Is really important to dispose all used objects, the XlsCompiledTransform class has possible memory leaks if not correctly disposed.</p>
<p>Is also important to create it only one time for XML/XSLT use case because it is quite expansive as CPU usage because the XSLT document must compiled every time.</p>
<p>So keep a XsltTransformer for each class/XSLT document you want to transform.</p>
<p>XSLT is really wonderful for a large variety of scenarios, for exaple you can use in ASP.NET MVC to display your DTO (Data Transfer Object) in a formatted structure and change it without touching the HTML you wrote in you application. So you can simply change
 the XSLT document and the that's it!</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;XmlSerializerHelper&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Serialize(<span class="visualBasic__keyword">ByVal</span>&nbsp;obj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;serializer&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XmlSerializer(obj.<span class="visualBasic__keyword">GetType</span>())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;writerSettings&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XmlWriterSettings&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;{.OmitXmlDeclaration&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>,&nbsp;.Indent&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;emptyNameSpace&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;XmlSerializerNamespaces()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;emptyNameSpace.Add(<span class="visualBasic__keyword">String</span>.Empty,&nbsp;<span class="visualBasic__keyword">String</span>.Empty)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;stringWriter&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringWriter()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;XmlWriter&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;XmlWriter&nbsp;=&nbsp;XmlWriter.Create(stringWriter,&nbsp;writerSettings)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;serializer.Serialize(XmlWriter,&nbsp;obj,&nbsp;emptyNameSpace)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;stringWriter.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">stylesheet</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">xsl</span>=<span class="xml__attr_value">&quot;http://www.w3.org/1999/XSL/Transform&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">output</span>&nbsp;<span class="xml__attr_name">method</span>=<span class="xml__attr_value">&quot;xml&quot;</span>&nbsp;<span class="xml__attr_name">indent</span>=<span class="xml__attr_value">&quot;yes&quot;</span>&nbsp;<span class="xml__attr_name">omit-xml-declaration</span>=<span class="xml__attr_value">&quot;yes&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">template</span>&nbsp;<span class="xml__attr_name">match</span>=<span class="xml__attr_value">&quot;/&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;html</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;body</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;div</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">apply-templates</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/div&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/body&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/html&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/xsl:template&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">template</span>&nbsp;<span class="xml__attr_name">match</span>=<span class="xml__attr_value">&quot;Person&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:&nbsp;<span class="xml__tag_start">&lt;b</span><span class="xml__tag_start">&gt;</span><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">value-of</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;Name&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/b&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;br</span><span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age:&nbsp;<span class="xml__tag_start">&lt;b</span><span class="xml__tag_start">&gt;</span><span class="xml__tag_start">&lt;xsl</span>:<span class="xml__keyword">value-of</span>&nbsp;<span class="xml__attr_name">select</span>=<span class="xml__attr_value">&quot;Age&quot;</span><span class="xml__tag_start">/&gt;</span><span class="xml__tag_end">&lt;/b&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/xsl:template&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/xsl:stylesheet&gt;</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;XsltTransformer&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;XslCompiledTransform&nbsp;xslTransform;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;XsltTransformer(<span class="cs__keyword">string</span>&nbsp;xsl)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xslTransform&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XslCompiledTransform();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;stringReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringReader(xsl))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;xslt&nbsp;=&nbsp;XmlReader.Create(stringReader))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xslTransform.Load(xslt);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Transform(<span class="cs__keyword">object</span>&nbsp;person)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;xml&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlSerializerHelper()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Serialize(person);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;writer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;input&nbsp;=&nbsp;XmlReader.Create(<span class="cs__keyword">new</span>&nbsp;StringReader(xml)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xslTransform.Transform(input,&nbsp;<span class="cs__keyword">null</span>,&nbsp;writer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;writer.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<p><em>&nbsp;</em></p>
</div>
</h1>
