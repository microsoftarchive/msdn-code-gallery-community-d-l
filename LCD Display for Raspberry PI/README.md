# LCD Display for Raspberry PI
## Requires
- Visual Studio 2017
## License
- MIT
## Technologies
- C#
- IoT
- Embedded Hardware
- Windows IoT
## Topics
- User Interface
- Hardware
- IoT
- Embedded
## Updated
- 04/16/2017
## Description

<h1>
<div class="endscriptcode">
<div class="endscriptcode"></div>
</div>
Introduction</h1>
<p>A&nbsp;Raspberry PI running Windows 10 IoT Core shall provide some information on a simple LCD display with 4 rows of 20 characters. The LCD display shall be connected to the Raspberry PI over the I2C bus. This connection requires only 4 wires.</p>
<p>As LCD display I have selected a Sainsmart LCD2004. You can buy it for less than 15 US Dollar.</p>
<p><img id="172223" src="https://i1.code.msdn.s-msft.com/lcd-display-for-raspberry-217c5fa2/image/file/172223/1/hardware.png" alt=""></p>
<p>&nbsp;</p>
<p>A datasheet for the LCD display and also for the I2C Bus Port expander used to connect the LCD Display with the Raspberry PI is included in the sample code. The LCD2004&nbsp;comes with&nbsp;the I2C Bus Port Expander connected as follows:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__preproc">#region&nbsp;&nbsp;Hardwware&nbsp;Information</span>&nbsp;
<span class="cs__com">//&nbsp;Hardware&nbsp;connection</span>&nbsp;
<span class="cs__com">//&nbsp;===================</span>&nbsp;
<span class="cs__com">//</span>&nbsp;
<span class="cs__com">//&nbsp;The&nbsp;LCD&nbsp;controller&nbsp;and&nbsp;the&nbsp;port&nbsp;expander&nbsp;are&nbsp;connected&nbsp;as&nbsp;show&nbsp;here:</span>&nbsp;
<span class="cs__com">//</span>&nbsp;
<span class="cs__com">//&nbsp;HD44780&nbsp;&nbsp;&nbsp;&nbsp;-&nbsp;&nbsp;PCF8574</span>&nbsp;
<span class="cs__com">//&nbsp;------------------------</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RS&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P0</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RW&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P1</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EN&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P2</span>&nbsp;
<span class="cs__com">//&nbsp;BackLight&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P3</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DB4&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P4</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DB5&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P5</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DB6&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P6</span>&nbsp;
<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DB7&nbsp;&nbsp;-&nbsp;&nbsp;&nbsp;P7</span><span class="cs__preproc">&nbsp;
#endregion</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;That means the connection between the LCD2004 and the Raspberry is possible only with four wires:</div>
<div class="endscriptcode"></div>
<ol>
<li>
<div class="endscriptcode">5 Volt supply (VCC)</div>
</li><li>
<div class="endscriptcode">Ground signal (GND)</div>
</li><li>
<div class="endscriptcode">I2C Data (SDA)</div>
</li><li>
<div class="endscriptcode">I2C Clock (SCL)</div>
</li></ol>
<p>The pinouts for the Raspberry PI can be found either <a href="https://www.raspberrypi.org/blog/pinout-for-gpio-connectors/">
here</a> or by an internet search for &quot;Raspberry PI GPIO image&quot;. Here is how the connection looks in my test setup:</p>
<p><img id="172231" src="https://i1.code.msdn.s-msft.com/lcd-display-for-raspberry-217c5fa2/image/file/172231/1/connections-512x205.png" alt="" width="512" height="205"></p>
<p><em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>To build the sample select ARM as target platform and rebuild the solution. I will compile a library that contains the code for the communication with the LCD display via the I2C bus.</p>
<p><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The solution contains a library that implments the communication with the LCD display viar the I2C bus. The usage of that libray is demonstrated by a small Universal Windows App that runs on a Raspberry PI under Windows 10 IoT. You can control the App by
 connecting with the Remote IoT Client program to the Raspberry</p>
<p>The most interesting file is the LCD2004.cs in the I2CLibrary project.&nbsp;The file contains a class that establishes the communication&nbsp;with the LCD2004 device and provide methods for printing text, setting&nbsp;cursor position,&nbsp;enabling the backlight
 etc.</p>
