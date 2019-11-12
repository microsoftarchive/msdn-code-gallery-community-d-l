# How to Add Digital Signature to PDF in C#
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- C#
- ASP.NET
- Windows Forms
- VB.Net
## Topics
- Digital Signature
- PDF API
## Updated
- 06/08/2018
## Description

<p>This is <a href="http://www.iditect.com/product/pdf-sign/">iDiTect .NET PDF Digital Signer</a> sample code project. Developers are allowed using the full featured trial library to add digital signature to PDF in C#.</p>
<p>As advanced component build by iDiTect, it can digital sign PDF with text or/and image. &quot;SHA1&quot;, &quot;SHA256&quot; and &quot;SHA512&quot; algorithm are embedded in the component, users can customized signature infomation about contact, location, reason, sign field name, and
 inserting rectagle in the PDF page. Besides, if you have a signed PDF document already, this library can also
<a href="http://www.iditect.com/tutorial/check-pdf-signature/">detect the signature information in c#</a>.</p>
<p>The library is thread safe, can be integrate in any Winforms desktop project and ASP.NET web programming. Both 32 and 64 bits support, require .NET framework 4.0&#43;.</p>
<p>This trial package are only allowed to use in evaluation test, any other use need the
<a href="http://www.iditect.com/pricing.html">license</a>.</p>
<p class="text-center">If the trial key in the download package is expired, please go to
<a href="http://www.iditect.com/download/iDiTect.Trial.zip">iditect to download the newest demo zip</a> for the fresh trial key.</p>
<p>&nbsp;</p>
<h1>C# Sample for Signing PDF with Text</h1>
<p><em>Following is a C# sample to creating text signature to PDF.</em><span style="font-size:small"><em>&nbsp;</em></span><em>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Input&nbsp;your&nbsp;certificate&nbsp;and&nbsp;password</span>&nbsp;
PdfCertificate&nbsp;cert&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfCertificate(<span class="cs__string">&quot;test.pfx&quot;</span>,&nbsp;<span class="cs__string">&quot;iditect&quot;</span>);&nbsp;
PdfSigner&nbsp;signer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfSigner(<span class="cs__string">&quot;sample.pdf&quot;</span>,&nbsp;cert);&nbsp;
&nbsp;
<span class="cs__com">//Set&nbsp;signature&nbsp;information</span>&nbsp;
signer.SignatureInfo.Contact&nbsp;=&nbsp;<span class="cs__string">&quot;123456789&quot;</span>;&nbsp;
signer.SignatureInfo.Reason&nbsp;=&nbsp;<span class="cs__string">&quot;Sign&nbsp;by&nbsp;iDiTect&quot;</span>;&nbsp;
signer.SignatureInfo.Location&nbsp;=&nbsp;<span class="cs__string">&quot;World&nbsp;Wide&nbsp;Web&quot;</span>;&nbsp;
<span class="cs__com">//Field&nbsp;name&nbsp;need&nbsp;to&nbsp;be&nbsp;unique&nbsp;in&nbsp;the&nbsp;same&nbsp;pdf&nbsp;document</span>&nbsp;
signer.SignatureInfo.FieldName&nbsp;=&nbsp;<span class="cs__string">&quot;iDiTect&nbsp;Sign&nbsp;Field&quot;</span>;&nbsp;
<span class="cs__com">//Sign&nbsp;in&nbsp;target&nbsp;page</span>&nbsp;
signer.SignatureInfo.PageId&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
<span class="cs__com">//Sign&nbsp;in&nbsp;target&nbsp;area</span>&nbsp;
signer.SignatureInfo.Rect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">50</span>);&nbsp;
signer.SignatureAlgorithm&nbsp;=&nbsp;SignatureAlgorithm.SHA256;&nbsp;
signer.SignatureType&nbsp;=&nbsp;SignatureType.Text;&nbsp;
&nbsp;
signer.Sign(<span class="cs__string">&quot;signed.pdf&quot;</span>);</pre>
</div>
</div>
</div>
<h1>C# Sample for Signing PDF with Image</h1>
<p><em>Following is a C# sample to creating image signature to PDF.</em><span style="font-size:small"><em>
</em></span></p>
<p><span style="font-size:small"><em>&nbsp;</em></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><em><span>C#</span></em></div>
<div class="pluginLinkHolder"><em><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></em></div>
<em><span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//Input&nbsp;your&nbsp;certificate&nbsp;and&nbsp;password</span>&nbsp;
PdfCertificate&nbsp;cert&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfCertificate(<span class="cs__string">&quot;test.pfx&quot;</span>,&nbsp;<span class="cs__string">&quot;iditect&quot;</span>);&nbsp;
PdfSigner&nbsp;signer&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PdfSigner(<span class="cs__string">&quot;sample.pdf&quot;</span>,&nbsp;cert);&nbsp;
&nbsp;
<span class="cs__com">//Support&nbsp;commonly&nbsp;used&nbsp;image&nbsp;format,&nbsp;like&nbsp;jpg,&nbsp;png,&nbsp;gif</span>&nbsp;
signer.SignatureImageFile&nbsp;=&nbsp;<span class="cs__string">&quot;sample.jpg&quot;</span>;&nbsp;
<span class="cs__com">//Field&nbsp;name&nbsp;need&nbsp;to&nbsp;be&nbsp;unique&nbsp;in&nbsp;the&nbsp;same&nbsp;pdf&nbsp;document</span>&nbsp;
signer.SignatureInfo.FieldName&nbsp;=&nbsp;<span class="cs__string">&quot;iDiTect&nbsp;Sign&quot;</span>;&nbsp;
<span class="cs__com">//Sign&nbsp;in&nbsp;target&nbsp;page</span>&nbsp;
signer.SignatureInfo.PageId&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
<span class="cs__com">//Sign&nbsp;in&nbsp;target&nbsp;area</span>&nbsp;
signer.SignatureInfo.Rect&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Rectangle(<span class="cs__number">50</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">100</span>,&nbsp;<span class="cs__number">50</span>);&nbsp;
signer.SignatureAlgorithm&nbsp;=&nbsp;SignatureAlgorithm.SHA256;&nbsp;
signer.SignatureType&nbsp;=&nbsp;SignatureType.Image;&nbsp;
&nbsp;
signer.Sign(<span class="cs__string">&quot;signed.pdf&quot;</span>);</pre>
</div>
</em></div>
</div>
<div class="endscriptcode"><em>&nbsp;For full details about adding text/image signature to pdf in c#, please see
<a href="http://www.iditect.com/tutorial/sign-pdf/">this page</a>.</em></div>
<p><em><br>
</em></p>
