# How to Convert Word to Tiff in C#
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Controls
- C#
- Silverlight
- ASP.NET
- Windows Forms
- WPF
- .NET Framework
- VB.Net
- Visual C#
## Topics
- Controls
- WPF
- Code Sample
- Conversions
- Save file
- .Net Programming
- Word to TIFF
- convert to TIFF in C#
## Updated
- 01/19/2017
## Description

<h1>Introduction</h1>
<p>Compared with raster images, like Jpeg, Jpg, Bmp, Png and Gif, Tiff image is somewhat special since it could be a file with single image page as well as multiple image pages. Due to its special feature, it is common requirement for us to convert Word to
 Tiff. Therefore, this sample will provide you with a coding solution for converting Word document to Tiff with high performance.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample is based on a free .NET library&mdash; <a href="https://www.e-iceblue.com/Introduce/free-doc-component.html">
Free Spire.Doc for .NET</a></p>
<p>Free Spire.Doc for .NET is a professional .NET Word class library to manipulate Word proceeding tasks. It allows developers to convert Word documents to most common and popular formats from any .NET(C#, VB.NET, ASP.NET) platform. Along with Free Spire.Doc
 for .NET, the conversion speed and quality can be highly guaranteed.</p>
<p>To convert Word to Tiff, please execute the following guide.</p>
<p><strong>Running the Sample</strong></p>
<p>To begin with, please make sure you have installed <a href="https://www.e-iceblue.com/Download/download-word-for-net-free.html">
Free Spire.Doc for .NET</a> and added Spire.Doc.dll to your C# programming project as reference.</p>
<p><strong>Step 1</strong>: Create a new document instance and load a Word document from file.</p>
<p><strong>Step 2</strong>: Use document.SaveToImages() method to save the Word document as Image array.</p>
<p><strong>Step 3</strong>: Use JoinTiffImages() method to save the images from Word pages to tiff image type, with the specified encoder and image-encoder parameters.</p>
<p><strong>Using the Code</strong></p>
<p>Now you may directly use the following C# sample code to convert Word file to Tiff.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">namespace convert_word_to_tiff
{
    class Program
    {
        static void Main(string[] args)
        {
            Document document = new Document(@&quot;E:\Program Files\testing.docx&quot;);
            JoinTiffImages(SaveAsImage(document),&quot;result.tiff&quot;,EncoderValue.CompressionLZW);
            System.Diagnostics.Process.Start(&quot;result.tiff&quot;);
        }
        private static Image[] SaveAsImage(Document document)
        {     
            Image[] images = document.SaveToImages(ImageType.Bitmap);    
            return images;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j &lt; encoders.Length; j&#43;&#43;)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType &#43; &quot; mime type not found in ImageCodecInfo&quot;);
        }

        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            //use the save encoder
            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);
            Image pages = images[0];
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo(&quot;image/tiff&quot;);
            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    //save the first frame
                    pages.Save(outFile, info, ep);
                }

                else
                {
                    //save the intermediate frames
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    pages.SaveAdd(img, ep);
                }
                if (frame == images.Length - 1)
                {
                    //flush and close.
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame&#43;&#43;;
            }
        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;convert_word_to_tiff&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Document&nbsp;document&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Document(@<span class="cs__string">&quot;E:\Program&nbsp;Files\testing.docx&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JoinTiffImages(SaveAsImage(document),<span class="cs__string">&quot;result.tiff&quot;</span>,EncoderValue.CompressionLZW);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(<span class="cs__string">&quot;result.tiff&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Image[]&nbsp;SaveAsImage(Document&nbsp;document)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image[]&nbsp;images&nbsp;=&nbsp;document.SaveToImages(ImageType.Bitmap);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;images;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;ImageCodecInfo&nbsp;GetEncoderInfo(<span class="cs__keyword">string</span>&nbsp;mimeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageCodecInfo[]&nbsp;encoders&nbsp;=&nbsp;ImageCodecInfo.GetImageEncoders();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(<span class="cs__keyword">int</span>&nbsp;j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;encoders.Length;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(encoders[j].MimeType&nbsp;==&nbsp;mimeType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;encoders[j];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">throw</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Exception(mimeType&nbsp;&#43;&nbsp;<span class="cs__string">&quot;&nbsp;mime&nbsp;type&nbsp;not&nbsp;found&nbsp;in&nbsp;ImageCodecInfo&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;JoinTiffImages(Image[]&nbsp;images,&nbsp;<span class="cs__keyword">string</span>&nbsp;outFile,&nbsp;EncoderValue&nbsp;compressEncoder)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//use&nbsp;the&nbsp;save&nbsp;encoder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Drawing.Imaging.Encoder&nbsp;enc&nbsp;=&nbsp;System.Drawing.Imaging.Encoder.SaveFlag;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncoderParameters&nbsp;ep&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameters(<span class="cs__number">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.MultiFrame);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">1</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(System.Drawing.Imaging.Encoder.Compression,&nbsp;(<span class="cs__keyword">long</span>)compressEncoder);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Image&nbsp;pages&nbsp;=&nbsp;images[<span class="cs__number">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;frame&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImageCodecInfo&nbsp;info&nbsp;=&nbsp;GetEncoderInfo(<span class="cs__string">&quot;image/tiff&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(Image&nbsp;img&nbsp;<span class="cs__keyword">in</span>&nbsp;images)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(frame&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages&nbsp;=&nbsp;img;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//save&nbsp;the&nbsp;first&nbsp;frame</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.Save(outFile,&nbsp;info,&nbsp;ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//save&nbsp;the&nbsp;intermediate&nbsp;frames</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.FrameDimensionPage);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.SaveAdd(img,&nbsp;ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(frame&nbsp;==&nbsp;images.Length&nbsp;-&nbsp;<span class="cs__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//flush&nbsp;and&nbsp;close.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ep.Param[<span class="cs__number">0</span>]&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;EncoderParameter(enc,&nbsp;(<span class="cs__keyword">long</span>)EncoderValue.Flush);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pages.SaveAdd(ep);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;frame&#43;&#43;;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<p><strong>Effective Screenshot:</strong></p>
<p><strong><img id="168271" src="168271-%e4%b8%8a%e4%bc%a0.png" alt="" width="431" height="379"><br>
</strong></p>
<h1>More Information</h1>
<p>Definitely, converting Word to Tiff is just a piece of cake by using Free Spire.Doc for .NET. As a free C#/VB.NET component, it also offers a lot of powerful functions as below.</p>
<p><img id="168272" src="168272-%e4%bb%bb%e5%a4%a9%e5%a0%82.png" alt="" width="567" height="314"></p>
<p>Free Spire.Doc for .NET is a totally free Word component for commercial and personal use.
<em>View complete information and start a free trial at:</em><em>&nbsp;</em></p>
<p><strong>Website: </strong><a href="http://www.e-iceblue.com"><strong>www.e-iceblue.com</strong></a><strong>
</strong></p>
<p><strong>Download: </strong><a href="http://www.e-iceblue.com/Introduce/free-doc-component.html#.WBwKk8lv7nG"><strong>Free Spire.Doc for .NET</strong></a><strong>
</strong><strong></strong></p>
<p><strong>Tutorials:</strong> <a href="https://www.e-iceblue.com/Tutorials/Spire.Doc/Spire.Doc-Program-Guide/Spire.Doc-Program-Guide-Content.html">
<strong>Spire.Doc Program Guide</strong></a></p>
