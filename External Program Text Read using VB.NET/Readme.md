# External Program Text Read using VB.NET
## Requires
- Visual Studio 2010
## License
- MIT
## Technologies
- Windows Forms
- VB.Net
- WM_GETTEXT
- WM_SETTEXT
## Topics
- Windows Forms
- VB.Net
- WM_GETTEXT
- WM_SETTEXT
## Updated
- 04/25/2017
## Description

<h1>Introduction</h1>
<p>The main aim of this article is to explain you all how to create simple program which will be used to read and edit the external program text, without modifying the external program (Another Application or Another Program)&nbsp;source code.</p>
<p>We will see in detail about &nbsp; &nbsp;</p>
<p><strong style="font-size:1.5em">1.How to Read / Edit Notepad Text from our program</strong></p>
<p>&nbsp;<img id="145771" src="145771-2.gif" alt="" width="550" height="400"></p>
<p>As we can see here I have opened a notepad named as &ldquo;SHANUEPTR.txt &ndash; 메모장&rdquo; .In our External program Text Read program I will give the Note pad file name with title displayed. Since we are going to Read and Edit Notepad Text, Here we will
 select radio option as Notepad and click &ldquo;Load External Program Button&rdquo;.</p>
<p>Once we clicked on the button we can see the Notepad text will be displayed in both Text Box. The First Textbox is to display the notepad text .The second Textbox is to edit the notepad text. After we have edited the Notepad text from our program we can
 click on &ldquo;Write to Notepad button&rdquo; to updated the text on Notepad.</p>
<p>Note: The text file should be opened. In my attached zip folder you can find the folder name as
<strong>&ldquo;SampleProgramtoRead&rdquo;</strong>.Inside this folder you can find my sample text file which need to be used for Read/Write. You can also use any text file but you have to give the same title text of each Notepad to read.</p>
<h2><strong>2.How to Read External Program Text from our program</strong></h2>
<p><img id="145774" src="145774-1.gif" alt="" width="550" height="340"></p>
<p>Same like reading Notepad text now let&rsquo;s see how to Read and Edit External program text from our program. We need to give the same title of our other external application text. Here for example we can see there is another program running and the program
 title text is <strong>&ldquo;</strong><strong>SHANU_SAMPLE_APPLICATION</strong><strong>&rdquo;.</strong>We will give this title to our program and select External program radio option and click on Load External program. We can see all controls of the form
 with control Type, control ID and Control Text will be listed. We can also change of textbox text of external program from our own program.</p>
<p>Note: The External program should be opened and running.In my attached zip folder you can find the folder name as
<strong>&ldquo;SampleProgramtoRead&rdquo;</strong>.Inside this folder you can find my sample external program exe as &ldquo;SampleProgramtoRead.exe&rdquo; file which need to be used for Read/Write. You can also use any program of yours but sure to give the
 exact title of that program to read.</p>
