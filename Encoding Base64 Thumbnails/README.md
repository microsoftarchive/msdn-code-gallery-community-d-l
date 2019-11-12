# Encoding Base64 Thumbnails
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- GDI+
- ASP.NET
- .NET
- ASP.NET MVC
- ASP.NET Dynamic Data
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- .NET Framework
- ASP.NET MVC 3
- ASP.NET Web Forms
- .NET Framework 4.0
- ASP.NET MVC 4
- Graphics Functions
- ASP.NET Code Sample Downloads
- Microsoft .NET Framework 3.5 SP1
- ASP.NET Web API
- ASP.NET 4.5
- asp.net 4.0
- .NET 4.5
- ASP.NET MVC3
## Topics
- Graphics
- C#
- GDI+
- Images
- Image manipulation
- Image Gallery
- Thumbnail Handler
- Image
- HTML
- HTML5
- Thumbnail
- Generic C# resuable code
- Image Optimization
- C# Language Features
- Base64 Encoding
- Load Image
## Updated
- 03/07/2013
## Description

<h1>Introduction</h1>
<p>This article details how to read <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> files from the file system, create thumbnails and then encoding thumbnail images to Base64 strings.</p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements or instructions for building the sample.</p>
<h1><span style="font-size:20px; font-weight:bold">Images as Base64 strings</span></h1>
<p>From <a href="http://en.wikipedia.org/wiki/Base64">Wikipedia</a>:</p>
<blockquote>
<p><strong>Base64</strong> is a group of similar encoding schemes that represent <a href="http://en.wikipedia.org/wiki/Binary_data">
binary data</a> in an ASCII string format by translating it into a <a href="http://en.wikipedia.org/wiki/Radix">
radix</a>-64 representation. The Base64 term originates from a specific <a href="http://en.wikipedia.org/wiki/MIME#Content-Transfer-Encoding">
MIME content transfer encoding</a>.</p>
<p>Base64 encoding schemes are commonly used when there is a need to encode binary data that need to be stored and transferred over media that are designed to deal with textual data. This is to ensure that the data remain intact without modification during
 transport. Base64 is commonly used in a number of applications including <a href="http://en.wikipedia.org/wiki/Email">
