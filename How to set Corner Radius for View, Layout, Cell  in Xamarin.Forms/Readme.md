# How to set Corner Radius for View, Layout, Cell  in Xamarin.Forms
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Xamarin.Forms
## Topics
- Corner Radius in Xamarin.Forms
- CornerRadius for StackLayout in Xamarin.Forms
- BorderRadius in Xamarin.Forms
- CornerRadius for Grid ListView in Xamarin.Forms
## Updated
- 12/24/2017
## Description

<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Introduction:</span></strong></span></p>
</div>
<div>
<p><span style="font-size:small"><span class="s1" style="font-family:verdana,sans-serif">This article describes how we can set Corner Radius&nbsp;for Control or View or Layout</span><span style="font-family:verdana,sans-serif">. Sometimes we may get the requirement
 to set corner radius for StackLayout or Grid or ListView in that cases earlier I tried to put View or Layout inside the Frame to make the corner radius, but it is difficult to set all corner properties. So in this article, we can learn how to achieve this
 functionality using CustomRenderer.</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">You can also read this article on my original blog from&nbsp;</span><a href=" https://venkyxamarin.blogspot.com/2017/12/how-to-set-corner-radius-for-view.html" target="_blank" style="font-family:verdana,sans-serif; font-size:small">here</a></span></p>
</div>
<div>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Requirements:</span></strong></span></p>
</div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article source code is prepared by using Visual Studio. And it is better to install latest visual studio updates from&nbsp;<a href="https://www.visualstudio.com/vs/visual-studio-mac/">here</a>.
</span></li></ul>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This article is prepared on a MAC machine.
</span></li></ul>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This sample project is Xamarin.Forms PCL project.
</span></li></ul>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small">This sample app is targeted for Android, iOS. And tested for Android &amp; iOS.
</span></li></ul>
<p><span style="font-size:small"><strong style="font-size:small">Description:</strong></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">The creation of &nbsp;Xamarin.Forms project is very simple in Visual Studio for Mac. It creates will three projects&nbsp;</span></p>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">1) Shared Code</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">2) Xamarin.Android</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">3) Xamarin.iOS</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">Because Mac system with&nbsp;&nbsp;Visual Studio for Mac&nbsp;it doesn't&nbsp;support Windows projects(UWP, Windows, Windows Phone)</span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">The following steps will show you how to create Xamarin.Forms project in Mac system with&nbsp;&nbsp;Visual Studio,</span></p>
</div>
<p><span style="font-family:verdana,sans-serif; font-size:small">First, open the Visual Studio for Mac. And click on New Project.</span></p>
<p class="separator"><span style="font-size:small"><a href="https://2.bp.blogspot.com/-t41O04XukYQ/WiuGAPVEcyI/AAAAAAAAAjw/GCSkXZR4M88M1Yt_ROYoZAFV06g4XoSpwCLcBGAs/s1600/XamarinStudio.png"><img src=":-xamarinstudio.png" border="0" alt="" width="640" height="352"></a></span></p>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small">After that, we need to select whether you're doing Xamarin.Forms or Xamarin.</span><span style="font-family:verdana,sans-serif">Android or Xamarin.iOS project. if we want to create Xamarin.Forms
 project just follow the below screenshot.</span><span style="font-family:verdana,sans-serif">&nbsp;</span></p>
</div>
<div>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><a href="https://3.bp.blogspot.com/--PCa5O0j10k/WiuGwTRu-eI/AAAAAAAAAj0/nIAoJ314sa0cfIvFqMbZsHj2I8E37HixACLcBGAs/s1600/SelectType.png"><img src=":-selecttype.png" border="0" alt="" width="640" height="462"></a></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small">Then we have to give the App Name i.e RoundedCornerViewDemo.</span></p>
</div>
</div>
<div>
<p class="separator"><span style="font-size:small"><a href="https://2.bp.blogspot.com/-aFfxPgGr8cM/WiuHVn90ZMI/AAAAAAAAAj4/Kb7G0Qq2Q1AExeTQxPhmSjqQdVytdYrBQCLcBGAs/s1600/ProjectName.png"><img src=":-projectname.png" border="0" alt="" width="640" height="466"></a></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small"><strong style="font-family:verdana,sans-serif; font-size:small">Note:</strong><span style="font-family:verdana,sans-serif">&nbsp;In the above screen under Shared Code, select Portable class Library or Use Shared Library.</span></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">Then click on Next Button the following screenshot will be displayed. In that screen, we have to browse the file path where we want&nbsp;to save that application on our PC.</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small"><a href="https://2.bp.blogspot.com/-JHZVrwpEy-o/WiuImBXeLAI/AAAAAAAAAj8/_fHSCksUutQqOHyxB5sRecOPsDs5GD1_wCLcBGAs/s1600/XamarinBrowseLocation.png"><img src=":-xamarinbrowselocation.png" border="0" alt="" width="640" height="466"></a></span></p>
<p class="separator">&nbsp;</p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">After Click on Create, button it will create the RoundedCornerViewDemo Xamarin.Forms project like this</span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small"><a href="https://4.bp.blogspot.com/-451FH6vuaPA/WiuKYh7tHhI/AAAAAAAAAkE/jOO34CMC0xonlu9rpACrofzIkcMuAZaiQCLcBGAs/s1600/Xamarin.FormsProject.png"><img src=":-xamarin.formsproject.png" border="0" alt="" width="640" height="352"></a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">And project structure will be.</span></p>
<div></div>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small"><strong>RoundedCornerViewDemo:</strong>&nbsp;It is for Shared Code
</span></li></ul>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small"><strong>RoundedCornerViewDemo.Droid:</strong>&nbsp;It is for Android.
</span></li></ul>
<ul>
<li><span style="font-family:verdana,sans-serif; font-size:small"><strong>RoundedCornerViewDemo.iOS:</strong>&nbsp;It is for iOS
</span></li></ul>
<p class="separator"><span style="font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small"><a href="https://1.bp.blogspot.com/-mg-epc4wGlU/WiualWe7-_I/AAAAAAAAAkQ/7ufKgbsR5-UVXvANYngK9HZ_hmAhjJwtQCLcBGAs/s1600/Xamarin.Forms%2BProjectStructure.png"><img src=":-xamarin.forms%2bprojectstructure.png" border="0" alt="" width="250" height="640"></a></span></p>
<p class="separator"><span style="font-family:verdana,sans-serif; font-size:small">We need to follow below few steps to make corner radius for the view.</span></p>
<div>
<p><span style="font-size:small"><strong style="font-family:verdana,sans-serif; font-size:small">1. Portable Class Library (PCL):</strong></span></p>
<p><strong style="font-family:verdana,sans-serif; font-size:small">Step 1:</strong><span style="font-family:verdana,sans-serif; font-size:small">&nbsp;</span></p>
</div>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In PCL, create a class name is&nbsp;</span><span style="font-family:verdana,sans-serif">RoundedCornerView which should inherit</span><span style="font-family:verdana,sans-serif">&nbsp;any
 layout and this article inherit Grid Layout and adding</span><span style="font-family:verdana,sans-serif">&nbsp;BindableProperties like BorderColor, RoundedCornerRadius, BorderWidth, MakeCircle, FillColor.</span></span></p>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>RoundedCornerView.cs</strong></span></p>
