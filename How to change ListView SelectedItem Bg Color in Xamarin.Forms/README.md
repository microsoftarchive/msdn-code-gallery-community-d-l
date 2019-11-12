# How to change ListView SelectedItem Bg Color in Xamarin.Forms
## Requires
- Visual Studio 2012
## License
- MIT
## Technologies
- Xamarin.Android
- Xamarin.iOS
- Xamarin
- Xamarin.Forms
## Topics
- ListView SelectedItem bg Color in Xamarin.Forms
## Updated
- 10/14/2018
## Description

<div>
<p><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Introduction</span></strong></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><span class="s1">This article describes how we can change ListView SelectedItem bg color in Xamarin.Forms</span>. Sometimes we may need to set different bg color for ListView selected
 item, So in this article, we can learn how to achieve this functionality using CustomRenderer.</span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><span>You can also read&nbsp; this article from my original blog</span><span>&nbsp;<a href="https://venkyxamarin.blogspot.com/2018/10/how-to-change-listview-selecteditem-bg.html">here</a></span><br>
</span></p>
</div>
<div>
<div></div>
<div>
<p><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Requirements:</span></strong></p>
</div>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">This article source code is prepared by using Visual Studio 2017. And it is better to install latest visual studio updates from&nbsp;<a href="https://www.visualstudio.com/vs/visual-studio-mac/">here</a>.</span>
</li></ul>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">This article is prepared on a MAC machine.</span>
</li></ul>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">This sample project is Xamarin.Forms .Net standard project.</span>
</li></ul>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">This sample app is targeted for Android, iOS. And tested for Android &amp; iOS.</span>
</li></ul>
<div>
<p><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Description:</span></strong></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><span>The creation of &nbsp;Xamarin.Forms project is very simple in Visual Studio for Mac. It&nbsp;</span><span>will&nbsp;</span><span>creates three projects&nbsp;</span></span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">1) Shared Code</span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">2) Xamarin.Android</span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">3) Xamarin.iOS</span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Because Mac system with&nbsp;&nbsp;Visual Studio for Mac&nbsp;it doesn't&nbsp;support Windows projects(UWP, Windows, Windows Phone)</span></p>
</div>
<div>
<p><span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">The following steps will show you how to create Xamarin.Forms project in Mac system with&nbsp;&nbsp;Visual Studio,</span></span></p>
</div>
<p><span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">F</span></span><span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">irst, open the Visual Studio for Mac. And Click on New Project&nbsp;</span></span></p>
<p class="separator"><img src=":-project.png" border="0" alt="" width="640" height="354"></p>
<p>&nbsp;</p>
<div>
<p class="separator"><span style="font-family:verdana,sans-serif"><span style="font-family:verdana,sans-serif"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">After that, we need to select whether you're doing Xamarin.Forms or Xamarin.</span></span></span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Android
 or Xamarin.iOS project. if we want to create Xamarin.Forms project just follow the below screenshot.</span></p>
<div>
<div>
<p><span style="font-family:verdana,sans-serif"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><img src=":-selecttemplate.png" border="0" alt="" width="640" height="464"></span></span></p>
</div>
</div>
</div>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Give the App Name i.e ListViewDemo.</span></p>
<p><img src=":-projectname.png" border="0" alt="" width="640" height="462"></p>
<p class="separator"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong>Note:</strong>&nbsp;</span></p>
<p class="separator"><span style="font-family:times,&quot;times new roman&quot;,serif"><span style="font-size:large">I</span><span style="font-size:large">n the above screen under Shared Code, select use .NET Standard or Use Shared Library.&nbsp;</span><span style="font-size:large">Then
 click on Next Button and below screenshot will show you how to browse to save the project on our PC.</span></span></p>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><img src=":-browse.png" border="0" alt="" width="640" height="464"><span style="font-family:Verdana,Arial,Helvetica,sans-serif; font-size:10px">&nbsp;</span></span></p>
