# JSON Parsing Sample in Xamarin.Forms (C# - Xaml)
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- Xamarin
- Xamarin.Forms
## Topics
- JSON parsing in Xamarin.Forms
## Updated
- 04/17/2017
## Description

<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Introduction:</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small"><a href="http://bsubramanyamraju.blogspot.in/2017/04/xamarinforms-consuming-rest-webserivce.html">Previously&nbsp;</a>we learned XML parsing in Xamarin.Forms. And this article demonstrates how
 to consume a RESTful web service and how to parse the JSON response from a Xamarin.Forms application.</span></p>
<p><span style="color:#ff0000"><strong><span style="font-family:verdana,sans-serif; font-size:small">You can also read this article from my original blog
<a title="MyBlog" href="http://bsubramanyamraju.blogspot.in/2017/04/xamarinforms-consuming-rest-webserivce_17.html" target="_blank">
here</a>.</span></strong></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-nskxSyxc198/WPSyd9TlbHI/AAAAAAAADO4/TA6xY-hQUkA7LLiP71vY3COORC9wdNVZQCLcB/s1600/JSONSampleScreen.jpg"><img src=":-jsonsamplescreen.jpg" border="0" alt="" width="640" height="380"></a></span></p>
<p>&nbsp;</p>
<p class="separator"><strong style="font-size:small">Requirements:</strong></p>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article source code is prepared by using Visual Studio 2017 Enterprise. And it is better to install latest visual studio updates from&nbsp;<a href="https://www.visualstudio.com/downloads/">here</a>.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This article is prepared on a Windows 10 machine.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This sample project is Xamarin.Forms PCL project.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">This sample app is targeted for Android, iOS &amp; Windows 10 UWP. And tested for Android &amp; UWP only. Hope this sample source code would work for iOS as well.</span>
</li></ul>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Description:</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">This article can explain you below topics:</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1. How to create Xamarin.Forms PCL project with Visual studio 2017?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">2. How to check network status from Xamarin.Forms app?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">3. How to consuming webservice&nbsp;from Xamarin.Forms?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">4. How to parse JSON string?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">5. How to bind JSON response to ListView?</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Let's learn how to use Visual Studio 2017 to&nbsp;create Xamarin.Forms project.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>1. How to create Xamarin.Forms PCL project with Visual studio 2017?</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Before to consume webservice, first we need to create the new project.&nbsp;</span></p>
</div>
<div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">Launch Visual Studio 2017/2015.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">On the File menu, select New &gt; Project.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">The New Project dialog appears. The left pane of the dialog lets you select the type of templates to display. In the left pane, expand&nbsp;<strong>Installed&nbsp;</strong>&gt;&nbsp;<strong>Templates&nbsp;</strong>&gt;&nbsp;<strong>Visual
 C#</strong>&nbsp;&gt;&nbsp;<strong>Cross-Platform</strong>. The dialog's center pane displays a list of project templates for Xamarin cross platform apps.</span>
</li><li><span style="font-family:verdana,sans-serif; font-size:small">In the center pane, select the Cross Platform App (Xamarin.Forms or Native) template.&nbsp;In the Name text box, type &quot;RestDemo&quot;. Click OK to create the project.
<p class="separator"><a href="https://3.bp.blogspot.com/-pZyeveTtr5M/WPOA9dlKmbI/AAAAAAAADK4/BoIiYokrxhEnZ7ehTc74A5WUg0Srml5XACLcB/s1600/RestDemo.PNG"><img src=":-restdemo.png" border="0" alt="" width="640" height="390"></a></p>
<p class="separator">And in next dialog, select Blank App=&gt;Xamarin.Forms=&gt;PCL.The selected App template creates a minimal mobile app that compiles and runs but contains no user interface controls or data. You add controls to the app over the course
 of this tutorial.</p>
