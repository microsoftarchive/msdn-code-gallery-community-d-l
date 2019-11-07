# Event Aggregation Code Sample using the Prism Library
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- WinRT
- Windows Phone 8
- Windows Store app
## Topics
- Prism
- Publisher/Subscriber
- Publish Subscribe
- Prism Event Aggregation
## Updated
- 08/21/2014
## Description

<h1>Introduction</h1>
<p>The Event Aggregation QuickStart sample demonstrates how to build a composite application that uses the Prism Library&rsquo;s Event Aggregator service. This service enables you to establish loosely coupled communications between components in your application.
 The Event Aggregator is a Portable Class Library (PCL) so it can be used on WPF, Windows Phone 8, and Windows Store apps.</p>
<p>The<strong> EventAggregator</strong> provides multicast publish/subscribe functionality. This means there can be multiple publishers that raise the same event and there can be multiple subscribers listening to the same event. Consider using the
<strong>EventAggregator</strong> to publish an event across modules and when sending a message between business logic code, such as controllers and presenters.&nbsp;</p>
<p>Events created with the Prism Library are typed events. This means you can take advantage of compile-time type checking to detect errors before you run the application. In the Prism Library, the
<strong>EventAggregator</strong> allows subscribers or publishers to locate a specific
<strong>EventBase</strong>. The event aggregator also allows for multiple publishers and multiple subscribers.</p>
<h1><span>Building the Sample</span></h1>
<p class="ppBodyText">This QuickStart requires Microsoft Visual Studio 2012 or later and the .NET Framework 4.5.1.</p>
<p class="ppProcedureStart">To build and run the MVVM QuickStart</p>
<ol>
<li>In Visual Studio, open the solution file EventAggregation\EventAggregation_Desktop.sln
</li><li>In the&nbsp;<strong>Build</strong>&nbsp;menu, click&nbsp;<strong>Rebuild Solution</strong>.
</li><li>Press F5 to run the QuickStart. </li></ol>
<p>&nbsp;</p>
<ul>
</ul>
<h1>More Information</h1>
<p><em><em>For more information on the MVVM QuickStart, see the associated&nbsp;<a href="http://aka.ms/prism-wpf-QSEADoc">documentation&nbsp;</a>on MSDN.&nbsp;</em></em></p>