<h1><span>Building the Sample</span></h1>
<p>To read the External program we need to use Windows WM_GETTEXT and WM_SETTEXT</p>
<h2>WM_GETTEXT</h2>
<p>The <strong>WM_GETTEXT </strong>is used to read the external program text .<br>
For Example :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">SendMessage(ChildHandle, WM_GETTEXT, 200, Hndl)</pre>
<div class="preview">
<pre class="js">SendMessage(ChildHandle,&nbsp;WM_GETTEXT,&nbsp;<span class="js__num">200</span>,&nbsp;Hndl)</pre>
</div>
</div>
</div>
<div class="endscriptcode">Here we use Windows <strong>SendMessage</strong> to get the text for external program text.</div>
<p><strong>ChildHandle</strong> is the control id .Each external program controls will have unique id we need to give the appropriate control id to get the text from that control.<br>
<strong>WM_GETTEXT</strong> to read the external program text.<br>
<strong>Hndl</strong> is the buffer memory size of the control.</p>
<p>&nbsp;</p>
<h2>WM_SETTEXT</h2>
<p>The <strong>WM_SETTEXT </strong>is used to Write to the external program text .<br>
For Example :</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">SendMessageSTRING(Handle, WM_SETTEXT, TexttoWritetoNotepad.Length, TexttoWritetoNotepad)</pre>
<div class="preview">
<pre class="vb">SendMessageSTRING(Handle,&nbsp;WM_SETTEXT,&nbsp;TexttoWritetoNotepad.Length,&nbsp;TexttoWritetoNotepad)</pre>
</div>
</div>
</div>
<div class="endscriptcode">Here we use Windows <strong>SendMessageSTRING</strong> to set the text for external program text.</div>
<p><strong>Handle</strong> is the control id .Each external program controls will have unique id we need to give the appropriate control id to set the text for that control..<br>
<strong>WM_SETTEXT</strong> to read the external program text.<br>
<strong>TexttoWritetoNotepad</strong> String which need to be write in external program.</p>
<p>Reference website:&nbsp;</p>
<ul>
<li><a href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms633500(v=vs.85).aspx" target="_blank">https://msdn.microsoft.com/en-us/library/windows/desktop/ms633500(v=vs.85).aspx&nbsp;&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a>&nbsp;
</li><li><a href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632644(v=vs.85).aspx" target="_blank">https://msdn.microsoft.com/en-us/library/windows/desktop/ms632644(v=vs.85).aspx&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a>&nbsp;
</li><li><a href="https://msdn.microsoft.com/en-us/library/aa922085.aspx" target="_blank">https://msdn.microsoft.com/en-us/library/aa922085.aspx&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump"></a>
</li><li>
<p><a href="https://social.msdn.microsoft.com/Forums/vstudio/en-US/02a67f3a-4a26-4d9a-9c67-0fdff1428a66/how-do-i-use-wmgettext-in-vbnet-to-get-text-from-another-applications-window?forum=vbgeneral" target="_blank">https://social.msdn.microsoft.com/Forums/vstudio/en-US/02a67f3a-4a26-4d9a-9c67-0fdff1428a66/how-do-i-use-wmgettext-in-vbnet-to-get-text-from-another-applications-window?forum=vbgeneral&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump"></a></p>
</li><li>
<p><a href="https://social.msdn.microsoft.com/Forums/vstudio/en-US/02a67f3a-4a26-4d9a-9c67-0fdff1428a66/how-do-i-use-wmgettext-in-vbnet-to-get-text-from-another-applications-window?forum=vbgeneral" target="_blank"><img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><a href="https://kellyschronicles.wordpress.com/2008/06/23/get-window-handles-associated-with-process-in-vb-net/" target="_blank">https://kellyschronicles.wordpress.com/2008/06/23/get-window-handles-associated-with-process-in-vb-net/&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a>&nbsp;By
 Kelly's Chronicles</p>
</li><li>
<p><a href="https://msdn.microsoft.com/en-us/library/windows/desktop/ms632644(v=vs.85).aspx" target="_blank">https://msdn.microsoft.com/en-us/library/windows/desktop/ms632644(v=vs.85).aspx&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump"></a></p>
</li></ul>
<div><span>Special Thanks to&nbsp;</span><a href="https://kellyschronicles.wordpress.com/about/" target="_blank">Kelly Martens&nbsp;<img title="This link is external to TechNet Wiki. It will open in a new window." src=":-10_5f00_external.png" border="0" alt="Jump">&nbsp;</a><span>&nbsp;his&nbsp;Get
 Window Handles Associated With Process in vb.net function&nbsp;helps me lot to complete the project.</span></div>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p><span>The main purpose is to make the program very simple and easy to use; all the functions have been well commented in the project. I have attached my sample program in this article for more details.&nbsp;</span></p>
