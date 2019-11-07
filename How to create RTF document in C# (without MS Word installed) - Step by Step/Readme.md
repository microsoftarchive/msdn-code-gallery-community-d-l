# How to create RTF document in C# (without MS Word installed) - Step by Step
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- Office
- .NET Framework
- VB.Net
- Visual C#
## Topics
- Controls
- C#
- ASP.NET
- User Interface
- How to
- Office 2010 101 code samples
## Updated
- 04/22/2016
## Description

<h1>Introduction</h1>
<p><em>This is a C# example to generate a RTF file via a free C# &laquo;RTF Document .Net&raquo; library. You will be able to create RTF document on fly and fill it by necessary data.</em></p>
<p><em><img id="151201" src="151201-rtf-document-scheme.png" alt="" width="487" height="277" style="display:block; margin-left:auto; margin-right:auto"><br>
</em></p>
<p><em>If you are searching for a solution to create RTF in C#, stop the searching - you're in the right place! The RTF Document.Net is only the one library designed for this purpose.</em></p>
<p><br>
<em>Only the .Net platform and nothing else, 32 and 64-bit support, Medium Trust level.</em></p>
<p><em>You will be able to do with RTF documents all what you want:</em></p>
<ul class="LiText">
<li><em>Create RTF document on fly and fill it by necessary data.</em> </li><li><em>Load RTF document and get all it's structure as tree of objects.</em> </li><li><em>Modify text, tables and other data in existing RTF document.</em> </li><li><em>Parse current content and structure and Save/Render it as new RTF.</em> </li><li><em>Replace data in RTF document.</em> </li></ul>
<h1>Main Function</h1>
<p>The simple code sample:</p>
<p><img id="151202" src="151202-rtf%20input.png" alt="" width="700" height="501"></p>
<p><span>The result (RTF file):</span></p>
<p><span><img id="151203" src="151203-rtf%20document.png" alt="" width="775" height="409"><br>
</span></p>
<h1><span>How to do it:</span></h1>
<p><em>So, here we'll show you in details how to create RTF document on fly and fill it by necessary data.</em></p>
<p><em><strong><span class="blue12b">Very simple example.</span></strong>&nbsp;For example, we need to generate a simple RTF document with 2 paragraphs.</em></p>
<p><em><span class="blue12b"><strong>Step 1</strong>:</span>&nbsp;Launch Visual Studio 2010 (2013). Click File-&gt;New Project-&gt;Visual C# Console Application.</em></p>
<p><em>Type the application name and location, for example &quot;simple RTF&quot; and &quot;c:\samples&quot;.</em></p>
<p><em><span class="blue12b"><strong>Step 2</strong>:</span>&nbsp;In the Solution Explorer right-click on &quot;References&quot; and select &quot;Add Reference&quot;. Next add a reference to the &quot;Document.dll&quot;</em><em>.</em></p>
<p><em><span class="blue12b"><strong>Step 3</strong>:</span>&nbsp;So, we've created an empty C# console application. Now type the C# code to create a simple RTF file with name: Result.rtf</em></p>
<p><em><strong>Step 4</strong>: Please insert c# code in your console application.&nbsp;Now build the application and launch it.</em></p>
<p><span><em><strong><span class="blue12b">Well done!</span>&nbsp;</strong>Our congratulations, with help of the RTF Document .Net library we've created an editable Word document.</em></span></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.IO;
using SautinSoft.Document;

