# How to read events from an IoT Hub with the Service Bus Explorer
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Microsoft Azure
- Service Bus
- Event Hubs
- IoT Hubs
## Topics
- IoT
## Updated
- 10/06/2015
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p>This sample shows how to use the <a href="https://code.msdn.microsoft.com/windowsapps/Service-Bus-Explorer-f2abca5a">
Service Bus Explorer</a> to read events from an IoT Hub. The solution makes use of a Device Emulator to send events to an IoT Hub. The code of the Device Emulator shows how to perform the following actions:</p>
<ul>
<li>Create a new device to the device identity registry using the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.adddeviceasync.aspx#M:<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.RegistryManager.AddDeviceAsync.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.RegistryManager.AddDeviceAsync">Microsoft.Azure.Devices.RegistryManager.AddDeviceAsync</a>(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.Device.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.Device">Microsoft.Azure.Devices.Device</a>)">
AddDeviceAsync</a> method of the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.aspx">
RegistryManager</a> class. </li><li>Retrieve an existing device from the device identity registry using the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.getdeviceasync.aspx#M:<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.RegistryManager.GetDeviceAsync.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.RegistryManager.GetDeviceAsync">Microsoft.Azure.Devices.RegistryManager.GetDeviceAsync</a>(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.String.aspx" target="_blank" title="Auto generated link to System.String">System.String</a>,<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.CancellationToken.aspx" target="_blank" title="Auto generated link to System.Threading.CancellationToken">System.Threading.CancellationToken</a>)">
GetDeviceAsync</a> method&nbsp;of the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.aspx">RegistryManager</a>&nbsp;class.
</li><li>Remove an existing device from the device identity registry using the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.removedeviceasync.aspx#M:<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.RegistryManager.RemoveDeviceAsync.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.RegistryManager.RemoveDeviceAsync">Microsoft.Azure.Devices.RegistryManager.RemoveDeviceAsync</a>(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.Device.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.Device">Microsoft.Azure.Devices.Device</a>,<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Threading.CancellationToken.aspx" target="_blank" title="Auto generated link to System.Threading.CancellationToken">System.Threading.CancellationToken</a>)">
RemoveDeviceAsync</a>&nbsp;method of the&nbsp;<a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.aspx">RegistryManager</a>&nbsp;class.
</li><li>Send events to an IoT Hub using the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.client.deviceclient.sendeventasync.aspx#M:<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.Client.DeviceClient.SendEventAsync.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.Client.DeviceClient.SendEventAsync">Microsoft.Azure.Devices.Client.DeviceClient.SendEventAsync</a>(<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/Microsoft.Azure.Devices.Client.Message.aspx" target="_blank" title="Auto generated link to Microsoft.Azure.Devices.Client.Message">Microsoft.Azure.Devices.Client.Message</a>)">
SendEventAsync</a> method of the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.client.deviceclient.aspx">
DeviceClient</a> class. </li></ul>
<h1>Scenario</h1>
<p>This solution simulates an Internet of Things (IoT) scenario where thousands of devices send events (e.g. sensor readings) to an IoT Hub. In this context, the
<a href="https://code.msdn.microsoft.com/windowsapps/Service-Bus-Explorer-f2abca5a">
Service Bus Explorer</a>&nbsp;is used to debug the application and trace the events sent by devices to the IoT Hub.</p>
<h1>Architecture</h1>
<p>The sample is structured as follows:</p>
<ul>
<li>A Windows Forms application is used to emulate a configurable amount of devices that send telemetry data into an IoT Hub.&nbsp;
</li><li>The emulator uses a separate Task for each device. </li><li>The Service Bus Explorer is used to read events from the receive device-to-cloud (D2C) endpoint exposed by the IoT Hub. The latter is an&nbsp;Event Hubs-compatible endpoint and its name is
<strong>messages/events</strong>. </li></ul>
<p>The following picture shows the architecture of the solution:</p>
<p style="text-align:center"><img id="143304" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143304/1/architecture.png" alt="" width="700"></p>
<h1>References</h1>
<p>IoT Hubs</p>
<ul>
<li><a href="https://azure.microsoft.com/en-us/documentation/articles/iot-hub-what-is-azure-iot/">Microsoft Azure and the Internet of Things (IoT)</a>
</li><li><a href="https://azure.microsoft.com/en-us/documentation/articles/iot-hub-what-is-iot-hub/">What is Azure IoT Hub?</a>
</li><li><a href="https://azure.microsoft.com/en-us/documentation/articles/iot-hub-csharp-csharp-getstarted/">Get started with IoT Hub</a>&nbsp;
</li><li><a href="https://msdn.microsoft.com/library/mt488521.aspx">IoT Hub .NET API reference</a>
</li></ul>
<p>&nbsp;</p>
<p>Event Hubs</p>
<ul>
<li><a href="http://azure.microsoft.com/en-us/services/event-hubs/">Event Hubs</a>
</li><li><a href="http://azure.microsoft.com/en-us/documentation/articles/service-bus-event-hubs-csharp-ephcs-getstarted/">Get started with Event Hubs</a>
</li><li><a href="https://msdn.microsoft.com/en-us/library/azure/dn789972.aspx">Event Hubs Programming Guide</a>
</li><li><a href="https://code.msdn.microsoft.com/windowsazure/Service-Bus-Event-Hub-286fd097">Service Bus Event Hubs Getting Started</a>
</li><li><a href="https://msdn.microsoft.com/en-us/library/azure/dn789974.aspx">Event Hubs Authentication and Security Model Overview</a>
</li><li><a href="https://code.msdn.microsoft.com/windowsazure/Service-Bus-Event-Hub-99ce67ab">Service Bus Event Hubs Large Scale Secure Publishing</a>
</li><li><a href="https://code.msdn.microsoft.com/windowsazure/Event-Hub-Direct-Receivers-13fa95c6">Service Bus Event Hubs Direct Receivers</a>
</li><li><a href="https://code.msdn.microsoft.com/windowsapps/Service-Bus-Explorer-f2abca5a">Service Bus Explorer</a>
</li><li><a href="http://channel9.msdn.com/Shows/Cloud&#43;Cover/Episode-160-Event-Hubs-with-Elio-Damaggio">Episode 160: Event Hubs with Elio&nbsp;Damaggio</a>&nbsp;(video)
</li><li><a href="http://channel9.msdn.com/Events/TechEd/Europe/2014/CDP-B307">Telemetry and Data Flow at Hyper-Scale: Azure Event Hub</a>&nbsp;(video)
</li><li><a href="https://github.com/mspnp/data-pipeline">Data Pipeline Guidance</a>&nbsp; (Patterns &amp; Practices solution)
</li><li><a href="http://blogs.msdn.com/b/servicebus/archive/2015/01/16/event-processor-host-best-practices-part-1.aspx">Event Processor Host Best Practices Part 1</a>
</li><li><a href="http://blogs.msdn.com/b/servicebus/archive/2015/01/21/event-processor-host-best-practices-part-2.aspx">Event Processor Host Best Practices Part 2</a>
</li><li><a href="http://blogs.msdn.com/b/paolos/archive/2014/12/01/how-to-create-a-service-bus-namespace-and-an-event-hub-using-a-powershell-script.aspx">How to create a Service Bus Namespace and an Event Hub using a PowerShell script</a>
</li></ul>
<div class="endscriptcode">
<h1 class="endscriptcode">Visual Studio Solution</h1>
</div>
<div></div>
<div class="endscriptcode">The Visual Studio solution includes the following projects:</div>
<div class="endscriptcode">&nbsp;</div>
<ul>
<li>
<div class="endscriptcode"><strong>DeviceEmulator</strong>: this Windows Forms application can be used to emulate a configurable amount of devices sending events to the IoT Hub.</div>
</li></ul>
<p class="endscriptcode"><strong>NOTE</strong>:&nbsp;To reduce the size of tha zip file, I deleted the NuGet packages. To repair the solution, make sure to right click the solution and select&nbsp;<strong>Enable NuGet Package Restore&nbsp;</strong>as shown
 in the picture below. For more information on this topic, see the following&nbsp;<a href="http://blogs.4ward.it/enable-nuget-package-restore-in-visual-studio-and-tfs-2012-rc-to-building-windows-8-metro-apps/">post</a>.</p>
