# HTML5 Drag and drop sample
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- HTML5
- Internet Explorer 10
## Topics
- Drag and Drop
## Updated
- 05/22/2014
## Description

<div><a href="http://samples.msdn.microsoft.com/iedevcenter/DragAndDrop/default.html" style="text-decoration:none">
<div style="background:#ff8c00; color:white; width:100px; padding:5px 15px; margin:15px 0; line-height:135%; font-family:inherit; font-size:1.1em; text-decoration:none">
View sample</div>
</a></div>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>The drag and drop sample contains four code examples&nbsp;to show&nbsp;how the&nbsp;draggable attribute helps you create fully drag and drop enabled web applications. The sample builds the process of creating a draggable element, acting on the element being
 dragged, acting on the areas being dragged over, and finally how to filter and capture dropped elements on an area.</p>
<p>Drag and drop is a second nature to almost every computer user. Whether it's editing text, filling in forms, or arranging photographs, one of the first skills computer users learn is to select and drag an element with their mouse.</p>
<p>Previously on the web, drag and drop has been limited to copy and pasting text, and dragging links. With the HTML5 draggable attribute, any element on a webpage can be dragged. Using existing JavaScript events, you can create drop areas to consume these
 dragged elements.<br>
<br>
The <strong>Enabling draggable elements</strong> example shows the basic draggable attribute. Several draggable &lt;div&gt; and link&nbsp;elements are shown that can be dragged, while&nbsp;an image is not. &nbsp;</p>
<p><br>
The syntax for the draggable element is:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>HTML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">html</span>

<div class="preview">
<pre class="js">&lt;div&nbsp;draggable=<span class="js__string">&quot;true&quot;</span>&gt;This&nbsp;element&nbsp;is&nbsp;draggable&nbsp;&lt;/div&gt;</pre>
</div>
</div>
</div>
<p><span>The <strong>Acting on the element being dragged</strong> example shows how elements can react to three different events, dragstart, drag, and dragend. In this example, the elements being dragged are acting on the events.
<br>
<br>
The <strong>Acting on the area being dragged over </strong>example shows how elements can act on other elements being dragged over them. The code shows how a &lt;div&gt; element can handle the dragenter, dragover, or dragleave events as an image is dragged
 over them. </span></p>
<p><span>The <strong>Putting it all together example</strong> shows using the dataTransfer object from&nbsp;a drag event to&nbsp;drag and drop a shape into it's associated destination. The example shows how you can use the element ID with the dataTransfer object
 to filter whether the object&nbsp;being dragged goes with the area being dropped onto. &nbsp;</span></p>
<h1>See also</h1>
<p><strong>Reference</strong><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/hh772927(v=vs.85).aspx" target="_blank">draggable attribute</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536928(v=vs.85).aspx" target="_blank">ondragstart event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536923(v=vs.85).aspx" target="_blank">ondrag event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536924(v=vs.85).aspx" target="_blank">ondragend event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536925(v=vs.85).aspx" target="_blank">ondragenter event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536926(v=vs.85).aspx" target="_blank">ondragleave event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536927(v=vs.85).aspx" target="_blank">ondragover event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms536929(v=vs.85).aspx" target="_blank">ondrop event</a><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/ms535861(v=vs.85).aspx" target="_blank">dataTransfer object</a><br>
<br>
<strong>Conceptual</strong><br>
<a href="http://msdn.microsoft.com/en-us/library/ie/hh673539(v=vs.85).aspx" target="_blank">Internet Explorer 10 Developer Guide: HTML5 Drag and drop</a><br>
<br>
<strong>Internet Explorer Test Drive</strong><br>
<a href="http://ie.microsoft.com/testdrive/Graphics/MagneticPoetry/Default.html" target="_blank">Magnetic poetry</a><br>
<br>
<strong>IEBlog</strong><br>
<a href="http://blogs.msdn.com/b/ie/archive/2011/07/27/html5-drag-and-drop-in-ie10-ppb2.aspx" target="_blank">HTML5 Drag and drop in IE10</a><br>
<br>
<strong>Internet Explorer Testing Center</strong><br>
<a href="http://samples.msdn.microsoft.com/ietestcenter/#html5DragandDrop" target="_blank">Drag and drop</a></p>
<h1>Further information</h1>
<p>The Internet Explorer Samples Gallery contains a variety of code samples that demonstrate new features available in Internet Explorer. These downloadable samples are provided as compressed ZIP files that contain the HTML, JavaScript, CSS, and image resources
 for the sample, along with the license agreement and sample description metadata. After you&rsquo;ve downloaded and unzipped the compressed files, the sample files can be found in the following location:</p>
<p style="padding-left:30px">(unzipped folder)\HTML,JavaScript\Website \<strong>(Sample)</strong></p>
<p>This sample is provided as-is in order to indicate or demonstrate the functionality of the feature APIs for Internet Explorer&nbsp;10. We appreciate your comments and questions on this sample!</p>
<p>For download info, visit <a href="http://msdn.microsoft.com/en-us/ie/aa740471.aspx">
Internet Explorer downloads</a>.</p>
