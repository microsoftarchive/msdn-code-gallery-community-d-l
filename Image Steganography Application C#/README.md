# Image Steganography Application C#
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- Image Processing
## Topics
- Image Steganography
## Updated
- 03/30/2014
## Description

<h1>Introduction</h1>
<p><em>Image Steganography application by Ninja Coders</em></p>
<h1><span>Building the Sample</span></h1>
<p><span>Screen shot of application.</span></p>
<p>last image has the 2nd image hiddent in it</p>
<p><img id="111413" src="111413-image%20steganography.png" alt=""></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>From this application you can hide your picture behind another picture and send it to some one... even you can upload it on facebook. and the reciever will save that image and decode the hidden image from the given image and get the original one using
 the same application.</em></p>
<p><em>download it and give your response.</em></p>
<p><em>thank you</em></p>
<p><em>Application by #Ninjas Coding Club</em></p>
<p>&nbsp;</p>
<p><em>Image Steganography introduction</em></p>
<p><strong>Steganography</strong>&nbsp;is the art or practice of concealing a message, image, or file within another message, image, or file. The word&nbsp;<em>steganography</em>&nbsp;is of&nbsp;<a title="Ancient Greek" href="http://en.wikipedia.org/wiki/Ancient_Greek">Greek</a>&nbsp;origin
 and means &quot;covered writing&quot; or &quot;concealed writing&quot;. Some implementations of steganography which lack a&nbsp;<a title="Shared secret" href="http://en.wikipedia.org/wiki/Shared_secret">shared secret</a>&nbsp;are forms of&nbsp;<a title="Security through obscurity" href="http://en.wikipedia.org/wiki/Security_through_obscurity">security
 through obscurity</a>, whereas key-dependent steganographic schemes adhere to<a title="Kerckhoffs's principle" href="http://en.wikipedia.org/wiki/Kerckhoffs%27s_principle">Kerckhoffs's principle</a>.It combines the Greek words&nbsp;<em>steganos</em>&nbsp;(&sigma;&tau;&epsilon;&gamma;&alpha;&nu;ό&sigmaf;),
 meaning &quot;covered or protected&quot;, and&nbsp;<em>graphei</em>&nbsp;meaning &quot;writing&quot;. The first recorded use of the term was in 1499 by&nbsp;<a title="Johannes Trithemius" href="http://en.wikipedia.org/wiki/Johannes_Trithemius">Johannes Trithemius</a>&nbsp;in
 his&nbsp;<em><a title="Johannes Trithemius" href="http://en.wikipedia.org/wiki/Johannes_Trithemius#Steganographia">Steganographia</a></em>, a treatise on cryptography and steganography, disguised as a book on magic. Generally, the hidden messages will appear
 to be (or be part of) something else: images, articles, shopping lists, or some other&nbsp;<em>cover text</em>. For example, the hidden message may be in&nbsp;<a title="Invisible ink" href="http://en.wikipedia.org/wiki/Invisible_ink">invisible ink</a>&nbsp;between
 the visible lines of a private letter.</p>
<p>The advantage of steganography over&nbsp;<a title="Cryptography" href="http://en.wikipedia.org/wiki/Cryptography">cryptography</a>&nbsp;alone is that the intended secret message does not attract attention to itself as an object of scrutiny. Plainly visible
 encrypted messages&mdash;no matter how unbreakable&mdash;will arouse interest, and may in themselves be incriminating in countries where&nbsp;<a title="Encryption" href="http://en.wikipedia.org/wiki/Encryption">encryption</a>&nbsp;is illegal.&nbsp;Thus, whereas
 cryptography is the practice of protecting the contents of a message alone, steganography is concerned with concealing the fact that a secret message is being sent, as well as concealing the contents of the message.</p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;Bitmap&nbsp;ToGreyScale(Bitmap&nbsp;bitmap)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;grey,&nbsp;i,&nbsp;j;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Color&nbsp;color;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(i&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;i&nbsp;&lt;&nbsp;bitmap.Width;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">for</span>&nbsp;(j&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;j&nbsp;&lt;&nbsp;bitmap.Height;&nbsp;j&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;color&nbsp;=&nbsp;bitmap.GetPixel(i,&nbsp;j);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grey&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)((color.R&nbsp;&#43;&nbsp;color.G&nbsp;&#43;&nbsp;color.B)&nbsp;/&nbsp;<span class="cs__number">3</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;grey&nbsp;=&nbsp;(int)((color.R&nbsp;*&nbsp;.3)&nbsp;&#43;&nbsp;(color.G&nbsp;*&nbsp;.59)&nbsp;&#43;&nbsp;(color.B&nbsp;*&nbsp;.11));</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bitmap.SetPixel(i,&nbsp;j,&nbsp;Color.FromArgb(grey,&nbsp;grey,&nbsp;grey));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;bitmap;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
