# Face Detection and Recognition with Azure Face API and C#
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Azure
- Cognitive Services
- Face API
## Topics
- Face detection
- Facial recognition
## Updated
- 05/08/2017
## Description

<p><span>As stated by&nbsp;</span><a href="https://docs.microsoft.com/en-us/azure/cognitive-services/Welcome" target="_blank">Azure Cognitive Services Welcome Page&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="https://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-components-sitefiles/10_5F00_external.png" border="0" alt="Jump">&nbsp;</a><span>,
 &quot;Microsoft Cognitive Services (formerly Project Oxford) are a set of APIs, SDKs and services available to developers to make their applications more intelligent, engaging and discoverable. Microsoft Cognitive Services expands on Microsoft&rsquo;s evolving
 portfolio of machine learning APIs and enables developers to easily add intelligent features &ndash; such as emotion and video detection; facial, speech and vision recognition; and speech and language understanding &ndash; into their applications. Our vision
 is for more personal computing experiences and enhanced productivity aided by systems that increasingly can see, hear, speak, understand and even begin to reason&quot;</span><br>
<br>
<span>Amongst those services, we will see here Microsoft Face API, &quot;a cloud-based service that provides the most advanced face algorithms. Face API has two main functions: face detection with attributes and face recognition&quot; (</span><a href="https://docs.microsoft.com/en-us/azure/cognitive-services/face/overview" target="_blank">Cognitive
 Services Face API Overview&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src="https://social.technet.microsoft.com/wiki/cfs-file.ashx/__key/communityserver-components-sitefiles/10_5F00_external.png" border="0" alt="Jump">&nbsp;</a><span>).
 We'll treat each of those function later in the article, while looking closer at them as we develop our sample solution.</span></p>
<h2>Connect and query webservice</h2>
<p><br>
<span>The most important part of a Face API webserver based program, is the declaration of a variable of type IFaceServiceClient: this allows the connection and the authentication at the remote endpoint. It is easily declared with the following code:</span><br>
<br>
</p>
<div class="reCodeBlock"><code>private</code>&nbsp;<code>readonly</code>&nbsp;<code>IFaceServiceClient faceServiceClient =&nbsp;</code><code>new</code>&nbsp;<code>FaceServiceClient(</code><code>&quot;&lt;PLACE_YOUR_SERVICE_KEY_HERE&gt;&quot;</code><code>);</code></div>
<p><br>
<span>The key you will use can be, indifferently, one of the two seen above and created on Azure portal.</span><br>
<br>
<span>Supposing we have an image we wish to analyze, we first will read it as a stream, passing it in that form to a method of our IFaceServiceClient,&nbsp;</span><strong>DetectAsync</strong><span>.</span><br>
<span>DetectAsync call is customizable, based on our needs and what informations we wish to acquire. In the following snippet, we'll see how to open an image as a stream, calling then the method.</span><br>
<br>
<span>The first parameter is the image stream. The second one is to ask to return the face Id, while the third queries for the face landmarks. The last one is an array of FaceAttributeType, to retrieve those attributes we desire to check. In the snippet, we
 ask Id, landmarks, and analysis on the gender, age, and emotion of every face in an image.</span><br>
