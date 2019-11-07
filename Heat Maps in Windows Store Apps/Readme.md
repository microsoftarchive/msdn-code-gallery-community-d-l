# Heat Maps in Windows Store Apps
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- Bing Maps
- Windows Store app
- Windows Store app Development
## Topics
- Bing Maps
- Heat Maps
## Updated
- 09/17/2014
## Description

<h1>Introduction</h1>
<p>Heat maps, also known as Choropleth maps, is a type of overlay on a map used to represent data using different colors. Heat maps are often used to show the data hot spots on the map. The data used in these overlays usually takes one of two forms. The first
 form is color coded polygons or polylines based on some metric related to those shapes. Creating this type of heat map is fairly easy as you simply need to assign a color to the shape when adding it to the map. The second form uses point based data, the colors
 of the heat map are based on the density of the data points on the map. Creating these types of heat maps are a bit more complex. If you are working in JavaScript there is a client side heat map module available in the
<a href="https://bingmapsv7modules.codeplex.com/">Bing Maps V7 Modules project</a> which can be used in Windows Store apps. Using this module is fairly easy and only takes a few lines of code to setup. Creating heat maps in native Windows Store apps is a bit
 harder to do. This code sample consists of a reusable library that generates a density heat map layer that can be overlaid on the Bing Maps control in C# and VB apps. Here is a sceenshot of the type of heatmaps that are generated using this code:</p>
<p><img id="109241" src="109241-heatmap.png" alt=""></p>
<h1><span>Building the Sample</span></h1>
<p>To run this sample you must install the <a href="http://visualstudiogallery.msdn.microsoft.com/224eb93a-ebc4-46ba-9be7-90ee777ad9e1">
Bing Maps SDK for Windows Store apps</a>&nbsp;and get a <a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">
Bing Maps key</a> for Windows Store apps. You must also have Windows 8.1 and Visual Studio 2013.</p>
<p>Open the sample in Visual Studio and insert your Bing Maps key in the&nbsp;MainPage.xaml file&nbsp;where it says &ldquo;YOUR_BING_MAPS_KEY&rdquo; in the source code. You must perform the following steps for your app project to work correctly with Bing Maps.
 Detailed instructions are provided below.&nbsp;</p>
<ul>
<li>Add a reference to&nbsp;Bing Maps SDK for C#, C&#43;&#43;, or Visual Basic. </li><li>Set the&nbsp;Active solution platform&nbsp;in Visual Studio to one of the following options.&nbsp;
<ul>
<li>C#, Visual Basic:&nbsp;ARM,&nbsp;x86&nbsp;or&nbsp;x64 </li><li>C&#43;&#43;:&nbsp;ARM,&nbsp;Win32&nbsp;or&nbsp;x64 </li></ul>
</li><li>If you are using C# or Visual basic, you must add a reference to&nbsp;Microsoft Visual C&#43;&#43; Runtime Package.
</li><li>Build the sample by press F5 or use <strong>Debug &gt; Start Debugging</strong>. To run the app without debugging, press Ctrl&#43;F5 or use
<strong>Debug &gt; Start Without Debugging</strong> </li></ul>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>The <strong>HeatMapLayer</strong> class provides a number of properties which can be used to customize how the heat map is rendered. Here is a list of the different properties available.</p>
<table border="1" cellspacing="0" cellpadding="0">
<tbody>
<tr>
<td width="114" valign="bottom">
<p><strong>Name</strong></p>
</td>
<td width="156" valign="bottom">
<p><strong>Type</strong></p>
</td>
<td width="354" valign="bottom">
<p><strong>Description</strong></p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>HeatGradient</p>
</td>
<td width="156" valign="top">
<p>GradientStopCollection</p>
</td>
<td width="354" valign="bottom">
<p>A color gradient used to colorize the heat map.</p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>Intensity</p>
</td>
<td width="156" valign="top">
<p>double</p>
</td>
<td width="354" valign="bottom">
<p>Intensity of the heat map. A value between 0 and 1.</p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>Locations</p>
</td>
<td width="156" valign="top">
<p>LocationCollection</p>
</td>
<td width="354" valign="bottom">
<p>Collection of locations to plot on the heat map.</p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>ParentMap</p>
</td>
<td width="156" valign="top">
<p>Map</p>
</td>
<td width="354" valign="bottom">
<p>A reference to the parent Bing Maps control.</p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>Radius</p>
</td>
<td width="156" valign="top">
<p>double</p>
</td>
<td width="354" valign="bottom">
<p>Radius of data point in meters.</p>
</td>
</tr>
<tr>
<td width="114" valign="top">
<p>EnableHardEdge</p>
</td>
<td width="156" valign="top">
<p>bool</p>
</td>
<td width="354" valign="bottom">
<p>Gives all values the same opacity to create a hard edge on each data point. When set to false (default) the data points will use a fading opacity towards the edges.</p>
</td>
</tr>
</tbody>
</table>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<br>
The heat map will not render until the <strong><em>ParentMap</em></strong> property is assigned. All the properties with the exception of this one support data binding. If you decided to add a heat map to your map using XAML you will need to set the
<strong><em>ParentMap</em></strong> property in your code behind. Here is an example of how to add a heat map to your map using XAML.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;Page
    x:Class=&quot;HeatMapTestApp.MainPage&quot;
    xmlns=&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;
    xmlns:x=&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;
    xmlns:local=&quot;using:HeatMapTestApp&quot;
    xmlns:d=&quot;http://schemas.microsoft.com/expression/blend/2008&quot;
    xmlns:mc=&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;
    xmlns:m=&quot;using:Bing.Maps&quot;
    xmlns:hm=&quot;using:Bing.Maps.HeatMaps&rdquo;&gt;

    &lt;Grid Background=&quot;{ThemeResource ApplicationPageBackgroundThemeBrush}&quot;&gt;       
        &lt;m:Map Name=&quot;MyMap&quot; Credentials=&quot;YOUR_BING_MAPS_KEY&quot;&gt;
            &lt;m:Map.Children&gt;
                &lt;hm:HeatMapLayer Name=&quot;layer&quot; Radius=&quot;2500&quot;/&gt;
            &lt;/m:Map.Children&gt;
        &lt;/m:Map&gt;
    &lt;/Grid&gt;
