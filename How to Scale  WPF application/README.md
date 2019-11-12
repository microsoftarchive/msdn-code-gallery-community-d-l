# How to Scale  WPF application
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- WPF
- Scale
## Topics
- WPF
- Rapid Application Development
## Updated
- 01/14/2017
## Description

<h1>Introduction</h1>
<p>If you/user has high-definition display resolutions (HD, 2K, 4K,&hellip;) you need to scale your application.&nbsp;</p>
<p>Usually, you change the display setting (125%, 150%, 200%...).</p>
<p>I think the best way to add needed behavior in your application &hellip;</p>
<p>WPF Windows application itself does not have Scaling Properties.</p>
<p>You can scale Grid, Canvas, etc&hellip; but not Application itself... Let windows doing scaling your application with minimum coding &nbsp;&hellip;</p>
<p>The easiest way to size correctly WPF application is wrapping all your users control inside MAIN user control and using MAIN user control in Window Application.</p>
<p>100%</p>
<p><img id="156842" src="156842-1.png" alt="" width="350" height="250"></p>
<p>200%</p>
<p><img id="156844" src="156844-2.png" alt="" width="350" height="250"></p>
<p>50%</p>
<p><img id="156845" src="156845-3.png" alt="" width="350" height="250"></p>
<h1>Building the Sample</h1>
<p>Make sure that your MAIN UserControl does not assign Width and Height &hellip;</p>
<p>Use only MinWidth and MinHeight &nbsp;</p>
<p><img id="156846" src="156846-4.png" alt="" width="500" height="70"></p>
<p>Do not use <strong>RenderingTransfer,</strong> it will scale User Control inside window &ndash; we need to have different behavior &hellip;</p>
<p>&nbsp;</p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp; </span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">UserControl.RenderTransform</span><span style="text-decoration:line-through">&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">TransformGroup</span><span style="text-decoration:line-through">&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">ScaleTransform</span><span style="text-decoration:line-through"> x</span><span style="text-decoration:line-through">:</span><span style="text-decoration:line-through">Name</span><span style="text-decoration:line-through">=&quot;trScale&quot;</span><span style="text-decoration:line-through">
 ScaleX</span><span style="text-decoration:line-through">=&quot;1.0&quot;</span><span style="text-decoration:line-through"> ScaleY</span><span style="text-decoration:line-through">=&quot;1.0&quot;/&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">SkewTransform</span><span style="text-decoration:line-through">/&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">RotateTransform</span><span style="text-decoration:line-through">/&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;</span><span style="text-decoration:line-through">TranslateTransform</span><span style="text-decoration:line-through">/&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</span><span style="text-decoration:line-through">&lt;/</span><span style="text-decoration:line-through">TransformGroup</span><span style="text-decoration:line-through">&gt;</span></p>
<p><span style="text-decoration:line-through">&nbsp;&nbsp;&nbsp; </span><span style="text-decoration:line-through">&lt;/</span><span style="text-decoration:line-through">UserControl.RenderTransform</span><span style="text-decoration:line-through">&gt;</span></p>
<p>&nbsp;</p>
<p><strong>Use Layout Transfer&nbsp;</strong></p>
<p>&nbsp;&nbsp; &lt;UserControl.LayoutTransform&gt;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ScaleTransform x:Name=&quot;ucScale&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;ScaleX=&quot;1.0&quot;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;ScaleY=&quot;1.0&quot; /&gt;</p>
<p>&nbsp;&nbsp;&nbsp; &lt;/UserControl.LayoutTransform&gt;</p>
<div class="scriptcode">
<div class="pluginEditHolder">
<div class="title"><span>C#</span><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">xaml</span>


<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Navigation.aspx" target="_blank" title="Auto generated link to System.Windows.Navigation">System.Windows.Navigation</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Shapes.aspx" target="_blank" title="Auto generated link to System.Windows.Shapes">System.Windows.Shapes</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;wpfScalingEntireApplication&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;Interaction&nbsp;logic&nbsp;for&nbsp;CommonUserControl.xaml</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">///&nbsp;&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;CommonUserControl&nbsp;:&nbsp;UserControl&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;CommonUserControl()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Slider_ValueChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedPropertyChangedEventArgs&lt;<span class="cs__keyword">double</span>&gt;&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(ucScale&nbsp;!=&nbsp;<span class="cs__keyword">null</span>&nbsp;&amp;&amp;&nbsp;slider&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;exclude&nbsp;of&nbsp;exception&nbsp;during&nbsp;LOAD&nbsp;...</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ucScale.ScaleX&nbsp;=&nbsp;slider.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ucScale.ScaleY&nbsp;=&nbsp;slider.Value;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