</span></li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://4.bp.blogspot.com/-s_hyRg8XJIk/WPOB5upXjBI/AAAAAAAADLE/-a2NZ_I8ZmAUBWW9RRIm2AZ4Wefy_QUDACLcB/s1600/RestDemo2.PNG"><img src=":-restdemo2.png" border="0" alt="" width="640" height="350"></a></span></p>
</li><li>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Next dialog will ask for you to confirm that your UWP app support min &amp; target versions. For this sample, I target the app with minimum version 10.0.10240 like below:</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://2.bp.blogspot.com/-9V31M3qBhKY/WPODrp0VAYI/AAAAAAAADLQ/iNRmZu_ALI0g7bqlpAUOPjMo2pxN9S61QCLcB/s1600/2.UWPTargetVersion.PNG"><img src=":-2.uwptargetversion.png" border="0" alt=""></a></span></p>
</li></ul>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>2. How to check network status from Xamarin.Forms app?</strong></span></p>
</div>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Before call webservice, first we need to check internet connectivity of a device, which can be either mobile data or Wi-Fi. In Xamarin.Forms, we are creating cross platform apps, so the different
 platforms have different implementations.&nbsp;</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">So to check the internet connection in Xamarin.Forms app, we need to follow the steps given below.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>Step 1:</strong></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Go to solution explorer and right click on your solution=&gt;Manage NuGet Packages for solution.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-1h7KogxhiYI/WPOHOXIZ8tI/AAAAAAAADLg/82sUUgL6Kc4FIeVKcMizaUuHhm5uycC9QCLcB/s1600/Nuget.PNG"><img src=":-nuget.png" border="0" alt="" width="640" height="498"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Now search for&nbsp;</span><strong style="font-family:verdana,sans-serif; font-size:small">Xam.Plugin.Connectivity</strong><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;NuGet
 package. On the right side, make sure select all platform projects&nbsp;and install it.</span><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://1.bp.blogspot.com/-05PDB_TLAME/WPOHCfHY-MI/AAAAAAAADLc/pX4cTPcWSQMvjHV6YqUzrsDVPdFdfgVmQCLcB/s1600/Xam.Plugin.Connectivity.PNG"><img src=":-xam.plugin.connectivity.png" border="0" alt="" width="640" height="220"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><strong>Step 2:</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">In Android platform, you have to allow the user permission to check internet connectivity. For this, use the steps given below.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Right click on&nbsp;<strong>RestDemo.Android</strong>&nbsp;Project and select Properties =&gt; Android Manifest option. Select ACCESS_NETWORK_STATE and INTERNET permission under Required permissions.</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><span style="font-family:verdana,sans-serif">&nbsp;</span><br>
</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/-NcOCdkpY7pw/WPOKXm9teRI/AAAAAAAADLs/_UYnRdjDJpYguWeEt4-NKOXCVwSNc2_KACLcB/s1600/AndroidManifest.PNG"><img src=":-androidmanifest.png" border="0" alt="" width="640" height="532"></a></span></p>
<p><strong style="font-family:verdana,sans-serif; font-size:small">Step 3:</strong></p>
<div>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Create a class name &quot;NetworkCheck.cs&quot;, and here I placed it in the&nbsp;Model&nbsp;folder. After creating a class, add below method to find network status.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;RestDemo.Model&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;NetworkCheck&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;IsInternet()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(CrossConnectivity.Current.IsConnected)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;write&nbsp;your&nbsp;code&nbsp;if&nbsp;there&nbsp;is&nbsp;no&nbsp;Internet&nbsp;available&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>3. How to consuming&nbsp;webservice&nbsp;from Xamarin.Forms?</strong>&nbsp;</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">We can consume webservice&nbsp;in Xamarin using&nbsp;HttpClient. But it is not directly available, and so we need to add &quot;<strong>Microsoft.Net.Http</strong>&quot; from Nuget.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span><strong style="font-family:verdana,sans-serif; font-size:small">Step 1:&nbsp;</strong><span style="font-family:verdana,sans-serif; font-size:small">Go to solution
 explorer and right click on your solution=&gt;Manage NuGet Packages for a solution =&gt; search for&nbsp;</span><strong style="font-family:verdana,sans-serif; font-size:small">Microsoft.Net.Http</strong><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;NuGet
 Package=&gt;on the right side, make sure select all platform projects&nbsp;and install it.</span></p>
<span style="font-family:verdana,sans-serif; font-size:small"><span style="font-family:verdana,sans-serif">
<p class="separator"><a href="https://4.bp.blogspot.com/-UafKBM4cYhk/WPOOthksRoI/AAAAAAAADL4/TD5xK8Imr9o623r84Kd7E_qkiNNlJy5yQCLcB/s1600/Microsoft.Net.Http.PNG"><img src=":-microsoft.net.http.png" border="0" alt="" width="640" height="220"></a></p>
<p class="separator"><strong>Note:&nbsp;</strong>To add &quot;<strong>Microsoft.Net.Http</strong>&quot;, you must install &quot;Microsoft.Bcl.Build&quot; from Nuget. Otherwise, you will get an error like &quot;Could not install package 'Microsoft.Bcl.Build 1.0.14'. You are trying
 to install this package into a project that targets 'Xamarin.iOS,Version=v1.0', but the package does not contain any assembly references or content files that are compatible with that framework.&quot;</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-H5O_tqwYU2A/WPOPsrknnXI/AAAAAAAADME/7MuwzS6ZKIEUCTq758K5i7cNh_XgvaAoACLcB/s1600/Microsoft.Bcl.Build.PNG"><img src=":-microsoft.bcl.build.png" border="0" alt="" width="640" height="218"></a></p>