<h1 class="endscriptcode">Solution</h1>
<p>This section briefly describes the individual components of the solution.</p>
<h2>DeviceEmulator</h2>
<p>This Windows Forms application can be used to create and remove a configurable number of devices in the device identity registry of an IoT Hub using the
<a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.registrymanager.aspx">
RegistryManager</a>&nbsp;class&nbsp;and send messages to the IoT Hub using the <a href="https://msdn.microsoft.com/en-us/library/microsoft.azure.devices.client.deviceclient.aspx">
DeviceClient</a>&nbsp;class. The application creates a separate task for each emulated device.</p>
<p style="text-align:center"><img id="143283" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143283/1/emulator02.png" alt="" width="660"></p>
<h3>Remarks</h3>
<ol>
<li><strong>Connection String</strong>: specifies the IoT Hub connection string. </li><li><strong>Min Value</strong>: specifies the minimum value for the telemetry data.
</li><li><strong>MaxValue</strong>: specifies the maximum value for the telemetry data.
</li><li><strong>Min Offset</strong>: specifies the minimum value for the offset to add to / subract from telemetry data when the device task emulates a spike.
</li><li><strong>Max Offset</strong>: specifies the maximum value for the offset to add to / subract from telemetry data&nbsp;when the device task emulates a spike.
</li><li><strong>Device Count</strong>: specifies the amount of devices to emulate. </li><li>E<strong>vent Interval in Milliseconds</strong>: specifies the time interval in milliseconds between two consecutive events.
</li><li><strong>Spike Percentage</strong>: specifies the percentage of spikes with respect to the tolerance range defined by the Min and Max values.
</li><li><strong>Create Devices</strong>: creates or retrieves the devices in the device identity registry of the IoT Hub.
</li><li><strong>Remove Devices</strong>: remove the devices from the device identity registry.
</li><li><strong>Clear</strong>: clears the log. </li><li><strong>Start/Stop</strong>: starts/stops the tasks that emulate devices. </li></ol>
<p>The following table shows the <strong>appSettings </strong>section of the configuration file where you can define the IoT Hub connection strings and the other settings used by the applications.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>

