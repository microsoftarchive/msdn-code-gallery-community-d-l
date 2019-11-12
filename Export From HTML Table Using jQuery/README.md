# Export From HTML Table Using jQuery
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- jQuery
- HTML
- HTML5
- CSS
- export to excel
- jQuery UI
## Topics
- jQuery
- HTML
- export to csv
- export to excel
- Data Export
- Export to Word
- Export to Pdf
## Updated
- 07/04/2016
## Description

<p><span style="font-size:small">In this article we will see how to export from an HTML table using jQuery. We all work in some applications where we are playing with data&rsquo;s . It might be some data returned by the server or it might be some client side
 data like HTML table. No matter which ever form the data is, there will be an export option. Isn&rsquo;t it? 80% of our clients need the data to be exported as excel. So we need to give the option to export the given data to excel, not dependent of the data
 format. In my case my data is in the form of an HTML table, so in this post we will explain how to export an html data to excel, pdf, png, jpeg etc. I hope you will like it.<br>
</span></p>
<p><strong><span style="font-size:small">Background</span></strong></p>
<p><span style="font-size:small">As I said earlier, this article explains how to export a HTML table using jQuery. In this article we will see how we can export the given data to the following formats:</span></p>
<li><span style="font-size:small">Excel</span> </li><li><span style="font-size:small">PDF</span> </li><li><span style="font-size:small">Image</span> </li><li><span style="font-size:small">CSV</span> </li><li><span style="font-size:small">PPT</span> </li><li><span style="font-size:small">Word</span> </li><li><span style="font-size:small">TXT</span> </li><li><span style="font-size:small">XML</span>
<p><span style="font-size:small">You can always see other exporting related articles here.</span></p>
</li><li><span style="font-size:small"><a href="http://sibeeshpassion.com/export-hierarchical-multi-level-html-table-with-styles-using-jquery/" target="_blank">Export Hierarchical (Multi-Level) HTML Table</a></span>
</li><li><span style="font-size:small"><a href="http://sibeeshpassion.com/compress-xml-string-variables-in-client-side-and-export-in-html5-using-jquery/" target="_blank">Compress And Export</a></span>
<p><strong><span style="font-size:small">Why</span></strong></p>
<p><span style="font-size:small">In my project, we are doing 80% of our work in the client side. So I decided to implement the export feature in the client side itself. The same can be done using server-side code also but I prefer the client-side one.</span></p>
<p><span style="font-size:small">What you must know</span></p>
</li><li><span style="font-size:small"><a href="http://jquery.com/" target="_blank">jQuery</a></span>
</li><li><span style="font-size:small"><a href="http://www.w3schools.com/js/" target="_blank">JavaScript</a></span>
</li><li><span style="font-size:small"><a href="http://www.w3schools.com/css/css3_intro.asp" target="_blank">CSS 3</a></span>
</li><li><span style="font-size:small"><a href="http://www.w3schools.com/html/" target="_blank">HTML</a></span>
</li><li><span style="font-size:small"><a href="http://www.tutorialspoint.com/jquery/jquery-dom.htm" target="_blank">DOM Manipulations in jQuery</a></span>
<p><strong><span style="font-size:small">Using the code</span></strong></p>
<p><span style="font-size:small">Before you start, you need to download the necessary files from:&nbsp;<a href="https://github.com/kayalshri/tableExport.jquery.plugin" target="_blank">TableExport.jquery.plugin</a>.</span></p>
<p><span style="font-size:small">Once you have download the files, you need to include those in your project. Here I am using a MVC4 web application.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_972419">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>jquery<span class="js__num">-1.9</span><span class="js__num">.1</span>.js&rdquo;&gt;&lt;/script&gt;&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>tableExport.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;export&nbsp;feature&nbsp;*@&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>jquery.base64.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;convert&nbsp;the&nbsp;content&nbsp;to&nbsp;base64&nbsp;&nbsp;*@&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>html2canvas.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;export&nbsp;to&nbsp;image&nbsp;feature&nbsp;*@&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>jspdf/libs/base64.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;&nbsp;convert&nbsp;the&nbsp;content&nbsp;to&nbsp;base64&nbsp;<span class="js__statement">for</span>&nbsp;pdf&nbsp;*@&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>jspdf/libs/sprintf.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;export&nbsp;feature&nbsp;<span class="js__statement">for</span>&nbsp;pdf&nbsp;*@&nbsp;
&lt;script&nbsp;src=&ldquo;~<span class="js__reg_exp">/Contents/</span>jspdf/jspdf.js&rdquo;&gt;&lt;/script&gt;&nbsp;@*Main&nbsp;file&nbsp;which&nbsp;does&nbsp;export&nbsp;feature&nbsp;<span class="js__statement">for</span>&nbsp;pdf&nbsp;*@</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Let&rsquo;s say you have an HTML table as follows:</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_110521">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;table&nbsp;id=&ldquo;activity&rdquo;&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Name&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Activity&nbsp;on&nbsp;Code&nbsp;Project&nbsp;(%)&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Activity&nbsp;on&nbsp;C#&nbsp;Corner&nbsp;(%)&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;Activity&nbsp;on&nbsp;Asp&nbsp;Forum&nbsp;(%)&lt;/th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/thead&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tbody&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;Sibeesh&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">100</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">98</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">80</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;Ajay&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">90</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">0</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">50</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;Ansary&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">100</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">20</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">10</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;Aghil&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">0</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">30</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">90</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;Arya&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">0</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">0</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&gt;<span class="js__num">95</span>&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tbody&gt;&nbsp;
&lt;/table&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Add some more UI elements for firing the click events.</span></p>
<div>
<div class="syntaxhighlighter xml" id="highlighter_694096">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;table&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&nbsp;id=&ldquo;footerExport&rdquo;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportexcel&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>xls.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;Excel&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportpdf&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>pdf.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;PDF&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportimage&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>png.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;PNG&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportcsv&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>csv.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;CSV&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportword&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>word.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;Word&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exporttxt&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>txt.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;TXT&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportxml&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>xml.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;XML&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;id=&ldquo;exportppt&rdquo;&gt;&lt;img&nbsp;src=&ldquo;~<span class="js__reg_exp">/icons/</span>ppt.png&rdquo;&nbsp;title=&ldquo;Export&nbsp;to&nbsp;PPT&rdquo;&nbsp;<span class="js__reg_exp">/&gt;&lt;/</span>td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&lt;/table&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Add a few styles to the table to make it viewable.</span></p>
<div>
<div class="syntaxhighlighter css" id="highlighter_661673"><br>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>CSS</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">css</span>

