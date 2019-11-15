# How to use Ghostscript.NET library to render PDF's directly to the screen
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- Windows Forms
- .NET Framework
- P/Invoke
- Windows Runtime
- Graphics Functions
## Topics
- C#
- Convert
- PDF file
- Portable Document Format (pdf)
## Updated
- 09/26/2013
## Description

<p><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif">First to say that&nbsp;<a href="http://ghostscriptnet.codeplex.com/"><strong>Ghostscript.NET</strong></a>&nbsp;(written in C#) is the most completed open source managed wrapper library around the Ghostscript
 library (both 32-bit &amp; 64-bit), an interpreter for the PostScript language, PDF, related software and documentation.</span></p>
<p><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif">All other .NET Ghostscript wrappers that you can find on the internet this days does not allow you to render PDF page directly to the screen without exporting the pages to the disk first. This wrapper does
 not require exporting to the disk, it can render PDF pages directly from the Ghostscript interpreter.</span></p>
<p><span style="font-family:Verdana,sans-serif"><br>
</span></p>
<p class="separator"><a href="https://download-codeplex.sec.s-msft.com/Download?ProjectName=ghostscriptnet&DownloadId=721272&Build=20748"><img src="https://download-codeplex.sec.s-msft.com/Download?ProjectName=ghostscriptnet&DownloadId=721272&Build=20748" border="0" alt="" width="320" height="62" style="display:block; margin-left:auto; margin-right:auto"></a></p>
<p><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif">Features of the Ghostscript.NET are:</span></p>
<p>&nbsp;</p>
<ul>
<li><span style="font-family:Verdana,sans-serif">It has&nbsp;<strong>GhostscriptViewer</strong>&nbsp;class which allows you to easily render and navigate through PDF file on the screen via code.</span>
</li><li><span style="font-family:Verdana,sans-serif">GhostscriptViewer contains progressive display update implementation. While Ghostscript is drawing / rasterizing you can see tiles drawing on the screen. Custom update interval can be set.</span>
</li><li><span style="font-family:Verdana,sans-serif">GhostscriptViewer has Zoom-in and Zoom-out functionality.</span>
</li><li><span style="font-family:Verdana,sans-serif">It allows you to run multiple instances of the Ghostscript library (dll)&nbsp;simultaneously&nbsp;within a single process (Ghostscript API does not support this out-of-the-box). This is achieved by using&nbsp;<a href="http://microsoftwinanyhelper.codeplex.com/"><strong>Microsoft.WinAny.Helper</strong></a>&nbsp;library
 and it's DynamicNativeLibrary class which allows you to load a native library from the memory instead from a disk. By doing this (loading from the memory), all Ghostscript instances are running in their own context.</span>
</li><li><span style="font-family:Verdana,sans-serif">It has&nbsp;<strong>GhostscriptProcessor</strong>&nbsp;class which allows you to call Ghostscript library (dll) with a custom specified arguments / switches.</span>
</li><li><span style="font-family:Verdana,sans-serif">All Ghostscript functions which provides ability to rasterize / render postscript or pdf directly to the screen without a need to save it to the disk first are implemented.</span>
</li><li><span style="font-family:Verdana,sans-serif">It's completely compatible and tested with 32-bit and 64-bit Ghostscript library.</span>
</li></ul>
<div>
<p><span style="font-family:Verdana,sans-serif"><br>
</span></p>
</div>
<div>
<p><span style="font-family:Verdana,sans-serif"><br>
</span></p>
</div>
<div>
<p><span style="font-family:Verdana,sans-serif"><strong>Code sample that will show you how to use&nbsp;<span style="color:#073763">GhostscriptViewer</span>&nbsp;class to render&nbsp;</strong></span><strong>PDF directly to the screen:</strong></p>
</div>
<div>
<p><span style="font-family:Verdana,sans-serif"><br>
</span></p>
</div>
<div>
<pre><code><span style="color:#0000ff">using</span> System;
<span style="color:#0000ff">using</span> <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;
<span style="color:#0000ff">using</span> <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Drawing.aspx" target="_blank" title="Auto generated link to System.Drawing">System.Drawing</a>;