<div class="preview">
<pre class="xml"><span class="xml__tag_start">&lt;configuration</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;<span class="xml__tag_start">&lt;appSettings</span><span class="xml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;connectionString&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;[IoT-Hub-Connection-String]&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;deviceCount&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;100&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;eventInterval&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;2000&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;minValue&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;maxValue&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;40&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;minOffset&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;maxOffset&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xml__tag_start">&lt;add</span>&nbsp;<span class="xml__attr_name">key</span>=<span class="xml__attr_value">&quot;spikePercentage&quot;</span>&nbsp;<span class="xml__attr_name">value</span>=<span class="xml__attr_value">&quot;5&quot;</span>&nbsp;<span class="xml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;<span class="xml__tag_end">&lt;/appSettings&gt;</span>&nbsp;
&nbsp;&nbsp;...&nbsp;
<span class="xml__tag_end">&lt;/configuration&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">The following table contains the code of the <strong>
Payload </strong>class used by the application as telemetry data. At runtime, messages are serialized to JSON format.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Payload&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;device&nbsp;id.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;deviceId&quot;</span>,&nbsp;Order&nbsp;=&nbsp;<span class="cs__number">1</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">long</span>&nbsp;DeviceId&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;device&nbsp;name.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;name&quot;</span>,&nbsp;Order&nbsp;=&nbsp;<span class="cs__number">2</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Name&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;device&nbsp;value.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;value&quot;</span>,&nbsp;Order&nbsp;=&nbsp;<span class="cs__number">3</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;Value&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;status.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;status&quot;</span>,&nbsp;Order&nbsp;=&nbsp;<span class="cs__number">4</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;Status&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Gets&nbsp;or&nbsp;sets&nbsp;the&nbsp;timestamp.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[JsonProperty(PropertyName&nbsp;=&nbsp;<span class="cs__string">&quot;timestamp&quot;</span>,&nbsp;Order&nbsp;=&nbsp;<span class="cs__number">5</span>)]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;DateTime&nbsp;Timestamp&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1 class="endscriptcode">Tutorial&nbsp;</h1>
<p>This section contains the steps necessary to use complete the tutorial that explains how to use the Service Bus Explorer to read messages from the receive device-to-cloud endpoint of an IoT Hub.</p>
<h2>Create an IoT Hub</h2>
<ol>
<li>
<p>Log on to the <a href="https://portal.azure.com/">Azure Preview Portal</a>.</p>
</li><li>
<p>In the jumpbar, click <strong>New</strong>, then click <strong>Internet of Things</strong>, and then click
<strong>IoT Hub</strong>.</p>
<p><img id="143284" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143284/1/create-iot-hub1.png" alt="" width="660" style="display:block; margin-left:auto; margin-right:auto"></p>
</li><li>
<p>In the <strong>New IoT Hub</strong> blade, specify the desired configuration for the IoT Hub.</p>
<p><img id="143285" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143285/1/create-iot-hub2.png" alt="" width="312" height="720" style="display:block; margin-left:auto; margin-right:auto"></p>
<ul>
<li>In the <strong>Name</strong> box, enter a name to identify your IoT hub. When the
<strong>Name</strong> is validated, a green check mark appears in the <strong>Name</strong> box.
</li><li>Change the <strong>Pricing and scale tier</strong> as desired. This tutorial does not require a specific tier.
</li><li>In the <strong>Resource group</strong> box, create a new resource group, or select and existing one. For more information, see
<a href="https://azure.microsoft.com/en-us/documentation/articles/resource-group-portal/">
Using resource groups to manage your Azure resources</a>. </li><li>Use <strong>Location</strong> to specify the geographic location in which to host your IoT hub.
</li></ul>
</li><li>
<p>Once the new IoT hub options are configured, click <strong>Create</strong>. It can take a few minutes for the IoT hub to be created. To check the status, you can monitor the progress on the Startboard. Or, you can monitor your progress from the Notifications
 section.</p>
