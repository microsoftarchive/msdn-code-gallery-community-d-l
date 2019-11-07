# Extract text and image from PDF file in C#
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- C#
- Silverlight
- ASP.NET
- WPF
- VB.Net
- PDF
## Topics
- Read PDF in C#
- Extract text from PDF
- Extract image from PDF
- PDF API
- .NET PDF
## Updated
- 09/02/2014
## Description

<h1>Introduction</h1>
<p><span style="font-size:small">Sometimes, you may find it a very frustrating task to extract contents from PDF file. This sample shows you how to extract text from PDF file into TXT file and how to save all images embedded in the PFD file to local folder
 using a free .NET PDF component.</span></p>
<p><span style="font-size:small">To extract text and image from a PDF document, your PDF file should meet some basic conditions. First of all, your PDF file is formatted to contain text or images. Next, the PDF file does not contain security restrictions because
 the security restrictions will disable text choosing.</span></p>
<h1><span><span style="font-size:20px; font-weight:bold">Description</span></span></h1>
<p><span style="font-size:small"><strong>Environment requirements</strong></span></p>
<ul>
<li><span style="font-size:small">.NET Framework 2.0, 3.0, 3.5 &amp; 4.0</span> </li><li><span style="font-size:small">Microsoft Visual Studio 2005 and above</span> </li><li><span style="font-size:small">Windows 2000, Windows XP, Windows 7, Windows Server 2003, etc</span>
</li></ul>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong>Method</strong></span></p>
<ol>
<li><span style="font-size:small"><a href="http://www.e-iceblue.com/Download/download-pdf-for-net-now.html">Download free Spire.PDF for .NET</a> and add Spire.PDF.dll as a reference in your .NET application project.</span>
</li><li><span style="font-size:small">Within free Spire.PDF&nbsp; for .NET, you can implement
<strong>PdfDocument.LoadFromFile(string filename)</strong> method to load your PDF file from system.Then, please call the methods
<strong>ExtractText</strong> and <strong>ExtractImages</strong> to extract PDF text and images.&nbsp;Using
<strong>System.IO.File.WriteAllText(string path, string contents)</strong> and <strong>
Image.Save(string filename, ImageFormat format) </strong>, you can save the extracted text and images respectively.</span>
</li></ol>
<p><span style="font-size:small">(Code snippet is available in the package attached.)</span></p>
<p><span style="font-size:small"><strong>&nbsp;</strong><br>
</span></p>
<p><span style="font-size:small"><strong>Screenshots of extract text and image from PDF</strong></span></p>
<p><span style="font-size:small"><strong><img id="120682" src="120682-tni4.png" alt="" width="683" height="431"><br>
</strong></span></p>
<p><span style="font-size:20px; font-weight:bold"><span style="font-size:small">&nbsp;</span><br>
</span></p>
<h1>More Information</h1>
<p><strong>&nbsp;</strong><span style="font-size:small">As a professional PDF component, &nbsp;free Spire.PDF is applied to creating, writing, editing, handling and reading PDF files without any external dependencies within .NET application. Using this .NET
 PDF library, you can implement rich capabilities to create PDF files from scratch or process existing PDF documents entirely through C#/VB.NET without installing Adobe Acrobat.</span></p>
<p><span style="font-size:small"><strong>More sample demo</strong></span></p>
<ol>
<li><span style="font-size:small">Download Spire.PDF for .NET first, and then install it on your computer.
</span></li><li><span style="font-size:small">You will find C# and VB.net demo projects in the folder {install-folder}\sample\.
</span></li><li><span style="font-size:small">You can open these demo projects with VS2005 or above, build and run it.
</span></li></ol>
<p><span style="font-size:small"><strong>Related Links</strong></span></p>
<p><span style="font-size:small">Website:&nbsp;<a href="http://www.e-iceblue.com">http://www.e-iceblue.com</a>&nbsp;</span></p>
<p><span style="font-size:small">Forum: <a href="http://www.e-iceblue.com/forum/spire-pdf-f7.html">
PDF Library Forum</a> (where you can request free customized demo regarding processing PDF with Spire.PDF)</span></p>
