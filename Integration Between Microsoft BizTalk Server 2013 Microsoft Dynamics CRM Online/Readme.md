# Integration Between Microsoft BizTalk Server 2013 Microsoft Dynamics CRM Online
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- WCF
- BizTalk Server
- Visual C#
- WCF behavior
- BizTalk Server 2013 R2
- Microsoft Dynamics CRM 2015 Online
- Microsoft Dynamics CRM 2016 Online
## Topics
- WCF Extensibility
- security token service
- integration
- BizTalk Server 2013
## Updated
- 04/24/2016
## Description

<h3><strong>Introduction</strong></h3>
<ul>
<li>This solution shows how you can integrate a BizTalk Server 2013 application with the Microsoft Dynamics CRM Online 2016 using the WCF-Custom adapter with Custom Behavior to exchange messages with external systems in a reliable, flexible, and scalable manner.
</li><li>Microsoft does not provide an adapter for Microsoft Dynamics CRM 2011- 2016 and the integration can only be realized via an original WCF service.
</li><li>BizTalk will communicate to Dynamics CRM for all types of operations like below using&nbsp;Organization&nbsp;Service.
</li></ul>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Create</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Update</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Delete</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Execute</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Associate</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Disassociate</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - Retrieve</p>
<p>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; - RetrieveMultiple</p>
<h3><strong>Description</strong></h3>
<ul>
<li>In my recent project, I got a scenario where we need to establish a connection to Microsoft Dynamics CRM Online through BizTalk Server 2013 R2.
</li><li>But when I started with this, there is no helpful information related to CRM Connectivity or Adapters or Connections related to BizTalk.
</li><li>BizTalk server should invoke all the WCF methods exposed by CRM Online 2016 Organization Service.
</li><li>The solution uses the following elements to realize the integration between the two products : WCF-Custom adapter using&nbsp;wsHttpBinding with custom Endpoint Behavior to communicate to CRM Online system.
</li></ul>
<h3><strong>Building the Sample</strong></h3>
<ul>
<li><span style="text-indent:-0.25in">Follow the below-detailed steps to Run the below sample.</span>
</li><li><span style="text-indent:-0.25in">See the complete Technet Wiki Article t</span><span style="text-indent:-0.25in">o Know the detailed deployment steps and to run the sample code E2E with BizTalk applications&nbsp;</span><span class="MsoHyperlink" style="text-indent:-0.25in"><a title="Technet Wiki Article" href="http://social.technet.microsoft.com/wiki/contents/articles/33960.integration-between-microsoft-biztalk-server-2013-microsoft-dynamics-crm-online-2016.aspx" target="_blank">Technet
 Wiki Article</a></span> </li></ul>
<h3>Conclusions</h3>
<ul>
<li>This article shows how BizTalk Server will communicate with Microsoft Dynamics CRM Online 2016 using the concepts of WCF Extensibility.
</li></ul>
<h3>See Also</h3>
<ul>
<li>Another important place to find a huge amount of BizTalk related articles is the TechNet Wiki itself. The best entry point is
<a title="BizTalk Server Resources on the TechNet Wiki" href="http://social.technet.microsoft.com/wiki/contents/articles/2240.biztalk-server-resources-on-the-technet-wiki.aspx" target="_blank">
BizTalk Server Resources on the TechNet Wiki</a>. </li></ul>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
<p class="MsoListParagraph" style="text-indent:-.25in">&lt;!--[if !supportLists]--&gt;d1.<span style="font-size:7pt; font-family:'Times New Roman'">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span>&lt;!--[endif]--&gt;The Sample Endpoint Behavior takes four parameters like described below.</p>
</div>
