# Face API Using ASP.Net MVC
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- ASP.NET MVC
- AngularJS
- Project Oxford Emotion API
## Topics
- Face detection
## Updated
- 01/11/2017
## Description

<h3><strong>Contents To&nbsp;Focused:</strong></h3>
<ul>
<li>What is Cognitive Services? </li><li>What is Face API? </li><li>Sign Up for Face API </li><li>Create ASP.Net MVC Sample Application
<ul>
<li>Add AngularJS </li><li>Install &amp; Configure the Face API </li></ul>
</li><li>Upload images to detect faces </li><li>Mark faces in the image </li><li>List detected faces with face information </li><li>Summary </li></ul>
<h3><strong>Cognitive Services (Project Oxford) :</strong></h3>
<p>Microsoft Cognitive Services, formerly known as&nbsp;<em>Project Oxford</em>&nbsp;are a set of machine-learning application programming interfaces (REST APIs), SDKs and services that helps developers to make smarter application by add intelligent features
 &ndash; such as emotion and video detection; facial, speech and vision recognition; and speech and language understanding. Get more details from website:&nbsp;<a href="https://staging.www.projectoxford.ai/">https://staging.www.projectoxford.ai</a>&nbsp;&nbsp;</p>
<h3><strong>Face API:&nbsp;</strong></h3>
<p>Microsoft Cognitive Services, there are four main components</p>
<ol>
<li><strong>Face recognition:</strong>&nbsp;recognizes faces in photos, groups faces that look alike and verifies whether two faces are the same,
</li><li><strong>Speech processing</strong>: recognize speech and translate it into text, and vice versa,
</li><li><strong>Visual tools</strong>: analyze visual content to look for things like inappropriate content or a dominant color scheme, and
</li><li><strong>Language Understanding Intelligent Service (LUIS):</strong>&nbsp;understand what users mean when they say or type something using natural, everyday language.
</li></ol>
<p>Get more details from Microsoft blog:&nbsp;<a href="http://blogs.microsoft.com/next/2015/05/01/microsofts-project-oxford-helps-developers-build-more-intelligent-apps/#sm.00000qcvfxlefheczxed59b9u8jna">http://blogs.microsoft.com/next/2015/05/01/microsofts-project-oxford-helps-developers-build-more-intelligent-apps/#sm.00000qcvfxlefheczxed59b9u8jna</a></p>
<p>We will implement Face recognition API in our sample application. So what is Face API? Face API, is a cloud-based service that provides the most advanced face algorithms to detect and recognize human faces in images.</p>
<p><strong>Face API has:</strong></p>
<ol>
<li>Face Detection </li><li>Face Verification </li><li>Similar Face Searching </li><li>Face Grouping </li><li>Face Identification </li></ol>
<p>Get detailed overview here:&nbsp;<a href="https://www.microsoft.com/cognitive-services/en-us/face-api/documentation/overview">https://www.microsoft.com/cognitive-services/en-us/face-api/documentation/overview</a></p>
<p><strong>Face Detection:&nbsp;</strong>In this post we are focusing on detecting faces so before we deal with the sample application let&rsquo;s take a closer look to API Reference (<a href="https://dev.projectoxford.ai/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395236">Face
 API - V1.0</a>). To enable the services we need to get an authorization key (API Key) by signing up with the service for free. Go to the link for signup:&nbsp;<a href="https://www.microsoft.com/cognitive-services/en-us/sign-up">https://www.microsoft.com/cognitive-services/en-us/sign-up</a>&nbsp;&nbsp;</p>
<h3><strong>Sign Up for Face API:</strong></h3>
<p>Sign up using any one by clicking on it,</p>
<ul>
<li>Microsoft account </li><li>GitHub </li><li>LinkedIn </li></ul>
<p>after successfully joining it will redirect to subscriptionsmpage. Request new trials for any of the product by selecting the checkbox. Process: Click on Request new trials &gt; Face - Preview &gt; Agree Term &gt; Subscribe Here you can see I have attached
 a screenshot of my subscription. In the Keys column from Key 1 click on &ldquo;Show&rdquo; to preview the API Key, click &ldquo;Copy&rdquo; to copy the key for further use. Key can be regenerate by clicking on &ldquo;Regenerate&rdquo;.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_8.png"><img class="alignnone size-large x_x_x_x_x_x_wp-image-3797" src="-fapi_8-1024x544.png" alt="" width="640" height="340"></a></p>
<p>So fur we are done with the subscription process, now let&rsquo;s get started with the ASP.Net MVC sample application.</p>
<h3><strong>Create Sample Application:&nbsp;</strong></h3>
<p>Before going to start the experiment let&rsquo;s make sure Visual Studio 2015 is installed on development machine. let&rsquo;s open Visual Studio 2015, From the File menu, click on New &gt; Project.&nbsp;<a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_1.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3784" src="-fapi_1.png" alt=""></a></p>
<p>Select ASP.Net Web Application, name it as you like, I just named it &ldquo;FaceAPI_MVC&rdquo; click Ok button to proceed on for next step. Choose empty template for the sample application, select &ldquo;MVC&rdquo; check box then click Ok.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_2.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3785" src="-fapi_2.png" alt=""></a></p>
<p>In our empty template let&rsquo;s now create MVC controller and generate views by scaffolding.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_3.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3786" src="-fapi_3.png" alt="" width="271" height="275"></a></p>
<h3><strong>Add AngularJS:&nbsp;</strong></h3>
<p>We need to add packages in our sample application. To do that go to Solution Explorer Right Click on Project &gt; Manage NuGet Package</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_4.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3792" src="-fapi_4.png" alt="" width="538" height="368"></a></p>
<p>In Package Manager Search by typing &ldquo;angularjs&rdquo;, select package then click Install.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_5.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3793" src="-fapi_5.png" alt=""></a>&nbsp;</p>
<p>After installing &ldquo;angularjs&rdquo; package we need to reference it in our layout page, also we need to define app root using &ldquo;ng-app&rdquo; directive.&nbsp;</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_6.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3794" src="-fapi_6.png" alt="" width="562" height="228"></a></p>
<p>If you are new to angularjs, please get a basic overview on angularjs with MVC application from here:&nbsp;<a href="http://shashangka.com/2016/01/17/asp-net-mvc-5-with-angularjs-part-1">http://shashangka.com/2016/01/17/asp-net-mvc-5-with-angularjs-part-1</a>&nbsp;&nbsp;</p>
<h3><strong>Install &amp; Configure the Face API:</strong></h3>
<p>We need to add<strong>&nbsp;&ldquo;Microsoft.ProjectOxford.Face&rdquo;&nbsp;</strong>library in our sample application. Type and search like below screen then select and Install.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_7.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3795" src="-fapi_7.png" alt=""></a></p>
<p><strong>Web.Config:&nbsp;</strong>&nbsp;In application Web.Config add a new configuration setting in appSettings section with our previously generated API Key.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;add key=&quot;FaceServiceKey&quot; value=&quot;xxxxxxxxxxxxxxxxxxxxxxxxxxx&quot; /&gt;</pre>
<div class="preview">
<pre class="js">&lt;add&nbsp;key=<span class="js__string">&quot;FaceServiceKey&quot;</span>&nbsp;value=<span class="js__string">&quot;xxxxxxxxxxxxxxxxxxxxxxxxxxx&quot;</span>&nbsp;/&gt;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Finallly appSettings:</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xml</span>
<pre class="hidden">&lt;appSettings&gt;
  &lt;add key=&quot;webpages:Version&quot; value=&quot;3.0.0.0&quot; /&gt;
  &lt;add key=&quot;webpages:Enabled&quot; value=&quot;false&quot; /&gt;
  &lt;add key=&quot;PreserveLoginUrl&quot; value=&quot;true&quot; /&gt;
  &lt;add key=&quot;ClientValidationEnabled&quot; value=&quot;true&quot; /&gt;
  &lt;add key=&quot;UnobtrusiveJavaScriptEnabled&quot; value=&quot;true&quot; /&gt;
  &lt;add key=&quot;FaceServiceKey&quot; value=&quot;xxxxxxxxxxxxxxxxxxxxxxxxxxx&quot; /&gt; &lt;!--replace with API Key--&gt;
