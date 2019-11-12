# Java Sample App for Windows Azure Active Directory Graph API (REST API)
## License
- MS-LPL
## Technologies
- REST
- Microsoft Azure
## Topics
- REST
- Microsoft Azure
## Updated
- 05/13/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:large"><span style="color:#ff0000">Note: this sample is outdated.&nbsp;The new version of this sample app is now being updated at</span>
</span></p>
<p><span style="font-size:medium"><a href="http://GitHub.com/AzureADSamples/WebApp-GraphAPI-Java">http://GitHub.com/AzureADSamples/WebApp-GraphAPI-Java</a></span></p>
<p>&nbsp;</p>
<p>------------------------------------------------------------------------------------------------------------------------</p>
<p>Updated: January 20, 2014 - uses latest Graph API api-version=2013-11-08</p>
<p><span style="font-size:x-small">This sample application demonstrates how to access tenant data from Windows Azure Active Directory using the new Graph API, which is a new RESTful interface that allows programmatic access to tenant data such as users, contacts,
 groups, roles etc.&nbsp;&nbsp; Note, a C# version of this sample application is avaialble from
<a href="http://go.microsoft.com/fwlink/?LinkID=262648&clcid=0x409" target="_blank">
link</a>.</span></p>
<p><span style="font-size:x-small"><br>
</span></p>
<h1><span>Building the Sample</span></h1>
<p><em>The Sample application can be built using the Eclipse IDE, and runs under Tomcat.&nbsp; The following instructions are provided:</em></p>
<p><br>
1. Download and install the JDK 7 from the Oracle Website (select the version for your development environment (e.g. Windows x64)&nbsp;<a href="http://www.oracle.com/technetwork/java/javase/downloads/index.html" target="_blank">JDK 7</a>&nbsp;&nbsp;</p>
<p style="padding-left:30px">a.&nbsp;Select JDK Standard Edition (JDK SE 7 with latest update).</p>
<p>b. Set a system environmental variable named JAVA_HOME and give the variable value to your java installation. Typically, this value would be something like: C:\Program Files\Java\jdk1.7.0_06</p>
<p>2. Download and install the Eclipse IDE for Java EE Developers from the following website (select the version for your development environment (e.g. Windows x86).&nbsp;&nbsp;<a href="http://www.eclipse.org/downloads/packages/eclipse-ide-java-ee-developers/junor" target="_blank">Eclipse
 IDE for Java EE</a>&nbsp;&nbsp;&nbsp;</p>
<p style="padding-left:30px">a. &nbsp;Unpack the Eclipse package to a file location of your choice.&nbsp; To start Eclipse, simply execute Eclipse.exe</p>
<p>3. Download and install Apache Tomcat.&nbsp;&nbsp;<a href="http://tomcat.apache.org/" target="_blank"> Apache TomCat</a>&nbsp; (<a href="http://tomcat.apache.org/" target="_blank">http://tomcat.apache.org/</a>)</p>
<ul>
<li>You can run Apache Tomcat by clicking &lt;tomcat folder&gt;/bin/startup.bat script.
<br>
You can also shut down apache tomcat by clicking &lt;tomcat folder&gt;/bin/shutdown.bat.<br>
However, when running your application from Eclipse, it can be configured to automatically start Apache Tomcat, and execute in normal or debug mode.
</li></ul>
<p><br>
4. Download/Unzip the JavaSampleApp.zip file to file location of your choice.&nbsp; &nbsp;Import the project in Eclipse by:</p>
<p style="padding-left:30px">a.&nbsp;Starting Eclipse by clicking Eclipse.exe.</p>
<p style="padding-left:30px">b.&nbsp;Specify a workspace folder of your choice.</p>
<p style="padding-left:30px">c. Click File/Import/General/Existing Projects Into the workspace</p>
<p style="padding-left:30px">d. Select the root directory to the project you want to import into.</p>
<p style="padding-left:30px">e. Click Finish.&nbsp;&nbsp;</p>
<p>Optionally, you can also import the JavaSampleApp.war file by selecting from Eclispe:&nbsp; File/Import/Web/War and selecting the JavaSampleApp.war file.</p>
<p><br>
5. To see the opened project:</p>
<p style="padding-left:30px">a. Click Window/Show View/Project Explorer. This<br>
would show the project explorer which would show the whole project hierarchy on<br>
the left of your screen.</p>
<p style="padding-left:30px">b. Now right click on the project name, and select &lsquo;Run As/Run on Server&rsquo;.</p>
<p style="padding-left:30px">c. This would prompt you to specify a server&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp; i.&nbsp;Select Apache Tomcat V7.0 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;ii.&nbsp;Select the root directory of the tomcat server.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br>
&nbsp;&nbsp;&nbsp;&nbsp;iii.&nbsp;Select &ldquo;Always use this server&rdquo;.</p>
<p><br>
<br>
</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><span style="font-size:x-small"><span style="color:black; font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;">This&nbsp;Java sample application is a web app that reads directory data from the Windows Azure Active Directory Graph API, and executes queries against a demo
 company</span><span style="color:black; font-family:&quot;Verdana&quot;,&quot;sans-serif&quot;">. The full list of capabilities for the Graph API can be found on MSDN (link below).&nbsp;If you would like to update the directory data, then the application must be&nbsp;configured&nbsp;to
 be&nbsp;used with your own Azure AD tenant -&nbsp;you will need&nbsp;add and configure&nbsp;a Service Principal for your Azure AD tenant. We've included a PowerShell script (createServicePrincipal.ps1)&nbsp;that allows you to easily do this - you will then
 need to update the sample application's web.xml file with your tenant ID, application service principal ID, and Client secret (symmetric key value), and rebuild the application.&nbsp; Review the following MSDN topics on how to
<a href="http://msdn.microsoft.com/en-us/library/hh974468" target="_blank">create a Service Principal</a>&nbsp;and how to
<a href="http://msdn.microsoft.com/en-us/library/hh974473" target="_blank">assign it to a Role
</a>in your own company.</span></span></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Java</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">java</span>

<div class="preview">
<pre class="java"><span class="java__keyword">package</span>&nbsp;org.sampleapp.dto;&nbsp;
&nbsp;
<span class="java__keyword">import</span>&nbsp;java.util.ArrayList;&nbsp;
&nbsp;
<span class="java__keyword">import</span>&nbsp;javax.xml.bind.annotation.XmlRootElement;&nbsp;
&nbsp;
<span class="java__mlcom">/**&nbsp;
&nbsp;*&nbsp;The&nbsp;User&nbsp;Class&nbsp;holds&nbsp;together&nbsp;all&nbsp;the&nbsp;members&nbsp;of&nbsp;a&nbsp;WAAD&nbsp;User&nbsp;entity&nbsp;and&nbsp;all&nbsp;the&nbsp;access&nbsp;methods&nbsp;and&nbsp;set&nbsp;methods&nbsp;
&nbsp;*&nbsp;to&nbsp;access&nbsp;or&nbsp;set&nbsp;any&nbsp;particular&nbsp;member&nbsp;attribute&nbsp;of&nbsp;such&nbsp;an&nbsp;object&nbsp;instance.&nbsp;&nbsp;
&nbsp;*&nbsp;@author&nbsp;Microsoft&nbsp;Corp&nbsp;&nbsp;
&nbsp;*/</span>&nbsp;
&nbsp;
<span class="java__meta">@XmlRootElement</span>&nbsp;
<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">class</span>&nbsp;User{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;following&nbsp;are&nbsp;the&nbsp;individual&nbsp;private&nbsp;members&nbsp;of&nbsp;a&nbsp;User&nbsp;object&nbsp;that&nbsp;holds&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;a&nbsp;particular&nbsp;simple&nbsp;attribute&nbsp;of&nbsp;an&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;ObjectId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;ObjectReference;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;ObjectType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;AccountEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;City;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;Country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;Department;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;DirSyncEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;DisplayName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;FacsimileTelephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;GivenName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;ImmutableId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;JobTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;LastDirSyncTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;Mail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;MailnickName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;Mobile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;PasswordPolicies;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;PhysicalDeliveryOfficeName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;PostalCode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;PreferredLanguage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;State;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;StreetAddress;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;Surname;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;TelephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;UsageLocation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;UserPrincipalName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;manager&nbsp;member&nbsp;variable&nbsp;holds&nbsp;the&nbsp;essential&nbsp;info&nbsp;of&nbsp;the&nbsp;manager&nbsp;of&nbsp;this&nbsp;user&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;such&nbsp;as&nbsp;DisplayName,&nbsp;ObjectId&nbsp;etc.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;UserInfo&nbsp;manager;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;arraylist&nbsp;directReports&nbsp;holds&nbsp;a&nbsp;list&nbsp;of&nbsp;directReports&nbsp;entity&nbsp;of&nbsp;this&nbsp;user.&nbsp;Each&nbsp;Direct&nbsp;Report&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;contains&nbsp;the&nbsp;DisplayName&nbsp;and&nbsp;the&nbsp;Object&nbsp;Id&nbsp;of&nbsp;that&nbsp;direct&nbsp;reports&nbsp;entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;ArrayList&lt;DirectReport&gt;&nbsp;directReports;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;arraylist&nbsp;groups&nbsp;holds&nbsp;a&nbsp;list&nbsp;of&nbsp;group&nbsp;entity&nbsp;this&nbsp;user&nbsp;belongs&nbsp;to.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;ArrayList&lt;GroupInfo&gt;&nbsp;groups;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;arraylist&nbsp;roles&nbsp;holds&nbsp;a&nbsp;list&nbsp;of&nbsp;role&nbsp;entity&nbsp;this&nbsp;user&nbsp;belongs&nbsp;to.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;ArrayList&lt;GroupInfo&gt;&nbsp;roles;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;The&nbsp;constructor&nbsp;for&nbsp;the&nbsp;User&nbsp;class.&nbsp;Initializes&nbsp;the&nbsp;dynamic&nbsp;lists&nbsp;and&nbsp;manager&nbsp;variables.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;User(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;directReports&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;ArrayList&lt;DirectReport&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;groups&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;ArrayList&lt;GroupInfo&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;roles&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;ArrayList&lt;GroupInfo&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;manager&nbsp;=&nbsp;<span class="java__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;objectId&nbsp;of&nbsp;this&nbsp;user.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getObjectId()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;ObjectId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;Set&nbsp;ObjectId&nbsp;of&nbsp;a&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setObjectId(String&nbsp;objectId)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjectId&nbsp;=&nbsp;objectId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;immutableId&nbsp;of&nbsp;this&nbsp;user.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getImmutableId()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;ImmutableId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;Set&nbsp;the&nbsp;ImmutableId&nbsp;of&nbsp;a&nbsp;user&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setImmutableId(String&nbsp;immutableId)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImmutableId&nbsp;=&nbsp;immutableId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;objectReference&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getObjectReference()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;ObjectReference;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;objectReference&nbsp;The&nbsp;objectReference&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setObjectReference(String&nbsp;objectReference)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjectReference&nbsp;=&nbsp;objectReference;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;objectType&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getObjectType()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;ObjectType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;objectType&nbsp;The&nbsp;objectType&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setObjectType(String&nbsp;objectType)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjectType&nbsp;=&nbsp;objectType;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;userPrincipalName&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getUserPrincipalName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;UserPrincipalName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;userPrincipalName&nbsp;The&nbsp;userPrincipalName&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setUserPrincipalName(String&nbsp;userPrincipalName)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UserPrincipalName&nbsp;=&nbsp;userPrincipalName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;usageLocation&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getUsageLocation()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;UsageLocation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;usageLocation&nbsp;The&nbsp;usageLocation&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setUsageLocation(String&nbsp;usageLocation)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UsageLocation&nbsp;=&nbsp;usageLocation;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;telephoneNumber&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getTelephoneNumber()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;TelephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;telephoneNumber&nbsp;The&nbsp;telephoneNumber&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setTelephoneNumber(String&nbsp;telephoneNumber)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TelephoneNumber&nbsp;=&nbsp;telephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;surname&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getSurname()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;Surname;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;surname&nbsp;The&nbsp;surname&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;Object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setSurname(String&nbsp;surname)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Surname&nbsp;=&nbsp;surname;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;streetAddress&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getStreetAddress()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;StreetAddress;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;streetAddress&nbsp;The&nbsp;streetAddress&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setStreetAddress(String&nbsp;streetAddress)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreetAddress&nbsp;=&nbsp;streetAddress;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;state&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getState()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;State;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;state&nbsp;The&nbsp;state&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setState(String&nbsp;state)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;State&nbsp;=&nbsp;state;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;preferredLanguage&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getPreferredLanguage()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;PreferredLanguage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;preferredLanguage&nbsp;The&nbsp;preferredLanguage&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setPreferredLanguage(String&nbsp;preferredLanguage)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PreferredLanguage&nbsp;=&nbsp;preferredLanguage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;postalCode&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getPostalCode()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;PostalCode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;postalCode&nbsp;The&nbsp;postalCode&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setPostalCode(String&nbsp;postalCode)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PostalCode&nbsp;=&nbsp;postalCode;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;physicalDeliveryOfficeName&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getPhysicalDeliveryOfficeName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;PhysicalDeliveryOfficeName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;physicalDeliveryOfficeName&nbsp;The&nbsp;physicalDeliveryOfficeName&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;Object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setPhysicalDeliveryOfficeName(String&nbsp;physicalDeliveryOfficeName)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PhysicalDeliveryOfficeName&nbsp;=&nbsp;physicalDeliveryOfficeName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;passwordPolicies&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getPasswordPolicies()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;PasswordPolicies;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;passwordPolicies&nbsp;The&nbsp;passwordPolicies&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setPasswordPolicies(String&nbsp;passwordPolicies)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PasswordPolicies&nbsp;=&nbsp;passwordPolicies;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;mobile&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getMobile()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;Mobile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;mobile&nbsp;The&nbsp;mobile&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setMobile(String&nbsp;mobile)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mobile&nbsp;=&nbsp;mobile;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;mail&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getMail()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;Mail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;mail&nbsp;The&nbsp;mail&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setMail(String&nbsp;mail)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mail&nbsp;=&nbsp;mail;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;mail&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getMailnickName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;MailnickName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;mail&nbsp;The&nbsp;mail&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setMailnickName(String&nbsp;mailnNickName)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MailnickName&nbsp;=&nbsp;mailnNickName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;jobTitle&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getJobTitle()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;JobTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;jobTitle&nbsp;The&nbsp;jobTitle&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;Object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setJobTitle(String&nbsp;jobTitle)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JobTitle&nbsp;=&nbsp;jobTitle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;givenName&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getGivenName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;GivenName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;givenName&nbsp;The&nbsp;givenName&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setGivenName(String&nbsp;givenName)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GivenName&nbsp;=&nbsp;givenName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;facsimileTelephoneNumber&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getFacsimileTelephoneNumber()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;FacsimileTelephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;facsimileTelephoneNumber&nbsp;The&nbsp;facsimileTelephoneNumber&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;Object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setFacsimileTelephoneNumber(String&nbsp;facsimileTelephoneNumber)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FacsimileTelephoneNumber&nbsp;=&nbsp;facsimileTelephoneNumber;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;displayName&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDisplayName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;DisplayName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;displayName&nbsp;The&nbsp;displayName&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User&nbsp;Object.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setDisplayName(String&nbsp;displayName)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DisplayName&nbsp;=&nbsp;displayName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;dirSyncEnabled&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDirSyncEnabled()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;DirSyncEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dirSyncEnabled&nbsp;The&nbsp;dirSyncEnabled&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setDirSyncEnabled(String&nbsp;dirSyncEnabled)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirSyncEnabled&nbsp;=&nbsp;dirSyncEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;department&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDepartment()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;Department;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;department&nbsp;The&nbsp;department&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setDepartment(String&nbsp;department)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Department&nbsp;=&nbsp;department;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;lastDirSyncTime&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getLastDirSyncTime()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;LastDirSyncTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;lastDirSyncTime&nbsp;The&nbsp;lastDirSyncTime&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setLastDirSyncTime(String&nbsp;lastDirSyncTime)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;LastDirSyncTime&nbsp;=&nbsp;lastDirSyncTime;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;country&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getCountry()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;Country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;country&nbsp;The&nbsp;country&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setCountry(String&nbsp;country)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Country&nbsp;=&nbsp;country;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;city&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getCity()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;City;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;city&nbsp;The&nbsp;city&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setCity(String&nbsp;city)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;City&nbsp;=&nbsp;city;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;accountEnabled&nbsp;attribute&nbsp;of&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getAccountEnabled()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;AccountEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;accountEnabled&nbsp;The&nbsp;accountEnabled&nbsp;to&nbsp;set&nbsp;to&nbsp;this&nbsp;User.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setAccountEnabled(String&nbsp;accountEnabled)&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AccountEnabled&nbsp;=&nbsp;accountEnabled;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Manager&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getManagerDisplayName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">if</span>(manager&nbsp;!=&nbsp;<span class="java__keyword">null</span>){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.manager.getDisplayName();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;objectId&nbsp;of&nbsp;the&nbsp;Manager&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getManagerObjectId()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">if</span>(manager&nbsp;!=&nbsp;<span class="java__keyword">null</span>){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.manager.getObjectId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dName&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Manager.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;oId&nbsp;Object&nbsp;Id&nbsp;of&nbsp;the&nbsp;Manager.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;setManager(String&nbsp;dName,&nbsp;String&nbsp;oId){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.manager&nbsp;=&nbsp;<span class="java__keyword">new</span>&nbsp;UserInfo(dName,&nbsp;oId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dName&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;oId&nbsp;&nbsp;&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;addNewDirectReport(String&nbsp;dName,&nbsp;String&nbsp;oId){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.directReports.add(<span class="java__keyword">new</span>&nbsp;DirectReport(dName,&nbsp;oId));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDirectReportObjectId(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.directReports.get(index).getObjectId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;DirectReport&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDirectReportDisplayName(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.directReports.get(index).getDisplayName();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;the&nbsp;number&nbsp;of&nbsp;direct&nbsp;report&nbsp;entries.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;getDirectReportNumber(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.directReports.size();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dName&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Group&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;oId&nbsp;&nbsp;&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;Group&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;addNewGroup(String&nbsp;dName,&nbsp;String&nbsp;oId){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.groups.add(&nbsp;<span class="java__keyword">new</span>&nbsp;GroupInfo(&nbsp;dName,&nbsp;oId&nbsp;)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;Group&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;Group&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getGroupObjectId(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.groups.get(index).getObjectId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;Group&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Group&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getGroupDisplayName(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.groups.get(index).getDisplayName();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;the&nbsp;number&nbsp;of&nbsp;group&nbsp;entries.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;getGroupNumber(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.groups.size();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;the&nbsp;number&nbsp;of&nbsp;roles&nbsp;entries.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">int</span>&nbsp;getRolesNumber(){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.roles.size();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;Roles&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;Role&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getRoleObjectId(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.roles.get(index).getObjectId();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;index&nbsp;The&nbsp;index&nbsp;of&nbsp;the&nbsp;Roles&nbsp;Entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Roles&nbsp;entry&nbsp;at&nbsp;index.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getRoleDisplayName(<span class="java__keyword">int</span>&nbsp;index){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;<span class="java__keyword">this</span>.roles.get(index).getDisplayName();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dName&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;Role&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;oId&nbsp;&nbsp;&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;Role&nbsp;to&nbsp;be&nbsp;added.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;<span class="java__keyword">void</span>&nbsp;addNewRole(String&nbsp;dName,&nbsp;String&nbsp;oId){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.roles.add(&nbsp;<span class="java__keyword">new</span>&nbsp;GroupInfo(&nbsp;dName,&nbsp;oId&nbsp;)&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;
&nbsp;
&nbsp;
<span class="java__mlcom">/**&nbsp;
&nbsp;*&nbsp;&nbsp;
&nbsp;*&nbsp;The&nbsp;Class&nbsp;DirectReports&nbsp;Holds&nbsp;the&nbsp;essential&nbsp;data&nbsp;for&nbsp;a&nbsp;single&nbsp;DirectReport&nbsp;entry.&nbsp;Namely,&nbsp;
&nbsp;*&nbsp;it&nbsp;holds&nbsp;the&nbsp;displayName&nbsp;and&nbsp;the&nbsp;objectId&nbsp;of&nbsp;the&nbsp;direct&nbsp;entry.&nbsp;Furthermore,&nbsp;it&nbsp;provides&nbsp;the&nbsp;
&nbsp;*&nbsp;access&nbsp;methods&nbsp;to&nbsp;set&nbsp;or&nbsp;get&nbsp;the&nbsp;displayName&nbsp;and&nbsp;the&nbsp;ObjectId&nbsp;of&nbsp;this&nbsp;entry.&nbsp;
&nbsp;*&nbsp;
&nbsp;*/</span>&nbsp;
&nbsp;
<span class="java__keyword">class</span>&nbsp;DirectReport{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;displayName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">private</span>&nbsp;String&nbsp;objectId;&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;Two&nbsp;arguments&nbsp;Constructor&nbsp;for&nbsp;the&nbsp;DirectReport&nbsp;Class.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;dName&nbsp;DisplayName&nbsp;of&nbsp;the&nbsp;DirectReport.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@param&nbsp;oId&nbsp;ObjectId&nbsp;of&nbsp;the&nbsp;DirectReport.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;DirectReport(String&nbsp;dName,&nbsp;String&nbsp;oId){&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.displayName&nbsp;=&nbsp;dName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">this</span>.objectId&nbsp;=&nbsp;oId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;diaplayName&nbsp;of&nbsp;this&nbsp;direct&nbsp;report&nbsp;entry.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getDisplayName()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;displayName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__mlcom">/**&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;@return&nbsp;The&nbsp;objectId&nbsp;of&nbsp;this&nbsp;direct&nbsp;report&nbsp;entry.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">public</span>&nbsp;String&nbsp;getObjectId()&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="java__keyword">return</span>&nbsp;objectId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>More Information</h1>
<ul>
<li><span style="font-size:x-small">Microsoft Windows Azure Active Directory Graph API full description:<a href="http://msdn.microsoft.com/en-us/library/hh974476.aspx" target="_blank">http://msdn.microsoft.com/en-us/library/hh974476.aspx</a></span>
</li><li><span style="font-size:x-small">Release Notes <a href="http://msdn.microsoft.com/en-us/library/jj149807">
http://msdn.microsoft.com/en-us/library/jj149807</a></span> </li><li><span style="font-size:x-small">C# Sample Application <a href="http://code.msdn.microsoft.com/Write-Sample-App-for-79e55502">
http://code.msdn.microsoft.com/Write-Sample-App-for-79e55502</a></span> </li><li><span style="font-size:x-small">Graph Explorer:&nbsp;a simple User interface that allows you to query and review results from the Demo company, or your own company:
<a href="https://GraphExplorer.CloudApp.net " target="_blank">https://GraphExplorer.CloudApp.net</a></span>
</li><li><span style="font-size:x-small">Graph API Differential Queries Sample App <a href="http://code.msdn.microsoft.com/windowsazure/Sample-App-for-Windows-97eaec90">
http://code.msdn.microsoft.com/windowsazure/Sample-App-for-Windows-97eaec90</a></span>
<ul>
<li><span style="font-size:x-small">Documentation <a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj836245.aspx">
http://msdn.microsoft.com/en-us/library/windowsazure/jj836245.aspx</a></span> </li></ul>
</li></ul>
<p><span style="font-size:x-small">&nbsp;</span></p>
<ul>
<li><span style="font-size:x-small">Windows Azure Authentication Library (AAL) documentation and release notes<span dir="ltr" style="direction:ltr"><span dir="ltr" style="color:#0000ff; font-family:&quot;Tahoma&quot;; font-size:10pt; direction:ltr; word-wrap:break-word"><a title="http://msdn.microsoft.com/en-us/library/jj573266" href="http://msdn.microsoft.com/en-us/library/jj573266">http://msdn.microsoft.com/en-us/library/jj573266</a></span></span></span>
</li></ul>
<ul>
<li><span style="font-size:x-small">Sign-up for&nbsp;a</span>&nbsp;<span style="font-size:x-small">standalone Windows Azure AD tenant<a href="http://g.microsoftonline.com/0AX00en/5"> here
</a>or a 30 day trial of an Office 365 tenant:<a href="http://www.office365.com" target="_blank">www.office365.com</a><a href="http://www.office365.com" target="_blank"></a><a href="http://www.office365.com" target="_blank"></a><a href="http://www.office365.com" target="_blank"></a></span>
</li></ul>
<ul>
<li>
<div><span style="font-size:x-small">Graph API Metadata endpoint: <a href="https://Directory.Windows.net/$metadata" target="_blank">
https://Graph.Windows.net/Contoso.com/$metadata</a></span></div>
</li><li>
<div><span style="font-size:x-small">View Presentations from TechEd June 2012 on the Graph API and Windows Azure Active Directory overview.</span></div>
<ul>
<li>
<div><span style="font-size:x-small">Windows Azure AD Graph API Drill down <a href="http://channel9.msdn.com/events/teched/northamerica/2012/sia322" target="_blank">
http://channel9.msdn.com/events/teched/northamerica/2012/sia322</a></span></div>
</li><li>
<div><span style="font-size:x-small">A Lap around Windows Azure Active Directory <a href="http://channel9.msdn.com/events/teched/northamerica/2012/sia209" target="_blank">
http://channel9.msdn.com/events/teched/northamerica/2012/sia209</a></span></div>
</li></ul>
</li></ul>
