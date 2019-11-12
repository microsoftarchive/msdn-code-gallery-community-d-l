# Fade animation using WPF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- Animations
## Topics
- WPF Animation
## Updated
- 09/23/2012
## Description

<h1>Introduction</h1>
<p><em>This is a sample based on animation libraries of WPF. Here we'll mainly focus on the fade animations under WPF.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Fade is a particular type of animation used by the mouse entering or leaving property.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>&nbsp;First of all, you need to include '<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Animation.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Animation">System.Windows.Media.Animation</a>'.</p>
<p>Then we'll use the fade animation when the mouse leaves the area or reappears when mouse enters the area.</p>
<p>It can either be a canvas, or an ellipse or any geometrical shape even a grid.</p>
<p>&nbsp;</p>
<p><em>Code for entering mouse :</em></p>
<pre><span>private</span>&nbsp;<span>void</span>&nbsp;canvas1_MouseEnter(<span>object</span>&nbsp;sender,&nbsp;<span>MouseEventArgs</span>&nbsp;e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>Canvas</span>&nbsp;c&nbsp;=&nbsp;(<span>Canvas</span>)sender;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>DoubleAnimation</span>&nbsp;animation&nbsp;=&nbsp;<span>new</span>&nbsp;<span>DoubleAnimation</span>(2,&nbsp;<span>TimeSpan</span>.FromSeconds(5));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.BeginAnimation(<span>Canvas</span>.OpacityProperty,&nbsp;animation);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Visibility&nbsp;=&nbsp;<span>Visibility</span>.Hidden;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock2.Visibility&nbsp;=&nbsp;<span>Visibility</span>.Visible;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
<pre><em>Code for leaving mouse :</em></pre>
<pre><pre><span>private</span>&nbsp;<span>void</span>&nbsp;canvas1_MouseLeave(<span>object</span>&nbsp;sender,&nbsp;<span>MouseEventArgs</span>&nbsp;e)
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>Canvas</span>&nbsp;c&nbsp;=&nbsp;(<span>Canvas</span>)sender;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>DoubleAnimation</span>&nbsp;animation&nbsp;=&nbsp;<span>new</span>&nbsp;<span>DoubleAnimation</span>(0,&nbsp;<span>TimeSpan</span>.FromSeconds(5));
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.BeginAnimation(<span>Canvas</span>.OpacityProperty,animation);
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock2.Visibility&nbsp;=&nbsp;<span>Visibility</span>.Hidden;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Visibility&nbsp;=&nbsp;<span>Visibility</span>.Visible;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
<pre>Here we create objects Canvas and animations and then apply properties.</pre>
<br></pre>
<p><em><br>
</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Linq.aspx" target="_blank" title="Auto generated link to System.Linq">System.Linq</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Text.aspx" target="_blank" title="Auto generated link to System.Text">System.Text</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.aspx" target="_blank" title="Auto generated link to System.Windows">System.Windows</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Controls.aspx" target="_blank" title="Auto generated link to System.Windows.Controls">System.Windows.Controls</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Data.aspx" target="_blank" title="Auto generated link to System.Windows.Data">System.Windows.Data</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Documents.aspx" target="_blank" title="Auto generated link to System.Windows.Documents">System.Windows.Documents</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Input.aspx" target="_blank" title="Auto generated link to System.Windows.Input">System.Windows.Input</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.aspx" target="_blank" title="Auto generated link to System.Windows.Media">System.Windows.Media</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Imaging.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Imaging">System.Windows.Media.Imaging</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Navigation.aspx" target="_blank" title="Auto generated link to System.Windows.Navigation">System.Windows.Navigation</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Shapes.aspx" target="_blank" title="Auto generated link to System.Windows.Shapes">System.Windows.Shapes</a>;&nbsp;
<span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Media.Animation.aspx" target="_blank" title="Auto generated link to System.Windows.Media.Animation">System.Windows.Media.Animation</a>;&nbsp;
&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;Animation&nbsp;
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
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;canvas1_MouseLeave(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Canvas&nbsp;c&nbsp;=&nbsp;(Canvas)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">0</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.BeginAnimation(Canvas.OpacityProperty,animation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock2.Visibility&nbsp;=&nbsp;Visibility.Hidden;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Visibility&nbsp;=&nbsp;Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;canvas1_MouseEnter(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Canvas&nbsp;c&nbsp;=&nbsp;(Canvas)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">2</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;c.BeginAnimation(Canvas.OpacityProperty,&nbsp;animation);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock1.Visibility&nbsp;=&nbsp;Visibility.Hidden;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock2.Visibility&nbsp;=&nbsp;Visibility.Visible;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ellipse1_MouseEnter(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ellipse&nbsp;e1&nbsp;=&nbsp;(Ellipse)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">2</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e1.BeginAnimation(Ellipse.OpacityProperty,&nbsp;animation1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ellipse1_MouseLeave(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ellipse&nbsp;e1&nbsp;=&nbsp;(Ellipse)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation1&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">0</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e1.BeginAnimation(Ellipse.OpacityProperty,&nbsp;animation1);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ellipse2_MouseEnter(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ellipse&nbsp;e2&nbsp;=&nbsp;(Ellipse)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">2</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e2.BeginAnimation(Ellipse.OpacityProperty,&nbsp;animation2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ellipse2_MouseLeave(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;MouseEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ellipse&nbsp;e2&nbsp;=&nbsp;(Ellipse)sender;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoubleAnimation&nbsp;animation2&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;DoubleAnimation(<span class="cs__number">0</span>,&nbsp;TimeSpan.FromSeconds(<span class="cs__number">5</span>));&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;e2.BeginAnimation(Ellipse.OpacityProperty,&nbsp;animation2);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;button1_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;textBlock8.Text&nbsp;=&nbsp;<span class="cs__string">&quot;34376&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;private&nbsp;void&nbsp;ellipse2_MouseLeftButtonDown(object&nbsp;sender,&nbsp;MouseButtonEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ellipse2.Opacity&nbsp;=&nbsp;1;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}*/</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><a id="67135" href="/windowsdesktop/site/view/file/67135/1/App.xaml.csharp">App.xaml.cs</a>
</li><li><em><em><a id="67136" href="/windowsdesktop/site/view/file/67136/1/MainWindow.xaml.csharp">MainWindow.xaml.cs</a></em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information , visit&nbsp;<a href="http://bitsandbinaries.wordpress.com/">http://bitsandbinaries.wordpress.com/</a></em></p>
