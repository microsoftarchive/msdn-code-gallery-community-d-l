# Finding the faces in images in ASP.NET web application
## Requires
- Visual Studio 2015
## License
- MS-LPL
## Technologies
- ASP.NET
- EmGU CV
## Topics
- Image Processing
- Desktop and Web apps development
## Updated
- 08/16/2016
## Description

<h1>Introduction</h1>
<p><em>In this ASP.NET web application based project I have shown how you can process the images uploaded by the users to process them and find the faces. After finding the faces, how you can map their locations in the images for the users to see where faces
 were found.&nbsp;</em></p>
<p><em>This is a full featured project and can be used in your own applications. I haven't created a GitHub project repositiry, but will do that sooner. So that you can get the templated version of this project for your own projects and applications.&nbsp;</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>I used ASP.NET 4 (MVC 5) for this application development process. Visual Studio 2015 Enterprise edition was used. Other editions and versions would also work in this case.&nbsp;</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>The default code that is used in the project is the following, this code does the maximum work, of finding the faces. Rest of the job is done using JavaScript on the client-side.</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__com">//&nbsp;Face&nbsp;detector&nbsp;helper&nbsp;object</span>&nbsp;
<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;FaceDetector&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;List&lt;Rectangle&gt;&nbsp;DetectFaces(Mat&nbsp;image)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;List&lt;Rectangle&gt;&nbsp;faces&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;List&lt;Rectangle&gt;();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;facesCascade&nbsp;=&nbsp;HttpContext.Current.Server.MapPath(<span class="cs__string">&quot;~/haarcascade_frontalface_default.xml&quot;</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(CascadeClassifier&nbsp;face&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;CascadeClassifier(facesCascade))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">using</span>&nbsp;(UMat&nbsp;ugray&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UMat())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CvInvoke.CvtColor(image,&nbsp;ugray,&nbsp;Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//normalizes&nbsp;brightness&nbsp;and&nbsp;increases&nbsp;contrast&nbsp;of&nbsp;the&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CvInvoke.EqualizeHist(ugray,&nbsp;ugray);&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Detect&nbsp;the&nbsp;faces&nbsp;from&nbsp;the&nbsp;gray&nbsp;scale&nbsp;image&nbsp;and&nbsp;store&nbsp;the&nbsp;locations&nbsp;as&nbsp;rectangle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;first&nbsp;dimensional&nbsp;is&nbsp;the&nbsp;channel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//The&nbsp;second&nbsp;dimension&nbsp;is&nbsp;the&nbsp;index&nbsp;of&nbsp;the&nbsp;rectangle&nbsp;in&nbsp;the&nbsp;specific&nbsp;channel</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rectangle[]&nbsp;facesDetected&nbsp;=&nbsp;face.DetectMultiScale(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ugray,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">1.1</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__number">10</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;Size(<span class="cs__number">20</span>,&nbsp;<span class="cs__number">20</span>));&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;faces.AddRange(facesDetected);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;faces;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;Note that the above code snippet requires Emgu CV helpers to be installed before you can call the above code. The rest of the code can be viewed in the sample itself. Download and try it out yourself.</div>
</em>
<p></p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>FindFacesController.cs - This file contains the controller and actions code that processes the images on the server-side once the user has uploaded them. It also contains the helper objects such as Location and FaceDetector object.</em>
</li><li><em><em>Views / FindFaces / Index.cshtml - This file is the view for the project and is used to render the HTML content. It has an HTML form by default and later would show the results of the images that are processed.&nbsp;</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information and a guide to learn about this, please read the following article of mine,&nbsp;<a href="https://basicsofwebdevelopment.wordpress.com/2016/08/17/highlighting-the-faces-in-uploaded-image-in-asp-net-web-applications/">Highlighting
 the faces in uploaded image in ASP.NET web applications</a>.</em></p>
