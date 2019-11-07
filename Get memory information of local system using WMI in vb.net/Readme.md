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
<p><span>&nbsp;Before using the ManagementObjectSearcher object you need to add Reference System.Management.dll to your project and import system.Management namespace.</span></p>
<p>&nbsp;</p>
<p><span>The sample project contains a Windows form with a combobox and Textbox control. textbox control will show the information according to combobox selection.
</span></p>
<p><span>The following code snippet is for retrieving the physical memory information from WMI:&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden"> Private Sub SetPhysicalMemoryinfo()
        Dim searcher As New ManagementObjectSearcher( _
                  &quot;root\CIMV2&quot;, _
                  &quot;SELECT * FROM Win32_PhysicalMemory&quot;)
        Dim index As Integer = 0
        Dim str As New StringBuilder

        For Each queryObj As ManagementObject In searcher.Get()
            On Error Resume Next
        
            str.Append(&quot;BankLabel: &quot; &amp; queryObj(&quot;BankLabel&quot;) &amp; vbCrLf)
            str.Append(&quot;Capacity: &quot; &amp; queryObj(&quot;Capacity&quot;) &amp; vbCrLf)
            str.Append(&quot;Caption: &quot; &amp; queryObj(&quot;Caption&quot;) &amp; vbCrLf)
            str.Append(&quot;CreationClassName: &quot; &amp; queryObj(&quot;CreationClassName&quot;) &amp; vbCrLf)
            str.Append(&quot;DataWidth: &quot; &amp; queryObj(&quot;DataWidth&quot;) &amp; vbCrLf)
            str.Append(&quot;Description: &quot; &amp; queryObj(&quot;Description&quot;) &amp; vbCrLf)
            str.Append(&quot;DeviceLocator: &quot; &amp; queryObj(&quot;DeviceLocator&quot;) &amp; vbCrLf)
            str.Append(&quot;FormFactor: &quot; &amp; queryObj(&quot;FormFactor&quot;) &amp; vbCrLf)
            str.Append(&quot;HotSwappable: &quot; &amp; queryObj(&quot;HotSwappable&quot;) &amp; vbCrLf)
            str.Append(&quot;InstallDate: &quot; &amp; queryObj(&quot;InstallDate&quot;) &amp; vbCrLf)
            str.Append(&quot;InterleaveDataDepth: &quot; &amp; queryObj(&quot;InterleaveDataDepth&quot;) &amp; vbCrLf)
            str.Append(&quot;InterleavePosition: &quot; &amp; queryObj(&quot;InterleavePosition&quot;) &amp; vbCrLf)
            str.Append(&quot;Manufacturer: &quot; &amp; queryObj(&quot;Manufacturer&quot;) &amp; vbCrLf)
            str.Append(&quot;MemoryType: &quot; &amp; queryObj(&quot;MemoryType&quot;) &amp; vbCrLf)
            str.Append(&quot;Model: &quot; &amp; queryObj(&quot;Model&quot;) &amp; vbCrLf)
            str.Append(&quot;Name: &quot; &amp; queryObj(&quot;Name&quot;) &amp; vbCrLf)
            str.Append(&quot;OtherIdentifyingInfo: &quot; &amp; queryObj(&quot;OtherIdentifyingInfo&quot;) &amp; vbCrLf)
            str.Append(&quot;PartNumber: &quot; &amp; queryObj(&quot;PartNumber&quot;) &amp; vbCrLf)
            str.Append(&quot;PositionInRow: &quot; &amp; queryObj(&quot;PositionInRow&quot;) &amp; vbCrLf)
            str.Append(&quot;PoweredOn: &quot; &amp; queryObj(&quot;PoweredOn&quot;) &amp; vbCrLf)
            str.Append(&quot;Removable: &quot; &amp; queryObj(&quot;Removable&quot;) &amp; vbCrLf)
            str.Append(&quot;Replaceable: &quot; &amp; queryObj(&quot;Replaceable&quot;) &amp; vbCrLf)
            str.Append(&quot;SerialNumber: &quot; &amp; queryObj(&quot;SerialNumber&quot;) &amp; vbCrLf)
            str.Append(&quot;SKU: &quot; &amp; queryObj(&quot;SKU&quot;) &amp; vbCrLf)
            str.Append(&quot;Speed: &quot; &amp; queryObj(&quot;Speed&quot;) &amp; vbCrLf)
            str.Append(&quot;Status: &quot; &amp; queryObj(&quot;Status&quot;) &amp; vbCrLf)
            str.Append(&quot;Tag: &quot; &amp; queryObj(&quot;Tag&quot;) &amp; vbCrLf)
            str.Append(&quot;TotalWidth: &quot; &amp; queryObj(&quot;TotalWidth&quot;) &amp; vbCrLf)
            str.Append(&quot;TypeDetail: &quot; &amp; queryObj(&quot;TypeDetail&quot;) &amp; vbCrLf)
            str.Append(&quot;Version: &quot; &amp; queryObj(&quot;Version&quot;) &amp; vbCrLf)
            str.Append(&quot;------------------------------------&quot;)

        Next
        TextBox1.Text = str.ToString()
    End Sub</pre>
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
