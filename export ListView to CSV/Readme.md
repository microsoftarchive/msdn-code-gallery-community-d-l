# export ListView to CSV
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- VB.Net
## Topics
- LINQ
- Strings
## Updated
- 01/14/2013
## Description

<p><span style="font-size:small"><img id="74624" src="74624-15-01-2013%2003.11.18.jpg" alt="" width="388" height="314"></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">Here's another proposed answer to a Samples Gallery request that I hope will answer the request either fully or at least partially.</span><br>
<span style="font-size:small">This example is written in vb.net (took just 10 minutes), and c#.net (took considerably longer, but I'm still learning c#).</span></p>
<p><span style="font-size:small">The program(s) demonstrate how to take all of the ColumnHeader's text &#43; the ListiewItem's and ListViewSubItem's text from a Details View ListView
</span><span style="font-size:small">and write that data out to an Excel CSV (comma separated values) file in a user chosen Directory in the PC's filesystem. Formatting the ListView
</span><span style="font-size:small">information as csv is achieved by querying first the Columns with LINQ, then querying the Items and SubItems again with LINQ, which returns an
</span><span style="font-size:small">array of strings for the ColumnHeaders and an array of array of strings for the ListiewItems and ListViewSubItems. These arrays are formatted into
</span><span style="font-size:small">a single string by joining first the headers with String.Join specifying the comma as the seperator, adding Environment.NewLine, then doing the same
</span><span style="font-size:small">for each Row, appending Environment.NewLine after each joined Row.
</span><br>
<span style="font-size:small">Once the formatted text is all joined together in one single string, it's simple to write it as the contents of a text file, specifying the .CSV file
</span><span style="font-size:small">extension, so the default editor for the newly written file will be Excel.</span></p>