&lt;/appSettings&gt;</pre>
<div class="preview">
<pre class="js">&lt;appSettings&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;webpages:Version&quot;</span>&nbsp;value=<span class="js__string">&quot;3.0.0.0&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;webpages:Enabled&quot;</span>&nbsp;value=<span class="js__string">&quot;false&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;PreserveLoginUrl&quot;</span>&nbsp;value=<span class="js__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;ClientValidationEnabled&quot;</span>&nbsp;value=<span class="js__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;UnobtrusiveJavaScriptEnabled&quot;</span>&nbsp;value=<span class="js__string">&quot;true&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&lt;add&nbsp;key=<span class="js__string">&quot;FaceServiceKey&quot;</span>&nbsp;value=<span class="js__string">&quot;xxxxxxxxxxxxxxxxxxxxxxxxxxx&quot;</span>&nbsp;/&gt;&nbsp;&lt;!--replace&nbsp;<span class="js__statement">with</span>&nbsp;API&nbsp;Key--&gt;&nbsp;
&lt;/appSettings&gt;</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>MVC Controller:&nbsp;</strong>This is where we are performing our main operation. First of all&nbsp;Get FaceServiceKey Value from web.config by&nbsp;ConfigurationManager.AppSettings.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">private static string ServiceKey = ConfigurationManager.AppSettings[&quot;FaceServiceKey&quot;];</pre>
<div class="preview">
<pre class="js">private&nbsp;static&nbsp;string&nbsp;ServiceKey&nbsp;=&nbsp;ConfigurationManager.AppSettings[<span class="js__string">&quot;FaceServiceKey&quot;</span>];</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Here in MVC Controller we have two main method to performing the face detection operation. One is HttpPost method, which is using for uploading the image file to folder and the other one is HttpGet method is using to get uploaded image and detecting faces
 by calling API Service. Both methods are getting called from client script while uploading image to detect faces. Let&rsquo;s get explained in steps.</p>
<p><strong>Image Upload:&nbsp;</strong>This method is responsible for uploading images.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[HttpPost]
public JsonResult SaveCandidateFiles()
{
    //Create Directory if Not Exist
    //Requested File Collection
    //Clear Folder
    //Save File in Folder
}</pre>
<div class="preview">
<pre class="js">[HttpPost]&nbsp;
public&nbsp;JsonResult&nbsp;SaveCandidateFiles()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;Directory&nbsp;if&nbsp;Not&nbsp;Exist</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Requested&nbsp;File&nbsp;Collection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Clear&nbsp;Folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Save&nbsp;File&nbsp;in&nbsp;Folder</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Image Detect:&nbsp;</strong>This method is responsible for detecting the faces from uploaded images.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">[HttpGet]
public async Task&lt;dynamic&gt; GetDetectedFaces()
{
     // Open an existing file for reading
     // Create Instance of Service Client by passing Servicekey as parameter in constructor
     // Call detection REST API
     // Create &amp; Save Cropped Detected Face Images
     // Convert detection result into UI binding object
}</pre>
<div class="preview">
<pre class="js">[HttpGet]&nbsp;
public&nbsp;async&nbsp;Task&lt;dynamic&gt;&nbsp;GetDetectedFaces()&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Open&nbsp;an&nbsp;existing&nbsp;file&nbsp;for&nbsp;reading</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;Instance&nbsp;of&nbsp;Service&nbsp;Client&nbsp;by&nbsp;passing&nbsp;Servicekey&nbsp;as&nbsp;parameter&nbsp;in&nbsp;constructor</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Call&nbsp;detection&nbsp;REST&nbsp;API</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;&amp;&nbsp;Save&nbsp;Cropped&nbsp;Detected&nbsp;Face&nbsp;Images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Convert&nbsp;detection&nbsp;result&nbsp;into&nbsp;UI&nbsp;binding&nbsp;object</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>This is the code snippet&nbsp;where the Face API is getting called to detect the face from uploaded image.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">// Open an existing file for reading
var fStream = System.IO.File.OpenRead(FullImgPath)

// Create Instance of Service Client by passing Servicekey as parameter in constructor 
var faceServiceClient = new FaceServiceClient(ServiceKey);

// Call detection REST API
Face[] faces = await faceServiceClient.DetectAsync(fStream, true, true, new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses });
Create &amp; Save Cropped Detected Face Images.

Hide   Copy Code
var croppedImg = Convert.ToString(Guid.NewGuid()) &#43; &quot;.jpeg&quot; as string;
var croppedImgPath = directory &#43; '/' &#43; croppedImg as string;
var croppedImgFullPath = Server.MapPath(directory) &#43; '/' &#43; croppedImg as string;
CroppedFace = CropBitmap(
              (Bitmap)Image.FromFile(FullImgPath),
              face.FaceRectangle.Left,
              face.FaceRectangle.Top,
              face.FaceRectangle.Width,
              face.FaceRectangle.Height);
CroppedFace.Save(croppedImgFullPath, ImageFormat.Jpeg);
if (CroppedFace != null)
   ((IDisposable)CroppedFace).Dispose();</pre>
