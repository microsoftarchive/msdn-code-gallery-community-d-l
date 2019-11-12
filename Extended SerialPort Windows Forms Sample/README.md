# Extended SerialPort Windows Forms Sample
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- SerialPort
## Topics
- Windows Forms
- SerialPort class
## Updated
- 07/29/2012
## Description

<h1>Introduction</h1>
<p>in addition to my other contributions of SerialPort class I will now present a extended Version.</p>
<p><br>
<a href="http://code.msdn.microsoft.com/SerialPort-Sample-in-VBNET-fb040fb2">http://code.msdn.microsoft.com/SerialPort-Sample-in-VBNET-fb040fb2</a><br>
Serial Port Sample in VB.NET. This is a beginners code</p>
<p><a href="http://code.msdn.microsoft.com/SerialPort-Windows-Forms-a43f208e">http://code.msdn.microsoft.com/SerialPort-Windows-Forms-a43f208e</a><br>
This is a extended application based on this.</p>
<p>My sample now demonstrates the usage of the Serial Port class. The serial port services are encapsulated in a class (full OOP). This is also a useful tool (terminal)</p>
<p>especially:</p>
<ul>
<li>usage of splashsreen<br>
using the com port being encapsulated<br>
reading an writing com port bytewise<br>
reading variable frames lenght up to 4096 bytes<br>
using extended tuning and timing (threshold, delay)<br>
extended working with Richtextbox control<br>
entering HEX data in a textbox<br>
converting bytes to HEX string<br>
extended working with enums </li></ul>
<p>&nbsp;</p>
<h1>Building the Sample</h1>
<p><br>
There are no special requirements or instructions for building the sample neccessary. You only need one com port on the system.</p>
<h1><br>
Description of the UI</h1>
<p>screenshot</p>
<p>&nbsp;<img id="60594" src="60594-ellenst_klein.jpg" alt="" width="692" height="479"></p>
<p><strong>Main menuestrip</strong></p>
<p>File &gt; Load config<br>
File &gt; save conifig<br>
File &gt; exit</p>
<p>Options &gt; font &gt; Large / Medium / Small</p>
<p><br>
<strong>Comport Toolstrip</strong></p>
<p>Select ComPort<br>
Select Baudrate<br>
Select Databits<br>
Select Parity<br>
Select Stopbits<br>
Select Delay<br>
Select Threshold<br>
Open/Close Port</p>
<p><br>
<strong>Receive Toolstrip</strong></p>
<p>Button clear RX box<br>
Button Save textfile from RX box<br>
counter RX<br>
status RX<br>
Checkbox Show HEX<br>
Checkbox Show ASCII</p>
<p><strong>Send Toolstrip1</strong></p>
<p>Button clear TX box<br>
Button Load textfile into TX box<br>
counter TX<br>
status TX<br>
Checkbox enter in HEX mode<br>
Checkbox Show HEX<br>
Checkbox Show ASCII</p>
<p><br>
<strong>Send Toolstrip2</strong></p>
<p>Combobox Enter data direct &amp; terminate with CR<br>
Checkboxes Add CR / LF to stream</p>
<p><strong>Send Box right mouse button menue</strong></p>
<p>Copy<br>
Paste<br>
Cut<br>
Send line (sending line from caret)<br>
Send selection</p>
<h1><br>
What is Threshold &amp; Delay?</h1>
<p><br>
.ReceivedBytesThreshold:<br>
Gets or sets the number of bytes in the internal input buffer before a DataReceived
<br>
&lt;<a href="http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.datareceived(v=vs.80">http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.datareceived(v=vs.80</a>)&gt; event occurs.<br>
&nbsp;<br>
In my sample I can change threshold from 1 ... 1000 .<br>
The intention is to fetch more bytes at once from the stream. This wil relif the main UI thread.</p>
<p>Example:<br>
When You have a fixed length of data frame 100 bytes You may set this property to 100.<br>
But notice: this is dangerous, when one bytes ist lost, event handle will never be executed.</p>
<p>See also: SerialPort.ReceivedBytesThreshold Property<br>
<a href="http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.receivedbytesthreshold(v=vs.80">http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.receivedbytesthreshold(v=vs.80</a>)</p>
<p><br>
Delay. We take a look into my code:</p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp; Private Sub SerialPort1_DataReceived(ByVal sender As <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Object.aspx" target="_blank" title="Auto generated link to System.Object">System.Object</a>, _</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ByVal e
 As <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.IO.Ports.SerialDataReceivedEventArgs.aspx" target="_blank" title="Auto generated link to System.IO.Ports.SerialDataReceivedEventArgs">System.IO.Ports.SerialDataReceivedEventArgs</a>) _</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Handles
 serialport1.DataReceived</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Try</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thread.Sleep(Me._receiveDelay)</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Dim len As Integer = serialport1.BytesToRead</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Me.buffer = New Byte(len - 1) {}</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; serialport1.Read(Me.buffer, 0, len)</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaiseEvent recOK(True)</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Catch ex As Exception</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; showmessage(&quot;Read &quot; &amp; ex.Message)</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; RaiseEvent recOK(False)</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Exit Sub</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; End Try</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ' data from secondary thread</strong><br>
<strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; sc.Post(New SendOrPostCallback(AddressOf doUpdate), Me.buffer)</strong></p>
<p><strong>&nbsp;&nbsp;&nbsp; End Sub</strong></p>
<p><br>
In my sample &nbsp; can set _receiceDelay 1 ... 1000 (ms). As You see it works similiar to Threshold.<br>
The difference is that Threshold needs exact the number of bytes in stream before the handle reacts.<br>
Here not. You have to configure the delay according to the baudrate and the lenght of the input buffer</p>
<p>Usage of the SerialPort.ReadBufferSize Property (Windows buffer)<br>
see : <a href="http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.readbuffersize">
http://msdn.microsoft.com/en-us/library/system.io.ports.serialport.readbuffersize</a></p>
<p>&nbsp;</p>
<h1>Review</h1>
<p>Bug No Comport on system 2012-07-14</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>regards Ellen</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
