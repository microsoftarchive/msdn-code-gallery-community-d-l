# Implementing the IEnumerable Interface in a Collection Class
## Requires
- Visual Studio 2010
## License
- Custom
## Technologies
- Windows General
## Topics
- Collections
- Tokens
- IEnumerable
- Foreach
## Updated
- 06/20/2011
## Description

<h1>Introduction</h1>
<p>This sample shows how to implement a collection class that can be used with the
<strong>foreach</strong> statement.</p>
<h1><span>Building the Sample</span></h1>
<h4 class="heading">To build and run the Collection Classes samples within Visual Studio</h4>
<div class="section" id="procedureSection1">
<ol>
<li>
<p>In <strong>Solution Explorer</strong>, right-click the CollectionClasses1 project and click
<strong>Set as StartUp Project</strong>.</p>
</li><li>
<p>From the <strong>Debug</strong> menu, click <strong>Start Without Debugging</strong>.</p>
</li><li>
<p>Repeat the preceding steps for CollectionClasses2.</p>
</li></ol>
</div>
<h4 class="heading">To build and run the Collection Classes samples from the Command Line</h4>
<div class="section" id="procedureSection2">
<ol>
<li>
<p>Use the <strong>Change Directory</strong> command to change to the CollectionClasses1 directory.</p>
</li><li>
<p>Type the following:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre>csc tokens.cs
tokens</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li><li>
<p>Use the <strong>Change Directory</strong> command to change to the CollectionClasses2 directory.</p>
</li><li>
<p>Type the following:</p>
<div class="code"><span>
<table cellspacing="0" cellpadding="0" width="100%">
<tbody>
<tr>
<td colspan="2">
<pre>csc tokens2.cs
tokens2</pre>
</td>
</tr>
</tbody>
</table>
</span></div>
</li></ol>
</div>
<h1>Description</h1>
<p>This sample shows how to implement a collection class that can be used with the
<strong>foreach</strong> statement. See Collection Classes (C# Programming Guide) for more information.</p>
<h4>Security Note</h4>
<p>This sample code is provided to illustrate a concept and should not be used in applications or Web sites, as it may not illustrate the safest coding practices. Microsoft assumes no liability for incidental or consequential damages should the sample code
 be used for purposes other than as intended.</p>
<h1>Screenshot</h1>
<p><img src="23517-screenshot.png" alt="" width="677" height="342"></p>
<h1>Sample Code</h1>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">   static void Main()
   {
      // Testing Tokens by breaking the string into tokens:
      Tokens f = new Tokens(&quot;This is a well-done program.&quot;, 
         new char[] {' ','-'});
      foreach (string item in f)
      {
         Console.WriteLine(item);
      }
   }</pre>
<div class="preview">
<pre id="codePreview" class="csharp">&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main()&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Testing&nbsp;Tokens&nbsp;by&nbsp;breaking&nbsp;the&nbsp;string&nbsp;into&nbsp;tokens:</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tokens&nbsp;f&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Tokens(<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;well-done&nbsp;program.&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">char</span>[]&nbsp;{<span class="cs__string">'&nbsp;'</span>,<span class="cs__string">'-'</span>});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(<span class="cs__keyword">string</span>&nbsp;item&nbsp;<span class="cs__keyword">in</span>&nbsp;f)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(item);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a class="browseFile" href="sourcecode?fileId=23509&pathId=848208947">tokens.cs</a>
</li><li><a class="browseFile" href="sourcecode?fileId=23509&pathId=2098527711">tokens2.cs</a>
</li></ul>
<h1>More Information</h1>
<p>For more information, see:</p>
<ul>
<li>IEnumerable Interface - <a href="http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/system.collections.ienumerable.aspx</a> </li><li>Foreach, in (C# Reference) - <a href="http://msdn.microsoft.com/en-us/library/ttw7t8t6%28v=VS.100%29.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/ttw7t8t6%28v=VS.100%29.aspx</a> </li><li>Collection Classes (C# Programming Guide) - <a href="http://msdn.microsoft.com/en-us/library/ybcx56wz%28v=VS.100%29.aspx" target="_blank">
http://msdn.microsoft.com/en-us/library/ybcx56wz%28v=VS.100%29.aspx</a> </li></ul>