<p>Here are some&nbsp;interesting code snippets:&nbsp;</p>
<p>For the communication over the I2C bus one has to know the I2C address of the&nbsp;LCD display. The&nbsp;LCD2004&nbsp;has the default address 0x27<em>.&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">const</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;I2CAddress&nbsp;=&nbsp;0x27;<br></pre>
</div>
</div>
</div>
<p>The method Initialize() creates an I2CDevice object that acts as a proxy for the LCD2004 hardware device:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">try</span>&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;i2CSettings&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;I2cConnectionSettings(I2CAddress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;i2CSettings.BusSpeed&nbsp;=&nbsp;I2cBusSpeed.FastMode;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;i2CMaster&nbsp;=&nbsp;I2cDevice.GetDeviceSelector();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;i2CSlaves&nbsp;=&nbsp;await&nbsp;DeviceInformation.FindAllAsync(i2CMaster);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_mDevice&nbsp;=&nbsp;await&nbsp;I2cDevice.FromIdAsync(i2CSlaves[<span class="cs__number">0</span>].Id,&nbsp;i2CSettings);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_mDevice&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception($<span class="cs__string">&quot;I2C&nbsp;Device&nbsp;with&nbsp;address&nbsp;{I2CAddress}&nbsp;already&nbsp;in&nbsp;use&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Debug.WriteLine.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debug.WriteLine">System.Diagnostics.Debug.WriteLine</a>(<span class="cs__string">&quot;Exception:&nbsp;{0}&quot;</span>,&nbsp;e.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;_mDevice&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
}&nbsp;
InitializeHardware();</pre>
</div>
</div>
</div>
<div class="endscriptcode">The sequence of commands for initalizing the hardware is defined in the datasheet. The LCD2004 is configured to communicate with 4 bits plus 3 handshake lines. The forth line is controlling the LCD's backlight.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;InitializeHardware()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_mDevice&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;data&nbsp;=&nbsp;{_backlight};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_mDevice.Write(data);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;put&nbsp;LCD&nbsp;into&nbsp;4bit&nbsp;mode&nbsp;according&nbsp;to&nbsp;HD44780&nbsp;datasheet&nbsp;page&nbsp;46</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write4Bits(&nbsp;0x03&nbsp;&lt;&lt;&nbsp;<span class="cs__number">4</span>&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write4Bits(&nbsp;0x03&nbsp;&lt;&lt;&nbsp;<span class="cs__number">4</span>&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write4Bits(&nbsp;0x03&nbsp;&lt;&lt;&nbsp;<span class="cs__number">4</span>&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write4Bits(0x02&nbsp;&lt;&lt;<span class="cs__number">4</span>&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write8Bits((<span class="cs__keyword">byte</span>)(Command.LCD_FUNCTIONSET&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;_displayFunction&nbsp;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write8Bits((<span class="cs__keyword">byte</span>)(Command.LCD_DISPLAYCONTROL&nbsp;|&nbsp;_displayControl&nbsp;&nbsp;));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Home();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Clear();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Write8Bits((<span class="cs__keyword">byte</span>)&nbsp;(Command.LCD_ENTRYMODESET&nbsp;|&nbsp;_displayMode));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Delay(<span class="cs__number">2</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Debug.WriteLine.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Debug.WriteLine">System.Diagnostics.Debug.WriteLine</a>(<span class="cs__string">&quot;Failed&nbsp;to&nbsp;initialize&nbsp;display&nbsp;on&nbsp;I2C&nbsp;address&nbsp;{0}&quot;</span>,&nbsp;I2CAddress);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode"></div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
</ul>
<p><em>The Visual Studio Solution contains two projects:</em></p>
<ul>
<li><em>I2CLibray&nbsp;</em>- Reusable library for communicating with a LCD2004 Display<em>.</em>
</li><li><em><em>LCDisplay - </em></em>Demo program (Universal Windows App) for Raspberry PI<em><em>.</em></em>
</li></ul>
<h1>More Information</h1>
<p>Also included in the example is a HTML Help that provides an overview about the I2CLibrary classes. The library is basically a port from the sainsmart C&#43;&#43; Library for an Arduino. All functions except support vor customer defined characters have been ported
 to C#.</p>
<p><em><br>
</em></p>
