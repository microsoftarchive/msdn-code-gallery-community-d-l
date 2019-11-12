# Dynamic Plotting Of Graph Using VB.NET
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- threading
- VB.Net
- Graphics Functions
## Topics
- threading
- VB.Net
- Graphics Functions
## Updated
- 12/29/2011
## Description

<h1>Introduction</h1>
<p style="text-align:justify"><em>This application focusses on the basic concepts and power of graphics using Visual Studio.NET and Visual Basic as the programming language. This example plots the graph in the X/Y coordinate system using cartesian coordinate
 system. This application uses the Picturebox top left corner as point 0 of the Cartesian Coordinate System.</em></p>
<h1><span>Building the Sample</span></h1>
<p style="text-align:justify"><em>Just code or download the sample and run the application using F5 thus plots the graph using the grid lines spaces as input and entering the minimum value and maximum value for the function to generate the plotting values.</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p style="text-align:justify"><em>The application starts with the click on the button Draw Graph which creates a new thread and allocates it a priority that is below normal. The thread in turn calls the DrawGraph() method. The Drawgraph() method calls the NewValues()
 method which generates random numbers to be plotted on the graph between the range of minimum and maximum values. The PlotValue() function now generates grid lines which are horrizontally spaced lines as used to indicate X units on the graph. This gives best
 result when the gridspace is 10 so if you plot 10 or 100 it gives exact accurate results.</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span> <span class="visualBasic__keyword">Sub</span> btnGraph_Click(sender <span class="visualBasic__keyword">As</span> System.<span class="visualBasic__keyword">Object</span>, e <span class="visualBasic__keyword">As</span> <a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>) <span class="visualBasic__keyword">Handles</span> btnGraph.Click 
        <span class="visualBasic__keyword">If</span> m_GraphThread <span class="visualBasic__keyword">Is</span> <span class="visualBasic__keyword">Nothing</span> <span class="visualBasic__keyword">Then</span> 
            <span class="visualBasic__com">' The thread isn't running. Start it.</span> 
            AddStatus(<span class="visualBasic__string">&quot;Starting thread&quot;</span>) 
 
            m_GraphThread = <span class="visualBasic__keyword">New</span> Thread(<span class="visualBasic__keyword">AddressOf</span> DrawGraph) 
            m_GraphThread.Priority = ThreadPriority.BelowNormal 
            m_GraphThread.IsBackground = <span class="visualBasic__keyword">True</span> 
            m_GraphThread.Start() 
 
            AddStatus(<span class="visualBasic__string">&quot;Thread started&quot;</span>) 
 
            btnGraph.Text = <span class="visualBasic__string">&quot;Stop&quot;</span> 
        <span class="visualBasic__keyword">Else</span> 
            <span class="visualBasic__com">' The thread is running. Stop it.</span> 
            AddStatus(<span class="visualBasic__string">&quot;Stopping thread&quot;</span>) 
 
            m_GraphThread.Abort() 
            <span class="visualBasic__com">' m_GraphThread.Join()</span> 
            m_GraphThread = <span class="visualBasic__keyword">Nothing</span> 
 
            AddStatus(<span class="visualBasic__string">&quot;Thread stopped&quot;</span>) 
 
            btnGraph.Text = <span class="visualBasic__string">&quot;Start&quot;</span> 
        <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">If</span> 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
 
    <span class="visualBasic__keyword">Private</span> <span class="visualBasic__keyword">Sub</span> DrawGraph() 
        <span class="visualBasic__keyword">Try</span> 
            <span class="visualBasic__com">' Generate pseudo-random values.</span> 
            <span class="visualBasic__keyword">Dim</span> y <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = m_Y 
            <span class="visualBasic__keyword">Do</span> 
                <span class="visualBasic__com">' Generate the next value.</span> 
                NewValue() 
 
                <span class="visualBasic__com">' Plot the new value.</span> 
                PlotValue(y, m_Y) 
                y = m_Y 
            <span class="visualBasic__keyword">Loop</span> 
        <span class="visualBasic__keyword">Catch</span> ex <span class="visualBasic__keyword">As</span> Exception 
            AddStatus(<span class="visualBasic__string">&quot;[Thread] &quot;</span> &amp; ex.Message) 
        <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Try</span> 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
 
    <span class="visualBasic__com">' Generate the next value.</span> 
    <span class="visualBasic__keyword">Private</span> <span class="visualBasic__keyword">Sub</span> NewValue() 
        <span class="visualBasic__com">' Delay a bit before calculating the value.</span> 
        <span class="visualBasic__keyword">Dim</span> stop_time <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Date</span> = Now.AddMilliseconds(<span class="visualBasic__number">20</span>) 
        <span class="visualBasic__keyword">Do</span> <span class="visualBasic__keyword">While</span> Now &lt; stop_time 
        <span class="visualBasic__keyword">Loop</span> 
 
        <span class="visualBasic__com">' Calculate the next value.</span> 
        <span class="visualBasic__keyword">Dim</span> rnd <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">New</span> Random 
        m_Y = rnd.<span class="visualBasic__keyword">Next</span>(<span class="visualBasic__keyword">CInt</span>(txtMinValue.Text), <span class="visualBasic__keyword">CInt</span>(txtMaxValue.Text)) 
        <span class="visualBasic__com">'m_Y = rnd.Next(5, 70)</span> 
        <span class="visualBasic__keyword">If</span> m_Y &lt; <span class="visualBasic__number">0</span> <span class="visualBasic__keyword">Then</span> m_Y = <span class="visualBasic__number">0</span> 
        <span class="visualBasic__keyword">If</span> m_Y &gt;= picGraph.ClientSize.Height - <span class="visualBasic__number">1</span> <span class="visualBasic__keyword">Then</span> m_Y = picGraph.ClientSize.Height - <span class="visualBasic__number">1</span> 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
 
    <span class="visualBasic__keyword">Private</span> <span class="visualBasic__keyword">Delegate</span> <span class="visualBasic__keyword">Sub</span> PlotValueDelegate(<span class="visualBasic__keyword">ByVal</span> old_y <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span>, <span class="visualBasic__keyword">ByVal</span> new_y <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span>) 
 
    <span class="visualBasic__keyword">Private</span> <span class="visualBasic__keyword">Sub</span> PlotValue(<span class="visualBasic__keyword">ByVal</span> old_y <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span>, <span class="visualBasic__keyword">ByVal</span> new_y <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span>) 
        <span class="visualBasic__com">' See if we're on the worker thread and thus</span> 
        <span class="visualBasic__com">' need to invoke the main UI thread.</span> 
        <span class="visualBasic__keyword">If</span> <span class="visualBasic__keyword">Me</span>.InvokeRequired <span class="visualBasic__keyword">Then</span> 
            <span class="visualBasic__com">' Make arguments for the delegate.</span> 
            <span class="visualBasic__keyword">Dim</span> args <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Object</span>() = {old_y, new_y} 
 
            <span class="visualBasic__com">' Make the delegate.</span> 
            <span class="visualBasic__keyword">Dim</span> plot_value_delegate <span class="visualBasic__keyword">As</span> PlotValueDelegate 
            plot_value_delegate = <span class="visualBasic__keyword">AddressOf</span> PlotValue 
 
            <span class="visualBasic__com">' Invoke the delegate on the main UI thread.</span> 
            <span class="visualBasic__keyword">Me</span>.Invoke(plot_value_delegate, args) 
 
            <span class="visualBasic__com">' We're done.</span> 
            <span class="visualBasic__keyword">Exit</span> <span class="visualBasic__keyword">Sub</span> 
        <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">If</span> 
 
        <span class="visualBasic__com">' Make the Bitmap and Graphics objects.</span> 
        <span class="visualBasic__keyword">Dim</span> wid <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = picGraph.ClientSize.Width 
        <span class="visualBasic__keyword">Dim</span> hgt <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = picGraph.ClientSize.Height 
        <span class="visualBasic__keyword">Dim</span> bm <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">New</span> Bitmap(wid, hgt) 
        <span class="visualBasic__keyword">Dim</span> gr <span class="visualBasic__keyword">As</span> Graphics = Graphics.FromImage(bm) 
        <span class="visualBasic__keyword">Dim</span> m_Ymid <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> 
        <span class="visualBasic__keyword">Dim</span> GRID_STEP <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = Convert.ToInt32(txtGridSpacing.Text) <span class="visualBasic__com">'Assign Grid Spacing</span> 
        m_Ymid = hgt / <span class="visualBasic__number">2</span> 
        <span class="visualBasic__com">' Move the old data one pixel to the left.</span> 
        gr.DrawImage(picGraph.Image, -<span class="visualBasic__number">1</span>, <span class="visualBasic__number">0</span>) 
 
        <span class="visualBasic__com">' Erase the right edge and draw guide lines.</span> 
        gr.DrawLine(Pens.Blue, wid - <span class="visualBasic__number">1</span>, <span class="visualBasic__number">0</span>, wid - <span class="visualBasic__number">1</span>, hgt - <span class="visualBasic__number">1</span>) 
        <span class="visualBasic__keyword">For</span> i <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = m_Ymid <span class="visualBasic__keyword">To</span> picGraph.ClientSize.Height <span class="visualBasic__keyword">Step</span> GRID_STEP 
            gr.DrawLine(Pens.LightBlue, wid - <span class="visualBasic__number">2</span>, i, wid - <span class="visualBasic__number">1</span>, i) 
        <span class="visualBasic__keyword">Next</span> i 
        <span class="visualBasic__keyword">For</span> i <span class="visualBasic__keyword">As</span> <span class="visualBasic__keyword">Integer</span> = m_Ymid <span class="visualBasic__keyword">To</span> <span class="visualBasic__number">0</span> <span class="visualBasic__keyword">Step</span> -GRID_STEP 
            gr.DrawLine(Pens.LightBlue, wid - <span class="visualBasic__number">2</span>, i, wid - <span class="visualBasic__number">1</span>, i) 
        <span class="visualBasic__keyword">Next</span> i 
 
        <span class="visualBasic__com">' Plot a new pixel.</span> 
        gr.DrawLine(Pens.White, wid - <span class="visualBasic__number">2</span>, old_y, wid - <span class="visualBasic__number">1</span>, new_y) 
 
        <span class="visualBasic__com">' Display the result.</span> 
        picGraph.Image = bm 
        picGraph.Refresh() 
 
        gr.Dispose() 
    <span class="visualBasic__keyword">End</span> <span class="visualBasic__keyword">Sub</span> 
</pre>
</div>
</div>
</div>
<p style="text-align:justify"><em>This application is just an illustration of what wonders can be done with Graphics in realtime processing and threading usage in the application. This does not give good accurate visible results for negative values. When the
 application is run, it plots the graph from the right side of the screen sliding towards the left of the screen. Running the application produces the screen as shown below :
</em></p>
<p style="text-align:justify"><em>&nbsp;<img src="48126-pic1.jpg" alt="" width="890" height="488"></em></p>
