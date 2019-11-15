# Find and Replace Text in Word with C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- WPF
- c# control
## Topics
- Find/Replace Dialog
- Find object
- Find Dialog
- Find function in C#
- Find and Replace in Word
## Updated
- 10/23/2014
## Description

<h1>Introduction</h1>
<p style="text-align:justify"><span style="font-size:small">Microsoft Word's Find feature lets you search through lengthy documents for a particular word, phrase, or character string. You can choose to selectively or automatically replace the searched text
 with a different word, phrase, or character string. This sample explains how to find and replace text using free Spire.Doc with C#.</span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">This solution is based on a .NET Word component - free Spire.Doc, download the package and unzip it, you&rsquo;ll get dll file and sample demo at the same time. Create
 or open a .NET class application in Visual Studio 2005 or above versions, add Spire.Doc.dll as a reference to your .NET project assemblies, set &ldquo;Target framework&rdquo; to &ldquo;.NET Framework 4&rdquo;, then you&rsquo;re able to find and replace text
 in Word using this sample code.</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><strong>Tools We Need:</strong><br>
</span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small">- Free Spire.Doc dll (This dll can not be uploaded with the zip package, please download by yourself)<br>
- Visual Studio</span></span></p>
<p><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small"><strong>Detailed Steps:</strong></span></span></span></p>
<p style="text-align:justify"><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small">STEP 1. Create a Winform Application, design the Form1 as below, double click the Run button to write code.</span></span></span></p>
<p><span style="font-size:20px"><span style="font-size:small"><span style="font-size:small"><img id="127458" src="https://i1.code.msdn.s-msft.com/find-and-highlight-text-in-09ca0320/image/file/127458/1/1.png" alt="" width="477" height="236"><br>
</span></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;<span class="cs__keyword">public</span>&nbsp;Form1()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;textBox1_TextChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p><span style="font-size:small">STEP 2</span>. <span style="font-size:small">Input below code to realize the find and replace function in button_Click event.</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;word&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Document&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//load&nbsp;a&nbsp;document</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.LoadFromFile(@<span class="cs__string">&quot;../../sample.docx&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Replace&nbsp;text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.Replace(<span class="cs__keyword">this</span>.textBox1.Text,&nbsp;<span class="cs__keyword">this</span>.textBox2.Text,<span class="cs__keyword">true</span>,<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Save&nbsp;doc&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;document.SaveToFile(<span class="cs__string">&quot;result.docx&quot;</span>,&nbsp;FileFormat.Docx);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Launching&nbsp;the&nbsp;MS&nbsp;Word&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WordDocViewer(<span class="cs__string">&quot;result.docx&quot;</span>);</pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;STEP 3. Launch the file.</span></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;WordDocViewer(<span class="cs__keyword">string</span>&nbsp;fileName)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Diagnostics.Process.Start.aspx" target="_blank" title="Auto generated link to System.Diagnostics.Process.Start">System.Diagnostics.Process.Start</a>(fileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;{&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p class="endscriptcode"><span style="font-size:small">STEP 4. Run the code, a dialog box will pop up, then input any text that we want to find and input another text that we want to insert. Here, I will find &quot;Unity&quot; and replace it with &quot;XXXXX&quot; in the sample
 file I prepared.</span></p>
<p class="endscriptcode"><span style="font-size:small"><img id="127461" src="https://i1.code.msdn.s-msft.com/find-and-highlight-text-in-09ca0320/image/file/127461/1/2.png" alt="" width="472" height="232"></span></p>
<p class="endscriptcode">&nbsp;</p>
<p class="endscriptcode"><span style="font-size:small"><strong>Screenshot of the result file:</strong></span></p>
<p class="endscriptcode"><span style="font-size:small"><strong><br>
</strong></span></p>
<p class="endscriptcode"><span style="font-size:small"><strong><img id="127462" src="https://i1.code.msdn.s-msft.com/find-and-highlight-text-in-09ca0320/image/file/127462/1/3.png" alt="" width="642" height="384"><br>
</strong></span></p>
<p class="endscriptcode"><span style="font-size:small"><strong><br>
</strong></span></p>
</div>
<h1>More Information</h1>
<p style="text-align:justify"><span style="font-size:small">Free Spire.Doc for .NET is a Community Edition of the Spire.Doc for .NET, which is a totally free word component for commercial and personal use. As a free C#/VB.NET component, it also offers a lot
 of powerful functions. Developers can use it to generate, read, write, save, print and convert documents on any .NET applications.</span></p>
<p><strong><span style="font-size:small">Related Links</span></strong></p>
<p><span style="font-size:small">Website:&nbsp;<a href="http://www.e-iceblue.com">http://www.e-iceblue.com</a>&nbsp;</span></p>
<p><span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/spire-doc-f6.html">
Spire.Doc Forum</a></span></p>
<p style="text-align:justify"><span style="font-size:small"><br>
</span></p>