</div>
<p class="separator"><span style="font-size:large"><span style="font-family:times,&quot;times new roman&quot;,serif">After click on Create, button it will create the ListViewDemo Xamarin.Forms project like below</span></span></p>
<div></div>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><em><strong>ListViewDemo:</strong>&nbsp;It is for Shared Code</em></span>
</li></ul>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><em><strong><em><strong>ListViewDemo</strong></em>.Droid:</strong>&nbsp;It is for Android.</em></span>
</li></ul>
<ul>
<li><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><em><strong><em><strong>ListViewDemo</strong></em>.iOS:</strong>&nbsp;It is for iOS</em></span>
</li></ul>
<p class="separator"><a href="https://1.bp.blogspot.com/-OmK8vEY6lJg/W5ZyNy_O6xI/AAAAAAAABWk/MlfioRy2AtExIrg-JTLAHOKiL6Tz4FccwCEwYBhgL/s1600/ProjectStructure.png"><img src=":-projectstructure.png" border="0" alt="" width="640" height="306"></a></p>
<p class="separator"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">We need to follow below few steps to change selected-item background color for ListView.</span></p>
<p class="separator"><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">.Net Standard/PCL:</span>&nbsp;</strong></p>
</div>
<div>
<p><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Step 1:</span></strong></p>
<div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:medium"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Create your own Xaml page name is ListViewPage.xaml, and make sure refer &quot;<strong>CustomViewCell</strong>&quot;
 class in Xaml by declaring a namespace for its location and using the namespace prefix on the control element. The following code example shows how the &quot;CustomViewCell&quot; renderer class can be consumed by a Xamlpage:</span></span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:medium"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">And here we are trying to set background color for ListView selected-item.</span></span></p>
</div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong>ListViewPage.xaml</strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="js">&lt;?xml&nbsp;version=<span class="js__string">&quot;1.0&quot;</span>&nbsp;encoding=<span class="js__string">&quot;UTF-8&quot;</span>?&gt;&nbsp;&nbsp;&nbsp;
&lt;ContentPage&nbsp;xmlns=<span class="js__string">&quot;http://xamarin.com/schemas/2014/forms&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2009/xaml&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:custom=<span class="js__string">&quot;clr-namespace:ListViewDemo.CustomControls;assembly=ListViewDemo&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:ios=<span class="js__string">&quot;clr-namespace:Xamarin.Forms.PlatformConfiguration.iOSSpecific;assembly=Xamarin.Forms.Core&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor=<span class="js__string">&quot;White&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:Class=<span class="js__string">&quot;ListViewDemo.Views.ListViewPage&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentPage.Padding&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;OnPlatform&nbsp;x:TypeArguments=<span class="js__string">&quot;Thickness&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Android=<span class="js__string">&quot;0,&nbsp;0,&nbsp;0,&nbsp;0&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;WinPhone=<span class="js__string">&quot;0,&nbsp;0,&nbsp;0,&nbsp;0&quot;</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;iOS=<span class="js__string">&quot;0,&nbsp;20,&nbsp;0,&nbsp;0&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ContentPage.Padding&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;ContentPage.Content&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackLayout&nbsp;Padding=<span class="js__string">&quot;30,40,30,0&quot;</span>&nbsp;Spacing=<span class="js__string">&quot;50&quot;</span>&nbsp;BackgroundColor=<span class="js__string">&quot;White&quot;</span>&nbsp;VerticalOptions=<span class="js__string">&quot;FillAndExpand&quot;</span>&nbsp;HorizontalOptions=<span class="js__string">&quot;FillAndExpand&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Text=<span class="js__string">&quot;ListView&nbsp;SelectedItemColor&quot;</span>&nbsp;&nbsp;HorizontalOptions=<span class="js__string">&quot;CenterAndExpand&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;20&quot;</span>&nbsp;TextColor=<span class="js__string">&quot;Maroon&quot;</span>&nbsp;FontAttributes=<span class="js__string">&quot;Bold&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView&nbsp;Grid.Row=<span class="js__string">&quot;1&quot;</span>&nbsp;ItemsSource=<span class="js__string">&quot;{Binding&nbsp;OrdersList}&quot;</span>&nbsp;Footer=<span class="js__string">&quot;&quot;</span>&nbsp;ios:ListView.SeparatorStyle=<span class="js__string">&quot;FullWidth&quot;</span>&nbsp;HeightRequest=<span class="js__string">&quot;140&quot;</span>&nbsp;SeparatorColor=<span class="js__string">&quot;Gray&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;custom:CustomViewCell&nbsp;SelectedItemBackgroundColor=<span class="js__string">&quot;#ADF3BE&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ViewCell.View&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackLayout&nbsp;Orientation=<span class="js__string">&quot;Horizontal&quot;</span>&nbsp;&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;OrderType}&quot;</span>&nbsp;VerticalOptions=<span class="js__string">&quot;CenterAndExpand&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;Medium&quot;</span>&nbsp;Font=<span class="js__string">&quot;15&quot;</span>&nbsp;TextColor=<span class="js__string">&quot;Gray&quot;</span>&nbsp;HorizontalOptions=<span class="js__string">&quot;StartAndExpand&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;StackLayout&nbsp;HorizontalOptions=<span class="js__string">&quot;EndAndExpand&quot;</span>&nbsp;Orientation=<span class="js__string">&quot;Horizontal&quot;</span>&nbsp;Spacing=<span class="js__string">&quot;15&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Frame&nbsp;OutlineColor=<span class="js__string">&quot;Green&quot;</span>&nbsp;HasShadow=<span class="js__string">&quot;false&quot;</span>&nbsp;Margin=<span class="js__string">&quot;0,8,0,8&quot;</span>&nbsp;BackgroundColor=<span class="js__string">&quot;Transparent&quot;</span>&nbsp;Padding=<span class="js__string">&quot;5&quot;</span>&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Label&nbsp;Text=<span class="js__string">&quot;{Binding&nbsp;TotalCount}&quot;</span>&nbsp;HorizontalOptions=<span class="js__string">&quot;CenterAndExpand&quot;</span>&nbsp;VerticalOptions=<span class="js__string">&quot;CenterAndExpand&quot;</span>&nbsp;FontSize=<span class="js__string">&quot;10&quot;</span>&nbsp;TextColor=<span class="js__string">&quot;Red&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Frame&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Image&nbsp;Source=<span class="js__string">&quot;back_icon.png&quot;</span>&nbsp;VerticalOptions=<span class="js__string">&quot;CenterAndExpand&quot;</span>&nbsp;HeightRequest=<span class="js__string">&quot;16&quot;</span>&nbsp;WidthRequest=<span class="js__string">&quot;16&quot;</span>&nbsp;HorizontalOptions=<span class="js__string">&quot;EndAndExpand&quot;</span>/&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackLayout&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackLayout&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ViewCell.View&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/custom:CustomViewCell&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView.ItemTemplate&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ListView&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/StackLayout&gt;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ContentPage.Content&gt;&nbsp;&nbsp;&nbsp;
&lt;/ContentPage&gt;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong>Note:</strong></span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">The &quot;custom&quot; namespace prefix can be named anything. However, the clr-namespace and assembly values must match the details of the custom renderer class. Once the namespace is declared
 the prefix is used to reference the custom control/layout.</span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong>Step 2:</strong></span></span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif"><span style="font-size:large">&nbsp;</span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Add some simple list data to bind ObservableCollection to the ListView in code behind.
 Also here I'm not following MVVM design pattern.</span></span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><span><strong>ListViewPage.xaml.cs</strong></span></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;ListViewDemo.ViewModels;&nbsp;&nbsp;&nbsp;
