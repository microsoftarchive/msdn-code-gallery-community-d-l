# Drawing on a Canvas with C#/XAML in a Windows Store App
## Requires
- Visual Studio 2012
## License
- Apache License, Version 2.0
## Technologies
- C#
- XAML
- Windows Store
- Windows Store app
## Topics
- Drawing
- Gestures
## Updated
- 04/16/2013
## Description

<h1>Introduction</h1>
<p><em>This code sample will allow you to give the user the ability to draw anything on the screen .</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>You need to have Windows 8 and Visual Studio 2012 installed on your PC in order to run this .</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This sample gives the user a new way in the ' Touch And Feel ' in Windows 8 . This app will make the user able to draw anything he wants on the screen , this code sample is very useful for many apps like games , I've developped a game for children named
 'MyAbc' to teach kids alphabets in 3 languages using this method . Besides the drawing with finger on a screen makes the app valuable . You still can add an app bar into the app and add buttons such as Recognize , Save or Erase , these buttons will add functionalities
 to the app and make it more powerful . There are three events that make the pointer works . We'll handle&nbsp;PointerReleased ,&nbsp;PointerMoved ,&nbsp;PointerPressed and each event will handle some code to let the user write using that pointer.</em></p>
<p><em>Here's a screen shot of this code sample running .</em></p>
<p><em><img id="79913" src="79913-sample.png" alt="" width="692" height="442">&nbsp;</em></p>
<p><em>Here's another screen shot , this one is from the app that I've developped using this method for kids to teach them alphabets .</em></p>
<p><img id="79917" src="79917-capture.png" alt=""></p>
<p><em><br>
</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">    public MainPage()
        {
            this.InitializeComponent();

            MyCanvas.PointerPressed &#43;= new PointerEventHandler(MyCanvas_PointerPressed);
            MyCanvas.PointerMoved &#43;= new PointerEventHandler(MyCanvas_PointerMoved);
            MyCanvas.PointerReleased &#43;= new PointerEventHandler(MyCanvas_PointerReleased);
            MyCanvas.PointerExited &#43;= new PointerEventHandler(MyCanvas_PointerReleased);
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyCanvas.PointerPressed&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointerEventHandler(MyCanvas_PointerPressed);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyCanvas.PointerMoved&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointerEventHandler(MyCanvas_PointerMoved);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyCanvas.PointerReleased&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointerEventHandler(MyCanvas_PointerReleased);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyCanvas.PointerExited&nbsp;&#43;=&nbsp;<span class="cs__keyword">new</span>&nbsp;PointerEventHandler(MyCanvas_PointerReleased);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainPage.xaml #1 - contains the canvas in the XAML code .</em> </li><li><em><em>MainPage.xaml.cs #2 -contains all the code behind and the events for the pointer .</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information feel free to contact me on khaled.jemni@studentpartner.com or mention me in Twitter @khaledjemni&nbsp;</em></p>
