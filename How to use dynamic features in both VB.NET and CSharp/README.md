# How to use dynamic features in both VB.NET and CSharp
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Basic .NET
- VB.Net
- Visual C#
## Topics
- Data Binding
- Dynamic
- object
## Updated
- 08/02/2017
## Description

<h1>Introduction</h1>
<p><em>The key word &quot;dynamic&quot; is only for C# to wrap a specific kind of variable like object. And when you use the dynamic value, you cannot get any intellisenses because properties,methods will be automatically invoked. So if you are sure that some object
 MUST have a property or method. You can directly write them one by one, step by step. The compiler won't check any syntaxes until during the running time.</em></p>
<p><strong><em>And in fact for VB.NET, we also have such features, but you should do these things first:</em></strong></p>
<p><strong><em>1) Everything define as an &quot;Object&quot; value.</em></strong></p>
<p><strong><em>2) Close &quot;Option Exclipit&quot; by switching it to &quot;Off&quot; so as to make Visual Basic have the function of Late binding&quot; in &quot;Properties&quot;=&gt;&quot;Compiler&quot;</em></strong></p>
<p><em><img id="176464" src="176464-%e6%8d%95%e8%8e%b7.png" alt="" width="361" height="79"><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>At least VS 2010 (net framework MUST BE 4.0 or later version).</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>1) The 1st senario to use this dynamic value is that you wanna do something like &#43;,-,*,/ (Have you remembered ?). In fact, if you are sure that the generic struct has implemented these overloadable operators, just write them and return a value without type
 checking.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb">&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;dynamic&nbsp;will&nbsp;automtically&nbsp;check&nbsp;whether&nbsp;the&nbsp;generic&nbsp;type&nbsp;supports&nbsp;operators&nbsp;such&nbsp;as&nbsp;&#43;,-,*,/.&nbsp;If&nbsp;Not,&nbsp;exceptions&nbsp;will&nbsp;be&nbsp;thrown&nbsp;out.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;So&nbsp;for&nbsp;dynamic,&nbsp;if&nbsp;we&nbsp;are&nbsp;sure&nbsp;that&nbsp;something&nbsp;has&nbsp;supported&nbsp;some&nbsp;methods&hellip;&hellip;ect.&nbsp;We'RE&nbsp;SURE&nbsp;to&nbsp;directly&nbsp;use&nbsp;that&nbsp;without&nbsp;any&nbsp;intellisenses.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;And&nbsp;it's&nbsp;not&nbsp;an&nbsp;easy&nbsp;task&nbsp;to&nbsp;cope&nbsp;with&nbsp;a&nbsp;generic&nbsp;type&nbsp;with&nbsp;operators,&nbsp;because&nbsp;we&nbsp;don't&nbsp;know&nbsp;whether&nbsp;they&nbsp;have&nbsp;implemented&nbsp;these&nbsp;operators&nbsp;or&nbsp;not.&nbsp;So&nbsp;we&nbsp;have&nbsp;to&nbsp;SUPPOSE&nbsp;they've&nbsp;implemented&nbsp;them.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Add(<span class="visualBasic__keyword">Of</span>&nbsp;T&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;{<span class="visualBasic__keyword">Structure</span>})(<span class="visualBasic__keyword">ByVal</span>&nbsp;num1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;num2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;T&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dnum1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;num1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dnum2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;num2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dnum1&nbsp;&#43;&nbsp;dnum2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p><span style="font-size:10px">2) For C# or VB.NET, we can also use ExpendoObject, which ONLY supports for dynamic properties, methods by dynamically attaching it.</span></p>
