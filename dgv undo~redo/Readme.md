# dgv undo~redo
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- C#
- VB.Net
## Topics
- DGV
- Undo/Redo
## Updated
- 09/25/2013
## Description

<p><span style="font-size:small"><img id="97056" src="97056-25-09-2013%2001.36.06.jpg" alt="" width="408" height="382"></span></p>
<p><span style="font-size:small">&nbsp;</span></p>
<p><span style="font-size:small">This is an Undo/Redo example for DataGridViews (unbound only in this example) that I wrote
</span><span style="font-size:small">to answer a request in the Samples Gallery. I wrote this in VB and C# in VS2008, which is my
</span><span style="font-size:small">preferred version of Visual Studio as it seems to run faster on my PC, and the code capabilities
</span><span style="font-size:small">and possibilities are usually sufficient for most programs I write.</span><br>
<span style="font-size:small">There is nothing in this project that is not compatible with, or that won't convert easily, to
</span><span style="font-size:small">VS2010 or VS2012.</span></p>
<p><span style="font-size:small">The program utilizes Stacks(of Object()()) to hold the Undo/Redo data. The data in each DataGridViewRow
</span><span style="font-size:small">can be retrieved and set, as or with, an Object array. Each item in the two Stacks is an array of Object
</span><span style="font-size:small">arrays, which contains a snapshot of the DataGridView at each Undo/Redo point.</span></p>
<p><span style="font-size:small">In the example I used two Extension methods and LINQ. There are several places in the code where I use these
</span><span style="font-size:small">Functions to avoid repeating the same code. Extension Functions are a neat way of achieving that, and using
</span><span style="font-size:small">LINQ in these Functions achieves in one line, that which would take six or seven lines without it.</span></p>
<p><span style="font-size:small">As always with my Samples Gallery submissions, I get a lot of enjoyment out of answering these requests and I appreciate any feedback or ratings and I strive to answer
</span><span style="font-size:small">any questions regarding this posting.</span></p>
