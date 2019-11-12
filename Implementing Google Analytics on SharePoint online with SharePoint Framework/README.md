# Implementing Google Analytics on SharePoint online with SharePoint Framework
## License
- MIT
## Technologies
- SharePoint Framework
## Topics
- SharePoint
## Updated
- 03/23/2018
## Description

<h1>Introduction</h1>
<p><em><span>In this article I&rsquo;m going to talk about&nbsp;</span><a rel="noopener" href="https://analytics.google.com/" target="_blank">Google Analytics</a><span>&nbsp;and&nbsp;</span><a rel="noopener" href="https://dev.office.com/sharepoint/docs/spfx/sharepoint-framework-overview" target="_blank">SharePoint
 Framework</a><span>, the first is one of the most famous analytics service and the second&nbsp;is an amazing development way.</span></em></p>
<h1><span>Building the Sample</span></h1>
<p>Microsoft has released SharePoint Framework in general availability worldwide, only to do a recap, the latter allow to build client side web part (React, Angular, jQuery, Riot&hellip;.) for Office 365 SharePoint online (in this year will be also available
 for SharePoint On-Premise 2016), but is not all, in fact Microsoft has introduced in these days SharePoint Framework Extensions (preview), you can take a look at the official documentations and the Github project:</p>
<p><a rel="noopener" href="https://dev.office.com/sharepoint/docs/spfx/extensions/overview-extensions" target="_blank">https://dev.office.com/sharepoint/docs/spfx/extensions/overview-extensions</a><br>
<a rel="noopener" href="https://github.com/SharePoint/sp-dev-fx-extensions" target="_blank">https://github.com/SharePoint/sp-dev-fx-extensions</a></p>
<p>In few words gives the possibility to extend the user experience within modern pages, basically we have three&nbsp;Extension types, Application Customizers, Field Customizers and Command Sets, please take a look at the link above&nbsp;If you want to deepen
 the argument.<br>
In order to achieve my goal I used a SharePoint Framework Application Customizer, the code is really easy, in fact in the onRender() method basically I inject the Google Analytics code necessary to monitor the site in the head tag, here my solution on github:</p>
<p><a rel="noopener" href="https://github.com/giuleon/js-application-analytics" target="_blank">https://github.com/giuleon/js-application-analytics</a></p>
<p><em><img id="174306" src="174308-js-application-google-analytics.gif.gif" alt="Giuliano De Luca | Blog | Implementing Google Analytics on SharePoint Online" width="700px"><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>Feel free to give your contribution is more than welcome.</span></p>
<ul>
</ul>
<h1>More Information</h1>
<p><em><a href="https://github.com/giuleon/js-application-analytics" target="_blank">https://github.com/giuleon/js-application-analytics</a></em></p>
<p><em><a href="https://www.delucagiuliano.com/implement-google-analytics-on-sharepoint-online-thanks-to-sharepoint-framework-extensions" target="_blank">https://www.delucagiuliano.com/implement-google-analytics-on-sharepoint-online-thanks-to-sharepoint-framework-extensions</a><br>
</em></p>