</div>
<div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">using System;  
using Xamarin.Forms;  
  
namespace RoundedCornerViewDemo.ControlsToolkit.Custom  
{  
    public class RoundedCornerView : Grid  
    {  
        public static readonly BindableProperty FillColorProperty =  
            BindableProperty.Create&lt;RoundedCornerView, Color&gt;(w =&gt; w.FillColor, Color.White);  
        public Color FillColor  
        {  
            get { return (Color)GetValue(FillColorProperty); }  
            set { SetValue(FillColorProperty, value); }  
        }  
  
        public static readonly BindableProperty RoundedCornerRadiusProperty =  
            BindableProperty.Create&lt;RoundedCornerView, double&gt;(w =&gt; w.RoundedCornerRadius, 3);  
        public double RoundedCornerRadius  
        {  
            get { return (double)GetValue(RoundedCornerRadiusProperty); }  
            set { SetValue(RoundedCornerRadiusProperty, value); }  
        }  
  
        public static readonly BindableProperty MakeCircleProperty =  
            BindableProperty.Create&lt;RoundedCornerView, Boolean&gt;(w =&gt; w.MakeCircle, false);  
        public Boolean MakeCircle  
        {  
            get { return (Boolean)GetValue(MakeCircleProperty); }  
            set { SetValue(MakeCircleProperty, value); }  
        }  
  
        public static readonly BindableProperty BorderColorProperty =  
            BindableProperty.Create&lt;RoundedCornerView, Color&gt;(w =&gt; w.BorderColor, Color.Transparent);  
        public Color BorderColor  
        {  
            get { return (Color)GetValue(BorderColorProperty); }  
            set { SetValue(BorderColorProperty, value); }  
        }  
  
