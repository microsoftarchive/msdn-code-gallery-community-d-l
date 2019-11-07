# How to view, create and convert PowerPoint slides to PDF in C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- ASP.NET
- Class Library
- WPF
- PowerPoint
## Topics
- Create PowerPoint Slide
- C# PowerPoint
## Updated
- 03/10/2017
## Description

<h1>Introduction</h1>
<p>This sample demonstrates how to:</p>
<ul>
<li>read PowerPoint files in C#, </li><li>view PowerPoint files in WPF, </li><li><a href="https://www.gemboxsoftware.com/presentation/examples/c-sharp-convert-powerpoint-to-pdf/204">convert PowerPoint to PDF</a> and other file formats and
</li><li>add a new <a href="https://www.gemboxsoftware.com/presentation/examples/c-sharp-vb-net-powerpoint-slides/401">
slide in C#</a> </li></ul>
<p>with a free version of <a href="https://www.gemboxsoftware.com/presentation/examples/c-sharp-vb-net-powerpoint-library/101">
C# / VB.NET PowerPoint library</a> called GemBox.Presentation.</p>
<h1><span>Building the Sample</span></h1>
<p>Referenced GemBox.Presentation.dll is already included in the attached solution. To use the latest version of GemBox.Presentation.dll,
<a href="https://www.gemboxsoftware.com/presentation/free-version">download it</a> and replace it with the existing one.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample solves the most common operations required when automating PowerPoint presentations by using the built-in functionalities of GemBox.Presentation library.</em></p>
<p><em><strong>Reading PowerPoint files</strong> is shown in the following code snippet:</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">var openFileDialog = new OpenFileDialog()
{
    DefaultExt = &quot;.pptx&quot;,
    Filter = &quot;PowerPoint Presentation|*.pptx&quot;
};

if (openFileDialog.ShowDialog(this) == true)
{
    this.presentation = PresentationDocument.Load(openFileDialog.FileName);
}</pre>
<div class="preview">
<pre class="csharp">var&nbsp;openFileDialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OpenFileDialog()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DefaultExt&nbsp;=&nbsp;<span class="cs__string">&quot;.pptx&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Filter&nbsp;=&nbsp;<span class="cs__string">&quot;PowerPoint&nbsp;Presentation|*.pptx&quot;</span>&nbsp;
};&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(openFileDialog.ShowDialog(<span class="cs__keyword">this</span>)&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.presentation&nbsp;=&nbsp;PresentationDocument.Load(openFileDialog.FileName);&nbsp;
}</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;<strong>Viewing PowerPoint files in WPF</strong> is shown in the following code snippet:</em></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">var openFileDialog = new OpenFileDialog()
{
    DefaultExt = &quot;.pptx&quot;,
    Filter = &quot;PowerPoint Presentation|*.pptx&quot;
};

if (openFileDialog.ShowDialog(this) == true)
{
    this.presentation = PresentationDocument.Load(openFileDialog.FileName);

    // XpsDocument needs to stay referenced so that DocumentViewer 
    // can access additional required resources.
    // Otherwise, GC will collect/dispose XpsDocument and DocumentViewer 
    // will not work.
    this.xpsPresentation = presentation.ConvertToXpsDocument(SaveOptions.Xps);

    this.PresentationViewer.Document = this.xpsPresentation.GetFixedDocumentSequence();
}</pre>
<div class="preview">
<pre class="csharp">var&nbsp;openFileDialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;OpenFileDialog()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;DefaultExt&nbsp;=&nbsp;<span class="cs__string">&quot;.pptx&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Filter&nbsp;=&nbsp;<span class="cs__string">&quot;PowerPoint&nbsp;Presentation|*.pptx&quot;</span>&nbsp;
};&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(openFileDialog.ShowDialog(<span class="cs__keyword">this</span>)&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.presentation&nbsp;=&nbsp;PresentationDocument.Load(openFileDialog.FileName);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;XpsDocument&nbsp;needs&nbsp;to&nbsp;stay&nbsp;referenced&nbsp;so&nbsp;that&nbsp;DocumentViewer&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;can&nbsp;access&nbsp;additional&nbsp;required&nbsp;resources.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Otherwise,&nbsp;GC&nbsp;will&nbsp;collect/dispose&nbsp;XpsDocument&nbsp;and&nbsp;DocumentViewer&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;will&nbsp;not&nbsp;work.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.xpsPresentation&nbsp;=&nbsp;presentation.ConvertToXpsDocument(SaveOptions.Xps);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.PresentationViewer.Document&nbsp;=&nbsp;<span class="cs__keyword">this</span>.xpsPresentation.GetFixedDocumentSequence();&nbsp;
}</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;<strong>Converting PowerPoint files to PDF</strong> and other file formats is shown in the following code snippet:</em></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>
<pre class="hidden">var saveFileDialog = new SaveFileDialog()
{
    Filter = &quot;PowerPoint Presentation|*.pptx|Adobe Portable Document Format|*.pdf|XML Paper Specification|*.xps|Image|*.png&quot;
};

