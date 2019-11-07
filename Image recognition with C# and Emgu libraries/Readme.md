# Image recognition with C# and Emgu libraries
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- .NET Framework
- OpenCV
- EmGU CV
## Topics
- Image Recognition
## Updated
- 05/02/2017
## Description

<h1>Abstract</h1>
<p><span>In the following we'll see how to realize an image recognition program, using&nbsp;</span><strong>C#</strong><span>&nbsp;and&nbsp;</span><strong>EmGu</strong><span>, a .NET wrapper for the Intel OpenCV image-processing library.</span><br>
<span>At the end of the article, the reader will be able to develop a simple application which will search into a list of images for the one containing a smaller portion of the original one, graphically showing the points of intersection between the two.</span><br>
<br>
</p>
<h1><a name="Download_and_install_EmGu"></a>Download and install EmGu</h1>
<p><span>EmGu libraries can be downloaded at&nbsp;</span><a href="https://sourceforge.net/projects/emgucv/files/" target="_blank">https://sourceforge.net/projects/emgucv/files/&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>.
 The latest version of the package is located at&nbsp;</span><a href="https://sourceforge.net/projects/emgucv/files/latest/download?source=files" target="_blank">https://sourceforge.net/projects/emgucv/files/latest/download?source=files&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>,
 and comes in the form of an exe installer. For a pretty complete reference of the library, the reader is invited to visit</span><a href="http://www.emgu.com/wiki/index.php/Main_Page" target="_blank">http://www.emgu.com/wiki/index.php/Main_Page&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>,
 which is the official Wiki of EmGu. Here will be considered only the indispensable aspects and functions to reach the declared goal of matching two images to find the smaller one in a list of possible candidates.</span></p>
