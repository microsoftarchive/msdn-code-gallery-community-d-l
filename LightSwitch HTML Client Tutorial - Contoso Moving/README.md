# LightSwitch HTML Client Tutorial - Contoso Moving
## Requires
- Visual Studio LightSwitch
## License
- Apache License, Version 2.0
## Technologies
- Visual Studio LightSwitch
## Topics
- Visual Studio LightSwitch
- Rapid Application Development
- mobile application development
## Updated
- 12/06/2013
## Description

<h2>Introduction</h2>
<p>The <a href="http://msdn.microsoft.com/en-US/vstudio/htmlclient">new HTML5 and JavaScript-based client
</a>is an important companion to our Silverlight-based desktop client that addresses the increasing need to build touch-oriented business applications that run well on modern mobile devices.&nbsp;</p>
<p>In this tutorial, we&rsquo;ll build a touch-first, modern experience for mobile devices.&nbsp; To help ground the tutorial, we&rsquo;ve created a fictional company scenario that has a need for such an application.</p>
<h2>Building the Sample</h2>
<p>Download the source files to a machine that has Visual Studio 2012 Update 2 installed. Follow the steps described in the Contoso Moving Tutorial to build a LightSwitch HTML client using these files.</p>
<h2><strong>Helpful Resources</strong></h2>
<p>As you walk through this tutorial, please bear in mind that there are useful resources available to help you should you get stuck or have a question:</p>
<ul>
<li><a href="http://social.msdn.microsoft.com/Forums/en-US/lightswitch/threads">LightSwitch forum
</a>to post feedback and ask questions, and check back for any corrections to the walkthrough document.
</li><li><a href="http://msdn.microsoft.com/en-us/lightswitch/htmlclient">HTML Client Resources Page on the Developer Center</a> for more learning resources &amp; to download the HTML Client.
</li></ul>
<h2>The Contoso Moving Application</h2>
<p><em>Contoso Moving </em>is an application that&rsquo;s used by <em>Contoso Movers, Inc</em>. to take the inventory of customers&rsquo; residences prior to moving.&nbsp; The data collected via the application helps
<em>Contoso Movers </em>determine the resources required to move a particular client&rsquo;s belongings&mdash;how many trucks, people, boxes, etc. need to be allocated. The application is comprised of two clients that serve distinct business functions:</p>
<ol>
<li><strong>Schedulers use a desktop application </strong>to service new customer requests and create appointments. This application is a rich desktop application primarily geared towards heavy data entry with the keyboard and mouse, since Schedulers are on
 the phone with customers a lot and need to enter quite a bit of information into the system during the course of a day.
</li><li><strong>Planning Specialists use a tablet device </strong>to quickly take inventory&mdash;on location&mdash;of each residence on the specialist&rsquo;s schedule for the day. Taking inventory involves detailing each room in the residence, its size and entry
 requirements (if any), and listing its contents. Pictures are often taken of each room so the movers have a point of reference when they arrive. Secondarily, Planning Specialists may make notes about parking restrictions for the move team (i.e., where they
 can park the truck during the move). </li></ol>
<p>This tutorial walks through building out the mobile client used by <em>Contoso Movers&rsquo;
</em>planning specialists.&nbsp;</p>
