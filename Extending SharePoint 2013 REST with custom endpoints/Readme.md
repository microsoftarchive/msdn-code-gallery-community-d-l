# Extending SharePoint 2013 REST with custom endpoints
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- SharePoint Server 2013
## Topics
- REST
- Extensibility
## Updated
- 04/17/2014
## Description

<h1>Introduction</h1>
<p><em>Ever wanted to deploy your own REST endpoints to the same _api endpoint as other SharePoint server REST endpoints to bypass cross-domain issues?&nbsp; Well, this project will show you how!<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>This sample is a full Visual Studio SharePoint Farm Solution project.&nbsp; You simply need to change the deploy server url and right-click the project and select &quot;Deploy&quot;<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample has a fully working and deployable instance of extending SharePoint REST!</em></p>
<p>Here are the high level steps of what you must do:</p>
<ol>
<li>Create a class decorated with ClientCallableType
<ol>
<li>Set the name to the same name as the class </li><li>Generate a new ServerTypeId set it </li><li>Set the FactoryType to a Object Factory that you will create next </li></ol>
</li><li>Add methods and properties to the class, decorate with ClientCallable, ClientCallableMethod, ClientCallableProperty
</li><li>Create the Object Factory that inherits from ClientCllableObjectFactory (this will create an class instance using an identifier)
<ol>
<li>Decorate the class with the Clietn </li><li>CallableObjectFactory attribute, set the ServerTypeId to the one you generated for the class
</li><li>Implement the GetObjectById method </li></ol>
</li><li>Create a ServerStub class that inherits from Microsoft.SharePoint.Client.ServerStub<br>
<ol>
<li>Decorate the class with the ServerStub attribute, set the type to the class type, set the TargetTypeId to the ServerTypeId
</li><li>Implement a public constructor </li><li>Override the following properties and methods
<ol>
<li>TargetType (returns typeof(class)) </li><li>TargetTypeId </li><li>TargetTypeScriptClientFullName (the name of your client target type you will create next)
</li><li>ClientLibraryTargets (what clients can call your rest endpoint) </li><li>GetProperty Method </li><li>InvokeConstructor method (for both the CSOM and REST calls) </li><li>Constructor implementations called from InvokeConstructor </li><li>InvokeMethod (this calls the object's method) </li><li>GetMethods (this is required to tell the $metadata endpoint what is available)
</li><li>GetProperties (similar to GetMethods) </li></ol>
</li></ol>
</li><li>Create another class in a .Client namespace
<ol>
<li>Decorate it with the ScriptType attribute, set the name and ServerTypeId </li><li>Make it inherit from ClientObject </li><li>Create the properties and methods that match to your server side class </li></ol>
</li><li>Create a ScriptTypeFactory that implements the IScriptTypeFactory interface
<ol>
<li>Implement the IFromJson method, use a switch statement to generate a Client class object based on the scriptType string
</li></ol>
</li><li>Create the ProxyLibrary.xxx.xml file<br>
<ol>
<li>Deploy to the {SharePointRoot}/ClientCallable directory </li></ol>
</li><li>Open the project's AssemblyInfo.cs file
<ol>
<li>Add a UrlSegmentAliasMap attribute </li><li>Add a ClientNamespaceMap attribute </li><li>Add a ClientTypeAssembly attribute </li></ol>
</li><li>Deploy the Farm Solution </li><li>Perform an IIS Reset </li><li>Hit a &quot;_/api/$metadata&quot; endpoint, you should see your end point displayed! </li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace CJG.ServerStub
{
    [ClientCallableType(Name=&quot;CJG&quot;, ServerTypeId=&quot;{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}&quot;, FactoryType=typeof(CJGObjectFactory))]
    public class CJG
    {
        public CJG()
        {

        }

        [ClientCallableProperty]
        public string FirstName { get; set; }

        [ClientCallableMethod]
        public int ReturnInt()
        {
            System.Random r = new Random();
            return r.Next();
        }

        [ClientCallable]
        public DateTime ReturnDate()
        {
            return DateTime.Now;
        }
    }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;CJG.ServerStub&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[ClientCallableType(Name=<span class="cs__string">&quot;CJG&quot;</span>,&nbsp;ServerTypeId=<span class="cs__string">&quot;{E1BB82E8-0D1E-4e52-B90C-684802AB4EF7}&quot;</span>,&nbsp;FactoryType=<span class="cs__keyword">typeof</span>(CJGObjectFactory))]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CJG&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CJG()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ClientCallableProperty]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;FirstName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ClientCallableMethod]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;ReturnInt()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Random&nbsp;r&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;r.Next();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[ClientCallable]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;ReturnDate()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;DateTime.Now;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>CJG.cs - has both the Server and Client side class (ideally this would be in two seperate assemblies).</em>
</li><li><em><em>CJGObjectFactory.cs - the class that generated instances of a CJG object</em></em>
</li><li><em><em>CJGServerStub.cs - the wrapper around the server object model class that tells the REST engine what endpoints are available in the EDMX mode.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>Original blog post is here.&nbsp; You can always email me at chris@architectingconnectedsystems with questions!</em></p>
