# Image Median Filter
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- GDI+
- .NET
- Class Library
- User Interface
- WPF
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- .NET Framework
- .NET Framework 4.0
- Library
- Windows General
- Windows UI
- C# Language
- Converter
- WinForms
- .NET Framework 4.5
- .NET Framwork
- C# 3.0
- Graphics Functions
- Microsoft .NET Framework 3.5 SP1
- System.Drawing.Drawing2D
- System.Windows.Forms.UserControl
- Image process
- extended controls
- Filter expression
- Manipulation
- .NET 4.5
- .NET Development
## Topics
- Controls
- Graphics
- C#
- GDI+
- Class Library
- Windows Forms
- Graphics and 3D
- Images
- 2d graphics
- Image manipulation
- Code Sample
- Windows UI
- Image Gallery
- Image
- .NET 4
- Imaging
- Drawing
- How to
- Colors and Gradient Brushes
- Extension
- Image Optimization
- Windows Forms Design
- general
- Windows Forms Controls
- C# Language Features
- Language Samples
- Graphics Functions
- User Control
- .Net Programming
- code snippets
- BitmapImage
## Updated
- 05/18/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify">The objective of this article is focussed on providing a discussion on implementing a
<a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
Median Filter</a> on an <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a>. This article illustrates varying levels of filter intensity: <strong><em>3&times;3</em></strong>,
<strong><em>5&times;5</em></strong>, <strong><em>7&times;7</em></strong>, <strong>
<em>9&times;9</em></strong>, <strong><em>11&times;11</em></strong> and <strong><em>13&times;13</em></strong>.</p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify">There are&nbsp;no special requirements or instructions for building the sample source code.</p>
<h1><span style="font-size:20px">Using the Sample Application</span></h1>
<p style="text-align:justify">The concepts explored in this article can be easily replicated by making use of the
<strong><em>Sample Application</em></strong>, which forms part of the associated sample source code accompanying this article.</p>
<p style="text-align:justify">When using the <strong><em>Image Median Filter</em></strong> sample application you can specify a input/source image by clicking the
<strong><em>Load Image</em></strong> button. The dropdown <a title="ComboxBox" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.combobox.aspx" target="_blank">
combobox</a> towards the bottom middle part of the screen relates the various levels of filter intensity.</p>
<p style="text-align:justify">If desired a user can save the resulting filtered image to the local file system by clicking the
<strong><em>Save Image</em></strong> button.</p>
<p style="text-align:justify">The following image is screenshot of the <strong><em>Image Median Filter</em></strong> sample application in action:</p>
<p><img id="82276" src="82276-imagemedianfilter_sampleapplication.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>What is&nbsp;Median Filtering?&nbsp;&nbsp;</h1>
<p style="text-align:justify">From <a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
Wikipedia</a> we gain the following <a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
quotes</a>:</p>
<blockquote>
<p style="text-align:justify">In <a title="Wikipedia: Signal Processing" rel="tag" href="http://en.wikipedia.org/wiki/Signal_processing" target="_blank">
signal processing</a>, it is often desirable to be able to perform some kind of <a href="http://en.wikipedia.org/wiki/Noise_reduction">
noise reduction</a> on an image or signal. The <strong>median filter</strong> is a nonlinear
<a title="Wikipedia: Digital Filter" rel="tag" href="http://en.wikipedia.org/wiki/Digital_filter" target="_blank">
digital filtering</a> technique, often used to remove <a href="http://en.wikipedia.org/wiki/Signal_noise">
noise</a>. Such noise reduction is a typical pre-processing step to improve the results of later processing (for example,
<a title="Wikipedia: Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> on an image). Median filtering is very widely used in digital <a title="Wikipedia: Image Processing" rel="tag" href="http://en.wikipedia.org/wiki/Image_processing" target="_blank">
image processing</a> because, under certain conditions, it preserves edges while removing noise (but see discussion below).</p>
</blockquote>
<blockquote>
<p style="text-align:justify">The main idea of the median filter is to run through the signal entry by entry, replacing each entry with the
<a title="Wikipedia: Median" rel="tag" href="http://en.wikipedia.org/wiki/Median" target="_blank">
median</a> of neighboring entries. The pattern of neighbors is called the &quot;window&quot;, which slides, entry by entry, over the entire signal. For 1D signals, the most obvious window is just the first few preceding and following entries, whereas for 2D (or higher-dimensional)
 signals such as images, more complex window patterns are possible (such as &quot;box&quot; or &quot;cross&quot; patterns). Note that if the window has an odd number of entries, then the
<a title="Wikipedia: Median" rel="tag" href="http://en.wikipedia.org/wiki/Median" target="_blank">
median</a> is simple to define: it is just the middle value after all the entries in the window are sorted numerically. For an even number of entries, there is more than one possible median, see
<a title="Wikipedia: Median" rel="tag" href="http://en.wikipedia.org/wiki/Median" target="_blank">
median</a> for more details.</p>
</blockquote>
<p style="text-align:justify">In simple terms, a <a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
Median Filter</a> can be applied to <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a> in order to achieve <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> smoothing or <a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a> reduction. The <a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
Median Filter</a> in contrast to most <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> smoothing methods, to a degree exhibits edge preservation properties.</p>
<h1>Applying a Median Filter</h1>
<p style="text-align:justify">The sample source code defines the <strong><em>MedianFilter
</em></strong><a title="MSDN: Extension Methods" rel="tag" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">extension method</a> targeting the
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> class. The <strong><em>matrixSize</em></strong> parameter determines the intensity of the
<a title="Wikipedia: Median Filter" rel="tag" href="http://en.wikipedia.org/wiki/Median_filter" target="_blank">
Median Filter</a> being applied.</p>
<p style="text-align:justify">The <strong><em>MedianFilter </em></strong><a title="MSDN: Extension Methods" rel="tag" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">extension method</a> iterates each pixel of the source
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a>. When iterating <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> pixels we determine the neighbouring pixels of the pixel currently being iterated. After having built up a list of neighbouring pixels, the
<strong><em>List</em></strong> is then sorted and from there we determine the middle pixel value. The final step involves assigning the determined middle pixel to the current pixel in the resulting
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a>, represented as an array of pixel colour component <a title="bytes" rel="tag" href="http://msdn.microsoft.com/en-us/library/5bdb6693.aspx" target="_blank">
bytes</a>.</p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;MedianFilter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;matrixSize,&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bias&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">false</span>)&nbsp;&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;sourceData&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle&nbsp;(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width,&nbsp;sourceBitmap.Height),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.ReadOnly,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;pixelBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;resultBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(sourceData.Scan0,&nbsp;pixelBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer.Length);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.UnlockBits(sourceData);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(grayscale&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;rgb&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;pixelBuffer.Length;&nbsp;k&nbsp;&#43;=&nbsp;<span class="cs__number">4</span>)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;=&nbsp;pixelBuffer[k]&nbsp;*&nbsp;<span class="cs__number">0</span>.11f;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.59f;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.3f;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>&nbsp;)rgb;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;filterOffset&nbsp;=&nbsp;(matrixSize&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;calcOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;byteOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;&nbsp;neighbourPixels&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">int</span>&gt;();&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;middlePixel;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;offsetY&nbsp;=&nbsp;filterOffset;&nbsp;offsetY&nbsp;&lt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height&nbsp;-&nbsp;filterOffset;&nbsp;offsetY&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;offsetX&nbsp;=&nbsp;filterOffset;&nbsp;offsetX&nbsp;&lt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width&nbsp;-&nbsp;filterOffset;&nbsp;offsetX&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;byteOffset&nbsp;=&nbsp;offsetY&nbsp;*&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Stride&nbsp;&#43;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;offsetX&nbsp;*&nbsp;<span class="cs__number">4</span>;&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;neighbourPixels.Clear();&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;filterY&nbsp;=&nbsp;-filterOffset;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterY&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterY&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;filterX&nbsp;=&nbsp;-filterOffset;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterX&#43;&#43;)&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calcOffset&nbsp;=&nbsp;byteOffset&nbsp;&#43;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterX&nbsp;*&nbsp;<span class="cs__number">4</span>)&nbsp;&#43;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterY&nbsp;*&nbsp;sourceData.Stride);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;neighbourPixels.Add(BitConverter.ToInt32(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer,&nbsp;calcOffset));&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;neighbourPixels.Sort();&nbsp;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;middlePixel&nbsp;=&nbsp;BitConverter.GetBytes(&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;neighbourPixels[filterOffset]);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset]&nbsp;=&nbsp;middlePixel[<span class="cs__number">0</span>];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;middlePixel[<span class="cs__number">1</span>];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;middlePixel[<span class="cs__number">2</span>];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;middlePixel[<span class="cs__number">3</span>];&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(sourceBitmap.Width,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;resultData&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle&nbsp;(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.Width,&nbsp;resultBitmap.Height),&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.WriteOnly,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(resultBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;resultData.Scan0,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer.Length);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.UnlockBits(resultData);&nbsp;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p></p>
<h1>Sample Images</h1>
<p style="text-align:justify">The sample images illustrated in this article were rendered from the same source image which is licensed under the
<a title="Creative Commons" href="http://en.wikipedia.org/wiki/en:Creative_Commons" target="_blank">
Creative Commons</a> Attribution-Share Alike <a title="Creative Commons" href="http://creativecommons.org/licenses/by-sa/3.0/deed.en" target="_blank">
3.0 Unported</a>, <a title="Creative Commons" href="http://creativecommons.org/licenses/by-sa/2.5/deed.en" target="_blank">
2.5 Generic</a>, <a title="Creative Commons" href="http://creativecommons.org/licenses/by-sa/2.0/deed.en" target="_blank">
2.0 Generic</a> and <a title="Creative Commons" href="http://creativecommons.org/licenses/by-sa/1.0/deed.en" target="_blank">
1.0 Generic</a> license. The <a title="Wikipedia" href="http://en.wikipedia.org/wiki/File:Ara_ararauna_Luc_Viatour.jpg" target="_blank">
original image</a> is attributed to <a title="Luc Viatour" href="http://commons.wikimedia.org/wiki/User:Lviatour" target="_blank">
Luc Viatour</a> &ndash; <a title="Luc Viatour" href="http://www.lucnix.be/" target="_blank">
www.Lucnix.be</a><strong></strong><strong> </strong>and can be <a title="Wikipedia" href="http://en.wikipedia.org/wiki/File:Ara_ararauna_Luc_Viatour.jpg" target="_blank">
downloaded</a> from <a title="Wikipedia:" href="http://en.wikipedia.org/wiki/File:Ara_ararauna_Luc_Viatour.jpg" target="_blank">
Wikipedia</a>.</p>
<p style="text-align:center"><strong><em>The Original Source Image</em></strong></p>
<p><strong><em><img id="82269" src="82269-ara_ararauna_luc_viatour.jpg" alt="" width="500" height="386" style="margin-right:auto; margin-left:auto; display:block"></em></strong></p>
<p style="text-align:center"><strong><em>Median 3&times;3 Filter</em></strong></p>
<p><img id="82270" src="82270-median_filter_3x3.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><strong><em>Median 5&times;5 Filter</em></strong></p>
<p><img id="82271" src="82271-median_filter_5x5.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><strong><em>Median 7&times;7 Filter</em></strong></p>
<p><img id="82272" src="82272-median_filter_7x7.jpg" alt="" width="500" height="386" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><strong><em>Median 9&times;9 Filter</em></strong></p>
<p><img id="82273" src="82273-median_filter_9x9.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><strong><em>Median 11&times;11 Filter</em></strong></p>
<p><span><img id="82274" src="82274-median_filter_11x11.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></span></p>
<p style="text-align:center"><span><strong><em>Median 13&times;13 Filter</em></strong></span></p>
<p><span><img id="82275" src="82275-median_filter_13x13.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></span></p>
<h1>&nbsp;</h1>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtBitmap.cs - Contains the definition of the MedianFilter extension method.</em>
</li><li><em><em>MainForm.cs - Windows Forms Sample Application implementing the MedianFilter extension method</em></em>
</li></ul>
<h1>More Information</h1>
<p>This article is based on an article originally posted on my <a href="http://softwarebydefault.com/" target="_blank">
blog</a>:&nbsp;<a href="http://softwarebydefault.com/2013/05/18/image-median-filter/" target="_blank">http://softwarebydefault.com/2013/05/18/image-median-filter/</a> If you have any questions/comments please feel free to make use of the Q&amp;A section on
 this page, also please remember to rate this article.</p>
<p><strong><em><a title="About Dewald Esterhuizen" rel="tag" href="http://softwarebydefault.com/about/" target="_blank">Dewald Esterhuizen</a></em></strong></p>