<div class="preview">
<pre class="js"><style> 
    #activity <span class="js__brace">{</span> 
        text-align:center;border:1px solid #ccc; 
    <span class="js__brace">}</span> 
    #activity td<span class="js__brace">{</span> 
        text-align:center;border:1px solid #ccc; 
    <span class="js__brace">}</span> 
     #footerExport td<span class="js__brace">{</span> 
       cursor:pointer; 
       text-align:center;border:1px solid #ccc; 
       border:none; 
    <span class="js__brace">}</span> 
</style></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Now it is time to fire our events.&nbsp;You can do that as in the following.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_747116">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js">&lt;script&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportexcel&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;excel&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportpdf&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;pdf&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportimage&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;png&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportcsv&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;csv&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportppt&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;powerpoint&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportxml&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;xml&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exportword&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;doc&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#exporttxt&rsquo;).bind(&lsquo;click&rsquo;,&nbsp;<span class="js__operator">function</span>&nbsp;(e)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;txt&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&lt;/script&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><span style="font-size:small">Please note that you can export to a few more formats in the same way. You can learn more here:tableExport.jquery.plugin.</span></p>
<p><span style="font-size:small">Explanation</span></p>
<p><span style="font-size:small">Now its time go deeper into that plugin. In the downloaded files you can see a file called tableExport.js. just open that file, you can see some conditions for specific formats. And the default property for exporting as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_552856">
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td class="gutter">
<div class="line number1 index0 alt2"></div>
</td>
<td class="code">
<div class="container"></div>
</td>
</tr>
</tbody>
</table>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;defaults&nbsp;=&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;separator:&nbsp;&lsquo;,&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ignoreColumn:&nbsp;[],&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tableName:&lsquo;yourTableName&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&lsquo;csv&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfFontSize:<span class="js__num">7</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pdfLeftMargin:<span class="js__num">20</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;escape:&lsquo;true&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;htmlContent:&lsquo;false&rsquo;,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;consoleLog:&lsquo;false&rsquo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">You can change these properties depending on your needs as follows.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_742674">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;varpdfFontSize=&nbsp;&lsquo;<span class="js__num">7</span>&rsquo;;&nbsp;
$(&lsquo;#activity&rsquo;).tableExport(<span class="js__brace">{</span>&nbsp;type:&nbsp;&lsquo;excel&rsquo;,&nbsp;escape:&nbsp;&lsquo;false&rsquo;,pdfFontSize:varpdfFontSize<span class="js__brace">}</span>);&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">You can try all the properties listed above like this :).</span></p>
<p><span style="font-size:small">Now in that file you can see an if else if condition that is satisfied for multiple formats. Let me explain for Excel formatting alone.</span></p>
<div>
<div class="syntaxhighlighter jscript" id="highlighter_920229">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span>

<div class="preview">
<pre class="js"><span class="js__statement">var</span>&nbsp;excel=&ldquo;&lt;table&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Header</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(el).find(&lsquo;thead&rsquo;).find(&lsquo;tr&rsquo;).each(<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&ldquo;&lt;tr&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).filter(&lsquo;:visible&rsquo;).find(&lsquo;th&rsquo;).each(<span class="js__operator">function</span>(index,data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($(<span class="js__operator">this</span>).css(&lsquo;display&rsquo;)&nbsp;!=&nbsp;&lsquo;none&rsquo;)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(defaults.ignoreColumn.indexOf(index)&nbsp;==&nbsp;-<span class="js__num">1</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&ldquo;&lt;td&gt;&rdquo;&nbsp;&#43;&nbsp;parseString($(<span class="js__operator">this</span>))&#43;&nbsp;&ldquo;&lt;/td&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&lsquo;&lt;/tr&gt;&rsquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Row&nbsp;Vs&nbsp;Column</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rowCount=<span class="js__num">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(el).find(&lsquo;tbody&rsquo;).find(&lsquo;tr&rsquo;).each(<span class="js__operator">function</span>()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&ldquo;&lt;tr&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;colCount=<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__operator">this</span>).filter(&lsquo;:visible&rsquo;).find(&lsquo;td&rsquo;).each(<span class="js__operator">function</span>(index,data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($(<span class="js__operator">this</span>).css(&lsquo;display&rsquo;)&nbsp;!=&nbsp;&lsquo;none&rsquo;)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(defaults.ignoreColumn.indexOf(index)&nbsp;==&nbsp;-<span class="js__num">1</span>)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&ldquo;&lt;td&gt;&rdquo;&#43;parseString($(<span class="js__operator">this</span>))&#43;&ldquo;&lt;/td&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;colCount&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rowCount&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&lsquo;&lt;/tr&gt;&rsquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excel&nbsp;&#43;=&nbsp;&lsquo;&lt;/table&gt;&rsquo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>(defaults.consoleLog&nbsp;==&nbsp;&lsquo;true&rsquo;)<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.log(excel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;excelFile&nbsp;=&nbsp;&ldquo;&lt;html&nbsp;xmlns:o=&rsquo;urn:schemas-microsoft-com:office:office&rsquo;&nbsp;xmlns:x=&rsquo;urn:schemas-microsoft-com:office:&rdquo;&#43;defaults.type&#43;&ldquo;&lsquo;&nbsp;xmlns=&rsquo;http:<span class="js__sl_comment">//www.w3.org/TR/REC-html40&prime;&gt;&rdquo;;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;head&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;!&ndash;[<span class="js__statement">if</span>&nbsp;gte&nbsp;mso&nbsp;<span class="js__num">9</span>]&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;xml&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:ExcelWorkbook&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:ExcelWorksheets&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:ExcelWorksheet&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:Name&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;<span class="js__brace">{</span>worksheet<span class="js__brace">}</span>&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/x:Name&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:WorksheetOptions&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;x:DisplayGridlines/&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/x:WorksheetOptions&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/x:ExcelWorksheet&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/x:ExcelWorksheets&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/x:ExcelWorkbook&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/xml&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;![endif]&ndash;&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/head&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;body&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;excel;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/body&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;excelFile&nbsp;&#43;=&nbsp;&ldquo;&lt;/html&gt;&rdquo;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;base64data&nbsp;=&nbsp;&ldquo;base64,&rdquo;&nbsp;&#43;&nbsp;$.base64.encode(excelFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;window.open(&lsquo;data:application/vnd.ms-&lsquo;&#43;defaults.type&#43;&lsquo;;filename=exportData.doc;&rsquo;&nbsp;&#43;&nbsp;base64data);</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<br>
<table border="0" cellspacing="0" cellpadding="0">
<tbody>
</tbody>
</table>
</div>
</div>
<p><strong><span style="font-size:small">Procedure</span></strong></p>
<p><span style="font-size:small">Find the UI element (in this case it is our HTML table).</span></p>
<p><span style="font-size:small">Loop through the rows of the thread for the header information.</span></p>
<p><span style="font-size:small">Apply a filter to avoid the UI elements that has a display as none&nbsp;<em>(filter(&lsquo;:visible&rsquo;))</em>.</span></p>
<p><span style="font-size:small">If the UI is visible, append it to the variable&nbsp;<em>(excel &#43;= &ldquo;&rdquo; &#43; parseString($(this))&#43; &ldquo;</em></span></p>
<p><span style="font-size:small"><em>&rdquo;;)</em>The same procedure is done for the row vs column values also. The only difference is, here we are looping through the tbody instead of thread.</span></p>
<p><span style="font-size:small">After the data is manipulated, data is formulated in the Excel format.</span><br>
<span style="font-size:small">You can learn more in the attachment.</span></p>
<p><span style="font-size:small">Output</span></p>
<div class="wp-caption x_alignnone" id="attachment_10926"><span style="font-size:small"><a href="http://sibeeshpassion.com/wp-content/uploads/2014/10/export.png"><img class="size-full x_wp-image-10926" src="-export.png" alt="Export From HTML Table" width="290" height="100"></a>
</span>
<p class="wp-caption-text"><span style="font-size:small">Export From HTML Table</span></p>
</div>
<h1></h1>
</li>