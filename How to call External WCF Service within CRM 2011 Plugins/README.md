# How to call External WCF Service within CRM 2011 Plugins
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C# Microsoft Dynamics CRM 2011
## Topics
- Plug-in
## Updated
- 01/30/2013
## Description

<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Step 1: Build and Publish the WCF Service</strong></p>
<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Step 2: Deploy the WCF Service</strong></p>
<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Step 3: Create WCF client</strong></p>
<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
Create a WCF client using &nbsp;ServiceModel Metadata Utility Tool (Svcutil.exe) by using following steps:</p>
<ol style="background-color:#ffffff; border:0px; margin:0px 0px 24px 1.5em; padding:0px; vertical-align:baseline; list-style:decimal; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<li style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline">
On the Start menu click All Programs, and then click Visual Studio 2010. Click Visual Studio Tools and then click Visual Studio 2010 Command Prompt.
</li><li style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline">
Navigate to the directory where you want to place the client code. </li><li style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline">
Use the command-line tool ServiceModel Metadata Utility Tool (Svcutil.exe) with the appropriate switches to create the client code. The following example generates a code file and a configuration file for the service.
</li></ol>
<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">svcutil.exe /language:cs /out:TaxServiceClient.cs http://192.168.124.26:81/TaxProductionService</strong></p>
<p style="background-color:#ffffff; border:0px; margin:0px 0px 24px; padding:0px; vertical-align:baseline; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Step 4: Write Plugin to consume external WCF Service</strong></p>
<ol style="background-color:#ffffff; border:0px; margin:0px 0px 24px 1.5em; padding:0px; vertical-align:baseline; list-style:decimal; color:#333333; font-family:Georgia,'Bitstream Charter',serif; font-size:16px; font-style:normal; font-variant:normal; font-weight:normal; letter-spacing:normal; line-height:24px; orphans:2; text-align:start; text-indent:0px; text-transform:none; white-space:normal; widows:2; word-spacing:0px">
<li style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline">
Add the above generated .CS class into the plugin solution. In&nbsp;Visual Studio, right-click the client project in&nbsp;<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Solution Explorer</strong>&nbsp;and
 select&nbsp;<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Add</strong><strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">&nbsp;</strong>and
 then&nbsp;<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">Existing Item</strong>. Select the&nbsp;<strong style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline; font-weight:bold">TaxServiceClient.cs&nbsp;</strong>file
 generated in the preceding step. </li><li style="background-color:transparent; border:0px; margin:0px; padding:0px; vertical-align:baseline">
Open the plugin.cs class from the solution. And call the WCF client using channel factory.
</li></ol>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;BasicHttpBinding&nbsp;myBinding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BasicHttpBinding();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myBinding.Name&nbsp;=&nbsp;<span class="cs__string">&quot;BasicHttpBinding_IPOCService&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myBinding.Security.Mode&nbsp;=&nbsp;BasicHttpSecurityMode.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myBinding.Security.Transport.ClientCredentialType&nbsp;=&nbsp;HttpClientCredentialType.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myBinding.Security.Transport.ProxyCredentialType&nbsp;=&nbsp;HttpProxyCredentialType.None;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myBinding.Security.Message.ClientCredentialType&nbsp;=&nbsp;BasicHttpMessageCredentialType.UserName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EndpointAddress&nbsp;endPointAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EndpointAddress(<span class="cs__string">&quot;http://crm2011.com:81/POCService/POCService.svc&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ChannelFactory&lt;IPOCService&gt;&nbsp;factory&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ChannelFactory&lt;IPOCService&gt;(myBinding,&nbsp;endPointAddress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IPOCService&nbsp;channel&nbsp;=&nbsp;factory.CreateChannel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;objOrder&nbsp;=&nbsp;channel.GetCalculatedTaxValue(unitPrice);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;factory.Close();</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
