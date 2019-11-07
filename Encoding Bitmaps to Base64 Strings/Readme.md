# Encoding Bitmaps to Base64 Strings
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- WCF
- JSON
- GDI+
- ASP.NET
- .NET
- IIS
- XML
- .NET Framework 4
- .NET 3.0
- .NET Framework 3.5 SP1
- Web Services
- .NET Framework
- .NET Framework 4.0
- Windows General
- ASMX web services
- C# Language
- HTML
- Converter
- XmlSerializer
- Internet Explorer
- HTML5
- Graphics Functions
- ASP.NET Code Sample Downloads
- Image process
- ASP.NET 4.5
- .NET 4.5
## Topics
- Graphics
- C#
- WCF
- JSON
- GDI+
- ASP.NET
- XML
- Images
- Web Services
- File mapping
- Extensibility
- Image Gallery
- Image
- WebBrowser
- HttpWebRequest
- HTML
- HTML5
- .NET 4
- Imaging
- How to
- Generic C# resuable code
- Extension
- Files
- web service
- WebParts
- C# Language Features
- Data Export
- Base64 Encoding
- Windows web services
- Webpage
- content management
- WebService
- Load Image
## Updated
- 03/01/2013
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p class="paragraphStyle">This article explores encoding Bitmap images to Base64 strings. Encoding is implemented by means of an extension method targeting the Bitmap class.</p>
<p class="paragraphStyle"><strong>Update: </strong>I've published&nbsp;a follow up article detailing how to convert/decode Base64 strings back into Bitmap images:
<a title="Encoding Bitmaps to Base64 Strings" href="http://code.msdn.microsoft.com/Encoding-Bitmaps-to-Base64-603248e3">
Encoding Bitmaps to Base64 Strings</a></p>
<h1><span>Building the Sample</span></h1>
<p class="paragraphStyle">There are no special requirements or instructions for building the sample.</p>
<h1><span style="font-size:20px">Description: Images as Base64 strings</span></h1>
<p class="paragraphStyle">From <a title="Wiki Base64" rel="tag" href="http://en.wikipedia.org/wiki/Base64" target="_blank">
Wikipedia</a>:</p>
<blockquote>
<p class="paragraphStyle"><strong>Base64</strong> is a group of similar encoding schemes that represent
<a href="http://en.wikipedia.org/wiki/Binary_data">binary data</a> in an ASCII string format by translating it into a
<a href="http://en.wikipedia.org/wiki/Radix">radix</a>-64 representation. The Base64 term originates from a specific
<a href="http://en.wikipedia.org/wiki/MIME#Content-Transfer-Encoding">MIME content transfer encoding</a>.</p>
<p class="paragraphStyle">Base64 encoding schemes are commonly used when there is a need to encode binary data that need to be stored and transferred over media that are designed to deal with textual data. This is to ensure that the data remain intact without
 modification during transport. Base64 is commonly used in a number of applications including
<a href="http://en.wikipedia.org/wiki/Email">email</a> via <a href="http://en.wikipedia.org/wiki/MIME">
MIME</a>, and storing complex data in <a href="http://en.wikipedia.org/wiki/XML">
XML</a>.</p>
</blockquote>
<p class="paragraphStyle">From the definition quoted above the need for base64 encoding becomes more clear. From
<a title="MSDN documentation" href="http://msdn.microsoft.com/en-us/library/dhx0d524.aspx" target="_blank">
MSDN documentation</a>:</p>
<blockquote>
<p class="paragraphStyle">The base-64 digits in ascending order from zero are the uppercase characters &quot;A&quot; to &quot;Z&quot;, the lowercase characters &quot;a&quot; to &quot;z&quot;, the numerals &quot;0&quot; to &quot;9&quot;, and the symbols &quot;&#43;&quot; and &quot;/&quot;. The valueless character, &quot;=&quot;, is used for trailing
 padding.</p>
</blockquote>
<p class="paragraphStyle">Base64 encoding allows developers to expose binary data without potentially encountering conflicts in regards to the transfer medium. Base64 encoded binary data serves ideally when performing data transfer operations implementing
 platforms such as html, xml, email.</p>
