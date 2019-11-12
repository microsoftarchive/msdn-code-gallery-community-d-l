# JavaScript Runtime Hosting Sample
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- Javascript
- Chakra
## Topics
- JavaScript hosting
## Updated
- 12/05/2013
## Description

<p>This sample shows how to host the IE11 Chakra JavaScript runtime in a non-IE application.</p>
<p>The sample demonstrates the following tasks:</p>
<ol>
<li>
<p>Initializing the JavaScript runtime and creating an execution context.</p>
</li><li>
<p>Running scripts and handling values.</p>
</li><li>
<p>Creating host objects that scripts can interact with.</p>
</li><li>
<p>Creating callback functions to execution actions in the host.</p>
</li><li>
<p>Handling exceptions throw in JavaScript.</p>
</li><li>
<p>Initializing JavaScript debugging.</p>
</li><li>
<p>Handling profile events from the JavaScript engine.</p>
</li></ol>
<h3>Operating system requirements</h3>
<table>
<tbody>
<tr>
<th>Client</th>
<td><dt>Windows&nbsp;8.1</dt></td>
</tr>
<tr>
<th>Server</th>
<td><dt>Windows Server&nbsp;2012&nbsp;R2</dt></td>
</tr>
</tbody>
</table>
<h3>Build the sample</h3>
<ol>
<li>Start Visual Studio&nbsp;2013 and select <strong>File &gt; Open &gt; Project/Solution</strong>.
</li><li>Go to the directory in which you unzipped the sample. Go to the directory named for the sample, and double-click the Microsoft Visual Studio Solution (.sln) file.
</li><li>Press F6 or use <strong>Build &gt; Build Solution</strong> to build the sample.
</li></ol>
<h3>Run the sample</h3>
<p>To debug the app and then run it, press F5 or use <strong>Debug</strong> &gt; <strong>
Start Debugging</strong>. To run the app without debugging, press Ctrl&#43;F5 or use <strong>
Debug</strong> &gt; <strong>Start Without Debugging</strong>.</p>
<h3>Run the C&#43;&#43; sample with script debugging enabled</h3>
<p>To debug a script running in the C&#43;&#43; sample host, choose <strong>Project</strong>&nbsp;&gt;
<strong>Properties</strong>. Under <strong>Configuration Properties</strong>, choose
<strong>Debugging</strong>. Change the values of <strong>Debugger Type</strong>&nbsp;to
<strong>Script</strong>&nbsp;and choose <strong>OK</strong>. Note that while using script debugging, you cannot debug the host itself. To switch back to native code debugging, change
<strong>Debugger Type</strong>&nbsp;to <strong>Auto</strong>.</p>
<h3>Run the C#/VB sample with script debugging enabled</h3>
<p>Because the C# and VB project systems do not allow changing the debugger type to the script debugger, to debug a script running in the C# or VB sample hosts it is necessary to open the host executable directly. Having built the project, choose
<strong>File</strong> &gt; <strong>Open</strong>&nbsp;&gt; <strong>Project/Solution</strong>. Navigate to where the host executable was built (for example,
<strong>&lt;project directory&gt;\bin\Debug</strong>) and choose the host executable (for example,
<strong>chakrahost.exe</strong>). Choose <strong>Project</strong>&nbsp;&gt; <strong>
Properties</strong>. Change <strong>Debugger Type</strong>&nbsp;to <strong>Script</strong>&nbsp;and hit F5<strong>.</strong></p>
<p><strong><br>
</strong></p>