<p class="separator"><strong>Step 2:</strong></p>
<p class="separator">Now it is time to use HttpClient for consuming&nbsp;webservice&nbsp;and before that we need to check the network connection. Please note that In below code you need to replace your&nbsp;URL, or you can also find the demo webservice url
 from the source code given below about this article.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;GetJSON()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;network&nbsp;status&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NetworkCheck.IsInternet())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.HttpClient.aspx" target="_blank" title="Auto generated link to System.Net.Http.HttpClient">System.Net.Http.HttpClient</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(<span class="cs__string">&quot;REPLACE&nbsp;YOUR&nbsp;JSON&nbsp;URL&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;contactsJson&nbsp;=&nbsp;response.Content.ReadAsStringAsync().Result;&nbsp;<span class="cs__com">//Getting&nbsp;response&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>4. How to parse JSON response string in Xamarin.Forms?</strong></div>
<p>&nbsp;</p>
<p class="separator">Generally, we will get a response from webservice in the form of XML/JSON. And we need to parse them to show them on mobile app UI. Let's assume, in the above code we will get below sample JSON response which is having a&nbsp;list of
 contacts.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="xml">{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&quot;contacts&quot;:&nbsp;[{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;id&quot;:&nbsp;&quot;c200&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;name&quot;:&nbsp;&quot;Ravi&nbsp;Tamada&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;email&quot;:&nbsp;&quot;ravi@gmail.com&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;address&quot;:&nbsp;&quot;xx-xx-xxxx,x&nbsp;-&nbsp;street,&nbsp;x&nbsp;-&nbsp;country&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;gender&quot;:&nbsp;&quot;male&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;phone&quot;:&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;mobile&quot;:&nbsp;&quot;&#43;91&nbsp;0000000000&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;home&quot;:&nbsp;&quot;00&nbsp;000000&quot;,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&quot;office&quot;:&nbsp;&quot;00&nbsp;000000&quot;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}]&nbsp;&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;So to parse above JSON, we need to follow steps below:</div>
<p>&nbsp;</p>
</span>
<p class="separator"><span style="font-family:verdana,sans-serif"><strong>Step 1:</strong>&nbsp;First we need to generate the C#.net class for JSON response string. So I am using&nbsp;<a href="http://json2csharp.com/">http://json2csharp.com/</a>&nbsp;for
 simply building a C# class from a JSON string. And it's very important is to make the class members as similar to JSON objects otherwise you will never parse JSON properly. Finally, I generate below the C# root class name is &quot;ContactList&quot;.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.Tasks.aspx" target="_blank" title="Auto generated link to System.Threading.Tasks">System.Threading.Tasks</a>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RestDemo.Model&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Phone&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;mobile&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;home&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;office&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Contact&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;email&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;address&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;gender&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Phone&nbsp;phone&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;ContactList&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;List&lt;Contact&gt;&nbsp;contacts&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>Step 2:&nbsp;</strong>In Xamarin, we need to add &quot;<strong>Newtonsoft.Json</strong>&quot; Nuget package to parse JSON string. So to add&nbsp;Newtonsoft.Json, go to solution explorer and right click on your solution=&gt;select&nbsp;<strong>Manage
 NuGet Packages for a solution</strong>&nbsp;=&gt; search for Newtonsoft.Json&nbsp;NuGet Package=&gt;on the right side, make sure select all platform projects and install it.</div>
</span>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif"><a href="https://1.bp.blogspot.com/-ZERA0_wJxUo/WPStXK0D7wI/AAAAAAAADOo/EO90iHpHnW8HRgjy_lVemhnvvM0aK0oPwCLcB/s1600/Newtonsoft.PNG"><img src=":-newtonsoft.png" border="0" alt="" width="640" height="222"></a></span></p>
<br>
<p class="separator"><span style="font-family:verdana,sans-serif"><strong>Step 3:&nbsp;</strong>And finally, write below code to parse above JSON response.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;async&nbsp;<span class="cs__keyword">void</span>&nbsp;GetJSON()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Check&nbsp;network&nbsp;status&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NetworkCheck.IsInternet())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Net.Http.HttpClient.aspx" target="_blank" title="Auto generated link to System.Net.Http.HttpClient">System.Net.Http.HttpClient</a>();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(<span class="cs__string">&quot;REPLACE&nbsp;YOUR&nbsp;JSON&nbsp;URL&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;contactsJson&nbsp;=&nbsp;response.Content.ReadAsStringAsync().Result;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ContactList&nbsp;ObjContactList&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ContactList();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contactsJson&nbsp;!=&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Converting&nbsp;JSON&nbsp;Array&nbsp;Objects&nbsp;into&nbsp;generic&nbsp;list&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObjContactList&nbsp;=&nbsp;JsonConvert.DeserializeObject&lt;ContactList&gt;(contacts);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Binding&nbsp;listview&nbsp;with&nbsp;server&nbsp;response&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listviewConacts.ItemsSource&nbsp;=&nbsp;ObjContactList.contacts;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;DisplayAlert(<span class="cs__string">&quot;JSONParsing&quot;</span>,&nbsp;<span class="cs__string">&quot;No&nbsp;network&nbsp;is&nbsp;available.&quot;</span>,&nbsp;<span class="cs__string">&quot;Ok&quot;</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Hide&nbsp;loader&nbsp;after&nbsp;server&nbsp;response&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ProgressLoader.IsVisible&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>5. How to bind JSON&nbsp;response to ListView?</strong></div>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif">Generally, it is very common scenario is showing a list of items in ListView from the server response.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif">&nbsp;</span>Let's assume we have below&nbsp;JSON&nbsp;response from the server via webservice.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;contacts&quot;</span>:&nbsp;[<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;id&quot;</span>:&nbsp;<span class="js__string">&quot;c200&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;name&quot;</span>:&nbsp;<span class="js__string">&quot;Ravi&nbsp;Tamada&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;email&quot;</span>:&nbsp;<span class="js__string">&quot;ravi@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;address&quot;</span>:&nbsp;<span class="js__string">&quot;xx-xx-xxxx,x&nbsp;-&nbsp;street,&nbsp;x&nbsp;-&nbsp;country&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;gender&quot;</span>:&nbsp;<span class="js__string">&quot;male&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;phone&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;mobile&quot;</span>:&nbsp;<span class="js__string">&quot;&#43;91&nbsp;0000000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;home&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;office&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;id&quot;</span>:&nbsp;<span class="js__string">&quot;c201&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;name&quot;</span>:&nbsp;<span class="js__string">&quot;Johnny&nbsp;Depp&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;email&quot;</span>:&nbsp;<span class="js__string">&quot;johnny_depp@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;address&quot;</span>:&nbsp;<span class="js__string">&quot;xx-xx-xxxx,x&nbsp;-&nbsp;street,&nbsp;x&nbsp;-&nbsp;country&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;gender&quot;</span>:&nbsp;<span class="js__string">&quot;male&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;phone&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;mobile&quot;</span>:&nbsp;<span class="js__string">&quot;&#43;91&nbsp;0000000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;home&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;office&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;id&quot;</span>:&nbsp;<span class="js__string">&quot;c202&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;name&quot;</span>:&nbsp;<span class="js__string">&quot;Leonardo&nbsp;Dicaprio&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;email&quot;</span>:&nbsp;<span class="js__string">&quot;leonardo_dicaprio@gmail.com&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;address&quot;</span>:&nbsp;<span class="js__string">&quot;xx-xx-xxxx,x&nbsp;-&nbsp;street,&nbsp;x&nbsp;-&nbsp;country&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;gender&quot;</span>:&nbsp;<span class="js__string">&quot;male&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;phone&quot;</span>:&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;mobile&quot;</span>:&nbsp;<span class="js__string">&quot;&#43;91&nbsp;0000000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;home&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;office&quot;</span>:&nbsp;<span class="js__string">&quot;00&nbsp;000000&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;]&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">See there is 3 different items in above JSON response and if we want to plan for showing them in ListView first we need to add below Xaml code in your ContentPage(<strong>JsonParsingPage.xaml</strong>).
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;utf-8&quot;</span>&nbsp;<span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;RestDemo.Views.JsonParsingPage&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;10&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;JSON&nbsp;Parsing&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;listviewConacts&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">HasUnevenRows</span>=<span class="xaml__attr_value">&quot;True&quot;</span>&nbsp;<span class="xaml__attr_name">ItemSelected</span>=<span class="xaml__attr_value">&quot;listviewContacts_ItemSelected&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ViewCell</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;10&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;name}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;email}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Orange&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;phone.mobile}&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;StartAndExpand&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">FontAttributes</span>=<span class="xaml__attr_value">&quot;Bold&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;BoxView</span>&nbsp;<span class="xaml__attr_name">HeightRequest</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0,10,10,0&quot;</span>&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ViewCell&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ActivityIndicator</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ProgressLoader&quot;</span>&nbsp;<span class="xaml__attr_name">IsRunning</span>=<span class="xaml__attr_value">&quot;True&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-family:verdana,sans-serif">See in above code there is a ListView which was binded with relevant properties (name, email, mobile) which was mentioned in our class name called&nbsp;</span><span style="font-family:verdana,sans-serif"><strong>Contact.cs</strong>.</span></div>
</div>
<p>&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif">Finally, we need to bind our ListView with list like below:(</span><strong>Please find which was already mentioned in the 4th section of GetXML method at 17th line</strong><span style="font-family:verdana,sans-serif">)</span></p>
<ol class="dp-c">
<li><span style="color:#000000">&nbsp;<span class="comment" style="color:#008200">//Binding&nbsp;listview&nbsp;with&nbsp;server&nbsp;response&nbsp;&nbsp;</span>&nbsp;&nbsp;</span>
</li><li class="alt"><span style="color:#000000">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;listviewConacts.ItemsSource&nbsp;=&nbsp;ObjContactList.contacts; &nbsp;</span>&nbsp;
</li></ol>
<p class="separator"><span style="font-family:verdana,sans-serif"><strong><span style="text-decoration:underline">Demo Screens from Android:</span></strong></span>&nbsp;</p>
<span style="font-family:verdana,sans-serif">
<p class="separator"><a href="https://4.bp.blogspot.com/-8ml5LqsSCsI/WPSeJUaW7uI/AAAAAAAADN4/t5ukytLbrn8rkkCWcg24-w3Xsss5YheLgCEw/s1600/AndroidJSONScreen.PNG"><img src=":-androidjsonscreen.png" border="0" alt=""></a></p>
<p class="separator">&nbsp;</p>
<p class="separator"><a href="https://1.bp.blogspot.com/-cBsm38-puM0/WPShDY_EC1I/AAAAAAAADOU/v-ZZ_eekskAczYPbd21VCEe4YmdCuc8bwCLcB/s1600/AndroidJSONScreen2.PNG"><img src=":-androidjsonscreen2.png" border="0" alt=""></a></p>
<p class="separator">&nbsp;</p>
<p class="separator"><strong><span style="text-decoration:underline"><span style="font-family:verdana,sans-serif">Demo Screens from Windows10 UWP:</span></span></strong></p>
<p class="separator"><strong><span style="text-decoration:underline"><a href="https://4.bp.blogspot.com/-bOAgmVfckQI/WPSeMmNk-5I/AAAAAAAADOA/AAFhVkc_cpoAiGSoSf3HU18dDhuRZDcHACEw/s1600/UWPScreen.PNG"><img src=":-uwpscreen.png" border="0" alt="" width="640" height="505"></a></span></strong></p>
<p class="separator"><strong><br>
</strong></p>
<p class="separator"><a href="https://4.bp.blogspot.com/-MLMJLLBs5dw/WPShE4CeG3I/AAAAAAAADOY/tx6-HCeE6F8p1LKTxIsNvuYXPzXoQ9PVwCLcB/s1600/UWPScreen2.PNG"><img src=":-uwpscreen2.png" border="0" alt="" width="640" height="504"></a></p>
<p class="separator"><span style="color:#ff0000"><strong><strong>You can also read this article from my original blog&nbsp;<a title="MyBlog" href="http://bsubramanyamraju.blogspot.in/2017/04/xamarinforms-consuming-rest-webserivce_17.html" target="_blank">here</a>.</strong></strong></span></p>
<p class="separator"><strong><strong><span>&nbsp;</span></strong>FeedBack Note:</strong>&nbsp;Please share your thoughts, what you think about this post, Is this post really helpful for you? Otherwise, it would be very happy, if you have any thoughts for
 to implement this requirement in any other way? I always welcome if you drop comments on this post and it would be impressive.</p>
<div>
<p><span style="font-family:verdana,sans-serif">Follow me always at&nbsp;<a href="https://twitter.com/Subramanyam_B">@Subramanyam_B</a></span></p>
<p><span style="font-family:verdana,sans-serif">Have a nice day by<span style="color:#000000">&nbsp;</span><a rel="author" href="http://bsubramanyamraju.blogspot.in/p/about-me.html">Subramanyam Raju</a><span style="color:#000000">&nbsp;:)</span></span></p>
</div>
</span></div>
</div>
