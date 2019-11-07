# Draw Rectangles on Bing Maps WPF
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- WPF
- Bing Maps
## Topics
- WPF
- Bing Maps
- Bing Maps Control for WPF
## Updated
- 02/03/2016
## Description

<h1>Introduction</h1>
<p>This code sample shows how to draw rectangles on the Bing Maps WPF control using the mouse or touch. To do this, several mouse events are added to the map; left button down/up, mouse move, touch move. Additionally the maps ViewChangeOnFrame is used to lock
 the center of the map so as to disable panning when dragging out a rectangle with the mouse/touch.</p>
<p>Take a look at the Bing Maps blog for other great examples of how to use Bing Maps:
<a href="http://blogs.bing.com/maps">http://blogs.bing.com/maps</a><em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>Open the MainWindow.xaml file and add your Bing Maps key to the map where it says YOUR_BING_MAPS_KEY.</p>
<div></div>
<div></div>
<div>If you do not have a Bing Maps key you can get ne by first creating a Bing Maps account and then a key as documented here:</div>
<div></div>
<div><a href="http://msdn.microsoft.com/en-us/library/gg650598.aspx">http://msdn.microsoft.com/en-us/library/gg650598.aspx</a></div>
<div><a href="http://msdn.microsoft.com/en-us/library/ff428642.aspx">http://msdn.microsoft.com/en-us/library/ff428642.aspx</a></div>
<p>This sample uses the Bing Maps WPF control. It pulls in the required libraries from Nuget here:&nbsp;<a href="http://www.nuget.org/packages/Microsoft.Maps.MapControl.WPF/">http://www.nuget.org/packages/Microsoft.Maps.MapControl.WPF/</a>&nbsp;&nbsp;</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To draw a rectangle first press the button that says &quot;Start Drawing&quot;. This will add all the required map events. Simply press the button again when you want to exit drawing mode.</p>
<p>Here is a screenshot of the finished app with a rectangle that has just been drawn on it.</p>
<p><img width="931" height="691" id="148137" src="148137-wpfrectangle.png" alt="" style="width:550px; height:447px"></p>
<p><em><br>
</em></p>