<p>Notice that I used IDictionary&lt;string,value&gt; is to wrap the passed parameter values as &quot;Property-Value&quot; pair. And then dynamically attach them to the ExpendoObject.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Dynamically&nbsp;attaching&nbsp;Properties,&nbsp;Events,&nbsp;Functions&nbsp;into&nbsp;an&nbsp;ExpandoObject</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;DynamicObjectCreator(<span class="visualBasic__keyword">ByVal</span>&nbsp;propertyValuesMapping&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>))&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dynamicObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;ExpandoObject()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;item&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;propertyValuesMapping&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dynamicObj(item.Key)&nbsp;=&nbsp;item.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;dynamicObj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span></pre>
</div>
</div>
</div>
<p>3) The last example is a little complicated. It has shown you to customize your own &quot;Dynamic Object&quot; by inherting from DynamicObject from overwriting some speicifc methods.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Dynamic&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.CompilerServices&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.InteropServices&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;CSharpDynamicUnitTest&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;CustomizedDynamicObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;DynamicObject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Allowed&nbsp;simple&nbsp;types&nbsp;to&nbsp;be&nbsp;called&nbsp;directly&nbsp;with&nbsp;&quot;ToString()&quot;&nbsp;in&nbsp;the&nbsp;&quot;GetRealString&quot;.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">ReadOnly</span>&nbsp;_allowedTypes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Type()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;We&nbsp;use&nbsp;a&nbsp;Name-Value&nbsp;collection&nbsp;so&nbsp;that&nbsp;we&nbsp;can&nbsp;mock&nbsp;an&nbsp;object&nbsp;in&nbsp;javascript.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_propertyValuesCollection&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IDictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CustomizedDynamicObject._allowedTypes&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Type()&nbsp;{<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Integer</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">UInteger</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Long</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">ULong</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Single</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Double</span>),&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">Decimal</span>)}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetDynamicMemberNames()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Keys&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;will&nbsp;check&nbsp;whether&nbsp;the&nbsp;current&nbsp;looped&nbsp;value&nbsp;Is&nbsp;of&nbsp;simple&nbsp;type,&nbsp;an&nbsp;IEnumerable&nbsp;value&nbsp;Or&nbsp;something&nbsp;else.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;1)&nbsp;For&nbsp;simple&nbsp;types&nbsp;such&nbsp;as&nbsp;string,&nbsp;numeric&nbsp;types,&nbsp;directly&nbsp;call&nbsp;ToString.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;2)&nbsp;For&nbsp;any&nbsp;array&nbsp;type&nbsp;that&nbsp;implements&nbsp;IEnumerable,&nbsp;we&nbsp;can&nbsp;just&nbsp;use&nbsp;&quot;[]&quot;&nbsp;to&nbsp;output&nbsp;each&nbsp;value.&nbsp;Considering&nbsp;that&nbsp;each&nbsp;value&nbsp;in&nbsp;the&nbsp;array&nbsp;may&nbsp;vary,&nbsp;so&nbsp;a&nbsp;recursive&nbsp;Is&nbsp;a&nbsp;MUST&nbsp;here.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetRealString(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;str&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(value.[<span class="visualBasic__keyword">GetType</span>]()&nbsp;=&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;<span class="visualBasic__keyword">String</span>.Concat(<span class="visualBasic__string">&quot;'&quot;</span>,&nbsp;value.ToString(),&nbsp;<span class="visualBasic__string">&quot;'&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;(Array.IndexOf(<span class="visualBasic__keyword">Of</span>&nbsp;Type)(CustomizedDynamicObject._allowedTypes,&nbsp;value.[<span class="visualBasic__keyword">GetType</span>]())&nbsp;=&nbsp;-<span class="visualBasic__number">1</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;p&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerable&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(value,&nbsp;IEnumerable)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(p&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;value.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sbu&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;accessor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerator&nbsp;=&nbsp;p.GetEnumerator()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;[&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(accessor.MoveNext())&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">Me</span>.GetRealString(accessor.Current))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;accessor.MoveNext()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">Me</span>.GetRealString(accessor.Current))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;]&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;sbu.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;value.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;str&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;will&nbsp;output&nbsp;a&nbsp;string&nbsp;value&nbsp;as&nbsp;a&nbsp;simple&nbsp;json&nbsp;formation.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Notice&nbsp;the&nbsp;algorithm&nbsp;will&nbsp;call&nbsp;GetRealString,&nbsp;And&nbsp;GetRealString&nbsp;will&nbsp;call&nbsp;the&nbsp;method&nbsp;by&nbsp;exchange&nbsp;recursive.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;A&nbsp;simple&nbsp;js-based&nbsp;object.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ToString()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;current&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sbu&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;StringBuilder&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringBuilder(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Count)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;{&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Count&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;pointer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IEnumerator(<span class="visualBasic__keyword">Of</span>&nbsp;KeyValuePair(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>))&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.GetEnumerator()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(pointer.MoveNext())&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;key&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;current.Key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">String</span>.Concat(key,&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.GetRealString(current.Value)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;pointer.MoveNext()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;,&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;str&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;current.Key&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;current&nbsp;=&nbsp;pointer.Current&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__keyword">String</span>.Concat(str,&nbsp;<span class="visualBasic__string">&quot;:&quot;</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.GetRealString(current.Value)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">While</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sbu.Append(<span class="visualBasic__string">&quot;}&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;sbu.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;This&nbsp;method&nbsp;means&nbsp;you&nbsp;can&nbsp;exclipitly&nbsp;convert&nbsp;the&nbsp;dynamic&nbsp;value&nbsp;to&nbsp;a&nbsp;string&nbsp;by&nbsp;assigning&nbsp;it.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Notice&nbsp;that&nbsp;this&nbsp;only&nbsp;supports&nbsp;converted&nbsp;to&nbsp;string.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryConvert(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ConvertBinder,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(binder.Type&nbsp;=&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryDeleteIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DeleteIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>())&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Remove(indexes(<span class="visualBasic__number">0</span>).ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryDeleteMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DeleteMemberBinder)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.Remove(binder.Name)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GetIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>(),&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.TryGetValueByKey(indexes(<span class="visualBasic__number">0</span>).ToString(),&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Fetch&nbsp;the&nbsp;existing&nbsp;member.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;binder&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;contenxt&nbsp;binder&nbsp;where&nbsp;we&nbsp;can&nbsp;get&nbsp;the&nbsp;inputted&nbsp;properties&nbsp;names.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;param&nbsp;name=&quot;result&quot;&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;The&nbsp;result&nbsp;as&nbsp;a&nbsp;return&nbsp;type&nbsp;for&nbsp;the&nbsp;assigned&nbsp;property&nbsp;value.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;true:&nbsp;Successfully&nbsp;assigned.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;false:&nbsp;exception&nbsp;will&nbsp;be&nbsp;thrown&nbsp;out.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;GetMemberBinder,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.TryGetValueByKey(binder.Name,&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TryGetValueByKey(<span class="visualBasic__keyword">ByVal</span>&nbsp;keyName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;&lt;Out&gt;&nbsp;<span class="visualBasic__keyword">ByRef</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;isSuccess&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(<span class="visualBasic__keyword">Me</span>._propertyValuesCollection.ContainsKey(keyName))&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection(keyName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;result&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;isSuccess&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;isSuccess&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetIndex(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SetIndexBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;indexes&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>(),&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;flag&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.TrySetValueByKey(indexes(<span class="visualBasic__number">0</span>).ToString(),&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetMember(<span class="visualBasic__keyword">ByVal</span>&nbsp;binder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;SetMemberBinder,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">Me</span>.TrySetValueByKey(binder.Name,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrySetValueByKey(<span class="visualBasic__keyword">ByVal</span>&nbsp;keyName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._propertyValuesCollection(keyName)&nbsp;=&nbsp;result&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span></pre>
</div>
</div>
</div>
<p>4) Here're the test cases:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">编辑脚本</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;Microsoft.VisualStudio.TestTools.UnitTesting&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;
&nbsp;
<span class="visualBasic__keyword">Namespace</span>&nbsp;CSharpDynamicUnitTest&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestClass&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;DynamicKeyWordUnitTest&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestMethod&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DynamicallyAddPropertiesMethodsAndEvents()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;strs&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Dictionary(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">Object</span>)()&nbsp;From&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;NumberOne&quot;</span>,&nbsp;<span class="visualBasic__number">1</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;StringValue&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;Hello&nbsp;World!&quot;</span>},&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{<span class="visualBasic__string">&quot;Add&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Func(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">Double</span>,&nbsp;<span class="visualBasic__keyword">Double</span>)(<span class="visualBasic__keyword">Function</span>(n1,&nbsp;n2)&nbsp;n1&nbsp;&#43;&nbsp;n2)}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nums&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__number">5</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;strs.Add(<span class="visualBasic__string">&quot;EventDelegate&quot;</span>,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Action(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__keyword">Sub</span>(num&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;nums.Add(num)))&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;d&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;DynamicObjectCreator(strs)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Do&nbsp;late&nbsp;binding</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.NumberCheckingLoop&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Action(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;<span class="visualBasic__keyword">Integer</span>)(<span class="visualBasic__keyword">Sub</span>(num1,&nbsp;num2)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;num1&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;num2&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;(i&nbsp;<span class="visualBasic__keyword">Mod</span>&nbsp;<span class="visualBasic__number">2</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.EventDelegate.DynamicInvoke(i)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">1</span>,&nbsp;d.NumberOne)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__string">&quot;Hello&nbsp;World!&quot;</span>,&nbsp;d.StringValue)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;Here&nbsp;we&nbsp;must&nbsp;use&nbsp;DynamicInvoke,&nbsp;because&nbsp;in&nbsp;VB.NET</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;we&nbsp;cannot&nbsp;directly&nbsp;call&nbsp;a&nbsp;Function&nbsp;or&nbsp;an&nbsp;Action&nbsp;by&nbsp;adding&nbsp;a&nbsp;pair&nbsp;of&nbsp;&quot;()&quot;&nbsp;with&nbsp;parameters&nbsp;in&nbsp;C#,&nbsp;because&nbsp;this&nbsp;will&nbsp;be&nbsp;reguarded&nbsp;as&nbsp;an&nbsp;expression</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">3.0</span>,&nbsp;d.Add.DynamicInvoke(<span class="visualBasic__number">1.0</span>,&nbsp;<span class="visualBasic__number">2.0</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.NumberCheckingLoop.DynamicInvoke(<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__number">10</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__number">5</span>,&nbsp;nums.Count)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TestMethod&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DynamicallyTestForDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;a&nbsp;basic&nbsp;simple&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;d&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.a&nbsp;=&nbsp;<span class="visualBasic__string">&quot;a&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.b&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;a&nbsp;nest&nbsp;object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;nestObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.d&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.e&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.array&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Integer</span>()&nbsp;{<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__number">2</span>,&nbsp;<span class="visualBasic__number">3</span>,&nbsp;<span class="visualBasic__number">4</span>,&nbsp;<span class="visualBasic__number">5</span>,&nbsp;<span class="visualBasic__number">6</span>}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Define&nbsp;an&nbsp;obj&nbsp;array</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dArrayObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">Object</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">5</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dObj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;CustomizedDynamicObject()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dObj.f&nbsp;=&nbsp;i&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dObj.g&nbsp;=&nbsp;i.ToString()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dArrayObj.Add(dObj)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nestObj.objArray&nbsp;=&nbsp;dArrayObj&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;d.c&nbsp;=&nbsp;nestObj&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''Do&nbsp;an&nbsp;implicit&nbsp;conversion</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;result&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;CTypeDynamic(d,&nbsp;<span class="visualBasic__keyword">GetType</span>(<span class="visualBasic__keyword">String</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Assert.AreEqual(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)(<span class="visualBasic__string">&quot;{a:'a',b:1,c:{d:1,e:2,array:[1,2,3,4,5,6],objArray:[{f:1,g:'1'},{f:2,g:'2'},{f:3,g:'3'},{f:4,g:'4'},{f:5,g:'5'}]}}&quot;</span>,&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Namespace</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
