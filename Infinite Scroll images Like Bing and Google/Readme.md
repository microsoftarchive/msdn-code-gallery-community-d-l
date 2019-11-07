# Infinite Scroll images Like Bing and Google
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- ASP.NET
- jQuery
- Web Services
- Javascript
- ASP.NET Web Forms
## Topics
- Images
- Image Gallery
- Infinite scroll
## Updated
- 03/16/2012
## Description

<h1>Introduction</h1>
<p>One of the must annoying thing when working with large data is how to loading this data to your page?</p>
<p>The common solution is paging but paging itself will not help too much you can end with hundred or thousands of page numbers.So new solution now is on the surface and it's called &quot;Infinite Scroll&quot;.Infinite Scroll allow you to load chunk of data when you
 scroll down of the page and inject it inside the page, it will load data each time you scrolling down on the page.</p>
<h1>Demo</h1>
<p><img src="50738-iscroll.gif" alt="" width="535" height="334"></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>As I told you in the int<em>roduction Infinite Scroll is becoming more and more populer it's in evreywhere starting with Bing,Google,Facebook,Twitter,Linkedin.etc.</em></p>
<p><em>The idea of infinite scrolling is so simple and it can be </em>summarized <em>
in the following </em>diagram <em>which is part of Scott Hanselmen Article</em></p>
<p><a class="TitleLinkStyle" rel="bookmark" href="http://www.hanselman.com/blog/InfiniteScrollWebSitesViaAutoPagerizeHackyButTheBeginningOfSomethingCool.aspx">Infinite Scroll WebSites via AutoPagerize - Hacky, but the beginning of something cool</a></p>
<p><em><img src="50567-image_2%5b1%5d.png" alt="" width="293" height="288"><br>
</em></p>
<p>My Sample will show you how to Display a list of images like Bing and Google but this is not the only thing,you can take the advantage of idea behind infinite scrolling and implement the same concept everywhere.</p>
<p>The following code snippet will be called when you scroll to the last of the page</p>
<p>C# Part</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>JavaScript</span><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">js</span><span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">        $(document).ready(function () {
            var Skip = 49; //Number of skipped row
            var Take = 14; //
            function Load(Skip, Take) {
                $('#divPostsLoader').html('&lt;img src=&quot;ProgressBar/ajax-loader.gif&quot;&gt;');

                //send a query to server side to present new content
                $.ajax({
                    type: &quot;POST&quot;,
                    url: &quot;Grid.aspx/LoadImages&quot;,
                    data: &quot;{ Skip:&quot; &#43; Skip &#43; &quot;, Take:&quot; &#43; Take &#43; &quot; }&quot;,
                    contentType: &quot;application/json; charset=utf-8&quot;,
                    dataType: &quot;json&quot;,
                    success: function (data) {

                        if (data != &quot;&quot;) {
                            $('.thumb').append(data.d);
                        }
                        $('#divPostsLoader').empty();
                    }

                })
            };
            //Larger thumbnail preview 

            //When scroll down, the scroller is at the bottom and fire the Load ()function
            $(window).scroll(function () {

                if ($(window).scrollTop() == $(document).height() - $(window).height()) {
                    Load(Skip, Take);

                   //Any number you want
                    Skip = Skip &#43; 14;
                }
            });
        });</pre>
<pre class="hidden"> &lt;WebMethod()&gt; _
    Public Shared Function LoadImages(Skip As Integer, Take As Integer) As String
        System.Threading.Thread.Sleep(2000)
        Dim GetImages As New StringBuilder()
        Dim Imagespath As String = HttpContext.Current.Server.MapPath(&quot;~/Images/&quot;)
        Dim SitePath As String = HttpContext.Current.Server.MapPath(&quot;~&quot;)
        Dim Files = (From file In Directory.GetFiles(Imagespath) Select New With { _
  Key .image = file.Replace(SitePath, &quot;&quot;) _
 }).Skip(Skip).Take(Take)
        For Each file As Object In Files

            Dim imageSrc = file.image.Replace(&quot;\&quot;, &quot;/&quot;).Substring(1) 'Remove First '/' from image path
            GetImages.AppendFormat(&quot;&lt;a&gt;&quot;)
            GetImages.AppendFormat(&quot;&lt;li&gt;&quot;)
            GetImages.AppendFormat(String.Format(&quot;&lt;img src='{0}'/&gt;&quot;, imageSrc))
            GetImages.AppendFormat(&quot;&lt;/li&gt;&quot;)
            GetImages.AppendFormat(&quot;&lt;/a&gt;&quot;)
        Next
        Return GetImages.ToString()
    End Function</pre>