<p><img id="143286" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143286/1/create-iot-hub3.png" alt="" width="485" height="124" style="display:block; margin-left:auto; margin-right:auto"></p>
</li><li>
<p>After the IoT hub has been created successfully, open the blade of the new IoT Hub, and select the
<strong>Key</strong> icon on the top.</p>
<p><img id="143289" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143289/1/key.png" alt="" width="585" height="812" style="display:block; margin-left:auto; margin-right:auto"><br>
<br>
</p>
</li><li>
<p>Select the Shared access policy called <strong>iothubowner</strong>, then copy and take note of the connection string on the right blade.</p>
<p style="text-align:center"><img id="143290" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143290/1/connectionstring2.png" alt="" width="660"><br>
<br>
</p>
</li><li>Click the <strong>All settings </strong>link, then click the Messaging link to open the Event Hub blade and create a new consumer group called
<strong>ServiceBusExplorer</strong>. If your IoT Hub solution uses the <strong>$Default</strong> consumer group, you need to create a dedicated consumer group to&nbsp;receive messages from the IoT Hub using the Service Bus Explore.
</li></ol>
<p><img id="143291" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143291/1/consumergroup.png" alt="" width="660"></p>
<p>Your IoT Hub is now created, and you have the connection string you need to complete this tutorial.</p>
</div>
<h2>Configure the Device Emulator</h2>
<p>I the configuration file of the emulator, replace the&nbsp;[IoT-Hub-Connection-String] placeholder with the IoT Hub connection string you obtained at the previous step.</p>
<h2>Run the Device Emulator</h2>
<p>Launch the device emulator, press the Create Devices button to create devices in the device identity registry and then press the
<strong>Start</strong> button to start device emulators. Click the <strong>Stop</strong> button to stop devices emulators.</p>
<h2>Use the Service Bus Explorer</h2>
<p>Make sure to use&nbsp;<a href="https://code.msdn.microsoft.com/windowsapps/Service-Bus-Explorer-f2abca5a">Service Bus Explorer</a>&nbsp;3.0.4 or higher. Click the
<strong>Actions </strong>menu and select the <strong>Create IoT Hub Listener</strong> menu item.</p>
<p><img id="143292" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143292/1/iothublistener.png" alt="" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Enter the <strong>IoT Hub Connection String</strong> and <strong>Consumer Group</strong> in the dialog that opens and then press the
<strong>Ok </strong>button.</p>
<p><img id="143293" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143293/1/parameters.png" alt="" width="616" height="225" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>Click the <strong>Start </strong>button to start receiving messages from the IoT Hub.&nbsp;</p>
<p style="text-align:center"><img id="143294" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143294/1/sbe02.png" alt="" width="660"></p>
<p>Enable <strong>Tracking </strong>checkbox&nbsp;if you want trace incoming messages. To display messages, click the Events tab (point 1 in the picture below) and select a message from the grid (point 2 in the picture below). The Event Text control (point
 3 in the picture below) shows the message body, where the Event Custom Properties control (point 4 in the picture below) shows the payload custom properties.</p>
<p><img id="143295" src="https://i1.code.msdn.s-msft.com/how-to-read-events-from-an-1641eb1b/image/file/143295/1/eventstab.png" alt="" width="660"></p>
