# Full Screen Button for UWP Windows 10 App
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
- XAML
- WinRT
- XAML/C#
- Visual Studio 2015
- Windows 10
- Universal Windows App Development
- Windows Univeral App
- Universal Windows Platform
- UWP
- Blend for Visual Studio 2015
## Topics
- C#
- XAML
- WinRT
- universal app
- Visual Studio 2015
- Windows 10
- Universal Windows App Development
- Universal Windows Platform
- Universal Windows Applicaitons
- UWP
- Blend for Visual Studio 2015
## Updated
- 08/09/2016
## Description

<h1>Introduction</h1>
<p class="projectSummary"><span style="font-size:small">This sample provide easy way to add EnterToFullScreen buttont in your app TitleBar and show you how to custumize the Titel Bar of your UWP Desktop application. You can add any Control in your app TitleBar
 by using XAML.</span></p>
<h1><span>Building the Sample</span></h1>
<p><span style="font-size:small"><em>For building this sample You should use visual Studio 2015 on &nbsp;Windows 10.</em></span></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">Windows 10 apps run in a window like any standard desktop application. This means that now they have a title bar, which can be customized, &nbsp;by default TitleBar has the name of the app on the left and the standard three
 button on the right. Also we can customize the colors of the standard buttons and this sample provide that functionality.</span></p>
<p><span style="font-size:small">The XAML side of the code is pretty simple:&nbsp;</span></p>
<p><em>&nbsp;</em></p>
<p><em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Grid Background=&quot;White&quot;&gt; 
    &lt;Grid.RowDefinitions&gt; 
          &lt;RowDefinition Height=&quot;Auto&quot;/&gt;   
          &lt;RowDefinition Height=&quot;*&quot;/&gt; 
     &lt;/Grid.RowDefinitions&gt; 
     &lt;Grid x:Name=&quot;CustomTitleBar&quot;  Grid.Row=&quot;0&quot;&gt; 
           &lt;Grid.ColumnDefinitions&gt; 
                &lt;ColumnDefinition Width=&quot;*&quot;/&gt; 
                &lt;ColumnDefinition Width=&quot;Auto&quot;/&gt; 
           &lt;/Grid.ColumnDefinitions&gt; 
            &lt;Rectangle x:Name=&quot;GrapPanel&quot;Fill=&quot;Transparent&quot;HorizontalAlignment=&quot;Stretch&quot;/&gt;
            &lt;Button x:Name=&quot;FullScreenButton&quot;VerticalAlignment=&quot;Stretch&quot; Grid.Column=&quot;1&quot; Width=&quot;auto&quot;
                   Foreground=&quot;Black&quot;Click=&quot;Button_Click&quot;  
                   Style=&quot;{StaticResource FullScreenButtonStyle}&quot;&gt; 
                   &lt;SymbolIcon Symbol=&quot;FullScreen&quot;/&gt;
            &lt;/Button&gt;
     &lt;/Grid&gt;
     &lt;Button x:Name=&quot;ChangeTandartButtonsColor&quot;Content=&quot;Button&quot;HorizontalAlignment=&quot;Center&quot; 
             Margin=&quot;0&quot; Grid.Row=&quot;1&quot;VerticalAlignment=&quot;Center&quot;
             Click=&quot;ChangeTandartButtonsColor_Click&quot;/&gt;
&lt;/Grid&gt;</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;Grid</span>&nbsp;<span class="xaml__attr_name">Background</span>=<span class="xaml__attr_value">&quot;White&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;CustomTitleBar&quot;</span>&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;0&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;*&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Rectangle</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;GrapPanel&quot;</span><span class="xaml__attr_name">Fill</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Stretch&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;FullScreenButton&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Stretch&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;auto&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Foreground</span>=<span class="xaml__attr_value">&quot;Black&quot;</span><span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;Button_Click&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Style</span>=<span class="xaml__attr_value">&quot;{StaticResource&nbsp;FullScreenButtonStyle}&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SymbolIcon</span>&nbsp;<span class="xaml__attr_name">Symbol</span>=<span class="xaml__attr_value">&quot;FullScreen&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Button&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ChangeTandartButtonsColor&quot;</span><span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Button&quot;</span><span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;0&quot;</span>&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span><span class="xaml__attr_name">VerticalAlignment</span>=<span class="xaml__attr_value">&quot;Center&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;ChangeTandartButtonsColor_Click&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/Grid&gt;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span style="font-size:medium">&nbsp;Here are the app screenshots&nbsp;</span></div>
</em>
<p></p>
<p><img id="156893" src="156893-screenshot%20(70).png" alt="" width="712" height="679"></p>
<p><img id="156894" src="156894-screenshot%20(71).png" alt="" width="270" height="216"></p>
<p><span style="font-size:medium">Here is the part of C# code of the app&nbsp;</span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">        private void TitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            GrapPanel.Height = sender.Height;
            FullScreenButton.Margin = new Thickness(0, 0, sender.SystemOverlayRightInset, 0);
            Window.Current.SetTitleBar(GrapPanel);
        }

        private void ChangeTandartButtonsColor_Click(object sender, RoutedEventArgs e)
        {
           var apptitlebar = ApplicationView.GetForCurrentView().TitleBar;
            apptitlebar.ButtonHoverBackgroundColor = Colors.Purple;
            apptitlebar.ButtonBackgroundColor = Colors.Green;
        }</pre>
<div class="preview">
<pre class="csharp">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;TitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar&nbsp;sender,&nbsp;<span class="cs__keyword">object</span>&nbsp;args)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GrapPanel.Height&nbsp;=&nbsp;sender.Height;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FullScreenButton.Margin&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;sender.SystemOverlayRightInset,&nbsp;<span class="cs__number">0</span>);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Window.Current.SetTitleBar(GrapPanel);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;ChangeTandartButtonsColor_Click(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;RoutedEventArgs&nbsp;e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;apptitlebar&nbsp;=&nbsp;ApplicationView.GetForCurrentView().TitleBar;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;apptitlebar.ButtonHoverBackgroundColor&nbsp;=&nbsp;Colors.Purple;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;apptitlebar.ButtonBackgroundColor&nbsp;=&nbsp;Colors.Green;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span style="font-size:small"><em>MainPage.xaml</em> </span></li></ul>
<ul>
<li><span style="font-size:small"><em>MainPage.xaml.cs</em></span> </li></ul>
<h1>More Information</h1>
<p><span style="font-size:small">To obtain an evaluation copy of Visual Studio&nbsp;2015, go to &nbsp;<a href="https://www.visualstudio.com/en-us/downloads">Visual Studio&nbsp;2015</a>. After you install Visual Studio&nbsp;2015, you can update your installation
 with Visual Studio&nbsp;2015 Update&nbsp;1 or later.</span></p>
<p><span style="font-size:small">For more info about the programming models, platforms, languages, and APIs demonstrated in this sample, please refer to the guidance, tutorials, and reference topics provided in the Windows&nbsp;10 documentation available in
 the Windows Developer Center.</span></p>
