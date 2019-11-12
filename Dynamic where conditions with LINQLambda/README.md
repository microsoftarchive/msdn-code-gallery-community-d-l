# Dynamic where conditions with LINQ/Lambda
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- LINQ
- Lambda Expressions
## Topics
- LINQ to Objects
- Data Access
## Updated
- 08/14/2014
## Description

<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p><span style="font-size:small">This article show how to dynamically create multiple conditions in the where part of a LINQ statement where the key point is we don't know if the user is going to filter on just one field/column or more.&nbsp; If we knew than
 our life is easy. If you search around the Internet it appears that you can only have one where clause, no different than conventional database SQL.</span>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;MexicoOwners&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;T&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;ResultsConventionalLinQ&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Where&nbsp;T.ContactType&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Owner&quot;</span>&nbsp;<span class="visualBasic__keyword">AndAlso</span>&nbsp;T.Country&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Mexico&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;T&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;).ToList.</pre>
</div>
</div>
</div>
<p><span style="font-size:small">The next code block queries a strong typed list with two conditions in the where section. If the user only wanted to filter on one condition we could check then in an if statement use the appropriate statement. That is all well
 and good until you need to do filtering on say a handful of fields in a dynamic manner. LINQ/Lambda is not going to help in the conventional way as we are still restricted similarly are above.</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Dim&nbsp;ResultsConventionalLambda&nbsp;As&nbsp;IEnumerable(Of&nbsp;Customer)&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;T&nbsp;In&nbsp;XDocument.Load(FileName)...&lt;Customer&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;New&nbsp;Customer&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Identifier&nbsp;=&nbsp;T.&lt;CustomerID&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CompanyName&nbsp;=&nbsp;T.&lt;CompanyName&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ContactType&nbsp;=&nbsp;T.&lt;ContactTitle&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Country&nbsp;=&nbsp;T.&lt;Country&gt;.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;).Where(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__object">Function</span>(x)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Return&nbsp;x.ContactType&nbsp;=&nbsp;ContactType&nbsp;AndAlso&nbsp;x.Country&nbsp;=&nbsp;Country&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span>).ToList</pre>
</div>
</div>
</div>
</span>
<p></p>
<p><span style="font-size:small">The solution to make additive where conditions work is extremely simple. Create a LINQ statement that selects your data. Next check which fields/columns the user wants to filter on and simple assign a Lambda statement to the
 original LINQ statement. The code block below is an excert from the attached demostration project<br>
<br>
</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Dim&nbsp;Results&nbsp;As&nbsp;IEnumerable(Of&nbsp;Customer)&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;From&nbsp;T&nbsp;In&nbsp;XDocument.Load(FileName)...&lt;Customer&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Select&nbsp;New&nbsp;Customer&nbsp;With&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Identifier&nbsp;=&nbsp;T.&lt;CustomerID&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CompanyName&nbsp;=&nbsp;T.&lt;CompanyName&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ContactType&nbsp;=&nbsp;T.&lt;ContactTitle&gt;.Value,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Country&nbsp;=&nbsp;T.&lt;Country&gt;.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
&nbsp;
If&nbsp;Not&nbsp;CompanyName.Equals(<span class="js__string">&quot;All&quot;</span>)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Results&nbsp;=&nbsp;Results.Where(<span class="js__object">Function</span>(x)&nbsp;x.CompanyName&nbsp;=&nbsp;CompanyName)&nbsp;
End&nbsp;If&nbsp;
&nbsp;
If&nbsp;Not&nbsp;ContactType.Equals(<span class="js__string">&quot;All&quot;</span>)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Results&nbsp;=&nbsp;Results.Where(<span class="js__object">Function</span>(x)&nbsp;x.ContactType&nbsp;=&nbsp;ContactType)&nbsp;
End&nbsp;If&nbsp;
&nbsp;
If&nbsp;Not&nbsp;Country.Equals(<span class="js__string">&quot;All&quot;</span>)&nbsp;Then&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Results&nbsp;=&nbsp;Results.Where(<span class="js__object">Function</span>(x)&nbsp;x.Country&nbsp;=&nbsp;Country)&nbsp;
End&nbsp;If</pre>
</div>
</div>
</div>
<div class="endscriptcode">So I invite you to download the solution, give a quick run through of the code, build/run to see how it all works.<br>
<br>
<img id="123796" src="123796-aaaaa.png" alt="" width="703" height="430"></div>
</span>
<p></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><br>
<img id="123797" src="123797-bbbbbb.png" alt="" width="369" height="319"><br>
<br>
<br>
</span></p>
