# Federation Metadata
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- .NET Framework
- Windows Identity Foundation
## Topics
- claims-based authentication
## Updated
- 01/29/2013
## Description

<h1>Overview</h1>
<p class="MsoNormal">This sample will show you how to dynamically consume WS-Federation metadata at run time in an ASP.NET Web Application. You will also see how to create a basic STS that produces WS-Federation metadata and issues tokens.</p>
<p class="MsoNormal">In addition this sample shows the basics of how claims have been integrated into the .NET framework. You will learn how a web application is enabled to use WIF. You will see how they are useful from within existing properties and functions,
 and how you can take the next step to using them directly using the ClaimsPrincipal class in System.Security.Claims. You also will also learn how to work with the local STS that is part of the Identity and Access tool for Visual Studio
<a name="_GoBack"></a>2012.</p>
<h1>Prerequisites</h1>
<p class="MsoNormal">You must have the <a href="http://go.microsoft.com/fwlink/?LinkID=245849">
Identity and Access Tool for Visual Studio 2012</a> installed. You can find this via the Extension Manager or download it directly from Visual Studio Gallery.</p>
<h1>How To Run</h1>
<p class="MsoNormal">To run this sample, start Visual Studio 2012 as administrator, open the project, and run the project by hitting F5. When you do you will be redirected from the web application to an STS that will issue you a token then redirect you back
 to the web application where you will see the user name displayed in the header and in the body of the page. You will also see an email address displayed and a table of claim values for the authenticated user.</p>
<p class="MsoNormal">Please note: if when you hit F5 you notice that VS starts only one project, please stop the debugger, right click on the solution in Solution Explorer, and choose &quot;Set StartUp Projects...&quot;. In the dialog select &quot;Multiple Startup Projects&quot;,
 and assign the action &quot;Start&quot; to both &quot;WebApplication&quot; and &quot;WSFederationSecurityTokenService&quot;. Hit OK, then prss F5 again.</p>
<h1>Dynamic WS-Federation Details</h1>
<p class="MsoNormal"><span>&nbsp;</span>This sample has already been configured to use the custom STS in the WSFederationSecurityTokenService project that is part of this solution. All of the required settings are present in the web.config of the Web Application
 project. On application startup the federation metadata of the custom STS will be read from the address in the web.config to process any changes, you can see this in Application_Start of the global.asax. Examine the web.config prior to running the sample,
 note that there is no system.identitymodel\identityConfiguration\issuerNameRegistry element present (if you have already run the sample remove this element from the web.config). Run the sample then reexamine the web.config, notice that this element has been
 added dynamically at application startup.</p>
<p class="MsoNormal">You can also examine the CustomSecurityTokenServiceConfiguration class to see how metadata is generated and the CustomSecurityTokenService class to see how claims are issued in the WSFederationSecurityTokenService project.</p>
<h1>Claims Usage Details</h1>
<p class="MsoNormal"><span>&nbsp;</span>In the body of the page the name is displayed using the Page.User.Identity.Name property. In the header the name is displayed using the LoginName control. The value itself is from a claim that the Windows Identity Foundation
 processed from a security token and integrated into the current user principal. Other claims can also be sent in a security token. These claims can be accessed directly, for example the email address displayed in the body is another claim in the security token.
 That is accessed in the code behind of default.aspx page by creating a ClaimsPrincipal from the current user. You can see all of the claims returned in the security token below in the GridView where we have used the ClaimsPrincipal as the data source in the
 code behind.</p>
<p class="MsoNormal">So where is the user in this sample from? Where are they being authenticated? This sample is configured to use an STS from the WSFederationSecurityTokenService project that is part of the solution. As this is used only for testing it
 does not actually authenticate a user. It simply issues a security token with the claims it is configured with whenever an application asks. See the GetOutputClaimsIdentity method in CustomSecurityTokenService.cs to see how claims are added to the ClaimsIdentity.
 . DO NOT use this STS sample code &lsquo;as is&rsquo; in production code.</p>
<h1>Troubleshooting</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span>I get an error from the Local STS when I hit F5</p>
<p class="MsoListParagraphCxSpLast">You need to run VS in admin mode to use the Local STS as it needs to be able to open ports to function.</p>
<h1>Security Considerations</h1>
<p class="MsoNormal">For illustrative purposes this sample application shows all the properties of claims (i.e. claim types and claim values), which are issued by a security token service (STS). In production code, security implications of echoing the properties
 of claims should be carefully considered. For example, some of the security considerations are: (i) accepting only claim types that are expected by the applications; (ii) sanitizing the claim properties before using them; and (iii) filtering out claims that
 may contain sensitive personal information. DO NOT use this sample code &lsquo;as is&rsquo; in production code.</p>
<h1>References</h1>
<p class="MsoListParagraphCxSpFirst"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245850">Windows Identity Foundation .NET 4.5 Reference documentation</a></p>
<p class="MsoListParagraphCxSpLast"><span style="font-family:Symbol"><span>&middot;<span style="font:7.0pt &quot;Times New Roman&quot;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span></span></span><a href="http://go.microsoft.com/fwlink/?LinkID=245849">Identity and Access Tool for Visual Studio 2012</a></p>
<p class="MsoNormal">&nbsp;</p>
