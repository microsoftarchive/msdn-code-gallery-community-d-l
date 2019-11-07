# Hamburger Menu Example
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- Windows 10
- UWP
## Topics
- Windows 10
- UWP
## Updated
- 01/05/2016
## Description

<h1>Introduction</h1>
<p><em>In this sample we will learn how to prepare the Hamburger Menu.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em><em>You will need to run this sample on Visual Studio 2015 which runs on Windows 10.</em><strong>&nbsp;</strong><em></em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>How does this sample solve the problem? </em>With all of the new and exciting features coming out with Windows 10 development, the SplitView control is a new addition to XAML.&nbsp; For a quick intro to the SplitView, you can check out my previous post
<a href="http://blogs.msdn.com/b/quick_thoughts/archive/2015/05/22/win-10-splitview-intro.aspx">
here.</a>&nbsp; This post covers the basics of implementing a SplitView in XAML, some of the key properties, etc.&nbsp; Regalrdess, it&rsquo;s basic use is to display a side menu, such as the one usually called &ldquo;hamburger menu&rdquo;.&nbsp; This is something
 that you have probably seen before on other platforms and maybe even some custom implementations on Windows, but now we, the developers, have access to it for the first time on the Windows platform.&nbsp; So, let&rsquo;s take a look at how we actually build
 one of these menus</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span><span class="hidden">csharp</span>
<pre class="hidden">&lt;RelativePanel&gt;
            &lt;Button Name=&quot;HamburgerButton&quot; FontFamily=&quot;Segoe MDL2 Assets&quot; Content=&quot;&amp;#xE700;&quot; FontSize=&quot;36&quot; Click=&quot;HamburgerButton_Click&quot; /&gt;
        &lt;/RelativePanel&gt;
        &lt;SplitView Name=&quot;MySplitView&quot; 
                   Grid.Row=&quot;1&quot; 
                   DisplayMode=&quot;CompactOverlay&quot; 
                   OpenPaneLength=&quot;200&quot; 
                   CompactPaneLength=&quot;56&quot; 
                   HorizontalAlignment=&quot;Left&quot;&gt;
            &lt;SplitView.Pane&gt;
                &lt;ListBox SelectionMode=&quot;Single&quot; 
                         Name=&quot;IconsListBox&quot; 
                         SelectionChanged=&quot;IconsListBox_SelectionChanged&quot;&gt;
                    &lt;ListBoxItem Name=&quot;ShareListBoxItem&quot;&gt;
                        &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                            &lt;TextBlock FontFamily=&quot;Segoe MDL2 Assets&quot; FontSize=&quot;36&quot; Text=&quot;&amp;#xE72D;&quot; /&gt;
                            &lt;TextBlock Text=&quot;Share&quot; FontSize=&quot;24&quot; Margin=&quot;20,0,0,0&quot; /&gt;
                        &lt;/StackPanel&gt;
                    &lt;/ListBoxItem&gt;

                    &lt;ListBoxItem Name=&quot;FavoritesListBoxItem&quot;&gt;
                        &lt;StackPanel Orientation=&quot;Horizontal&quot;&gt;
                            &lt;TextBlock FontFamily=&quot;Segoe MDL2 Assets&quot; FontSize=&quot;36&quot; Text=&quot;&amp;#xE734;&quot; /&gt;
                            &lt;TextBlock Text=&quot;Favorites&quot; FontSize=&quot;24&quot; Margin=&quot;20,0,0,0&quot; /&gt;
                        &lt;/StackPanel&gt;
                    &lt;/ListBoxItem&gt;

                &lt;/ListBox&gt;
            &lt;/SplitView.Pane&gt;
            &lt;SplitView.Content&gt;
                &lt;TextBlock Name=&quot;ResultTextBlock&quot; /&gt;
            &lt;/SplitView.Content&gt;
        &lt;/SplitView&gt;
        </pre>
<pre class="hidden">  private void HamburgerButton_Click(object sender, RoutedEventArgs e)
    {
      MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
    }

    private void IconsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (ShareListBoxItem.IsSelected) { ResultTextBlock.Text = &quot;Share&quot;; }
      else if (FavoritesListBoxItem.IsSelected) { ResultTextBlock.Text = &quot;Favorites&quot;; }
    }
  }</pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;RelativePanel</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;HamburgerButton&quot;</span>&nbsp;<span class="xaml__attr_name">FontFamily</span>=<span class="xaml__attr_value">&quot;Segoe&nbsp;MDL2&nbsp;Assets&quot;</span>&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;&amp;#xE700;&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;36&quot;</span>&nbsp;<span class="xaml__attr_name">Click</span>=<span class="xaml__attr_value">&quot;HamburgerButton_Click&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/RelativePanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SplitView</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;MySplitView&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">DisplayMode</span>=<span class="xaml__attr_value">&quot;CompactOverlay&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">OpenPaneLength</span>=<span class="xaml__attr_value">&quot;200&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CompactPaneLength</span>=<span class="xaml__attr_value">&quot;56&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">HorizontalAlignment</span>=<span class="xaml__attr_value">&quot;Left&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SplitView</span>.Pane<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBox</span>&nbsp;<span class="xaml__attr_name">SelectionMode</span>=<span class="xaml__attr_value">&quot;Single&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;IconsListBox&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">SelectionChanged</span>=<span class="xaml__attr_value">&quot;IconsListBox_SelectionChanged&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBoxItem</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ShareListBoxItem&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">FontFamily</span>=<span class="xaml__attr_value">&quot;Segoe&nbsp;MDL2&nbsp;Assets&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;36&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;&amp;#xE72D;&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Share&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;24&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;20,0,0,0&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListBoxItem&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListBoxItem</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;FavoritesListBoxItem&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackPanel</span>&nbsp;<span class="xaml__attr_name">Orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">FontFamily</span>=<span class="xaml__attr_value">&quot;Segoe&nbsp;MDL2&nbsp;Assets&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;36&quot;</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;&amp;#xE734;&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Favorites&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;24&quot;</span>&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;20,0,0,0&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackPanel&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListBoxItem&gt;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListBox&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/SplitView.Pane&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;SplitView</span>.Content<span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextBlock</span>&nbsp;<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;ResultTextBlock&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/SplitView.Content&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/SplitView&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainPage.xaml #1 - summary contains the XAML control</em>s </li><li><em>MainPage.xaml.cs #1 - summary contains the code behind.</em> </li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
<div class="mcePaste" id="_mcePaste" style="left:-10000px; top:0px; width:1px; height:1px; overflow:hidden">
With all of the new and exciting features coming out with Windows 10 development, the SplitView control is a new addition to XAML.&nbsp; For a quick intro to the SplitView, you can check out my previous post
<a href="http://blogs.msdn.com/b/quick_thoughts/archive/2015/05/22/win-10-splitview-intro.aspx">
here.</a>&nbsp; This post covers the basics of implementing a SplitView in XAML, some of the key properties, etc.&nbsp; Regalrdess, it&rsquo;s basic use is to display a side menu, such as the one usually called &ldquo;hamburger menu&rdquo;.&nbsp; This is something
 that you have probably seen before on other platforms and maybe even some custom implementations on Windows, but now we, the developers, have access to it for the first time on the Windows platform.&nbsp; So, let&rsquo;s take a look at how we actually build
 one of these menus!<strong></strong><em></em></div>
