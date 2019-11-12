# Example of math expressions, variables, and if statements
## Requires
- Visual Studio 2013
## License
- MS-LPL
## Technologies
- C#
- C++
- F#
- VB.Net
## Topics
- User Interface
## Updated
- 02/07/2015
## Description

<h1>Introduction</h1>
<p><span style="font-size:x-small">Have you just installed Visual Studio and are ready to begin your first program? Then this is the sample for you. This is a basic example of some basic functions in C# C&#43;&#43; VB or F#. These basic skills are necessary for complex
 C# VB C&#43;&#43; or F#&nbsp;programming.</span></p>
<p><span style="font-size:20px; font-weight:bold">Building the Sample</span></p>
<p>To run this you will need Visual Studio 2013 or Visual Studio 2013 Express installed. They can be downloaded
<a href="http://www.microsoft.com/visualstudio/11/en-us/downloads#vs">here</a>. To run it open the .sln file then hit f5.</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>This sample solves the program by creating a small interface in which you can choose to compare two numbers, or solve a mathematical equation with them. This sample&nbsp;explains string variables and integer variables, if equal, greater than, less than,&nbsp;greater
 than or equal, less than or equal, and not equal statements, and the addition, subtraction, multiplication, and division of numbers. Then you can look at the code and see what has happened. The interface is a collection of radioboxes, asking for operation,
 textboxes, for the numbers, and a picturebox, to show the relationship between the two numbers.</p>
<p><em>This is a small example of what happens when you click&nbsp;the add radiobox.</em></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span><span>Visual Basic</span><span>C&#43;&#43;</span><span>F#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span><span class="hidden">vb</span><span class="hidden">cplusplus</span><span class="hidden">fsharp</span>




<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;radioButton1_CheckedChanged(<span class="cs__keyword">object</span>&nbsp;sender,&nbsp;EventArgs&nbsp;e)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;x&nbsp;=&nbsp;<span class="cs__keyword">this</span>.textBox1.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;y&nbsp;=&nbsp;<span class="cs__keyword">this</span>.textBox2.Text;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(x&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;<span class="cs__com">//See&nbsp;if&nbsp;x&nbsp;has&nbsp;no&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x&nbsp;=&nbsp;<span class="cs__string">&quot;0&quot;</span>;&nbsp;<span class="cs__com">//Set&nbsp;x&nbsp;to&nbsp;0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(y&nbsp;==&nbsp;<span class="cs__string">&quot;&quot;</span>)&nbsp;<span class="cs__com">//See&nbsp;if&nbsp;x&nbsp;has&nbsp;no&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;y&nbsp;=&nbsp;<span class="cs__string">&quot;0&quot;</span>;&nbsp;<span class="cs__com">//Set&nbsp;y&nbsp;to&nbsp;0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;x_number&nbsp;=&nbsp;Convert.ToInt32(x);&nbsp;<span class="cs__com">//Converts&nbsp;the&nbsp;string&nbsp;x&nbsp;to&nbsp;a&nbsp;number&nbsp;then&nbsp;stores&nbsp;it&nbsp;in&nbsp;x_number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;y_number&nbsp;=&nbsp;Convert.ToInt32(y);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">int</span>&nbsp;random&nbsp;=&nbsp;x_number&nbsp;&#43;&nbsp;y_number;&nbsp;<span class="cs__com">//Sets&nbsp;the&nbsp;integer&nbsp;variable&nbsp;random&nbsp;to&nbsp;the&nbsp;value&nbsp;of&nbsp;x_number&nbsp;plus&nbsp;y_number</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">string</span>&nbsp;random_string&nbsp;=&nbsp;Convert.ToString(random);&nbsp;<span class="cs__com">//Converts&nbsp;the&nbsp;integer&nbsp;random&nbsp;to&nbsp;the&nbsp;string&nbsp;random_string</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">this</span>.label3.Text&nbsp;=&nbsp;random_string;&nbsp;
}</pre>
</div>
</div>
</div>
<h1><span><img id="80359" src="80359-capture.jpg" alt="" width="533" height="309"></span></h1>
<p><em>This is a picture of the C# interface</em></p>
<h1><span>Source Code Files</span></h1>
<p><span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C#</span></p>
<ul>
<li><em>Program.cs - the program that first runs</em> </li><li><em>Form1.Designer.cs - the program to design the form</em> </li><li><em>Form1.cs - the program that controls the interface</em> </li></ul>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; C&#43;&#43;</p>
<ul>
<li><em>Program.cpp - the program that controls the interface</em> </li><li><em>Resource.rc - the script that handles the resources</em> </li><li><em>Header.h - the header to Program.cpp</em> </li></ul>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VB</p>
<ul>
<li><em>Form1.Designer.vb - the program to design the form</em> </li><li><em>Form1.vb - the program that controls the interface</em> </li></ul>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;F#</p>
<ul>
<li><em>Program.fs - the program that controls the interface </em></li></ul>
<p><em>&nbsp;</em></p>
<h1>More Information</h1>
<p>For more information on this sample, please feel free to ask questions on the Q&amp;A. Any feedback will be appreciated.</p>
