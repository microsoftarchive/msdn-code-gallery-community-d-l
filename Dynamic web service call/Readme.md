# Dynamic web service call
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- ASP.NET
- Web Services
- ASMX web services
- WSDL
## Topics
- Web Services
- WSDL
- dynamic webservices
## Updated
- 03/14/2016
## Description

<h1>Introduction</h1>
<p>Generally when we use web service, at first we should add it in the web reference and then call its methods statically. Despite&nbsp;having a high speed, it isn't very flexible.</p>
<p>In order to do it dynamically by dynamic invocation of&nbsp;web service, it has a very good flexibility. For example, the source of programs will be compiled once.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em>open Solution</em></p>
<p><em>Buik F5 and Run</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Instead of using pre-generated assemblies, perhaps you want to generate the assembly on the fly and invoke it.&nbsp; In other words, instead of right-clicking and using the &ldquo;Add Web Reference&rdquo; dialog or using WSDL.exe to create a proxy, perhaps
 you want to point your code at a URL and invoke a method without previously creating a proxy.&nbsp;</p>
<p>We can use any web service that we need. We can watch all of the web service's methods and parameters, automatic assignment methods and parameters.</p>
<p><span>One of the communication ways with web service is setup. Giving the information about web service will be done through WSDL file. To do this work, we should produce a&nbsp;</span><code>WebRequest&nbsp;</code><span>and send it to the WSDL. All activities
 about the parts are done by&nbsp;</span><code>WebRequest</code><span>.</span></p>
<p><span>Here in this example i have used wsdl url </span></p>
<p>http://www.webservicex.net/country.asmx?WSDL</p>
<p><span>and use two methods</span></p>
<p><span>1) GetCountries &nbsp; -which return country list .and i have bind in grid</span></p>
<p><span>2) GetCurrencyByCountry&nbsp; &nbsp;-which return contry data from webservice and i have bind this detail in second grid.</span></p>
<p><span>&nbsp;</span><img id="149528" src="149528-11.png" alt="" width="729" height="405"><img id="149529" src="149529-22.png" alt="" width="746" height="489"></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;

using System.CodeDom;
using System.CodeDom.Compiler;