namespace Sample
{
    class Sample
    {
        static void Main(string[] args)
        {
            CreateRtf();            
        }
        public static void CreateRtf()
        {
            // Working directory
            string workingDir = Path.GetFullPath(Directory.GetCurrentDirectory() &#43; @&quot;Tempos&quot;);
            string rtfFilePath = Path.Combine(workingDir, &quot;Result.rtf&quot;);

            // Let's create a simple RTF document.
            DocumentCore rtf = new DocumentCore();
             // You may download the latest version of SDK here:   
            // http://sautinsoft.com/products/rtf-document/download.php  

            // Add new section.
            Section section = new Section(rtf);
            rtf.Sections.Add(section);

            // Let's set page size A4.
            section.PageSetup.PaperType = PaperType.A4;

            // Add two paragraphs using different ways:

            // Way 1: Add 1st paragraph.
            section.Blocks.Add(new Paragraph(rtf, &quot;This is a first line in 1st paragraph!&quot;));
            Paragraph par1 = section.Blocks[0] as Paragraph;
            par1.ParagraphFormat.Alignment = HorizontalAlignment.Center;

            // Let's add a second line.
            par1.Inlines.Add(new SpecialCharacter(rtf, SpecialCharacterType.LineBreak));
            par1.Inlines.Add(new Run(rtf, &quot;Let's type a second line.&quot;));

            // Let's change font name, size and color.
            CharacterFormat cf = new CharacterFormat() { FontName = &quot;Verdana&quot;, Size = 16, FontColor = Color.Orange };
            foreach (Inline inline in par1.Inlines)
                if (inline is Run)
                    (inline as Run).CharacterFormat = cf.Clone();

            // Way 2 (easy): Add 2nd paragarph using another way.
            rtf.Content.End.Insert(&quot;\nThis is a first line in 2nd paragraph.&quot;, new CharacterFormat() { Size = 25, FontColor = Color.Blue, Bold = true });
            SpecialCharacter lBr = new SpecialCharacter(rtf, SpecialCharacterType.LineBreak);
            rtf.Content.End.Insert(lBr.Content);
            rtf.Content.End.Insert(&quot;This is a second line.&quot;, new CharacterFormat() { Size = 20, FontColor = Color.DarkGreen, UnderlineStyle = UnderlineType.Single });

            // Save RTF to a file
            rtf.Save(rtfFilePath, SaveOptions.RtfDefault);

            // Open the result for demonstation purposes.
            System.Diagnostics.Process.Start(rtfFilePath);
        }

    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.IO;&nbsp;
<span class="cs__keyword">using</span>&nbsp;SautinSoft.Document;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Sample&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Sample&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateRtf();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;CreateRtf()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Working&nbsp;directory</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;workingDir&nbsp;=&nbsp;Path.GetFullPath(Directory.GetCurrentDirectory()&nbsp;&#43;&nbsp;@<span class="cs__string">&quot;Tempos&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;rtfFilePath&nbsp;=&nbsp;Path.Combine(workingDir,&nbsp;<span class="cs__string">&quot;Result.rtf&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;create&nbsp;a&nbsp;simple&nbsp;RTF&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DocumentCore&nbsp;rtf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DocumentCore();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;download&nbsp;the&nbsp;latest&nbsp;version&nbsp;of&nbsp;SDK&nbsp;here:&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;http://sautinsoft.com/products/rtf-document/download.php&nbsp;&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;new&nbsp;section.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Section&nbsp;section&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Section(rtf);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtf.Sections.Add(section);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;set&nbsp;page&nbsp;size&nbsp;A4.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;section.PageSetup.PaperType&nbsp;=&nbsp;PaperType.A4;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Add&nbsp;two&nbsp;paragraphs&nbsp;using&nbsp;different&nbsp;ways:</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Way&nbsp;1:&nbsp;Add&nbsp;1st&nbsp;paragraph.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;section.Blocks.Add(<span class="cs__keyword">new</span>&nbsp;Paragraph(rtf,&nbsp;<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;first&nbsp;line&nbsp;in&nbsp;1st&nbsp;paragraph!&quot;</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Paragraph&nbsp;par1&nbsp;=&nbsp;section.Blocks[<span class="cs__number">0</span>]&nbsp;<span class="cs__keyword">as</span>&nbsp;Paragraph;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.ParagraphFormat.Alignment&nbsp;=&nbsp;HorizontalAlignment.Center;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;add&nbsp;a&nbsp;second&nbsp;line.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.Inlines.Add(<span class="cs__keyword">new</span>&nbsp;SpecialCharacter(rtf,&nbsp;SpecialCharacterType.LineBreak));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;par1.Inlines.Add(<span class="cs__keyword">new</span>&nbsp;Run(rtf,&nbsp;<span class="cs__string">&quot;Let's&nbsp;type&nbsp;a&nbsp;second&nbsp;line.&quot;</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Let's&nbsp;change&nbsp;font&nbsp;name,&nbsp;size&nbsp;and&nbsp;color.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CharacterFormat&nbsp;cf&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;FontName&nbsp;=&nbsp;<span class="cs__string">&quot;Verdana&quot;</span>,&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">16</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.Orange&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Inline&nbsp;inline&nbsp;<span class="cs__keyword">in</span>&nbsp;par1.Inlines)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(inline&nbsp;<span class="cs__keyword">is</span>&nbsp;Run)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(inline&nbsp;<span class="cs__keyword">as</span>&nbsp;Run).CharacterFormat&nbsp;=&nbsp;cf.Clone();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Way&nbsp;2&nbsp;(easy):&nbsp;Add&nbsp;2nd&nbsp;paragarph&nbsp;using&nbsp;another&nbsp;way.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtf.Content.End.Insert(<span class="cs__string">&quot;\nThis&nbsp;is&nbsp;a&nbsp;first&nbsp;line&nbsp;in&nbsp;2nd&nbsp;paragraph.&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">25</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.Blue,&nbsp;Bold&nbsp;=&nbsp;<span class="cs__keyword">true</span>&nbsp;});&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SpecialCharacter&nbsp;lBr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SpecialCharacter(rtf,&nbsp;SpecialCharacterType.LineBreak);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtf.Content.End.Insert(lBr.Content);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtf.Content.End.Insert(<span class="cs__string">&quot;This&nbsp;is&nbsp;a&nbsp;second&nbsp;line.&quot;</span>,&nbsp;<span class="cs__keyword">new</span>&nbsp;CharacterFormat()&nbsp;{&nbsp;Size&nbsp;=&nbsp;<span class="cs__number">20</span>,&nbsp;FontColor&nbsp;=&nbsp;Color.DarkGreen,&nbsp;UnderlineStyle&nbsp;=&nbsp;UnderlineType.Single&nbsp;});&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Save&nbsp;RTF&nbsp;to&nbsp;a&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rtf.Save(rtfFilePath,&nbsp;SaveOptions.RtfDefault);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;the&nbsp;result&nbsp;for&nbsp;demonstation&nbsp;purposes.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(rtfFilePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/rtf-document/index.php">RTF Document.Net</a><br>
Download:&nbsp;<em><a href="http://sautinsoft.com/products/rtf-document/download.php">RTF Document.Net</a></em><a href="http://sautinsoft.com/products/html-to-rtf/download.php"></a></em></div>
<p>&nbsp;</p>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that RTF Document.Net is entirely written in managed C#, which makes it
 absolutely standalone and an independent library</em></p>