if (saveFileDialog.ShowDialog(this) == true)
    this.presentation.Save(saveFileDialog.FileName);</pre>
<div class="preview">
<pre class="csharp">var&nbsp;saveFileDialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SaveFileDialog()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Filter&nbsp;=&nbsp;<span class="cs__string">&quot;PowerPoint&nbsp;Presentation|*.pptx|Adobe&nbsp;Portable&nbsp;Document&nbsp;Format|*.pdf|XML&nbsp;Paper&nbsp;Specification|*.xps|Image|*.png&quot;</span>&nbsp;
};&nbsp;
&nbsp;
<span class="cs__keyword">if</span>&nbsp;(saveFileDialog.ShowDialog(<span class="cs__keyword">this</span>)&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.presentation.Save(saveFileDialog.FileName);</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em><strong>Adding a new slide </strong>is shown in the following code snippet:</em></div>
<div class="endscriptcode"><em>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Add a new empty slide.
var slide = this.presentation.Slides.AddNew(SlideLayoutType.Custom);

// Add a text box of size 5 x 5 cm in the top-left corner of the slide.
var textBox = slide.Content.AddTextBox(0, 0, 5, 5, LengthUnit.Centimeter);

// Add a paragraph with text content to the text box.
textBox.AddParagraph().AddRun(this.slideTextBox.Text);</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;new&nbsp;empty&nbsp;slide.</span>&nbsp;
var&nbsp;slide&nbsp;=&nbsp;<span class="cs__keyword">this</span>.presentation.Slides.AddNew(SlideLayoutType.Custom);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;text&nbsp;box&nbsp;of&nbsp;size&nbsp;5&nbsp;x&nbsp;5&nbsp;cm&nbsp;in&nbsp;the&nbsp;top-left&nbsp;corner&nbsp;of&nbsp;the&nbsp;slide.</span>&nbsp;
var&nbsp;textBox&nbsp;=&nbsp;slide.Content.AddTextBox(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">5</span>,&nbsp;LengthUnit.Centimeter);&nbsp;
&nbsp;
<span class="cs__com">//&nbsp;Add&nbsp;a&nbsp;paragraph&nbsp;with&nbsp;text&nbsp;content&nbsp;to&nbsp;the&nbsp;text&nbsp;box.</span>&nbsp;
textBox.AddParagraph().AddRun(<span class="cs__keyword">this</span>.slideTextBox.Text);</pre>
</div>
</div>
</div>
</em></div>
<div class="endscriptcode"><em>For a full reference, please download the attached Visual Studio solution.<br>
</em></div>
<em></em></div>
<em></em></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml.cs - contains all the code used in this sample.</em> </li></ul>
<h1>More Information</h1>
<p><em>GemBox.Presentation is a <strong>C#/VB.NET library</strong> that provides a simple and efficient way to process PowerPoint files. It enables developers to
<strong>read, write, convert and print presentation files (PPTX, PDF, XPS and image formats) from .NET applications</strong> without a need for Microsoft PowerPoint on either the developer or client machines.</em></p>