using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Reflection;
using System.Data;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Webservicecall(&quot;&quot;);
    }


    private void Webservicecall(string contryname)
    {

        WebRequest webRequest = WebRequest.Create(&quot;http://www.webservicex.net/country.asmx?WSDL&quot;);
        WebResponse webResponse = webRequest.GetResponse();
        // Stream stream = webResponse.GetResponseStream();
        ServiceDescription description = new ServiceDescription();
        using (Stream stream = webResponse.GetResponseStream())
        {
            description = ServiceDescription.Read(stream);
        }
        ServiceDescriptionImporter importer = new ServiceDescriptionImporter();


        importer.ProtocolName = &quot;Soap12&quot;;//' Use SOAP 1.2.
        importer.AddServiceDescription(description, null, null);
        importer.Style = ServiceDescriptionImportStyle.Client;

        //'--Generate properties to represent primitive values.
        importer.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;
        //'Initialize a Code-DOM tree into which we will import the service.

        CodeNamespace nmspace = new CodeNamespace();
        CodeCompileUnit unit1 = new CodeCompileUnit();
        unit1.Namespaces.Add(nmspace);
        ServiceDescriptionImportWarnings warning = importer.Import(nmspace, unit1);
        CodeDomProvider provider1 = CodeDomProvider.CreateProvider(&quot;C#&quot;);

        //'--Compile the assembly proxy with the // appropriate references
        String[] assemblyReferences;
        assemblyReferences = new String[] { &quot;System.dll&quot;, &quot;System.Web.Services.dll&quot;, &quot;System.Web.dll&quot;, &quot;System.Xml.dll&quot;, &quot;System.Data.dll&quot; };

        CompilerParameters parms = new CompilerParameters(assemblyReferences);
        parms.GenerateInMemory = true;
        CompilerResults results = provider1.CompileAssemblyFromDom(parms, unit1);
        if (results.Errors.Count &gt; 0)
        {
        }


        Type foundType = null;
        Type[] types = results.CompiledAssembly.GetTypes();
        foreach (Type type1 in types)
        {
            if (type1.BaseType == typeof(SoapHttpClientProtocol))
            {
                foundType = type1;
            }
        }


        if (!String.IsNullOrEmpty(contryname))
        {
            Object[] args = new Object[1];
            args[0] = contryname;
            Object wsvcClass = results.CompiledAssembly.CreateInstance(foundType.ToString());
            MethodInfo mi = wsvcClass.GetType().GetMethod(&quot;GetCurrencyByCountry&quot;);
            var returnValue = mi.Invoke(wsvcClass, args);
            DataSet ds = new DataSet();
            grdcountrydata.DataSource = ConvertXMLToDataSet(returnValue.ToString());
            grdcountrydata.DataBind();
        }
        else
        {
            Object wsvcClass = results.CompiledAssembly.CreateInstance(foundType.ToString());
            MethodInfo mi = wsvcClass.GetType().GetMethod(&quot;GetCountries&quot;);
            var returnValue = mi.Invoke(wsvcClass,null);
            DataSet ds = new DataSet();
            grdcountry.DataSource = ConvertXMLToDataSet(returnValue.ToString());
            grdcountry.DataBind();
        }





    }

    public DataSet ConvertXMLToDataSet(string xmlData)
    {
        StringReader stream = null;
        XmlTextReader reader = null;
        try
        {
            DataSet xmlDS = new DataSet();
            stream = new StringReader(xmlData);
            // Load the XmlTextReader from the stream
            reader = new XmlTextReader(stream);
            xmlDS.ReadXml(reader);
            return xmlDS;
        }
        catch
        {
            return null;
        }
        finally
        {
            if (reader != null) reader.Close();
        }
    }
    protected void grdcountry_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Webservicecall(&quot;&quot;);
        grdcountry.PageIndex = e.NewPageIndex;
        grdcountry.DataBind();
    }
    protected void grdcountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals(&quot;Loaddata&quot;))
        {
            Webservicecall(e.CommandArgument.ToString());
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Net;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.UI.WebControls;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.CodeDom;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.CodeDom.Compiler;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Services.Description;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Web.Services.Protocols;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Reflection;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Data;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Xml;&nbsp;
&nbsp;
<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;_Default&nbsp;:&nbsp;System.Web.UI.Page&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Page_Load(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Webservicecall(<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Webservicecall(<span class="cs__keyword">string</span>&nbsp;contryname)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebRequest&nbsp;webRequest&nbsp;=&nbsp;WebRequest.Create(<span class="cs__string">&quot;http://www.webservicex.net/country.asmx?WSDL&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WebResponse&nbsp;webResponse&nbsp;=&nbsp;webRequest.GetResponse();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Stream&nbsp;stream&nbsp;=&nbsp;webResponse.GetResponseStream();</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescription&nbsp;description&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceDescription();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(Stream&nbsp;stream&nbsp;=&nbsp;webResponse.GetResponseStream())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;description&nbsp;=&nbsp;ServiceDescription.Read(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescriptionImporter&nbsp;importer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ServiceDescriptionImporter();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;importer.ProtocolName&nbsp;=&nbsp;<span class="cs__string">&quot;Soap12&quot;</span>;<span class="cs__com">//'&nbsp;Use&nbsp;SOAP&nbsp;1.2.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;importer.AddServiceDescription(description,&nbsp;<span class="cs__keyword">null</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;importer.Style&nbsp;=&nbsp;ServiceDescriptionImportStyle.Client;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//'--Generate&nbsp;properties&nbsp;to&nbsp;represent&nbsp;primitive&nbsp;values.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;importer.CodeGenerationOptions&nbsp;=&nbsp;System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//'Initialize&nbsp;a&nbsp;Code-DOM&nbsp;tree&nbsp;into&nbsp;which&nbsp;we&nbsp;will&nbsp;import&nbsp;the&nbsp;service.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CodeNamespace&nbsp;nmspace&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CodeNamespace();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CodeCompileUnit&nbsp;unit1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CodeCompileUnit();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;unit1.Namespaces.Add(nmspace);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ServiceDescriptionImportWarnings&nbsp;warning&nbsp;=&nbsp;importer.Import(nmspace,&nbsp;unit1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CodeDomProvider&nbsp;provider1&nbsp;=&nbsp;CodeDomProvider.CreateProvider(<span class="cs__string">&quot;C#&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//'--Compile&nbsp;the&nbsp;assembly&nbsp;proxy&nbsp;with&nbsp;the&nbsp;//&nbsp;appropriate&nbsp;references</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;String[]&nbsp;assemblyReferences;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;assemblyReferences&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;String[]&nbsp;{&nbsp;<span class="cs__string">&quot;System.dll&quot;</span>,&nbsp;<span class="cs__string">&quot;System.Web.Services.dll&quot;</span>,&nbsp;<span class="cs__string">&quot;System.Web.dll&quot;</span>,&nbsp;<span class="cs__string">&quot;System.Xml.dll&quot;</span>,&nbsp;<span class="cs__string">&quot;System.Data.dll&quot;</span>&nbsp;};&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompilerParameters&nbsp;parms&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CompilerParameters(assemblyReferences);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;parms.GenerateInMemory&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CompilerResults&nbsp;results&nbsp;=&nbsp;provider1.CompileAssemblyFromDom(parms,&nbsp;unit1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(results.Errors.Count&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;foundType&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type[]&nbsp;types&nbsp;=&nbsp;results.CompiledAssembly.GetTypes();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Type&nbsp;type1&nbsp;<span class="cs__keyword">in</span>&nbsp;types)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(type1.BaseType&nbsp;==&nbsp;<span class="cs__keyword">typeof</span>(SoapHttpClientProtocol))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foundType&nbsp;=&nbsp;type1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(!String.IsNullOrEmpty(contryname))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Object[]&nbsp;args&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Object[<span class="cs__number">1</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;args[<span class="cs__number">0</span>]&nbsp;=&nbsp;contryname;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Object&nbsp;wsvcClass&nbsp;=&nbsp;results.CompiledAssembly.CreateInstance(foundType.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MethodInfo&nbsp;mi&nbsp;=&nbsp;wsvcClass.GetType().GetMethod(<span class="cs__string">&quot;GetCurrencyByCountry&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;returnValue&nbsp;=&nbsp;mi.Invoke(wsvcClass,&nbsp;args);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;ds&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountrydata.DataSource&nbsp;=&nbsp;ConvertXMLToDataSet(returnValue.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountrydata.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Object&nbsp;wsvcClass&nbsp;=&nbsp;results.CompiledAssembly.CreateInstance(foundType.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MethodInfo&nbsp;mi&nbsp;=&nbsp;wsvcClass.GetType().GetMethod(<span class="cs__string">&quot;GetCountries&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;returnValue&nbsp;=&nbsp;mi.Invoke(wsvcClass,<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;ds&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountry.DataSource&nbsp;=&nbsp;ConvertXMLToDataSet(returnValue.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountry.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DataSet&nbsp;ConvertXMLToDataSet(<span class="cs__keyword">string</span>&nbsp;xmlData)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StringReader&nbsp;stream&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;XmlTextReader&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataSet&nbsp;xmlDS&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DataSet();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;stream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringReader(xmlData);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Load&nbsp;the&nbsp;XmlTextReader&nbsp;from&nbsp;the&nbsp;stream</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;reader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;XmlTextReader(stream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlDS.ReadXml(reader);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;xmlDS;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(reader&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;reader.Close();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;grdcountry_PageIndexChanging(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;GridViewPageEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Webservicecall(<span class="cs__string">&quot;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountry.PageIndex&nbsp;=&nbsp;e.NewPageIndex;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grdcountry.DataBind();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;grdcountry_RowCommand(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;GridViewCommandEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(e.CommandName.Equals(<span class="cs__string">&quot;Loaddata&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Webservicecall(e.CommandArgument.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - webform1.aspx</em> </li></ul>
<h1>More Information</h1>
<p><em>Refrence Link</em></p>
<p><em>https://blogs.msdn.microsoft.com/kaevans/2006/04/27/dynamically-invoking-a-web-service/<br>
</em></p>
