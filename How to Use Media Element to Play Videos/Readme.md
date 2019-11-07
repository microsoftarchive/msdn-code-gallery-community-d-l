# How to: Use Media Element to Play Videos
## Requires
- Visual Studio 2012
## License
- MS-LPL
## Technologies
- WPF
## Topics
- WPF
## Updated
- 09/25/2013
## Description

<h1>Introduction</h1>
<div><em>In WPF, we can use <a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement.aspx">
Media Element </a>to play videos.</em></div>
<h1><span>Building the Sample</span></h1>
<div><em>Development tool: Visual Studio 2012</em></div>
<div><span style="font-size:20px; font-weight:bold">Description</span></div>
<div><em>In this sample, we will see how to use Media Element in WPF and we<br>
will explore some of the basic functionalities such as Play, Pause, Stop, Back<br>
and Forward. It is just for beginner.</em></div>
<div><br>
<br>
<em>1.Create a WPF application. We named this project WpfMeidaPlayer<img id="97066" src="97066-untitled.png" alt="" width="800" height="478"></em></div>
<div>&nbsp;</div>
<div>2. We will add a MediaEelement, add 5 buttons to the Main Windows. Somthing looks like,</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid&gt;
	&lt;Grid.RowDefinitions&gt;
		&lt;RowDefinition Height=&quot;320*&quot;/&gt;
		&lt;RowDefinition Height=&quot;50*&quot;/&gt;
	&lt;/Grid.RowDefinitions&gt;
	&lt;MediaElement x:Name=&quot;MediaPlayer&quot; Grid.RowSpan=&quot;1&quot; LoadedBehavior=&quot;Manual&quot;/&gt;
	&lt;StackPanel Orientation=&quot;Horizontal&quot; Grid.Row=&quot;1&quot; HorizontalAlignment=&quot;Center&quot;&gt;
		&lt;Button x:Name=&quot;btnPlay&quot; Content=&quot;Play&quot; Click=&quot;btnPlay_Click&quot; Width=&quot;50&quot; Height=&quot;25&quot; Margin=&quot;5&quot;/&gt;
		&lt;Button x:Name=&quot;btnStop&quot; Content=&quot;Stop&quot; Click=&quot;btnStop_Click&quot; Width=&quot;50&quot; Height=&quot;25&quot; Margin=&quot;5&quot;/&gt;
		&lt;Button x:Name=&quot;btnMoveBack&quot; Content=&quot;Back&quot; Click=&quot;btnMoveBack_Click&quot; Width=&quot;50&quot; Height=&quot;25&quot; Margin=&quot;5&quot;/&gt;
		&lt;Button x:Name=&quot;btnMoveForward&quot; Content=&quot;Forward&quot; Click=&quot;btnMoveForward_Click&quot; Width=&quot;50&quot; Height=&quot;25&quot; Margin=&quot;5&quot;/&gt;
		&lt;Button x:Name=&quot;btnOpen&quot; Content=&quot;Open&quot; Click=&quot;btnOpen_Click&quot; Width=&quot;50&quot; Height=&quot;25&quot; Margin=&quot;5&quot;/&gt;
	&lt;/StackPanel&gt;
&lt;/Grid&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;320*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;50*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;MediaElement</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;MediaPlayer&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">RowSpan</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">LoadedBehavior</span>=<span class="xaml__attr_value">&quot;Manual&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnPlay&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Play&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnPlay_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnStop&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Stop&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnStop_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnMoveBack&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Back&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnMoveBack_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnMoveForward&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Forward&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnMoveForward_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;btnOpen&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Open&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;btnOpen_Click&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;50&quot;</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;25&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;5&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
<div>3. We will begin to achieve the Play,Stop... funtions, something looks like,</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">public MainWindow()
{
	InitializeComponent();
	IsPlaying(false);
}

private void IsPlaying(bool flag)
{
	btnPlay.IsEnabled = flag;
	btnStop.IsEnabled = flag;
	btnMoveBack.IsEnabled = flag;
	btnMoveForward.IsEnabled = flag;
}

private void btnPlay_Click(object sender, RoutedEventArgs e)
{
	IsPlaying(true);
	if (btnPlay.Content.ToString() == &quot;Play&quot;)
	{
		MediaPlayer.Play();
		btnPlay.Content = &quot;Pause&quot;;
	}
	else
	{
		MediaPlayer.Pause();
		btnPlay.Content = &quot;Play&quot;;
	}
}

private void btnStop_Click(object sender, RoutedEventArgs e)
{
	MediaPlayer.Pause();
	btnPlay.Content = &quot;Play&quot;;
	IsPlaying(false);
	btnPlay.IsEnabled = true;
}