<div class="preview">
<pre class="js"><span class="js__sl_comment">//&nbsp;Open&nbsp;an&nbsp;existing&nbsp;file&nbsp;for&nbsp;reading</span>&nbsp;
<span class="js__statement">var</span>&nbsp;fStream&nbsp;=&nbsp;System.IO.File.OpenRead(FullImgPath)&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Create&nbsp;Instance&nbsp;of&nbsp;Service&nbsp;Client&nbsp;by&nbsp;passing&nbsp;Servicekey&nbsp;as&nbsp;parameter&nbsp;in&nbsp;constructor&nbsp;</span>&nbsp;
<span class="js__statement">var</span>&nbsp;faceServiceClient&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FaceServiceClient(ServiceKey);&nbsp;
&nbsp;
<span class="js__sl_comment">//&nbsp;Call&nbsp;detection&nbsp;REST&nbsp;API</span>&nbsp;
Face[]&nbsp;faces&nbsp;=&nbsp;await&nbsp;faceServiceClient.DetectAsync(fStream,&nbsp;true,&nbsp;true,&nbsp;<span class="js__operator">new</span>&nbsp;FaceAttributeType[]&nbsp;<span class="js__brace">{</span>&nbsp;FaceAttributeType.Gender,&nbsp;FaceAttributeType.Age,&nbsp;FaceAttributeType.Smile,&nbsp;FaceAttributeType.Glasses&nbsp;<span class="js__brace">}</span>);&nbsp;
Create&nbsp;&amp;&nbsp;Save&nbsp;Cropped&nbsp;Detected&nbsp;Face&nbsp;Images.&nbsp;
&nbsp;
Hide&nbsp;&nbsp;&nbsp;Copy&nbsp;Code&nbsp;
<span class="js__statement">var</span>&nbsp;croppedImg&nbsp;=&nbsp;Convert.ToString(Guid.NewGuid())&nbsp;&#43;&nbsp;<span class="js__string">&quot;.jpeg&quot;</span>&nbsp;as&nbsp;string;&nbsp;
<span class="js__statement">var</span>&nbsp;croppedImgPath&nbsp;=&nbsp;directory&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;croppedImg&nbsp;as&nbsp;string;&nbsp;
<span class="js__statement">var</span>&nbsp;croppedImgFullPath&nbsp;=&nbsp;Server.MapPath(directory)&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;croppedImg&nbsp;as&nbsp;string;&nbsp;
CroppedFace&nbsp;=&nbsp;CropBitmap(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Bitmap)Image.FromFile(FullImgPath),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Left,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Top,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Height);&nbsp;
CroppedFace.Save(croppedImgFullPath,&nbsp;ImageFormat.Jpeg);&nbsp;
<span class="js__statement">if</span>&nbsp;(CroppedFace&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;((IDisposable)CroppedFace).Dispose();</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Method that&nbsp;Cropping Images according to face values.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
{
    // Crop Images
}</pre>
<div class="preview">
<pre class="js">public&nbsp;Bitmap&nbsp;CropBitmap(Bitmap&nbsp;bitmap,&nbsp;int&nbsp;cropX,&nbsp;int&nbsp;cropY,&nbsp;int&nbsp;cropWidth,&nbsp;int&nbsp;cropHeight)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Crop&nbsp;Images</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Finally Full MVC Controller:</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>C#</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">csharp</span>
<pre class="hidden">public class FaceDetectionController : Controller
{
    private static string ServiceKey = ConfigurationManager.AppSettings[&quot;FaceServiceKey&quot;];
    private static string directory = &quot;../UploadedFiles&quot;;
    private static string UplImageName = string.Empty;
    private ObservableCollection&lt;vmFace&gt; _detectedFaces = new ObservableCollection&lt;vmFace&gt;();
    private ObservableCollection&lt;vmFace&gt; _resultCollection = new ObservableCollection&lt;vmFace&gt;();
    public ObservableCollection&lt;vmFace&gt; DetectedFaces
    {
        get
        {
            return _detectedFaces;
        }
    }
    public ObservableCollection&lt;vmFace&gt; ResultCollection
    {
        get
        {
            return _resultCollection;
        }
    }
    public int MaxImageSize
    {
        get
        {
            return 450;
        }
    }

    // GET: FaceDetection
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public JsonResult SaveCandidateFiles()
    {
        string message = string.Empty, fileName = string.Empty, actualFileName = string.Empty; bool flag = false;
        //Requested File Collection
        HttpFileCollection fileRequested = System.Web.HttpContext.Current.Request.Files;
        if (fileRequested != null)
        {
            //Create New Folder
            CreateDirectory();

            //Clear Existing File in Folder
            ClearDirectory();

            for (int i = 0; i &lt; fileRequested.Count; i&#43;&#43;)
            {
                var file = Request.Files[i];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() &#43; Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath(directory), fileName));
                    message = &quot;File uploaded successfully&quot;;
                    UplImageName = fileName;
                    flag = true;
                }
                catch (Exception)
                {
                    message = &quot;File upload failed! Please try again&quot;;
                }
            }
        }
        return new JsonResult
        {
            Data = new
            {
                Message = message,
                UplImageName = fileName,
                Status = flag
            }
        };
    }

    [HttpGet]
    public async Task&lt;dynamic&gt; GetDetectedFaces()
    {
        ResultCollection.Clear();
        DetectedFaces.Clear();

        var DetectedResultsInText = string.Format(&quot;Detecting...&quot;);
        var FullImgPath = Server.MapPath(directory) &#43; '/' &#43; UplImageName as string;
        var QueryFaceImageUrl = directory &#43; '/' &#43; UplImageName;

        if (UplImageName != &quot;&quot;)
        {
            //Create New Folder
            CreateDirectory();

            try
            {
                // Call detection REST API
                using (var fStream = System.IO.File.OpenRead(FullImgPath))
                {
                    // User picked one image
                    var imageInfo = UIHelper.GetImageInfoForRendering(FullImgPath);

                    // Create Instance of Service Client by passing Servicekey as parameter in constructor 
                    var faceServiceClient = new FaceServiceClient(ServiceKey);
                    Face[] faces = await faceServiceClient.DetectAsync(fStream, true, true, new FaceAttributeType[] { FaceAttributeType.Gender, FaceAttributeType.Age, FaceAttributeType.Smile, FaceAttributeType.Glasses });
                    DetectedResultsInText = string.Format(&quot;{0} face(s) has been detected!!&quot;, faces.Length);
                    Bitmap CroppedFace = null;

                    foreach (var face in faces)
                    {
                        //Create &amp; Save Cropped Images
                        var croppedImg = Convert.ToString(Guid.NewGuid()) &#43; &quot;.jpeg&quot; as string;
                        var croppedImgPath = directory &#43; '/' &#43; croppedImg as string;
                        var croppedImgFullPath = Server.MapPath(directory) &#43; '/' &#43; croppedImg as string;
                        CroppedFace = CropBitmap(
                                        (Bitmap)Image.FromFile(FullImgPath),
                                        face.FaceRectangle.Left,
                                        face.FaceRectangle.Top,
                                        face.FaceRectangle.Width,
                                        face.FaceRectangle.Height);
                        CroppedFace.Save(croppedImgFullPath, ImageFormat.Jpeg);
                        if (CroppedFace != null)
                            ((IDisposable)CroppedFace).Dispose();


                        DetectedFaces.Add(new vmFace()
                        {
                            ImagePath = FullImgPath,
                            FileName = croppedImg,
                            FilePath = croppedImgPath,
                            Left = face.FaceRectangle.Left,
                            Top = face.FaceRectangle.Top,
                            Width = face.FaceRectangle.Width,
                            Height = face.FaceRectangle.Height,
                            FaceId = face.FaceId.ToString(),
                            Gender = face.FaceAttributes.Gender,
                            Age = string.Format(&quot;{0:#} years old&quot;, face.FaceAttributes.Age),
                            IsSmiling = face.FaceAttributes.Smile &gt; 0.0 ? &quot;Smile&quot; : &quot;Not Smile&quot;,
                            Glasses = face.FaceAttributes.Glasses.ToString(),
                        });
                    }

                    // Convert detection result into UI binding object for rendering
                    var rectFaces = UIHelper.CalculateFaceRectangleForRendering(faces, MaxImageSize, imageInfo);
                    foreach (var face in rectFaces)
                    {
                        ResultCollection.Add(face);
                    }
                }
            }
            catch (FaceAPIException)
            {
                //do exception work
            }
        }
        return new JsonResult
        {
            Data = new
            {
                QueryFaceImage = QueryFaceImageUrl,
                MaxImageSize = MaxImageSize,
                FaceInfo = DetectedFaces,
                FaceRectangles = ResultCollection,
                DetectedResults = DetectedResultsInText
            },
            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
    }

    public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
    {
        Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
        Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
        return cropped;
    }

    public void CreateDirectory()
    {
        bool exists = System.IO.Directory.Exists(Server.MapPath(directory));
        if (!exists)
        {
            try
            {
                Directory.CreateDirectory(Server.MapPath(directory));
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }

    public void ClearDirectory()
    {
        DirectoryInfo dir = new DirectoryInfo(Path.Combine(Server.MapPath(directory)));
        var files = dir.GetFiles();
        if (files.Length &gt; 0)
        {
            try
            {
                foreach (FileInfo fi in dir.GetFiles())
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    fi.Delete();
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}</pre>
<div class="preview">
<pre class="js">public&nbsp;class&nbsp;FaceDetectionController&nbsp;:&nbsp;Controller&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;string&nbsp;ServiceKey&nbsp;=&nbsp;ConfigurationManager.AppSettings[<span class="js__string">&quot;FaceServiceKey&quot;</span>];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;string&nbsp;directory&nbsp;=&nbsp;<span class="js__string">&quot;../UploadedFiles&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;static&nbsp;string&nbsp;UplImageName&nbsp;=&nbsp;string.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;ObservableCollection&lt;vmFace&gt;&nbsp;_detectedFaces&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObservableCollection&lt;vmFace&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;ObservableCollection&lt;vmFace&gt;&nbsp;_resultCollection&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObservableCollection&lt;vmFace&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ObservableCollection&lt;vmFace&gt;&nbsp;DetectedFaces&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_detectedFaces;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ObservableCollection&lt;vmFace&gt;&nbsp;ResultCollection&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_resultCollection;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;int&nbsp;MaxImageSize&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__num">450</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;GET:&nbsp;FaceDetection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ActionResult&nbsp;Index()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;View();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpPost]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;JsonResult&nbsp;SaveCandidateFiles()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;string&nbsp;message&nbsp;=&nbsp;string.Empty,&nbsp;fileName&nbsp;=&nbsp;string.Empty,&nbsp;actualFileName&nbsp;=&nbsp;string.Empty;&nbsp;bool&nbsp;flag&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Requested&nbsp;File&nbsp;Collection</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;HttpFileCollection&nbsp;fileRequested&nbsp;=&nbsp;System.Web.HttpContext.Current.Request.Files;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(fileRequested&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;New&nbsp;Folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDirectory();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Clear&nbsp;Existing&nbsp;File&nbsp;in&nbsp;Folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ClearDirectory();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">for</span>&nbsp;(int&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>;&nbsp;i&nbsp;&lt;&nbsp;fileRequested.Count;&nbsp;i&#43;&#43;)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;file&nbsp;=&nbsp;Request.Files[i];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;actualFileName&nbsp;=&nbsp;file.FileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileName&nbsp;=&nbsp;Guid.NewGuid()&nbsp;&#43;&nbsp;Path.GetExtension(file.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;int&nbsp;size&nbsp;=&nbsp;file.ContentLength;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;file.SaveAs(Path.Combine(Server.MapPath(directory),&nbsp;fileName));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;<span class="js__string">&quot;File&nbsp;uploaded&nbsp;successfully&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UplImageName&nbsp;=&nbsp;fileName;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;flag&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;message&nbsp;=&nbsp;<span class="js__string">&quot;File&nbsp;upload&nbsp;failed!&nbsp;Please&nbsp;try&nbsp;again&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;JsonResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Message&nbsp;=&nbsp;message,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;UplImageName&nbsp;=&nbsp;fileName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Status&nbsp;=&nbsp;flag&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;[HttpGet]&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;async&nbsp;Task&lt;dynamic&gt;&nbsp;GetDetectedFaces()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResultCollection.Clear();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DetectedFaces.Clear();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;DetectedResultsInText&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;Detecting...&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;FullImgPath&nbsp;=&nbsp;Server.MapPath(directory)&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;UplImageName&nbsp;as&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;QueryFaceImageUrl&nbsp;=&nbsp;directory&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;UplImageName;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(UplImageName&nbsp;!=&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;New&nbsp;Folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CreateDirectory();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Call&nbsp;detection&nbsp;REST&nbsp;API</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;using&nbsp;(<span class="js__statement">var</span>&nbsp;fStream&nbsp;=&nbsp;System.IO.File.OpenRead(FullImgPath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;User&nbsp;picked&nbsp;one&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;imageInfo&nbsp;=&nbsp;UIHelper.GetImageInfoForRendering(FullImgPath);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Create&nbsp;Instance&nbsp;of&nbsp;Service&nbsp;Client&nbsp;by&nbsp;passing&nbsp;Servicekey&nbsp;as&nbsp;parameter&nbsp;in&nbsp;constructor&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;faceServiceClient&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FaceServiceClient(ServiceKey);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Face[]&nbsp;faces&nbsp;=&nbsp;await&nbsp;faceServiceClient.DetectAsync(fStream,&nbsp;true,&nbsp;true,&nbsp;<span class="js__operator">new</span>&nbsp;FaceAttributeType[]&nbsp;<span class="js__brace">{</span>&nbsp;FaceAttributeType.Gender,&nbsp;FaceAttributeType.Age,&nbsp;FaceAttributeType.Smile,&nbsp;FaceAttributeType.Glasses&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DetectedResultsInText&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;{0}&nbsp;face(s)&nbsp;has&nbsp;been&nbsp;detected!!&quot;</span>,&nbsp;faces.Length);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;CroppedFace&nbsp;=&nbsp;null;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;face&nbsp;<span class="js__operator">in</span>&nbsp;faces)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;&amp;&nbsp;Save&nbsp;Cropped&nbsp;Images</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;croppedImg&nbsp;=&nbsp;Convert.ToString(Guid.NewGuid())&nbsp;&#43;&nbsp;<span class="js__string">&quot;.jpeg&quot;</span>&nbsp;as&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;croppedImgPath&nbsp;=&nbsp;directory&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;croppedImg&nbsp;as&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;croppedImgFullPath&nbsp;=&nbsp;Server.MapPath(directory)&nbsp;&#43;&nbsp;<span class="js__string">'/'</span>&nbsp;&#43;&nbsp;croppedImg&nbsp;as&nbsp;string;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CroppedFace&nbsp;=&nbsp;CropBitmap(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Bitmap)Image.FromFile(FullImgPath),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Left,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Top,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;face.FaceRectangle.Height);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CroppedFace.Save(croppedImgFullPath,&nbsp;ImageFormat.Jpeg);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(CroppedFace&nbsp;!=&nbsp;null)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;((IDisposable)CroppedFace).Dispose();&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DetectedFaces.Add(<span class="js__operator">new</span>&nbsp;vmFace()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ImagePath&nbsp;=&nbsp;FullImgPath,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FileName&nbsp;=&nbsp;croppedImg,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FilePath&nbsp;=&nbsp;croppedImgPath,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Left&nbsp;=&nbsp;face.FaceRectangle.Left,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Top&nbsp;=&nbsp;face.FaceRectangle.Top,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width&nbsp;=&nbsp;face.FaceRectangle.Width,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height&nbsp;=&nbsp;face.FaceRectangle.Height,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceId&nbsp;=&nbsp;face.FaceId.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Gender&nbsp;=&nbsp;face.FaceAttributes.Gender,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Age&nbsp;=&nbsp;string.Format(<span class="js__string">&quot;{0:#}&nbsp;years&nbsp;old&quot;</span>,&nbsp;face.FaceAttributes.Age),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;IsSmiling&nbsp;=&nbsp;face.FaceAttributes.Smile&nbsp;&gt;&nbsp;<span class="js__num">0.0</span>&nbsp;?&nbsp;<span class="js__string">&quot;Smile&quot;</span>&nbsp;:&nbsp;<span class="js__string">&quot;Not&nbsp;Smile&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Glasses&nbsp;=&nbsp;face.FaceAttributes.Glasses.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//&nbsp;Convert&nbsp;detection&nbsp;result&nbsp;into&nbsp;UI&nbsp;binding&nbsp;object&nbsp;for&nbsp;rendering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;rectFaces&nbsp;=&nbsp;UIHelper.CalculateFaceRectangleForRendering(faces,&nbsp;MaxImageSize,&nbsp;imageInfo);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;face&nbsp;<span class="js__operator">in</span>&nbsp;rectFaces)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ResultCollection.Add(face);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(FaceAPIException)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//do&nbsp;exception&nbsp;work</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;<span class="js__operator">new</span>&nbsp;JsonResult&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Data&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;QueryFaceImage&nbsp;=&nbsp;QueryFaceImageUrl,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MaxImageSize&nbsp;=&nbsp;MaxImageSize,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceInfo&nbsp;=&nbsp;DetectedFaces,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceRectangles&nbsp;=&nbsp;ResultCollection,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DetectedResults&nbsp;=&nbsp;DetectedResultsInText&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JsonRequestBehavior&nbsp;=&nbsp;JsonRequestBehavior.AllowGet&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Bitmap&nbsp;CropBitmap(Bitmap&nbsp;bitmap,&nbsp;int&nbsp;cropX,&nbsp;int&nbsp;cropY,&nbsp;int&nbsp;cropWidth,&nbsp;int&nbsp;cropHeight)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rectangle&nbsp;rect&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;Rectangle(cropX,&nbsp;cropY,&nbsp;cropWidth,&nbsp;cropHeight);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Bitmap&nbsp;cropped&nbsp;=&nbsp;bitmap.Clone(rect,&nbsp;bitmap.PixelFormat);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;cropped;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;CreateDirectory()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bool&nbsp;exists&nbsp;=&nbsp;System.IO.Directory.Exists(Server.MapPath(directory));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(!exists)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Directory.CreateDirectory(Server.MapPath(directory));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ex.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;<span class="js__operator">void</span>&nbsp;ClearDirectory()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DirectoryInfo&nbsp;dir&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;DirectoryInfo(Path.Combine(Server.MapPath(directory)));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;files&nbsp;=&nbsp;dir.GetFiles();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(files.Length&nbsp;&gt;&nbsp;<span class="js__num">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(FileInfo&nbsp;fi&nbsp;<span class="js__operator">in</span>&nbsp;dir.GetFiles())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GC.Collect();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GC.WaitForPendingFinalizers();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fi.Delete();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ex.ToString();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span></pre>
</div>
</strong></div>
</div>
<p>&nbsp;</p>
<p><strong>UI Helper:</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">/// &lt;summary&gt;
/// UI helper functions
/// &lt;/summary&gt;
internal static class UIHelper
{
    #region Methods

    /// &lt;summary&gt;
    /// Calculate the rendering face rectangle
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;faces&quot;&gt;Detected face from service&lt;/param&gt;
    /// &lt;param name=&quot;maxSize&quot;&gt;Image rendering size&lt;/param&gt;
    /// &lt;param name=&quot;imageInfo&quot;&gt;Image width and height&lt;/param&gt;
    /// &lt;returns&gt;Face structure for rendering&lt;/returns&gt;
    public static IEnumerable&lt;vmFace&gt; CalculateFaceRectangleForRendering(IEnumerable&lt;Microsoft.ProjectOxford.Face.Contract.Face&gt; faces, int maxSize, Tuple&lt;int, int&gt; imageInfo)
    {
        var imageWidth = imageInfo.Item1;
        var imageHeight = imageInfo.Item2;
        float ratio = (float)imageWidth / imageHeight;

        int uiWidth = 0;
        int uiHeight = 0;

        uiWidth = maxSize;
        uiHeight = (int)(maxSize / ratio);
       
        float scale = (float)uiWidth / imageWidth;

        foreach (var face in faces)
        {
            yield return new vmFace()
            {
                FaceId = face.FaceId.ToString(),
                Left = (int)(face.FaceRectangle.Left * scale),
                Top = (int)(face.FaceRectangle.Top * scale),
                Height = (int)(face.FaceRectangle.Height * scale),
                Width = (int)(face.FaceRectangle.Width * scale),
            };
        }
    }

    /// &lt;summary&gt;
    /// Get image basic information for further rendering usage
    /// &lt;/summary&gt;
    /// &lt;param name=&quot;imageFilePath&quot;&gt;Path to the image file&lt;/param&gt;
    /// &lt;returns&gt;Image width and height&lt;/returns&gt;
    public static Tuple&lt;int, int&gt; GetImageInfoForRendering(string imageFilePath)
    {
        try
        {
            using (var s = File.OpenRead(imageFilePath))
            {
                JpegBitmapDecoder decoder = new JpegBitmapDecoder(s, BitmapCreateOptions.None, BitmapCacheOption.None);
                var frame = decoder.Frames.First();

                // Store image width and height for following rendering
                return new Tuple&lt;int, int&gt;(frame.PixelWidth, frame.PixelHeight);
            }
        }
        catch
        {
            return new Tuple&lt;int, int&gt;(0, 0);
        }
    }
    #endregion Methods
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
<span class="cs__com">///&nbsp;UI&nbsp;helper&nbsp;functions</span>&nbsp;
<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
<span class="cs__keyword">internal</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;UIHelper&nbsp;
{<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#region&nbsp;Methods</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Calculate&nbsp;the&nbsp;rendering&nbsp;face&nbsp;rectangle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;faces&quot;&gt;Detected&nbsp;face&nbsp;from&nbsp;service&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;maxSize&quot;&gt;Image&nbsp;rendering&nbsp;size&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;imageInfo&quot;&gt;Image&nbsp;width&nbsp;and&nbsp;height&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;Face&nbsp;structure&nbsp;for&nbsp;rendering&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;IEnumerable&lt;vmFace&gt;&nbsp;CalculateFaceRectangleForRendering(IEnumerable&lt;Microsoft.ProjectOxford.Face.Contract.Face&gt;&nbsp;faces,&nbsp;<span class="cs__keyword">int</span>&nbsp;maxSize,&nbsp;Tuple&lt;<span class="cs__keyword">int</span>,&nbsp;<span class="cs__keyword">int</span>&gt;&nbsp;imageInfo)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageWidth&nbsp;=&nbsp;imageInfo.Item1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;imageHeight&nbsp;=&nbsp;imageInfo.Item2;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;ratio&nbsp;=&nbsp;(<span class="cs__keyword">float</span>)imageWidth&nbsp;/&nbsp;imageHeight;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;uiWidth&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;uiHeight&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiWidth&nbsp;=&nbsp;maxSize;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;uiHeight&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(maxSize&nbsp;/&nbsp;ratio);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">float</span>&nbsp;scale&nbsp;=&nbsp;(<span class="cs__keyword">float</span>)uiWidth&nbsp;/&nbsp;imageWidth;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">foreach</span>&nbsp;(var&nbsp;face&nbsp;<span class="cs__keyword">in</span>&nbsp;faces)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yield&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;vmFace()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FaceId&nbsp;=&nbsp;face.FaceId.ToString(),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Left&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(face.FaceRectangle.Left&nbsp;*&nbsp;scale),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Top&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(face.FaceRectangle.Top&nbsp;*&nbsp;scale),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Height&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(face.FaceRectangle.Height&nbsp;*&nbsp;scale),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Width&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(face.FaceRectangle.Width&nbsp;*&nbsp;scale),&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Get&nbsp;image&nbsp;basic&nbsp;information&nbsp;for&nbsp;further&nbsp;rendering&nbsp;usage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;param&nbsp;name=&quot;imageFilePath&quot;&gt;Path&nbsp;to&nbsp;the&nbsp;image&nbsp;file&lt;/param&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;returns&gt;Image&nbsp;width&nbsp;and&nbsp;height&lt;/returns&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;Tuple&lt;<span class="cs__keyword">int</span>,&nbsp;<span class="cs__keyword">int</span>&gt;&nbsp;GetImageInfoForRendering(<span class="cs__keyword">string</span>&nbsp;imageFilePath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(var&nbsp;s&nbsp;=&nbsp;File.OpenRead(imageFilePath))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;JpegBitmapDecoder&nbsp;decoder&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;JpegBitmapDecoder(s,&nbsp;BitmapCreateOptions.None,&nbsp;BitmapCacheOption.None);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;frame&nbsp;=&nbsp;decoder.Frames.First();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Store&nbsp;image&nbsp;width&nbsp;and&nbsp;height&nbsp;for&nbsp;following&nbsp;rendering</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Tuple&lt;<span class="cs__keyword">int</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(frame.PixelWidth,&nbsp;frame.PixelHeight);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">new</span>&nbsp;Tuple&lt;<span class="cs__keyword">int</span>,&nbsp;<span class="cs__keyword">int</span>&gt;(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}<span class="cs__preproc">&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;#endregion&nbsp;Methods</span>&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>MVC View:</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>HTML</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">html</span>
<pre class="hidden">@{
    ViewBag.Title = &quot;Face Detection&quot;;
}

&lt;div ng-controller=&quot;faceDetectionCtrl&quot;&gt;

    &lt;h3&gt;{{Title}}&lt;/h3&gt;
    &lt;div class=&quot;loadmore&quot;&gt;
        &lt;div ng-show=&quot;loaderMoreupl&quot; ng-class=&quot;result&quot;&gt;
            &lt;img src=&quot;~/Content/ng-loader.gif&quot; /&gt; {{uplMessage}}
        &lt;/div&gt;
    &lt;/div&gt;
    &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
    &lt;table style=&quot;width:100%&quot;&gt;
        &lt;tr&gt;
            &lt;th&gt;&lt;h4&gt;Select Query Face&lt;/h4&gt;&lt;/th&gt;
            &lt;th&gt;&lt;h4&gt;Detection Result&lt;/h4&gt;&lt;/th&gt;
        &lt;/tr&gt;
        &lt;tr&gt;
            &lt;td style=&quot;width:60%&quot; valign=&quot;top&quot;&gt;
                &lt;form novalidate name=&quot;f1&quot;&gt;
                    &lt;input type=&quot;file&quot; name=&quot;file&quot; accept=&quot;image/*&quot; onchange=&quot;angular.element(this).scope().selectCandidateFileforUpload(this.files)&quot; required /&gt;
                &lt;/form&gt;
                &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
                &lt;div class=&quot;loadmore&quot;&gt;
                    &lt;div ng-show=&quot;loaderMore&quot; ng-class=&quot;result&quot;&gt;
                        &lt;img src=&quot;~/Content/ng-loader.gif&quot; /&gt; {{faceMessage}}
                    &lt;/div&gt;
                &lt;/div&gt;
                &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
                &lt;div class=&quot;facePreview_thumb_big&quot; id=&quot;faceCanvas&quot;&gt;&lt;/div&gt;
            &lt;/td&gt;
            &lt;td style=&quot;width:40%&quot; valign=&quot;top&quot;&gt;
                &lt;p&gt;{{DetectedResultsMessage}}&lt;/p&gt;
                &lt;hr /&gt;
                &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
                &lt;div class=&quot;facePreview_thumb_small&quot;&gt;
                    &lt;div ng-repeat=&quot;item in DetectedFaces&quot; class=&quot;col-sm-12&quot;&gt;
                        &lt;div class=&quot;col-sm-3&quot;&gt;
                            &lt;img ng-src=&quot;{{item.FilePath}}&quot; width=&quot;100&quot; /&gt;
                        &lt;/div&gt;
                        &lt;div class=&quot;col-sm-8&quot;&gt;
                            &lt;ul&gt;
                                @*&lt;li&gt;FaceId: {{item.FaceId}}&lt;/li&gt;*@
                                &lt;li&gt;Age: {{item.Age}}&lt;/li&gt;
                                &lt;li&gt;Gender: {{item.Gender}}&lt;/li&gt;
                                &lt;li&gt;{{item.IsSmiling}}&lt;/li&gt;
                                &lt;li&gt;{{item.Glasses}}&lt;/li&gt;
                            &lt;/ul&gt;
                        &lt;/div&gt;
                        &lt;div class=&quot;clearfix&quot;&gt;&lt;/div&gt;
                    &lt;/div&gt;
                &lt;/div&gt;
                &lt;div ng-hide=&quot;DetectedFaces.length&quot;&gt;No face detected!!&lt;/div&gt;
            &lt;/td&gt;
        &lt;/tr&gt;
    &lt;/table&gt;
&lt;/div&gt;

@section NgScript{
    &lt;script src=&quot;~/ScriptsNg/FaceDetectionCtrl.js&quot;&gt;&lt;/script&gt;
}</pre>
<div class="preview">
<pre class="js">@<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ViewBag.Title&nbsp;=&nbsp;<span class="js__string">&quot;Face&nbsp;Detection&quot;</span>;&nbsp;
<span class="js__brace">}</span>&nbsp;
&nbsp;
&lt;div&nbsp;ng-controller=<span class="js__string">&quot;faceDetectionCtrl&quot;</span>&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;h3&gt;<span class="js__brace">{</span><span class="js__brace">{</span>Title<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/h3&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;loadmore&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;ng-show=<span class="js__string">&quot;loaderMoreupl&quot;</span>&nbsp;ng-class=<span class="js__string">&quot;result&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;src=<span class="js__string">&quot;~/Content/ng-loader.gif&quot;</span>&nbsp;/&gt;&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>uplMessage<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;clearfix&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;table&nbsp;style=<span class="js__string">&quot;width:100%&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&lt;h4&gt;Select&nbsp;Query&nbsp;Face&lt;<span class="js__reg_exp">/h4&gt;&lt;/</span>th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;th&gt;&lt;h4&gt;Detection&nbsp;Result&lt;<span class="js__reg_exp">/h4&gt;&lt;/</span>th&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;width:60%&quot;</span>&nbsp;valign=<span class="js__string">&quot;top&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;form&nbsp;novalidate&nbsp;name=<span class="js__string">&quot;f1&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;input&nbsp;type=<span class="js__string">&quot;file&quot;</span>&nbsp;name=<span class="js__string">&quot;file&quot;</span>&nbsp;accept=<span class="js__string">&quot;image/*&quot;</span>&nbsp;onchange=<span class="js__string">&quot;angular.element(this).scope().selectCandidateFileforUpload(this.files)&quot;</span>&nbsp;required&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/form&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;clearfix&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;loadmore&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;ng-show=<span class="js__string">&quot;loaderMore&quot;</span>&nbsp;ng-class=<span class="js__string">&quot;result&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;src=<span class="js__string">&quot;~/Content/ng-loader.gif&quot;</span>&nbsp;/&gt;&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>faceMessage<span class="js__brace">}</span><span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;clearfix&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;facePreview_thumb_big&quot;</span>&nbsp;id=<span class="js__string">&quot;faceCanvas&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;td&nbsp;style=<span class="js__string">&quot;width:40%&quot;</span>&nbsp;valign=<span class="js__string">&quot;top&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;p&gt;<span class="js__brace">{</span><span class="js__brace">{</span>DetectedResultsMessage<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/p&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;hr&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;clearfix&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;facePreview_thumb_small&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;ng-repeat=<span class="js__string">&quot;item&nbsp;in&nbsp;DetectedFaces&quot;</span>&nbsp;class=<span class="js__string">&quot;col-sm-12&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;col-sm-3&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;img&nbsp;ng-src=<span class="js__string">&quot;{{item.FilePath}}&quot;</span>&nbsp;width=<span class="js__string">&quot;100&quot;</span>&nbsp;/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;col-sm-8&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;@*&lt;li&gt;FaceId:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>item.FaceId<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/li&gt;*@&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;Age:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>item.Age<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;Gender:&nbsp;<span class="js__brace">{</span><span class="js__brace">{</span>item.Gender<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;<span class="js__brace">{</span><span class="js__brace">{</span>item.IsSmiling<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;li&gt;<span class="js__brace">{</span><span class="js__brace">{</span>item.Glasses<span class="js__brace">}</span><span class="js__brace">}</span>&lt;/li&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ul&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;class=<span class="js__string">&quot;clearfix&quot;</span>&gt;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;div&nbsp;ng-hide=<span class="js__string">&quot;DetectedFaces.length&quot;</span>&gt;No&nbsp;face&nbsp;detected!!&lt;/div&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/td&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/tr&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/table&gt;&nbsp;
&lt;/div&gt;&nbsp;
&nbsp;
@section&nbsp;NgScript<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;script&nbsp;src=<span class="js__string">&quot;~/ScriptsNg/FaceDetectionCtrl.js&quot;</span>&gt;&lt;/script&gt;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</strong></div>
</div>
<p>&nbsp;</p>
<p><strong>Angular Controller:</strong></p>
<p><strong>&nbsp;</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><strong><span>JavaScript</span></strong></div>
<div class="pluginLinkHolder"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></div>
<strong><span class="hidden">js</span>
<pre class="hidden">angular.module('myFaceApp', [])
.controller('faceDetectionCtrl', function ($scope, FileUploadService) {

    $scope.Title = 'Microsoft FaceAPI - Face Detection';
    $scope.DetectedResultsMessage = 'No result found!!';
    $scope.SelectedFileForUpload = null;
    $scope.UploadedFiles = [];
    $scope.SimilarFace = [];
    $scope.FaceRectangles = [];
    $scope.DetectedFaces = [];

    //File Select &amp; Save 
    $scope.selectCandidateFileforUpload = function (file) {
        $scope.SelectedFileForUpload = file;
        $scope.loaderMoreupl = true;
        $scope.uplMessage = 'Uploading, please wait....!';
        $scope.result = &quot;color-red&quot;;

        //Save File
        var uploaderUrl = &quot;/FaceDetection/SaveCandidateFiles&quot;;
        var fileSave = FileUploadService.UploadFile($scope.SelectedFileForUpload, uploaderUrl);
        fileSave.then(function (response) {
            if (response.data.Status) {
                $scope.GetDetectedFaces();
                angular.forEach(angular.element(&quot;input[type='file']&quot;), function (inputElem) {
                    angular.element(inputElem).val(null);
                });
                $scope.f1.$setPristine();
                $scope.uplMessage = response.data.Message;
                $scope.loaderMoreupl = false;
            }
        },
        function (error) {
            console.warn(&quot;Error: &quot; &#43; error);
        });
    }

    //Get Detected Faces
    $scope.GetDetectedFaces = function () {
        $scope.loaderMore = true;
        $scope.faceMessage = 'Preparing, detecting faces, please wait....!';
        $scope.result = &quot;color-red&quot;;

        var fileUrl = &quot;/FaceDetection/GetDetectedFaces&quot;;
        var fileView = FileUploadService.GetUploadedFile(fileUrl);
        fileView.then(function (response) {
            $scope.QueryFace = response.data.QueryFaceImage;
            $scope.DetectedResultsMessage = response.data.DetectedResults;
            $scope.DetectedFaces = response.data.FaceInfo;
            $scope.FaceRectangles = response.data.FaceRectangles;
            $scope.loaderMore = false;

            //Reset element
            $('#faceCanvas_img').remove();
            $('.divRectangle_box').remove();

            //get element byID
            var canvas = document.getElementById('faceCanvas');

            //add image element
            var elemImg = document.createElement(&quot;img&quot;);
            elemImg.setAttribute(&quot;src&quot;, $scope.QueryFace);
            elemImg.setAttribute(&quot;width&quot;, response.data.MaxImageSize);
            elemImg.id = 'faceCanvas_img';
            canvas.append(elemImg);

            //Loop with face rectangles
            angular.forEach($scope.FaceRectangles, function (imgs, i) {
                //console.log($scope.DetectedFaces[i])
                //Create rectangle for every face
                var divRectangle = document.createElement('div');
                var width = imgs.Width;
                var height = imgs.Height;
                var top = imgs.Top;
                var left = imgs.Left;

                //Style Div
                divRectangle.className = 'divRectangle_box';
                divRectangle.style.width = width &#43; 'px';
                divRectangle.style.height = height &#43; 'px';
                divRectangle.style.position = 'absolute';
                divRectangle.style.top = top &#43; 'px';
                divRectangle.style.left = left &#43; 'px';
                divRectangle.style.zIndex = '999';
                divRectangle.style.border = '1px solid #fff';
                divRectangle.style.margin = '0';
                divRectangle.id = 'divRectangle_' &#43; (i &#43; 1);

                //Generate rectangles
                canvas.append(divRectangle);
            });
        },
        function (error) {
            console.warn(&quot;Error: &quot; &#43; error);
        });
    };
})
.factory('FileUploadService', function ($http, $q) {
    var fact = {};
    fact.UploadFile = function (files, uploaderUrl) {
        var formData = new FormData();
        angular.forEach(files, function (f, i) {
            formData.append(&quot;file&quot;, files[i]);
        });
        var request = $http({
            method: &quot;post&quot;,
            url: uploaderUrl,
            data: formData,
            withCredentials: true,
            headers: { 'Content-Type': undefined },
            transformRequest: angular.identity
        });
        return request;
    }
    fact.GetUploadedFile = function (fileUrl) {
        return $http.get(fileUrl);
    }
    return fact;
})</pre>
<div class="preview">
<pre class="js">angular.module(<span class="js__string">'myFaceApp'</span>,&nbsp;[])&nbsp;
.controller(<span class="js__string">'faceDetectionCtrl'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($scope,&nbsp;FileUploadService)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.Title&nbsp;=&nbsp;<span class="js__string">'Microsoft&nbsp;FaceAPI&nbsp;-&nbsp;Face&nbsp;Detection'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.DetectedResultsMessage&nbsp;=&nbsp;<span class="js__string">'No&nbsp;result&nbsp;found!!'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.SelectedFileForUpload&nbsp;=&nbsp;null;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.UploadedFiles&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.SimilarFace&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.FaceRectangles&nbsp;=&nbsp;[];&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.DetectedFaces&nbsp;=&nbsp;[];&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//File&nbsp;Select&nbsp;&amp;&nbsp;Save&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.selectCandidateFileforUpload&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(file)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.SelectedFileForUpload&nbsp;=&nbsp;file;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loaderMoreupl&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.uplMessage&nbsp;=&nbsp;<span class="js__string">'Uploading,&nbsp;please&nbsp;wait....!'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.result&nbsp;=&nbsp;<span class="js__string">&quot;color-red&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Save&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;uploaderUrl&nbsp;=&nbsp;<span class="js__string">&quot;/FaceDetection/SaveCandidateFiles&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fileSave&nbsp;=&nbsp;FileUploadService.UploadFile($scope.SelectedFileForUpload,&nbsp;uploaderUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileSave.then(<span class="js__operator">function</span>&nbsp;(response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(response.data.Status)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.GetDetectedFaces();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;angular.forEach(angular.element(<span class="js__string">&quot;input[type='file']&quot;</span>),&nbsp;<span class="js__operator">function</span>&nbsp;(inputElem)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;angular.element(inputElem).val(null);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.f1.$setPristine();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.uplMessage&nbsp;=&nbsp;response.data.Message;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loaderMoreupl&nbsp;=&nbsp;false;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.warn(<span class="js__string">&quot;Error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Get&nbsp;Detected&nbsp;Faces</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;$scope.GetDetectedFaces&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;()&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loaderMore&nbsp;=&nbsp;true;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.faceMessage&nbsp;=&nbsp;<span class="js__string">'Preparing,&nbsp;detecting&nbsp;faces,&nbsp;please&nbsp;wait....!'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.result&nbsp;=&nbsp;<span class="js__string">&quot;color-red&quot;</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fileUrl&nbsp;=&nbsp;<span class="js__string">&quot;/FaceDetection/GetDetectedFaces&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fileView&nbsp;=&nbsp;FileUploadService.GetUploadedFile(fileUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fileView.then(<span class="js__operator">function</span>&nbsp;(response)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.QueryFace&nbsp;=&nbsp;response.data.QueryFaceImage;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.DetectedResultsMessage&nbsp;=&nbsp;response.data.DetectedResults;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.DetectedFaces&nbsp;=&nbsp;response.data.FaceInfo;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.FaceRectangles&nbsp;=&nbsp;response.data.FaceRectangles;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$scope.loaderMore&nbsp;=&nbsp;false;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Reset&nbsp;element</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'#faceCanvas_img'</span>).remove();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$(<span class="js__string">'.divRectangle_box'</span>).remove();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//get&nbsp;element&nbsp;byID</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;canvas&nbsp;=&nbsp;document.getElementById(<span class="js__string">'faceCanvas'</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//add&nbsp;image&nbsp;element</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;elemImg&nbsp;=&nbsp;document.createElement(<span class="js__string">&quot;img&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elemImg.setAttribute(<span class="js__string">&quot;src&quot;</span>,&nbsp;$scope.QueryFace);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elemImg.setAttribute(<span class="js__string">&quot;width&quot;</span>,&nbsp;response.data.MaxImageSize);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;elemImg.id&nbsp;=&nbsp;<span class="js__string">'faceCanvas_img'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.append(elemImg);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Loop&nbsp;with&nbsp;face&nbsp;rectangles</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;angular.forEach($scope.FaceRectangles,&nbsp;<span class="js__operator">function</span>&nbsp;(imgs,&nbsp;i)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//console.log($scope.DetectedFaces[i])</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Create&nbsp;rectangle&nbsp;for&nbsp;every&nbsp;face</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;divRectangle&nbsp;=&nbsp;document.createElement(<span class="js__string">'div'</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;width&nbsp;=&nbsp;imgs.Width;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;height&nbsp;=&nbsp;imgs.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;top&nbsp;=&nbsp;imgs.Top;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;left&nbsp;=&nbsp;imgs.Left;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Style&nbsp;Div</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.className&nbsp;=&nbsp;<span class="js__string">'divRectangle_box'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.width&nbsp;=&nbsp;width&nbsp;&#43;&nbsp;<span class="js__string">'px'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.height&nbsp;=&nbsp;height&nbsp;&#43;&nbsp;<span class="js__string">'px'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.position&nbsp;=&nbsp;<span class="js__string">'absolute'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.top&nbsp;=&nbsp;top&nbsp;&#43;&nbsp;<span class="js__string">'px'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.left&nbsp;=&nbsp;left&nbsp;&#43;&nbsp;<span class="js__string">'px'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.zIndex&nbsp;=&nbsp;<span class="js__string">'999'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.border&nbsp;=&nbsp;<span class="js__string">'1px&nbsp;solid&nbsp;#fff'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.style.margin&nbsp;=&nbsp;<span class="js__string">'0'</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;divRectangle.id&nbsp;=&nbsp;<span class="js__string">'divRectangle_'</span>&nbsp;&#43;&nbsp;(i&nbsp;&#43;&nbsp;<span class="js__num">1</span>);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Generate&nbsp;rectangles</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.append(divRectangle);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">function</span>&nbsp;(error)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;console.warn(<span class="js__string">&quot;Error:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;error);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
<span class="js__brace">}</span>)&nbsp;
.factory(<span class="js__string">'FileUploadService'</span>,&nbsp;<span class="js__operator">function</span>&nbsp;($http,&nbsp;$q)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;fact&nbsp;=&nbsp;<span class="js__brace">{</span><span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fact.UploadFile&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(files,&nbsp;uploaderUrl)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;formData&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;FormData();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;angular.forEach(files,&nbsp;<span class="js__operator">function</span>&nbsp;(f,&nbsp;i)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;formData.append(<span class="js__string">&quot;file&quot;</span>,&nbsp;files[i]);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;request&nbsp;=&nbsp;$http(<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;method:&nbsp;<span class="js__string">&quot;post&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;url:&nbsp;uploaderUrl,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;data:&nbsp;formData,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;withCredentials:&nbsp;true,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;headers:&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__string">'Content-Type'</span>:&nbsp;<span class="js__property">undefined</span>&nbsp;<span class="js__brace">}</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;transformRequest:&nbsp;angular.identity&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;request;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;fact.GetUploadedFile&nbsp;=&nbsp;<span class="js__operator">function</span>&nbsp;(fileUrl)&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;$http.get(fileUrl);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;fact;&nbsp;
<span class="js__brace">}</span>)</pre>
</div>
</strong></div>
</div>
<p>&nbsp;</p>
<h3><strong>Upload images to detect faces:</strong></h3>
<p>Browse Image from local folder to upload and detect faces.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_11.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3813" src="-fapi_11.png" alt=""></a></p>
<h3><strong>Mark faces in the image:</strong></h3>
<p>Detected faces will mark with white rectangle.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_9.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3798" src="-fapi_9.png" alt="" width="503" height="533"></a></p>
<h3><strong>List detected faces with face information:</strong></h3>
<p>List and&nbsp;Separate&nbsp;the faces with detailed&nbsp;face information.</p>
<p><a href="http://shashangka.com/wp-content/uploads/2017/01/fapi_10.png"><img class="alignnone size-full x_x_x_x_x_x_wp-image-3799" src="-fapi_10.png" alt="" width="483" height="425"></a></p>
<h3><strong>Summary:</strong></h3>
<p>You have just seen how to call Face API to detect faces in an Image. Hope this will help to make application more smart and intelligent&nbsp;🙂.</p>
<p><strong>References:</strong></p>
<ul>
<li><a href="https://www.microsoft.com/cognitive-services/en-us/face-api/documentation/get-started-with-face-api/GettingStartedwithFaceAPIinCSharp">https://www.microsoft.com/cognitive-services/en-us/face-api/documentation/get-started-with-face-api/GettingStartedwithFaceAPIinCSharp</a>
</li><li><a href="https://www.microsoft.com/cognitive-services/en-us/face-api">https://www.microsoft.com/cognitive-services/en-us/face-api</a>
</li><li><a href="https://staging.www.projectoxford.ai/">https://staging.www.projectoxford.ai</a>
</li><li><a href="https://github.com/ShashangkaShekhar/ProjectOxford-ClientSDK">https://github.com/ShashangkaShekhar/ProjectOxford-ClientSDK</a>
</li></ul>
