# Generating a Web Service from WSDL
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Web Services
- .NET Framework
- ASMX web services
- XmlSerializer
## Topics
- C#
- Data Binding
- Web Services
- Web
- CodeDOM
- Compiler
- Web Development
- Generic C# resuable code
- web service
- C# Language Features
- Web Serives
- Web Service Interface
- Consuming Web Services
- Web Architecture
- Windows web services
- Code Generation
- Web App
- WebService
## Updated
- 02/16/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify"><span style="font-size:small"><a title="Web Service Definition Language (WSDL)" href="http://en.wikipedia.org/wiki/Web_Services_Description_Language" target="_blank">Web Service Definition Language (WSDL)</a> is an Xml based schema
 that exactly details the custom data types and web service methods exposed by a web service. Developers usually generate web service client proxy code in order to call into web services. Since WSDL is an exact description of a web service it is also possible
 to generate code that represents the service in the form of web method stubs. This article illustrates how to generate a web service from WSDL.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small">There are no special requirements or instructions&nbsp;to build the sample source code.</span></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p style="text-align:justify"><span style="font-size:small">I&rsquo;ve often found myself in a scenario where I have to interface with third parties via web services. It is often the case that third party service are proprietary, usually I find that I have
 very little control over the web services I&rsquo;m required to interface to. Countless hours are wasted because of out dated test environments, missing/incorrect security certificates or even just trying to get hold of log files.</span></p>
<p style="text-align:justify"><span style="font-size:small">Time spent on development and testing can be significantly reduced in most cases if I had a local copy of a web service available to me. Having access to source code would be even more beneficial,
 being able to manipulate the data returned, testing timeouts etc. After surprisingly little effort I manage to develop a utility application capable of generating web method stubs and custom defined types in C# source code. The only required input in generating
 a web service is the WSDL of an existing web service.</span></p>
