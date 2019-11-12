# Get memory information of local system using WMI in vb.net
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- WMI
- VB.Net
## Topics
- VB.Net
- Windows Management Interface (WMI)
## Updated
- 01/05/2013
## Description

<h1>Introduction</h1>
<p><em>We can retrieve the hardware inforamtion of the local system by using WMI (<span>Windows Management Instrumentation&nbsp;</span>) in vb.net. This samle project demonstrate how you can retrieve the physical memeory and cache memory information by using
 WMI and &nbsp;ManagementObjectSearcher class in vb.net.</em></p>
<p><em><span>Windows Management Instrumentation (WMI) is the infrastructure for management data and operations on Windows-based operating systems.</span></em></p>
<p><em><span><br>
</span></em></p>
<p>&nbsp;</p>
<p><em><img id="74114" src="74114-memory-info-using-wmi.jpg" alt=""><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>&nbsp;Before using the ManagementObjectSearcher object you need to add Reference System.Management.dll to your project and import <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/system.Management.aspx" target="_blank" title="Auto generated link to system.Management">system.Management</a> namespace.</span></p>
<p>&nbsp;</p>
<p><span>The sample project contains a Windows form with a combobox and Textbox control. textbox control will show the information according to combobox selection.
</span></p>
<p><span>The following code snippet is for retrieving the physical memory information from WMI:&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">&nbsp;Private&nbsp;Sub&nbsp;SetPhysicalMemoryinfo()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;searcher&nbsp;As&nbsp;New&nbsp;ManagementObjectSearcher(&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;root\CIMV2&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__string">&quot;SELECT&nbsp;*&nbsp;FROM&nbsp;Win32_PhysicalMemory&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;index&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;str&nbsp;As&nbsp;New&nbsp;StringBuilder&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;queryObj&nbsp;As&nbsp;ManagementObject&nbsp;In&nbsp;searcher.Get()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;On&nbsp;<span class="js__error">Error</span>&nbsp;Resume&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;BankLabel:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;BankLabel&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Capacity:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Capacity&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Caption:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Caption&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;CreationClassName:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;CreationClassName&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;DataWidth:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;DataWidth&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Description:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Description&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;DeviceLocator:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;DeviceLocator&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;FormFactor:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;FormFactor&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;HotSwappable:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;HotSwappable&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;InstallDate:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;InstallDate&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;InterleaveDataDepth:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;InterleaveDataDepth&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;InterleavePosition:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;InterleavePosition&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Manufacturer:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Manufacturer&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;MemoryType:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;MemoryType&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Model:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Model&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Name:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Name&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;OtherIdentifyingInfo:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;OtherIdentifyingInfo&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;PartNumber:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;PartNumber&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;PositionInRow:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;PositionInRow&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;PoweredOn:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;PoweredOn&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Removable:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Removable&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Replaceable:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Replaceable&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;SerialNumber:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;SerialNumber&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;SKU:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;SKU&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Speed:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Speed&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Status:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Status&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Tag:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Tag&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;TotalWidth:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;TotalWidth&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;TypeDetail:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;TypeDetail&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;Version:&nbsp;&quot;</span>&nbsp;&amp;&nbsp;queryObj(<span class="js__string">&quot;Version&quot;</span>)&nbsp;&amp;&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str.Append(<span class="js__string">&quot;------------------------------------&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox1.Text&nbsp;=&nbsp;str.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<ul>
</ul>
<h1>More Information</h1>
<p>We can use the WMI code creator tool to generate&nbsp;VBScript, C#, and VB .NET code that uses WMI to complete a management task such as querying for management data.</p>
<p>You can download from&nbsp;http://www.microsoft.com/en-us/download/details.aspx?id=8572</p>
<p>&nbsp;</p>
<p>For more information on WMI :&nbsp;http://msdn.microsoft.com/en-us/library/aa394582(v=vs.85).aspx</p>