&lt;/Page&gt;
</pre>
<div class="preview">
<pre class="js">&lt;Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;x:Class=<span class="js__string">&quot;HeatMapTestApp.MainPage&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="js__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:local=<span class="js__string">&quot;using:HeatMapTestApp&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:d=<span class="js__string">&quot;http://schemas.microsoft.com/expression/blend/2008&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:mc=<span class="js__string">&quot;http://schemas.openxmlformats.org/markup-compatibility/2006&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:m=<span class="js__string">&quot;using:Bing.Maps&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;xmlns:hm=&quot;using:Bing.Maps.HeatMaps&rdquo;&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Background=<span class="js__string">&quot;{ThemeResource&nbsp;ApplicationPageBackgroundThemeBrush}&quot;</span>&gt;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;m:Map&nbsp;Name=<span class="js__string">&quot;MyMap&quot;</span>&nbsp;Credentials=<span class="js__string">&quot;YOUR_BING_MAPS_KEY&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;m:Map.Children&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;hm:HeatMapLayer&nbsp;Name=<span class="js__string">&quot;layer&quot;</span>&nbsp;Radius=<span class="js__string">&quot;2500&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/m:Map.Children&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/m:Map&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Page&gt;&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>You can then set the <strong><em>ParentMap</em></strong> property using the following code. You also can data bind the Location property, but for simplicity in this example I have just set it from code.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Bing.Maps;
using Microsoft.Maps.SpatialToolbox;
using Microsoft.Maps.SpatialToolbox.Bing;
using System;
using Windows.UI.Xaml.Controls;

namespace HeatMapTestApp
{
    public sealed partial class MainPage : Page
    {
        private LocationCollection locs;

        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded &#43;= (s, e) =&gt;
            {
                locs = new LocationCollection();

                //Add location data to collection&hellip;

                layer.ParentMap = MyMap;
                layer.Locations = locs;
            };
        }
    }
} 
</pre>
<div class="preview">
<pre class="js">using&nbsp;Bing.Maps;&nbsp;
using&nbsp;Microsoft.Maps.SpatialToolbox;&nbsp;
using&nbsp;Microsoft.Maps.SpatialToolbox.Bing;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;Windows.UI.Xaml.Controls;&nbsp;
&nbsp;
namespace&nbsp;HeatMapTestApp&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;sealed&nbsp;partial&nbsp;class&nbsp;MainPage&nbsp;:&nbsp;Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;LocationCollection&nbsp;locs;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span><span class="js__operator">this</span>.InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Loaded&nbsp;&#43;=&nbsp;(s,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locs&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;LocationCollection();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Add&nbsp;location&nbsp;data&nbsp;to&nbsp;collection&hellip;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.ParentMap&nbsp;=&nbsp;MyMap;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.Locations&nbsp;=&nbsp;locs;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span><span class="js__brace">}</span><span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports Bing.Maps

Public NotInheritable Class MainPage
    Inherits Page

    Private layer As HeatMapLayer
    Private locs As LocationCollection

    Public Sub New()
        InitializeComponent()

        AddHandler MyMap.Loaded, Sub()
                                     locs = New LocationCollection()

                                     'Add location data to collection&hellip;

                                     layer.ParentMap = MyMap
                                     layer.Locations = locs
                                 End Sub
    End Sub