<h1><span>Input Web service WSDL</span></h1>
<p style="text-align:justify"><span style="font-size:small">The sample source accompanying this article defines a very simplistic web service, consisting of one web method
<strong><em>HelloWorld(). </em></strong>The source code is listed below:</span></p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[WebService(Namespace&nbsp;=&nbsp;<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>)]&nbsp;
[WebServiceBinding(ConformsTo&nbsp;=&nbsp;WsiProfiles.BasicProfile1_1)]&nbsp;
[System.ComponentModel.ToolboxItem(<span class="cs__keyword">false</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;TestWebService&nbsp;:&nbsp;System.Web.Services.WebService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[WebMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HelloWorld()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Hello&nbsp;World&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="font-size:small">The resulting WSDL is generated as illustrated by the following snippet:</span></p>
</span></div>
<div><span>
<h1 class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;?xml</span>&nbsp;<span class="xml__attr_name">version</span>=<span class="xml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xml__attr_name">encoding</span>=<span class="xml__attr_value">&quot;utf-8&quot;</span><span class="xml__tag_start">?&gt;</span>&nbsp;
<span class="xml__tag_start">&lt;wsdl</span>:definitions&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">soap</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/wsdl/soap/&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">tm</span>=<span class="xml__attr_value">&quot;http://microsoft.com/wsdl/mime/textMatching/&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">soapenc</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/soap/encoding/&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">mime</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/wsdl/mime/&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">tns</span>=<span class="xml__attr_value">&quot;http://softwarebydefault.com&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">s</span>=<span class="xml__attr_value">&quot;http://www.w3.org/2001/XMLSchema&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">soap12</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/wsdl/soap12/&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">http</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/wsdl/http/&quot;</span>&nbsp;<span class="xml__attr_name">targetNamespace</span>=<span class="xml__attr_value">&quot;http://softwarebydefault.com&quot;</span>&nbsp;<span class="xml__keyword">xmlns</span>:<span class="xml__attr_name">wsdl</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/wsdl/&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span><span class="xml__tag_start">:types&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span>:schema&nbsp;<span class="xml__attr_name">elementFormDefault</span>=<span class="xml__attr_value">&quot;qualified&quot;</span>&nbsp;<span class="xml__attr_name">targetNamespace</span>=<span class="xml__attr_value">&quot;http://softwarebydefault.com&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span>:<span class="xml__keyword">element</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorld&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span>:complexType&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/s:element&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span>:<span class="xml__keyword">element</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorldResponse&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span><span class="xml__tag_start">:complexType&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span><span class="xml__tag_start">:sequence&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;s</span>:<span class="xml__keyword">element</span>&nbsp;<span class="xml__attr_name">minOccurs</span>=<span class="xml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xml__attr_name">maxOccurs</span>=<span class="xml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorldResult&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;s:string&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/s:sequence&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/s:complexType&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/s:element&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/s:schema&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:types&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:message&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorldSoapIn&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:part&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;parameters&quot;</span>&nbsp;<span class="xml__attr_name">element</span>=<span class="xml__attr_value">&quot;tns:HelloWorld&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:message&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:message&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorldSoapOut&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:part&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;parameters&quot;</span>&nbsp;<span class="xml__attr_name">element</span>=<span class="xml__attr_value">&quot;tns:HelloWorldResponse&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:message&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:portType&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebServiceSoap&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:operation&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorld&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:input&nbsp;<span class="xml__attr_name">message</span>=<span class="xml__attr_value">&quot;tns:HelloWorldSoapIn&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:<span class="xml__keyword">output</span>&nbsp;<span class="xml__attr_name">message</span>=<span class="xml__attr_value">&quot;tns:HelloWorldSoapOut&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:operation&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:portType&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:binding&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebServiceSoap&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;tns:TestWebServiceSoap&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap</span>:binding&nbsp;<span class="xml__attr_name">transport</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/soap/http&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:operation&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorld&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap</span>:operation&nbsp;<span class="xml__attr_name">soapAction</span>=<span class="xml__attr_value">&quot;http://softwarebydefault.com/HelloWorld&quot;</span>&nbsp;<span class="xml__attr_name">style</span>=<span class="xml__attr_value">&quot;document&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span><span class="xml__tag_start">:input&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap</span>:body&nbsp;<span class="xml__attr_name">use</span>=<span class="xml__attr_value">&quot;literal&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:input&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span><span class="xml__tag_start">:output&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap</span>:body&nbsp;<span class="xml__attr_name">use</span>=<span class="xml__attr_value">&quot;literal&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:output&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:operation&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:binding&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:binding&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebServiceSoap12&quot;</span>&nbsp;<span class="xml__attr_name">type</span>=<span class="xml__attr_value">&quot;tns:TestWebServiceSoap&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap12</span>:binding&nbsp;<span class="xml__attr_name">transport</span>=<span class="xml__attr_value">&quot;http://schemas.xmlsoap.org/soap/http&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:operation&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;HelloWorld&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap12</span>:operation&nbsp;<span class="xml__attr_name">soapAction</span>=<span class="xml__attr_value">&quot;http://softwarebydefault.com/HelloWorld&quot;</span>&nbsp;<span class="xml__attr_name">style</span>=<span class="xml__attr_value">&quot;document&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span><span class="xml__tag_start">:input&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap12</span>:body&nbsp;<span class="xml__attr_name">use</span>=<span class="xml__attr_value">&quot;literal&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:input&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span><span class="xml__tag_start">:output&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap12</span>:body&nbsp;<span class="xml__attr_name">use</span>=<span class="xml__attr_value">&quot;literal&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:output&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:operation&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:binding&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:service&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebService&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:port&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebServiceSoap&quot;</span>&nbsp;<span class="xml__attr_name">binding</span>=<span class="xml__attr_value">&quot;tns:TestWebServiceSoap&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap</span>:address&nbsp;<span class="xml__attr_name">location</span>=<span class="xml__attr_value">&quot;http://localhost:6078/TestWS.asmx&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:port&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;wsdl</span>:port&nbsp;<span class="xml__attr_name">name</span>=<span class="xml__attr_value">&quot;TestWebServiceSoap12&quot;</span>&nbsp;<span class="xml__attr_name">binding</span>=<span class="xml__attr_value">&quot;tns:TestWebServiceSoap12&quot;</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;soap12</span>:address&nbsp;<span class="xml__attr_name">location</span>=<span class="xml__attr_value">&quot;http://localhost:6078/TestWS.asmx&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:port&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/wsdl:service&gt;</span>&nbsp;
<span class="xml__tag_end">&lt;/wsdl:definitions&gt;</span></pre>
</div>
</div>
</h1>
<h1>Generating the Web service from input WSDL</h1>
</span></div>
<p style="text-align:justify"><span style="font-size:small">The crux of this article revolves around the
<strong><em>Generate </em></strong>method defined in the associated sample source code. The method makes use of the
<a title="ServiceDescription" href="http://msdn.microsoft.com/en-us/library/system.servicemodel.description.servicedescription.aspx" target="_blank">
ServiceDescription</a> and <a title="ServiceDescriptionImporter" href="http://msdn.microsoft.com/en-us/library/system.web.services.description.servicedescriptionimporter.aspx" target="_blank">
ServiceDescriptionImporter</a> classes to reference the WSDL generated earlier. The code defined by the
<strong><em>Generate</em></strong> method is very similar to the code that would generate web service client proxy code. Make
<em><span style="text-decoration:underline"><strong>note</strong></span></em> of the
<a title="Style" href="http://msdn.microsoft.com/en-us/library/system.web.services.description.servicedescriptionimporter.style.aspx" target="_blank">
Style</a> property of the <a title="ServiceDescriptionImporter" href="http://msdn.microsoft.com/en-us/library/system.web.services.description.servicedescriptionimporter.aspx" target="_blank">
ServiceDescriptionImporter</a> object being set to <a title="ServiceDescriptionImportStyle.Server" href="http://msdn.microsoft.com/en-us/library/system.web.services.description.servicedescriptionimporter.style.aspx" target="_blank">
ServiceDescriptionImportStyle.Server</a>. By setting the style to server we indicate that any code generated should reflect the server interface. Had the property being set to
<a title="ServiceDescriptionImportStyle.Client" href="http://msdn.microsoft.com/en-us/library/system.web.services.description.servicedescriptionimporter.style.aspx" target="_blank">
ServiceDescriptionImportStyle.Client</a> web service client proxy code would be generated.</span></p>
<p style="text-align:justify"><span style="font-size:small">After importing the service descriptions as defined by the specified WSDL and if no errors occurred we generate C# source code based on the service descriptions imported. The resulting source code
 generated is then saved to the file system based on the file path passed as method parameter.</span></p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Generate(<span class="cs__keyword">string</span>&nbsp;wsdlPath,&nbsp;<span class="cs__keyword">string</span>&nbsp;outputFilePath)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(File.Exists(wsdlPath)&nbsp;==&nbsp;<span class="cs__keyword">false</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescription&nbsp;wsdlDescription&nbsp;=&nbsp;ServiceDescription.Read(wsdlPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescriptionImporter&nbsp;wsdlImporter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceDescriptionImporter();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wsdlImporter.ProtocolName&nbsp;=&nbsp;<span class="cs__string">&quot;Soap12&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wsdlImporter.AddServiceDescription(wsdlDescription,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wsdlImporter.Style&nbsp;=&nbsp;ServiceDescriptionImportStyle.Server;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;wsdlImporter.CodeGenerationOptions&nbsp;=&nbsp;CodeGenerationOptions.GenerateProperties;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CodeNamespace&nbsp;codeNamespace&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CodeNamespace();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CodeCompileUnit&nbsp;codeUnit&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CodeCompileUnit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;codeUnit.Namespaces.Add(codeNamespace);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescriptionImportWarnings&nbsp;importWarning&nbsp;=&nbsp;wsdlImporter.Import(codeNamespace,&nbsp;codeUnit);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(importWarning&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;stringBuilder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringWriter&nbsp;stringWriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringWriter(stringBuilder);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CodeDomProvider&nbsp;codeProvider&nbsp;=&nbsp;CodeDomProvider.CreateProvider(<span class="cs__string">&quot;CSharp&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;codeProvider.GenerateCodeFromCompileUnit(codeUnit,&nbsp;stringWriter,&nbsp;<span class="cs__keyword">new</span>&nbsp;CodeGeneratorOptions());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stringWriter.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;File.WriteAllText(outputFilePath,&nbsp;stringBuilder.ToString(),&nbsp;Encoding.UTF8);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(importWarning);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
</span></div>
<p style="text-align:justify"><span style="font-size:small">Notice the use of the
<a title="CodeDomProvider" href="http://msdn.microsoft.com/en-us/library/system.codedom.compiler.codedomprovider.aspx" target="_blank">
CodeDomProvider</a> class, creating an instance of this class allows us to generate source code. This class can also be used to compile source code to assemblies, in essence it allows developers access to a set of compilers accessible from code. As described
 by <a title="CodeDomProvider" href="http://msdn.microsoft.com/en-us/library/system.codedom.compiler.codedomprovider.aspx" target="_blank">
MSDN documentation</a>:</span></p>
<blockquote>
<p style="text-align:justify"><span style="font-size:small">A CodeDomProvider implementation typically provides code generation and/or code compilation interfaces for generating code and managing compilation for a single programming language. Several languages
 are supported by CodeDomProvider implementations that ship with the Windows Software Development Kit (SDK). These languages include C#, Visual Basic, C&#43;&#43;, and JScript. Developers or compiler vendors can implement the
<a href="http://msdn.microsoft.com/en-us/library/system.codedom.compiler.icodegenerator.aspx">
ICodeGenerator</a> and <a href="http://msdn.microsoft.com/en-us/library/system.codedom.compiler.icodecompiler.aspx">
ICodeCompiler</a> interfaces and provide a CodeDomProvider that extends CodeDOM support to other programming languages.</span></p>
</blockquote>
<h1><span>The Generated Code</span></h1>
<p style="text-align:justify"><span style="font-size:small">The code generated comes in the form of abstract classes and methods. The snippet below illustrates the raw generated code:</span></p>
<p style="text-align:justify"><span>&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[System.CodeDom.Compiler.GeneratedCodeAttribute&nbsp;
(<span class="cs__string">&quot;WSDLToWebService&quot;</span>,&nbsp;<span class="cs__string">&quot;1.0.0.0&quot;</span>)]&nbsp;
[System.Web.Services.WebServiceAttribute&nbsp;
(Namespace=<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>)]&nbsp;
[System.Web.Services.WebServiceBindingAttribute&nbsp;
(Name=<span class="cs__string">&quot;TestWebServiceSoap12&quot;</span>,&nbsp;
Namespace=<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;TestWebService&nbsp;:&nbsp;System.Web.Services.WebService&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;remarks/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Services.WebMethodAttribute.aspx" target="_blank" title="Auto generated link to System.Web.Services.WebMethodAttribute">System.Web.Services.WebMethodAttribute</a>()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Services.Protocols.SoapDocumentMethodAttribute.aspx" target="_blank" title="Auto generated link to System.Web.Services.Protocols.SoapDocumentMethodAttribute">System.Web.Services.Protocols.SoapDocumentMethodAttribute</a>(<span class="cs__string">&quot;http://softwarebydefault.com/HelloWorld&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RequestNamespace=<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>,&nbsp;&nbsp;
ResponseNamespace=<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>,&nbsp;&nbsp;
Use=System.Web.Services.Description.SoapBindingUse.Literal,&nbsp;
ParameterStyle=&nbsp;
System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">abstract</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HelloWorld();&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p><span style="font-size:small">The code generated compiles without issue, but being declared
<a title="abstract" href="http://msdn.microsoft.com/en-us/library/sf985hc5.aspx" target="_blank">
abstract</a> prevents the code from functioning as a web service implementation. I find the easiest method is to refactor the code instead of implementing inheritance. The snippet listed below represents the generated code refactored to reflect a web service
 implementation.</span></p>
<p>&nbsp;</p>
<div><span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">[System.CodeDom.Compiler.GeneratedCodeAttribute&nbsp;
(<span class="cs__string">&quot;WSDLToWebService&quot;</span>,&nbsp;<span class="cs__string">&quot;1.0.0.0&quot;</span>)]&nbsp;
[System.Web.Services.WebServiceAttribute&nbsp;
(Namespace&nbsp;=&nbsp;<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>)]&nbsp;
[System.Web.Services.WebServiceBindingAttribute&nbsp;
(Name&nbsp;=&nbsp;<span class="cs__string">&quot;TestWebService&quot;</span>,&nbsp;Namespace&nbsp;&nbsp;
=&nbsp;<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>)]&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;TestWebService&nbsp;:&nbsp;System.Web.Services.WebService&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Web.Services.WebMethodAttribute.aspx" target="_blank" title="Auto generated link to System.Web.Services.WebMethodAttribute">System.Web.Services.WebMethodAttribute</a>()]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[System.Web.Services.Protocols.SoapDocumentMethod&nbsp;
Attribute(<span class="cs__string">&quot;http://softwarebydefault.com/HelloWorld&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RequestNamespace&nbsp;=&nbsp;<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>,&nbsp;ResponseNamespace&nbsp;=&nbsp;<span class="cs__string">&quot;http://softwarebydefault.com&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Use&nbsp;=&nbsp;System.Web.Services.Description.SoapBindingUse.Literal,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ParameterStyle&nbsp;=&nbsp;System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;HelloWorld()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__string">&quot;Hello&nbsp;Generated&nbsp;World&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode" style="text-align:justify"><span style="font-size:small">The
<strong><em>TestWebService</em></strong> class and <strong><em>HelloWorld</em></strong> method is now no longer defined as
<a title="abstract" href="http://msdn.microsoft.com/en-us/library/sf985hc5.aspx" target="_blank">
abstract</a>. In addition <strong><em>HelloWorld</em></strong> now defines a method body as required by not being an
<a title="abstract" href="http://msdn.microsoft.com/en-us/library/sf985hc5.aspx" target="_blank">
abstract</a> method anymore.</span></p>
</span></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:small"><em>WebServiceGenerator.cs - Contains the code definition of the Generate() method, the crux of this article</em></span>
</li><li><span style="font-size:small"><em><em>TestWS.asmx.cs - Example web service definition used as WSDL input</em></em></span>
</li><li><span style="font-size:small"><em>TestWebService.asmx.cs - Refactored implementation of generated abstract web service</em></span>
</li><li><span style="font-size:small"><em>Program.cs - Console based application used to implement Generate() method</em></span>
</li></ul>
<h1>More Information</h1>
<p><span style="font-size:small">Please remember to rate this sample, if you have any questions, suggestions or improvements please make use of the Q&amp;A section on this page. - Dewald Esterhuizen</span></p>
<p><span style="font-size:small">This article is based on an article originally posted on my
<a href="http://softwarebydefault.com/" target="_blank">blog</a>: <a href="http://softwarebydefault.com/2013/02/17/generate-webservice-wsdl/">
http://softwarebydefault.com/2013/02/17/generate-webservice-wsdl/</a></span></p>
