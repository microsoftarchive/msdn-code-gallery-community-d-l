# Fancy Custom Label Class (LabelEx)
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Controls
- Graphics
- C#
- Visual Studio 2008
- Class Library
- Windows Forms
- .NET Framework 3.5 SP1
- themes
- custom controls
- .NET Framework
- Visual Basic .NET
- Visual basic
- Visual Basic.NET
- VB.Net
- Image manipulation
- Library
- C# Language
- Classes
- WinForms
- Graphics Functions
- vb2008
- Microsoft .NET Framework 3.5 SP1
- System.Drawing.Drawing2D
- other
- extended controls
- DLL file to use in VB
- Class Inheritance
## Topics
- Controls
- Graphics
- C#
- Class Library
- custom controls
- Windows Form Controls
- 2d graphics
- Visual Basic .NET
- Image manipulation
- DLL
- Drawing
- Paint
- Libraries
- Properties
- Classes
- Form controls
- Windows Forms Controls
- Graphics Functions
- System.Drawing.Drawing2D
- Transforms
- Design &amp; Implementation
## Updated
- 04/20/2015
## Description

<h1>Introduction</h1>
<p><em><span style="font-size:small">If you would like to add some fancy looking text to your windows forms application then adding the LabelEx class to your application or Toolbox will help make it a snap. Designed to replace the plain look of a standard Label
 when you want a fancy look to match your applications theme. Here is just some idea of the looks you can get.</span></em></p>
<p><em><span style="font-size:small"><img id="115872" src="http://i1.code.msdn.s-msft.com/fancy-custom-label-class-ff18dbd1/image/file/115872/1/demoimage.png" alt="" width="725" height="575"><br>
</span></em></p>
<h1><span>Building the Sample</span></h1>
<p><em><span style="font-size:small">This was built using VS2008 on an x86 machine targeting .Net 3.5</span></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span style="font-size:small">The LabelEx class is a custom class that inherits &quot;Control&quot; so that i could start with a blank slate (so to say) and add the properties that i wanted it to have and make it look the way i wanted it to also. That involved a lot
 of Drawing and Drawing2D graphics needed to be used to draw the LabelEx control according to how the properties are set.<br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small">&nbsp;You can add one to your project a few different ways and i will explain 2 of them. The first way is to simply add a class to your current windows form project. You can do that by following these steps.</span></p>
<ol>
<li><span style="font-size:small">Open or create your windows form project in VB.Net</span>
</li><li><span style="font-size:small">On the VB menu click on (<strong>Project</strong>) and then select (<strong>Add Class...</strong>)</span>
</li><li><span style="font-size:small">Name the class <strong>LabelEx</strong> and click (<strong>OK</strong>)</span>
</li><li><span style="font-size:small">Select and copy all the code shown below</span>
</li><li><span style="font-size:small">Select all the code in the new empty class and then paste the code in.</span>
</li><li><span style="font-size:small">Go to the VB menu and click (<strong>Build</strong>) and select (<strong>Build</strong>
<em>NameOfYourProject</em>) or (<strong>Build Solution</strong>) if your using C#.</span>
</li></ol>
<p><span style="font-size:small">Now go to the Forms <strong>[Design]</strong> tab and you should see a control called
<strong>LabelEx</strong> in your Toolbox that you can drag onto your form and set its proprties just like any other control. The LabelEx control will only be available in the Toolbox for the project that you add one to.<br>
</span></p>
<p>&nbsp;</p>
<p>&nbsp;<span style="font-size:small">The second way that i will explain is adding the
<strong>LabelEx</strong> control rite to the Toolbox so that you don`t need to add a class and the code to your project every time you want to use one on a different project</span>.
<span style="font-size:small">It will always be in the toolbox so that you can drag one or more onto any project you have opened.</span></p>
<p><span style="font-size:small">&nbsp;For this you will need to create a <strong>
Class Library</strong> project using the LabelEx class code below and build the dll file first, or you can download the LabelEx Demo Project which contains a Class Library project that i have already built the dll file for (Located in the Release folder). If
 you want to build a Class Library project and build the dll yourself you will see the note at the top of the code for adding References that you will need to follow. Ether way you do it you will need the .dll file so, make sure you have it ready.<br>
</span></p>
<ol>
<li><span style="font-size:small">Go to the VB menu and click (<strong>Tools</strong>), then select (<strong>Choose Toolbox Items...</strong>)</span>
</li><li><span style="font-size:small">When the Dialog window opens click (<strong>Browse</strong>)</span>
</li><li><span style="font-size:small">Browse to the dll file you created or the one in the LabelEx Project`s Release folder and select it. Press (Ok).<br>
</span></li></ol>
<p><span style="font-size:small">&nbsp;Now the LabelEx control is added to your Toolbox so that you can drag one or more onto any project you want without the hassle of adding a class and the code to every project you would like to use one on.
<br>
</span></p>
<p>&nbsp;</p>
<p><br>
<span style="text-decoration:underline"><strong><span style="font-size:small">The LabelEx Class Code:
</span></strong></span><em><br>
</em></p>
<div class="endscriptcode">&nbsp;</div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>


