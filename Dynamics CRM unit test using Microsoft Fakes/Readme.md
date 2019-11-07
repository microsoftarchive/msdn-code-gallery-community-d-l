# Dynamics CRM unit test using Microsoft Fakes
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- Dynamics CRM
## Topics
- Dynamics CRM Unit Test
## Updated
- 08/02/2012
## Description

<h1>Introduction</h1>
<p><em>This sample demonstrate how to use Microsoft Fakes to isolate Dynamics CRM unit test.</em></p>
<h1>
<p><em>&nbsp;</em></p>
<span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><em>This sample provide two ways to unit test Dynamics CRM code, one is to use run time redirect delegete feature of Microsoft Fakes to directly mock required API, the other is to mock IOrganizationService core API to indirectly isolate code under test.</em></p>
<h1><span>Source Code Files</span></h1>
<p><em>1. WebService Project</em></p>
<ul>
<li><em>ContextMethods.cs - code using OrganizationServiceContext</em> </li><li><em><em>ContextMethods2.cs - code using OrganizationServiceContext through IOrganizationService</em></em>
</li><li>CrmContextMethods.cs -&nbsp;code using CrmOrganizationServiceContext </li><li>CrmContextMethods2.cs -&nbsp;code using CrmOrganizationServiceContext&nbsp;through IOrganizationService
</li><li>LINQToCRM.cs - code demonstrate linq to crm query </li><li>LINQToCRM2.cs - code demonstrate linq to crm query through IOrganizationService
</li><li>OrganizationServiceMethods.cs - code using IOrganizationService </li></ul>
<p>2. Plugin project</p>
<ul>
<li>Plugin.cs - a sample Dynamics CRM&nbsp;plugin, which is called after a contact is created within Dynamics CRM, if the parent customer is set to an account, the number of employees attribute of that account will be increased by one
</li></ul>
<p>3. Workflow project</p>
<ul>
<li>AddMemberTeamActivity.cs - a sample Dynamics CRM custom workflow activity, which will add a user to a team
</li></ul>
<h1>More Information</h1>
<p><em>For more information <a href="http://zhongchenzhou.wordpress.com/2012/07/08/dynamics-crm-2011-unit-test-part-1-introduction-and-series-contents/">
http://zhongchenzhou.wordpress.com/2012/07/08/dynamics-crm-2011-unit-test-part-1-introduction-and-series-contents/</a></em></p>
