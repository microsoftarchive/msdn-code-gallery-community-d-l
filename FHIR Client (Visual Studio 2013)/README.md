# FHIR Client (Visual Studio 2013)
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- JSON
- REST
- .NET
- XML
- FHIR
## Topics
- C#
- REST
- healthcare
- HttpClient
- FHIR
- HL7
## Updated
- 05/15/2014
## Description

<h1>
<div class="endscriptcode">&nbsp;</div>
Introduction</h1>
<p>This example illustrates howto build a client for an HL7 FHIR server. It makes use of the FHIR .NET reference implementation that is available on
<a href="https://github.com/ewoutkramer/fhir-net-api" target="_blank">Github</a> and also as NuGet package. More about the HL7 FHIR standard can be found on the
<a href="http://www.hl7.org/implement/standards/fhir/" target="_blank">FHIR Specification Home</a> page.&nbsp;</p>
<p>This sample implements a command line client that supports the&nbsp;following command's on a
<em><strong>FHIR&nbsp;Patient</strong>&nbsp;<strong>Resource</strong></em>:</p>
<ul>
<li><strong>register - </strong>register a new patient on the FHIR server </li><li><strong>update </strong>- update an existing patient on a FHIR server </li><li><strong>get</strong> - retrieve the patient information from a FHIR server, either current or historical data
</li><li><strong>history</strong> - retrieve the history information about a Patient resource on a FHIR server
</li><li><strong>search</strong> - search for a patient by name </li></ul>
<p>The command line client supports a help function for listing available commands and paramters.</p>
<p><img id="114265" src="http://i1.code.msdn.s-msft.com/client-for-hl7-fhir-server-0709be0b/image/file/114265/1/fpat.png" alt="" width="617" height="280"></p>
<h1><span>Building the Sample</span></h1>
<p>Simply start the build command in Visual Studio. Any required NuGet packages will be automatically downloaded.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The example has been created during the HL7 conference in Phoenix AZ after the connectathon. So the description is a little bit rough and will probably be updated in the near future.</em></p>
<p><em>The code provides a very lightweight framework for your own extensions. It is intended as additoinal source for educational use in addition to mentioned sources of information from HL7 and Ewout Kramer.</em></p>
<p><em>Thanks to Ewout's .NET reference implementation for the HL7 FHIR standard it is very easy to implement a client for accessing a FHIR REST service.</em></p>
<h2>Example code for retrieving Patient Resource by ID</h2>
<p>In order to retrieve a FHIR Patient Resource by its ID we need a client that is talking to the REST service offered by the FHIR Server. You can instantiate a&nbsp;FhirClient object passing the FHIR Servers REST endpoint into the constructor. The Patient
 resource is retrieved by calling the method Read with an ResourceIdentity object&nbsp;as argumen. For building the ResourceIdentity object one needs to pass the type of the resource, its logical id and optionally the version into the constructor of the ResourceIdentitiy.</p>
<p><em>&nbsp;</em></p>
<div class="scriptcode"><em>
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;Hl7.Fhir.Rest;&nbsp;
&nbsp;
<span class="cs__keyword">string</span>&nbsp;url&nbsp;=&nbsp;<span class="cs__string">&quot;http://spark.furore.com/fhir&quot;</span>;&nbsp;
<span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;<span class="cs__string">&quot;1&quot;</span>;&nbsp;
&nbsp;
var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;FhirClient(url);&nbsp;
var&nbsp;identity&nbsp;=&nbsp;ResourceIdentity.Build(<span class="cs__string">&quot;Patient&quot;</span>,&nbsp;id);&nbsp;
var&nbsp;patient&nbsp;=&nbsp;client.Read(identity);</pre>
</div>
</div>
</em></div>
<p><em>&nbsp;</em><em>&nbsp;</em></p>
<h2>Extendig the sample code with your own CommandHander</h2>
<p>This section is specific to the sample code, it is not related to the .NET reference implementation for FHIR. The example can be easily extended with new command handler classes that implement the ICommandHandler interface.&nbsp;</p>
<p>You do so by deriving a new class from the abstract CommandHanlder class. Inside the constructor assign the command name to the property ID. Now you have to implement the two methods</p>
<ul>
<li>Execute(Arguments args) - here goes the code that interacts with the FHIR server
</li><li>ShowUsage - Write a description incuding the parameter needed by your command to the console
</li></ul>
<p>That's it!</p>
