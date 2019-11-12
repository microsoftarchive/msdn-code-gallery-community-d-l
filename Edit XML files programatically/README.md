# Edit XML files programatically
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- XML
## Topics
- XML Programming
## Updated
- 01/28/2013
## Description

<div>Many times i have found questions regarding how to edit/update contents of xml file programatically.
<br>
This sample application is very simple, it consists of a xml file and some application code. Before going further i would like to bring focus on IEnumrable and IEnumerator interface. Hope you were knowing this but still a brief information about these :</div>
<div><br>
IEnumrable : This interface provides contract so that any engine can iterate over that object(these kind of objects are known as Collection). So, for Collection it is compulsary that it should implement IEnumrable. Actually, IEnumrable itself does not contain
 any complex thing. It only contains a method GetEnumrator, of type IEnumrator.</div>
<div>IEnumrator : This interface contains contracts that how the iteration should work i.e., logic of iteration. One of the important method in this interface is MoveNext() which gives the next item from the collection of objects.</div>
<div>Now, come to origional topic :<br>
Your XML document can be loaded in .NET object using Load method of XmlDocument class. This XmlDocument class will then represent that xml document.</div>
<div>Suppose your xml document contains :</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="js">&lt;appSettings&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;URL&quot;</span>&nbsp;value=<span class="js__string">&quot;http://&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;Server2ClientPort&quot;</span>&nbsp;value=<span class="js__string">&quot;1234&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;ServerAddress&quot;</span>&nbsp;value=<span class="js__string">&quot;hello&quot;</span>&nbsp;/&gt;&nbsp;
&lt;/appSettings&gt;</pre>
</div>
</div>
</div>
</div>
<div>And programatically you want to change value of value attribute where key=&quot;URL&quot;.</div>
<div>So, first of all load your xml document in XmlDocument object using its Load method :</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">XmlDocument&nbsp;doc&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;XmlDocument();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;path&nbsp;=&nbsp;@&quot;C:\Users\TestFolder\EditXmlDemo\EditXmlDemo&nbsp;
&nbsp;
\XMLFile1.xml&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.Load(path);</pre>
</div>
</div>
</div>
</div>
<div>Then using SelectNodes method get get IEnumrator object so that using MoveNext you can iterate over that collection and fullfill your required conditions.</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">IEnumerator&nbsp;ie&nbsp;=&nbsp;doc.SelectNodes(<span class="js__string">&quot;/appSettings/add&quot;</span>).GetEnumerator();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">while</span>&nbsp;(ie.MoveNext())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__statement">if</span>&nbsp;((ie.Current&nbsp;as&nbsp;XmlNode).Attributes[<span class="js__string">&quot;key&quot;</span>].Value&nbsp;==&nbsp;&nbsp;
&nbsp;
<span class="js__string">&quot;ServerAddress&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(ie.Current&nbsp;as&nbsp;XmlNode).Attributes[<span class="js__string">&quot;value&quot;</span>].Value&nbsp;=&nbsp;&nbsp;
&nbsp;
<span class="js__string">&quot;hello&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;doc.Save(path);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This way you can change content of your xml files programatically.</div>
<div class="endscriptcode">Remember to add reference to&nbsp; <span style="font-family:Consolas; font-size:x-small">
<span style="font-family:Consolas; font-size:x-small"><strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Xml.aspx" target="_blank" title="Auto generated link to System.Xml">System.Xml</a> </strong>
and <strong><a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.aspx" target="_blank" title="Auto generated link to System.Collections">System.Collections</a> </strong>namespace at top and give proper path of XML file that you have to edit.</span></span>
<div><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small">
<div>&nbsp;</div>
</span></span><span style="font-family:Consolas; font-size:x-small"><span style="font-family:Consolas; font-size:x-small"></span></span></div>
<div>&nbsp;</div>
<h1><em>&nbsp;</em></h1>
</div>
</div>
