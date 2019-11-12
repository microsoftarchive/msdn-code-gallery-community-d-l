# Handling Exceptions inside BizTalk Orchestrations
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- BizTalk Server
## Topics
- BizTalk
## Updated
- 02/27/2017
## Description

<h1>Introduction</h1>
<p><span style="font-family:Tahoma; font-size:small">Handling exceptions inside orchestration is the equivalent of doing a &ldquo;catch { }&rdquo; block in C#, of course, there are some little differences, but the idea is the same.</span></p>
<h1>General Exception Type</h1>
<p><span style="font-family:Tahoma; font-size:small">When we create New Exception Handler, in property &ldquo;Exception Object Type combo, the only item in the list is &lsquo;General Exception&rsquo;:
</span></p>
<p><span style="font-family:Tahoma; font-size:small">Think of catching a &ldquo;Generic Exception&rdquo; as the equivalent of doing a &ldquo;catch { }&rdquo; block in C#
<strong><span style="text-decoration:underline">with no exception declared</span></strong>. &ldquo;General Exception&rdquo; allows BizTalk to deal with any exception it may catch and re-throw, there&rsquo;s no way to get the exception message at that point.
</span></p>
<p style="text-align:center"><span style="font-family:Tahoma; font-size:small"><a rel="WLPP;url=http://sandroaspbiztalkblog.files.wordpress.com/2009/10/general-exception.jpg?w=300" href="http://sandroaspbiztalkblog.files.wordpress.com/2009/10/general-exception.jpg?w=300"><img class="aligncenter" src="-general-exception.jpg?w=300" alt=""></a></span></p>
<h1>How can I get Exception Message</h1>
<p><span style="font-family:Tahoma; font-size:small">You can accomplish this by changing the exception type to <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Exception.aspx" target="_blank" title="Auto generated link to System.Exception">System.Exception</a> or another type (<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Web.Services.Protocols.SoapException.aspx" target="_blank" title="Auto generated link to System.Web.Services.Protocols.SoapException">System.Web.Services.Protocols.SoapException</a>):
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">In &ldquo;Exception Object Type&rdquo; property select: &lt;.NET Exception&hellip;&gt;</span>
</li><li><span style="font-family:Tahoma; font-size:small">In Artifact Type windows, select <a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Exception.aspx" target="_blank" title="Auto generated link to System.Exception">System.Exception</a></span>
</li></ul>
<p style="text-align:center"><a rel="WLPP;url=http://sandroaspbiztalkblog.files.wordpress.com/2009/10/system-exception.jpg?w=270" href="http://sandroaspbiztalkblog.files.wordpress.com/2009/10/system-exception.jpg?w=270"><img class="aligncenter" src="-system-exception.jpg?w=270" alt=""></a></p>
<p><span style="font-family:Tahoma; font-size:small">By selecting another type, you are able to define &ldquo;Exception Object Name&rdquo;, in this case, &ldquo;ex&rdquo;, and then for getting the error message is just like C#: &ldquo;ex.Message&rdquo; or &ldquo;ex.ToString()&rdquo;.
</span></p>
<p><span style="font-family:Tahoma; font-size:small">See sample 1.<br>
</span></p>
<p><span style="font-size:20px; font-weight:bold">Handling Delivery Failure Exception (using a request-response port)<br>
</span></p>
<p><span style="font-family:Tahoma; font-size:small">There is a great </span><a href="http://www.codeproject.com/KB/biztalk/ExceptionDemo.aspx"><span style="font-family:Tahoma; font-size:small">post</span></a><span style="font-family:Tahoma; font-size:small">
 by Naveen Karamchetti about this; this is the key steps&hellip; </span></p>
<p><span style="font-family:Tahoma; font-size:small">In order to catch an exception within your scope block in BizTalk while using a request-response port, you might have to do the following:
</span></p>
<ul>
<li><span style="font-family:Tahoma; font-size:small">Set the retry-count to 0 on your physical request-response port which you use to bind.</span>
</li><li><span style="font-family:Tahoma; font-size:small">Enable the flag Delivery Notification to &lsquo;Transmitted&rsquo; on your logical request-response port within the orchestration.</span>
</li><li><span style="font-family:Tahoma; font-size:small">Catch the &ldquo;Microsoft.XLANGs.BaseTypes.DeliveryFailureException&rdquo; exception and handle it has you please.</span>
</li></ul>
<p><span style="font-family:Tahoma; font-size:small">The Delivery Notification flag on the Send Port indicates that the orchestration must be NOTIFIED back, in case the message has not been received by the destination. Delivery Notification works only when
 the Retry Count set to 0. When a message cannot be delivered, a Delivery Failure Exception is raised and the exception needs to be handled by the Orchestration.
</span></p>
<h1>Handling SOAP Exception</h1>
<p><span style="font-family:Tahoma; font-size:small">Similar to Delivery Failure, but in this case, we have to configure the Exception with &ldquo;System.Web.Services.Protocols.SoapException&rdquo;.
</span></p>
<p><span style="font-family:Tahoma; font-size:small">Note: remember to set the retry-count to 0.
</span></p>
<p><span style="font-family:Tahoma; font-size:small">To get an error message, just: &ldquo;ex.Detail.InnerText&rdquo;
</span></p>
<p><span style="font-family:Tahoma; font-size:small">See sample 2.</span></p>
<h1>About Me</h1>
<p><strong>Sandro Pereira</strong><br>
<a href="http://www.devscope.net/">DevScope</a>&nbsp;| MVP &amp; MCTS BizTalk Server 2010<br>
<a href="http://sandroaspbiztalkblog.wordpress.com/">http://sandroaspbiztalkblog.wordpress.com/</a>&nbsp;|&nbsp;<a href="http://twitter.com/sandro_asp">@sandro_asp</a></p>
<p><a href="http://www.devscope.net/"><img id="129835" src="129835-devscope-monochrome-black.png" alt="" width="166" height="51"></a></p>
<p><span style="font-family:Tahoma; font-size:small"><br>
</span></p>
