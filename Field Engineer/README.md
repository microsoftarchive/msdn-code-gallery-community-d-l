# Field Engineer
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Microsoft Azure
- Windows Azure Mobile Services
- Mobile Services
## Topics
- Offline Mobile application
- Windows Azure Mobile Services
- Azure Mobile Services offline support
- Azure Mobile Services .NET Backend
## Updated
- 12/09/2014
## Description

<h1>Introduction</h1>
<p>Field Engineer helps mobile field agents keep track of work assignments, complete with destination routing and inventory management. The application allows an agent to view currently assigned tasks and to capture customer signoff when the job is complete,
 even when offline.</p>
<p>A complete version of the app is available&nbsp;for viewing in the <a href="http://apps.microsoft.com/windows/en-us/app/field-engineer/47e616cc-8ca3-4608-8886-55a982a2390d">
Windows Store</a>.</p>
<h1><span>Building the Sample</span></h1>
<h2>Tools needed</h2>
<p>&nbsp;- Visual Studio 2013 (<a href="http://www.visualstudio.com/en-us/downloads">http://www.visualstudio.com/en-us/downloads</a>)<br>
&nbsp;- Windows Store Developer account (<a href="https://appdev.microsoft.com/StorePortals/en-US/Account/signup/start">https://appdev.microsoft.com/StorePortals/en-US/Account/signup/start</a>)<br>
&nbsp;-&nbsp; Azure Subscription (<a href="http://azure.microsoft.com/en-us/">http://azure.microsoft.com/en-us/</a>)</p>
<h2>Building Solution</h2>
<p>- Install Bing Maps Extension (<a href="http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1">http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1</a>)<br>
- Install SQLite for Windows 8.1 (<a href="http://visualstudiogallery.msdn.microsoft.com/1d04f82f-2fe9-4727-a2f9-a2db127ddc9a">http://visualstudiogallery.msdn.microsoft.com/1d04f82f-2fe9-4727-a2f9-a2db127ddc9a</a>)<br>
- Open AzureMobile.Samples.FieldEngineer.sln&nbsp;and build solution. This will download all the required nuget package references</p>
<p>&nbsp;</p>
<h2>Mobile Service Setup</h2>
<p>1. Create New MobileService with new database on Azure Portal (<a href="https://manage.windowsazure.com/">https://manage.windowsazure.com/</a>)<br>
2. Register an app with windows store (<a href="http://msdn.microsoft.com/en-US/windows/apps/br211386">http://msdn.microsoft.com/en-US/windows/apps/br211386</a>)<br>
3.&nbsp;Setup Push credentials (<a href="http://msdn.microsoft.com/en-us/library/azure/jj591526.aspx">http://msdn.microsoft.com/en-us/library/azure/jj591526.aspx</a>)</p>
<h2>Azure Active Directory Setup</h2>
<p>1. Follow instructions at&nbsp;Single Sign on with AAD (<a href="http://azure.microsoft.com/en-us/documentation/articles/mobile-services-windows-store-dotnet-adal-sso-authentication/">http://azure.microsoft.com/en-us/documentation/articles/mobile-services-windows-store-dotnet-adal-sso-authentication/</a>)
 to setup AAD native app.<br>
2. Follow instructions&nbsp;AAD authentication with Mobile Service (<a href="http://azure.microsoft.com/en-us/documentation/articles/mobile-services-how-to-register-active-directory-authentication/">http://azure.microsoft.com/en-us/documentation/articles/mobile-services-how-to-register-active-directory-authentication/</a>
 ) to use AAD authentication with MobileService<br>
3. Go to configure page for the AAD Web App created above: <br>
&nbsp;(This App will be used to update/read information about AAD users)<br>
&nbsp;-&nbsp; Update permissions to include all the delegated permissions. <br>
&nbsp;-&nbsp; Update permissions to include Read and Write Directory Data Application Permissions.<br>
&nbsp;-&nbsp; Create a key. **Make sure you save the key created at this step. We will need this later**<br>
&nbsp;<br>
4. GO to Groups tab on AD and create two groups:<br>
&nbsp;&nbsp;&nbsp; - FieldAgents <br>
&nbsp;&nbsp;&nbsp; - Managers<br>
5. Save following information from the AD:</p>
<p>&nbsp;- Go to FieldAgent group configure page. Get the object id for the group.
<br>
&nbsp;- Go to Manager group configure page. Get the object id for the group. <br>
&nbsp;- Go to Domains page for directory. Get the default domain.</p>
<p>&nbsp;</p>
<h2>Create Active Directory Users</h2>
<p><br>
1. Go to Users tab, create a minimum of **3** users. Once the user is created add alternate email address on profile tab.
<br>
2. Go to FieldAgents Group and Add 2 members<br>
3. Go to Managers Group and 1 member</p>
<p>Jobs in database are equally distributed among the users in FieldAgents. You can increase the number of users to suit your needs.</p>
<h2><br>
Database setup</h2>
<p>1. Open AzureMobile.Samples.FieldEngineer.Setup project and update following in App.config:<br>
&nbsp; - AadTenantDomain&nbsp;: Your Active Directory Domain name. Get this from Domains tab on your directory. This looks like: xxxxxxxx.onmicrosoft.com<br>
&nbsp; - MS_AadClientID: Client id for the Web App you setup<br>
&nbsp; - AadServiceAppKey: Key you saved earlier in Active Directory Setup<br>
&nbsp; - AadFieldAgentGroupObjectId: ObjectId for FieldAgents Group. You can get this from FieldAgents Group configure page<br>
&nbsp; - AadFieldManagerGroupObjectId: ObjectId for Managers Group. You can get this from Managers Group configure page<br>
&nbsp; - MS_TableConnectionString : SQL Azure Connection string. Get ADO.Net connection string from Azure SQL DB Dashboard.<br>
&nbsp; - MS_MobileServiceName: The name you used when creating the mobile service<br>
&nbsp; - Run the project, and paste in the Master Key for your mobile serivce when prompted. The master key can be found by clicking &quot;Manage Keys&quot; while on the dashboard page of the Mobile Services Management Portal.</p>
<p>&nbsp;</p>
<h2>(Optional) Enable app analytics with Microsoft-owned Capptain.com</h2>
<p>1. Register your application according to the instructions on <a href="http://www.capptain.com/">
http://www.capptain.com/</a> and obtain an Application ID and an SDK Key.<br>
2. In CapptainConfiguration.xml, replace &quot;ReplaceWithYourApplicationId&quot; with the Application ID you obtained during registration.<br>
3. Replace &quot;ReplaceWithYourSDKKey&quot; with the SDK Key you obtained during registration.</p>
<h2>Publish Mobile Service</h2>
<p>1.&nbsp; Add following AppSettings from Mobile Service from Configure page on Azure Portal(<a href="https://manage.windowsazure.com">https://manage.windowsazure.com</a>)<br>
&nbsp;- Key: AadFieldAgentGroupObjectId Value: Object Id for the FieldAgents group<br>
&nbsp;- Key: AadFieldManagerGroupObjectId Value: Object Id for the Managers group<br>
&nbsp;- Key: AadTenantDomain Value: AAD Domain<br>
&nbsp;- Key: AadServiceAppKey Value: This is the key from AD Web App &nbsp;</p>
<p>2. To send email when job is completed, set up SendGrid account and add following AppSettings in MobileService:<br>
&nbsp;- Key: SendGridUserName value: SendGrid account user name<br>
&nbsp;- Key: SendGridPassword value: Send grid account password<br>
&nbsp;- Key: SendGridFromEmailId value: Address from which you Email will be sent<br>
&nbsp;- Key: SendGridFromEmailUserName value: Your name</p>
<p>&nbsp; <br>
3. Publish Service to the MobileService you created. To see how to publish take a look at &quot;Publish Your Mobile Service&quot; section in this article (<a href="http://azure.microsoft.com/en-us/documentation/articles/mobile-services-dotnet-backend-windows-store-dotnet-get-started/">http://azure.microsoft.com/en-us/documentation/articles/mobile-services-dotnet-backend-windows-store-dotnet-get-started/</a>)</p>
<p>&nbsp;</p>
<h2>Run Windows Store App</h2>
<p><br>
1. Update following in Secrets.cs:<br>
&nbsp;- MobileServiceUrl = &quot;https Mobile Service URL&quot;;<br>
&nbsp;- MobileServiceAccessKey = &quot;Mobile Service Application Key&quot;;<br>
&nbsp;- AadDomainName = &quot;AAD Domain Name&quot;;<br>
&nbsp;- AadNativeClientId = &quot;Native App Client ID&quot;;</p>
<p>2. Run AzureMobile.Samples.FieldEngineer.Windows project</p>
<p>3. Login using AD user credentials. You can login with any user from FieldAgents group</p>
<p>&nbsp;</p>
<h2>(Optional) FieldEngineerManager</h2>
<p><span style="font-size:10px"><span style="font-size:x-small">FieldEngineerManager app
</span>is a&nbsp;</span>simple MVC app with AAD authentication and connects to Mobile Service to:</p>
<p class="MsoNormal"><span style="text-indent:-0.25in">Create Job: If the agent new job is created for is logged into client app, it will recieve push notification</span></p>
<p class="MsoNormal"><span style="text-indent:-0.25in">&nbsp;</span><span style="text-indent:-0.25in">To reset jobs for a selected agent: This is useful if you want to clean up jobs table.</span></p>
<p class="MsoListParagraph" style="text-indent:-.25in"><strong>-<span style="font-size:small; font-family:'Times New Roman'">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; AAD Setup</span></strong></p>
<ol>
<li>Sign in to the Azure management portal. </li><li>Click on Active Directory in the left hand nav. </li><li>Click the directory tenant where you wish to register the sample application.
</li><li>Click the Applications tab. </li><li>In the drawer, click Add. </li><li>Click &quot;Add an application my organization is developing&quot;. </li><li>Enter a friendly name for the application, for example &quot;MyFieldEngineerManager&quot;, select &quot;Web Application and/or Web API&quot;, and click next.
</li><li>For the sign-on URL, enter the base URL for the sample, which is by default https://localhost:44322/. NOTE: It is important, due to the way Azure AD matches URLs, to ensure there is a trailing slash on the end of this URL. If you don't include the trailing
 slash, you will receive an error when the application attempts to redeem an authorization code.
</li><li>For the App ID URI, enter https://&lt;your_tenant_name&gt;/MyFieldEngineerManager, replacing &lt;your_tenant_name&gt; with the domain name of your Azure AD tenant. For Example &quot;https://contoso.com/MyFieldEngineerManager&quot;. Click OK to complete the registration.
</li><li>While still in the Azure portal, click the Configure tab of your application.
</li><li>Find the Client ID value and copy it aside, you will need this later when configuring your application.
</li><li>In the Reply URL, add the reply URL address used to return the authorization code returned during Authorization code flow. For example: &quot;https://localhost:44322/&quot;
</li><li>Under the Keys section, select either a 1 year or 2 year key - the keyValue will be displayed after you save the configuration at the end.
</li><li>Configure Permissions - under the &quot;Permissions to other applications&quot; section, select application &quot;Windows Azure Active Directory&quot; (this is the Graph API), and under the second permission (Delegated permissions), select &quot;Access your organization's directory&quot;
 and &quot;Enable sign-on and read users' profiles&quot;. The 2nd column (Application permission) is not needed for this demo app.
</li><li>Select the Save button at the bottom of the screen - upon sucessful configuration, your Key value should now be displayed - please copy and store this value in a secure location. The key value is only displayed once, and you will not be able to retrieve
 it later. </li></ol>
<p><strong style="text-indent:-24px"><span style="font-size:small; font-family:'Times New Roman'">&nbsp;Configure Manager app with AAD and run the app</span></strong></p>
<p><strong style="text-indent:-24px"><span style="font-size:small; font-family:'Times New Roman'">&nbsp;</span></strong>Open AzureMobile.Samples.FieldEngineer.Manager project and update following in Web.config:</p>
<ol>
<li>ida:Tenant - Your Active Directory Domain name. Get this from Domains tab on your directory. This looks like: xxxxxxxx.onmicrosoft.com
</li><li>ida:ClientId - Client id for the Web App you setup </li><li>ida:AppKey - Key you saved earlier in Active Directory Setup </li><li>MobileServiceUrl- FieldEngineer MobileServiceURL. This looks like https://&lt;NameofMobileService&gt;.azure-mobile.net
</li></ol>
<p><strong style="text-indent:-24px"><span style="font-size:small; font-family:'Times New Roman'"><span style="font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px; font-weight:normal; text-indent:0px">Run the project, and login with a user in Manager
 group</span></span></strong></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
</div>