<span style="color:#008000">// required Ghostscript.NET namespaces</span>
<span style="color:#0000ff">using</span> Ghostscript.NET;
<span style="color:#0000ff">using</span> Ghostscript.NET.Viewer;

<span style="color:#0000ff">namespace</span> Ghostscript.NET.Samples.Samples
{
    <span style="color:#0000ff">public</span> <span style="color:#0000ff">class</span> DisplayPdfSample : ISample
    {
        <span style="color:#0000ff">private</span> GhostscriptVersionInfo _lastInstalledVersion = <span style="color:#0000ff">null</span>;
        <span style="color:#0000ff">private</span> GhostscriptViewer _viewer = <span style="color:#0000ff">null</span>;
        <span style="color:#0000ff">private</span> Bitmap _pdfPage = <span style="color:#0000ff">null</span>;

        <span style="color:#0000ff">public</span> <span style="color:#0000ff">void</span> Start()
        {
            <span style="color:#008000">// there can be multiple Ghostscript versions installed on the system</span>
            <span style="color:#008000">// and we can choose which one we will use. In this sample we will use</span>
            <span style="color:#008000">// the last installed Ghostscript version. We can choose if we want to </span>
            <span style="color:#008000">// use GPL or AFPL (commercial) version of the Ghostscript. By setting </span>
            <span style="color:#008000">// the parameters below we told that we want to fetch the last version </span>
            <span style="color:#008000">// of the GPL or AFPL Ghostscript and if both are available we prefer </span>
            <span style="color:#008000">// to use GPL version.</span>

            _lastInstalledVersion = 
                GhostscriptVersionInfo.GetLastInstalledVersion(
                        GhostscriptLicense.GPL | GhostscriptLicense.AFPL, 
                        GhostscriptLicense.GPL);

            <span style="color:#008000">// create a new instance of the viewer</span>
            _viewer = <span style="color:#0000ff">new</span> GhostscriptViewer();

            <span style="color:#008000">// set the display update interval to 10 times per second. This value</span>
            <span style="color:#008000">// is milliseconds based and updating display every 100 milliseconds</span>
            <span style="color:#008000">// is optimal value. The smaller value you set the rasterizing will </span>
            <span style="color:#008000">// take longer as DisplayUpdate event will be raised more often.</span>
            _viewer.ProgressiveUpdateInterval = 100;

            <span style="color:#008000">// attach three main viewer events</span>
            _viewer.DisplaySize &#43;= <span style="color:#0000ff">new</span> GhostscriptViewerViewEventHandler(_viewer_DisplaySize);
            _viewer.DisplayUpdate &#43;= <span style="color:#0000ff">new</span> GhostscriptViewerViewEventHandler(_viewer_DisplayUpdate);
            _viewer.DisplayPage &#43;= <span style="color:#0000ff">new</span> GhostscriptViewerViewEventHandler(_viewer_DisplayPage);

            <span style="color:#008000">// open PDF file using the last Ghostscript version. If you want to use</span>
            <span style="color:#008000">// multiple viewers withing a single process then you need to pass 'true' </span>
            <span style="color:#008000">// value as the last parameter of the method below in order to tell the</span>
            <span style="color:#008000">// viewer to load Ghostscript from the memory and not from the disk.</span>
            _viewer.Open(<span style="color:#a31515">&quot;E:\test\test.pdf&quot;</span>,_lastInstalledVersion, <span style="color:#0000ff">false</span>);
        }

        <span style="color:#008000">// this is the first raised event before PDF page starts rasterizing. </span>
        <span style="color:#008000">// this event is raised only once per page showing and it tells us </span>
        <span style="color:#008000">// the dimensions of the PDF page and gives us page image reference.</span>
        <span style="color:#0000ff">void</span> _viewer_DisplaySize(<span style="color:#0000ff">object</span> sender, GhostscriptViewerViewEventArgs e)
        {
            <span style="color:#008000">// store PDF page image reference</span>
            _pdfPage = e.Image;
        }

        <span style="color:#008000">// this event is raised when a tile or the part of the page is rasterized</span>
        <span style="color:#008000">// code in this event must be fast or it will slow down the Ghostscript</span>
        <span style="color:#008000">// rasterizing. </span>
        <span style="color:#0000ff">void</span> _viewer_DisplayUpdate(<span style="color:#0000ff">object</span> sender, GhostscriptViewerViewEventArgs e)
        {
            <span style="color:#008000">// if we are displaying the image in the PictureBox we can update </span>
            <span style="color:#008000">// it by calling PictureBox.Invalidate() and PictureBox.Update()</span>
            <span style="color:#008000">// methods. We dont need to set image reference again because</span>
            <span style="color:#008000">// Ghostscript.NET is changing Image object directly in the</span>
            <span style="color:#008000">// memory and does not create new Bitmap instance.</span>
        }

        <span style="color:#008000">// this is the last raised event after complete page is rasterized</span>
        <span style="color:#0000ff">void</span> _viewer_DisplayPage(<span style="color:#0000ff">object</span> sender, GhostscriptViewerViewEventArgs e)
        {
            <span style="color:#008000">// complete PDF page is rasterized and we can update our PictureBox</span>
            <span style="color:#008000">// once again by calling PictureBox.Invalidate() and PictureBox.Update()</span>
        }

        <span style="color:#008000">// dummy method just to list other viewer properties and methods</span>
        <span style="color:#0000ff">private</span> <span style="color:#0000ff">void</span> Other_Viewer_Methods()
        {
            <span style="color:#008000">// show first pdf page</span>
            _viewer.ShowFirstPage();
            <span style="color:#008000">// show previous pdf page</span>
            _viewer.ShowPreviousPage();
            <span style="color:#008000">// show next pdf page</span>
            _viewer.ShowNextPage();
            <span style="color:#008000">// show last pdf page</span>
            _viewer.ShowLastPage();
            <span style="color:#008000">// show page based on page number</span>
            _viewer.ShowPage(6);
            <span style="color:#008000">// refresh current page / rasterize it again</span>
            _viewer.RefreshPage();
            <span style="color:#008000">// zoom in</span>
            _viewer.ZoomIn();
            <span style="color:#008000">// zoom out</span>
            _viewer.ZoomOut();
            <span style="color:#008000">// get first page number</span>
            <span style="color:#0000ff">int</span> fpn = _viewer.FirstPageNumber;
            <span style="color:#008000">// get last page number</span>
            <span style="color:#0000ff">int</span> lpn = _viewer.LastPageNumber;
            <span style="color:#008000">// get current page number</span>
            <span style="color:#0000ff">int</span> cpn = _viewer.CurrentPageNumber;
        }

    }
}
</code></pre>
<p>&nbsp;</p>
<p><span style="font-family:Verdana,sans-serif">You can download last version of the Ghostscript.NET library from CodePlex:</span></p>
<p><span style="font-family:Verdana,sans-serif"><strong><a href="http://ghostscriptnet.codeplex.com/">http://ghostscriptnet.codeplex.com</a></strong></span></p>
<p><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif">Ghostscript interpreter can be downloaded from here:&nbsp;</span></p>
<p><span style="font-family:Verdana,sans-serif"><strong><a href="http://www.ghostscript.com/download/gsdnld.html">http://www.ghostscript.com/download/gsdnld.html</a></strong></span></p>
<p><span style="font-family:Verdana,sans-serif"><br>
</span><span style="font-family:Verdana,sans-serif"><br>
</span></p>
</div>
<p><img src="http://www.watchmytraffic.com/6956167-9C1CF2E9CCDD12363151B85F6CEB3988/counter.img?theme=5&digits=7&siteId=6" border="0" alt="Website counter" hspace="0" vspace="0"></p>
