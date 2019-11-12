# Implementing Xml Serialization through a generic extension method
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- .NET
- XML
- .NET Framework 4
- .NET Framework
- Console
- Generics
- .NET Framework 4.0
- Library
- C# Language
- XmlSerializer
## Topics
- C#
- XML
- Generics
- Generic C# resuable code
- Language Samples
- Extension methods
## Updated
- 02/09/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify">The purpose of this article is to explore the implementation of
<a title="Object Xml serialization" href="http://msdn.microsoft.com/en-us/library/182eeyhh(v=vs.110).aspx" target="_blank">
object Xml serialization</a> by means of a single <a title="Extension Methods" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">
extension method</a> supporting <a title="Generic Types" href="http://msdn.microsoft.com/en-us/library/512aeb7t(v=vs.110).aspx" target="_blank">
generic types</a>.</p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements for building the sample code. The related sample code was developed and tested using Visual Studio 2010.</p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<h2>&nbsp;&nbsp;&nbsp;Example custom data type</h2>
<p>The sample source code provided with this article provides a user defined data type, the
<strong><em>CustomDataType</em></strong> class of which the code snippet is listed below.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;XMLSerializationGenericExtension&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomDataType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;intMember&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;IntMember&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;intMember;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;intMember&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;stringMember&nbsp;=&nbsp;String.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;StringMember&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;stringMember;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;stringMember&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;DateTime&nbsp;dateTimeMember&nbsp;=&nbsp;DateTime.MinValue;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;DateTimeMember&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;dateTimeMember;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;dateTimeMember&nbsp;=&nbsp;<span class="cs__keyword">value</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify"><span>This article&rsquo;s accompanying sample source code was implemented to serialize an object instance of type
<strong><em>CustomDataType. </em></strong>The resulting Xml markup representation is listed below.</span></p>
<h2><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=&nbsp;<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-16&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;CustomDataType</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">xsi</span>=<span class="xml__attr_value">&quot;http://www.w3.org/2001/XMLSchema-instance&quot;</span>&nbsp;&nbsp;
<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">xsd</span>=<span class="xml__attr_value">&quot;http://www.w3.org/2001/XMLSchema&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;IntMember</span><span class="xml__tag_start">&gt;</span>42<span class="xml__tag_end">&lt;/IntMember&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;StringMember</span><span class="xml__tag_start">&gt;</span>Some&nbsp;random&nbsp;string<span class="xml__tag_end">&lt;/StringMember&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;DateTimeMember</span><span class="xml__tag_start">&gt;</span>2013-02-03T17:01:32.9799772&#43;02:00<span class="xml__tag_end">&lt;/DateTimeMember&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/CustomDataType&gt;</span></pre>
</div>
</div>
</div>
</span><span>The serialization method &ndash; Implementation as an extension method with generic type support</span></h2>
<p><a title="Extension method architecture" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">Extension method architecture</a> enables developers to create methods which, from a syntactic and implementation point of view
 appear to be part of an existing data type. Extension methods create the perception of being updates or additions, literarily extending a data type as the name implies. Extension methods do not require access to the source code of the particular types being
 extended, nor does the implementation thereof require recompilation of the referenced types. This article illustrates a combined implementation of extension methods extending the functionality of
<a title="Generic Types" href="http://msdn.microsoft.com/en-us/library/512aeb7t(v=vs.110).aspx" target="_blank">
generic types</a>. The following code snippet provides the extension method definition.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ExtObject&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;XmlSerialize&lt;T&gt;(<span class="cs__keyword">this</span>&nbsp;T&nbsp;objectToSerialize)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlSerializer&nbsp;xmlSerializer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlSerializer(<span class="cs__keyword">typeof</span>(T));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringWriter&nbsp;stringWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlTextWriter&nbsp;xmlWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlTextWriter(stringWriter);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlWriter.Formatting&nbsp;=&nbsp;Formatting.Indented;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlSerializer.Serialize(xmlWriter,&nbsp;objectToSerialize);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;stringWriter.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</div>
<p style="text-align:justify">The <strong><em>XmlSerialize</em></strong> method satisfies the requirements of the extension method architecture by being defined as a static method, implemented as a member method of a statically defined class. In addition the
 method signature features the <a title="C# this Keyword" href="http://msdn.microsoft.com/en-us/library/vstudio/dk1507sz.aspx" target="_blank">
