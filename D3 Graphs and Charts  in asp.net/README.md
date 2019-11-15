# D3 Graphs and Charts  in asp.net
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- JSON
- jQuery
- Javascript
- Json.NET
- d3
- Data Driven Document
## Topics
- D3 in asp.net
- Data Driven Document in asp.net
## Updated
- 05/19/2014
## Description

<h1>Introduction</h1>
<p><strong>D3</strong> allows you to bind arbitrary data to a Document Object Model (DOM), and then apply data-driven transformations to the document. For example, you can use D3 to generate an HTML table from an array of numbers. Or, use the same data to create
 an interactive SVG bar chart with smooth transitions and interaction.</p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p><em>For using d3 charts and graphs it requires data in <strong>json </strong>file format. Here, you can easily find flare.json file in this sample.<br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><strong>D3.js</strong> is a JavaScript library for manipulating documents based on data.
<strong>D3</strong> helps you bring data to life using HTML, SVG and CSS. D3&rsquo;s emphasis on web standards gives you the full capabilities of modern browsers without tying yourself to a proprietary framework, combining powerful visualization components
 and a data-driven approach to DOM manipulation.</p>
<p>Download the latest version <span id="version">(3.4.7)</span> here:</p>
<ul>
<li><a id="download" href="https://github.com/mbostock/d3/releases/download/v3.4.7/d3.zip">d3.zip</a>
</li></ul>
<p>Or, to link directly to the latest release, copy this snippet:</p>
<pre><code class="html xml"><span class="tag">&lt;<span class="title">script</span> <span class="attribute">src</span>=<span class="value">&quot;http://d3js.org/d3.v3.min.js&quot;</span> <span class="attribute">charset</span>=<span class="value">&quot;utf-8&quot;</span>&gt;</span><span class="tag">&lt;/<span class="title">script</span>&gt;<br><br>It Contains <br>1) Circle Packing<br><img id="114826" src="http://i1.code.msdn.s-msft.com/d3-graphs-and-charts-in-4146e258/image/file/114826/1/1.png" alt="" width="321" height="297"><br>2) Zoomable Pack Layout<br><img id="114827" src="http://i1.code.msdn.s-msft.com/d3-graphs-and-charts-in-4146e258/image/file/114827/1/3.png" alt="" width="242" height="241"><br>3) Sun Burst<br><img id="114828" src="http://i1.code.msdn.s-msft.com/d3-graphs-and-charts-in-4146e258/image/file/114828/1/2.png" alt="" width="226" height="214"><br><br>It is the sample of javascript file for Circle Packing</span></code></pre>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;diameter&nbsp;=&nbsp;<span class="js__num">960</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;format&nbsp;=&nbsp;d3.format(<span class="js__string">&quot;,d&quot;</span>);&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;pack&nbsp;=&nbsp;d3.layout.pack()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.size([diameter&nbsp;-&nbsp;<span class="js__num">4</span>,&nbsp;diameter&nbsp;-&nbsp;<span class="js__num">4</span>])&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.value(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;d.size;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
<span class="js__statement">var</span>&nbsp;svg&nbsp;=&nbsp;d3.select(<span class="js__string">&quot;body&quot;</span>).append(<span class="js__string">&quot;svg&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;width&quot;</span>,&nbsp;diameter)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;height&quot;</span>,&nbsp;diameter)&nbsp;
&nbsp;&nbsp;.append(<span class="js__string">&quot;g&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;transform&quot;</span>,&nbsp;<span class="js__string">&quot;translate(2,2)&quot;</span>);&nbsp;
&nbsp;
d3.json(<span class="js__string">&quot;Resources/flare.json&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(error,&nbsp;root)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;node&nbsp;=&nbsp;svg.datum(root).selectAll(<span class="js__string">&quot;.node&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.data(pack.nodes)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;.enter().append(<span class="js__string">&quot;g&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;class&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;d.children&nbsp;?&nbsp;<span class="js__string">&quot;node&quot;</span>&nbsp;:&nbsp;<span class="js__string">&quot;leaf&nbsp;node&quot;</span>;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;transform&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__string">&quot;translate(&quot;</span>&nbsp;&#43;&nbsp;d.x&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&quot;</span>&nbsp;&#43;&nbsp;d.y&nbsp;&#43;&nbsp;<span class="js__string">&quot;)&quot;</span>;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;node.append(<span class="js__string">&quot;title&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.text(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;d.name&nbsp;&#43;&nbsp;(d.children&nbsp;?&nbsp;<span class="js__string">&quot;&quot;</span>&nbsp;:&nbsp;<span class="js__string">&quot;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;format(d.size));&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;node.append(<span class="js__string">&quot;circle&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;r&quot;</span>,&nbsp;<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;d.r;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;node.filter(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;!d.children;&nbsp;<span class="js__brace">}</span>).append(<span class="js__string">&quot;text&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.attr(<span class="js__string">&quot;dy&quot;</span>,&nbsp;<span class="js__string">&quot;.3em&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.style(<span class="js__string">&quot;text-anchor&quot;</span>,&nbsp;<span class="js__string">&quot;middle&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.text(<span class="js__operator">function</span>&nbsp;(d)&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;d.name.substring(<span class="js__num">0</span>,&nbsp;d.r&nbsp;/&nbsp;<span class="js__num">3</span>);&nbsp;<span class="js__brace">}</span>);&nbsp;
<span class="js__brace">}</span>);&nbsp;
&nbsp;
d3.select(self.frameElement).style(<span class="js__string">&quot;height&quot;</span>,&nbsp;diameter&nbsp;&#43;&nbsp;<span class="js__string">&quot;px&quot;</span>);&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