using&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
namespace&nbsp;ListViewDemo.Views&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;partial&nbsp;class&nbsp;ListViewPage&nbsp;:&nbsp;ContentPage&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ListViewPage()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindingContext&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ListViewPageViewModel();&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</pre>
</div>
</div>
</div>
</div>
<h2><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">ViewModels:</span></h2>
<h2>ListViewPageviewModel.cs</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;System;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.Generic.aspx" target="_blank" title="Auto generated link to System.Collections.Generic">System.Collections.Generic</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Collections.ObjectModel.aspx" target="_blank" title="Auto generated link to System.Collections.ObjectModel">System.Collections.ObjectModel</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
using&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Runtime.CompilerServices.aspx" target="_blank" title="Auto generated link to System.Runtime.CompilerServices">System.Runtime.CompilerServices</a>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
using&nbsp;ListViewDemo.Models;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
namespace&nbsp;ListViewDemo.ViewModels&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;ListViewPageViewModel&nbsp;:&nbsp;INotifyPropertyChanged&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ObservableCollection&lt;Order&gt;&nbsp;_ordersList;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ObservableCollection&lt;Order&gt;&nbsp;OrdersList&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;_ordersList;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ordersList&nbsp;=&nbsp;value;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(<span class="js__string">&quot;OrdersList&quot;</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;bool&nbsp;SetProperty&lt;T&gt;(ref&nbsp;T&nbsp;backingStore,&nbsp;T&nbsp;value,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[CallerMemberName]string&nbsp;propertyName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Action&nbsp;onChanged&nbsp;=&nbsp;null)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(EqualityComparer&lt;T&gt;.Default.Equals(backingStore,&nbsp;value))&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;backingStore&nbsp;=&nbsp;value;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;onChanged?.Invoke();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OnPropertyChanged(propertyName);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//INotifyPropertyChanged&nbsp;implementation&nbsp;method&nbsp;&nbsp;&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;event&nbsp;PropertyChangedEventHandler&nbsp;PropertyChanged;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;protected&nbsp;<span class="js__operator">void</span>&nbsp;OnPropertyChanged([CallerMemberName]&nbsp;string&nbsp;propertyName&nbsp;=&nbsp;<span class="js__string">&quot;&quot;</span>)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;changed&nbsp;=&nbsp;PropertyChanged;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(changed&nbsp;==&nbsp;null)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;changed.Invoke(<span class="js__operator">this</span>,&nbsp;<span class="js__operator">new</span>&nbsp;PropertyChangedEventArgs(propertyName));&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;ListViewPageViewModel()&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">var</span>&nbsp;ordersList&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;ObservableCollection&lt;Order&gt;();&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Completed&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;56566&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Limit&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;878&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Market&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;39856&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Stop&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;056708&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Imbalance&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;64775674&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Conditional&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;56&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Scheduled&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;1457575763&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Mid-Point&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;2443&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Odd&nbsp;lot&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;65781&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ordersList.Add(<span class="js__operator">new</span>&nbsp;Order()&nbsp;<span class="js__brace">{</span>&nbsp;OrderType&nbsp;=&nbsp;<span class="js__string">&quot;Pending&nbsp;Orders&quot;</span>,&nbsp;TotalCount&nbsp;=&nbsp;<span class="js__string">&quot;9896&quot;</span>&nbsp;<span class="js__brace">}</span>);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;OrdersList&nbsp;=&nbsp;ordersList;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><strong style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Step 3:</strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">&nbsp;</span></p>
<h2>
<div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong>In&nbsp;.Net
</strong>Standard<strong>/PCL, create a class name is&nbsp;CustomViewCell which should inherit&nbsp;any ViewCell</strong><br>
</span></p>
</div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:medium"><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">CustomViewCell.cs</span></strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="js">using&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
namespace&nbsp;ListViewDemo.CustomControls&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;class&nbsp;CustomViewCell&nbsp;:&nbsp;ViewCell&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;static&nbsp;readonly&nbsp;BindableProperty&nbsp;SelectedItemBackgroundColorProperty&nbsp;=&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BindableProperty.Create(<span class="js__string">&quot;SelectedItemBackgroundColor&quot;</span>,&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">typeof</span>(Color),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">typeof</span>(CustomViewCell),&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Color.Default);&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;Color&nbsp;SelectedItemBackgroundColor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;get&nbsp;<span class="js__brace">{</span>&nbsp;<span class="js__statement">return</span>&nbsp;(Color)GetValue(SelectedItemBackgroundColorProperty);&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;set&nbsp;<span class="js__brace">{</span>&nbsp;SetValue(SelectedItemBackgroundColorProperty,&nbsp;value);&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<p><span style="font-family:Times,&quot;Times New Roman&quot;,serif; font-size:large">Xamarin.Android:</span></p>
<p>In Android project, create a class name is CustomViewCellRenderer and make sure to add renderer registration for our CustomViewCell class on above of the namespace.</p>
<p><strong style="font-size:large"><span style="font-family:times,&quot;times new roman&quot;,serif">CustomViewCellRenderer.cs</span></strong></p>
</div>
</h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.ComponentModel.aspx" target="_blank" title="Auto generated link to System.ComponentModel">System.ComponentModel</a>;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ListViewDemo.CustomControls;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;ListViewDemo.Droid.CustomControls;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Android.Content;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Android.Graphics.Drawables;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Android.Views;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms.Platform.Android;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;ExportRenderer(<span class="cs__keyword">typeof</span>(CustomViewCell),&nbsp;<span class="cs__keyword">typeof</span>(CustomViewCellRenderer))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;ListViewDemo.Droid.CustomControls&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomViewCellRenderer&nbsp;:&nbsp;ViewCellRenderer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Android.Views.View&nbsp;_cellCore;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;Drawable&nbsp;_unselectedBackground;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">bool</span>&nbsp;_selected;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;Android.Views.View&nbsp;GetCellCore(Cell&nbsp;item,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Android.Views.View&nbsp;convertView,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ViewGroup&nbsp;parent,&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Context&nbsp;context)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cellCore&nbsp;=&nbsp;<span class="cs__keyword">base</span>.GetCellCore(item,&nbsp;convertView,&nbsp;parent,&nbsp;context);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_selected&nbsp;=&nbsp;<span class="cs__keyword">false</span>;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_unselectedBackground&nbsp;=&nbsp;_cellCore.Background;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;_cellCore;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">protected</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;OnCellPropertyChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;PropertyChangedEventArgs&nbsp;args)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">base</span>.OnCellPropertyChanged(sender,&nbsp;args);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(args.PropertyName&nbsp;==&nbsp;<span class="cs__string">&quot;IsSelected&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_selected&nbsp;=&nbsp;!_selected;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(_selected)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;extendedViewCell&nbsp;=&nbsp;sender&nbsp;<span class="cs__keyword">as</span>&nbsp;CustomViewCell;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cellCore.SetBackgroundColor(extendedViewCell.SelectedItemBackgroundColor.ToAndroid());&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">else</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_cellCore.SetBackground(_unselectedBackground);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<span style="font-family:times,&quot;times new roman&quot;,serif">
<div class="endscriptcode"><span style="font-size:large">Here OnCellPropertyChanged method instantiates background for ListView selected item.&nbsp;</span></div>
</span></div>
<div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif"><span style="font-size:large"><strong><span style="font-family:times,&quot;times new roman&quot;,serif">Xamarin.iOS:</span></strong></span></span></p>
<p><span style="font-family:times,&quot;times new roman&quot;,serif"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">In iOS project, create a class name is&nbsp;<span><span style="font-family:times,&quot;times new roman&quot;,serif">CustomViewCellRenderer</span></span>&nbsp;and
 make sure to add renderer registration for our&nbsp;</span><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">RoundedCornerView class in above of the namespace.</span></span></p>
</div>
<div>
<p><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><strong><span style="font-family:times,&quot;times new roman&quot;,serif">CustomViewCellRenderer.cs</span></strong></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">using</span>&nbsp;ListViewDemo.CustomControls;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;UIKit;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;Xamarin.Forms.Platform.iOS;&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">using</span>&nbsp;xamformsdemo.iOS.CustomControls;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
[assembly:&nbsp;ExportRenderer(<span class="cs__keyword">typeof</span>(CustomViewCell),&nbsp;<span class="cs__keyword">typeof</span>(CustomViewCellRenderer))]&nbsp;&nbsp;&nbsp;
<span class="cs__keyword">namespace</span>&nbsp;xamformsdemo.iOS.CustomControls&nbsp;&nbsp;&nbsp;
{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">class</span>&nbsp;CustomViewCellRenderer&nbsp;:&nbsp;ViewCellRenderer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">override</span>&nbsp;UITableViewCell&nbsp;GetCell(Cell&nbsp;item,&nbsp;UITableViewCell&nbsp;reusableCell,&nbsp;UITableView&nbsp;tv)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;cell&nbsp;=&nbsp;<span class="cs__keyword">base</span>.GetCell(item,&nbsp;reusableCell,&nbsp;tv);&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;view&nbsp;=&nbsp;item&nbsp;<span class="cs__keyword">as</span>&nbsp;CustomViewCell;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cell.SelectedBackgroundView&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;UIView&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BackgroundColor&nbsp;=&nbsp;view.SelectedItemBackgroundColor.ToUIColor(),&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;};&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;cell;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;&nbsp;&nbsp;
}&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<span style="font-family:times,&quot;times new roman&quot;,serif">
<div class="endscriptcode"><span style="font-size:large">Here GetCell override method instantiates&nbsp;background for ListView selected item.</span></div>
</span></div>
</div>
<div>
<p><strong><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large">Output:</span></strong></p>
<p class="separator"><span style="font-family:times,&quot;times new roman&quot;,serif; font-size:large"><a href="https://1.bp.blogspot.com/-I0vb1F0OCYQ/W5Z9d7tw1JI/AAAAAAAABXE/1cHUYO16oXQHV3kSz0K38_6XahjJpHouwCLcBGAs/s1600/iOS.png"><img src=":-ios.png" border="0" alt="" width="177" height="400"></a><a href="https://4.bp.blogspot.com/-Ws49Pgjsih8/W5Z9d114LfI/AAAAAAAABXI/0VX-r2YUrbUYBEF_nxFXLadxknKHce2YgCLcBGAs/s1600/Android.png"><img src=":-android.png" border="0" alt="" width="208" height="400"></a></span></p>
</div>