private void btnMoveBack_Click(object sender, RoutedEventArgs e)
{
	MediaPlayer.Position -= TimeSpan.FromSeconds(10);
}

private void btnMoveForward_Click(object sender, RoutedEventArgs e)
{
	MediaPlayer.Position &#43;= TimeSpan.FromSeconds(10);
}

private void btnOpen_Click(object sender, RoutedEventArgs e)
{
	// Configure open file dialog box
	Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
	dialog.FileName = &quot;Videos&quot;; // Default file name
	dialog.DefaultExt = &quot;.WMV&quot;; // Default file extension
	dialog.Filter = &quot;WMV file (.wm)|*.wmv&quot;; // Filter files by extension 

	// Show open file dialog box
	Nullable&lt;bool&gt; result = dialog.ShowDialog();

	// Process open file dialog box results 
	if (result == true)
	{
		// Open document 
		MediaPlayer.Source = new Uri(dialog.FileName);
		btnPlay.IsEnabled = true;
	}
}</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;MainWindow()&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IsPlaying(<span class="cs__keyword">false</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;IsPlaying(<span class="cs__keyword">bool</span>&nbsp;flag)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.IsEnabled&nbsp;=&nbsp;flag;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnStop.IsEnabled&nbsp;=&nbsp;flag;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnMoveBack.IsEnabled&nbsp;=&nbsp;flag;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnMoveForward.IsEnabled&nbsp;=&nbsp;flag;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnPlay_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IsPlaying(<span class="cs__keyword">true</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(btnPlay.Content.ToString()&nbsp;==&nbsp;<span class="cs__string">&quot;Play&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Play();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.Content&nbsp;=&nbsp;<span class="cs__string">&quot;Pause&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Pause();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.Content&nbsp;=&nbsp;<span class="cs__string">&quot;Play&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnStop_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Pause();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.Content&nbsp;=&nbsp;<span class="cs__string">&quot;Play&quot;</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;IsPlaying(<span class="cs__keyword">false</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnMoveBack_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Position&nbsp;-=&nbsp;TimeSpan.FromSeconds(<span class="cs__number">10</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnMoveForward_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Position&nbsp;&#43;=&nbsp;TimeSpan.FromSeconds(<span class="cs__number">10</span>);&nbsp;
}&nbsp;
&nbsp;
<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;btnOpen_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Configure&nbsp;open&nbsp;file&nbsp;dialog&nbsp;box</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Microsoft.Win32.OpenFileDialog&nbsp;dialog&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Microsoft.Win32.OpenFileDialog();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dialog.FileName&nbsp;=&nbsp;<span class="cs__string">&quot;Videos&quot;</span>;&nbsp;<span class="cs__com">//&nbsp;Default&nbsp;file&nbsp;name</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dialog.DefaultExt&nbsp;=&nbsp;<span class="cs__string">&quot;.WMV&quot;</span>;&nbsp;<span class="cs__com">//&nbsp;Default&nbsp;file&nbsp;extension</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;dialog.Filter&nbsp;=&nbsp;<span class="cs__string">&quot;WMV&nbsp;file&nbsp;(.wm)|*.wmv&quot;</span>;&nbsp;<span class="cs__com">//&nbsp;Filter&nbsp;files&nbsp;by&nbsp;extension&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Show&nbsp;open&nbsp;file&nbsp;dialog&nbsp;box</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Nullable&lt;<span class="cs__keyword">bool</span>&gt;&nbsp;result&nbsp;=&nbsp;dialog.ShowDialog();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Process&nbsp;open&nbsp;file&nbsp;dialog&nbsp;box&nbsp;results&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(result&nbsp;==&nbsp;<span class="cs__keyword">true</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Open&nbsp;document&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MediaPlayer.Source&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Uri(dialog.FileName);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;btnPlay.IsEnabled&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<div>&nbsp;</div>
<div>4.&nbsp; If we want play more video format. we can use some 3rd part video decoder. Such as K-Lite Mega Codec Pack. Media Element defers to the same underlying infrastructure as Windows Media Player. So it can only play AVI or MP3, MP4 extension files.
 And I think we could not use asynchronous pattern to decode the videos. It uses the Windows Media Player OCX control which in turn is using Media Foundation to decode.</div>
<div><br>
5. Here are some related references about Media Element, I recommend it to you.<br>
#MediaElement Class<br>
<a href="http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement.aspx">http://msdn.microsoft.com/en-us/library/system.windows.controls.mediaelement.aspx</a><br>
#MediaElement Overview<br>
<a href="http://msdn.microsoft.com/en-us/library/aa970915.aspx">http://msdn.microsoft.com/en-us/library/aa970915.aspx</a><br>
Hope it can help you.</div>