        public static readonly BindableProperty BorderWidthProperty =  
            BindableProperty.Create&lt;RoundedCornerView, int&gt;(w =&gt; w.BorderWidth, 1);  
        public int BorderWidth  
        {  
            get { return (int)GetValue(BorderWidthProperty); }  
            set { SetValue(BorderWidthProperty, value); }  
        }  
    }  
}  </span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RoundedCornerViewDemo.ControlsToolkit.Custom&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RoundedCornerView&nbsp;:&nbsp;Grid&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;FillColorProperty&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create&lt;RoundedCornerView,&nbsp;Color&gt;(w&nbsp;=&gt;&nbsp;w.FillColor,&nbsp;Color.White);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Color&nbsp;FillColor&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(Color)GetValue(FillColorProperty);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(FillColorProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;RoundedCornerRadiusProperty&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create&lt;RoundedCornerView,&nbsp;<span class="cs__keyword">double</span>&gt;(w&nbsp;=&gt;&nbsp;w.RoundedCornerRadius,&nbsp;<span class="cs__number">3</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">double</span>&nbsp;RoundedCornerRadius&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">double</span>)GetValue(RoundedCornerRadiusProperty);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(RoundedCornerRadiusProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;MakeCircleProperty&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create&lt;RoundedCornerView,&nbsp;Boolean&gt;(w&nbsp;=&gt;&nbsp;w.MakeCircle,&nbsp;<span class="cs__keyword">false</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Boolean&nbsp;MakeCircle&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(Boolean)GetValue(MakeCircleProperty);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(MakeCircleProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;BorderColorProperty&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create&lt;RoundedCornerView,&nbsp;Color&gt;(w&nbsp;=&gt;&nbsp;w.BorderColor,&nbsp;Color.Transparent);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;Color&nbsp;BorderColor&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(Color)GetValue(BorderColorProperty);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(BorderColorProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">static</span>&nbsp;<span class="cs__keyword">readonly</span>&nbsp;BindableProperty&nbsp;BorderWidthProperty&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create&lt;RoundedCornerView,&nbsp;<span class="cs__keyword">int</span>&gt;(w&nbsp;=&gt;&nbsp;w.BorderWidth,&nbsp;<span class="cs__number">1</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">int</span>&nbsp;BorderWidth&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;{&nbsp;<span class="cs__keyword">return</span>&nbsp;(<span class="cs__keyword">int</span>)GetValue(BorderWidthProperty);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">set</span>&nbsp;{&nbsp;SetValue(BorderWidthProperty,&nbsp;<span class="cs__keyword">value</span>);&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Step 2:</span></strong></span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">Create your own Xaml page name is&nbsp;RoundedCornerViewPage.xaml, and make sure refer &quot;</span><span style="font-family:verdana,sans-serif">RoundedCornerView</span><span style="font-family:verdana,sans-serif">&quot;
 class&nbsp;</span><span style="font-family:verdana,sans-serif">in Xaml by declaring a namespace for its location and using the namespace prefix on the control element. The following code example shows how the&nbsp;</span><span style="font-family:verdana,sans-serif">&quot;</span><span style="font-family:verdana,sans-serif">RoundedCornerView</span><span style="font-family:verdana,sans-serif">&quot;</span><span style="font-family:verdana,sans-serif">&nbsp;</span><span style="font-family:verdana,sans-serif">renderer
 class</span><span style="font-family:verdana,sans-serif">&nbsp;can be consumed by a XAML page:</span></span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">And here we are trying to set rounded corner radius for ListView, so place Listview inside our custom renderer control, let's see how it make corner radius.</span></span></p>
</div>
<p><span style="font-size:small"><strong>RoundedCornerViewPage.xaml</strong></span></p>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">XAML</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">xaml </span>
<pre class="hidden"><span style="font-size:small">&lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;  
&lt;ContentPage xmlns=&quot;http://xamarin.com/schemas/2014/forms&quot;  
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;  
    xmlns:custom=&quot;clr-namespace:RoundedCornerViewDemo.ControlsToolkit.Custom;assembly=RoundedCornerViewDemo&quot;  
    x:Class=&quot;RoundedCornerViewDemo.RoundedCornerViewPage&quot;&gt;  
    &lt;StackLayout Spacing=&quot;20&quot; Padding=&quot;20,40,20,20&quot;&gt;  
        &lt;Label Text=&quot;RoundedCornerView&quot; HorizontalOptions=&quot;CenterAndExpand&quot; FontSize=&quot;30&quot; TextColor=&quot;Blue&quot;/&gt;  
        &lt;custom:RoundedCornerView BorderColor=&quot;Gray&quot; BorderWidth=&quot;2&quot;  BackgroundColor=&quot;Transparent&quot; VerticalOptions=&quot;FillAndExpand&quot; RoundedCornerRadius=&quot;8&quot;&gt;  
         &lt;ListView x:Name=&quot;EmployeeView&quot;&gt;  
            &lt;ListView.ItemTemplate&gt;  
               &lt;DataTemplate&gt;  
                &lt;TextCell Text=&quot;{Binding DisplayName}&quot;/&gt;  
               &lt;/DataTemplate&gt;  
               &lt;/ListView.ItemTemplate&gt;  
          &lt;/ListView&gt;  
         &lt;/custom:RoundedCornerView&gt;  
        &lt;/StackLayout&gt;  
&lt;/ContentPage&gt;  </span></pre>
<div class="preview">
<pre class="xaml"><span style="font-size:small"><span class="xaml__tag_start">&lt;?xml</span>&nbsp;<span class="xaml__attr_name">version</span>=<span class="xaml__attr_value">&quot;1.0&quot;</span>&nbsp;<span class="xaml__attr_name">encoding</span>=<span class="xaml__attr_value">&quot;utf-8&quot;</span><span class="xaml__tag_start">?&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_start">&lt;ContentPage</span>&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">custom</span>=<span class="xaml__attr_value">&quot;clr-namespace:RoundedCornerViewDemo.ControlsToolkit.Custom;assembly=RoundedCornerViewDemo&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;RoundedCornerViewDemo.RoundedCornerViewPage&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">Spacing</span>=<span class="xaml__attr_value">&quot;20&quot;</span>&nbsp;<span class="xaml__attr_name">Padding</span>=<span class="xaml__attr_value">&quot;20,40,20,20&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;RoundedCornerView&quot;</span>&nbsp;<span class="xaml__attr_name">HorizontalOptions</span>=<span class="xaml__attr_value">&quot;CenterAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">FontSize</span>=<span class="xaml__attr_value">&quot;30&quot;</span>&nbsp;<span class="xaml__attr_name">TextColor</span>=<span class="xaml__attr_value">&quot;Blue&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;custom</span>:RoundedCornerView&nbsp;<span class="xaml__attr_name">BorderColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;<span class="xaml__attr_name">BorderWidth</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">RoundedCornerRadius</span>=<span class="xaml__attr_value">&quot;8&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;EmployeeView&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ListView</span>.ItemTemplate<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;DataTemplate</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;TextCell</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;DisplayName}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/DataTemplate&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/ListView&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/custom:RoundedCornerView&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/ContentPage&gt;</span>&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<span style="font-family:verdana,sans-serif; font-size:small"><strong>Note:</strong></span>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">The &quot;<strong>custom</strong>&quot; n</span><span style="font-family:verdana,sans-serif">amespace prefix can be named anything. However, the&nbsp;clr-namespace and assembly values must
 match the details of the custom renderer class. Once the namespace is declared the prefix is used to reference the custom control/layout.</span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif"><strong>Step 3:</strong></span></span></p>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">Add some simple data to bind ObservableCollection to the ListView in code behind. Also here I'm not following MVVM design pattern.</span></span></p>
</div>
<div>
<p><span style="font-size:small"><strong style="font-size:small"><span style="font-family:verdana,sans-serif">RoundedCornerViewPage.xaml.cs</span></strong></span></p>
</div>
<div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">C#</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">csharp </span>
<pre class="hidden"><span style="font-size:small">using System.Collections.ObjectModel;  
using Xamarin.Forms;  
  
namespace RoundedCornerViewDemo  
{  
    public partial class RoundedCornerViewPage : ContentPage  
    {  
        ObservableCollection&lt;Employee&gt; employees = new ObservableCollection&lt;Employee&gt;();  
  
        public RoundedCornerViewPage()  
        {  
            InitializeComponent();  
  
            employees.Add(new Employee { DisplayName = &quot;Rob Finnerty&quot; });  
            employees.Add(new Employee { DisplayName = &quot;Bill Wrestler&quot; });  
            employees.Add(new Employee { DisplayName = &quot;Dr. Geri-Beth Hooper&quot; });  
            employees.Add(new Employee { DisplayName = &quot;Dr. Keith Joyce-Purdy&quot; });  
            employees.Add(new Employee { DisplayName = &quot;Sheri Spruce&quot; });  
            employees.Add(new Employee { DisplayName = &quot;Burt Indybrick&quot; });  
  
            EmployeeView.ItemsSource = employees;  
        }  
    }  
  
    public class Employee  
    {  
        public string DisplayName { get; set; }  
    }  
}  </span></pre>
<div class="preview">
<pre class="csharp"><span style="font-size:small"><span class="cs__keyword">using</span>&nbsp;System.Collections.ObjectModel;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RoundedCornerViewDemo&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;RoundedCornerViewPage&nbsp;:&nbsp;ContentPage&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Employee&gt;&nbsp;employees&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;ObservableCollection&lt;Employee&gt;();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;RoundedCornerViewPage()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Rob&nbsp;Finnerty&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Bill&nbsp;Wrestler&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Dr.&nbsp;Geri-Beth&nbsp;Hooper&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Dr.&nbsp;Keith&nbsp;Joyce-Purdy&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Sheri&nbsp;Spruce&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;employees.Add(<span class="cs__keyword">new</span>&nbsp;Employee&nbsp;{&nbsp;DisplayName&nbsp;=&nbsp;<span class="cs__string">&quot;Burt&nbsp;Indybrick&quot;</span>&nbsp;});&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EmployeeView.ItemsSource&nbsp;=&nbsp;employees;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;Employee&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;DisplayName&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;<span class="cs__keyword">set</span>;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small"><strong style="font-family:Verdana,Arial,Helvetica,sans-serif"><span style="font-family:verdana,sans-serif">Examples:</span></strong></span></div>
</div>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In above code, we made corner radius for ListView. But we can also set RoundedCornerRadius for any Control/View and Layout.</span></span></p>
</div>
<div>
<p><span style="font-size:small"><strong style="font-size:small"><span style="font-family:verdana,sans-serif">StackLayout:</span></strong></span></p>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small"><strong>XAML</strong></span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></span></div>
<span style="font-size:small"><strong><span class="hidden">xaml</span>
<pre class="hidden">&lt;custom:RoundedCornerView BorderColor=&quot;Gray&quot; BorderWidth=&quot;2&quot;  BackgroundColor=&quot;Transparent&quot; VerticalOptions=&quot;FillAndExpand&quot; RoundedCornerRadius=&quot;8&quot;&gt;  
         &lt;StackLayout orientation=&quot;Horizontal&quot;&gt; 
            &lt;Label Text=&quot;Hi Welcome&quot;/&gt;   
          &lt;/StackLayout&gt;  
&lt;/custom:RoundedCornerView&gt;  </pre>
<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;custom</span>:RoundedCornerView&nbsp;<span class="xaml__attr_name">BorderColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;<span class="xaml__attr_name">BorderWidth</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">RoundedCornerRadius</span>=<span class="xaml__attr_value">&quot;8&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;StackLayout</span>&nbsp;<span class="xaml__attr_name">orientation</span>=<span class="xaml__attr_value">&quot;Horizontal&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Hi&nbsp;Welcome&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/StackLayout&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/custom:RoundedCornerView&gt;</span>&nbsp;&nbsp;</pre>
</div>
</strong></span></div>
</div>
<p><span style="font-size:small"><strong style="font-family:verdana,sans-serif; font-size:small">Grid:</strong></span></p>
</div>
<div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">XAML</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">xaml </span>
<pre class="hidden"><span style="font-size:small">&lt;custom:RoundedCornerView BorderColor=&quot;Gray&quot; BorderWidth=&quot;2&quot;  BackgroundColor=&quot;Transparent&quot; VerticalOptions=&quot;FillAndExpand&quot; RoundedCornerRadius=&quot;8&quot;&gt;   
           &lt;Grid&gt;  
               &lt;Grid.RowDefinitions&gt;  
                   &lt;RowDefinition Height=&quot;Auto&quot;/&gt;  
               &lt;/Grid.RowDefinitions&gt;  
               &lt;Grid.ColumnDefinitions&gt;  
                   &lt;ColumnDefinition Width=&quot;Auto&quot;/&gt;  
               &lt;/Grid.ColumnDefinitions&gt;  
               &lt;Label Text=&quot;Hi Welcome&quot;/&gt; 
           &lt;/Grid&gt;  
&lt;/custom:RoundedCornerView&gt;   </span></pre>
<div class="preview">
<pre class="xaml"><span style="font-size:small"><span class="xaml__tag_start">&lt;custom</span>:RoundedCornerView&nbsp;<span class="xaml__attr_name">BorderColor</span>=<span class="xaml__attr_value">&quot;Gray&quot;</span>&nbsp;<span class="xaml__attr_name">BorderWidth</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;&nbsp;<span class="xaml__attr_name">BackgroundColor</span>=<span class="xaml__attr_value">&quot;Transparent&quot;</span>&nbsp;<span class="xaml__attr_name">VerticalOptions</span>=<span class="xaml__attr_value">&quot;FillAndExpand&quot;</span>&nbsp;<span class="xaml__attr_name">RoundedCornerRadius</span>=<span class="xaml__attr_value">&quot;8&quot;</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.RowDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;RowDefinition</span>&nbsp;<span class="xaml__attr_name">Height</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.RowDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span>.ColumnDefinitions<span class="xaml__tag_start">&gt;&nbsp;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;ColumnDefinition</span>&nbsp;<span class="xaml__attr_name">Width</span>=<span class="xaml__attr_value">&quot;Auto&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid.ColumnDefinitions&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Label</span>&nbsp;<span class="xaml__attr_name">Text</span>=<span class="xaml__attr_value">&quot;Hi&nbsp;Welcome&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;&nbsp;&nbsp;
<span class="xaml__tag_end">&lt;/custom:RoundedCornerView&gt;</span>&nbsp;&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><span style="font-size:small">&nbsp;<strong style="font-family:verdana,sans-serif; font-size:small">ViewCell:</strong></span></div>
<div class="endscriptcode"></div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small">XAML</span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></span></div>
<span class="hidden" style="font-size:small">xaml </span>
<pre class="hidden"><span style="font-size:small">&lt;ListView x:Name=&quot;EmployeeView&quot;&gt;   
                &lt;ListView.ItemTemplate&gt;   
                    &lt;DataTemplate&gt;    
                        &lt;ViewCell&gt;  
                            &lt;custom:RoundedCornerView BorderColor=&quot;Gray&quot; BorderWidth=&quot;2&quot;  BackgroundColor=&quot;Transparent&quot; VerticalOptions=&quot;FillAndExpand&quot; RoundedCornerRadius=&quot;8&quot;&gt;    
                                &lt;TextCell Text=&quot;{Binding DisplayName}&quot;/&gt;  
                            &lt;/custom:RoundedCornerView&gt;    
                        &lt;/ViewCell&gt;  
                    &lt;/DataTemplate&gt;    
                &lt;/ListView.ItemTemplate&gt;    
&lt;/ListView&gt;  </span></pre>
<div class="preview">
<pre class="js"><span style="font-size:small">&lt;ListView&nbsp;x:Name=<span class="js__string">&quot;EmployeeView&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ViewCell&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;custom:RoundedCornerView&nbsp;BorderColor=<span class="js__string">&quot;Gray&quot;</span>&nbsp;BorderWidth=<span class="js__string">&quot;2&quot;</span>&nbsp;&nbsp;BackgroundColor=<span class="js__string">&quot;Transparent&quot;</span>&nbsp;VerticalOptions=<span class="js__string">&quot;FillAndExpand&quot;</span>&nbsp;RoundedCornerRadius=<span class="js__string">&quot;8&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;TextCell&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;DisplayName}&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/custom:RoundedCornerView&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ViewCell&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&lt;/ListView&gt;&nbsp;&nbsp;</span></pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong style="font-size:small"><span style="font-family:verdana,sans-serif">2. Xamarin.Android</span></strong></div>
</div>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In Android project, create a class name is RoundedCornerViewRenderer and make sure to add renderer registration for our&nbsp;</span><span style="font-family:verdana,sans-serif">RoundedCornerView
 class in above of the namespace</span><span style="font-family:verdana,sans-serif">:</span></span></p>
<p><span style="font-size:small"><strong style="font-size:small">RoundedCornerViewRenderer.cs</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small"><strong style="font-size:small">C#</strong></span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><strong style="font-size:small"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></span></div>
<span style="font-size:small"><strong style="font-size:small"><span class="hidden">csharp</span>
<pre class="hidden">using System;  

using Android.Graphics;  
using RoundedCornerViewDemo;  
using RoundedCornerViewDemo.ControlsToolkit.Custom;  
using RoundedCornerViewDemo.Droid.Renderers;  
using Xamarin.Forms;  
using Xamarin.Forms.Platform.Android;  
  
[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]  
namespace RoundedCornerViewDemo.Droid.Renderers  
{  
    public class RoundedCornerViewRenderer : ViewRenderer  
    {  
  
        protected override void OnElementChanged(ElementChangedEventArgs&lt;View&gt; e)  
        {  
            base.OnElementChanged(e);  
        }  
  
        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)  
        {  
            if (Element == null) return false;  
  
            RoundedCornerView rcv = (RoundedCornerView)Element;  
            this.SetClipChildren(true);  
  
            rcv.Padding = new Thickness(0, 0, 0, 0);  
            //rcv.HasShadow = false;  
  
            int radius = (int)(rcv.RoundedCornerRadius);  
            // Check if make circle is set to true. If so, then we just use the width and  
            // height of the control to calculate the radius. RoundedCornerRadius will be ignored  
            // in this case.  
            if (rcv.MakeCircle)  
            {  
                radius = Math.Min(Width, Height) / 2;  
            }  
  
            // When we create a round rect, we will have to double the radius since it is not  
            // the same as creating a circle.  
            radius *= 2;  
  
            try  
            {  
                //Create path to clip the child   
                var path = new Path();  
                path.AddRoundRect(new RectF(0, 0, Width, Height),  
                              new float[] { radius, radius, radius, radius, radius, radius, radius, radius },  
                              Path.Direction.Ccw);  
  
                canvas.Save();  
                canvas.ClipPath(path);  
  
                // Draw the child first so that the border shows up above it.  
                var result = base.DrawChild(canvas, child, drawingTime);  
  
                canvas.Restore();  
  
                /* 
                 * If a border is specified, we use the same path created above to stroke 
                 * with the border color. 
                 * */  
                if (rcv.BorderWidth &gt; 0)  
                {  
                    // Draw a filled circle.  
                    var paint = new Paint();  
                    paint.AntiAlias = true;  
                    paint.StrokeWidth = rcv.BorderWidth;  
                    paint.SetStyle(Paint.Style.Stroke);  
                    paint.Color = rcv.BorderColor.ToAndroid();  
  
                    canvas.DrawPath(path, paint);  
  
                    paint.Dispose();  
                }  
  
                //Properly dispose  
                path.Dispose();  
                return result;  
            }  
            catch (Exception ex)  
            {  
                System.Console.Write(ex.Message);  
            }  
  
            return base.DrawChild(canvas, child, drawingTime);  
        }  
    }  
}  </pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="cs__keyword">using</span>&nbsp;Android.Graphics;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo.ControlsToolkit.Custom;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo.Droid.Renderers;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms.Platform.Android;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;ExportRenderer(<span class="cs__keyword">typeof</span>(RoundedCornerView),&nbsp;<span class="cs__keyword">typeof</span>(RoundedCornerViewRenderer))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RoundedCornerViewDemo.Droid.Renderers&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RoundedCornerViewRenderer&nbsp;:&nbsp;ViewRenderer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnElementChanged(ElementChangedEventArgs&lt;View&gt;&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnElementChanged(e);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;DrawChild(Canvas&nbsp;canvas,&nbsp;global::Android.Views.View&nbsp;child,&nbsp;<span class="cs__keyword">long</span>&nbsp;drawingTime)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(Element&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoundedCornerView&nbsp;rcv&nbsp;=&nbsp;(RoundedCornerView)Element;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.SetClipChildren(<span class="cs__keyword">true</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rcv.Padding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//rcv.HasShadow&nbsp;=&nbsp;false;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;radius&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(rcv.RoundedCornerRadius);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Check&nbsp;if&nbsp;make&nbsp;circle&nbsp;is&nbsp;set&nbsp;to&nbsp;true.&nbsp;If&nbsp;so,&nbsp;then&nbsp;we&nbsp;just&nbsp;use&nbsp;the&nbsp;width&nbsp;and&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;height&nbsp;of&nbsp;the&nbsp;control&nbsp;to&nbsp;calculate&nbsp;the&nbsp;radius.&nbsp;RoundedCornerRadius&nbsp;will&nbsp;be&nbsp;ignored&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;in&nbsp;this&nbsp;case.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rcv.MakeCircle)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;radius&nbsp;=&nbsp;Math.Min(Width,&nbsp;Height)&nbsp;/&nbsp;<span class="cs__number">2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;When&nbsp;we&nbsp;create&nbsp;a&nbsp;round&nbsp;rect,&nbsp;we&nbsp;will&nbsp;have&nbsp;to&nbsp;double&nbsp;the&nbsp;radius&nbsp;since&nbsp;it&nbsp;is&nbsp;not&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;the&nbsp;same&nbsp;as&nbsp;creating&nbsp;a&nbsp;circle.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;radius&nbsp;*=&nbsp;<span class="cs__number">2</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Create&nbsp;path&nbsp;to&nbsp;clip&nbsp;the&nbsp;child&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;path&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Path();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;path.AddRoundRect(<span class="cs__keyword">new</span>&nbsp;RectF(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;Width,&nbsp;Height),&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;<span class="cs__keyword">float</span>[]&nbsp;{&nbsp;radius,&nbsp;radius,&nbsp;radius,&nbsp;radius,&nbsp;radius,&nbsp;radius,&nbsp;radius,&nbsp;radius&nbsp;},&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Path.Direction.Ccw);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.Save();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.ClipPath(path);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Draw&nbsp;the&nbsp;child&nbsp;first&nbsp;so&nbsp;that&nbsp;the&nbsp;border&nbsp;shows&nbsp;up&nbsp;above&nbsp;it.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;result&nbsp;=&nbsp;<span class="cs__keyword">base</span>.DrawChild(canvas,&nbsp;child,&nbsp;drawingTime);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.Restore();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__mlcom">/*&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;If&nbsp;a&nbsp;border&nbsp;is&nbsp;specified,&nbsp;we&nbsp;use&nbsp;the&nbsp;same&nbsp;path&nbsp;created&nbsp;above&nbsp;to&nbsp;stroke&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;with&nbsp;the&nbsp;border&nbsp;color.&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*&nbsp;*/</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rcv.BorderWidth&nbsp;&gt;&nbsp;<span class="cs__number">0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//&nbsp;Draw&nbsp;a&nbsp;filled&nbsp;circle.&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;paint&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Paint();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint.AntiAlias&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint.StrokeWidth&nbsp;=&nbsp;rcv.BorderWidth;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint.SetStyle(Paint.Style.Stroke);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint.Color&nbsp;=&nbsp;rcv.BorderColor.ToAndroid();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;canvas.DrawPath(path,&nbsp;paint);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;paint.Dispose();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//Properly&nbsp;dispose&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;path.Dispose();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;result;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;ex)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;System.Console.Write(ex.Message);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">base</span>.DrawChild(canvas,&nbsp;child,&nbsp;drawingTime);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</strong></span></div>
</div>
<div class="endscriptcode"><span style="font-family:verdana,sans-serif">Here OnElementChanged method instantiates an Android&nbsp;UI Layout. And also make sure to override DrawChild which is responsible for getting the canvas in the right state that includes
 BorderColor, BorderWidth, BorderRadius etc.</span><strong style="font-size:small">&nbsp;</strong></div>
</div>
</div>
</div>
<div>
<div>
<p><span style="font-size:small"><strong style="font-size:small"><span style="font-family:verdana,sans-serif">3.&nbsp;</span></strong><strong style="font-size:small"><span style="font-family:verdana,sans-serif">Xamarin.iOS</span></strong></span></p>
</div>
<div>
<p><span style="font-size:small"><span style="font-family:verdana,sans-serif">In iOS project, create a class name is RoundedCornerViewRenderer and make sure to add renderer registration for our&nbsp;</span><span style="font-family:verdana,sans-serif">RoundedCornerView
 class in above of the namespace</span><span style="font-family:verdana,sans-serif">:</span></span></p>
</div>
<div>
<p><span style="font-family:verdana,sans-serif; font-size:small"><strong>RoundedCornerViewRenderer.cs</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span style="font-size:small"><strong>C#</strong></span></div>
<div class="pluginLinkHolder"><span style="font-size:small"><strong><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></strong></span></div>
<span style="font-size:small"><strong><span class="hidden">csharp</span>
<pre class="hidden">using System;  
using System.Diagnostics;  
using RoundedCornerViewDemo;  
using RoundedCornerViewDemo.ControlsToolkit.Custom;  
using RoundedCornerViewDemo.iOS;  
using Xamarin.Forms;  
using Xamarin.Forms.Platform.iOS;  
  
[assembly: ExportRenderer(typeof(RoundedCornerView), typeof(RoundedCornerViewRenderer))]  
namespace RoundedCornerViewDemo.iOS  
{  
    public class RoundedCornerViewRenderer : ViewRenderer  
    {  
        protected override void OnElementChanged(ElementChangedEventArgs&lt;View&gt; e)  
        {  
            base.OnElementChanged(e);  
  
            if (this.Element == null) return;  
  
            this.Element.PropertyChanged &#43;= (sender, e1) =&gt;  
            {  
                try  
                {  
                    if (NativeView != null)  
                    {  
                        NativeView.SetNeedsDisplay();  
                        NativeView.SetNeedsLayout();  
                    }  
                }  
                catch (Exception exp)  
                {  
                    Debug.WriteLine(&quot;Handled Exception in RoundedCornerViewDemoRenderer. Just warngin : &quot; &#43; exp.Message);  
                }  
            };  
        }  
  
        public override void Draw(CoreGraphics.CGRect rect)  
        {  
            base.Draw(rect);  
  
            this.LayoutIfNeeded();  
  
            RoundedCornerView rcv = (RoundedCornerView)Element;  
            //rcv.HasShadow = false;  
            rcv.Padding = new Thickness(0, 0, 0, 0);  
  
            //this.BackgroundColor = rcv.FillColor.ToUIColor();  
            this.ClipsToBounds = true;  
            this.Layer.BackgroundColor = rcv.FillColor.ToCGColor();  
            this.Layer.MasksToBounds = true;  
            this.Layer.CornerRadius = (nfloat)rcv.RoundedCornerRadius;  
            if (rcv.MakeCircle)  
            {  
                this.Layer.CornerRadius = (int)(Math.Min(Element.Width, Element.Height) / 2);  
            }  
            this.Layer.BorderWidth = 0;  
  
            if (rcv.BorderWidth &gt; 0 &amp;&amp; rcv.BorderColor.A &gt; 0.0)  
            {  
                this.Layer.BorderWidth = rcv.BorderWidth;  
                this.Layer.BorderColor =  
                    new UIKit.UIColor(  
                    (nfloat)rcv.BorderColor.R,  
                    (nfloat)rcv.BorderColor.G,  
                    (nfloat)rcv.BorderColor.B,  
                        (nfloat)rcv.BorderColor.A).CGColor;  
            }  
        }  
    }  
}  
</pre>
<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;System;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;System.Diagnostics;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo.ControlsToolkit.Custom;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;RoundedCornerViewDemo.iOS;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms.Platform.iOS;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;ExportRenderer(<span class="cs__keyword">typeof</span>(RoundedCornerView),&nbsp;<span class="cs__keyword">typeof</span>(RoundedCornerViewRenderer))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;RoundedCornerViewDemo.iOS&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;RoundedCornerViewRenderer&nbsp;:&nbsp;ViewRenderer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnElementChanged(ElementChangedEventArgs&lt;View&gt;&nbsp;e)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnElementChanged(e);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(<span class="cs__keyword">this</span>.Element&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;<span class="cs__keyword">return</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Element.PropertyChanged&nbsp;&#43;=&nbsp;(sender,&nbsp;e1)&nbsp;=&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(NativeView&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NativeView.SetNeedsDisplay();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NativeView.SetNeedsLayout();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">catch</span>&nbsp;(Exception&nbsp;exp)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Debug.WriteLine(<span class="cs__string">&quot;Handled&nbsp;Exception&nbsp;in&nbsp;RoundedCornerViewDemoRenderer.&nbsp;Just&nbsp;warngin&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;exp.Message);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Draw(CoreGraphics.CGRect&nbsp;rect)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.Draw(rect);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.LayoutIfNeeded();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RoundedCornerView&nbsp;rcv&nbsp;=&nbsp;(RoundedCornerView)Element;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//rcv.HasShadow&nbsp;=&nbsp;false;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;rcv.Padding&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;Thickness(<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>,&nbsp;<span class="cs__number">0</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__com">//this.BackgroundColor&nbsp;=&nbsp;rcv.FillColor.ToUIColor();&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.ClipsToBounds&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.BackgroundColor&nbsp;=&nbsp;rcv.FillColor.ToCGColor();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.MasksToBounds&nbsp;=&nbsp;<span class="cs__keyword">true</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.CornerRadius&nbsp;=&nbsp;(nfloat)rcv.RoundedCornerRadius;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rcv.MakeCircle)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.CornerRadius&nbsp;=&nbsp;(<span class="cs__keyword">int</span>)(Math.Min(Element.Width,&nbsp;Element.Height)&nbsp;/&nbsp;<span class="cs__number">2</span>);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.BorderWidth&nbsp;=&nbsp;<span class="cs__number">0</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(rcv.BorderWidth&nbsp;&gt;&nbsp;<span class="cs__number">0</span>&nbsp;&amp;&amp;&nbsp;rcv.BorderColor.A&nbsp;&gt;&nbsp;<span class="cs__number">0.0</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.BorderWidth&nbsp;=&nbsp;rcv.BorderWidth;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.Layer.BorderColor&nbsp;=&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">new</span>&nbsp;UIKit.UIColor(&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(nfloat)rcv.BorderColor.R,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(nfloat)rcv.BorderColor.G,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(nfloat)rcv.BorderColor.B,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(nfloat)rcv.BorderColor.A).CGColor;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;&nbsp;
</pre>
</div>
</strong></span></div>
</div>
<div class="endscriptcode"><span style="font-family:verdana,sans-serif; font-size:small">Here OnElementChanged method instantiates an iOS UI, with a reference to the layout being assigned to the renderer's&nbsp;Element property. In DrawChild method reference
 to the Layout being assigned to the renderer's Element property.&nbsp;</span></div>
</div>
</div>
<div>
<p><span style="font-size:small"><br>
</span></p>
</div>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif">Output:</span></strong></span></p>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif"><br>
</span></strong></span></p>
<p class="separator"><span style="font-size:small">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;<a href="https://3.bp.blogspot.com/-7LrOsB8-pAA/WizJWqsIBrI/AAAAAAAAAmU/lOaLk9IOttgYrP41zAFZ0Aq3mmGIT8QSgCLcBGAs/s1600/Andoid.png"><img src=":-andoid.png" border="0" alt="" width="250" height="400"></a><a href="https://1.bp.blogspot.com/-oPbeQfSy9QU/WizJWlZDpXI/AAAAAAAAAmQ/4_gp2mCPK0Ef2bGl7SiBJxQyppE3-ceKACLcBGAs/s1600/iOS.png"><img src=":-ios.png" border="0" alt="" width="232" height="400"></a></span></p>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif"><br>
</span></strong></span></p>
</div>
<p class="separator"><span style="font-size:small"><br>
</span></p>
<p class="separator"><span style="font-size:small">&nbsp; &nbsp; &nbsp;&nbsp;</span></p>
<div>
<p><span style="font-size:small"><strong><span style="font-family:verdana,sans-serif"><br>
</span></strong></span></p>
</div>
<div></div>