<p class="paragraphStyle">A common implementation of Base64 encoding can be found when transferring image data. This article details how to convert/encode a
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> object to a Base64 string.</p>
<h1>Base64 Bitmap encoding implemented as an extension method</h1>
<p class="paragraphStyle">The code snippet listed below details the <strong><em>ToBase64String</em></strong> extension method targeting the
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> class.</p>
<p class="paragraphStyle">&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static string ToBase64String(this Bitmap bmp, ImageFormat imageFormat)
{
    string base64String = string.Empty;

    MemoryStream memoryStream = new MemoryStream();
    bmp.Save(memoryStream, imageFormat);

    memoryStream.Position = 0;
    byte[] byteBuffer = memoryStream.ToArray();

    memoryStream.Close();

    base64String = Convert.ToBase64String(byteBuffer);
    byteBuffer = null;

    return base64String;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToBase64String(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;bmp,&nbsp;ImageFormat&nbsp;imageFormat)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MemoryStream&nbsp;memoryStream&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;MemoryStream();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bmp.Save(memoryStream,&nbsp;imageFormat);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Position&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">byte</span>[]&nbsp;byteBuffer&nbsp;=&nbsp;memoryStream.ToArray();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;memoryStream.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;Convert.ToBase64String(byteBuffer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;byteBuffer&nbsp;=&nbsp;<span class="cs__keyword">null</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;base64String;&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p class="paragraphStyle">The <strong><em>ToBase64String </em></strong>method writes the targeted
<a title="Bitmap" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.bitmap.aspx" target="_blank">
Bitmap</a> object&rsquo;s pixel data to a <a title="MemoryStream" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.io.memorystream.aspx" target="_blank">
MemoryStream</a> object using the specified <a title="ImageFormat" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.drawing.imaging.imageformat.aspx" target="_blank">
ImageFormat</a> parameter. Next a byte array is extracted and passed to the method
<a title="Convert.ToBase64String" rel="tag" href="http://msdn.microsoft.com/en-us/library/system.convert.tobase64string.aspx" target="_blank">
Convert.ToBase64String</a>, which is responsible for implementing the Base64 encoding.</p>
<h1>Creating an Image tag implementing a Base64 string</h1>
<p class="paragraphStyle">The sample source code in addition also defines an extension method to generate html image tags to display a Base64 string encoded image.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static string ToBase64ImageTag(this Bitmap bmp, ImageFormat imageFormat)
{
    string imgTag = string.Empty;
    string base64String = string.Empty;

    base64String = bmp.ToBase64String(imageFormat);

    imgTag = &quot;&lt;img src=\&quot;data:image/&quot; &#43; imageFormat.ToString() &#43; &quot;;base64,&quot;;
    imgTag &#43;= base64String &#43; &quot;\&quot; &quot;;
    imgTag &#43;= &quot;width=\&quot;&quot; &#43; bmp.Width.ToString() &#43; &quot;\&quot; &quot;;
    imgTag &#43;= &quot;height=\&quot;&quot; &#43; bmp.Height.ToString() &#43; &quot;\&quot; /&gt;&quot;;

    return imgTag;
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ToBase64ImageTag(<span class="cs__keyword">this</span>&nbsp;Bitmap&nbsp;bmp,&nbsp;ImageFormat&nbsp;imageFormat)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;imgTag&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64String&nbsp;=&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;base64String&nbsp;=&nbsp;bmp.ToBase64String(imageFormat);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;=&nbsp;<span class="cs__string">&quot;&lt;img&nbsp;src=\&quot;data:image/&quot;</span>&nbsp;&#43;&nbsp;imageFormat.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;;base64,&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;base64String&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\&quot;&nbsp;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;width=\&quot;&quot;</span>&nbsp;&#43;&nbsp;bmp.Width.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\&quot;&nbsp;&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;imgTag&nbsp;&#43;=&nbsp;<span class="cs__string">&quot;height=\&quot;&quot;</span>&nbsp;&#43;&nbsp;bmp.Height.ToString()&nbsp;&#43;&nbsp;<span class="cs__string">&quot;\&quot;&nbsp;/&gt;&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;imgTag;&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p class="paragraphStyle">The <strong><em>ToBase64ImageTag</em></strong> extension method invokes the
<strong><em>ToBase64String</em></strong> extension method in order to retrieve encoded the data. The Html image tag has only to be slightly modified from the norm in order to accommodate Base64 encoded strings.</p>
<h1>The implementation</h1>
<p class="paragraphStyle">The two extension methods are implemented using a console based application.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">static void Main(string[] args)
{
    StreamReader streamReader = new StreamReader(&quot;NavForward.png&quot;);
    Bitmap bmp = new Bitmap(streamReader.BaseStream);
    streamReader.Close();

    string base64ImageAndTag = bmp.ToBase64ImageTag(ImageFormat.Png);

    Console.WriteLine(base64ImageAndTag);

    Console.ReadKey();
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;StreamReader&nbsp;streamReader&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;StreamReader(<span class="cs__string">&quot;NavForward.png&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;bmp&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Bitmap(streamReader.BaseStream);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;streamReader.Close();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;base64ImageAndTag&nbsp;=&nbsp;bmp.ToBase64ImageTag(ImageFormat.Png);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.WriteLine(base64ImageAndTag);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Console.ReadKey();&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>ExtBitmap.cs - Implements the definition of ToBase64String() and ToBase64ImageTag() extension methods</em>
</li><li><em>Program.cs - Console Application responsible for implementing extension methods/Test application</em>
</li></ul>
<h1>More Information</h1>
<p class="paragraphStyle">This article is based on an article originally posted on my
<a href="http://softwarebydefault.com">blog</a>: <a href="http://softwarebydefault.com/2013/02/23/bitmap-base64-strings">
http://softwarebydefault.com/2013/02/23/bitmap-base64-strings</a> If you have any questions/comments please feel free to make use of the Q&amp;A section on this page, also please remember to rate this article.</p>
<p class="paragraphStyle"><strong><em>Dewald Esterhuizen</em></strong></p>
