# How to translate from C# to VB using the roslyn.
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Visual Basic .NET
- VB.Net
- C# Language
- .NET Framework 4.5
- Roslyn
## Topics
- C#
- Visual Basic .NET
- Code Sample
- Code Generation
- Roslyn
## Updated
- 03/05/2016
## Description

<h1>Introduction</h1>
<p>&nbsp;</p>
<ul>
<li><em>This sample can analyze the structure of C# source using the roslyn, and convert to the structure of the VB from this structure.</em>
</li></ul>
<p><em>And after, Roslyn can output&nbsp; formatted text code of VB&nbsp; from this structure.<br>
This sample include real-time viewer that is result of translate from C# to VB. and it has viewer of syntax tree as like syntax visualizer.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>The C# project requires VS 2013 or later. .Net Framework 4.5<br>
<br>
<a href="https://github.com/dotnet/roslyn" target="_blank">Roslyn</a> 1.1.1<br>
&nbsp; PM&gt; Install-Package Microsoft.CodeAnalysis<br>
&nbsp;Microsoft.CodeAnalysis<br>
&nbsp;Microsoft.CodeAnalysis.CSharp<br>
&nbsp;Microsoft.CodeAnalysis.VisualBasic<br>
<br>
<a href="https://www.nuget.org/packages/AvalonEdit">AvalonEdit</a> <br>
&nbsp; PM&gt; Install-Package AvalonEdit <br>
<br>
Reference of Rosyln and AvalonEdit isn't inculuded in this sample.<br>
Please read official page of Roslyn and add references to the solution by Nuget.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Translator analyze source code through the roslyn. This result is multi tree diagram of SyntaxNode that is included SyntaxNode and Token.<br>
Next, translator generate Syntax Node of VB using SyntaxFactory from this tree structure recursively.</p>
<p>&nbsp;<img id="140140" src="140140-roslynconverter2.png" alt="" width="600" height="740"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img id="140142" src="140142-roslynconverter3.png" alt="" width="600" height="292"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">スクリプトの編集</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Microsoft.CodeAnalysis;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ConsoleApplication1&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;csCode&nbsp;=&nbsp;<span class="cs__string">&quot;&nbsp;void&nbsp;main(){&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Console.WriteLine.aspx" target="_blank" title="Auto generated link to System.Console.WriteLine">System.Console.WriteLine</a>(\&quot;OK\&quot;);&nbsp;}&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;vbRoot&nbsp;=&nbsp;Gekka.Roslyn.Translator.CS2VB.Translate(csCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;vbCode=&nbsp;vbRoot.NormalizeWhitespace().ToFullString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(vbCode);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:x-small">RoslynTranslator - translator project </span>
</li><li><span style="font-size:x-small">RoslynTranslator\TestFile\TestFile.cs - sample C# code</span>
</li><li><span style="font-size:x-small">TranslateViewer - Translator and syntax tree viewer
</span></li></ul>
<h1>More Information</h1>
<p><strong><em>License<br>
</em></strong><a href="https://github.com/icsharpcode/AvalonEdit">Roslyn</a>&nbsp; : Apache License Version 2.0<br>
<a href="https://www.nuget.org/packages/AvalonEdit">Avalon Edit&nbsp;</a> : MIT License</p>
<p><em><strong>Notice</strong><br>
The C#&nbsp; features is not matches VB features. So, c# and VB features has not entirely correspond to the complete translation.<br>
this sample can't&nbsp; analyse function call tree , because this is analyzing syntax structures only.<br>
This will not be able to find the implicit interface that is the implementation of member.<br>
EventHander&nbsp; assignment is not support.</em></p>
<p><em><em><strong>History</strong><br>
</em></em>Ver 1.1</p>
<ul>
<li>Bug Fix. </li><li>Implement translate trivia. </li><li>Update Roslyn to 1.1.1 </li></ul>
