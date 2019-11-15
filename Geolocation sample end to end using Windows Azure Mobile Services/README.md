# Geolocation sample end to end using Windows Azure Mobile Services
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Microsoft Azure
- Windows RT
- Windows Azure Mobile Services
- Windows Store app
- Geolocator
## Topics
- Microsoft Azure
- Location
- Geolocation
- Windows RT
- Windows Azure Mobile Services
- Windows Store app
- Geolocator
## Updated
- 05/01/2014
## Description

<div class="content">
<h1 id="My_Places_Sample">My Places: Geolocation sample end to end using Windows Azure Mobile Services&nbsp;</h1>
<h3 id="Introduction">Introduction</h3>
<p>This sample provides and end to end location scenario with a Windows Store app using Bing Maps and a
<strong>Windows Azure Mobile Services </strong>backend. It shows how to add places to the Map, store place coordinates in a Mobile Services table, and how to query for places near your current&nbsp;location.</p>
<p><img id="74255" width="640" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/74255/1/my-places-search-radius.png" alt="" height="400"></p>
<h3 id="Prerequisites">Prerequisites</h3>
<ul>
<li>Visual Studio 2013 Express for Windows or higher </li><li><a href="http://go.microsoft.com/fwlink/?LinkID=322092">Bing Maps for Windows 8.1 Store apps</a>
</li><li>A Windows Azure Account&nbsp;<span style="font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13px">- get the&nbsp;</span><a title="Windows Azure Free" href="http://www.windowsazure.com/en-us/pricing/free-trial/?WT.mc_id=AA0EDCEAF" target="_blank" style="color:#960bb4; text-decoration:none; font-family:'Segoe UI','Lucida Grande',Verdana,Arial,Helvetica,sans-serif; font-size:13px">Windows
 Azure Free Trial</a> </li></ul>
<h3 id="Building_the_Sample"><span style="font-size:1.17em">Building the Sample</span></h3>
<p>Follow these steps to set up the sample.</p>
<ol>
<li>
<p>First, you need to install <strong>Bing Maps for Windows Store apps</strong> for
<strong>Visual Studio 2013</strong>. To do this, open <strong>Visual Studio 2013</strong>, go to
<strong>Tools</strong> and select <strong>Extensions and Updates</strong>.</p>
</li><li>
<p>Make sure the option <strong>Online</strong> is selected in the left panel. Search for
<strong>Bing Maps SDK for Windows 8.1 Store apps</strong> and install it. If asked, restart Visual Studio.</p>
</li><li>
<p>Now, you need to register and retrieve a <strong>Bing Maps</strong> key in order to use it in your application. For more information, go to
<a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">http://msdn.microsoft.com/en-us/library/ff428642.aspx</a>. Make note of your Bing Maps account key.</p>
</li><li>
<p>Create a new <strong>Mobile Service</strong> from the Windows Azure Management Portal.</p>
<p>To do this, log in to the <a href="https://manage.windowsazure.com">Windows Azure Management Portal</a>, navigate to Mobile Services and click
<strong>New</strong>.</p>
<p><img id="106775" width="133" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106775/1/new-button.png" alt="New Button" height="57"></p>
<p>Expand <strong>Compute | Mobile Service</strong>, then click <strong>Create</strong>.</p>
<p>In the <strong>Create a Mobile Service</strong> page, type a subdomain name for the new mobile service in the
<strong>URL</strong> textbox (e.g. <em>myplacesservice</em>) and wait for name verification. Once name verification completes, select
<em>Create a new SQL Database</em> in the <strong>Database</strong> dropdown list and click the right arrow button to go to the next page.</p>
<p><img id="106776" width="680" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106776/1/create-new-mobile-service.png" alt="Create new Mobile Service" height="450"></p>
<p>This displays the <strong>Specify database settings</strong> page.</p>
<blockquote>
<p><strong>Note:</strong> As part of this sample, you create a new SQL database instance and server. You can reuse this new database and administer it as you would with any other SQL database instance. If you already have a database in the same region as the
 new mobile service, you can instead choose <em>Use existing Database</em> and then select that database. The use of a database in a different region is not recommended because of additional bandwidth costs and higher latencies.</p>
