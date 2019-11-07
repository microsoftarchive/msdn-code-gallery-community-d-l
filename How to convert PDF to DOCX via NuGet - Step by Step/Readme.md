# How to convert PDF to DOCX via NuGet - Step by Step
## Requires
- Visual Studio 2017
## License
- MS-LPL
## Technologies
- C#
- ASP.NET
- Office
- .NET
- WPF
- Microsoft Azure
- .NET Framework
- .NET Framework 4.0
- C# Language
- Visual C#
- SharePoint Server 2013
## Topics
- Controls
- C#
- ASP.NET
- How to
- Office 2010 101 code samples
## Updated
- 04/20/2017
## Description

<h1>Introduction</h1>
<p><em>This example shows how to easily and simply convert PDF to DOCX using Nuget. It's enough to have Visual Studio with Nuget support, and also 5-10 minutes of free time.</em></p>
<p><em>PDF Focus .Net totally simplifies the development of .Net applications where it is required to convert PDF documents. Let us say, to provide the function of converting PDF to Word within a WinForms application, you have add only the reference to the
 &quot;SautinSoft.PdfFocus.dll&quot; and write 3-4 C# lines in your application.<br>
</em></p>
<h1><span>Using NuGet</span></h1>
<h3>Adding a Package to your Project</h3>
<p>For adding a package, right click the References node in the Solution Explorer and click on Manage NuGet Packages&hellip; option.&nbsp;</p>
<p><img id="172381" src="172381-nuget1.png" alt="" width="480" height="470"></p>
<p>It will open a dialog box, here type the desired package name in search text box at the top right side.</p>
<p>When you select the package, it shows package information in right side pane like Created By, Id, Version, Downloads, Description, Dependencies, etc.</p>
<p><img id="172382" src="172382-nuget2.png" alt="" width="800" height="597"></p>
<p>Now click the Install button, it will download the package as well as its dependencies if any and install the package in your application.</p>
<p>Once installed, it makes few changes in your project like if you are adding a package for the first time, then it will create a file named&nbsp;<em>packages.config</em>. This file keeps a list of all packages that are installed in your project.</p>
<p><img id="172383" src="172383-nuget3.png" alt="" width="800" height="604"></p>
<p>It also creates a folder named&nbsp;<em>packages</em>&nbsp;in the directory where your solution (<em>.sln</em>) file resides. Packages folder contains a subfolder for each installed package with version number.</p>
<p>NuGet automatically adds the reference of library and makes the necessary changes in&nbsp;<em>config</em>&nbsp;file. &nbsp;So you don&rsquo;t need to do anything and now you are ready to use the package in your application.</p>
<p><img id="172384" src="172384-nuget4.png" alt="" width="312" height="821"></p>
<p>&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">The code sample</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Из&#1084;енение сценария</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF_to_DOCX_via_NuGet
{
    class Program
    {
        static void Main(string[] args)
        {
            string pdfFile = @&quot;d:\Tempos\sample.pdf&quot;;
            string wordFile = @&quot;d:\Tempos\sample.docx&quot;;

            // Convert PDF file to DOCX file
            SautinSoft.PdfFocus f = new SautinSoft.PdfFocus();
           
            f.OpenPdf(pdfFile);

            if (f.PageCount &gt; 0)
            {
                // You may choose output format between Docx and Rtf.
                f.WordOptions.Format = SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;

                int result = f.ToWord(wordFile);

                // Show the resulting Word document.
                if (result == 0)
                {
                    System.Diagnostics.Process.Start(wordFile);
                }
            }

        }
    }
}
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Collections.Generic;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Linq;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Text;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Threading.Tasks;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;PDF_to_DOCX_via_NuGet&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">class</span>&nbsp;Program&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Main(<span class="cs__keyword">string</span>[]&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;pdfFile&nbsp;=&nbsp;@<span class="cs__string">&quot;d:\Tempos\sample.pdf&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;wordFile&nbsp;=&nbsp;@<span class="cs__string">&quot;d:\Tempos\sample.docx&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Convert&nbsp;PDF&nbsp;file&nbsp;to&nbsp;DOCX&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SautinSoft.PdfFocus&nbsp;f&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;SautinSoft.PdfFocus();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.OpenPdf(pdfFile);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(f.PageCount&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;You&nbsp;may&nbsp;choose&nbsp;output&nbsp;format&nbsp;between&nbsp;Docx&nbsp;and&nbsp;Rtf.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;f.WordOptions.Format&nbsp;=&nbsp;SautinSoft.PdfFocus.CWordOptions.eWordDocument.Docx;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;result&nbsp;=&nbsp;f.ToWord(wordFile);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Show&nbsp;the&nbsp;resulting&nbsp;Word&nbsp;document.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;<span class="cs__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Diagnostics.Process.Start(wordFile);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1>The results</h1>
<p><img id="172390" src="172390-nuget5.png" alt="" width="800" height="451"></p>
<h1><span>Source Code Files</span></h1>
<p><em>Related Links:</em></p>
<div><em><br>
Website:&nbsp;<a href="http://www.sautinsoft.com/">www.sautinsoft.com</a><br>
Product Home:&nbsp;<a href="http://sautinsoft.com/products/pdf-focus/index.php">PDF Focus .NET</a><br>
Download:&nbsp;<a href="http://sautinsoft.com/thankyou.php?download=pdf_focus_net.zip">PDF Focus .NET</a>&nbsp;(from website)</em></div>
<div><em><em>Search &amp; Install: sautinsoft.pdffocus (<a href="https://www.nuget.org/packages/sautinsoft.pdffocus/">from NuGet</a>)</em><br>
</em></div>
<h2 class="H2Text">Requrements and Technical Information</h2>
<p class="CommonText"><em>Requires only .Net 4.0 or above. Our product is compatible with all .Net languages and supports all Operating Systems where .Net Framework can be used. Note that PDF Focus .Net is entirely written in managed C#, which makes it absolutely
 standalone and an independent library</em></p>