this</a> keyword preceding all other method parameters. The seemingly contradicting statement of specifying the
<a title="C# this Keyword" href="http://msdn.microsoft.com/en-us/library/vstudio/dk1507sz.aspx" target="_blank">
this</a> keyword in a static context usually serves as a quick indication that a method is implemented as an extension method. Remember that the
<strong><em>this</em></strong> keyword provides a reference to the current instance, whereas in the case of static methods and classes there is no current instance, being static results in limiting a type to only one instance accessed as a shared reference.</p>
<p style="text-align:justify">The definition of the <strong><em>XmlSerialize</em></strong> method also specifies the definition of a generic type
<strong><em>&lt;T&gt;</em></strong>. When defining an extension method the first parameter specified indicates the type being extended. As an example, if an extension method definition specifies as a first parameter a variable of type
<strong><em>string</em></strong>, the extension method will operate as an extension to the
<strong><em>String</em></strong> class. Notice that extending a native value type is possible as a result of .net&rsquo;s
<a title="Boxing and Unboxing" href="http://msdn.microsoft.com/en-us/library/yz2be5wk(v=vs.110).aspx" target="_blank">
boxing and unboxing</a> functionality.</p>
<p style="text-align:justify">The <strong><em>XmlSerialize</em></strong> method defines as a first parameter a variable of generic type
<strong><em>&lt;T&gt;</em></strong>. Extending a generic type allows the implementing code access to the
<strong><em>XmlSerialize</em></strong> method as a member of all data types, except static types. It is not possible to extend a static type.</p>
<h2><span>The implementation</span></h2>
<p style="text-align:justify">The <strong><em>XmlSerialize</em></strong> method discussed in the previous section appears as a member method to all non static types, provided that the implementing code applies the relevant namespace resolution by specifying
 the <strong><em>using</em></strong> statement where needed.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">class</span>&nbsp;Program&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomDataType&nbsp;objectInstance&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CustomDataType();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectInstance.DateTimeMember&nbsp;=&nbsp;DateTime.Now;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectInstance.IntMember&nbsp;=&nbsp;<span class="cs__number">42</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objectInstance.StringMember&nbsp;=&nbsp;<span class="cs__string">&quot;Some&nbsp;random&nbsp;string&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;xmlString&nbsp;=&nbsp;objectInstance.XmlSerialize();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(xmlString);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;Press&nbsp;any&nbsp;key...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p style="text-align:justify">From the code listed above the <strong><em>XmlSerialize</em></strong> method appears as a member of the
<strong><em>CustomDataType</em></strong> class but in reality <strong><em>CustomDataType</em></strong> does not define the
<strong><em>XmlSerialize</em></strong> method. The type being extended functions as per normal, not being aware of the extension method
<strong><em>XmlSerialize. </em></strong></p>
<p style="text-align:justify">The extension method now provides a uniform implementation enabling objects to be serialized to an Xml string, regardless of type.</p>
<p style="text-align:justify"><strong>Note: </strong>Not all types can be serialized! A commonly repeated mistake regarding object Xml serialization being that serialization will fail if a type does not provide a constructor with no parameters.</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>CustomDataType.cs - Class definition of the CustomDataType.</em> </li><li><em><em>ExtObject.cs - Definition of the XmlSerialize Extension method, the crux of this sample.</em></em>
</li><li><em>Program.cs - Console application used for testing and illustrating code implementation.</em>
</li></ul>
<h1>More Information</h1>
<div>This sample is based on an article originally posted on my blog: <a href="http://softwarebydefault.com/2013/02/04/xml-serialization-generics/">
http://softwarebydefault.com/2013/02/04/xml-serialization-generics/</a></div>
