# Gaussian blur with CUDA 5
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C++
- Parallel Programming
- CUDA
- GPGPU
## Topics
- Parallel Programming
- Image manipulation
- CUDA
- GPGPU
## Updated
- 02/25/2013
## Description

<h1>Introduction</h1>
<div style="font-size:small">We will&nbsp;continue from a <a title="RGBA to Gray image conversion with CUDA 5" href="http://code.msdn.microsoft.com/vstudio/RGBA-to-Gray-image-e07dd9f5" target="_blank">
previous example</a> of RGBA to gray image conversion with CUDA 5 and&nbsp;add&nbsp;gaussian filter. After applying the filter we will achieve the following transformation:</div>
<div style="font-size:small"></div>
<div style="font-size:small"><img id="76440" src="76440-flowers.jpg" alt="" width="700"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">to:</div>
<div style="font-size:small"><img id="76441" src="76441-flowers-gaussian.jpg" alt="" width="700"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">Here's the information showing time it took to run&nbsp;CUDA kernel on the GPU compared to time on the CPU:</div>
<div style="font-size:small"></div>
<div style="font-size:small"><img id="76442" src="76442-command.png" alt="" width="1360" height="360"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">This code will work with RGBA images where each channel (Red, Green, Blue, and Alpha) is represented by one byte (8-bits) and a range of values between 0 and 255 (2^8 - 1) for a total of 4-bytes per pixel.</div>
<div style="font-size:small"></div>
<div style="font-size:small">Gaussian function&nbsp;expresses normal distribution in statistics.&nbsp;In image processing, Gaussian blur is based on the following function in one dimension:</div>
<div style="font-size:small"><img id="76443" src="76443-gaussian-1d.png" alt="" width="204" height="54"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">In two dimensions, it is the product of two Gaussians, one in each dimension, and has to be applied to each pixel of the image.</div>
<div style="font-size:small"></div>
<div style="font-size:small"><img id="76445" src="76445-gaussian-2d.png" alt="" width="213" height="54"></div>
<div style="font-size:small">&nbsp;</div>
<div style="font-size:small">In the formula, x is the distance from the origin in the horizontal axis (number of pixels to the left and to the right), y is the distance from the origin in the vertical axis (number of pixels to the top and to the bottom), and
 &sigma; is the standard deviation of the Gaussian distribution (arbitrary number). When applied in two dimensions, this formula produces a surface whose contours are concentric circles with a bell-shaped distribution from the center point. Values from this
 distribution are used to build a convolution matrix which is applied to the original image. Each pixel's new value is set to a weighted average of that pixel's neighboring pixels and self. The original pixel's value receives the heaviest weight (having the
 highest Gaussian value) and neighboring pixels receive smaller weights as their distance to the original pixel increases. This results in a blur that preserves boundaries and edges.</div>
