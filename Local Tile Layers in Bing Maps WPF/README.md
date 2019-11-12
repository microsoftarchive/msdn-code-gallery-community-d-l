# Local Tile Layers in Bing Maps WPF
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- WPF
- Bing Maps
## Topics
- Bing Maps
- Bing Maps Control for WPF
- Tile Layers
## Updated
- 08/24/2015
## Description

<h1>Introduction</h1>
<p>Earlier this year the Bing Maps WPF control was updated with a number of performance and bug fixes. Most notably, navigating the map using touch works much better in Windows 8 than it did before. This update also increases the number of supported cultures
 from 15 to 117 and aligns with the same cultures supported by the Bing Maps Windows Store SDK which are documented
<a href="https://msdn.microsoft.com/en-us/library/dn306047.aspx">here</a>. One new feature is the ability to have a lot more control over tile layers. In the past tiles for a tile layer had to be hosted on a server in order to load them into the WPF map control.
 Now you can extend the <strong>TileSource</strong> class and load in tiles from local storage or generate them right in code. In this code sample we create a custom tile source that loads tiles from a local folder.</p>
<p>This code sample was written for this&nbsp;<a href="https://blogs.bing.com/maps/2015/08/24/local-tile-layers-in-bing-maps-wpf/">blog post</a>.</p>
<h1><span>Building the Sample</span></h1>
<p>Open the MainWindow.xaml file and add your Bing Maps key where it says YOUR_BING_MAPS_KEY.</p>
<div>If you do not have a Bing Maps key you can get ne by first creating a Bing Maps account and then a key as documented here:</div>
<div></div>
<div><a href="http://msdn.microsoft.com/en-us/library/gg650598.aspx">http://msdn.microsoft.com/en-us/library/gg650598.aspx</a></div>
<div><a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">http://msdn.microsoft.com/en-us/library/ff428642.aspx</a></div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>If you build and run the application you will see the map loads over a hospital in Essex, UK and renders a custom tile layer, that is hosted locally, over top the map.</p>
<p><img id="138999" src="138999-hospitalonmap.png" alt="" width="968" height="766" style="width:521px; height:370px"></p>
