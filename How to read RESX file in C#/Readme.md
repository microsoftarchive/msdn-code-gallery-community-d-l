# How to read RESX file in C#
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET
- Visual Studio 2012
## Topics
- C#
- Performance
- Visual Studio
- RESX
## Updated
- 07/21/2016
## Description

<p><span style="font-size:small">In this article you will learn how we can read a RESX file in our application using c#. I hope you will like it.<br>
</span></p>
<p><span style="font-size:small">Background</span></p>
<p><span style="font-size:small">Few days back I used a RESX file inmy application and I have set some error codes and details in it. It worked like a charm. So I thought of sharing you a demo of how we can use RESX file in our application.</span></p>
<p><span style="font-size:small">What RESX file is?</span></p>
<li><span style="font-size:small">The .resx resource file format consists of XML entries</span>
</li><li><span style="font-size:small">These XML entries specify objects and strings inside XML tags</span>
</li><li><span style="font-size:small">It can be easily manipulated</span>
<p><span style="font-size:small">Using the code</span></p>
<p><span style="font-size:small">To start with, you need to create a web application. Here I am using Visual Studio 2012 and C# as the language.</span><br>
<span style="font-size:small">Once you created the application, you need to create a RESX file by clicking the &ldquo;New Item&rdquo;</span></p>
<p><span style="font-size:small"><img src="-usingresxfileincsharp1.png" alt=""></span></p>
<p><span style="font-size:small"><img src="-usingresxfileincsharp2.png" alt=""></span></p>
<p><span style="font-size:small">Now you can see a new file in your solution explorer named Resource1.resx</span></p>
<p><span style="font-size:small"><img src="-usingresxfileincsharp3.png" alt=""></span></p>
<p><span style="font-size:small">So our RESX file is ready right? Now we can set some values to that.&nbsp;You can see the values I set to my RESX file in the preceding image.</span></p>
<p><span style="font-size:small"><img src="-usingresxfileincsharp4.png" alt=""></span></p>
<p><span style="font-size:small">Now add a web page and go to the code behind by right click&#43;view code . What you need to do next is, adding needed namespaces. You can find out them from the preceding code block.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_829970">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System.Reflection;
using System.Resources;
using System.Globalization;
</pre>
<div class="preview">
<pre class="js">using&nbsp;System.Reflection;&nbsp;
using&nbsp;System.Resources;&nbsp;
using&nbsp;System.Globalization;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">Once it is done, you are ready to go. Please paste the below mentioned code in your page load.</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_474100">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ResourceManager rm = new ResourceManager(&quot;UsingRESX.Resource1&quot;,
                Assembly.GetExecutingAssembly());
            String strWebsite = rm.GetString(&quot;Website&quot;,CultureInfo.CurrentCulture);
            String strName = rm.GetString(&quot;Name&quot;);
            form1.InnerText = &quot;Website: &quot; &#43; strWebsite &#43; &quot;--Name: &quot; &#43; strName;
</pre>
<div class="preview">
<pre class="js">ResourceManager&nbsp;rm&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ResourceManager(<span class="js__string">&quot;UsingRESX.Resource1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assembly.GetExecutingAssembly());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;strWebsite&nbsp;=&nbsp;rm.GetString(<span class="js__string">&quot;Website&quot;</span>,CultureInfo.CurrentCulture);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">String</span>&nbsp;strName&nbsp;=&nbsp;rm.GetString(<span class="js__string">&quot;Name&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;form1.InnerText&nbsp;=&nbsp;<span class="js__string">&quot;Website:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;strWebsite&nbsp;&#43;&nbsp;<span class="js__string">&quot;--Name:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;strName;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<p><span style="font-size:small">So in the above code block we are getting the values of &ldquo;Name&rdquo; and &ldquo;Website&rdquo; which we have already set in the RESX file. Cool right?</span></p>
<div>
<div class="syntaxhighlighter csharp" id="highlighter_404127">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">ResourceManager rm = new ResourceManager(&quot;UsingRESX.Resource1&quot;,
                Assembly.GetExecutingAssembly());</pre>
<div class="preview">
<pre class="js">ResourceManager&nbsp;rm&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ResourceManager(<span class="js__string">&quot;UsingRESX.Resource1&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assembly.GetExecutingAssembly());</pre>
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
<p><span style="font-size:small">In the above mentioned code block we are setting our Resource file to the ResourceManager class. Please be noted that in&nbsp;<em>UsingRESX.Resource1</em>,&nbsp;<em>UsingRESX</em>&nbsp;is my project base name and<em>Resource1</em>&nbsp;is
 my resource file name. The function&nbsp;<em>GetString</em>&nbsp;is used to read the resource file properties.&nbsp;</span></p>
<p><span style="font-size:small">Output</span></p>
<p><span style="font-size:small">Now it is time to see the output.</span></p>
<p><span style="font-size:small"><img src="-usingresxfileincsharp5.png" alt=""></span></p>
</li>