<pre class="hidden">[WebMethod]
    public static string LoadImages(int Skip, int Take)
    {
        System.Threading.Thread.Sleep(2000);
        StringBuilder GetImages = new StringBuilder();
        string Imagespath = HttpContext.Current.Server.MapPath(&quot;~/Images/&quot;);
        string SitePath = HttpContext.Current.Server.MapPath(&quot;~&quot;);
        var Files = (from file in Directory.GetFiles(Imagespath) select new { image = file.Replace(SitePath, &quot;&quot;) }).Skip(Skip).Take(Take);
        foreach (var file in Files)
        {
            var imageSrc = file.image.Replace(&quot;\\&quot;,&quot;/&quot;).Substring(1); //Remove First '/' from image path
            GetImages.AppendFormat(&quot;&lt;a&gt;&quot;);
            GetImages.AppendFormat(&quot;&lt;li&gt;&quot;);
            GetImages.AppendFormat(string.Format(&quot;&lt;img src='{0}'/&gt;&quot;, imageSrc));
            GetImages.AppendFormat(&quot;&lt;/li&gt;&quot;);
            GetImages.AppendFormat(&quot;&lt;/a&gt;&quot;);


        }
        return GetImages.ToString();
    }</pre>
<div class="preview">
<pre class="js">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(document).ready(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Skip&nbsp;=&nbsp;<span class="js__num">49</span>;&nbsp;<span class="js__sl_comment">//Number&nbsp;of&nbsp;skipped&nbsp;row</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;Take&nbsp;=&nbsp;<span class="js__num">14</span>;&nbsp;<span class="js__sl_comment">//</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;Load(Skip,&nbsp;Take)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#divPostsLoader'</span>).html(<span class="js__string">'&lt;img&nbsp;src=&quot;ProgressBar/ajax-loader.gif&quot;&gt;'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//send&nbsp;a&nbsp;query&nbsp;to&nbsp;server&nbsp;side&nbsp;to&nbsp;present&nbsp;new&nbsp;content</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$.ajax(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;type:&nbsp;<span class="js__string">&quot;POST&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;<span class="js__string">&quot;Grid.aspx/LoadImages&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;<span class="js__string">&quot;{&nbsp;Skip:&quot;</span>&nbsp;&#43;&nbsp;Skip&nbsp;&#43;&nbsp;<span class="js__string">&quot;,&nbsp;Take:&quot;</span>&nbsp;&#43;&nbsp;Take&nbsp;&#43;&nbsp;<span class="js__string">&quot;&nbsp;}&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;contentType:&nbsp;<span class="js__string">&quot;application/json;&nbsp;charset=utf-8&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;dataType:&nbsp;<span class="js__string">&quot;json&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;success:&nbsp;<span class="js__operator">function</span>&nbsp;(data)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(data&nbsp;!=&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.thumb'</span>).append(data.d);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#divPostsLoader'</span>).empty();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Larger&nbsp;thumbnail&nbsp;preview&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//When&nbsp;scroll&nbsp;down,&nbsp;the&nbsp;scroller&nbsp;is&nbsp;at&nbsp;the&nbsp;bottom&nbsp;and&nbsp;fire&nbsp;the&nbsp;Load&nbsp;()function</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(window).scroll(<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;($(window).scrollTop()&nbsp;==&nbsp;$(document).height()&nbsp;-&nbsp;$(window).height())&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Load(Skip,&nbsp;Take);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Any&nbsp;number&nbsp;you&nbsp;want</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Skip&nbsp;=&nbsp;Skip&nbsp;&#43;&nbsp;<span class="js__num">14</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>Images : Folder contain images to displaying </span>purpose. </li><li>Prgressbar : Foder contain progress image ,it will be displayed when loading data.
</li><li>scripts : Folder contain Jquery.js and to other scripts for loading data (one for C# and other for VB.NET)
</li><li>Grid.aspx : ASPX page with C# Code -behind </li><li>GridVB.aspx:ASPX page with VB.NET Code-behind </li><li>web.config </li></ul>
<ul>
</ul>
<h1>More Information</h1>
<p><em>you can ask me here In Q &amp; A section<br>
</em></p>
