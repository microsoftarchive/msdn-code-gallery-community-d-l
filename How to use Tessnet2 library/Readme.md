# How to use Tessnet2 library
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
## Topics
- Tessnet2
- OCR
## Updated
- 08/29/2014
## Description

<h1>Introduction</h1>
<p><em><span>This article has the goal to show how to use the&nbsp;Tessnet2 library.</span></em></p>
<h1>Description</h1>
<p><a href="http://www.pixel-technology.com/freeware/tessnet2/">Tessnet2</a>&nbsp;is a .NET 2.0 Open Source OCR assembly using Tesseract engine.&nbsp;<a href="http://tmp.m4f.eu/tessnet2.zip">Download binary here</a>.</p>
<p>Another important thing for&nbsp;Tessnet2 work is get the languages packages, get it&nbsp;<a href="http://code.google.com/p/tesseract-ocr/downloads/list">here</a>&nbsp;for the languages you want. For the sample we are use english language.</p>
<p>Let's start the sample.</p>
<p>Create one console aplication:<br>
<img src="-consoleapplication.png" alt="console aplication"></p>
<p>Then copy the folder with binaries and languages packages to the same folder.<br>
Note: Don&acute;t forget unzip the languanges packages until have the tessdata folder with eng.DangAmbigs, eng.freq-dawg, eng.inttemp, eng.normproto, eng.pffmtable, eng.unicharset, eng.user-words and eng.word-dawg files.<br>
The aspect should be something like:</p>
<p><img src="-ocrtest.png" alt="ocr test folder"></p>
<p>Now add the&nbsp;Tessnet2 reference to the project, do a right click in References &gt; Add References &gt; Browse&gt; Select the folder with&nbsp;C:\OCRTest\tessnet2\Release64\tessnet2_64.dll and click Ok.</p>
<p>After add the reference for&nbsp;System.Drawing:<br>
<img src="-reference.png" alt="reference"></p>
<p>Now we need configure the project to compile in x64, for it Right Click in project&gt; Properties&gt;Build&gt; Platform target</p>
<p><img src="-config.png" alt="configs"></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>In Program.cs add the following code:</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
        {
            try
            {
                var image = new Bitmap(@&quot;C:\OCRTest\number.jpg&quot;);
                var ocr = new Tesseract();
                ocr.SetVariable(&quot;tessedit_char_whitelist&quot;, &quot;0123456789&quot;); // If digit only
                //@&quot;C:\OCRTest\tessdata&quot; contains the language package, without this the method crash and app breaks
                ocr.Init(@&quot;C:\OCRTest\tessdata&quot;, &quot;eng&quot;, true); 
                var result = ocr.DoOCR(image, Rectangle.Empty);
                foreach (Word word in result)
                    Console.WriteLine(&quot;{0} : {1}&quot;, word.Confidence, word.Text);

                Console.ReadLine();
            }
            catch (Exception exception)
            {

            }
        }</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;image&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(@<span class="cs__string">&quot;C:\OCRTest\number.jpg&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;ocr&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Tesseract();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ocr.SetVariable(<span class="cs__string">&quot;tessedit_char_whitelist&quot;</span>,&nbsp;<span class="cs__string">&quot;0123456789&quot;</span>);&nbsp;<span class="cs__com">//&nbsp;If&nbsp;digit&nbsp;only</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//@&quot;C:\OCRTest\tessdata&quot;&nbsp;contains&nbsp;the&nbsp;language&nbsp;package,&nbsp;without&nbsp;this&nbsp;the&nbsp;method&nbsp;crash&nbsp;and&nbsp;app&nbsp;breaks</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ocr.Init(@<span class="cs__string">&quot;C:\OCRTest\tessdata&quot;</span>,&nbsp;<span class="cs__string">&quot;eng&quot;</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;ocr.DoOCR(image,&nbsp;Rectangle.Empty);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Word&nbsp;word&nbsp;<span class="cs__keyword">in</span>&nbsp;result)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(<span class="cs__string">&quot;{0}&nbsp;:&nbsp;{1}&quot;</span>,&nbsp;word.Confidence,&nbsp;word.Text);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadLine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<p>and run the application, this give an error:</p>
<p><img src="-error.png" alt="error"></p>
<p>to solve this go to directory and change the App.config:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
&lt;configuration&gt;
  &lt;startup useLegacyV2RuntimeActivationPolicy=&quot;true&quot;&gt;
    &lt;supportedRuntime version=&quot;v4.0&quot; sku=&quot;.NETFramework,Version=v4.5&quot; /&gt;
  &lt;/startup&gt;
&lt;/configuration&gt;</pre>
<div class="preview">
<pre class="js">&lt;?xml&nbsp;version=<span class="js__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="js__string">&quot;utf-8&quot;</span>&nbsp;?&gt;&nbsp;
&lt;configuration&gt;&nbsp;
&nbsp;&nbsp;&lt;startup&nbsp;useLegacyV2RuntimeActivationPolicy=<span class="js__string">&quot;true&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;supportedRuntime&nbsp;version=<span class="js__string">&quot;v4.0&quot;</span>&nbsp;sku=<span class="js__string">&quot;.NETFramework,Version=v4.5&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;/startup&gt;&nbsp;
&lt;/configuration&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1 class="endscriptcode"><strong>Update</strong></h1>
<p>&nbsp;</p>
<p>Make sure you added the right paths to the Program.cs file!!<strong> I got the sample and changed the path for image and for tessdata and it works well!!<br>
</strong></p>
<div class="endscriptcode"><img id="115248" src="115248-tessnet%202.png" alt="" width="738" height="361"></div>
<div class="endscriptcode"></div>
<p>&nbsp;</p>
<p><span style="font-size:2em">More Information</span></p>
<p><em>sk me on twitter @saramgsilva</em></p>
<p><a><img src="-" alt="free hit counter" style="border:none"></a></p>