<br>
<span>What we will return is an array of those informations.</span><br>
<br>
</p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;Task&lt;Face[]&gt;&nbsp;UploadAndDetectFaces(string&nbsp;imageFilePath)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(Stream&nbsp;imageFileStream&nbsp;=&nbsp;File.OpenRead(imageFilePath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;faces&nbsp;=&nbsp;await&nbsp;faceServiceClient.DetectAsync(imageFileStream,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">new</span>&nbsp;FaceAttributeType[]&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceAttributeType.Gender,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceAttributeType.Age,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceAttributeType.Emotion&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;faces.ToArray();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(ex.Message);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;Face[<span class="js__num">0</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
</div>
</div>
<p><span>Once retrieved, how those informations are used is a matter of need / preference. In the attached example, we parse the returning array to graphically showing each read property. Lets see the following snippet, related to the click of the button which
 uploads the image:</span><br>
<br>
</p>
<div class="reCodeBlock">
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">private&nbsp;async&nbsp;<span class="js__operator">void</span>&nbsp;btnProcess_Click(object&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Face[]&nbsp;faces&nbsp;=&nbsp;await&nbsp;UploadAndDetectFaces(_imagePath);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(faces.Length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;faceBitmap&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Bitmap(imgBox.Image);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;g&nbsp;=&nbsp;Graphics.FromImage(faceBitmap))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Alpha-black&nbsp;rectangle&nbsp;on&nbsp;entire&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(<span class="js__num">200</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>,&nbsp;<span class="js__num">0</span>)),&nbsp;g.ClipBounds);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;br&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;SolidBrush(Color.FromArgb(<span class="js__num">200</span>,&nbsp;Color.LightGreen));&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Loop&nbsp;each&nbsp;face&nbsp;recognized</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;face&nbsp;<span class="js__operator">in</span>&nbsp;faces)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fr&nbsp;=&nbsp;face.FaceRectangle;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fa&nbsp;=&nbsp;face.FaceAttributes;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Get&nbsp;original&nbsp;face&nbsp;image&nbsp;(color)&nbsp;to&nbsp;overlap&nbsp;the&nbsp;grayed&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;faceRect&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Rectangle(fr.Left,&nbsp;fr.Top,&nbsp;fr.Width,&nbsp;fr.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(imgBox.Image,&nbsp;faceRect,&nbsp;faceRect,&nbsp;GraphicsUnit.Pixel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawRectangle(Pens.LightGreen,&nbsp;faceRect);&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Loop&nbsp;face.FaceLandmarks&nbsp;properties&nbsp;for&nbsp;drawing&nbsp;landmark&nbsp;spots</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;pts&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;List&lt;Point&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Type&nbsp;type&nbsp;=&nbsp;face.FaceLandmarks.GetType();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(PropertyInfo&nbsp;property&nbsp;<span class="js__operator">in</span>&nbsp;type.GetProperties())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawRectangle(Pens.LightGreen,&nbsp;GetRectangle((FeatureCoordinate)property.GetValue(face.FaceLandmarks,&nbsp;null)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Calculate&nbsp;where&nbsp;to&nbsp;position&nbsp;the&nbsp;detail&nbsp;rectangle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;rectTop&nbsp;=&nbsp;fr.Top&nbsp;&#43;&nbsp;fr.Height&nbsp;&#43;&nbsp;<span class="js__num">10</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(rectTop&nbsp;&#43;&nbsp;<span class="js__num">45</span>&nbsp;&gt;&nbsp;faceBitmap.Height)&nbsp;rectTop&nbsp;=&nbsp;fr.Top&nbsp;-&nbsp;<span class="js__num">30</span>;&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Draw&nbsp;detail&nbsp;rectangle&nbsp;and&nbsp;write&nbsp;face&nbsp;informations&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.FillRectangle(br,&nbsp;fr.Left&nbsp;-&nbsp;<span class="js__num">10</span>,&nbsp;rectTop,&nbsp;fr.Width&nbsp;&lt;&nbsp;<span class="js__num">120</span>&nbsp;?&nbsp;<span class="js__num">120</span>&nbsp;:&nbsp;fr.Width&nbsp;&#43;&nbsp;<span class="js__num">20</span>,&nbsp;<span class="js__num">25</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawString(string.Format(<span class="js__string">&quot;{0:0.0}&nbsp;/&nbsp;{1}&nbsp;/&nbsp;{2}&quot;</span>,&nbsp;fa.Age,&nbsp;fa.Gender,&nbsp;fa.Emotion.ToRankedList().OrderByDescending(x&nbsp;=&gt;&nbsp;x.Value).First().Key),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Font,&nbsp;Brushes.Black,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fr.Left&nbsp;-&nbsp;<span class="js__num">8</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rectTop&nbsp;&#43;&nbsp;<span class="js__num">4</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgBox.Image&nbsp;=&nbsp;faceBitmap;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">As it can be seen, there are no particular difficulties in that code, which can be reduced to a simple graphical rendering of each element of interest. After calling UploadAndDetectFaces method, the obtained array is cycled through.
 The original image gets blacked, to better highlight the spotted face, inscribed into a rectangle, which will be draw separately in green. Each landmark (i.e. each point used by the webservice to determine what can be defined as a face) is drawn in the same
 way, with green 2x2 rectangles. Lastly, we draw a rectangle which will contain th read attributes: gender, age and emotion.</div>
</div>
</div>
<p><br>
<span>The&nbsp;</span><strong>Emotion API beta</strong><span>&nbsp;will assign a value between 0 and 1 to a predetermined set of emotions, like &quot;</span><em>Happiness</em><span>&quot;, &quot;</span><em>Sadness</em><span>&quot;, &quot;</span><em>Neutral</em><span>&quot;, etc.</span><br>
<span>In our example, through the LINQ function&nbsp;</span></p>
<p></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">fa.Emotion.ToRankedList().OrderByDescending(x&nbsp;=&gt;&nbsp;x.Value).First().Key</pre>
</div>
</div>
</div>
<p></p>
<p><span>we will read the preponderant emotion, i.e. the one which has received the highest value. That method lack precision, and it serves as a mere example, without claims of perfection.</span></p>
<p><span style="font-size:small; background-color:#ffff00">Continue reading here:&nbsp;<a href="https://social.technet.microsoft.com/wiki/contents/articles/37893.c-face-detection-and-recognition-with-azure-face-api.aspx" target="_blank">https://social.technet.microsoft.com/wiki/contents/articles/37893.c-face-detection-and-recognition-with-azure-face-api.aspx</a></span></p>