<p>&nbsp;</p>
<p><span><img src=":-1881.08.png" alt=" "></span></p>
<p>&nbsp;</p>
<h1>SURF detection</h1>
<p><span>As said in the Wikipedia page for&nbsp;</span><strong>Speeded up robust features</strong><span>&nbsp;(</span><a href="https://en.wikipedia.org/wiki/Speeded_up_robust_features" target="_blank">https://en.wikipedia.org/wiki/Speeded_up_robust_features&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>),
 &laquo;[...] is a patented local feature detector and descriptor. It can be used for tasks such as object recognition, image registration, classification or 3D reconstruction. It is partly inspired by the scale-invariant feature transform (SIFT) descriptor.
 The standard version of SURF is several times faster than SIFT and claimed by its authors to be more robust against different image transformations than SIFT. To detect interest points, SURF uses an integer approximation of the&nbsp;</span><a href="https://en.wikipedia.org/wiki/Blob_detection#The_determinant_of_the_Hessian" target="_blank">determinant
 of Hessian&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><a href="https://en.wikipedia.org/wiki/Blob_detection" target="_blank">&nbsp;blob
 detector&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>,
 which can be computed with 3 integer operations using a precomputed integral image. Its feature descriptor is based on the sum of the&nbsp;</span><a href="https://en.wikipedia.org/wiki/Haar-like_features" target="_blank">Haar wavelet&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>&nbsp;response
 around the point of interest. These can also be computed with the aid of the integral image. SURF descriptors have been used to locate and recognize objects, people or faces, to reconstruct 3D scenes, to track objects and to extract points of interest.&raquo;</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public static void FindMatch(Mat modelImage, Mat observedImage, out long matchTime, out VectorOfKeyPoint modelKeyPoints, out VectorOfKeyPoint observedKeyPoints, VectorOfVectorOfDMatch matches, out Mat mask, out Mat homography, out long score)
{
    int k = 2;
    double uniquenessThreshold = 0.80;
 
    Stopwatch watch;
    homography = null;
 
    modelKeyPoints = new VectorOfKeyPoint();
    observedKeyPoints = new VectorOfKeyPoint();
 
    using (UMat uModelImage = modelImage.GetUMat(AccessType.Read))
    using (UMat uObservedImage = observedImage.GetUMat(AccessType.Read))
    {
        KAZE featureDetector = new KAZE();
 
        Mat modelDescriptors = new Mat();
        featureDetector.DetectAndCompute(uModelImage, null, modelKeyPoints, modelDescriptors, false);
 
        watch = Stopwatch.StartNew();
 
        Mat observedDescriptors = new Mat();
        featureDetector.DetectAndCompute(uObservedImage, null, observedKeyPoints, observedDescriptors, false);
 
        // KdTree for faster results / less accuracy
        using (var ip = new Emgu.CV.Flann.KdTreeIndexParams())  
        using (var sp = new SearchParams())
        using (DescriptorMatcher matcher = new FlannBasedMatcher(ip, sp))
        {
            matcher.Add(modelDescriptors);
 
            matcher.KnnMatch(observedDescriptors, matches, k, null);
            mask = new Mat(matches.Size, 1, DepthType.Cv8U, 1);
            mask.SetTo(new MCvScalar(255));
            Features2DToolbox.VoteForUniqueness(matches, uniquenessThreshold, mask);
 
            // Calculate score based on matches size
            // ----------------------------------------------&gt;
            score = 0;
            for (int i = 0; i &lt; matches.Size; i&#43;&#43;)
            {
                if (mask.GetData(i)[0] == 0) continue;
                foreach (var e in matches[i].ToArray())
                    &#43;&#43;score;
            }
            // &lt;----------------------------------------------
 
            int nonZeroCount = CvInvoke.CountNonZero(mask);
            if (nonZeroCount &gt;= 4)
            {
                nonZeroCount = Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints, observedKeyPoints, matches, mask, 1.5, 20);
                if (nonZeroCount &gt;= 4)
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints, observedKeyPoints, matches, mask, 2);
            }
        }
        watch.Stop();
 
    }
    matchTime = watch.ElapsedMilliseconds;
}</pre>
<div class="preview">
<pre class="js">public&nbsp;static&nbsp;<span class="js__operator">void</span>&nbsp;FindMatch(Mat&nbsp;modelImage,&nbsp;Mat&nbsp;observedImage,&nbsp;out&nbsp;long&nbsp;matchTime,&nbsp;out&nbsp;VectorOfKeyPoint&nbsp;modelKeyPoints,&nbsp;out&nbsp;VectorOfKeyPoint&nbsp;observedKeyPoints,&nbsp;VectorOfVectorOfDMatch&nbsp;matches,&nbsp;out&nbsp;Mat&nbsp;mask,&nbsp;out&nbsp;Mat&nbsp;homography,&nbsp;out&nbsp;long&nbsp;score)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;k&nbsp;=&nbsp;<span class="js__num">2</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;double&nbsp;uniquenessThreshold&nbsp;=&nbsp;<span class="js__num">0.80</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Stopwatch&nbsp;watch;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;homography&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;modelKeyPoints&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;VectorOfKeyPoint();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;observedKeyPoints&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;VectorOfKeyPoint();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(UMat&nbsp;uModelImage&nbsp;=&nbsp;modelImage.GetUMat(AccessType.Read))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(UMat&nbsp;uObservedImage&nbsp;=&nbsp;observedImage.GetUMat(AccessType.Read))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;KAZE&nbsp;featureDetector&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;KAZE();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mat&nbsp;modelDescriptors&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Mat();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;featureDetector.DetectAndCompute(uModelImage,&nbsp;null,&nbsp;modelKeyPoints,&nbsp;modelDescriptors,&nbsp;false);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;watch&nbsp;=&nbsp;Stopwatch.StartNew();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mat&nbsp;observedDescriptors&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Mat();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;featureDetector.DetectAndCompute(uObservedImage,&nbsp;null,&nbsp;observedKeyPoints,&nbsp;observedDescriptors,&nbsp;false);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;KdTree&nbsp;for&nbsp;faster&nbsp;results&nbsp;/&nbsp;less&nbsp;accuracy</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;ip&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Emgu.CV.Flann.KdTreeIndexParams())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;sp&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SearchParams())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(DescriptorMatcher&nbsp;matcher&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FlannBasedMatcher(ip,&nbsp;sp))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;matcher.Add(modelDescriptors);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;matcher.KnnMatch(observedDescriptors,&nbsp;matches,&nbsp;k,&nbsp;null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mask&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Mat(matches.Size,&nbsp;<span class="js__num">1</span>,&nbsp;DepthType.Cv8U,&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mask.SetTo(<span class="js__operator">new</span>&nbsp;MCvScalar(<span class="js__num">255</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Features2DToolbox.VoteForUniqueness(matches,&nbsp;uniquenessThreshold,&nbsp;mask);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Calculate&nbsp;score&nbsp;based&nbsp;on&nbsp;matches&nbsp;size</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;----------------------------------------------&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;score&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;matches.Size;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(mask.GetData(i)[<span class="js__num">0</span>]&nbsp;==&nbsp;<span class="js__num">0</span>)&nbsp;<span class="js__statement">continue</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;e&nbsp;<span class="js__operator">in</span>&nbsp;matches[i].ToArray())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&#43;&#43;score;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;&lt;----------------------------------------------</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;nonZeroCount&nbsp;=&nbsp;CvInvoke.CountNonZero(mask);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nonZeroCount&nbsp;&gt;=&nbsp;<span class="js__num">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;nonZeroCount&nbsp;=&nbsp;Features2DToolbox.VoteForSizeAndOrientation(modelKeyPoints,&nbsp;observedKeyPoints,&nbsp;matches,&nbsp;mask,&nbsp;<span class="js__num">1.5</span>,&nbsp;<span class="js__num">20</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(nonZeroCount&nbsp;&gt;=&nbsp;<span class="js__num">4</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;homography&nbsp;=&nbsp;Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(modelKeyPoints,&nbsp;observedKeyPoints,&nbsp;matches,&nbsp;mask,&nbsp;<span class="js__num">2</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;watch.Stop();&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;matchTime&nbsp;=&nbsp;watch.ElapsedMilliseconds;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<span style="background-color:#ffff00; font-size:small">Continue reading here:&nbsp;<a href="https://social.technet.microsoft.com/wiki/contents/articles/37863.image-recognition-with-c-and-emgu-libraries.aspx" target="_blank">https://social.technet.microsoft.com/wiki/contents/articles/37863.image-recognition-with-c-and-emgu-libraries.aspx</a></span>
<p></p>
