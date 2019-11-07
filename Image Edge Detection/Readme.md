# Image Edge Detection
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
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- .NET Framework
- .NET Framework 4.0
- Library
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
- Graphics
- C#
- GDI+
- User Interface
- Windows Forms
- Graphics and 3D
- Image manipulation
- Image Gallery
- .NET 4
- Imaging
- Drawing
- How to
- Generic C# resuable code
- Image Optimization
- general
- C# Language Features
- Language Samples
- Graphics Functions
- User Control
- BitmapImage
- Load Image
- Extension methods
## Updated
- 05/17/2013
## Description

<h1>Introduction</h1>
<p style="text-align:justify">The objective of this article is to explore various
<a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> algorithms. The types of <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> discussed are: <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a>, <a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">
Laplacian of Gaussian</a>, <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
Sobel</a>, <a title="Wikipedia: Prewitt" rel="tag" href="http://en.wikipedia.org/wiki/Prewitt_operator" target="_blank">
Prewitt</a> and <a title="Wikipedia: Kirsch" rel="tag" href="http://en.wikipedia.org/wiki/Kirsch_operator" target="_blank">
Kirsch</a>. All instances are implemented by means of <a title="Image Convolution" rel="tag" href="http://en.wikipedia.org/wiki/Kernel_(image_processing)#Convolution" target="_blank">
Image Convolution</a>.</p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify">There are no special requirements or instructions for building the sample source code.</p>
<h1><span style="font-size:20px">Using the Sample Application</span></h1>
<p style="text-align:justify">The concepts explored in this article can be easily replicated by making use of the
<strong><em>Sample Application</em></strong>, which forms part of the associated sample source code accompanying this article.</p>
<p style="text-align:justify">When using the <strong><em>Image Edge Detection</em></strong> sample application you can specify a input/source image by clicking the
<strong><em>Load Image</em></strong> button. The dropdown <a title="MSDN: ComboBox" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.windows.forms.combobox.aspx" target="_blank">
combobox</a> towards the bottom middle part of the screen relates the various <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> methods discussed.</p>
<p style="text-align:justify">If desired a user can save the resulting <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> image to the local file system by clicking the <strong><em>Save Image</em></strong> button.</p>
<p style="text-align:justify">The following image is screenshot of the <strong><em>Image Edge Detection</em></strong> sample application in action:</p>
<p><img id="82257" src="82257-image_edge_detection_sample_application.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Edge Detection</h1>
<p style="text-align:justify">A good description of edge detection forms part of the
<a title="Wikipedia: Edge Detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
main Edge Detection article</a> on <a title="Wikipedia: Edge Detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
Wikipedia</a>:</p>
<blockquote>
<p style="text-align:justify"><strong>Edge detection</strong> is the name for a set of mathematical methods which aim at identifying points in a
<a title="Wikipedia: Digital Image" rel="tag" href="http://en.wikipedia.org/wiki/Digital_image" target="_blank">
digital image</a> at which the <a title="Wikipedia: Luminous Intensity" rel="tag" href="http://en.wikipedia.org/wiki/Luminous_intensity" target="_blank">
image brightness</a> changes sharply or, more formally, has discontinuities. The points at which image brightness changes sharply are typically organized into a set of curved line segments termed
<em>edges</em>. The same problem of finding discontinuities in 1D signals is known as
<a title="Wikipedia: Step Detection" rel="tag" href="http://en.wikipedia.org/wiki/Step_detection" target="_blank">
step detection</a> and the problem of finding signal discontinuities over time is known as
<a title="Wikipedia: Change Detection" rel="tag" href="http://en.wikipedia.org/wiki/Change_detection" target="_blank">
change detection</a>. Edge detection is a fundamental tool in <a title="Wikipedia: Image Processing" rel="tag" href="http://en.wikipedia.org/wiki/Image_processing" target="_blank">
image processing</a>, <a title="Wikipedia: Machine Vision" rel="tag" href="http://en.wikipedia.org/wiki/Machine_vision" target="_blank">
machine vision</a> and <a title="Wikipedia: Computer Vision" rel="tag" href="http://en.wikipedia.org/wiki/Computer_vision" target="_blank">
computer vision</a>, particularly in the areas of <a title="Wikipedia: Feature Detection" rel="tag" href="http://en.wikipedia.org/wiki/Feature_detection_(computer_vision)" target="_blank">
feature detection</a> and <a title="Wikipedia: Feature Extraction" rel="tag" href="http://en.wikipedia.org/wiki/Feature_extraction" target="_blank">
feature extraction</a>.</p>
</blockquote>
<h1>Image Convolution</h1>
<p>A good introduction article&nbsp; to <a title="Image Convolution" rel="tag" href="http://en.wikipedia.org/wiki/Kernel_(image_processing)#Convolution" target="_blank">
Image Convolution</a> can be found at: <a title="http://homepages.inf.ed.ac.uk/rbf/HIPR2/convolve.htm" href="http://homepages.inf.ed.ac.uk/rbf/HIPR2/convolve.htm">
http://homepages.inf.ed.ac.uk/rbf/HIPR2/convolve.htm</a>. From the article we learn the following:</p>
<blockquote>
<p style="text-align:justify">Convolution is a simple mathematical operation which is fundamental to many common image processing operators. Convolution provides a way of `multiplying together&rsquo; two arrays of numbers, generally of different sizes, but
 of the same dimensionality, to produce a third array of numbers of the same dimensionality. This can be used in image processing to implement operators whose output pixel values are simple linear combinations of certain input pixel values.</p>
<p style="text-align:justify">In an image processing context, one of the input arrays is normally just a graylevel image. The second array is usually much smaller, and is also two-dimensional (although it may be just a single pixel thick), and is known as the
<a title="Kernel" href="http://homepages.inf.ed.ac.uk/rbf/HIPR2/kernel.htm" target="_blank">
kernel</a>.</p>
</blockquote>
<h1>Single Matrix Convolution</h1>
<p style="text-align:justify">The sample source code implements the <strong><em>ConvolutionFilter</em></strong> method, an
<a title="MSDN: Extension Methods" rel="tag" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">
extension method</a> targeting the <a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> class. The <strong><em>ConvolutionFilter</em></strong> method is intended to apply a user defined
<a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> and optionally covert an <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> to grayscale. The implementation as follows:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static Bitmap ConvolutionFilter(Bitmap sourceBitmap, 
                                     double[,] filterMatrix, 
                                          double factor = 1, 
                                               int bias = 0, 
                                     bool grayscale = false) 
{
    BitmapData sourceData = 
                   sourceBitmap.LockBits(new Rectangle(0, 0,
                   sourceBitmap.Width, sourceBitmap.Height),
                                     ImageLockMode.ReadOnly, 
                                PixelFormat.Format32bppArgb);

  
    byte[] pixelBuffer = new byte[sourceData.Stride *
                                  sourceData.Height];

 
    byte[] resultBuffer = new byte[sourceData.Stride *
                                   sourceData.Height];

  
    Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                               pixelBuffer.Length);

 
    sourceBitmap.UnlockBits(sourceData);

  
    if(grayscale == true)
    {
        float rgb = 0;

  
        for(int k = 0; k &lt; pixelBuffer.Length; k &#43;= 4)
        {
            rgb = pixelBuffer[k] * 0.11f;
            rgb &#43;= pixelBuffer[k &#43; 1] * 0.59f;
            rgb &#43;= pixelBuffer[k &#43; 2] * 0.3f;

  
            pixelBuffer[k] = (byte)rgb;
            pixelBuffer[k &#43; 1] = pixelBuffer[k];
            pixelBuffer[k &#43; 2] = pixelBuffer[k];
            pixelBuffer[k &#43; 3] = 255;
        }
    }

  
    double blue = 0.0;
    double green = 0.0;
    double red = 0.0;

  
    int filterWidth = filterMatrix.GetLength(1);
    int filterHeight = filterMatrix.GetLength(0);

  
    int filterOffset = (filterWidth-1) / 2;
    int calcOffset = 0;

  
    int byteOffset = 0;

  
    for(int offsetY = filterOffset; offsetY &lt; 
        sourceBitmap.Height - filterOffset; offsetY&#43;&#43;)
    {
        for(int offsetX = filterOffset; offsetX &lt; 
            sourceBitmap.Width - filterOffset; offsetX&#43;&#43;)
        {
            blue = 0;
            green = 0;
            red = 0;

  
            byteOffset = offsetY * 
                         sourceData.Stride &#43; 
                         offsetX * 4;

  
            for(int filterY = -filterOffset; 
                filterY &lt;= filterOffset; filterY&#43;&#43;)
            {
                for(int filterX = -filterOffset;
                    filterX &lt;= filterOffset; filterX&#43;&#43;)
               {

  
                   calcOffset = byteOffset &#43; 
                                (filterX * 4) &#43; 
                                (filterY * sourceData.Stride);

  
                   blue &#43;= (double)(pixelBuffer[calcOffset]) *
                           filterMatrix[filterY &#43; filterOffset, 
                                        filterX &#43; filterOffset];

  
                   green &#43;= (double)(pixelBuffer[calcOffset&#43;1]) *
                            filterMatrix[filterY &#43; filterOffset, 
                                         filterX &#43; filterOffset];

  
                   red &#43;= (double)(pixelBuffer[calcOffset&#43;2]) *
                          filterMatrix[filterY &#43; filterOffset, 
                                       filterX &#43; filterOffset];
                }
            }

  
            blue = factor * blue &#43; bias;
            green = factor * green &#43; bias;
            red = factor * red &#43; bias;

  
            if(blue &gt; 255)
            { blue = 255;}
            else if(blue &lt; 0)
            { blue = 0;}

  
            if(green &gt; 255)
            { green = 255;}
            else if(green &lt; 0)
            { green = 0;}

  
            if(red &gt; 255)
            { red = 255;}
            else if(red &lt; 0)
            { red = 0;}

  
            resultBuffer[byteOffset] = (byte)(blue);
            resultBuffer[byteOffset &#43; 1] = (byte)(green);
            resultBuffer[byteOffset &#43; 2] = (byte)(red);
            resultBuffer[byteOffset &#43; 3] = 255;
        }
    }

  
    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, 
                                    sourceBitmap.Height);

  
    BitmapData resultData =
               resultBitmap.LockBits(new Rectangle(0, 0,
               resultBitmap.Width, resultBitmap.Height),
                                ImageLockMode.WriteOnly,
                            PixelFormat.Format32bppArgb);

  
    Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                               resultBuffer.Length);
    resultBitmap.UnlockBits(resultData);

  
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;ConvolutionFilter(Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;filterMatrix,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;factor&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bias&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">false</span>)&nbsp;&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;sourceData&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width,&nbsp;sourceBitmap.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.ReadOnly,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;pixelBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;resultBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(sourceData.Scan0,&nbsp;pixelBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer.Length);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.UnlockBits(sourceData);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(grayscale&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;rgb&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;pixelBuffer.Length;&nbsp;k&nbsp;&#43;=&nbsp;<span class="cs__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;=&nbsp;pixelBuffer[k]&nbsp;*&nbsp;<span class="cs__number">0</span>.11f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.59f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.3f;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)rgb;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;blue&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;green&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;red&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;filterWidth&nbsp;=&nbsp;filterMatrix.GetLength(<span class="cs__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;filterHeight&nbsp;=&nbsp;filterMatrix.GetLength(<span class="cs__number">0</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;filterOffset&nbsp;=&nbsp;(filterWidth<span class="cs__number">-1</span>)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;calcOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;byteOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;offsetY&nbsp;=&nbsp;filterOffset;&nbsp;offsetY&nbsp;&lt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height&nbsp;-&nbsp;filterOffset;&nbsp;offsetY&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;offsetX&nbsp;=&nbsp;filterOffset;&nbsp;offsetX&nbsp;&lt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width&nbsp;-&nbsp;filterOffset;&nbsp;offsetX&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blue&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;green&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;red&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;byteOffset&nbsp;=&nbsp;offsetY&nbsp;*&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Stride&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;offsetX&nbsp;*&nbsp;<span class="cs__number">4</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;filterY&nbsp;=&nbsp;-filterOffset;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterY&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterY&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>(<span class="cs__keyword">int</span>&nbsp;filterX&nbsp;=&nbsp;-filterOffset;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterX&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calcOffset&nbsp;=&nbsp;byteOffset&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterX&nbsp;*&nbsp;<span class="cs__number">4</span>)&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterY&nbsp;*&nbsp;sourceData.Stride);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blue&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)(pixelBuffer[calcOffset])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterMatrix[filterY&nbsp;&#43;&nbsp;filterOffset,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;green&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)(pixelBuffer[calcOffset<span class="cs__number">&#43;1</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterMatrix[filterY&nbsp;&#43;&nbsp;filterOffset,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;red&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)(pixelBuffer[calcOffset<span class="cs__number">&#43;2</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterMatrix[filterY&nbsp;&#43;&nbsp;filterOffset,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;filterOffset];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blue&nbsp;=&nbsp;factor&nbsp;*&nbsp;blue&nbsp;&#43;&nbsp;bias;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;green&nbsp;=&nbsp;factor&nbsp;*&nbsp;green&nbsp;&#43;&nbsp;bias;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;red&nbsp;=&nbsp;factor&nbsp;*&nbsp;red&nbsp;&#43;&nbsp;bias;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(blue&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;blue&nbsp;=&nbsp;<span class="cs__number">255</span>;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>(blue&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;blue&nbsp;=&nbsp;<span class="cs__number">0</span>;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(green&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;green&nbsp;=&nbsp;<span class="cs__number">255</span>;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>(green&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;green&nbsp;=&nbsp;<span class="cs__number">0</span>;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>(red&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;red&nbsp;=&nbsp;<span class="cs__number">255</span>;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>(red&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;red&nbsp;=&nbsp;<span class="cs__number">0</span>;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(blue);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(green);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(red);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(sourceBitmap.Width,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;resultData&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.Width,&nbsp;resultBitmap.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.WriteOnly,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(resultBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;resultData.Scan0,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.UnlockBits(resultData);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>Horizontal and Vertical Matrix Convolution</h1>
<p style="text-align:justify">The <strong><em>ConvolutionFilter</em></strong> <a title="MSDN: Extension Methods" rel="tag" href="http://msdn.microsoft.com/en-us/library/vstudio/bb383977.aspx" target="_blank">
extension method</a> has been overloaded to accept two matrices, representing a vertical
<a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> and a horizontal <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a>. The implementation as follows:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap ConvolutionFilter(this Bitmap sourceBitmap,
                                        double[,] xFilterMatrix,
                                        double[,] yFilterMatrix,
                                              double factor = 1,
                                                   int bias = 0,
                                         bool grayscale = false)
{
    BitmapData sourceData = 
                   sourceBitmap.LockBits(new Rectangle(0, 0,
                   sourceBitmap.Width, sourceBitmap.Height),
                                     ImageLockMode.ReadOnly,
                                PixelFormat.Format32bppArgb);

  
    byte[] pixelBuffer = new byte[sourceData.Stride * 
                                  sourceData.Height];

  
    byte[] resultBuffer = new byte[sourceData.Stride *
                                   sourceData.Height];

  
    Marshal.Copy(sourceData.Scan0, pixelBuffer, 0,
                               pixelBuffer.Length);

  
    sourceBitmap.UnlockBits(sourceData);

  
    if (grayscale == true)
    {
        float rgb = 0;

  
        for (int k = 0; k &lt; pixelBuffer.Length; k &#43;= 4)
        {
            rgb = pixelBuffer[k] * 0.11f;
            rgb &#43;= pixelBuffer[k &#43; 1] * 0.59f;
            rgb &#43;= pixelBuffer[k &#43; 2] * 0.3f;

  
            pixelBuffer[k] = (byte)rgb;
            pixelBuffer[k &#43; 1] = pixelBuffer[k];
            pixelBuffer[k &#43; 2] = pixelBuffer[k];
            pixelBuffer[k &#43; 3] = 255;
        }
    }

  
    double blueX = 0.0;
    double greenX = 0.0;
    double redX = 0.0;

  
    double blueY = 0.0;
    double greenY = 0.0;
    double redY = 0.0;

  
    double blueTotal = 0.0;
    double greenTotal = 0.0;
    double redTotal = 0.0;

  
    int filterOffset = 1;
    int calcOffset = 0;

  
    int byteOffset = 0;

  
    for (int offsetY = filterOffset; offsetY &lt;
        sourceBitmap.Height - filterOffset; offsetY&#43;&#43;)
    {
        for (int offsetX = filterOffset; offsetX &lt;
            sourceBitmap.Width - filterOffset; offsetX&#43;&#43;)
        {
            blueX = greenX = redX = 0;
            blueY = greenY = redY = 0;

  
            blueTotal = greenTotal = redTotal = 0.0;

  
            byteOffset = offsetY *
                         sourceData.Stride &#43;
                         offsetX * 4;

  
            for (int filterY = -filterOffset;
                filterY &lt;= filterOffset; filterY&#43;&#43;)
            {
                for (int filterX = -filterOffset;
                    filterX &lt;= filterOffset; filterX&#43;&#43;)
                {
                    calcOffset = byteOffset &#43;
                                 (filterX * 4) &#43;
                                 (filterY * sourceData.Stride);

  
                    blueX &#43;= (double)
                              (pixelBuffer[calcOffset]) *
                              xFilterMatrix[filterY &#43; 
                                            filterOffset,
                                            filterX &#43; 
                                            filterOffset];

  
                    greenX &#43;= (double)
                          (pixelBuffer[calcOffset &#43; 1]) *
                              xFilterMatrix[filterY &#43;
                                            filterOffset,
                                            filterX &#43;
                                            filterOffset];

  
                    redX &#43;= (double)
                          (pixelBuffer[calcOffset &#43; 2]) *
                              xFilterMatrix[filterY &#43;
                                            filterOffset,
                                            filterX &#43;
                                            filterOffset];

  
                    blueY &#43;= (double)
                              (pixelBuffer[calcOffset]) *
                              yFilterMatrix[filterY &#43;
                                            filterOffset,
                                            filterX &#43;
                                            filterOffset];

  
                    greenY &#43;= (double)
                          (pixelBuffer[calcOffset &#43; 1]) *
                              yFilterMatrix[filterY &#43;
                                            filterOffset,
                                            filterX &#43;
                                            filterOffset];

  
                    redY &#43;= (double)
                          (pixelBuffer[calcOffset &#43; 2]) *
                              yFilterMatrix[filterY &#43;
                                            filterOffset,
                                            filterX &#43;
                                            filterOffset];
                }
            }

  
            blueTotal = Math.Sqrt((blueX * blueX) &#43;
                                  (blueY * blueY));

  
            greenTotal = Math.Sqrt((greenX * greenX) &#43;
                                   (greenY * greenY));

  
            redTotal = Math.Sqrt((redX * redX) &#43;
                                 (redY * redY));

  
            if (blueTotal &gt; 255)
            { blueTotal = 255; }
            else if (blueTotal &lt; 0)
            { blueTotal = 0; }

  
            if (greenTotal &gt; 255)
            { greenTotal = 255; }
            else if (greenTotal &lt; 0)
            { greenTotal = 0; }

  
            if (redTotal &gt; 255)
            { redTotal = 255; }
            else if (redTotal &lt; 0)
            { redTotal = 0; }

  
            resultBuffer[byteOffset] = (byte)(blueTotal);
            resultBuffer[byteOffset &#43; 1] = (byte)(greenTotal);
            resultBuffer[byteOffset &#43; 2] = (byte)(redTotal);
            resultBuffer[byteOffset &#43; 3] = 255;
        }
    }

  
    Bitmap resultBitmap = new Bitmap(sourceBitmap.Width,
                                     sourceBitmap.Height);

  
    BitmapData resultData =
               resultBitmap.LockBits(new Rectangle(0, 0,
               resultBitmap.Width, resultBitmap.Height),
                                ImageLockMode.WriteOnly,
                            PixelFormat.Format32bppArgb);

  
    Marshal.Copy(resultBuffer, 0, resultData.Scan0,
                               resultBuffer.Length);
    resultBitmap.UnlockBits(resultData);

  
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;ConvolutionFilter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;xFilterMatrix,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;yFilterMatrix,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;factor&nbsp;=&nbsp;<span class="cs__number">1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;bias&nbsp;=&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">false</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;sourceData&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width,&nbsp;sourceBitmap.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.ReadOnly,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;pixelBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;resultBuffer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">byte</span>[sourceData.Stride&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Height];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(sourceData.Scan0,&nbsp;pixelBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer.Length);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.UnlockBits(sourceData);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(grayscale&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;rgb&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;pixelBuffer.Length;&nbsp;k&nbsp;&#43;=&nbsp;<span class="cs__number">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;=&nbsp;pixelBuffer[k]&nbsp;*&nbsp;<span class="cs__number">0</span>.11f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.59f;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgb&nbsp;&#43;=&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;*&nbsp;<span class="cs__number">0</span>.3f;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)rgb;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;pixelBuffer[k];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pixelBuffer[k&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;blueX&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;greenX&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;redX&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;blueY&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;greenY&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;redY&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;blueTotal&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;greenTotal&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">double</span>&nbsp;redTotal&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;filterOffset&nbsp;=&nbsp;<span class="cs__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;calcOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;byteOffset&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;offsetY&nbsp;=&nbsp;filterOffset;&nbsp;offsetY&nbsp;&lt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height&nbsp;-&nbsp;filterOffset;&nbsp;offsetY&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;offsetX&nbsp;=&nbsp;filterOffset;&nbsp;offsetX&nbsp;&lt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Width&nbsp;-&nbsp;filterOffset;&nbsp;offsetX&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueX&nbsp;=&nbsp;greenX&nbsp;=&nbsp;redX&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueY&nbsp;=&nbsp;greenY&nbsp;=&nbsp;redY&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueTotal&nbsp;=&nbsp;greenTotal&nbsp;=&nbsp;redTotal&nbsp;=&nbsp;<span class="cs__number">0.0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;byteOffset&nbsp;=&nbsp;offsetY&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceData.Stride&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;offsetX&nbsp;*&nbsp;<span class="cs__number">4</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;filterY&nbsp;=&nbsp;-filterOffset;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterY&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterY&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;filterX&nbsp;=&nbsp;-filterOffset;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&lt;=&nbsp;filterOffset;&nbsp;filterX&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;calcOffset&nbsp;=&nbsp;byteOffset&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterX&nbsp;*&nbsp;<span class="cs__number">4</span>)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(filterY&nbsp;*&nbsp;sourceData.Stride);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueX&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xFilterMatrix[filterY&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greenX&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset&nbsp;&#43;&nbsp;<span class="cs__number">1</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xFilterMatrix[filterY&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redX&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset&nbsp;&#43;&nbsp;<span class="cs__number">2</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xFilterMatrix[filterY&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueY&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yFilterMatrix[filterY&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greenY&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset&nbsp;&#43;&nbsp;<span class="cs__number">1</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yFilterMatrix[filterY&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redY&nbsp;&#43;=&nbsp;(<span class="cs__keyword">double</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(pixelBuffer[calcOffset&nbsp;&#43;&nbsp;<span class="cs__number">2</span>])&nbsp;*&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yFilterMatrix[filterY&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterX&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterOffset];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueTotal&nbsp;=&nbsp;Math.Sqrt((blueX&nbsp;*&nbsp;blueX)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(blueY&nbsp;*&nbsp;blueY));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greenTotal&nbsp;=&nbsp;Math.Sqrt((greenX&nbsp;*&nbsp;greenX)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(greenY&nbsp;*&nbsp;greenY));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redTotal&nbsp;=&nbsp;Math.Sqrt((redX&nbsp;*&nbsp;redX)&nbsp;&#43;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(redY&nbsp;*&nbsp;redY));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(blueTotal&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;blueTotal&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(blueTotal&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;blueTotal&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(greenTotal&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;greenTotal&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(greenTotal&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;greenTotal&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(redTotal&nbsp;&gt;&nbsp;<span class="cs__number">255</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;redTotal&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;<span class="cs__keyword">if</span>&nbsp;(redTotal&nbsp;&lt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;redTotal&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(blueTotal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">1</span>]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(greenTotal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">2</span>]&nbsp;=&nbsp;(<span class="cs__keyword">byte</span>)(redTotal);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer[byteOffset&nbsp;&#43;&nbsp;<span class="cs__number">3</span>]&nbsp;=&nbsp;<span class="cs__number">255</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(sourceBitmap.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sourceBitmap.Height);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BitmapData&nbsp;resultData&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.LockBits(<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.Width,&nbsp;resultBitmap.Height),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageLockMode.WriteOnly,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PixelFormat.Format32bppArgb);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Marshal.Copy(resultBuffer,&nbsp;<span class="cs__number">0</span>,&nbsp;resultData.Scan0,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;resultBuffer.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap.UnlockBits(resultData);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<h1>Original Sample Image</h1>
<p style="text-align:justify">The original source <a href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx">
image</a> used to create all of the <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> sample images in this article has been licensed under the <a title="Creative Commons" href="http://en.wikipedia.org/wiki/en:Creative_Commons" target="_blank">
Creative Commons</a> Attribution-Share Alike <a title="3.0 Unported" href="http://creativecommons.org/licenses/by-sa/3.0/deed.en" target="_blank">
3.0 Unported</a>, <a title="2.5 Generic" href="http://creativecommons.org/licenses/by-sa/2.5/deed.en" target="_blank">
2.5 Generic</a>, <a title="2.0 Generic" href="http://creativecommons.org/licenses/by-sa/2.0/deed.en" target="_blank">
2.0 Generic</a> and <a title="1.0 Generic" href="http://creativecommons.org/licenses/by-sa/1.0/deed.en" target="_blank">
1.0 Generic</a> license. The original image is attributed to <a title="Wikipedia: Kenneth Dwain Harrelson" href="http://en.wikipedia.org/wiki/User:HaarFager" target="_blank">
Kenneth Dwain Harrelson</a> and can be <a title="Wikipedia" href="http://en.wikipedia.org/wiki/File:Monarch_In_May.jpg" target="_blank">
downloaded</a> from <a title="Wikipedia" href="http://en.wikipedia.org/wiki/File:Monarch_In_May.jpg" target="_blank">
Wikipedia</a>.</p>
<p><img id="82259" src="82259-monarch_in_may.jpg" alt="" width="480" height="319" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian Edge Detection</h1>
<p style="text-align:justify">The <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> method of <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> counts as one of the commonly used <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> implementations. From <a title="Wikipedia: Base64" rel="tag" href="http://en.wikipedia.org/wiki/Base64" target="_blank">
Wikipedia</a> we gain the following definition:</p>
<blockquote>
<p style="text-align:justify">Discrete Laplace operator is often used in image processing e.g. in edge detection and motion estimation applications. The discrete Laplacian is defined as the sum of the second derivatives
<a title="Laplace operator Coordinate expressions" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator#Coordinate_expressions" target="_blank">
Laplace operator Coordinate expressions</a> and calculated as sum of differences over the nearest neighbours of the central pixel.</p>
</blockquote>
<p style="text-align:justify">A number of <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a>/<a title="Image Kernel" rel="tag" href="http://en.wikipedia.org/wiki/Kernel_(image_processing)" target="_blank">kernel</a> variations may be applied with results ranging from slight to fairly pronounced. In the following sections of this article
 we explore two common <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> implementations, <strong><em>3&times;3</em></strong> and <strong><em>5&times;5</em></strong>.</p>
<h1>Laplacian 3x3</h1>
<p style="text-align:justify">When implementing a <strong><em>3&times;3</em></strong>
<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> you will notice little difference between colour and grayscale result <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian3x3Filter(this Bitmap sourceBitmap, 
                      bool grayscale = true)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                Matrix.Laplacian3x3,
                                  1.0, 0, grayscale);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian3x3Filter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian3x3,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;grayscale);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian3x3
{ 
   get   
   { 
       return new double[,]
       { { -1, -1, -1, },  
         { -1,  8, -1, },  
         { -1, -1, -1, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">8</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian 3x3</strong></em></p>
<p><img id="82239" src="82239-laplacian_3x3.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><em><strong>Laplacian 3x3 Grayscale</strong></em></p>
<p><img id="82240" src="82240-laplacian_3x3_grayscale.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian 5x5</h1>
<p style="text-align:justify">The <strong><em>5&times;5</em></strong>&nbsp;<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">Laplacian</a>
<a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> produces result <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a> with a noticeable difference between colour and grayscale <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a>. The detected edges are expressed in a fair amount of fine detail, although the
<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> has a tendency to be sensitive to <a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian5x5Filter(this Bitmap sourceBitmap, 
                      bool grayscale = true)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                Matrix.Laplacian5x5,
                                  1.0, 0, grayscale);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian5x5Filter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian5x5,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;grayscale);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian5x5 
{ 
    get   
    { 
       return new double[,]
       { { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, 24, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1  } }; 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian5x5&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>&nbsp;&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian 5x5</strong></em></p>
<p><img id="82241" src="82241-laplacian_5x5.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><em><strong>Laplacian 5x5 Grayscale</strong></em></p>
<p><img id="82242" src="82242-laplacian_5x5_grayscale.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian of Gaussian</h1>
<p style="text-align:justify">The <a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">
Laplacian of Gaussian</a> (LoG) is a common variation of the <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filter. <a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">
Laplacian of Gaussian</a> is intended to counter the noise sensitivity of the regular
<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filter.</p>
<p style="text-align:justify"><a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">Laplacian of Gaussian</a> attempts to remove
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> noise by implementing <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> smoothing by means of a <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a>. In order to optimize performance we can calculate a single <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> representing a <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> and <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
LaplacianOfGaussian(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                         Matrix.LaplacianOfGaussian, 
                                       1.0, 0, true);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
LaplacianOfGaussian(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.LaplacianOfGaussian,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] LaplacianOfGaussian
{ 
    get   
    { 
        return new double[,]
        { {  0,  0, -1,  0,  0 },  
          {  0, -1, -2, -1,  0 },  
          { -1, -2, 16, -2, -1 }, 
          {  0, -1, -2, -1,  0 }, 
          {  0,  0, -1,  0,  0 } };
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;LaplacianOfGaussian&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">2</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">2</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;-<span class="cs__number">2</span>,&nbsp;-<span class="cs__number">1</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">2</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>&nbsp;}&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian of Gaussian</strong></em></p>
<p><img id="82243" src="82243-laplacian_of_gaussian.jpg" alt="" width="480" height="319" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (3x3) of Gaussian (3x3)</h1>
<p style="text-align:justify">Different <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> variations can be combined in an attempt to produce results best suited to the input
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a>. In this case we first apply a <strong><em>3&times;3</em></strong> <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> followed by a <strong><em>3&times;3</em></strong> <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian3x3OfGaussian3x3Filter(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                 Matrix.Gaussian3x3,
                                1.0 / 16.0, 0, true);

 
    resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                         Matrix.Laplacian3x3, 1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian3x3OfGaussian3x3Filter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian3x3,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">16.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian3x3,&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian3x3
{ 
   get   
   { 
       return new double[,]
       { { -1, -1, -1, },  
         { -1,  8, -1, },  
         { -1, -1, -1, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">8</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian3x3
{ 
   get   
   { 
       return new double[,]
       { { 1, 2, 1, },  
         { 2, 4, 2, },  
         { 1, 2, 1, } }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (3x3) of Gaussian (3x3)</strong></em></p>
<p><img id="82244" src="82244-laplacian_3x3_of_gaussian_3x3.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (3&times;3) of Gaussian (5&times;5 &ndash; Type 1)</h1>
<p style="text-align:justify">In this scenario we apply a variation of a <strong>
<em>5&times;5</em></strong> <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> followed by a <strong><em>3&times;3</em></strong> <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filter.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian3x3OfGaussian5x5Filter1(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                            Matrix.Gaussian5x5Type1,
                               1.0 / 159.0, 0, true);

 
    resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                         Matrix.Laplacian3x3, 1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian3x3OfGaussian5x5Filter1(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian5x5Type1,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">159.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian3x3,&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian3x3
{ 
   get   
   { 
       return new double[,]
       { { -1, -1, -1, },  
         { -1,  8, -1, },  
         { -1, -1, -1, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">8</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian5x5Type1 
{ 
   get   
   { 
       return new double[,]   
       { { 2, 04, 05, 04, 2 },  
         { 4, 09, 12, 09, 4 },  
         { 5, 12, 15, 12, 5 }, 
         { 4, 09, 12, 09, 4 }, 
         { 2, 04, 05, 04, 2 }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian5x5Type1&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">05</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">2</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">15</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">05</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">2</span>&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (3&times;3) of Gaussian (5&times;5 &ndash; Type 1)</strong></em></p>
<p><img id="82245" src="82245-laplacian_3x3_of_gaussian_5x5_type1.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (3&times;3) of Gaussian (5&times;5 &ndash; Type 2)</h1>
<p style="text-align:justify">The following implementation is very similar to the previous implementation. Applying a variation of a
<strong><em>5&times;5</em></strong> <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> results in slight differences.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian3x3OfGaussian5x5Filter2(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                            Matrix.Gaussian5x5Type2,
                               1.0 / 256.0, 0, true);

 
    resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                         Matrix.Laplacian3x3, 1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian3x3OfGaussian5x5Filter2(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian5x5Type2,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">256.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian3x3,&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian3x3
{ 
   get   
   { 
       return new double[,]
       { { -1, -1, -1, },  
         { -1,  8, -1, },  
         { -1, -1, -1, }, }; 
   } 
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">8</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian5x5Type2 
{ 
   get   
   {
       return new double[,]  
       { {  1,   4,  6,  4,  1 },  
         {  4,  16, 24, 16,  4 },  
         {  6,  24, 36, 24,  6 }, 
         {  4,  16, 24, 16,  4 }, 
         {  1,   4,  6,  4,  1 }, }; 
   }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian5x5Type2&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">1</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">16</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">36</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;&nbsp;<span class="cs__number">6</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">16</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">1</span>&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (3&times;3) of Gaussian (5&times;5 &ndash; Type 2)</strong></em></p>
<p><img id="82246" src="82246-laplacian_3x3_of_gaussian_5x5_type2.jpg" alt="" width="480" height="319" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (5&times;5) of Gaussian (3&times;3)</h1>
<p style="text-align:justify">This variation of the <a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">
Laplacian of Gaussian</a> filter implements a <strong><em>3&times;3</em></strong>
<a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a>, followed by a <strong><em>5&times;5</em></strong> <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a>. The resulting <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> appears significantly brighter when compared to a <strong><em>3&times;3</em></strong>
<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian5x5OfGaussian3x3Filter(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                 Matrix.Gaussian3x3,
                                1.0 / 16.0, 0, true);

 
    resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap,
                         Matrix.Laplacian5x5, 1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian5x5OfGaussian3x3Filter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian3x3,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">16.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian5x5,&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian5x5 
{ 
    get   
    { 
       return new double[,]
       { { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, 24, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1  } }; 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian5x5&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>&nbsp;&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian3x3
{ 
   get   
   { 
       return new double[,]
       { { 1, 2, 1, },  
         { 2, 4, 2, },  
         { 1, 2, 1, } }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian3x3&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">1</span>,&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">1</span>,&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (5&times;5) of Gaussian (3&times;3)</strong></em></p>
<p><img id="82247" src="82247-laplacian_5x5_of_gaussian_3x3.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (5&times;5) of Gaussian (5&times;5 &ndash; Type 1)</h1>
<p style="text-align:justify">Implementing a larger <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> <a title="Matrix" rel="tag" href="http://en.wikipedia.org/wiki/Matrix_(mathematics)" target="_blank">
matrix</a> results in a higher degree of <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a> smoothing, equating to less <a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian5x5OfGaussian5x5Filter1(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                            Matrix.Gaussian5x5Type1,
                               1.0 / 159.0, 0, true);

 
    resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap,
                         Matrix.Laplacian5x5, 1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian5x5OfGaussian5x5Filter1(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian5x5Type1,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">159.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian5x5,&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian5x5 
{ 
    get   
    { 
       return new double[,]
       { { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, 24, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1  } }; 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian5x5&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>&nbsp;&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian5x5Type1 
{ 
   get   
   { 
       return new double[,]   
       { { 2, 04, 05, 04, 2 },  
         { 4, 09, 12, 09, 4 },  
         { 5, 12, 15, 12, 5 }, 
         { 4, 09, 12, 09, 4 }, 
         { 2, 04, 05, 04, 2 }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian5x5Type1&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">05</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">2</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">5</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">15</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">5</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">4</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">12</span>,&nbsp;<span class="cs__number">09</span>,&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;<span class="cs__number">2</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">05</span>,&nbsp;<span class="cs__number">04</span>,&nbsp;<span class="cs__number">2</span>&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (5&times;5) of Gaussian (5&times;5 &ndash; Type 1)</strong></em></p>
<p><img id="82248" src="82248-laplacian_5x5_of_gaussian_5x5_type1.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Laplacian (5&times;5) of Gaussian (5&times;5 &ndash; Type 2)</h1>
<p style="text-align:justify">The variation of <a title="Gaussian blur" rel="tag" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">
Gaussian blur</a> most applicable when implementing a <a title="Wikipedia: Laplacian of Gaussian" rel="tag" href="http://en.wikipedia.org/wiki/Blob_detection#The_Laplacian_of_Gaussian" target="_blank">
Laplacian of Gaussian</a> filter depends on <a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a> expressed by a source <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
image</a>. In this scenario the first variations (<em>Type 1</em>) appears to result in less
<a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Laplacian5x5OfGaussian5x5Filter2(this Bitmap sourceBitmap)
{
    Bitmap resultBitmap = 
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                            Matrix.Gaussian5x5Type2, 
                               1.0 / 256.0, 0, true);

 
    resultBitmap = 
           ExtBitmap.ConvolutionFilter(resultBitmap, 
                                Matrix.Laplacian5x5, 
                                      1.0, 0, false);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Laplacian5x5OfGaussian5x5Filter2(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Gaussian5x5Type2,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>&nbsp;/&nbsp;<span class="cs__number">256.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">true</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;resultBitmap&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(resultBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Laplacian5x5,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__keyword">false</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Laplacian5x5 
{ 
    get   
    { 
       return new double[,]
       { { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, 24, -1, -1, },  
         { -1, -1, -1, -1, -1, },  
         { -1, -1, -1, -1, -1  } }; 
    } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Laplacian5x5&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>&nbsp;&nbsp;}&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Gaussian5x5Type2 
{ 
   get   
   {
       return new double[,]  
       { {  1,   4,  6,  4,  1 },  
         {  4,  16, 24, 16,  4 },  
         {  6,  24, 36, 24,  6 }, 
         {  4,  16, 24, 16,  4 }, 
         {  1,   4,  6,  4,  1 }, }; 
   }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Gaussian5x5Type2&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">1</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">16</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">36</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;&nbsp;<span class="cs__number">6</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">16</span>,&nbsp;<span class="cs__number">24</span>,&nbsp;<span class="cs__number">16</span>,&nbsp;&nbsp;<span class="cs__number">4</span>&nbsp;},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">6</span>,&nbsp;&nbsp;<span class="cs__number">4</span>,&nbsp;&nbsp;<span class="cs__number">1</span>&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Laplacian (5&times;5) of Gaussian (5&times;5 &ndash; Type 2)</strong></em></p>
<p><img id="82249" src="82249-laplacian_5x5_of_gaussian_5x5_type2.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Sobel Edge Detection</h1>
<p style="text-align:justify"><a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">Sobel</a>
<a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> is another common implementation of <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a>. We gain the following <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
quote</a> from <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
Wikipedia</a>:</p>
<blockquote>
<p style="text-align:justify">The <strong>Sobel operator</strong> is used in <a title="Wikipedia: image processing" rel="tag" href="http://en.wikipedia.org/wiki/Image_processing" target="_blank">
image processing</a>, particularly within <a href="http://en.wikipedia.org/wiki/Edge_detection">
edge detection</a> algorithms. Technically, it is a <a title="Wikipedia: Discrete Differentiation Operator" rel="tag" href="http://en.wikipedia.org/wiki/Difference_operator" target="_blank">
discrete differentiation operator</a>, computing an approximation of the <a title="Wikipedia: Image Gradient" rel="tag" href="http://en.wikipedia.org/wiki/Image_gradient" target="_blank">
gradient</a> of the image intensity function. At each point in the image, the result of the Sobel operator is either the corresponding gradient vector or the norm of this vector. The Sobel operator is based on convolving the image with a small, separable, and
 integer valued filter in horizontal and vertical direction and is therefore relatively inexpensive in terms of computations. On the other hand, the gradient approximation that it produces is relatively crude, in particular for high frequency variations in
 the image.</p>
</blockquote>
<p style="text-align:justify">Unlike the <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filters discussed earlier, <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
Sobel</a> filter results differ significantly when comparing colour and grayscale
<a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a>. The <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
Sobel</a> filter tends to be less sensitive to <a title="Image noise" rel="tag" href="http://en.wikipedia.org/wiki/Image_noise" target="_blank">
image noise</a> compared to the <a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filter. The detected edge lines are not as finely detailed/granular as the detected edge lines resulting from
<a title="Wikipedia: Laplacian" rel="tag" href="http://en.wikipedia.org/wiki/Laplace_operator" target="_blank">
Laplacian</a> filters.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
Sobel3x3Filter(this Bitmap sourceBitmap, 
                  bool grayscale = true)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                          Matrix.Sobel3x3Horizontal, 
                            Matrix.Sobel3x3Vertical, 
                                  1.0, 0, grayscale);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
Sobel3x3Filter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Sobel3x3Horizontal,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Sobel3x3Vertical,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;grayscale);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Sobel3x3Horizontal
{ 
   get   
   {
       return new double[,]  
       { { -1,  0,  1, },  
         { -2,  0,  2, },  
         { -1,  0,  1, }, }; 
   } 
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Sobel3x3Horizontal&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">2</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">2</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Sobel3x3Vertical 
{ 
   get   
   { 
       return new double[,]  
       { {  1,  2,  1, },  
         {  0,  0,  0, },  
         { -1, -2, -1, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Sobel3x3Vertical&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">2</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">2</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Sobel 3x3</strong></em></p>
<p><img id="82250" src="82250-sobel_3x3.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><em><strong>Sobel 3x3 Grayscale</strong></em></p>
<p><img id="82251" src="82251-sobel_3x3_grayscale.jpg" alt="" width="480" height="319" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Prewitt Edge Detection</h1>
<p style="text-align:justify">As with the other methods of <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> discussed in this article the <a title="Wikipedia: Prewitt" rel="tag" href="http://en.wikipedia.org/wiki/Prewitt_operator" target="_blank">
Prewitt</a> <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> method is also a fairly common implementation. From <a title="Wikipedia: Prewitt" rel="tag" href="http://en.wikipedia.org/wiki/Prewitt" target="_blank">
Wikipedia</a> we gain the following quote:</p>
<blockquote>
<p style="text-align:justify">The <strong>Prewitt operator</strong> is used in <a title="Wikipedia: Image processing" rel="tag" href="http://en.wikipedia.org/wiki/Image_processing" target="_blank">
image processing</a>, particularly within <a title="Wikipedia: Edge Detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> algorithms. Technically, it is a <a title="Wikipedia: Difference Operator" rel="tag" href="http://en.wikipedia.org/wiki/Difference_operator" target="_blank">
discrete differentiation operator</a>, computing an approximation of the <a title="Wikipedia: Image Gradient" rel="tag" href="http://en.wikipedia.org/wiki/Image_gradient" target="_blank">
gradient</a> of the image intensity function. At each point in the image, the result of the Prewitt operator is either the corresponding gradient vector or the norm of this vector. The Prewitt operator is based on convolving the image with a small, separable,
 and integer valued filter in horizontal and vertical direction and is therefore relatively inexpensive in terms of computations. On the other hand, the gradient approximation which it produces is relatively crude, in particular for high frequency variations
 in the image. The Prewitt operator was developed by Judith M. S. Prewitt.</p>
<p style="text-align:justify">In simple terms, the operator calculates the <em><a title="Wikipedia: Image gradient" rel="tag" href="http://en.wikipedia.org/wiki/Image_gradient" target="_blank">gradient</a></em> of the image intensity at each point, giving the
 direction of the largest possible increase from light to dark and the rate of change in that direction. The result therefore shows how &quot;abruptly&quot; or &quot;smoothly&quot; the image changes at that point, and therefore how likely it is that that part of the image represents
 an <em>edge</em>, as well as how that edge is likely to be oriented. In practice, the magnitude (likelihood of an edge) calculation is more reliable and easier to interpret than the direction calculation.</p>
</blockquote>
<p style="text-align:justify">Similar to the <a title="Wikipedia: Sobel" rel="tag" href="http://en.wikipedia.org/wiki/Sobel_operator" target="_blank">
Sobel</a> filter, resulting <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a> express a significant difference when comparing colour and grayscale <a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a>.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
PrewittFilter(this Bitmap sourceBitmap, 
                 bool grayscale = true)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                        Matrix.Prewitt3x3Horizontal, 
                          Matrix.Prewitt3x3Vertical, 
                                  1.0, 0, grayscale);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
PrewittFilter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Prewitt3x3Horizontal,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Prewitt3x3Vertical,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;grayscale);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Prewitt3x3Horizontal 
{ 
   get   
   { 
       return new double[,]  
       { { -1,  0,  1, },  
         { -1,  0,  1, },  
         { -1,  0,  1, }, }; 
   } 
} </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Prewitt3x3Horizontal&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Prewitt3x3Vertical 
{ 
   get   
   { 
       return new double[,]  
       { {  1,  1,  1, },  
         {  0,  0,  0, },  
         { -1, -1, -1, }, }; 
   }
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Prewitt3x3Vertical&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;&nbsp;<span class="cs__number">1</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;-<span class="cs__number">1</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Prewitt</strong></em></p>
<p><img id="82252" src="82252-prewitt.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><em><strong>Prewitt Grayscale</strong></em></p>
<p><img id="82253" src="82253-prewitt_grayscale.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1>Kirsch Edge Detection</h1>
<p style="text-align:justify">The <a title="Wikipedia: Kirsch" rel="tag" href="http://en.wikipedia.org/wiki/Kirsch_operator" target="_blank">
Kirsch</a> <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a> method is often implemented in the form of Compass <a title="Edge detection" rel="tag" href="http://en.wikipedia.org/wiki/Edge_detection" target="_blank">
edge detection</a>. In the following scenario we only implement two components: Horizontal and Vertical. Resulting
<a title="images" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
images</a> tend to have a high level of brightness.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static Bitmap 
KirschFilter(this Bitmap sourceBitmap, 
                bool grayscale = true)
{
    Bitmap resultBitmap =
           ExtBitmap.ConvolutionFilter(sourceBitmap, 
                         Matrix.Kirsch3x3Horizontal, 
                           Matrix.Kirsch3x3Vertical, 
                                  1.0, 0, grayscale);

 
    return resultBitmap;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Bitmap&nbsp;&nbsp;
KirschFilter(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">bool</span>&nbsp;grayscale&nbsp;=&nbsp;<span class="cs__keyword">true</span>)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;resultBitmap&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ExtBitmap.ConvolutionFilter(sourceBitmap,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Kirsch3x3Horizontal,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Matrix.Kirsch3x3Vertical,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;grayscale);&nbsp;
&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;resultBitmap;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Kirsch3x3Horizontal 
{ 
   get   
   {
       return new double[,]  
       { {  5,  5,  5, },  
         { -3,  0, -3, },  
         { -3, -3, -3, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Kirsch3x3Horizontal&nbsp;&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">3</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;-<span class="cs__number">3</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static double[,] Kirsch3x3Vertical
{ 
   get   
   { 
       return new double[,]  
       { {  5, -3, -3, },  
         {  5,  0, -3, },  
         {  5, -3, -3, }, }; 
   } 
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;Kirsch3x3Vertical&nbsp;
{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">double</span>[,]&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;{&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;&nbsp;<span class="cs__number">0</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;<span class="cs__number">5</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;-<span class="cs__number">3</span>,&nbsp;},&nbsp;};&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p style="text-align:center"><em><strong>Kirsch</strong></em></p>
<p><img id="82254" src="82254-kirsch.jpg" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
<p style="text-align:center"><em><strong>Kirsch Grayscale</strong></em></p>
<p><img id="82255" src="82255-kirsch_grayscale.jpg" alt="" width="480" height="319" style="margin-right:auto; margin-left:auto; display:block"></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtBitmap.cs - Definition of various extension methods targeting the Bitmap class.</em>&nbsp;
</li><li><em>Matrix.cs - Definition of two dimensional matrix/kernel values</em> </li><li><em>MainForm.cs - Windows Forms based test application</em> </li></ul>
<h1>More Information</h1>
<p>This article is based on an article originally posted on my <a href="http://softwarebydefault.com/" target="_blank">
blog</a>:&nbsp;<a rel="tag" href="http://softwarebydefault.com/2013/05/11/image-edge-detection/" target="_blank">http://softwarebydefault.com/2013/05/11/image-edge-detection/</a> If you have any questions/comments please feel free to make use of the Q&amp;A
 section on this page, also please remember to rate this article.</p>
<p><strong><em><a title="About Dewald Esterhuizen" rel="tag" href="http://softwarebydefault.com/about/" target="_blank">Dewald Esterhuizen</a></em></strong></p>
<p>&nbsp;</p>
<p><em>&nbsp;</em></p>
