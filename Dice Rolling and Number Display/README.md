# Dice Rolling and Number Display
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- WPF Basics
- WPF Data Binding
- WPF Commanding
- WPF CustomControl
- XAML Control Templates
- WPF Path XAML ResourceDictionary Cogweel
## Updated
- 06/09/2012
## Description

<p>Hello <a href="http://webeasyforall.blogspot.com/" target="_blank">Guys</a>, Today I&rsquo;m gonna show you how to make a dice rolling control for Ludo, snake ladder etc in
<a href="http://webeasyforall.blogspot.com/" target="_blank">wpf(Windows presentation foundation)</a>, so let&rsquo;s get started, open a new project of wpf give it to a name say DiceRoll, before moving further let me tell you those which are required for Dice
 rolling control, a button, on its click event it will generate numbers(Integers) randomly, and a
<a href="http://webeasyforall.blogspot.com/" target="_blank">textblock</a> which will show a generated number(integer), and a<a href="http://webeasyforall.blogspot.com/" target="_blank"> image
</a>control, which will show the<a href="http://webeasyforall.blogspot.com/" target="_blank"> Dice face</a>, from toolbox, just drag and drop the button, and change its content to Roll a Dice, Drop a text block &nbsp;control, remove its text, and drag and drop
 image control in your main window, now on click event of <a href="http://webeasyforall.blogspot.com/" target="_blank">
button(Roll a Dice)</a> create an object of class Random, here is the code <a href="http://webeasyforall.blogspot.com/" target="_blank">
(C#)</a> :</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;num&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>To<a href="http://webeasyforall.blogspot.com/" target="_blank"> generate</a> number(Integers)
<a href="http://webeasyforall.blogspot.com/" target="_blank">randomly</a>, you just declare an integer say Number so in the next line of the same method<a href="http://webeasyforall.blogspot.com/" target="_blank">(button1_Click)</a>, so now the code is like
 this,</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;num&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Number&nbsp;=&nbsp;num.Next(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">7</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><a href="http://webeasyforall.blogspot.com/" target="_blank">Num.Next(Int ,int )</a> non-static method takes two
<a href="http://webeasyforall.blogspot.com/" target="_blank">parameters</a>, first one parameter is the starting point, and second point is the End point, here I have used 1 and 7, it will generate 1 to 6 integers, 7 number is excluding, now to show the generated
 number(Integers) on the text box I have added a line :</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;num&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Number&nbsp;=&nbsp;num.Next(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">7</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Text&nbsp;=&nbsp;Number.ToString()&#43;<span class="cs__string">&quot;&nbsp;Number&quot;</span>;&nbsp;
&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>So When will you click on button<a href="http://webeasyforall.blogspot.com/" target="_blank">(Roll a Dice)</a> it will start showing random number, now the main portion is to show image(DiceFace), I have used BitmapImage class, I have added 6 images, and
 placed these images into Dicefaces, I have created an instance of BitmapImage class, and its
<a href="http://webeasyforall.blogspot.com/" target="_blank">constructor</a> I set up the URI, and and URIKind, and image source is set to<a href="http://webeasyforall.blogspot.com/" target="_blank"> BitmapImage</a>&rsquo;s instance, here is the code :</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span><span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;num&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Number&nbsp;=&nbsp;num.Next(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">7</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitmapImage&nbsp;Img&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BitmapImage(<span class="cs__keyword">new</span>&nbsp;Uri(@<span class="cs__string">&quot;DiceFaces\&quot;&#43;Number.ToString()&#43;&quot;</span>.png&quot;,UriKind.Relative));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Text&nbsp;=&nbsp;Number.ToString()&#43;<span class="cs__string">&quot;&nbsp;Number&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image1.Source&nbsp;=&nbsp;Img;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p><strong>Screen Shot</strong></p>
<p><strong><a href="http://webeasyforall.blogspot.com/" target="_blank"><img id="59593" src="59593-11.png" alt="" width="526" height="351"></a><br>
</strong></p>
<p>I hope you have enjoyed it, thank you all, and feel free to ask questions,&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">namespace</span>&nbsp;diceRoll&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Interaction&nbsp;logic&nbsp;for&nbsp;MainWindow.xaml</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;MainWindow&nbsp;:&nbsp;Window&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Random&nbsp;num&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Random();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;Number&nbsp;=&nbsp;num.Next(<span class="cs__number">1</span>,&nbsp;<span class="cs__number">7</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BitmapImage&nbsp;Img&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;BitmapImage(<span class="cs__keyword">new</span>&nbsp;Uri(@<span class="cs__string">&quot;DiceFaces\&quot;&#43;Number.ToString()&#43;&quot;</span>.png&quot;,UriKind.Relative));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Text&nbsp;=&nbsp;Number.ToString()&#43;<span class="cs__string">&quot;&nbsp;Number&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;image1.Source&nbsp;=&nbsp;Img;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