</blockquote>
<p>In <strong>Name</strong>, type the name of the new database, then type <strong>
Login Name</strong>, which is the administrator login name for the new SQL database server, type and confirm the password, and click the check button to complete the process.</p>
<p><img id="106777" width="680" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106777/1/new-mobile-service-step-2.png" alt="New Mobile Service step 2" height="450"></p>
<p>You have now created a new mobile service that can be used by your mobile apps.</p>
</li><li>
<p>Connect the Windows 8 app to Mobile Services.</p>
<p>Get the <strong>Mobile Service URL</strong> and <strong>Mobile Service Key</strong> values. Browse to your Mobile Service dashboard, copy the service URL and click
<strong>Manage Keys</strong> on the bottom bar.</p>
<p><img id="106778" width="271" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106778/1/mobile-service-settings-dashboard.png" alt="Mobile Service URL" height="249"></p>
<p><em>Mobile Service URL</em></p>
<p>Now copy the <strong>Application Key</strong> value.</p>
<p><img id="106779" width="500" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106779/1/mobile-service-settings-keys.png" alt="Mobile Services Access Key" height="350"></p>
</li><li>
<p>In Visual Studio, open the <strong>Windows Store</strong> app provided in this sample and open the
<strong>App.xaml.cs</strong> file in the solution. Replace the placeholders <strong>
{mobile-service-name}</strong> and <strong>{mobile-service-key}</strong> with the values obtained in the previous steps.</p>
&lt;!-- mark:2-3 --&gt; <span class="codelanguage">&nbsp;</span>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;static&nbsp;MobileServiceClient&nbsp;mobileService&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;MobileServiceClient(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;https://{mobile-service-name}.azure-mobile.net/&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;{mobile-service-key}&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li><li>
<p>In <strong>Server Explorer</strong>, right click on the <strong>Windows Azure</strong> node and select
<strong>Import Subscription...</strong>.</p>
<p><img title="Import Subscription Menu" id="106780" width="383" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106780/1/import-subscription-menu.png" alt="Import Subscription Menu" height="262"></p>
</li><li>
<p>Click on <strong>Download subscription file</strong>, log in to your Windows Azure account (if required) and click Save when your browser requests to save the file.</p>
<p><img title="Download Subscription File" id="106781" width="550" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106781/1/import-subscription-download.png" alt="Download Subscription File" height="206"></p>
<blockquote>
<p><strong>Note:</strong> The login window is displayed in the browser, which may be behind your Visual Studio window. Remember to make a note of where you saved the downloaded .publishsettings file.</p>
</blockquote>
</li><li>
<p>Click <strong>Browse</strong>, navigate to the location where you saved the .publishsettings file, select the file, then click
<strong>Open</strong> and then <strong>Import</strong>. Visual Studio imports the data needed to connect to your Windows Azure subscription.</p>
<p><img title="Import Subscription" id="106782" width="550" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106782/1/import-subscription-import.png" alt="Import Subscription" height="206"></p>
<blockquote>
<p><strong>Security Note:</strong> After importing the publish settings, consider deleting the downloaded .publishsettings file as it contains information that can be used by others to access your account. Secure the file if you plan to keep it for use in other
 connected app projects.</p>
</blockquote>
</li><li>
<p>Expand <strong>Mobile Services</strong> under <strong>Windows Azure</strong>, right-click your mobile service and select
<strong>Create Table</strong>. Create a new table named <strong>Place</strong> and set the permissions for Insert, Update, Delete, and Read to
<strong>&quot;Anybody with the application key&quot;</strong>.</p>
<p><img id="106783" width="500" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106783/1/create-place-table.png" alt="Create Place Table" height="484"></p>
</li><li>
<p>Once the table is created, you need to modify it to support a geography data type. To do this, go back to the Management Portal, go to the SQL Server you created for the Mobile Service and select
<strong>Manage</strong>.</p>
<p><img id="106784" width="236" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106784/1/managing-your-sql-server-database.png" alt="Managing your SQL Server database" height="60"></p>
<p><em>Managing your SQL Server database</em></p>
</li><li>
<p>If prompted to update the firewall rules to include the IP address of your computer, click
<strong>Yes</strong>.</p>
</li><li>
<p>Log in to the SQL Database Management Portal using your SQL Server credentials. Make sure the database for your Mobile Services is selected on the left panel and go to
<strong>Design</strong>.</p>
<p><img id="106785" width="223" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106785/1/designing-your-database.png" alt="Designing your database" height="162"></p>
<p><em>Designing your database</em></p>
</li><li>
<p>Select the <strong>Place</strong> table and click <strong>Edit</strong>.</p>
<p><img id="106786" width="633" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106786/1/editing-the-place-table.png" alt="Editing the Place table" height="243"></p>
<p><em>Editing the Place table</em></p>
</li><li>
<p>Add the following columns to the table: <strong>title</strong> as <strong>nvarchar(50)</strong> (mark it as required),
<strong>description</strong> as <strong>nvarchar(max)</strong> and <strong>location</strong> as
<strong>geography</strong> (mark it as required). The <strong>location</strong> column will store the coordinates of the different places that will be shown in the Windows Store app. Click
<strong>Save</strong> to finish the updates.</p>
<p><img id="106787" width="812" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106787/1/updating-table-definition.png" alt="Updating table definition" height="462"></p>
<p><em>Updating table definition</em></p>
</li><li>
<p>Now that your table is updated, go back to the Visual Studio. In Server Explorer, expand the
<strong>Place</strong> table under your mobile service. Then, right-click the <strong>
insert.js</strong> script file and select <strong>Edit script</strong>.</p>
</li><li>
<p>The script opens in an editor window. Replace the script contents with the following code and press
<strong>CTRL&#43;S</strong> to save the script.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__operator">function</span>&nbsp;insert(item,&nbsp;user,&nbsp;request)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;queryString&nbsp;=&nbsp;<span class="js__string">&quot;INSERT&nbsp;INTO&nbsp;Place&nbsp;(title,&nbsp;description,&nbsp;location)&nbsp;VALUES&nbsp;(?,&nbsp;?,&nbsp;geography::STPointFromText('POINT('&nbsp;&#43;&nbsp;?&nbsp;&#43;&nbsp;'&nbsp;'&nbsp;&#43;&nbsp;?&nbsp;&#43;&nbsp;')',&nbsp;4326))&quot;</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;mssql.query(queryString,&nbsp;[item.title,&nbsp;item.description,&nbsp;item.longitude.toString(),&nbsp;item.latitude.toString()],&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.respond(statusCodes.OK,&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>This script parses the latitude and longitude values and creates a SQL Server geography instance. In order to do this, you need to execute a custom query using the
<strong>mssql</strong> object. For more information about <strong>mssql</strong> go to
<a href="http://msdn.microsoft.com/en-us/library/windowsazure/jj554212.aspx">http://msdn.microsoft.com/en-us/library/windowsazure/jj554212.aspx</a>.</p>
</li><li>
<p>You will now create a custom API script to retrieve the places for a given origin and within a certain radius.</p>
<blockquote>
<p><strong>Note:</strong> A custom API is an endpoint in your mobile service that is accessed by one or more of the standard HTTP methods: GET, POST, PUT, PATCH, DELETE. Custom API enables you to expose server functionality that does not map to an insert, update,
 delete, or read operation or as a scheduled job.</p>
</blockquote>
<p>Go to the Management Portal, and select your mobile service. Under the <strong>
API</strong> tab, click <strong>Create Custom API</strong>.</p>
<p><img id="106788" width="740" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106788/1/create-custom-api.png" alt="Create custom API" height="160"></p>
<p><em>Create custom API</em></p>
<p>In the enter <strong>places</strong> in the API Name field, and make sure all permission levels are set to
<strong>Anybody with the Application Key</strong>. Click the check mark to continue.</p>
<p><img id="106789" width="650" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106789/1/custom-api-configuration.png" alt="Custom API configuration" height="560"></p>
<p><em>Custom API options</em></p>
</li><li>
<p>Select the custom API you just created and replace the script with the following code.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">exports.get&nbsp;=&nbsp;<span class="js__operator">function</span>(request,&nbsp;response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;queryString&nbsp;=&nbsp;<span class="js__string">&quot;SELECT&nbsp;id,&nbsp;title,&nbsp;description,&nbsp;location.Lat&nbsp;latitude,&nbsp;location.Long&nbsp;longitude&nbsp;FROM&nbsp;Place&nbsp;WHERE&nbsp;location.STDistance(geography::STPointFromText('POINT('&nbsp;&#43;&nbsp;?&nbsp;&#43;&nbsp;'&nbsp;'&nbsp;&#43;&nbsp;?&nbsp;&#43;&nbsp;')',&nbsp;4326))&nbsp;&lt;=&nbsp;?&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.service.mssql.query(queryString,&nbsp;[request.query.longitude.toString(),&nbsp;request.query.latitude.toString(),&nbsp;request.query.distance],&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>(results)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;request.respond(statusCodes.OK,&nbsp;results);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="JavaScript">
</code></pre>
<p>This script performs a spatial query on the database to obtain the records in the
<strong>Place</strong> table for which the distance between their location and the origin point passed as a parameter is under the specified distance.</p>
<p>Finally, click <strong>Save</strong> to save the changes to the script.</p>
</li><li>
<p>Switch to Visual Studio and open <strong>Package.appxmanifest</strong>. Select the
<strong>Capabilities</strong> tab and check the <strong>Location</strong> option. Your application is now able to retrieve the current location of the device.</p>
<p><img id="106790" width="806" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106790/1/adding-location-capability-to-the-application.png" alt="Adding Location capability to the application manifest" height="476"></p>
<p><em>Adding Location capability to the application manifest</em></p>
</li><li>
<p>Open <strong>MainPage.xaml.cs</strong>, locate the <strong>LoadMap</strong> method and replace the placeholder with your Bing Maps account key.</p>
&lt;!-- mark:4 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;async&nbsp;<span class="js__operator">void</span>&nbsp;LoadMap()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.BingMap.RightTapped&nbsp;&#43;=&nbsp;<span class="js__operator">this</span>.BingMap_RightTapped;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.BingMap.Credentials&nbsp;=&nbsp;<span class="js__string">&quot;{enter-your-bing-maps-key-here}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.BingMap.MapType&nbsp;=&nbsp;Bing.Maps.MapType.Road;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;<span class="js__operator">this</span>.RefreshMap();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.DrawBuffer();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li><li>
<p>To retrieve the current location from the device, you need to instantiate a <strong>
Geolocator</strong> object which allows you to read the position using Latitude and Longitude coordinates. Locate the
<strong>GetCurrentPosition</strong> method and replace the body of the method with the following highlighted code.</p>
&lt;!-- mark:3-11 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;static&nbsp;async&nbsp;Task&lt;Position&gt;&nbsp;GetCurrentPosition()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;geolocator&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Windows.Devices.Geolocation.Geolocator();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;location&nbsp;=&nbsp;await&nbsp;geolocator.GetGeopositionAsync();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;position&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Position&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Latitude&nbsp;=&nbsp;location.Coordinate.Point.Position.Latitude,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Longitude&nbsp;=&nbsp;location.Coordinate.Point.Position.Longitude&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;position;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li><li>
<p>This sample uses your location and a radius buffer to filter the places that are around you. To do this, you will send the parameters to Mobile Services, which will execute the custom API you created previously. The API will return a list of places around
 your location which will be rendered in the map as pins. Go to the <strong>SpatialQueryFilter</strong> method and replace it with the following highlighted code.</p>
&lt;!-- mark:3-14 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;Task&nbsp;SpatialQueryFilter()&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(<span class="js__operator">this</span>.myLocation&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;filter&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Dictionary&lt;string,&nbsp;string&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filter.Add(<span class="js__string">&quot;latitude&quot;</span>,&nbsp;<span class="js__operator">this</span>.myLocation.Latitude.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filter.Add(<span class="js__string">&quot;longitude&quot;</span>,&nbsp;<span class="js__operator">this</span>.myLocation.Longitude.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filter.Add(<span class="js__string">&quot;distance&quot;</span>,&nbsp;(Convert.ToInt32(<span class="js__operator">this</span>.Radius.SelectedValue)&nbsp;*&nbsp;<span class="js__num">1000</span>).ToString());&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;jtoken&nbsp;=&nbsp;await&nbsp;App.MobileService.InvokeApiAsync(<span class="js__string">&quot;places&quot;</span>,&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Net.Http.HttpMethod.Get.aspx" target="_blank" title="Auto generated link to System.Net.Http.HttpMethod.Get">System.Net.Http.HttpMethod.Get</a>,&nbsp;filter);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;results&nbsp;=&nbsp;jtoken.ToObject&lt;List&lt;Place&gt;&gt;();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.AddPushPins(results);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li><li>
<p>To insert a new Place and save it to Mobile Services, open <strong>AddMyPlace.xaml.cs</strong> and replace the
<strong>InsertPlace</strong> method with the following highlighted code.</p>
&lt;!-- mark:3-11 --&gt;
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;Task&nbsp;InsertPlace()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;place&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Place()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title&nbsp;=&nbsp;<span class="js__operator">this</span>.TitleText.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Description&nbsp;=&nbsp;<span class="js__operator">this</span>.DescriptionText.Text,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Latitude&nbsp;=&nbsp;<span class="js__operator">this</span>.latitude,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Longitude&nbsp;=&nbsp;<span class="js__operator">this</span>.longitude&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;await&nbsp;App.MobileService.GetTable&lt;Place&gt;().InsertAsync(place);&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<pre><code class="C#">
</code></pre>
</li></ol>
<h3 id="Running_the_Sample">Running the Sample</h3>
<ol>
<li>
<p>In Visual Studio, press <strong>F5</strong> to run the application.</p>
<blockquote>
<p><strong>Note:</strong> If this is the first time you run the app, you may get an error message saying that the build restored the NuGet packages. If that is the case, run the app one more time to include those packages in the build (for more information,
 see <a href="http://go.microsoft.com/fwlink/?LinkID=317568">http://go.microsoft.com/fwlink/?LinkID=317568</a>).</p>
</blockquote>
</li><li>
<p>Once the app is running, it will ask permission to use you location. Click <strong>
Allow</strong> and the Bing Maps will be positioned on your location.</p>
</li><li>
<p>Press and hold (or right-click with the mouse) the map inside the radius circle around your location and fill the values in the displayed dialog box.</p>
<p><img id="106791" width="1280" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106791/1/my-places-add-a-place.png" alt="my-places-add-a-place" height="800"></p>
</li><li>
<p>When saved, the new place will be displayed on the map as a blue pin. You can click on it to display its information.</p>
<p><img id="106792" width="1919" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106792/1/my-places-radial-search-result.png" alt="my-places-radial-search-result" height="1199"></p>
</li><li>
<p>You can play around with the radius filter options and continue adding places.</p>
<p><img id="106793" width="1280" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106793/1/my-places-search-radius.png" alt="my-places-search-radius" height="799"></p>
</li></ol>
<h3 id="Known_Issues">Known Issues</h3>
<p>When running the sample if your Bing Maps control displays the following image:</p>
<p><img id="106794" width="285" src="http://i1.code.msdn.s-msft.com/windowsapps/geolocation-sample-end-to-5d9ee245/image/file/106794/1/bing-maps-unsupported.png" alt="bing-maps-unsupported" height="184"></p>
<p>See this MSDN article related to the supported regions in Bing Maps: <a href="http://msdn.microsoft.com/en-us/library/jj670541.aspx">
http://msdn.microsoft.com/en-us/library/jj670541.aspx</a>. You can set the property
<strong>Map.HomeRegion</strong> to any of the supported regions to workaround the problem.</p>
<p>Want to see more Windows Store app samples using Windows Azure Mobile Services - check out the
<a href="http://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=Technology&f%5B0%5D.Value=Windows%20Azure%20Mobile%20Services&f%5B0%5D.Text=Windows%20Azure%20Mobile%20Services" target="_blank">
full listing</a>. If you cant find a specific&nbsp;Windows Azure Mobile Services&nbsp;scenaro in the
<a href="http://code.msdn.microsoft.com/windowsapps/site/search?f%5B0%5D.Type=Technology&f%5B0%5D.Value=Windows%20Azure%20Mobile%20Services&f%5B0%5D.Text=Windows%20Azure%20Mobile%20Services" target="_blank">
full listing</a> please&nbsp;feel free to reach out to me on Twitter&nbsp;via&nbsp;<a href="http://www.twitter.com/cloudnick" target="_blank">@cloudnick</a></p>
<div id="_mcePaste" class="mcePaste" style="overflow:hidden; height:1px; left:-10000px; top:0px; width:1px">
</div>
</div>
