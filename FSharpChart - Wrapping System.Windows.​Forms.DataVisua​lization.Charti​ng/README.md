# FSharpChart - Wrapping System.Windows.​Forms.DataVisua​lization.Charti​ng
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- Windows Forms
## Topics
- data visualization
- charting
- Chart Controls
## Updated
- 06/05/2013
## Description

<h2><strong>FSharp.Charting: The F# Charting Library</strong></h2>
<p><span style="font-size:small"><strong><span style="color:#333399">The new version of FSharp.Chart (formely FSharpChart) can now be found on GitHib at:
</span><a href="http://fsharp.github.io/FSharp.Charting/"></a><a href="http://fsharp.github.io/FSharp.Charting/">http://fsharp.github.io/FSharp.Charting/</a></strong></span></p>
<h2><strong>FSharpChart - Wrapping the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.DataVisualization.Charting.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.DataVisualization.Charting">System.Windows.Forms.DataVisualization.Charting</a> Charting Types</strong></h2>
<p>FSharpChart contains F#-friendly wrappers for the types in the <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.Windows.Forms.DataVisualization.Charting.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.DataVisualization.Charting">System.Windows.Forms.DataVisualization.Charting</a> namespace (<a href="http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.aspx">http://msdn.microsoft.com/en-us/library/system.windows.forms.datavisualization.charting.aspx</a>),
 making it easy to interactively chart data from F# Interactive.</p>
<h3><strong>Basic features</strong></h3>
<p>These methods make it easy to directly pipe data into a chart. Furthermore, the FSharpChart library adds a custom printer to F# Interactive which automatically opens each chart control in its own window.</p>
<p>Each chart control also has a context menu which makes it easy to copy the chart to the clipboard, save to a file, or view (and modify) detailed chart properties.</p>
<p>An introduction of the code can be found on the fsharp team blog at:<br>
<a href="http://blogs.msdn.com/b/fsharpteam/archive/2011/04/15/getting-started-with-fsharpchart.aspx">http://blogs.msdn.com/b/fsharpteam/archive/2011/04/15/getting-started-with-fsharpchart.aspx</a></p>
<p>A summary of some of the 0.5 features can be found at:<br>
<a href="http://blogs.msdn.com/b/mcsuksoldev/archive/2011/06/22/fsharpchart-new-features-and-code-drop-availability.aspx">http://blogs.msdn.com/b/mcsuksoldev/archive/2011/06/22/fsharpchart-new-features-and-code-drop-availability.aspx</a></p>
<p>A summary of the 0.55 features can be found here:</p>
<p><a href="http://blogs.msdn.com/b/carlnol/archive/2011/10/11/fsharpchart-new-release-available-version-0-55.aspx">http://blogs.msdn.com/b/carlnol/archive/2011/10/11/fsharpchart-new-release-available-version-0-55.aspx</a>&nbsp;</p>
<p>A summary of the 0.60 changes can be found here:</p>
<p><a href="http://blogs.msdn.com/b/carlnol/archive/2011/10/27/fsharpchart-release-supporting-stacked-charts-version-0-60.aspx">http://blogs.msdn.com/b/carlnol/archive/2011/10/27/fsharpchart-release-supporting-stacked-charts-version-0-60.aspx</a>&nbsp;</p>
<h3><strong>Version History:</strong></h3>
<p>0.2 - Base Version<br>
<br>
0.3 - Includes Clipboard and SaveAs Capabilities (supporting multiple file formats)<br>
<br>
0.4 - Property Change Events for Name, Title, Margin, Legend, and Custom properties.</p>
<p>0.5 - Support for 3D Charts and naming of data series for BoxPlot charts</p>
<p>0.55 - Support for defaults and ToolTip's in addition to some WPF samples</p>
<p>0.56 - Minor changes for additional With properties and WithSeries.Marker()</p>
<p>0.60 - Support for binding a StackedChart with multiple Data Series</p>
<p>A minor change has been added to support naming form windows with the chart type and for FastLines binding.<br>
<br>
In version 0.4 the solution is broken down into individual FS source files. The root directory of the ZIP download however still contains a FSX file containing all the source code in a single script file; FSharpChart.fsx.</p>
<p>Code is also available as a NuGet Package:</p>
<p><a href="http://www.nuget.org/List/Packages/MSDN.FSharpChart.dll">http://www.nuget.org/List/Packages/MSDN.FSharpChart.dll</a></p>
