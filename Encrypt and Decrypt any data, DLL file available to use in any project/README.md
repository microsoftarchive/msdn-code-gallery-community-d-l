# Encrypt and Decrypt any data, DLL file available to use in any project
## Requires
- Visual Studio 2008
## License
- Apache License, Version 2.0
## Technologies
- Encryption in VB
- DLL file to use in VB
## Topics
- Encryption/Decryption
- DLL example
## Updated
- 01/09/2013
## Description

<h1>Introduction</h1>
<p><em>It is simple and Excellent Encryption TOOL for developers who need to store data in encrypted form. In databases, if you do not want to store data directly, you can encrypt those data with this DLL reference and store it in database. when you want to
 read the data again you can decrypt for normal read and write. </em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Are there special requirements or instructions for building the sample?</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em><em>It is simple and Excellent Encryption TOOL for developers who need to store data in encrypted form. In databases, if you do not want to store data directly, you can encrypt those data with this DLL reference and store it in database. when you want
 to read the data again you can decrypt for normal read and write. </em></em></p>
<p><em><em>&nbsp;</em></em></p>
<p><em><em>There is a DLL file by name EncryptS, which need to add as reference in&nbsp; your project and by using the code you will be able to encrypt and decrypt any data.
</em></em></p>
<p><em><em>I have added project source code here,&nbsp;you may download. </em></em></p>
<p><em>The project Contains&nbsp;a form with three text boxes and three buttions.
</em></p>
<p><em>Add reference &quot;EncryptS&quot; to your project and see the below code how to work with.
</em></p>
<p><em>It is free code can be used in any project of Visual Basic. </em></p>
<p><em><em>It is free code can be used in any project of Visual Basic. </em></em></p>
<p><em><em>It is free code can be used in any project of Visual Basic. </em></em></p>
<p><em>Enjoy....&nbsp;</em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__com">'&nbsp;I&nbsp;made&nbsp;DLL&nbsp;file&nbsp;with&nbsp;encyption&nbsp;maths,&nbsp;that&nbsp;can&nbsp;be&nbsp;used&nbsp;in&nbsp;any&nbsp;VB&nbsp;or&nbsp;.Net&nbsp;application&nbsp;free.&nbsp;</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;I&nbsp;have&nbsp;included&nbsp;a&nbsp;sample&nbsp;project&nbsp;with&nbsp;DLL&nbsp;file,&nbsp;Please&nbsp;refer.&nbsp;Do&nbsp;not&nbsp;forget&nbsp;to&nbsp;add&nbsp;reference&nbsp;to&nbsp;your&nbsp;project.&nbsp;Reference&nbsp;is&nbsp;&nbsp;&quot;EncryptS&quot;.&nbsp;</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'The&nbsp;code&nbsp;is&nbsp;as&nbsp;follows:</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'&nbsp;Add&nbsp;three&nbsp;textboxes&nbsp;and&nbsp;three&nbsp;Buttons&nbsp;to&nbsp;your&nbsp;form</span>&nbsp;
<span class="visualBasic__com">'&nbsp;Add&nbsp;reference&nbsp;to&nbsp;your&nbsp;project&nbsp;&quot;EncryptS&quot;&nbsp;DLL&nbsp;file</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button1.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncryptS.UniCod.txt2Encrypt&nbsp;=&nbsp;TextBox1.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncryptS.UniCod.EncryptNow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox2.Text&nbsp;=&nbsp;EncryptS.UniCod.EncryptedText&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button2_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button2.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncryptS.UniCod.txt2Decrypt&nbsp;=&nbsp;TextBox2.Text&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;EncryptS.UniCod.DecryptNow()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TextBox3.Text&nbsp;=&nbsp;EncryptS.UniCod.DecryptedText&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button3_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;Button3.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;TextBox1.Text&nbsp;=&nbsp;TextBox3.Text&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Successfull&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Failed&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'You&nbsp;can&nbsp;use&nbsp;this&nbsp;DLL&nbsp;file&nbsp;and&nbsp;add&nbsp;reference&nbsp;to&nbsp;any&nbsp;of&nbsp;your&nbsp;project&nbsp;and&nbsp;encrypt&nbsp;any&nbsp;data&nbsp;and&nbsp;decrypt&nbsp;it&nbsp;same&nbsp;time.&nbsp;</span>&nbsp;
&nbsp;
&nbsp;
Thanks&nbsp;for&nbsp;using&nbsp;this&nbsp;help&nbsp;line.&nbsp;Enjoy...</pre>
</div>
</div>
</div>
