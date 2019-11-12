# Gradient Background
## Requires
- Visual Studio 2015
## License
- MIT
## Technologies
- C#
## Topics
- Gradient Colouring
- Gradient Background
- Gradient
## Updated
- 05/25/2017
## Description

<div>
<h1>Gradient Background</h1>
<p>=====================================================================</p>
</div>
<h2><span style="font-size:large"><strong>Preface</strong></span></h2>
<p><span style="font-size:medium">In this chapter we want to write advanced Calculator program.</span></p>
<p><strong>____________________________________________________________________________________________</strong></p>
<h2><span style="font-size:large"><strong>Process</strong></span></h2>
<p><span style="font-size:medium">The following steps show how to make Gradient Background:</span></p>
<p><span style="font-size:medium">1. First, Click <strong>New Project</strong> in
<strong>Start Page</strong> or On <strong>File Menu</strong>.</span></p>
<p><span style="font-size:medium">2. In New Project Dialog, Click <strong>Windows</strong> On Left Pane and
<strong>Windows Forms Application</strong> On Middle Pane.</span></p>
<p><span style="font-size:medium"><img id="173777" src="173777-gradientbackground.png" alt=""></span></p>
<p><span style="font-size:medium">3. In The Using&rsquo;s Part, Write This:</span></p>
<address><span style="font-size:small"><span style="color:#0000ff">using </span><a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Drawing.Drawing2D.aspx" target="_blank" title="Auto generated link to System.Drawing.Drawing2D">System.Drawing.Drawing2D</a>;</span></address>
<p><span style="font-size:small">4. In The <strong>Paint </strong>Event of your sightly Object (Form, Panel and &hellip;) Write This:</span></p>
<address><span style="font-size:small">System.Drawing.<span style="color:#008000">Graphics
</span>graphics = e.Graphics;</span></address>
<address><span style="font-size:small">System.Drawing.<span style="color:#008000">Rectangle
</span>gradient_rectangle = <span style="color:#0000ff">new </span>System.Drawing.<span style="color:#008000">Rectangle</span>(0, 0,
<span style="color:#ffcc00">YourSightlyObject</span>.Width, <span style="color:#ffcc00">
YourSightlyObject</span>.Height);</span></address>
<address><span style="font-size:small">System.Drawing.<span style="color:#008000">Brush
</span>b = <span style="color:#0000ff">new</span> System.Drawing.Drawing2D.<span style="color:#008000">LinearGradientBrush</span>(gradient_rectangle,
<span style="color:#ffcc00">YourCustomColor</span>, <span style="color:#ffcc00">YourCustomColor</span>, 65f);</span></address>
<address><span style="font-size:small">graphics.FillRectangle(b, gradient_rectangle);</span></address>
<p><span style="font-size:medium">5. Now, Background of Your Sightly Object is Gradient Color.</span></p>
<h2><strong>Good Luck!</strong></h2>
<p><strong>_______________________________________________________________________________<br>
</strong></p>
<h2><span style="font-size:large"><strong>More Information</strong></span></h2>
<p><span style="font-size:medium">My Email-Address is pc_age82@yahoo.com.</span></p>
<p><span style="font-size:medium">To open&nbsp;this sample,&nbsp;you'll need&nbsp;Visual Studio&nbsp;2015.</span></p>
