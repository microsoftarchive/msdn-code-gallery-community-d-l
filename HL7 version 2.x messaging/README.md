# HL7 version 2.x messaging
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Sockets
- Network
## Topics
- healthcare
- Messaging
- Interoperability
- HL7
## Updated
- 07/06/2014
## Description

<h1>
<div class="endscriptcode">&nbsp;</div>
Introduction</h1>
<p>This is an example for a very simple implementation of an HL7 message server. The server waits on a network socket for incoming connections and looks for a valid MLLP frame. When such a data frame has been found the contained data is unpacked and parsed
 into an HL7 message. After the HL7 message has been processed the server sends automatically an acknowledgment back over the network and closes the connection.</p>
<h1><span>Building the Sample</span></h1>
<p>The sample has no dependencies to other libraries. Just build the sample code in Visual Studio. The solution contains one portable class library for parsing and building HL7 version 2.x messages. You can use the library in your own projects. It is licensed
 unter the Apache 2.0 licsense terms.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The example contains a library for parsing text into a HL7 message object. Simply call the method&nbsp;Parse()&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;the&nbsp;string&nbsp;data&nbsp;holds&nbsp;the&nbsp;HL7&nbsp;Version&nbsp;2.x&nbsp;message&nbsp;text&nbsp;&nbsp;</span>&nbsp;
&nbsp;
var&nbsp;msg&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Message();&nbsp;
msg.Parse(data);&nbsp;
&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Parsed&nbsp;message&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;{0}&quot;</span>,&nbsp;msg.MessageType()&nbsp;);&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Message&nbsp;timestamp&nbsp;&nbsp;:&nbsp;{0}&quot;</span>,&nbsp;msg.MessageDateTime()&nbsp;);&nbsp;
Console.WriteLine(<span class="cs__string">&quot;Message&nbsp;control&nbsp;id&nbsp;:&nbsp;{0}&quot;</span>,&nbsp;msg.MessageControlId());</pre>
</div>
</div>
</div>
<p>An HL7 message consists of a sequence of segments. Each segment contains a number of fields, which can be divided even further into smaller parts. The example supports only Segments and Fields, but it is easy to extend.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Create&nbsp;a&nbsp;response&nbsp;message</span>&nbsp;
<span class="cs__com">//</span>&nbsp;
var&nbsp;response&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Message();&nbsp;
&nbsp;
var&nbsp;msh&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Segment(<span class="cs__string">&quot;MSH&quot;</span>);&nbsp;
msh.Field(<span class="cs__number">2</span>,&nbsp;<span class="cs__string">&quot;^~\\&amp;&quot;</span>);&nbsp;
msh.Field(<span class="cs__number">7</span>,&nbsp;DateTime.Now.ToString(<span class="cs__string">&quot;yyyyMMddhhmmsszzz&quot;</span>));&nbsp;
msh.Field(<span class="cs__number">9</span>,&nbsp;<span class="cs__string">&quot;ACK&quot;</span>);&nbsp;
msh.Field(<span class="cs__number">10</span>,&nbsp;Guid.NewGuid().ToString()&nbsp;);&nbsp;
msh.Field(<span class="cs__number">11</span>,&nbsp;<span class="cs__string">&quot;P&quot;</span>);&nbsp;
msh.Field(<span class="cs__number">12</span>,&nbsp;<span class="cs__string">&quot;2.5.1&quot;</span>);&nbsp;
response.Add(msh);&nbsp;
&nbsp;
var&nbsp;msa&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Segment(<span class="cs__string">&quot;MSA&quot;</span>);&nbsp;
msa.Field(<span class="cs__number">1</span>,&nbsp;<span class="cs__string">&quot;AA&quot;</span>);&nbsp;
msa.Field(<span class="cs__number">2</span>,&nbsp;msg.MessageControlId());&nbsp;
response.Add(msa);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<h1>More Information</h1>
<p>Further information about HL7 version 2.x messaging can be found on <a href="http://www.hl7.org">
http://www.hl7.org</a>. Please note that the HL7 organisation has issued several standards and made them publicly available. Further help for implemeting HL7 messaging is provided by the IHE
<a href="http://www.ihe.net">http://www.ihe.net</a>.</p>
