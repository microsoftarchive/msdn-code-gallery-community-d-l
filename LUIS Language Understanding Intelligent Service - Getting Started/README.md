# LUIS Language Understanding Intelligent Service - Getting Started
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- Cognitive Services
- LUIS
## Topics
- C#
- Cognitive Services
- LUIS
## Updated
- 07/28/2016
## Description

<h1>Introduction</h1>
<p><em>Interfaceing with LUIS is not extremely complicated.&nbsp; Consuming the interface is as simple as interfacing with any Web API that returns a JSON file.&nbsp; The interesting find I had was what I needed to do to get LUIS to get information from the
 user so that thier question could then be answered.</em></p>
<p><em>Like we all know, in most cases an initial question does not contain all the information required to make a educated answer, so questions to get that information are required and LUIS can do that.</em></p>
<p><em>This code example shows how you can accomplish this.<br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>To get the sampleto work you need to do 2 things: </em></p>
<p><em>1.&nbsp;&nbsp;Update the LUIS ID and LUIS KEY with yours within the askLUIS(string question, string contextId)</em></p>
<p><em>2. In the solution you will find a DEFAULT.json file which is an extract of my sample LUIS project.&nbsp; You need to IMPORT it into your LUIS console here:&nbsp;
<a href="https://www.luis.ai/applicationlist">https://www.luis.ai/applicationlist</a>
</em><em><br>
</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>I have written a blog that discusses more about this project here:&nbsp; <a href="https://blogs.msdn.microsoft.com/benjaminperkins/tag/bot">
https://blogs.msdn.microsoft.com/benjaminperkins/tag/bot</a> , it will be published on 1-AUG-2016</em><em>&nbsp;</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">while</span>&nbsp;(luisResponse?.dialog?.prompt?.Length&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Write(luisResponse.dialog.prompt&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&nbsp;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;contextId&nbsp;=&nbsp;luisResponse.dialog.contextId;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;question&nbsp;=&nbsp;question&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Task.Run(async&nbsp;()&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;luisResponse&nbsp;=&nbsp;await&nbsp;askLUIS(question,&nbsp;contextId);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine(JsonConvert.SerializeObject(luisResponse));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WriteLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}).Wait();&nbsp;
}&nbsp;
&nbsp;
<span class="cs__com">//-----------------------</span>&nbsp;
<span class="cs__keyword">static</span>&nbsp;async&nbsp;Task&lt;LUISResponse&gt;&nbsp;askLUIS(<span class="cs__keyword">string</span>&nbsp;question,&nbsp;<span class="cs__keyword">string</span>&nbsp;contextId)&nbsp;
{&nbsp;
&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;client&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;HttpClient())&nbsp;
&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;client.BaseAddress&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(<span class="cs__string">&quot;https://api.projectoxford.ai&quot;</span>);<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;PREVIEW</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;id&nbsp;=&nbsp;<span class="cs__string">&quot;ADD&nbsp;YOUR&nbsp;LUID&nbsp;ID&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;subscriptionKey&nbsp;=&nbsp;<span class="cs__string">&quot;ADD&nbsp;THE&nbsp;SUBSCRIPTION&nbsp;KEY&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;requestUri&nbsp;=&nbsp;<span class="cs__string">&quot;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(contextId&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestUri&nbsp;=&nbsp;$<span class="cs__string">&quot;/luis/v1/application/preview?id={id}&amp;subscription-key={subscriptionKey}&amp;q={question}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;requestUri&nbsp;=&nbsp;$<span class="cs__string">&quot;/luis/v1/application/preview?id={id}&amp;subscription-key={subscriptionKey}&amp;q={question}&amp;contextId={contextId}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpResponseMessage&nbsp;response&nbsp;=&nbsp;await&nbsp;client.GetAsync(requestUri);<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion</span>&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;JsonConvert.DeserializeObject&lt;LUISResponse&gt;(await&nbsp;response.Content.ReadAsStringAsync());&nbsp;
&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>Program.cs contains the Main() method where the program is run from</em> </li><li><em><em>LUISResponse.cs is the class that I Deserialize the JSON response into</em></em>
</li><li><em>DEFAULT.json is the exported LUIS application I used for this example</em>
</li></ul>
<h1>More Information</h1>
<p><em>Access LUIS here: <a href="https://www.luis.ai">https://www.luis.ai</a></em></p>