<div style="font-size:small"></div>
<div style="font-size:small">Visually convollution matrix looks like this:</div>
<div style="font-size:small"></div>
<div style="font-size:small"><img id="76446" src="76446-gaussian-visual.png" alt="" width="431" height="349"></div>
<div style="font-size:small">References:</div>
<div style="font-size:small"></div>
<div style="font-size:small"><a title="wiki" href="http://en.wikipedia.org/wiki/Gaussian_blur" target="_blank">Wikipedia</a></div>
<div style="font-size:small"><a href="http://rastergrid.com/blog/2010/09/efficient-gaussian-blur-with-linear-sampling" target="_blank">Efficient Gaussian blur with linear sampling</a></div>
<div style="font-size:small"><a href="http://www.swageroo.com/wordpress/how-to-program-a-gaussian-blur-without-using-3rd-party-libraries" target="_blank">How to program a Gaussian Blur</a></div>
<div style="font-size:small"><a href="http://people.csail.mit.edu/sparis/bf_course/slides08/03_definition_bf.pdf" target="_blank">Gentle introduction to bilateral filtering</a></div>
<div style="font-size:small">&nbsp;</div>
<h1><span>Building the Sample</span></h1>
<div style="font-size:small">Required prerequisites are: CUDA 5.0, NSight 3.0 RC1,
<a title="OpenCV download" href="http://opencv.org/downloads.html" target="_blank">
OpenCV</a>, Visual Studio 2012</div>
<h1>Description</h1>
<div style="font-size:small">To calculate gaussian blur we have to complete the following steps:</div>
<ol>
<li>
<div style="font-size:small">Separate RGBA image into red, green, and blue channels;</div>
</li><li>
<div style="font-size:small">Apply gaussian blur to each channel, one at a time;</div>
</li><li>
<div style="font-size:small">Recombine red, green, and blue back into RGBA image.</div>
</li></ol>
<div style="font-size:small">Code that separates the channels looks the following:&nbsp;</div>
<div style="font-size:small">
<div class="endscriptcode">&nbsp;</div>
</div>
<div style="font-size:small">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Kernel&nbsp;separates&nbsp;rgba&nbsp;image&nbsp;into&nbsp;red,&nbsp;green,&nbsp;blue&nbsp;channels</span>&nbsp;
__global__&nbsp;&nbsp;
<span class="cpp__keyword">void</span>&nbsp;gaussian_separate_channels(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;red,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;green,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;blue,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;uchar4*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;rgba,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
.&nbsp;.&nbsp;.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;idx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;c&nbsp;&#43;&nbsp;cols&nbsp;*&nbsp;r;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;current&nbsp;pixel&nbsp;index</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;red&nbsp;&nbsp;[idx]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;rgba[idx].x;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;green[idx]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;rgba[idx].y;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;blue&nbsp;[idx]&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;rgba[idx].z;&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">Here's the blur kernel:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">__global__&nbsp;&nbsp;
<span class="cpp__keyword">void</span>&nbsp;gaussian_blur(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blurredChannel,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;return&nbsp;value:&nbsp;blurred&nbsp;channel&nbsp;(either&nbsp;red,&nbsp;green,&nbsp;or&nbsp;blue)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;inputChannel,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;red,&nbsp;green,&nbsp;or&nbsp;blue&nbsp;channel&nbsp;from&nbsp;the&nbsp;original&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">float</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWeight,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;gaussian&nbsp;filter&nbsp;weights.&nbsp;The&nbsp;weights&nbsp;look&nbsp;like&nbsp;a&nbsp;bell&nbsp;shape.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWidth&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;number&nbsp;of&nbsp;pixels&nbsp;in&nbsp;x&nbsp;and&nbsp;y&nbsp;directions&nbsp;for&nbsp;calculating&nbsp;average&nbsp;blurring</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
.&nbsp;.&nbsp;.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;half&nbsp;&nbsp;&nbsp;=&nbsp;filterWidth&nbsp;/&nbsp;<span class="cpp__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blur&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>.f;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;will&nbsp;contained&nbsp;blurred&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width&nbsp;&nbsp;=&nbsp;cols&nbsp;-&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;height&nbsp;=&nbsp;rows&nbsp;-&nbsp;<span class="cpp__number">1</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;i&nbsp;=&nbsp;-half;&nbsp;i&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;i)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;rows</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;j&nbsp;=&nbsp;-half;&nbsp;j&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;j)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;columns</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Clamp&nbsp;filter&nbsp;to&nbsp;the&nbsp;image&nbsp;border</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;h&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;min(max(r&nbsp;&#43;&nbsp;i,&nbsp;<span class="cpp__number">0</span>),&nbsp;height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;w&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;min(max(c&nbsp;&#43;&nbsp;j,&nbsp;<span class="cpp__number">0</span>),&nbsp;width);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Blur&nbsp;is&nbsp;a&nbsp;product&nbsp;of&nbsp;current&nbsp;pixel&nbsp;value&nbsp;and&nbsp;weight&nbsp;of&nbsp;that&nbsp;pixel.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Remember&nbsp;that&nbsp;sum&nbsp;of&nbsp;all&nbsp;weights&nbsp;equals&nbsp;to&nbsp;1,&nbsp;so&nbsp;we&nbsp;are&nbsp;averaging&nbsp;sum&nbsp;of&nbsp;all&nbsp;pixels&nbsp;by&nbsp;their&nbsp;weight.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;w&nbsp;&#43;&nbsp;cols&nbsp;*&nbsp;h;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;current&nbsp;pixel&nbsp;index</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;&nbsp;&nbsp;&nbsp;pixel&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">float</span>&gt;(inputChannel[idx]);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;idx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;(i&nbsp;&#43;&nbsp;half)&nbsp;*&nbsp;filterWidth&nbsp;&#43;&nbsp;j&nbsp;&#43;&nbsp;half;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;&nbsp;&nbsp;&nbsp;weight&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;filterWeight[idx];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blur&nbsp;&#43;=&nbsp;pixel&nbsp;*&nbsp;weight;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;blurredChannel[c&nbsp;&#43;&nbsp;r&nbsp;*&nbsp;cols]&nbsp;=&nbsp;<span class="cpp__keyword">static_cast</span>&lt;unsigned&nbsp;<span class="cpp__datatype">char</span>&gt;(blur);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">Convolution matrix, 9x9 in our case, is a table of weight values where sum of all weights&nbsp;totals to 1. We have to 'cover' a pixel that we are computing blur for with the weight matrix, find a pixel under each cell of the matrix
 and multiply color value in that pixel by that of the weight. Summing all products up will produce average pixel color value for the entire region covered by the convolution matrix, that is the new color valur of the pixel. We have to be careful around image
 edges where we have to clip convolution matrix to image boundaries.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">To recombine channels we have to do the following:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Recombines&nbsp;red,&nbsp;green,&nbsp;and&nbsp;blue&nbsp;channels&nbsp;into&nbsp;an&nbsp;RGB&nbsp;image.</span>&nbsp;
<span class="cpp__com">//&nbsp;Alpha&nbsp;channel&nbsp;is&nbsp;set&nbsp;to&nbsp;255&nbsp;or&nbsp;opaque.</span>&nbsp;
__global__&nbsp;
<span class="cpp__keyword">void</span>&nbsp;gaussian_recombine_channels(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;uchar4*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rgba,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;red,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;green,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;blue,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
.&nbsp;.&nbsp;.&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;idx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;y&nbsp;&#43;&nbsp;cols&nbsp;*&nbsp;x;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;current&nbsp;pixel&nbsp;index</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Copy&nbsp;channels&nbsp;to&nbsp;the&nbsp;local&nbsp;variables</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>&nbsp;r&nbsp;=&nbsp;red[idx];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>&nbsp;g&nbsp;=&nbsp;green[idx];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>&nbsp;b&nbsp;=&nbsp;blue[idx];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Combine,&nbsp;setting&nbsp;alpha&nbsp;to&nbsp;255</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;uchar4&nbsp;pixel&nbsp;=&nbsp;make_uchar4(r,&nbsp;g,&nbsp;b,&nbsp;<span class="cpp__number">255</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Update&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;rgba[idx]&nbsp;=&nbsp;pixel;&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">That was relatively straight forward.</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<div class="endscriptcode">To execute the kernels we have to decide on number of threads to allocate and from that to calculate how many blocks of threads the image requires, then call each kernel one at a time. In my case, i am allocating 32 threads for
 x and y dimensions for the total of 32x32=1024, maximum number of threads per block for my GPU:</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Applies&nbsp;gaussian&nbsp;blur&nbsp;to&nbsp;an&nbsp;r8g8b8a8&nbsp;image.</span>&nbsp;
<span class="cpp__com">//&nbsp;Returns&nbsp;blurredimage.</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;RunGaussianBlurKernel(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;uchar4*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blurredImage,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Return&nbsp;value:&nbsp;blurred&nbsp;rgba&nbsp;image&nbsp;with&nbsp;alpha&nbsp;set&nbsp;to&nbsp;255&nbsp;or&nbsp;opaque.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;uchar4*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;originalImage,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;red,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;red&nbsp;channel&nbsp;from&nbsp;the&nbsp;original&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;green,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;green&nbsp;channel&nbsp;from&nbsp;the&nbsp;original&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;blue,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;blue&nbsp;channel&nbsp;from&nbsp;the&nbsp;original&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;redBlurred,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;red&nbsp;channel&nbsp;from&nbsp;the&nbsp;blurred&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;greenBlurred,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;green&nbsp;channel&nbsp;from&nbsp;the&nbsp;blurred&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;unsigned&nbsp;<span class="cpp__datatype">char</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;blueBlurred,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;blue&nbsp;channel&nbsp;from&nbsp;the&nbsp;blurred&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">float</span>*&nbsp;<span class="cpp__keyword">const</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWeight,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;gaussian&nbsp;filter&nbsp;weights.&nbsp;The&nbsp;weights&nbsp;look&nbsp;like&nbsp;a&nbsp;bell&nbsp;shape.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWidth,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;number&nbsp;of&nbsp;pixels&nbsp;in&nbsp;x&nbsp;and&nbsp;y&nbsp;directions&nbsp;for&nbsp;calculating&nbsp;average&nbsp;blurring</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;image&nbsp;size:&nbsp;number&nbsp;of&nbsp;rows</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;image&nbsp;size:&nbsp;number&nbsp;of&nbsp;columns</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">char</span>*&nbsp;func&nbsp;=&nbsp;<span class="cpp__string">&quot;RunGaussianBlurKernel&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;cudaError&nbsp;hr&nbsp;=&nbsp;cudaSuccess;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">static</span>&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;BLOCK_WIDTH&nbsp;=&nbsp;<span class="cpp__number">32</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;threads&nbsp;per&nbsp;block;&nbsp;because&nbsp;we&nbsp;are&nbsp;setting&nbsp;2-dimensional&nbsp;block,&nbsp;the&nbsp;total&nbsp;number&nbsp;of&nbsp;threads&nbsp;is&nbsp;32^2,&nbsp;or&nbsp;1024</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;1024&nbsp;is&nbsp;the&nbsp;maximum&nbsp;number&nbsp;of&nbsp;threads&nbsp;per&nbsp;block&nbsp;for&nbsp;modern&nbsp;GPUs.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;x&nbsp;=&nbsp;<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">int</span>&gt;(ceilf(<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">float</span>&gt;(cols)&nbsp;/&nbsp;BLOCK_WIDTH));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;y&nbsp;=&nbsp;<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">int</span>&gt;(ceilf(<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">float</span>&gt;(rows)&nbsp;/&nbsp;BLOCK_WIDTH));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;dim3&nbsp;grid&nbsp;(x,&nbsp;y,&nbsp;<span class="cpp__number">1</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;number&nbsp;of&nbsp;blocks</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;dim3&nbsp;block(BLOCK_WIDTH,&nbsp;BLOCK_WIDTH,&nbsp;<span class="cpp__number">1</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;block&nbsp;width:&nbsp;number&nbsp;of&nbsp;threads&nbsp;per&nbsp;block</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Separate&nbsp;RGBA&nbsp;image&nbsp;into&nbsp;different&nbsp;color&nbsp;channels</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gaussian_separate_channels&lt;&lt;&lt;grid,&nbsp;block&gt;&gt;&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;red,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;green,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blue,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;originalImage,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaDeviceSynchronize();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK_CUDA_ERROR(hr,&nbsp;func,&nbsp;<span class="cpp__string">&quot;separate_channels&nbsp;kernel&nbsp;failed.&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Call&nbsp;convolution&nbsp;kernel&nbsp;for&nbsp;the&nbsp;total&nbsp;of&nbsp;3&nbsp;times,&nbsp;once&nbsp;for&nbsp;each&nbsp;channel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gaussian_blur&lt;&lt;&lt;grid,&nbsp;block&gt;&gt;&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;red,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWeight,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaDeviceSynchronize();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK_CUDA_ERROR(hr,&nbsp;func,&nbsp;<span class="cpp__string">&quot;gaussian_blur&nbsp;kernel&nbsp;failed&nbsp;-&nbsp;red&nbsp;channel&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gaussian_blur&lt;&lt;&lt;grid,&nbsp;block&gt;&gt;&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greenBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;green,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWeight,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaDeviceSynchronize();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK_CUDA_ERROR(hr,&nbsp;func,&nbsp;<span class="cpp__string">&quot;gaussian_blur&nbsp;kernel&nbsp;failed&nbsp;-&nbsp;green&nbsp;channel&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gaussian_blur&lt;&lt;&lt;grid,&nbsp;block&gt;&gt;&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blue,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWeight,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filterWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaDeviceSynchronize();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK_CUDA_ERROR(hr,&nbsp;func,&nbsp;<span class="cpp__string">&quot;gaussian_blur&nbsp;kernel&nbsp;failed&nbsp;-&nbsp;blue&nbsp;channel&quot;</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Recombine&nbsp;red,&nbsp;green,and&nbsp;blue&nbsp;channels&nbsp;into&nbsp;an&nbsp;RGB&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;gaussian_recombine_channels&lt;&lt;&lt;grid,&nbsp;block&gt;&gt;&gt;(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blurredImage,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;redBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;greenBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;blueBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rows,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cols&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaDeviceSynchronize();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CHECK_CUDA_ERROR(hr,&nbsp;func,&nbsp;<span class="cpp__string">&quot;gaussian_recombine_channels&nbsp;kernel&nbsp;failed.&quot;</span>);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">The rest is similar to the previous example where&nbsp;we have to:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<ol>
<li>
<div class="endscriptcode">Allocate memory on the host and device for input and output RGBA images;&nbsp;red,&nbsp;green, blue normal and blurred channels; weights convolution matrix;</div>
</li><li>
<div class="endscriptcode">Execute blur kernels;</div>
</li><li>
<div class="endscriptcode">Copy blured image from the device to the CPU and save it to disk.</div>
</li></ol>
</div>
<p class="endscriptcode">Here's the function that does all that:</p>
<p class="endscriptcode"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Applies&nbsp;gaussian&nbsp;blur&nbsp;to&nbsp;an&nbsp;image</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;BlurFilter::GaussianBlur(<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">string</span>&amp;&nbsp;imagePath,&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">string</span>&amp;&nbsp;outputPath)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Load&nbsp;image&nbsp;and&nbsp;initialize&nbsp;kernel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;KernelMap&nbsp;host;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeKernel(host,&nbsp;imagePath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CreateGaussianFilter();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AllocateChannels();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Run&nbsp;kernel:&nbsp;convert&nbsp;rgba&nbsp;image&nbsp;to&nbsp;modifiedImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;RunGaussianBlurKernel(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.modifiedImage,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.originalImage,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.red,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.green,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.blue,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.redBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.greenBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.blueBlurred,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_device.filter,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_filter.width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_host.originalImage.rows,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_host.originalImage.cols&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Save&nbsp;modifiedImage&nbsp;image&nbsp;to&nbsp;disk</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SaveImageToDisk(outputPath);<span class="cpp__preproc">&nbsp;
&nbsp;
#if&nbsp;0&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;//&nbsp;Change&nbsp;to&nbsp;1&nbsp;to&nbsp;enable</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Validate&nbsp;GPU&nbsp;convertion&nbsp;against&nbsp;CPU&nbsp;result.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Only&nbsp;turn&nbsp;it&nbsp;when&nbsp;you&nbsp;want&nbsp;to&nbsp;run&nbsp;validation&nbsp;because&nbsp;CPU&nbsp;calculation&nbsp;will&nbsp;be&nbsp;slow.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;VerifyGpuComputation(host.originalImage);<span class="cpp__preproc">&nbsp;
#endif</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Release&nbsp;cuda</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaFree(m_device.modifiedImage);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;hr&nbsp;=&nbsp;cudaFree(m_device.originalImage);&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="endscriptcode">We should check results of blurring by runnig the same calculation on CPU and comparing pixels. That is what VerifyGpuComputation does.</div>
<div style="font-size:small"></div>
</div>
<div class="endscriptcode">The last interesting function is the one creating the convolution matrix:</div>
<div class="endscriptcode"></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus"><span class="cpp__com">//&nbsp;Creates&nbsp;gaussian&nbsp;filter&nbsp;based&nbsp;on&nbsp;G(x,y)&nbsp;formula:&nbsp;http://en.wikipedia.org/wiki/Gaussian_blur.</span>&nbsp;
<span class="cpp__keyword">void</span>&nbsp;BlurFilter::CreateGaussianFilter()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;width&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">9</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;This&nbsp;is&nbsp;stencil&nbsp;width,&nbsp;or&nbsp;how&nbsp;many&nbsp;pixels&nbsp;in&nbsp;each&nbsp;row&nbsp;or&nbsp;column&nbsp;should&nbsp;we&nbsp;include&nbsp;in&nbsp;blurring&nbsp;function.&nbsp;SHould&nbsp;be&nbsp;odd.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">float</span>&nbsp;sigma&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">2</span>.f;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Standard&nbsp;deviation&nbsp;of&nbsp;the&nbsp;Gaussian&nbsp;distribution.</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">const</span>&nbsp;<span class="cpp__datatype">int</span>&nbsp;&nbsp;&nbsp;&nbsp;half&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;width&nbsp;/&nbsp;<span class="cpp__number">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;=&nbsp;<span class="cpp__number">0</span>.f;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_filter.width&nbsp;=&nbsp;width;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Create&nbsp;convolution&nbsp;matrix</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;m_filter.weight.resize(width&nbsp;*&nbsp;width);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Calculate&nbsp;filter&nbsp;sum&nbsp;first</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;r&nbsp;=&nbsp;-half;&nbsp;r&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;r)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;c&nbsp;=&nbsp;-half;&nbsp;c&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;c)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;e&nbsp;(natural&nbsp;logarithm&nbsp;base)&nbsp;to&nbsp;the&nbsp;power&nbsp;x,&nbsp;where&nbsp;x&nbsp;is&nbsp;what's&nbsp;in&nbsp;the&nbsp;brackets</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;weight&nbsp;=&nbsp;expf(-<span class="cpp__keyword">static_cast</span>&lt;<span class="cpp__datatype">float</span>&gt;(c&nbsp;*&nbsp;c&nbsp;&#43;&nbsp;r&nbsp;*&nbsp;r)&nbsp;/&nbsp;(<span class="cpp__number">2</span>.f&nbsp;*&nbsp;sigma&nbsp;*&nbsp;sigma));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;idx&nbsp;=&nbsp;(r&nbsp;&#43;&nbsp;half)&nbsp;*&nbsp;width&nbsp;&#43;&nbsp;c&nbsp;&#43;&nbsp;half;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_filter.weight[idx]&nbsp;=&nbsp;weight;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sum&nbsp;&#43;=&nbsp;weight;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__com">//&nbsp;Normalize&nbsp;weight:&nbsp;sum&nbsp;of&nbsp;weights&nbsp;must&nbsp;equal&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">float</span>&nbsp;normal&nbsp;=&nbsp;<span class="cpp__number">1</span>.f&nbsp;/&nbsp;sum;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;r&nbsp;=&nbsp;-half;&nbsp;r&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;r)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">for</span>&nbsp;(<span class="cpp__datatype">int</span>&nbsp;c&nbsp;=&nbsp;-half;&nbsp;c&nbsp;&lt;=&nbsp;half;&nbsp;&#43;&#43;c)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__datatype">int</span>&nbsp;idx&nbsp;=&nbsp;(r&nbsp;&#43;&nbsp;half)&nbsp;*&nbsp;width&nbsp;&#43;&nbsp;c&nbsp;&#43;&nbsp;half;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;m_filter.weight[idx]&nbsp;*=&nbsp;normal;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">In the main function we can now call our code:</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C&#43;&#43;</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">cplusplus</span>

<div class="preview">
<pre class="cplusplus">&nbsp;&nbsp;&nbsp;&nbsp;BlurFilter&nbsp;gaussian;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gaussian.GaussianBlur(imagePath,&nbsp;outputPath);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cpp__keyword">catch</span>(exception&amp;&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cerr&nbsp;&lt;&lt;&nbsp;endl&nbsp;&lt;&lt;&nbsp;<span class="cpp__string">&quot;ERROR:&nbsp;&quot;</span>&nbsp;&lt;&lt;&nbsp;e.what()&nbsp;&lt;&lt;&nbsp;endl;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;exit(<span class="cpp__number">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
We are done!&nbsp;&nbsp;</div>
<p></p>
</div>
<div style="font-size:small">
<div class="endscriptcode">&nbsp;</div>
</div>
<h1>Source Code Files</h1>
<dl><dt>program.cpp - main function.</dt><dt>BlurFilter.h and BlurFilter.cpp - responsible for loading and saving images, initializing CUDA kernel and managing memory;</dt><dt>GaussianBlur.cu - CUDA kernel and function needed to run them;</dt><dt>utilities - checks runtime errors and compares pixels from GPU conversion to reference conversion on CPU;</dt><dt>gputimer - events to measure execution time on the GPU in milliseconds</dt></dl>
<div>&nbsp;</div>
<div>&nbsp;</div>
<dl></dl>