<p><strong>Windows API call</strong></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">'Imports   
Imports System.Data  
Imports System.Runtime.InteropServices  
Imports System.Text  
Imports System.Collections.Generic  
  
  Declare Auto Function SendMessage Lib &quot;user32.dll&quot; (ByVal hWnd As IntPtr, ByVal msg As Integer, _  
    ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr  
    &lt;dllimport(&quot;user32.dll&quot;, charset:=&quot;CharSet.Auto)&quot; setlasterror:=&quot;True,&quot;&gt; _  
    Public Shared Function FindWindowEx(ByVal parentHandle As IntPtr, _  
                                     ByVal childAfter As IntPtr, _  
                                     ByVal lclassName As String, _  
                                     ByVal windowTitle As String) As IntPtr  
    End Function  
    Declare Auto Function UpdateWindow Lib &quot;user32.dll&quot; (ByVal hWnd As Int32) As Int32  
    Declare Auto Function redrawwindow Lib &quot;user32.dll&quot; (ByVal hWnd As Int32) As Int32  
    Declare Auto Function FindWindow Lib &quot;user32.dll&quot; (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr  
  
  
    Public Const WM_SETTEXT = &amp;HC  
    Public Declare Function SendMessageSTRING Lib &quot;user32.dll&quot; Alias &quot;SendMessageA&quot; (ByVal hwnd As Int32, _  
   ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As String) As Int32  
  
    '    Private Declare Function FindWindow Lib &quot;user32.dll&quot; Alias _  
    '&quot;FindWindowA&quot; (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32  
    Private Declare Function FindWindowEx Lib &quot;user32.dll&quot; Alias _  
  &quot;FindWindowExA&quot; (ByVal hWnd1 As Int32, ByVal hWnd2 As Int32, ByVal lpsz1 As String, _  
  ByVal lpsz2 As String) As Int32  
&lt;/dllimport(&quot;user32.dll&quot;,&gt;  </pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__com">'Imports&nbsp;&nbsp;&nbsp;</span>&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Data&nbsp;&nbsp;&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Runtime.InteropServices&nbsp;&nbsp;&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Text&nbsp;&nbsp;&nbsp;
<span class="visualBasic__keyword">Imports</span>&nbsp;System.Collections.Generic&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;Auto&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;SendMessage&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;msg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Integer</span>,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;dllimport(<span class="visualBasic__string">&quot;user32.dll&quot;</span>,&nbsp;charset:=<span class="visualBasic__string">&quot;CharSet.Auto)&quot;</span>&nbsp;setlasterror:=<span class="visualBasic__string">&quot;True,&quot;</span>&gt;&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Shared</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;FindWindowEx(<span class="visualBasic__keyword">ByVal</span>&nbsp;parentHandle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;childAfter&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lclassName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;windowTitle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;Auto&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;UpdateWindow&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;Auto&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;redrawwindow&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;Auto&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;FindWindow&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;lpClassName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpWindowName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;WM_SETTEXT&nbsp;=&nbsp;&amp;HC&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;SendMessageSTRING&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;<span class="visualBasic__keyword">Alias</span>&nbsp;<span class="visualBasic__string">&quot;SendMessageA&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wMsg&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;wParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lParam&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;Private&nbsp;Declare&nbsp;Function&nbsp;FindWindow&nbsp;Lib&nbsp;&quot;user32.dll&quot;&nbsp;Alias&nbsp;_&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&quot;FindWindowA&quot;&nbsp;(ByVal&nbsp;lpClassName&nbsp;As&nbsp;String,&nbsp;ByVal&nbsp;lpWindowName&nbsp;As&nbsp;String)&nbsp;As&nbsp;Int32&nbsp;&nbsp;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;FindWindowEx&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;user32.dll&quot;</span>&nbsp;<span class="visualBasic__keyword">Alias</span>&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="visualBasic__string">&quot;FindWindowExA&quot;</span>&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpsz1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpsz2&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Int32&nbsp;&nbsp;&nbsp;
&lt;/dllimport(<span class="visualBasic__string">&quot;user32.dll&quot;</span>,&gt;&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>All this Windows API will be used in our program to read the external program text.</span><br>
<br>
<strong>FindWindow</strong><span>: This will be used to find the application program that is currently opened.</span><br>
<strong>FindWindowEx</strong><span>: This wil be used to find the control of the application from where the text will be read or written.</span><br>
<strong>SendMessage</strong><span>: Used to get the text from the external program.</span><br>
<strong>SendMessageSTRING</strong><span>: Used to set the text to the external program.</span></div>
<h2 class="endscriptcode"><strong>Read Notepad Text to our program</strong><strong>&nbsp;</strong></h2>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function ReadtextfromNotepad()  
       'Find the running notepad window  
       Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)  
       Dim NumText As Integer  
       'Find the Edit control of the Running Notepad  
       Dim ChildHandle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, &quot;Edit&quot;, Nothing)  
  
       'Alloc memory for the buffer that recieves the text  
       Dim Hndl As IntPtr = Marshal.AllocHGlobal(200)  
  
       'Send The WM_GETTEXT Message  
       NumText = SHANUEPTR.SendMessage(ChildHandle, SHANUEPTR.WM_GETTEXT, 200, Hndl)  
  
       'copy the characters from the unmanaged memory to a managed string  
       Text = Marshal.PtrToStringUni(Hndl)  
       If Text = &quot;AutoCompleteProxy&quot; Then  
           MessageBox.Show(&quot;Enter the valid Notepad text file Name. Note :  the note pad text file name should be as full text as same as titile of note pad / The Note pad should be open if its closed the text can not be read.This sample will load only the active notepad text file text.&quot;)  
           Exit Function  
  
       End If  
       'Display the string using a label  
       txtNotepadread.Text = Text  
       txtNotepadWrite.Text = Text  
   End Function  </pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;ReadtextfromNotepad()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Find&nbsp;the&nbsp;running&nbsp;notepad&nbsp;window&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Hwnd&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindow(Nothing,&nbsp;txtTitle.Text)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;NumText&nbsp;As&nbsp;Integer&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Find&nbsp;the&nbsp;Edit&nbsp;control&nbsp;of&nbsp;the&nbsp;Running&nbsp;Notepad&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;ChildHandle&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindowEx(Hwnd,&nbsp;IntPtr.Zero,&nbsp;<span class="js__string">&quot;Edit&quot;</span>,&nbsp;Nothing)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Alloc&nbsp;memory&nbsp;<span class="js__statement">for</span>&nbsp;the&nbsp;buffer&nbsp;that&nbsp;recieves&nbsp;the&nbsp;text&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Hndl&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;Marshal.AllocHGlobal(<span class="js__num">200</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Send&nbsp;The&nbsp;WM_GETTEXT&nbsp;Message&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NumText&nbsp;=&nbsp;SHANUEPTR.SendMessage(ChildHandle,&nbsp;SHANUEPTR.WM_GETTEXT,&nbsp;<span class="js__num">200</span>,&nbsp;Hndl)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'copy&nbsp;the&nbsp;characters&nbsp;from&nbsp;the&nbsp;unmanaged&nbsp;memory&nbsp;to&nbsp;a&nbsp;managed&nbsp;string&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;Marshal.PtrToStringUni(Hndl)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;Text&nbsp;=&nbsp;<span class="js__string">&quot;AutoCompleteProxy&quot;</span>&nbsp;Then&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="js__string">&quot;Enter&nbsp;the&nbsp;valid&nbsp;Notepad&nbsp;text&nbsp;file&nbsp;Name.&nbsp;Note&nbsp;:&nbsp;&nbsp;the&nbsp;note&nbsp;pad&nbsp;text&nbsp;file&nbsp;name&nbsp;should&nbsp;be&nbsp;as&nbsp;full&nbsp;text&nbsp;as&nbsp;same&nbsp;as&nbsp;titile&nbsp;of&nbsp;note&nbsp;pad&nbsp;/&nbsp;The&nbsp;Note&nbsp;pad&nbsp;should&nbsp;be&nbsp;open&nbsp;if&nbsp;its&nbsp;closed&nbsp;the&nbsp;text&nbsp;can&nbsp;not&nbsp;be&nbsp;read.This&nbsp;sample&nbsp;will&nbsp;load&nbsp;only&nbsp;the&nbsp;active&nbsp;notepad&nbsp;text&nbsp;file&nbsp;text.&quot;</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Exit&nbsp;<span class="js__object">Function</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'Display&nbsp;the&nbsp;string&nbsp;using&nbsp;a&nbsp;label&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtNotepadread.Text&nbsp;=&nbsp;Text&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;txtNotepadWrite.Text&nbsp;=&nbsp;Text&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode"><strong>&nbsp;Find the running Notepad window:</strong></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)  </pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;Hwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindow(<span class="visualBasic__keyword">Nothing</span>,&nbsp;txtTitle.Text)&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>FindWindow</strong><span>: will check for the currently opened application with the same title as we have given.</span><br>
<br>
<span>Note here txtTitle.Text is the Notepad file name. We need to provide the full title, the same as in Notepad, for example if your Notepad title is &quot;SHANUEPTR.txt - Notepad&quot; then provide the full name as it is.</span><br>
<br>
<span>Use the following to find the Edit control of the running Notepad:</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim ChildHandle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, &quot;Edit&quot;, Nothing)</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;ChildHandle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindowEx(Hwnd,&nbsp;IntPtr.Zero,&nbsp;<span class="visualBasic__string">&quot;Edit&quot;</span>,&nbsp;<span class="visualBasic__keyword">Nothing</span>)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<span>FindWindowEx checks for the control from the application from where to read the text.</span><br>
<span><strong>Hwnd:</strong> is the Application id or Control ID</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">NumText = SHANUEPTR.SendMessage(ChildHandle, SHANUEPTR.WM_GETTEXT, 200, Hndl)  </pre>
<div class="preview">
<pre class="vb">NumText&nbsp;=&nbsp;SHANUEPTR.SendMessage(ChildHandle,&nbsp;SHANUEPTR.WM_GETTEXT,&nbsp;<span class="visualBasic__number">200</span>,&nbsp;Hndl)&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;<strong>SendMessage</strong><span>: is used to send the message to the external program to get the text.</span><br>
<strong>ChildHandle</strong><span>: is the external application control ID from where we read the text we need to provide the proper control id to read the text .</span><br>
<strong>WM_GETTEXT</strong><span>: is used to get the Text.</span><br>
<strong>Hndl</strong><span>: here we will have the result of the text from the external program.</span></div>
<div class="endscriptcode"></div>
<h2 class="endscriptcode"><strong>Write Text to Notepad from our program</strong></h2>
<div class="endscriptcode"><strong>&nbsp;</strong><span>Use the following to write text to Notepad from our program:&nbsp;</span></div>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function WritetextfromNotepad()  
 Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)  
 Dim Handle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, &quot;Edit&quot;, Nothing)  
 Dim TexttoWritetoNotepad As String = txtNotepadWrite.Text.Trim()  
 SHANUEPTR.SendMessageSTRING(Handle, SHANUEPTR.WM_SETTEXT, TexttoWritetoNotepad.Length, TexttoWritetoNotepad) 
End Function  </pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;WritetextfromNotepad()&nbsp;&nbsp;&nbsp;
&nbsp;Dim&nbsp;Hwnd&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindow(Nothing,&nbsp;txtTitle.Text)&nbsp;&nbsp;&nbsp;
&nbsp;Dim&nbsp;Handle&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindowEx(Hwnd,&nbsp;IntPtr.Zero,&nbsp;<span class="js__string">&quot;Edit&quot;</span>,&nbsp;Nothing)&nbsp;&nbsp;&nbsp;
&nbsp;Dim&nbsp;TexttoWritetoNotepad&nbsp;As&nbsp;<span class="js__object">String</span>&nbsp;=&nbsp;txtNotepadWrite.Text.Trim()&nbsp;&nbsp;&nbsp;
&nbsp;SHANUEPTR.SendMessageSTRING(Handle,&nbsp;SHANUEPTR.WM_SETTEXT,&nbsp;TexttoWritetoNotepad.Length,&nbsp;TexttoWritetoNotepad)&nbsp;&nbsp;
End&nbsp;<span class="js__object">Function</span></pre>
</div>
</div>
</div>
<p>Use the following to find the running Notepad window:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim Hwnd As IntPtr = SHANUEPTR.FindWindow(Nothing, txtTitle.Text)  </pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;Hwnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindow(<span class="visualBasic__keyword">Nothing</span>,&nbsp;txtTitle.Text)&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;FindWindow: will check for the currently opened application with the same title as we gave.</div>
<p>Note that here txtTitle.Text is the Notepad file name. We need to provide the full title, the same as in Notepad. For example if your notepad title is &quot;SHANUEPTR.txt - Notepad&quot; then provide the full name as it is.<br>
<br>
Use the following to find the Edit control of the running Notepad:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Dim Handle As IntPtr = SHANUEPTR.FindWindowEx(Hwnd, IntPtr.Zero, &quot;Edit&quot;, Nothing)</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Dim</span>&nbsp;Handle&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;IntPtr&nbsp;=&nbsp;SHANUEPTR.FindWindowEx(Hwnd,&nbsp;IntPtr.Zero,&nbsp;<span class="visualBasic__string">&quot;Edit&quot;</span>,&nbsp;<span class="visualBasic__keyword">Nothing</span>)</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;FindWindowEx is to check for the control from the application from where to read the text.</div>
<p><strong>Hwnd</strong>: is the Application id or Control ID</p>
<div class="dp-highlighter">
<ol class="dp-vb">
<li class="alt"><span class="keyword">Dim</span><span>&nbsp;TexttoWritetoNotepad&nbsp;</span><span class="keyword">As</span><span>&nbsp;</span><span class="keyword">String</span><span>&nbsp;=&nbsp;txtNotepadWrite.Text.Trim()&nbsp;&nbsp;</span>
</li><li><span>SHANUEPTR.SendMessageSTRING(Handle,&nbsp;SHANUEPTR.WM_SETTEXT,&nbsp;TexttoWritetoNotepad.Length,&nbsp;TexttoWritetoNotepad)&nbsp;</span>
</li></ol>
</div>
<p><strong>SendMessageSTRING</strong>&nbsp;is used to send the message to external program to SET the text.<br>
<strong>Handle</strong>&nbsp;is the external application control ID from where we read the text we need to provide the proper control id to read the text.<br>
<br>
<strong>WM_SETTEXT</strong>&nbsp;is used to SET the Text.<br>
<strong>TexttoWritetoNotepad</strong>&nbsp;is the string to be written to Notepad.</p>
<h2><strong>Read Text from External Application</strong></h2>
<p>Use the following to read text from the external application:&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Function ReadtextfromApplication()  
        ListView1.Items.Clear()  
        Dim Hndl As IntPtr = Marshal.AllocHGlobal(200)  
        Dim NumText As Integer        
        Static count As Integer = 0  
        Dim enumerator As New SHANUEPTR()  
        Dim sb As New StringBuilder()  
        For Each top As ApiWindow In enumerator.GetTopLevelWindows  
            count = 0  
  
            'If top.MainWindowTitle = &quot;E2Max-MTMS - [&ecirc;&sup3;&micro;&igrave;&sect;&euro;&igrave;&sbquo;&not;&iacute;&bull;&shy;]&quot; Then  
            If top.MainWindowTitle = txtTitle.Text Then  
                '  MessageBox.Show(top.MainWindowTitle)  
  
                For Each child As ApiWindow In enumerator.GetChildWindows(top.hWnd)  
                    '  Console.WriteLine(child.MainWindowTitle)  
  
                    Dim lvi As ListViewItem    
                    NumText = SHANUEPTR.SendMessage(child.hWnd, SHANUEPTR.WM_GETTEXT, 200, Hndl)  
                    Text = Marshal.PtrToStringUni(Hndl)  
                    lvi = New ListViewItem(child.ClassName.ToString())  
                    lvi.SubItems.Add(child.hWnd.ToString())  
                    lvi.SubItems.Add(child.MainWindowTitle.ToString())  
                    ListView1.Items.Add(lvi)                                          
                Next child  
            End If  
        Next top  
    End Function  </pre>
<div class="preview">
<pre class="js">Public&nbsp;<span class="js__object">Function</span>&nbsp;ReadtextfromApplication()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListView1.Items.Clear()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;Hndl&nbsp;As&nbsp;IntPtr&nbsp;=&nbsp;Marshal.AllocHGlobal(<span class="js__num">200</span>)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;NumText&nbsp;As&nbsp;Integer&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Static&nbsp;count&nbsp;As&nbsp;Integer&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;enumerator&nbsp;As&nbsp;New&nbsp;SHANUEPTR()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;sb&nbsp;As&nbsp;New&nbsp;StringBuilder()&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;top&nbsp;As&nbsp;ApiWindow&nbsp;In&nbsp;enumerator.GetTopLevelWindows&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;count&nbsp;=&nbsp;<span class="js__num">0</span>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'If&nbsp;top.MainWindowTitle&nbsp;=&nbsp;<span class="js__string">&quot;E2Max-MTMS&nbsp;-&nbsp;[&ecirc;&sup3;&micro;&igrave;&sect;&euro;&igrave;&sbquo;&not;&iacute;&bull;&shy;]&quot;</span>&nbsp;Then&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;If&nbsp;top.MainWindowTitle&nbsp;=&nbsp;txtTitle.Text&nbsp;Then&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;&nbsp;MessageBox.Show(top.MainWindowTitle)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;For&nbsp;Each&nbsp;child&nbsp;As&nbsp;ApiWindow&nbsp;In&nbsp;enumerator.GetChildWindows(top.hWnd)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'&nbsp;&nbsp;Console.WriteLine(child.MainWindowTitle)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Dim&nbsp;lvi&nbsp;As&nbsp;ListViewItem&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NumText&nbsp;=&nbsp;SHANUEPTR.SendMessage(child.hWnd,&nbsp;SHANUEPTR.WM_GETTEXT,&nbsp;<span class="js__num">200</span>,&nbsp;Hndl)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Text&nbsp;=&nbsp;Marshal.PtrToStringUni(Hndl)&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lvi&nbsp;=&nbsp;New&nbsp;ListViewItem(child.ClassName.ToString())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lvi.SubItems.Add(child.hWnd.ToString())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lvi.SubItems.Add(child.MainWindowTitle.ToString())&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ListView1.Items.Add(lvi)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;child&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;If&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Next&nbsp;top&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;End&nbsp;<span class="js__object">Function</span>&nbsp;&nbsp;</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;This is the same as in the receding example. Here this function will find all the controls and child controls of the external application and read the text of each control. The resultant controls text will be added to the
 list view.</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><span>SHANU_EPTR_V1.0.zip</span> </li></ul>
<h1>More Information</h1>
<p><em><span>For the External application for now I have created to read text from label ,Text box, Combo box ,Button controls, and for edit I have made sample only for edit box like Text box and combo box.&nbsp;</span></em></p>
