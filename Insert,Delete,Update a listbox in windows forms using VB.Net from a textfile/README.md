# Insert,Delete,Update a listbox in windows forms using VB.Net from a textfile
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- Windows Forms
- VB.Net
## Topics
- Windows Forms
## Updated
- 10/26/2012
## Description

<p>&nbsp;</p>
<h1>Introduction</h1>
<p><em>This is a simple listbox control created using Windows Forms. The language here used is Visual Basic.</em></p>
<p><em>The Tool used here is the Visual Studio 2010 , you can also use Visual Studio 2012 or Visual Studio 2008 to work this tutorial. If you are using Visual Studio 2008 you must have to copy and paste the code to your application. This is because i am using
 the .Net framework 4 to write this application. This is a simple listbox control , with this you can delete the values ,update the values and add the values into a listbox.</em></p>
<p><em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<address><em>Visual studio 2010</em></address>
<p><em>Visual Studio 2012</em></p>
<p><em>Windows Forms and VB.Net</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><em>This is a simple listbox control , with this you can delete the values ,update the values and add the values into a listbox.</em></p>
<p>The values in the listbox are stored inside the textfile. Here i am not using any database . Its purely depends on the text file concept.</p>
<p>The design of the application is like this</p>
<p><img id="68813" src="68813-first%20image.png" alt="" width="400" height="253"></p>
<p>&nbsp;</p>
<p>The above picture describes the design of the form with the Name of the controls defined.</p>
<p>&nbsp;</p>
<p><strong>Add Data to Listbox</strong></p>
<p>To add data to the listbox we are use the textbox. The data from the textbox is entered into the listbox with the help of the Add button.</p>
<p>Here is the sample code</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button1_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnAdd.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;txtAddtoListbox.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Enter&nbsp;some&nbsp;data&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(txtAddtoListbox.Text.Trim())&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtAddtoListbox.Text&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtAddtoListbox.Focus()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span></pre>
</div>
</div>
</div>
<address>The &nbsp;logic behind this code is&nbsp;</address>
<address>the textbox value cannot be null , if the textbox value is empty and we click the button a message box will be popup showing the value is not there so enter some data</address>
<address>else the data must be added to the listbox.</address>
<address><br>
</address>
<address>ListBox1.Items.Add(_the values of the textbox_)</address>
<address><br>
</address>
<address>and then the textbox must have to be cleared automatically and automatically the cursor will get focused on the textbox&nbsp;</address>
<address><br>
</address>
<address><br>
</address>
<address>When you click the ok button the data must be added into the Text file.the path of the textfile will be as in the same folder as our application is installed .So no need to create a new location for the text file.</address>
<address><br>
</address>
<address>The text file path will be -&gt; our project path &gt;Debug &gt;bin</address>
<address>The fpath is set to the current project path&nbsp;</address>
<address><br>
</address>
<address>then the filepath will be our project path &#43; the textfile.</address>
<address>so the textfile will be inside our project folder.</address>
<address>If the count of the listbox is greaterthan zero then the values are stored inside a variable named listbox.</address>
<address>Then all the values are writeinto the textfile using the WriteAllText() method.</address>
<address><br>
</address>
<address>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button2_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnOk.Click&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;fpath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fpath&nbsp;=&nbsp;AppDomain.CurrentDomain.BaseDirectory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;filepath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filepath&nbsp;=&nbsp;fpath&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;txtdetails.txt&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;details&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ListBox1.Items.Count&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;details&nbsp;=&nbsp;ListBox1.Items(<span class="visualBasic__number">0</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;ListBox1.Items.Count&nbsp;-&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;details&nbsp;=&nbsp;details&nbsp;&amp;&nbsp;vbCrLf&nbsp;&amp;&nbsp;ListBox1.Items(i)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;My.Computer.FileSystem.WriteAllText(filepath,&nbsp;details,&nbsp;<span class="visualBasic__keyword">False</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Values&nbsp;Inserted&nbsp;Successfully&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Catch</span>&nbsp;ex&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Exception&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;Values&nbsp;Can't&nbsp;be&nbsp;inserted&nbsp;this&nbsp;time&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Try</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;To delete an item from the listbox just select the item from listbox and delete the item. But you must have to update by clicking the ok button.</div>
<div class="endscriptcode"></div>
<div class="endscriptcode">If you donot select anyitem and try to delete the item , it will show a messagebox.The conformation message buttons ok button will remove the item from listbox.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb">&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Button3_Click(<span class="visualBasic__keyword">ByVal</span>&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;btnDelete.Click&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ListBox1.SelectedItem&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox(<span class="visualBasic__string">&quot;please&nbsp;select&nbsp;an&nbsp;item&quot;</span>)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ListBox1.Items.Count&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;R&nbsp;U&nbsp;Sure&nbsp;u&nbsp;want&nbsp;to&nbsp;remove&nbsp;items&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;message&quot;</span>,&nbsp;MessageBoxButtons.OKCancel)&nbsp;=&nbsp;MsgBoxResult.Ok&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Remove(ListBox1.SelectedItem.ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;When the form load the values from the textbox will be automatically load to the listbox using the ReadAllText() function.</div>
<div class="endscriptcode">
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;Form1_Load(ByVal&nbsp;sender&nbsp;As&nbsp;System.<span class="js__object">Object</span>,&nbsp;ByVal&nbsp;e&nbsp;As&nbsp;<a class="libraryLink" href="http://msdn.microsoft.com/en-US/library/System.EventArgs.aspx" target="_blank" title="Auto generated link to System.EventArgs">System.EventArgs</a>)&nbsp;Handles&nbsp;MyBase.Load&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;fpath&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;splitdata&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;fpath&nbsp;=&nbsp;AppDomain.CurrentDomain.BaseDirectory&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;filepath&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;filepath&nbsp;=&nbsp;fpath&nbsp;&amp;&nbsp;<span class="js__string">&quot;txtdetails.txt&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;details&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;details&nbsp;=&nbsp;My.Computer.FileSystem.ReadAllText(filepath)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;splitdata&nbsp;=&nbsp;Split(details,&nbsp;vbCrLf)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;i&nbsp;As&nbsp;Integer&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;i&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;To&nbsp;UBound(splitdata)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListBox1.Items.Add(splitdata(i))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;
&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;Sub</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
</div>
</div>
<br>
</address>
<address><br>
</address>