email</a> via <a href="http://en.wikipedia.org/wiki/MIME">MIME</a>, and storing complex data in
<a href="http://en.wikipedia.org/wiki/XML">XML</a>.</p>
</blockquote>
<p>From the definition quoted above the need for base64 encoding becomes more clear. From
<a href="http://msdn.microsoft.com/en-us/library/dhx0d524.aspx">MSDN documentation</a>:</p>
<blockquote>
<p>The base-64 digits in ascending order from zero are the uppercase characters &quot;A&quot; to &quot;Z&quot;, the lowercase characters &quot;a&quot; to &quot;z&quot;, the numerals &quot;0&quot; to &quot;9&quot;, and the symbols &quot;&#43;&quot; and &quot;/&quot;. The valueless character, &quot;=&quot;, is used for trailing padding.</p>
</blockquote>
<p>Base64 encoding allows developers to expose binary data without potentially encountering conflicts in regards to the transfer medium. Base64 encoded binary data serves ideally when performing data transfer operations using platforms such as html, xml, email.</p>
<p>A common implementation of Base64 encoding can be found when transferring image data. This article details how to convert/encode
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> object thumbnails to Base64 strings.</p>
<h1>Base64 Image encoding implemented as an extension method</h1>
<p>The code snippet listed below details the <strong><em>ToBase64String</em></strong> extension method targeting the
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> class.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToBase64String(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;bmp)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bmp.Save(memoryStream,&nbsp;ImageFormat.Png);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exc)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;String.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Position&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;byteBuffer&nbsp;=&nbsp;memoryStream.ToArray();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;Convert.ToBase64String(byteBuffer,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Base64FormattingOptions.InsertLineBreaks);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;byteBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;base64String;&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The <strong><em>ToBase64String </em></strong>method writes the targeted
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> object&rsquo;s pixel data to a <a title="MemoryStream" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.io.memorystream.aspx" target="_blank">
MemoryStream</a> object using the Png <a title="ImageFormat" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageformat.aspx" target="_blank">
ImageFormat</a>. Next a byte array is extracted and passed to the method <a title="Convert.ToBase64String" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.convert.tobase64string.aspx" target="_blank">
Convert.ToBase64String</a>, which is responsible for implementing the Base64 encoding.</p>
</div>
<h1>Creating an Image tag implementing a Base64 string</h1>
<p>The sample source code in addition also defines an extension method to generate html image tags to display a Base64 string encoded image.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToBase64ImageTag(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;bmp)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;imgTag&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;bmp.ToBase64String();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;img&nbsp;src=\\&quot;</span>data:image/<span class="cs__string">&quot;&nbsp;&#43;&nbsp;&quot;</span>png&quot;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;;base64,&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;base64String&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\&quot;</span>&nbsp;&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;width=\\&quot;</span>&quot;&nbsp;&#43;&nbsp;bmp.Width.ToString()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\&quot;</span>&nbsp;&quot;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;height=\\&quot;</span>&quot;&nbsp;&#43;&nbsp;bmp.Height.ToString()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\\&quot;</span>&nbsp;/&gt;&quot;;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;imgTag;&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The <strong><em>ToBase64ImageTag</em></strong> extension method invokes the
<strong><em>ToBase64String</em></strong> extension method in order to retrieve encoded data. The Html image tag has only to be slightly modified from the norm in order to accommodate Base64 encoded strings.</p>
</div>
<h1>Creating Image thumbnails</h1>
<p>The <a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> class conveniently provides the method <a title="GetThumbnailImage" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.getthumbnailimage.aspx" target="_blank">
GetThumbnailImage</a>, which we&rsquo;ll be using to create thumbnails from existing
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> objects. The sample source code defines the method <em><strong>ToBase64Thumbnail</strong></em>, as listed below:</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToBase64Thumbnail(<span class="cs__keyword">this</span>&nbsp;Image&nbsp;bmp,&nbsp;<span class="cs__keyword">int</span>&nbsp;width,&nbsp;<span class="cs__keyword">int</span>&nbsp;height,&nbsp;<span class="cs__keyword">bool</span>&nbsp;wrapImageTag)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Image.GetThumbnailImageAbort&nbsp;callback&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Image.GetThumbnailImageAbort(ThumbnailCallback);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;thumbnailImage&nbsp;=&nbsp;bmp.GetThumbnailImage(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width,&nbsp;height,&nbsp;callback,&nbsp;<span class="cs__keyword">new</span>&nbsp;IntPtr());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String&nbsp;=&nbsp;String.Empty;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(wrapImageTag&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;thumbnailImage.ToBase64ImageTag();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;thumbnailImage.ToBase64String();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;thumbnailImage.Dispose();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;base64String;&nbsp;
}&nbsp;
&nbsp;&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;ThumbnailCallback()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The <strong><em>ToBase64Thumbnail</em></strong> method is defined as an extension method targeting the
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> class. The calling code is required to specify the width and height of the output thumbnails and in addition whether to wrap the base64 encoded string in an
<strong><em>Html &lt;img&gt;</em></strong> tag.</p>
</div>
<p>Note the definition of <strong><em>ThumnailCallback</em></strong>, the <a title="GetThumbnailImage" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.getthumbnailimage.aspx" target="_blank">
GetThumbnailImage</a> method requires calling code to specify a callback delegate.</p>
<p>Based on the value of the parameter <strong><em>wrapImageTag</em></strong>, we next invoke either
<strong><em>ToBase64ImageTag</em></strong> or <strong><em>ToBase64String</em></strong>, as defined/discussed earlier.</p>
<h1>Reading Image files from the file system</h1>
<p>The starting point in creating Base64 encoded thumbnails would be to read the local file system, searching for image files. The
<strong><em>ToBase64Thumbnails</em></strong> method is defined as an extension method targeting the string class. When invoking the
<strong><em>ToBase64Thumbnails</em></strong> method users are expected to provide a directory path, width and height of output thumbnails, whether to add
<strong><em>Html &lt;img&gt;</em></strong> tags and which file types to process. The code snippet below details the implementation of the
<strong><em>ToBase64Thumbnails</em></strong> method.</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;ToBase64Thumbnails(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;path,&nbsp;<span class="cs__keyword">int</span>&nbsp;width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;height,&nbsp;<span class="cs__keyword">bool</span>&nbsp;wrapImageTag,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">params</span>&nbsp;<span class="cs__keyword">string</span>[]&nbsp;fileTypes)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;base64Thumbnails&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;searchFilter&nbsp;=&nbsp;String.Empty;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(fileTypes&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;fileTypes.Length;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searchFilter&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;*.&quot;</span>&nbsp;&#43;&nbsp;fileTypes[k];&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(k&nbsp;&lt;&nbsp;fileTypes.Length&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searchFilter&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;|&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searchFilter&nbsp;=&nbsp;<span class="cs__string">&quot;*.*&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>[]&nbsp;files&nbsp;=&nbsp;Directory.GetFiles(path,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;searchFilter);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;files.Length;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;streamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader(files[k]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;img&nbsp;=&nbsp;Image.FromStream(streamReader.BaseStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;streamReader.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;base64Thumbnails.Add(img.ToBase64Thumbnail(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;width,&nbsp;height,&nbsp;wrapImageTag));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;img.Dispose();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;base64Thumbnails;&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The <strong><em>ToBase64Thumbnails</em></strong> method implements the static method
<a title="Directory.GetFiles" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.io.directory.getfiles.aspx" target="_blank">
Directory.GetFiles</a> in order to search a specified directory path. When invoking the
<strong><em>ToBase64Thumbnails</em></strong> method the calling code can optionally specify a number of file extensions, which results in only files having file extensions conforming to the specified extensions being encoded.</p>
</div>
<p>Once an array of file paths have been determined the sample code iterates the array creating an
<a title="Image" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.image.aspx" target="_blank">
Image</a> object of each file specified. The final step required is to invoke the extension method
<strong><em>ToBase64Thumbnail</em></strong>.</p>
<h1>The implementation</h1>
<p>The sample source code defines a console based application, used to test/illustrate creating Base64 encoded thumbnails based on a specified directory path.&nbsp; Included in the sample code is a template html file. The Main method generates a list of Base64
 encoded thumbnails by invoking <strong><em>ToBase64Thumbnails</em></strong>, defined as an extension method targeting the String class. The resulting Base64 encoded thumbnails are defined as
<strong><em>Html &lt;img&gt;</em></strong> tags, added to a copy of the html template file. The Console application&rsquo;s definition:</p>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;path&nbsp;=&nbsp;<span class="cs__string">&quot;Images&quot;</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;List&lt;<span class="cs__keyword">string</span>&gt;&nbsp;thumbnailTags&nbsp;=&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;path.ToBase64Thumbnails(<span class="cs__number">100</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__keyword">true</span>,&nbsp;<span class="cs__keyword">null</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;streamreader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;StreamReader(<span class="cs__string">&quot;HtmlTemplate.htm&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;htmlPage&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;streamreader.ReadToEnd());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;streamreader.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StringBuilder&nbsp;imageTags&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StringBuilder();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;k&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;k&nbsp;&lt;&nbsp;thumbnailTags.Count;&nbsp;k&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageTags.AppendLine(<span class="cs__string">&quot;&lt;p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageTags.AppendLine(thumbnailTags[k]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageTags.AppendLine(<span class="cs__string">&quot;&lt;/p&gt;&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;htmlPage.Replace(<span class="cs__string">&quot;&lt;!--Tags_Placeholder--&gt;&quot;</span>,&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imageTags.ToString());&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StreamWriter&nbsp;streamwriter&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamWriter(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__string">&quot;TempPage.htm&quot;</span>,&nbsp;<span class="cs__keyword">false</span>,&nbsp;Encoding.UTF8);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;streamwriter.Write(htmlPage.ToString());&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;streamwriter.Close();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Process.Start(<span class="cs__string">&quot;TempPage.htm&quot;</span>);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
}</pre>
</div>
</div>
</div>
<p class="endscriptcode">The resulting Base64 encoded image thumbnails viewed as
<strong><em>html &lt;img&gt;</em></strong> tags forming part of an html file, as viewed in Microsoft Internet Explorer 9:</p>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode"><img id="77363" src="77363-base64thumbnails.png" alt="" width="250" height="725"></div>
</div>
<div><span>&nbsp;</span></div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtBitmap.cs - Implements the definition of&nbsp;encoding extension methods</em>
</li><li><em>Program.cs - Console Application responsible for implementing extension methods/Test application, creates html page displaying thumbnails.</em>
</li></ul>
<h1>More Information</h1>
<p>This article is based on an article originally posted on my <a href="http://softwarebydefault.com">
blog</a>:&nbsp;<a href="http://softwarebydefault.com/2013/03/08/base64-thumbnails/">http://softwarebydefault.com/2013/03/08/base64-thumbnails/</a> If you have any questions/comments please feel free to make use of the Q&amp;A section on this page, also please
 remember to rate this article.</p>
<p><strong><em>Dewald Esterhuizen</em></strong></p>