End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;Bing.Maps&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">NotInheritable</span><span class="visualBasic__keyword">Class</span>&nbsp;MainPage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Page&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;layer&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;HeatMapLayer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;locs&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;LocationCollection&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">AddHandler</span>&nbsp;MyMap.Loaded,&nbsp;<span class="visualBasic__keyword">Sub</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locs&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;LocationCollection()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Add&nbsp;location&nbsp;data&nbsp;to&nbsp;collection&hellip;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.ParentMap&nbsp;=&nbsp;MyMap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.Locations&nbsp;=&nbsp;locs&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Sub</span><span class="visualBasic__keyword">End</span><span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>Alternatively you can create the heat map completely from code and add it as a child of the map. The following is an example of how to add a
<strong>HeatMapLayer</strong> to Bing Maps using code.&nbsp;</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">using Bing.Maps;
using Microsoft.Maps.SpatialToolbox;
using Microsoft.Maps.SpatialToolbox.Bing;
using System;
using Windows.UI.Xaml.Controls;

namespace HeatMapTestApp
{
    public sealed partial class MainPage : Page
    {
        private HeatMapLayer layer;
        private LocationCollection locs;

        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded &#43;= (s, e) =&gt;
            {
                locs = new LocationCollection();

                //Add location data to collection&hellip;

                layer = new HeatMapLayer()
                {
                    ParentMap = MyMap,
                    Locations = locs,
                    Radius = 2500
                };

                MyMap.Children.Add(layer);
            };
        }
    }
} 
</pre>
<div class="preview">
<pre class="js">using&nbsp;Bing.Maps;&nbsp;
using&nbsp;Microsoft.Maps.SpatialToolbox;&nbsp;
using&nbsp;Microsoft.Maps.SpatialToolbox.Bing;&nbsp;
using&nbsp;System;&nbsp;
using&nbsp;Windows.UI.Xaml.Controls;&nbsp;
&nbsp;
namespace&nbsp;HeatMapTestApp&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;sealed&nbsp;partial&nbsp;class&nbsp;MainPage&nbsp;:&nbsp;Page&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;HeatMapLayer&nbsp;layer;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;private&nbsp;LocationCollection&nbsp;locs;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;public&nbsp;MainPage()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.InitializeComponent();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__operator">this</span>.Loaded&nbsp;&#43;=&nbsp;(s,&nbsp;e)&nbsp;=&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locs&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;LocationCollection();&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__sl_comment">//Add&nbsp;location&nbsp;data&nbsp;to&nbsp;collection&hellip;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer&nbsp;=&nbsp;<span class="js__operator">new</span>&nbsp;HeatMapLayer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ParentMap&nbsp;=&nbsp;MyMap,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Locations&nbsp;=&nbsp;locs,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Radius&nbsp;=&nbsp;<span class="js__num">2500</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyMap.Children.Add(layer);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__brace">}</span>&nbsp;
<span class="js__brace">}</span>&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Imports Bing.Maps
Imports Microsoft.Maps.SpatialToolbox
Imports Microsoft.Maps.SpatialToolbox.Bing

Public NotInheritable Class MainPage
    Inherits Page

    Private layer As HeatMapLayer
    Private locs As LocationCollection

    Public Sub New()
        InitializeComponent()

        AddHandler MyMap.Loaded, Sub()
                                     locs = New LocationCollection()

                                     'Add location data to collection&hellip;

                                     layer = New HeatMapLayer()
                                     layer.ParentMap = MyMap
                                     layer.Locations = locs
                                     layer.Radius = 2500

                                     MyMap.Children.Add(layer)
                                 End Sub
    End Sub
End Class
</pre>
<div class="preview">
<pre class="js">Imports&nbsp;Bing.Maps&nbsp;
Imports&nbsp;Microsoft.Maps.SpatialToolbox&nbsp;
Imports&nbsp;Microsoft.Maps.SpatialToolbox.Bing&nbsp;
&nbsp;
Public&nbsp;NotInheritable&nbsp;Class&nbsp;MainPage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Inherits&nbsp;Page&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;layer&nbsp;As&nbsp;HeatMapLayer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;locs&nbsp;As&nbsp;LocationCollection&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Public&nbsp;Sub&nbsp;New()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AddHandler&nbsp;MyMap.Loaded,&nbsp;Sub()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;locs&nbsp;=&nbsp;New&nbsp;LocationCollection()&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Add&nbsp;location&nbsp;data&nbsp;to&nbsp;collection&hellip;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer&nbsp;=&nbsp;New&nbsp;HeatMapLayer()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.ParentMap&nbsp;=&nbsp;MyMap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.Locations&nbsp;=&nbsp;locs&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;layer.Radius&nbsp;=&nbsp;<span class="js__num">2500</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MyMap.Children.Add(layer)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub&nbsp;
End&nbsp;Class&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