<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;System&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.ComponentModel&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Drawing.Drawing2D&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Windows.Forms&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;LabelEx&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Inherit&nbsp;the&nbsp;methods,&nbsp;properties,&nbsp;and&nbsp;events&nbsp;from&nbsp;the&nbsp;Control&nbsp;base&nbsp;class.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;Control&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Add&nbsp;all&nbsp;of&nbsp;the&nbsp;Property&nbsp;Backing&nbsp;Feilds&nbsp;for&nbsp;the&nbsp;Properties&nbsp;added&nbsp;to&nbsp;the&nbsp;LabelEx&nbsp;class</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_OutLinePen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BorderPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.Black)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_CenterBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(Color.White)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BackgroundBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(Color.Transparent)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_BorderStyle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;BorderType&nbsp;=&nbsp;BorderType.None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_Image&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ImageAlign&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;=&nbsp;ContentAlignment.MiddleCenter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextAlign&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;=&nbsp;ContentAlignment.MiddleCenter&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextPatternImage&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_TextPatternImageLayout&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PatternLayout&nbsp;=&nbsp;PatternLayout.Stretch&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowBrush&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;SolidBrush(Color.FromArgb(<span class="visualBasic__number">128</span>,&nbsp;Color.Black))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowPen&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Pen(Color.FromArgb(<span class="visualBasic__number">128</span>,&nbsp;Color.Black))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowColor&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;=&nbsp;Color.Black&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShowTextShadow&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowPosition&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowArea&nbsp;=&nbsp;ShadowArea.BottomRight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowDepth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowTransparency&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">128</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ShadowStyle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowDrawingType&nbsp;=&nbsp;ShadowDrawingType.FillShadow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_ForeColorTransparency&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">255</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;_OutlineThickness&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Declare&nbsp;the&nbsp;Enums&nbsp;used&nbsp;for&nbsp;some&nbsp;of&nbsp;the&nbsp;special&nbsp;selections&nbsp;we&nbsp;want&nbsp;to&nbsp;use&nbsp;for&nbsp;some&nbsp;of&nbsp;the&nbsp;properties</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;BorderTypes&nbsp;used&nbsp;for&nbsp;the&nbsp;Labels&nbsp;BorderStyle.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;BorderType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;None&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Squared&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Rounded&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;layout&nbsp;styles&nbsp;used&nbsp;for&nbsp;the&nbsp;Labels&nbsp;TextPaternImage.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;PatternLayout&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Normal&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Center&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Stretch&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tile&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;areas&nbsp;used&nbsp;for&nbsp;the&nbsp;Labels&nbsp;ShadowPosition.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;ShadowArea&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TopLeft&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TopRight&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BottomLeft&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;BottomRight&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'''&nbsp;&lt;summary&gt;Enum&nbsp;of&nbsp;drawing&nbsp;types&nbsp;used&nbsp;for&nbsp;the&nbsp;Labels&nbsp;ShadowStyle.&lt;/summary&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;ShadowDrawingType&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawShadow&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;FillShadow&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Enum</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'In&nbsp;the&nbsp;constructor&nbsp;we&nbsp;set&nbsp;all&nbsp;the&nbsp;styles&nbsp;we&nbsp;want&nbsp;the&nbsp;LabelEx&nbsp;control&nbsp;to&nbsp;have&nbsp;when&nbsp;it&nbsp;is&nbsp;created.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'We&nbsp;also&nbsp;set&nbsp;a&nbsp;few&nbsp;properties&nbsp;that&nbsp;we&nbsp;want&nbsp;the&nbsp;control&nbsp;to&nbsp;have&nbsp;set&nbsp;by&nbsp;default&nbsp;when&nbsp;a&nbsp;new&nbsp;instance&nbsp;is&nbsp;created.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.OptimizedDoubleBuffer,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.UserPaint,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.ResizeRedraw,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.SetStyle(ControlStyles.SupportsTransparentBackColor,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Font&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Font(<span class="visualBasic__string">&quot;Comic&nbsp;Sans&nbsp;MS&quot;</span>,&nbsp;<span class="visualBasic__number">18</span>,&nbsp;FontStyle.Bold)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Size&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Size(<span class="visualBasic__number">130</span>,&nbsp;<span class="visualBasic__number">38</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.ForeColor&nbsp;=&nbsp;Color.White&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.BackColor&nbsp;=&nbsp;Color.Transparent&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Create&nbsp;all&nbsp;of&nbsp;the&nbsp;properties&nbsp;we&nbsp;want&nbsp;the&nbsp;control&nbsp;to&nbsp;have&nbsp;and&nbsp;Override&nbsp;the&nbsp;ones&nbsp;it&nbsp;already&nbsp;has&nbsp;if&nbsp;they&nbsp;need&nbsp;to&nbsp;be&nbsp;used&nbsp;for&nbsp;special&nbsp;reasons.&nbsp;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;background&nbsp;color&nbsp;of&nbsp;the&nbsp;Label.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Transparent&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BackColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.BackColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BackgroundBrush.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;center&nbsp;color&nbsp;of&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;White&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ForeColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.ForeColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;_ForeColorTransparency&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_CenterBrush.Color&nbsp;=&nbsp;Color.FromArgb(_ForeColorTransparency,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;A&nbsp;value&nbsp;between&nbsp;0&nbsp;and&nbsp;255&nbsp;that&nbsp;sets&nbsp;the&nbsp;transparency&nbsp;of&nbsp;the&nbsp;ForeColor.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__number">255</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ForeColorTransparency()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ForeColorTransparency&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;<span class="visualBasic__number">255</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">255</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;<span class="visualBasic__keyword">Me</span>.ForeColor&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ForeColorTransparency&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_CenterBrush.Color&nbsp;=&nbsp;Color.FromArgb(value,&nbsp;<span class="visualBasic__keyword">Me</span>.ForeColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Aligns&nbsp;the&nbsp;text&nbsp;to&nbsp;the&nbsp;left,&nbsp;right,&nbsp;top,&nbsp;or&nbsp;bottom&nbsp;of&nbsp;the&nbsp;Label.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ContentAlignment),&nbsp;<span class="visualBasic__string">&quot;MiddleCenter&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TextAlign()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_TextAlign&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextAlign&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;Image&nbsp;for&nbsp;the&nbsp;Label.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Image()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_Image&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_Image&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Aligns&nbsp;the&nbsp;Image&nbsp;to&nbsp;the&nbsp;left,&nbsp;right,&nbsp;top,&nbsp;or&nbsp;bottom.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ContentAlignment),&nbsp;<span class="visualBasic__string">&quot;MiddleCenter&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ImageAlign()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ImageAlign&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ImageAlign&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;outline&nbsp;color&nbsp;of&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Black&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;OutlineColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_OutLinePen.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_OutLinePen.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;thickness&nbsp;of&nbsp;the&nbsp;text&nbsp;outline.&nbsp;Limited&nbsp;to&nbsp;a&nbsp;number&nbsp;between&nbsp;1&nbsp;and&nbsp;10.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__number">1</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;OutlineThickness()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_OutlineThickness&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;the&nbsp;user&nbsp;set&nbsp;lower&nbsp;than&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;<span class="visualBasic__number">10</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">10</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;the&nbsp;user&nbsp;set&nbsp;higher&nbsp;than&nbsp;10</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_OutlineThickness&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_OutLinePen.Width&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowPen.Width&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;color&nbsp;of&nbsp;the&nbsp;Labels&nbsp;border.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Black&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BorderColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BorderPen.Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_BorderPen.Color&nbsp;<span class="visualBasic__com">'Set&nbsp;it&nbsp;back&nbsp;to&nbsp;the&nbsp;prior&nbsp;color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Alert&nbsp;the&nbsp;user&nbsp;that&nbsp;Color.Transparent&nbsp;is&nbsp;not&nbsp;supported&nbsp;for&nbsp;this&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;The&nbsp;border&nbsp;color&nbsp;does&nbsp;not&nbsp;support&nbsp;the&nbsp;Transparent&nbsp;color&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderPen.Color&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;style&nbsp;of&nbsp;the&nbsp;border&nbsp;around&nbsp;the&nbsp;Label.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(BorderType),&nbsp;<span class="visualBasic__string">&quot;None&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;BorderStyle()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;BorderType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_BorderStyle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;BorderType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_BorderStyle&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;An&nbsp;image&nbsp;used&nbsp;as&nbsp;a&nbsp;fill&nbsp;pattern&nbsp;for&nbsp;the&nbsp;center&nbsp;of&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TextPatternImage()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_TextPatternImage&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Bitmap)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextPatternImage&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;layout&nbsp;of&nbsp;the&nbsp;pattern&nbsp;image&nbsp;inside&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(PatternLayout),&nbsp;<span class="visualBasic__string">&quot;Stretch&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;TextPatternImageLayout()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PatternLayout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_TextPatternImageLayout&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;PatternLayout)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;Show&nbsp;a&nbsp;shadow&nbsp;behind&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">False</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShowTextShadow()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShowTextShadow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShowTextShadow&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;color&nbsp;of&nbsp;the&nbsp;shadow&nbsp;behind&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(Color),&nbsp;<span class="visualBasic__string">&quot;Black&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShadowColor()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShadowColor&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Color)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;=&nbsp;Color.Transparent&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;value&nbsp;=&nbsp;_ShadowBrush.Color&nbsp;<span class="visualBasic__com">'Set&nbsp;it&nbsp;back&nbsp;to&nbsp;the&nbsp;prior&nbsp;color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Alert&nbsp;the&nbsp;user&nbsp;that&nbsp;Color.Transparent&nbsp;is&nbsp;not&nbsp;supported&nbsp;for&nbsp;this&nbsp;property</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Throw</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Exception(<span class="visualBasic__string">&quot;The&nbsp;Shadow&nbsp;color&nbsp;does&nbsp;not&nbsp;support&nbsp;using&nbsp;Color.Transparent&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowColor&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowBrush.Color&nbsp;=&nbsp;Color.FromArgb(_ShadowTransparency,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowPen.Color&nbsp;=&nbsp;Color.FromArgb(_ShadowTransparency,&nbsp;value)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;position&nbsp;of&nbsp;the&nbsp;shadow&nbsp;behind&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ShadowArea),&nbsp;<span class="visualBasic__string">&quot;BottomRight&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShadowPosition()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowArea&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShadowPosition&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowArea)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowPosition&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;A&nbsp;value&nbsp;between&nbsp;1-10&nbsp;that&nbsp;controls&nbsp;the&nbsp;depth&nbsp;of&nbsp;the&nbsp;shadow&nbsp;behind&nbsp;the&nbsp;text.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__number">2</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShadowDepth()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShadowDepth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;user&nbsp;set&nbsp;this&nbsp;property&nbsp;lower&nbsp;than&nbsp;1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;<span class="visualBasic__number">10</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">10</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;user&nbsp;set&nbsp;this&nbsp;property&nbsp;higher&nbsp;than&nbsp;10</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowDepth&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;A&nbsp;value&nbsp;between&nbsp;0&nbsp;and&nbsp;255&nbsp;that&nbsp;sets&nbsp;the&nbsp;transparency&nbsp;of&nbsp;the&nbsp;shadow.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__number">128</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShadowTransparency()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShadowTransparency&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&lt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;user&nbsp;set&nbsp;this&nbsp;property&nbsp;lower&nbsp;than&nbsp;0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;value&nbsp;&gt;&nbsp;<span class="visualBasic__number">255</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;value&nbsp;=&nbsp;<span class="visualBasic__number">255</span>&nbsp;<span class="visualBasic__com">'Dont&nbsp;let&nbsp;user&nbsp;set&nbsp;this&nbsp;property&nbsp;higher&nbsp;than&nbsp;255</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowTransparency&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowBrush.Color&nbsp;=&nbsp;Color.FromArgb(value,&nbsp;_ShadowColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowPen.Color&nbsp;=&nbsp;Color.FromArgb(value,&nbsp;_ShadowColor)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Category(<span class="visualBasic__string">&quot;Appearance&quot;</span>),&nbsp;Description(<span class="visualBasic__string">&quot;The&nbsp;style&nbsp;used&nbsp;to&nbsp;draw&nbsp;the&nbsp;shadow.&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Browsable(<span class="visualBasic__keyword">True</span>),&nbsp;DefaultValue(<span class="visualBasic__keyword">GetType</span>(ShadowDrawingType),&nbsp;<span class="visualBasic__string">&quot;FillShadow&quot;</span>)&gt;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ShadowStyle()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowDrawingType&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;_ShadowStyle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ShadowDrawingType)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;_ShadowStyle&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;the&nbsp;OnPaint&nbsp;overrides&nbsp;sub&nbsp;to&nbsp;paint&nbsp;the&nbsp;control&nbsp;to&nbsp;match&nbsp;how&nbsp;all&nbsp;the&nbsp;properties&nbsp;settings&nbsp;have&nbsp;been&nbsp;set&nbsp;by&nbsp;the&nbsp;user</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnPaint(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.Windows.Forms.PaintEventArgs.aspx" target="_blank" title="Auto generated link to System.Windows.Forms.PaintEventArgs">System.Windows.Forms.PaintEventArgs</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;e.Graphics&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Fill&nbsp;the&nbsp;background&nbsp;with&nbsp;the&nbsp;BackColor&nbsp;color</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillRectangle(_BackgroundBrush,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.ClientSize.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.ClientSize.Height))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;BackgroundImage&nbsp;property&nbsp;has&nbsp;been&nbsp;set&nbsp;to&nbsp;an&nbsp;image&nbsp;then&nbsp;draw&nbsp;the&nbsp;BackgroundImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawBackImage(e.Graphics)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;Image&nbsp;property&nbsp;has&nbsp;been&nbsp;set&nbsp;to&nbsp;an&nbsp;image&nbsp;then&nbsp;draw&nbsp;the&nbsp;image&nbsp;on&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_Image&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DrawImage(_Image,&nbsp;AlignImage(<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;Text&nbsp;property&nbsp;has&nbsp;been&nbsp;assigned&nbsp;any&nbsp;text&nbsp;then&nbsp;draw&nbsp;the&nbsp;text&nbsp;on&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Text.Trim&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Set&nbsp;the&nbsp;smothing&nbsp;mode&nbsp;of&nbsp;the&nbsp;graphics&nbsp;to&nbsp;make&nbsp;things&nbsp;look&nbsp;smother</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TextRenderingHint&nbsp;=&nbsp;Drawing.Text.TextRenderingHint.AntiAlias&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SmoothingMode&nbsp;=&nbsp;SmoothingMode.AntiAlias&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'The&nbsp;Drawing2D.GraphicsPath&nbsp;used&nbsp;for&nbsp;drawing&nbsp;and/or&nbsp;filling&nbsp;the&nbsp;text</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;pth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Drawing2D.GraphicsPath&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'The&nbsp;StringFormat&nbsp;used&nbsp;to&nbsp;align&nbsp;the&nbsp;text&nbsp;in&nbsp;the&nbsp;Label</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;sf&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;StringFormat&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;(ta)&nbsp;which&nbsp;is&nbsp;an&nbsp;integer&nbsp;value&nbsp;of&nbsp;the&nbsp;ContentAlignment&nbsp;integer&nbsp;enum&nbsp;to&nbsp;set&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Alignment&nbsp;of&nbsp;the&nbsp;text&nbsp;that&nbsp;will&nbsp;be&nbsp;added&nbsp;to&nbsp;the&nbsp;Drawing2D.GraphicsPath</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ta&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.TextAlign&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ta&nbsp;&lt;&nbsp;<span class="visualBasic__number">8</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.LineAlignment&nbsp;=&nbsp;StringAlignment.Near&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ta&nbsp;&lt;&nbsp;<span class="visualBasic__number">128</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.LineAlignment&nbsp;=&nbsp;StringAlignment.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ta&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(ta&nbsp;/&nbsp;<span class="visualBasic__number">16</span>,&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.LineAlignment&nbsp;=&nbsp;StringAlignment.Far&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ta&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(ta&nbsp;/&nbsp;<span class="visualBasic__number">256</span>,&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ta&nbsp;=&nbsp;ContentAlignment.TopLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.Alignment&nbsp;=&nbsp;StringAlignment.Near&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ta&nbsp;=&nbsp;ContentAlignment.TopCenter&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.Alignment&nbsp;=&nbsp;StringAlignment.Center&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ta&nbsp;=&nbsp;ContentAlignment.TopRight&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sf.Alignment&nbsp;=&nbsp;StringAlignment.Far&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Add&nbsp;the&nbsp;text&nbsp;to&nbsp;the&nbsp;Drawing2D.GraphicsPath&nbsp;using&nbsp;the&nbsp;StringFormat</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;pth.AddString(<span class="visualBasic__keyword">Me</span>.Text,&nbsp;<span class="visualBasic__keyword">Me</span>.Font.FontFamily,&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__keyword">Me</span>.Font.Style),&nbsp;<span class="visualBasic__keyword">CSng</span>((.DpiY&nbsp;*&nbsp;<span class="visualBasic__keyword">Me</span>.Font.Size)&nbsp;/&nbsp;<span class="visualBasic__number">72</span>),&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__keyword">Me</span>.Padding.Left,&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Top,&nbsp;(<span class="visualBasic__keyword">Me</span>.ClientSize.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.Padding.Left&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Right),&nbsp;(<span class="visualBasic__keyword">Me</span>.ClientSize.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.Padding.Top&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Bottom)),&nbsp;sf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;ShowTextShadow&nbsp;property&nbsp;is&nbsp;set&nbsp;to&nbsp;true&nbsp;then&nbsp;draw&nbsp;the&nbsp;shadow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShowTextShadow&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;the&nbsp;ShadowPosition&nbsp;property&nbsp;to&nbsp;set&nbsp;the&nbsp;Graphics.TranslateTransform&nbsp;to&nbsp;draw&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'shadow&nbsp;at&nbsp;the&nbsp;correct&nbsp;offset&nbsp;position.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(-_ShadowDepth,&nbsp;-_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopRight&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(&#43;_ShadowDepth,&nbsp;-_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.BottomLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(-_ShadowDepth,&nbsp;&#43;_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(&#43;_ShadowDepth,&nbsp;&#43;_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShadowStyle&nbsp;=&nbsp;ShadowDrawingType.DrawShadow&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;Drawing2D.GraphicsPath&nbsp;with&nbsp;the&nbsp;_ShadowPen&nbsp;that&nbsp;is&nbsp;set&nbsp;to&nbsp;the&nbsp;ShadowColor&nbsp;having&nbsp;the&nbsp;ShadowTransparency</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DrawPath(_ShadowPen,&nbsp;pth)&nbsp;<span class="visualBasic__com">'Draws&nbsp;the&nbsp;shadow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Fill&nbsp;the&nbsp;Drawing2D.GraphicsPath&nbsp;with&nbsp;the&nbsp;_ShadowBrush&nbsp;that&nbsp;is&nbsp;set&nbsp;to&nbsp;the&nbsp;ShadowColor&nbsp;having&nbsp;the&nbsp;ShadowTransparency</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillPath(_ShadowBrush,&nbsp;pth)&nbsp;<span class="visualBasic__com">'Draws&nbsp;the&nbsp;shadow</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Now&nbsp;use&nbsp;the&nbsp;Graphics.TranslateTransform&nbsp;to&nbsp;shift&nbsp;the&nbsp;graphics&nbsp;back&nbsp;in&nbsp;the&nbsp;opposite</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'direction&nbsp;before&nbsp;Drawing&nbsp;and&nbsp;Filling&nbsp;the&nbsp;Drawing2D.GraphicsPath&nbsp;again&nbsp;with&nbsp;text&nbsp;colors</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(&#43;(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>),&nbsp;&#43;(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopRight&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(-(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>),&nbsp;&#43;(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.BottomLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(&#43;(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>),&nbsp;-(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TranslateTransform(-(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>),&nbsp;-(_ShadowDepth&nbsp;*&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;TextPatternImage&nbsp;property&nbsp;has&nbsp;been&nbsp;set&nbsp;to&nbsp;an&nbsp;image&nbsp;then&nbsp;fill&nbsp;the&nbsp;center&nbsp;of&nbsp;the&nbsp;text&nbsp;with&nbsp;the&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'else&nbsp;the&nbsp;center&nbsp;will&nbsp;be&nbsp;filled&nbsp;with&nbsp;a&nbsp;soloid&nbsp;color&nbsp;of&nbsp;the&nbsp;ForeColor&nbsp;property.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_TextPatternImage&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;the&nbsp;TextPatternImageLayout&nbsp;property&nbsp;to&nbsp;resize&nbsp;and/or&nbsp;position&nbsp;the&nbsp;TextPatternImage</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;br&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Rectangle&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;PatternLayout.Normal&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;PatternLayout.Tile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;br&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.X)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.Y&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>),&nbsp;_TextPatternImage.Width&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;_TextPatternImage.Height&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;PatternLayout.Center&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((pth.GetBounds.X&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;&#43;&nbsp;((pth.GetBounds.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(_TextPatternImage.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;yy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((pth.GetBounds.Y&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;&#43;&nbsp;((pth.GetBounds.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(_TextPatternImage.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;br&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(xx,&nbsp;yy,&nbsp;_TextPatternImage.Width&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;_TextPatternImage.Height&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;PatternLayout.Stretch&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;br&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.X)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.Y&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>),&nbsp;<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.Width)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">CInt</span>(pth.GetBounds.Height)&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;patBmp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Bitmap(_TextPatternImage,&nbsp;br.Width,&nbsp;br.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;a&nbsp;TextureBrush&nbsp;with&nbsp;the&nbsp;TextPatternImage&nbsp;assigned&nbsp;as&nbsp;the&nbsp;texture&nbsp;image</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;tb&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;TextureBrush(patBmp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;TextPatternImageLayout&nbsp;property&nbsp;is&nbsp;not&nbsp;set&nbsp;to&nbsp;Tile&nbsp;then&nbsp;set&nbsp;the&nbsp;set&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'TextureBrush`s&nbsp;WrapMode&nbsp;to&nbsp;Clamp&nbsp;to&nbsp;stop&nbsp;it&nbsp;from&nbsp;tiling&nbsp;the&nbsp;image.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;_TextPatternImageLayout&nbsp;=&nbsp;PatternLayout.Tile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;tb.WrapMode&nbsp;=&nbsp;WrapMode.Clamp&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tb.TranslateTransform(br.X,&nbsp;br.Y)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Fill&nbsp;the&nbsp;GraphicsPath&nbsp;with&nbsp;the&nbsp;TextureBrush.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillPath(tb,&nbsp;pth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Fill&nbsp;the&nbsp;GraphicsPath&nbsp;with&nbsp;a&nbsp;soloid&nbsp;color&nbsp;of&nbsp;the&nbsp;ForeColor&nbsp;property.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.FillPath(_CenterBrush,&nbsp;pth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Draw&nbsp;the&nbsp;GraphicsPath&nbsp;with&nbsp;the&nbsp;OutlineColor.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DrawPath(_OutLinePen,&nbsp;pth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;BorderStyle&nbsp;property&nbsp;is&nbsp;other&nbsp;than&nbsp;None&nbsp;then&nbsp;call&nbsp;the&nbsp;DrawBorder&nbsp;sub&nbsp;to&nbsp;draw&nbsp;the&nbsp;border</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_BorderStyle&nbsp;&lt;&gt;&nbsp;BorderType.None&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DrawLabelBorder(e.Graphics,&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;-&nbsp;<span class="visualBasic__number">1</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;-&nbsp;<span class="visualBasic__number">1</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'A&nbsp;private&nbsp;sub&nbsp;used&nbsp;to&nbsp;position,&nbsp;resize,&nbsp;and&nbsp;draw&nbsp;the&nbsp;BackgroundImage&nbsp;according&nbsp;to&nbsp;the&nbsp;BackgroundImageLayout</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DrawBackImage(<span class="visualBasic__keyword">ByVal</span>&nbsp;g&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.None&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundImage,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Tile&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tc&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Math.Ceiling(<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;tr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Math.Ceiling(<span class="visualBasic__keyword">Me</span>.Height&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;y&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;tr&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;x&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;tc&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundImage,&nbsp;(x&nbsp;*&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width),&nbsp;(y&nbsp;*&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height),&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Center&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xx&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;yy&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundImage,&nbsp;xx,&nbsp;yy,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Stretch&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundImage,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImageLayout&nbsp;=&nbsp;ImageLayout.Zoom&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;meratio&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;imgratio&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Double</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Width&nbsp;/&nbsp;<span class="visualBasic__keyword">Me</span>.BackgroundImage.Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;imgrect&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__keyword">Me</span>.Width,&nbsp;<span class="visualBasic__keyword">Me</span>.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;imgratio&nbsp;&gt;&nbsp;meratio&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Width&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Width&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Height&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;imgratio)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;imgratio&nbsp;&lt;&nbsp;meratio&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Height&nbsp;=&nbsp;<span class="visualBasic__keyword">Me</span>.Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Width&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(<span class="visualBasic__keyword">Me</span>.Height&nbsp;*&nbsp;imgratio)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.X&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(imgrect.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;imgrect.Y&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>((<span class="visualBasic__keyword">Me</span>.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;(imgrect.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawImage(<span class="visualBasic__keyword">Me</span>.BackgroundImage,&nbsp;imgrect)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'A&nbsp;private&nbsp;sub&nbsp;used&nbsp;for&nbsp;drawing&nbsp;the&nbsp;Border&nbsp;part&nbsp;of&nbsp;the&nbsp;control</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DrawLabelBorder(<span class="visualBasic__keyword">ByVal</span>&nbsp;g&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Graphics,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;rec&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Rectangle)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;ShowTextShadow&nbsp;property&nbsp;is&nbsp;true&nbsp;and&nbsp;the&nbsp;Text&nbsp;property&nbsp;is&nbsp;not&nbsp;an&nbsp;empty&nbsp;string&nbsp;then&nbsp;because&nbsp;of&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'prior&nbsp;calls&nbsp;to&nbsp;the&nbsp;Graphics.TranslateTransform&nbsp;used&nbsp;for&nbsp;the&nbsp;shadow&nbsp;effect&nbsp;the&nbsp;Graphics&nbsp;must&nbsp;be&nbsp;shifted</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'back&nbsp;to&nbsp;its&nbsp;center&nbsp;position&nbsp;before&nbsp;drawing&nbsp;the&nbsp;border.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShowTextShadow&nbsp;<span class="visualBasic__keyword">And</span>&nbsp;<span class="visualBasic__keyword">Me</span>.Text.Trim&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.TranslateTransform(-_ShadowDepth,&nbsp;-_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.TopRight&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.TranslateTransform(&#43;_ShadowDepth,&nbsp;-_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;_ShadowPosition&nbsp;=&nbsp;ShadowArea.BottomLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.TranslateTransform(-_ShadowDepth,&nbsp;&#43;_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.TranslateTransform(&#43;_ShadowDepth,&nbsp;&#43;_ShadowDepth)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;the&nbsp;BorderStyle&nbsp;property&nbsp;is&nbsp;set&nbsp;to&nbsp;Rounded&nbsp;then&nbsp;draw&nbsp;the&nbsp;border&nbsp;with&nbsp;rounded&nbsp;corners</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'else&nbsp;just&nbsp;draw&nbsp;a&nbsp;Rectangle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.BorderStyle&nbsp;=&nbsp;BorderType.Rounded&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.SmoothingMode&nbsp;=&nbsp;SmoothingMode.AntiAlias&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;gp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Drawing2D.GraphicsPath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;rad&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(rec.Height&nbsp;/&nbsp;<span class="visualBasic__number">3</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;rec.Width&nbsp;&lt;&nbsp;rec.Height&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;rad&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(rec.Width&nbsp;/&nbsp;<span class="visualBasic__number">3</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.X,&nbsp;rec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">180</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.Right&nbsp;-&nbsp;(rad),&nbsp;rec.Y,&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">270</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.Right&nbsp;-&nbsp;(rad),&nbsp;rec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.AddArc(rec.X,&nbsp;rec.Bottom&nbsp;-&nbsp;(rad),&nbsp;rad,&nbsp;rad,&nbsp;<span class="visualBasic__number">90</span>,&nbsp;<span class="visualBasic__number">90</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;gp.CloseFigure()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawPath(_BorderPen,&nbsp;gp)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Using</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;g.DrawRectangle(_BorderPen,&nbsp;rec.X,&nbsp;rec.Y,&nbsp;rec.Width,&nbsp;rec.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'A&nbsp;private&nbsp;function&nbsp;used&nbsp;for&nbsp;calculating&nbsp;the&nbsp;rectagle&nbsp;area&nbsp;of&nbsp;the&nbsp;Label&nbsp;to&nbsp;draw&nbsp;the&nbsp;Image&nbsp;in</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;AlignImage(<span class="visualBasic__keyword">ByVal</span>&nbsp;Rect&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Rectangle)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Rectangle&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Use&nbsp;the&nbsp;value&nbsp;of&nbsp;the&nbsp;ContentAlignment&nbsp;assigned&nbsp;to&nbsp;the&nbsp;ImageAlign&nbsp;property&nbsp;to&nbsp;set&nbsp;the&nbsp;X&nbsp;and&nbsp;Y</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'values&nbsp;of&nbsp;the&nbsp;returned&nbsp;rectangle&nbsp;for&nbsp;the&nbsp;image.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;xp,&nbsp;yp&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ia&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ContentAlignment&nbsp;=&nbsp;_ImageAlign&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ia&nbsp;&lt;&nbsp;<span class="visualBasic__number">8</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yp&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Top&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ia&nbsp;&lt;&nbsp;<span class="visualBasic__number">128</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yp&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Rect.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(_Image.Height&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ia&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(ia&nbsp;/&nbsp;<span class="visualBasic__number">16</span>,&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;yp&nbsp;=&nbsp;Rect.Height&nbsp;-&nbsp;_Image.Height&nbsp;-&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Bottom&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ia&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(ia&nbsp;/&nbsp;<span class="visualBasic__number">256</span>,&nbsp;ContentAlignment)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ia&nbsp;=&nbsp;ContentAlignment.TopLeft&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xp&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;&#43;&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Left&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ia&nbsp;=&nbsp;ContentAlignment.TopCenter&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xp&nbsp;=&nbsp;<span class="visualBasic__keyword">CInt</span>(Rect.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;-&nbsp;<span class="visualBasic__keyword">CInt</span>(_Image.Width&nbsp;/&nbsp;<span class="visualBasic__number">2</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ElseIf</span>&nbsp;ia&nbsp;=&nbsp;ContentAlignment.TopRight&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xp&nbsp;=&nbsp;Rect.Width&nbsp;-&nbsp;_Image.Width&nbsp;-&nbsp;<span class="visualBasic__keyword">Me</span>.Padding.Right&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;Rectangle(xp,&nbsp;yp,&nbsp;_Image.Width,&nbsp;_Image.Height)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Need&nbsp;to&nbsp;use&nbsp;the&nbsp;OnTextChanged&nbsp;overrides&nbsp;sub&nbsp;to&nbsp;make&nbsp;the&nbsp;Label&nbsp;repaint&nbsp;itself&nbsp;when&nbsp;the&nbsp;text&nbsp;is&nbsp;changed</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;OnTextChanged(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="https://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>.Refresh()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.OnTextChanged(e)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Need&nbsp;to&nbsp;use&nbsp;the&nbsp;Dispose&nbsp;Overides&nbsp;sub&nbsp;to&nbsp;make&nbsp;sure&nbsp;all&nbsp;of&nbsp;the&nbsp;New&nbsp;brushes&nbsp;and&nbsp;pens&nbsp;created&nbsp;for&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'property&nbsp;backing&nbsp;feilds&nbsp;are&nbsp;disposed.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Dispose(<span class="visualBasic__keyword">ByVal</span>&nbsp;disposing&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._BackgroundBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._BorderPen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._CenterBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._OutLinePen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._ShadowBrush.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Me</span>._ShadowPen.Dispose()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">MyBase</span>.Dispose(disposing)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>&nbsp;<strong><span style="font-size:large">More Information</span><br>
</strong></p>
<p><span style="font-size:x-large"><span style="font-size:small">I have not found a good way to implement an AutoSize property yet which i mention because, you will notice that if the size of the LabelEx is not large enough for the size needed for the text
 you will notice the TextAlign property may not position the text as you expect. You may find using the Top, Left, Right, and Bottom Padding property works to offset the text in this case.</span></span></p>
<p>&nbsp;</p>
<p><strong><span style="font-size:large">Updates</span></strong></p>
<p><span style="font-size:x-large"><span style="font-size:small">5/31/14 11:40AM - I have updated the code to implement the BackgroundImageLayout property</span></span></p>
<p>&nbsp;</p>
<p><span style="font-size:x-large"><span style="font-size:small">6/01/14 9:00AM - I have added the C# code and demo project. The C# code had to be changed slightly but, it is the same class and does the same thing as the VB version.</span></span></p>
<p>&nbsp;</p>
<p><span style="font-size:x-large"><span style="font-size:small">2/28/15 8:06PM - Fixed bug with TextPatternImage property not repainting the label instantly.&nbsp; Changed spots in code to use property backing fields instead of the actual properties.</span></span></p>
<p>&nbsp;</p>
<p><span style="font-size:x-large"><span style="font-size:small">4/20/15 8:04AM - Fixed minor bug with Transparency do to the BackColor and added the default values for the properties.<br>
</span></span></p>
