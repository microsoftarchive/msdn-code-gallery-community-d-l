# ListView Printer
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- VB.Net
## Topics
- Listviews
## Updated
- 05/24/2016
## Description

<p><span style="font-size:small"><img id="74805" src="74805-18-01-2013%2003.33.47.jpg" alt="" width="315" height="359"></span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">This is a revised submission. The original wasn't working properly, although it was when i originally submitted it...</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">This is another dual language example I wrote not for a Samples Gallery request this time, but to answer another question in a different forum, and I thought it might be useful here on MSDN.</span><br>
<span style="font-size:small">The example is a demonstration application (in vb.net &#43; c#.net) that shows how to use the listViewPrinter
</span><span style="font-size:small">class I developed for printing Details View ListViews, with or without Border, GridLines, and Groups.</span></p>
<p><span style="font-size:small">The example application is set up to display a PrintPreviewDialog instead of printing immediately to the printer as I spent some time testing this &#43; the
</span><span style="font-size:small">PrintPreviewDialog is quicker (and cheaper:D). I used three ListViewGroups, and twenty six standard sized Columns in my example, but the class is written to
</span><span style="font-size:small">be dynamic in that it will work with any number or size of Column and any number of ListViewGroups.</span></p>
<p><span style="font-size:small">To use this class with your Listview, just add the class: listViewPrinter to your project, and call it like this:</span></p>
<p>&nbsp; <br>
<span style="font-size:small">Dim printer As New listViewPrinter(ListView1, New Point(50, 50), chkBorder.Checked, ListView1.Groups.Count &gt; 0, hLines.Checked, vLines.Checked, &quot;titleText&quot;)</span><br>
<span style="font-size:small">printer.print()</span></p>
<p><br>
<span style="font-size:small">the seven parameters are:</span></p>
<p></p>
<ul>
<li><span style="font-size:small">ListView - the ListView to print</span> </li><li><span style="font-size:small">Location = the origin for printing on the printed page</span>
</li><li><span style="font-size:small">Border - whether to print a border or not</span>
</li><li><span style="font-size:small">hasGroups - whether the ListView to print has Groups</span>
</li><li><span style="font-size:small">hLines - whether to print horizontal lines</span>
</li><li><span style="font-size:small">vLines - whether to print vertical lines</span>
</li><li><span style="font-size:small">Title - the title text to print</span> </li></ul>
<p></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p>&nbsp;</p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">&nbsp;</span></p>
