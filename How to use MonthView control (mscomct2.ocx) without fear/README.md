# How to use MonthView control (mscomct2.ocx) without fear
## License
- Apache License, Version 2.0
## Technologies
- VBA
- VB.Net
## Topics
- Excel Automation
- Office Automation
- mscomct2.ocx
- MonthView
## Updated
- 11/08/2012
## Description

<h1>Introduction (for those who like to read)</h1>
<p>Recently I was asked to design an Excel file with integrated MontView control.&nbsp; I was surprised to see that so many users are looking for solutions and guidelines on how to use the well known and beloved Date-Picker (or as it is formally named: MonthView
 ActiveX control).</p>
<p>The number of threads on this subject are countless.</p>
<p>Unfortunately I was unable to find one solid solution that will solve the annoying stability issues accompanying this control and so I decided to present a solution to this problem that is completely resilient to user&rsquo;s environment variations.</p>
<p>In order to use this control it is necessary to establish a &lsquo;solid&rsquo; reference to the ActiveX file mscomct2.ocx. The reason for this stability issues stems from the fact that creating this &lsquo;solid&rsquo; reference is a tricky, almost impossible
 mission with today OS. Particularly for applications that must run on different OS of 32 and 64 bits and Office versions of 32 and 64 bits (yes the hassle of where the hell should I save resources, in System32 or SysWOW64?). Even after thoroughly debugging
 an application it may later function erratically for some users. Particularly if the application (e.g. an Excel file with macros) is placed and used from a remote server by&nbsp;other users.</p>
<p>In the following sample I will present a solution to this problem that was already tested on different OS with different Office versions, on a standalone PC or on networks.</p>
<p>The presented solution was implemented in an Excel file, the most common use of the DatePicker.</p>
<p>Note: It will not show how to call the DatePicker from Excel since this issue is well covered by others (Google it).</p>
<p>&nbsp;</p>
<h1>Strategy (more boring stuff)</h1>
<p>One may think on 3 different strategies which I will call the Straw House, the Wood House and the Brick House strategies.</p>
<p>The Straw House strategy may define a solution, best suited for single users, and&nbsp;of files&nbsp;which are&nbsp;always&nbsp;located&nbsp;on the same computer. In this case we will ask the user to do some initialization process for&nbsp;the&nbsp;first
 time the file is used (you can simplify the below code to follow this functionality).</p>
<p>The Wood House strategy is similar to the Straw House strategy but it will also suit the use of files by many users over a network. Here the user is asked to do a one-time initialization process before he can use the file (you can simplify the below code
 to follow this functionality).</p>
<p>The Brick House strategy (which I presented here) will enable using&nbsp;files by single users or by many users, regardless if the file is local or shared on a network. Every time the file is opened (e.g. an Excel file) it will check whether the user is
 having valid references to the resources needed, if not, the user will be asked to correct the problem (automatically) and only then he will be able to use the file with the DatePicker. This way we will assure good functionality of the Month View control under
 any condition.</p>
<p>Sound complicated? Not really, as you will learn later.</p>
<p>&nbsp;</p>
<h1>Implementation (warming up)</h1>
<p>Regardless on the strategy you choose, 3 basic issues must be addressed and solved:</p>
<ol>
<li>We need a solid verification process on whether a valid reference to the mscomc2.ocx exists (and we don&rsquo;t like to get messy with Windows registry).
</li><li>If the reference is missing or broken we need to have a foolproof method on how to fix it, regardless on current user environment.
</li><li>If for some reason (e.g in Straw Hose approach) the files (e.g. Excel)&nbsp;are used with missing references, we need to protect the user from confusing messages or even worst &ndash; compilation error messages.
</li></ol>
<p>In this sample we will do the following:</p>
<p>The resource file mscomc2.ocx will be placed in a predefined folder that will serve any user who is activating our file. I decided to save the file in a subfolder 'Support' located under the folder containing our application file (working folder) but it
 may be saved at any location that suit your requirements (in the later case you will need to make a small modification of the code).</p>
<p>&nbsp;</p>
<h1>Preparations</h1>
<p>You should follow the next steps:</p>
<p>1. Save the Excel file you want to use in a folder. In this folder create a subfolder by the name
<em><strong>Support </strong></em>(works with no problems on networks).</p>
<p>2. Load and extract the ActiveX file<strong> mscomct.ocx</strong> from the following link:
<a href="http://support.microsoft.com/kb/297381">http://support.microsoft.com/kb/297381</a> and save it in the
<strong><em>Support</em></strong> folder (you need only this file). It may look like this:</p>
<ul>
<li>Work folder - X:\Company Apps\MyExelFile.xlsm </li><li>Support folder - X:\Company Apps\Support\mscomct2.ocx </li></ul>
<p>3. Insert a UserForm to your excel file VBA project.&nbsp; Rename it to: <strong>
<em>CalendarForm </em></strong>with caption: <strong><em>Calendar</em></strong></p>
<p>4. Add to the CalendarForm 2 Command Buttons:</p>
<ul>
<li>1<sup>st</sup> Button renamed to: <strong><em>CommandButtonAddDate </em></strong>with caption:
<strong><em>Add Date</em></strong> </li><li>2<sup>nd</sup> Button renamed to: <em><strong>Cancel </strong></em>with caption:
<em><strong>Cancel</strong></em> </li></ul>
<ul>
<li>The Form should look like this: </li></ul>
<p><img id="70083" src="70083-calendar.png" alt="" width="292" height="212" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>5. Add the following code to the <strong><em>CalendarForm</em></strong></p>
<p style="padding-left:30px">Note: You are not requested to enter a MonthView control to the form</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Option</span>&nbsp;Explicit&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__com">'To&nbsp;change&nbsp;The&nbsp;buttons&nbsp;size&nbsp;under&nbsp;the&nbsp;MonthView&nbsp;control&nbsp;use&nbsp;only&nbsp;the&nbsp;next&nbsp;3&nbsp;lines</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;Paspartu&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;ButtonsHeight&nbsp;&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;=&nbsp;<span class="visualBasic__number">20</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Const</span>&nbsp;ButtonsSpace&nbsp;&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;=&nbsp;<span class="visualBasic__number">40</span>&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">WithEvents</span>&nbsp;MonthView1&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;MSComCtl2.MonthView&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;AddMonthPicker()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;myCalendar&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Control&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;CalendarWidth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;CalendarHeight&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ButtonsTops&nbsp;&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;ButtonsWidth&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;<span class="visualBasic__keyword">Error</span>&nbsp;<span class="visualBasic__keyword">GoTo</span>&nbsp;LastRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;CalendarForm.MonthView1&nbsp;=&nbsp;CalendarForm.Controls.Add(<span class="visualBasic__string">&quot;MSComCtl2.MonthView&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;MonthView1&quot;</span>,&nbsp;<span class="visualBasic__keyword">True</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Err.Number&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Or</span>&nbsp;CalendarForm.MonthView1&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">GoTo</span>&nbsp;LastRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;myCalendar&nbsp;=&nbsp;CalendarForm.Controls(<span class="visualBasic__string">&quot;MonthView1&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;CalendarForm.Controls(<span class="visualBasic__string">&quot;MonthView1&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Appearance&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__com">'ccFlat</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BorderStyle&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__com">'ccFixedSingle</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.ShowWeekNumbers&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BackColor&nbsp;=&nbsp;&amp;HBA5A03&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TitleBackColor&nbsp;=&nbsp;&amp;HFFA782&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.TitleForeColor&nbsp;=&nbsp;&amp;HBA5A03&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.BorderStyle&nbsp;=&nbsp;cc2None&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Value&nbsp;=&nbsp;<span class="visualBasic__keyword">Date</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.StartOfWeek&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;<span class="visualBasic__com">'mvwSunday</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;CalendarForm&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Define&nbsp;MonthView&nbsp;location</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CalendarWidth&nbsp;=&nbsp;myCalendar.Width&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CalendarHeight&nbsp;=&nbsp;myCalendar.Height&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myCalendar.Top&nbsp;=&nbsp;Paspartu&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;myCalendar.Left&nbsp;=&nbsp;Paspartu&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Define&nbsp;buttons&nbsp;size&nbsp;and&nbsp;lockation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ButtonsTops&nbsp;=&nbsp;<span class="visualBasic__number">2</span>&nbsp;*&nbsp;Paspartu&nbsp;&#43;&nbsp;CalendarHeight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ButtonsWidth&nbsp;=&nbsp;(<span class="visualBasic__number">3</span>&nbsp;*&nbsp;Paspartu&nbsp;&#43;&nbsp;CalendarWidth&nbsp;-&nbsp;ButtonsSpace)&nbsp;/&nbsp;<span class="visualBasic__number">2</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonAddDate.Top&nbsp;=&nbsp;ButtonsTops&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonAddDate.Left&nbsp;=&nbsp;Paspartu&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonAddDate.Width&nbsp;=&nbsp;ButtonsWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonAddDate.Height&nbsp;=&nbsp;ButtonsHeight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonCancel.Top&nbsp;=&nbsp;ButtonsTops&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonCancel.Left&nbsp;=&nbsp;Paspartu&nbsp;&#43;&nbsp;CalendarWidth&nbsp;-&nbsp;ButtonsWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonCancel.Width&nbsp;=&nbsp;ButtonsWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.CommandButtonCancel.Height&nbsp;=&nbsp;ButtonsHeight&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Define&nbsp;Form&nbsp;size</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Height&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;*&nbsp;Paspartu&nbsp;&#43;&nbsp;CalendarHeight&nbsp;&#43;&nbsp;ButtonsHeight&nbsp;&#43;&nbsp;<span class="visualBasic__number">20</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Width&nbsp;=&nbsp;<span class="visualBasic__number">3</span>&nbsp;*&nbsp;Paspartu&nbsp;&#43;&nbsp;CalendarWidth&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
LastRow:&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CommandButtonAddDate_Click()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Selection&nbsp;=&nbsp;MonthView1.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Unload&nbsp;<span class="visualBasic__keyword">Me</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CommandButtonCancel_Click()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Unload&nbsp;<span class="visualBasic__keyword">Me</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;MonthView1_DateDblClick(<span class="visualBasic__keyword">ByVal</span>&nbsp;DateDblClicked&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Date</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Selection&nbsp;=&nbsp;MonthView1.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;Unload&nbsp;<span class="visualBasic__keyword">Me</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__com">'The&nbsp;Initialize&nbsp;event&nbsp;is&nbsp;used&nbsp;(instead&nbsp;of&nbsp;Activate&nbsp;event)&nbsp;the&nbsp;in&nbsp;order&nbsp;to&nbsp;prevent&nbsp;flickering&nbsp;when&nbsp;user&nbsp;calls&nbsp;the&nbsp;form</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;UserForm_Initialize()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;AddMonthPicker&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SetDate&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;SetDate()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;<span class="visualBasic__keyword">Error</span>&nbsp;<span class="visualBasic__keyword">GoTo</span>&nbsp;LastRow&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;ActiveCell&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;ActiveCell.Value&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MonthView1.Value&nbsp;=&nbsp;ActiveCell.Value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
LastRow:&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<p>&nbsp;</p>
<p>6. Add a standard Module to the VBA project (Module1)</p>
<p>7. Add the following code to this Module</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Option</span>&nbsp;Explicit&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Declare</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ShellExecute&nbsp;<span class="visualBasic__keyword">Lib</span>&nbsp;<span class="visualBasic__string">&quot;shell32.dll&quot;</span>&nbsp;<span class="visualBasic__keyword">Alias</span>&nbsp;<span class="visualBasic__string">&quot;ShellExecuteA&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;(<span class="visualBasic__keyword">ByVal</span>&nbsp;hWnd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpOperation&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpFile&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpParameters&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;lpDirectory&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;nShowCmd&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;WorkFolder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;<span class="visualBasic__com">'Stores&nbsp;the&nbsp;work&nbsp;folder&nbsp;of&nbsp;the&nbsp;Workbook</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;SupportFolder&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;<span class="visualBasic__com">'Stores&nbsp;the&nbsp;Support&nbsp;folder&nbsp;for&nbsp;this&nbsp;application</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;bMscomct2ReferenceStatus&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;<span class="visualBasic__com">'Stores&nbsp;the&nbsp;mscomct2.ocx&nbsp;reference&nbsp;status</span>&nbsp;
&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;CheckAndFixReferences()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;bMscomct2ReferenceStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;i&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
<span class="visualBasic__com">'Stage&nbsp;1&nbsp;-&nbsp;Check&nbsp;the&nbsp;'Trust&nbsp;VBA&nbsp;project'&nbsp;status</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;TrustAccessToVBA&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;You&nbsp;have&nbsp;chosen&nbsp;not&nbsp;to&nbsp;trust&nbsp;the&nbsp;VBA&nbsp;project&nbsp;module.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;Therefore,&nbsp;the&nbsp;file&nbsp;is&nbsp;not&nbsp;usable&nbsp;and&nbsp;it&nbsp;will&nbsp;be&nbsp;closed.&quot;</span>,&nbsp;vbExclamation,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;VBA&nbsp;project&nbsp;trust&nbsp;status&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Close&nbsp;File</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActiveWorkbook.Close&nbsp;SaveChanges:=<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="visualBasic__com">'Stage&nbsp;2&nbsp;-&nbsp;Check&nbsp;if&nbsp;a&nbsp;reference&nbsp;to&nbsp;mscomct2.ocx&nbsp;exist&nbsp;and&nbsp;if&nbsp;it's&nbsp;status&nbsp;is&nbsp;OK</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Mscomct2ReferenceStatus&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'mscomct2.ocx&nbsp;is&nbsp;not&nbsp;referenced&nbsp;or&nbsp;reference&nbsp;is&nbsp;broken.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'The&nbsp;shortest&nbsp;way&nbsp;to&nbsp;correct&nbsp;this&nbsp;situation&nbsp;is&nbsp;to&nbsp;register&nbsp;mscomct2.ocx</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'(without&nbsp;removing&nbsp;the&nbsp;broken&nbsp;reference).</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'To&nbsp;simplify&nbsp;the&nbsp;registration&nbsp;process&nbsp;mscomct2.ocx&nbsp;will&nbsp;saved&nbsp;and&nbsp;registered</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'form&nbsp;a&nbsp;Support&nbsp;folder.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetMyWorkFolder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;you&nbsp;want&nbsp;to&nbsp;save&nbsp;mscomct2.ocx&nbsp;in&nbsp;a&nbsp;diferent&nbsp;lockation</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'(e.g.&nbsp;Windows\system32\)&nbsp;you&nbsp;will&nbsp;have&nbsp;to&nbsp;change&nbsp;the&nbsp;next&nbsp;line</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetSupportFolder&nbsp;<span class="visualBasic__com">'defines&nbsp;-&nbsp;SupportFolder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Mscomct2Exists(SupportFolder)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;The&nbsp;file&nbsp;mscomct2.ocx&nbsp;was&nbsp;not&nbsp;found&nbsp;in&nbsp;the&nbsp;Support&nbsp;folder&nbsp;or&nbsp;the&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;Support&nbsp;folder&nbsp;does&nbsp;not&nbsp;exist.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;This&nbsp;problem&nbsp;must&nbsp;be&nbsp;corrected&nbsp;to&nbsp;allow&nbsp;this&nbsp;workbook&nbsp;loading.&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;Mscomct2.ocx&nbsp;must&nbsp;be&nbsp;located&nbsp;in&nbsp;the&nbsp;folowing&nbsp;folder:&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SupportFolder&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;mscomct2.ocx&quot;</span>,&nbsp;vbExclamation,&nbsp;<span class="visualBasic__string">&quot;Excel&nbsp;aborted&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'If&nbsp;Support&nbsp;folder&nbsp;was&nbsp;not&nbsp;found&nbsp;close&nbsp;Workbook</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActiveWorkbook.Close&nbsp;SaveChanges:=<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="visualBasic__com">'Stage&nbsp;3&nbsp;-&nbsp;Register&nbsp;mscomct2.ocx&nbsp;from&nbsp;the&nbsp;Support&nbsp;folder</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RegisterFile&nbsp;SupportFolder&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;mscomct2.ocx&quot;</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'In&nbsp;order&nbsp;to&nbsp;complete&nbsp;the&nbsp;registration&nbsp;process&nbsp;we&nbsp;need&nbsp;to&nbsp;allow&nbsp;the&nbsp;operating&nbsp;system</span>&nbsp;
<span class="visualBasic__com">'to&nbsp;process&nbsp;these&nbsp;events&nbsp;externally.</span>&nbsp;
<span class="visualBasic__com">'Test&nbsp;has&nbsp;shown&nbsp;that&nbsp;a&nbsp;single&nbsp;call&nbsp;to&nbsp;DoEvents&nbsp;may&nbsp;not&nbsp;work&nbsp;on&nbsp;some&nbsp;systems.&nbsp;A&nbsp;safe</span>&nbsp;
<span class="visualBasic__com">'A&nbsp;minimum&nbsp;of&nbsp;1000&nbsp;calls&nbsp;is&nbsp;recommended.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;i&nbsp;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;<span class="visualBasic__keyword">To</span>&nbsp;<span class="visualBasic__number">1000</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DoEvents&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span class="visualBasic__com">'Stage&nbsp;4&nbsp;-&nbsp;Recheck&nbsp;mscomct2.ocx&nbsp;registration&nbsp;status</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Mscomct2ReferenceStatus&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Incorrect&nbsp;status.&nbsp;Close&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;You&nbsp;do&nbsp;not&nbsp;have&nbsp;a&nbsp;correct&nbsp;registration&nbsp;or&nbsp;reference&nbsp;to&nbsp;the&nbsp;support&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;file&nbsp;mscomct2.ocx&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;Possible&nbsp;causes&nbsp;for&nbsp;the&nbsp;problem:&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;1.&nbsp;&nbsp;The&nbsp;file&nbsp;was&nbsp;not&nbsp;installed&nbsp;on&nbsp;your&nbsp;computer&nbsp;or&nbsp;it&nbsp;is&nbsp;not&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;located&nbsp;in&nbsp;the&nbsp;'Support'&nbsp;folder&nbsp;as&nbsp;it&nbsp;should&nbsp;be.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;(!)&nbsp;Make&nbsp;sure&nbsp;the&nbsp;file&nbsp;is&nbsp;located&nbsp;correctly&nbsp;in&nbsp;a&nbsp;subfolder&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;'Support'&nbsp;under&nbsp;the&nbsp;folder&nbsp;containing&nbsp;this&nbsp;excel&nbsp;file.&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;2.&nbsp;&nbsp;The&nbsp;file&nbsp;mscomct2.ocx&nbsp;exists&nbsp;but&nbsp;Excel&nbsp;was&nbsp;not&nbsp;able&nbsp;to&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;correct&nbsp;a&nbsp;broken&nbsp;reference&nbsp;to&nbsp;it.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;(!)&nbsp;To&nbsp;fix&nbsp;this&nbsp;problem&nbsp;close&nbsp;all&nbsp;open&nbsp;Workbooks&nbsp;(excel&nbsp;files)&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;and&nbsp;restart&nbsp;only&nbsp;this&nbsp;file.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;3.&nbsp;&nbsp;You&nbsp;are&nbsp;using&nbsp;unsupported&nbsp;Windows&nbsp;or&nbsp;Office&nbsp;version.&quot;</span>&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;(!)&nbsp;Call&nbsp;your&nbsp;system&nbsp;administrator&nbsp;to&nbsp;fix&nbsp;this&nbsp;problem.&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbInformation,&nbsp;<span class="visualBasic__string">&quot;Excel&nbsp;aborted&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;The&nbsp;application&nbsp;in&nbsp;this&nbsp;file&nbsp;may&nbsp;not&nbsp;work&nbsp;correctly.&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;The&nbsp;file&nbsp;must&nbsp;be&nbsp;closed&nbsp;in&nbsp;order&nbsp;to&nbsp;prevent&nbsp;ambiguous&nbsp;results.&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbInformation,&nbsp;<span class="visualBasic__string">&quot;Excel&nbsp;aborted&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Close&nbsp;file</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ActiveWorkbook.Close&nbsp;SaveChanges:=<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Exit</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bMscomct2ReferenceStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;A&nbsp;valid,&nbsp;unbroken,&nbsp;reference&nbsp;to&nbsp;mscomct2.ocx&nbsp;was&nbsp;found.&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbInformation,&nbsp;<span class="visualBasic__string">&quot;Reference&nbsp;validation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;bMscomct2ReferenceStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Function&nbsp;will&nbsp;find&nbsp;if&nbsp;trust&nbsp;access&nbsp;to&nbsp;VBA&nbsp;object&nbsp;module(in&nbsp;Options)&nbsp;is&nbsp;checked.</span>&nbsp;
<span class="visualBasic__com">'This&nbsp;is&nbsp;a&nbsp;general&nbsp;property&nbsp;of&nbsp;Excel&nbsp;applied&nbsp;to&nbsp;all&nbsp;Workbooks&nbsp;(that&nbsp;are&nbsp;already&nbsp;open</span>&nbsp;
<span class="visualBasic__com">'or&nbsp;will&nbsp;be&nbsp;opened).</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;TrustAccessToVBA()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Response&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;VisualBasicProject&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;TrustAccessToVBA&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;<span class="visualBasic__keyword">Error</span>&nbsp;<span class="visualBasic__keyword">Resume</span>&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Check&nbsp;if&nbsp;trust&nbsp;center&nbsp;is&nbsp;alowing&nbsp;to&nbsp;run&nbsp;macros</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;VisualBasicProject&nbsp;=&nbsp;ActiveWorkbook.VBProject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;Err.Number&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Response&nbsp;=&nbsp;MsgBox(<span class="visualBasic__string">&quot;Programme&nbsp;Stopped.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;Your&nbsp;current&nbsp;security&nbsp;settings&nbsp;do&nbsp;not&nbsp;allow&nbsp;the&nbsp;code&nbsp;in&nbsp;this&nbsp;workbook&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;to&nbsp;work&nbsp;as&nbsp;designed&nbsp;and&nbsp;you&nbsp;will&nbsp;get&nbsp;error&nbsp;messages.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;To&nbsp;allow&nbsp;the&nbsp;code&nbsp;to&nbsp;function&nbsp;correctly&nbsp;and&nbsp;without&nbsp;errors&nbsp;you&nbsp;need&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;to&nbsp;change&nbsp;your&nbsp;security&nbsp;setting&nbsp;as&nbsp;follows:&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;1.&nbsp;Click&nbsp;OK&nbsp;to&nbsp;go&nbsp;directly&nbsp;to&nbsp;the&nbsp;security&nbsp;centre&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;&nbsp;2.&nbsp;Check&nbsp;'Trust&nbsp;access&nbsp;to&nbsp;VBA&nbsp;project&nbsp;object&nbsp;model'&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbOKCancel&nbsp;&#43;&nbsp;vbCritical)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Response&nbsp;=&nbsp;vbOK&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.CommandBars(<span class="visualBasic__string">&quot;Macro&quot;</span>).Controls(<span class="visualBasic__string">&quot;Security...&quot;</span>).Execute&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Retesting&nbsp;if&nbsp;user&nbsp;has&nbsp;allowed&nbsp;access&nbsp;to&nbsp;the&nbsp;VBA&nbsp;project&nbsp;object&nbsp;model</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'1st&nbsp;-&nbsp;Reset&nbsp;last&nbsp;error&nbsp;value</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Err.Number&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'2nd&nbsp;-&nbsp;Recall&nbsp;the&nbsp;VBProject&nbsp;in&nbsp;order&nbsp;to&nbsp;see&nbsp;if&nbsp;it&nbsp;generate&nbsp;an&nbsp;error</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;VisualBasicProject&nbsp;=&nbsp;ActiveWorkbook.VBProject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'3rd&nbsp;-&nbsp;Check&nbsp;if&nbsp;an&nbsp;error&nbsp;was&nbsp;generated</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Err.Number&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;Access&nbsp;to&nbsp;the&nbsp;VBA&nbsp;project&nbsp;object&nbsp;model&nbsp;was&nbsp;set&nbsp;to&nbsp;TRUSTED.&quot;</span>,&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;vbApplicationModal&nbsp;&#43;&nbsp;vbInformation,&nbsp;<span class="visualBasic__string">&quot;Excel&nbsp;Setup&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;TrustAccessToVBA&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;VisualBasicProject&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Get&nbsp;the&nbsp;Active&nbsp;Workbook&nbsp;working&nbsp;folder</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;GetMyWorkFolder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;WorkPath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;AWB&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;Workbook&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;AWB&nbsp;=&nbsp;ActiveWorkbook&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;WorkFolder&nbsp;=&nbsp;AWB.Path&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;WorkFolder&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;File&nbsp;is&nbsp;not&nbsp;saved.&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;AWB&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Set&nbsp;the&nbsp;the&nbsp;path&nbsp;for&nbsp;the&nbsp;Support&nbsp;folder&nbsp;for&nbsp;this&nbsp;Workbook</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;SetSupportFolder()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;SupportFolder&nbsp;=&nbsp;WorkFolder&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;\&quot;&nbsp;&amp;&nbsp;&quot;</span>Support\&quot;&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Find&nbsp;if&nbsp;mscomct2.ocx&nbsp;exsist&nbsp;in&nbsp;the&nbsp;Support&nbsp;folder</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Mscomct2Exists(SupportFolderName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;str&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;str&nbsp;=&nbsp;Dir(SupportFolderName&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;mscomct2.ocx&quot;</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;str&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;Mscomct2Exists&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;<span class="visualBasic__keyword">Else</span>:&nbsp;Mscomct2Exists&nbsp;=&nbsp;<span class="visualBasic__keyword">False</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Silently&nbsp;register&nbsp;a&nbsp;file&nbsp;with&nbsp;administrator&nbsp;elevated&nbsp;access</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;RegisterFile(<span class="visualBasic__keyword">ByVal</span>&nbsp;sFileName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ShellExecute&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__string">&quot;runas&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;cmd&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;/c&nbsp;regsvr32&nbsp;/s&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>&nbsp;&amp;&nbsp;sFileName&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>,&nbsp;&quot;C:\&quot;,&nbsp;<span class="visualBasic__number">0</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Silently&nbsp;unregister&nbsp;a&nbsp;file&nbsp;with&nbsp;administrator&nbsp;elevated&nbsp;access</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;UnRegisterFile(<span class="visualBasic__keyword">ByVal</span>&nbsp;sFileName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;ShellExecute&nbsp;<span class="visualBasic__number">0</span>,&nbsp;<span class="visualBasic__string">&quot;runas&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;cmd&quot;</span>,&nbsp;<span class="visualBasic__string">&quot;/c&nbsp;regsvr32&nbsp;/u&nbsp;/s&nbsp;&quot;</span>&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>&nbsp;&amp;&nbsp;sFileName&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;&quot;</span><span class="visualBasic__string">&quot;&quot;</span>,&nbsp;&quot;C:\&quot;,&nbsp;<span class="visualBasic__number">0</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'Check&nbsp;if&nbsp;a&nbsp;reference&nbsp;to&nbsp;mscomct2.ocx&nbsp;exists&nbsp;and&nbsp;if&nbsp;yes&nbsp;what&nbsp;the&nbsp;status&nbsp;of&nbsp;this</span>&nbsp;
<span class="visualBasic__com">'reference.</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;Mscomct2ReferenceStatus()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;VBProj&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;<span class="visualBasic__com">'As&nbsp;VBIDE.VBProject&nbsp;'(In&nbsp;order&nbsp;to&nbsp;use&nbsp;early&nbsp;bound&nbsp;a&nbsp;reference</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'has&nbsp;to&nbsp;be&nbsp;made&nbsp;to&nbsp;the&nbsp;VBIDE&nbsp;library)</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;chkRef&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;sPath&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;RefOK&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;RefNo&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Long</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Get&nbsp;the&nbsp;activedocument's&nbsp;VBA&nbsp;project.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;VBProj&nbsp;=&nbsp;ActiveWorkbook.VBProject&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Go&nbsp;through&nbsp;the&nbsp;listed&nbsp;project&nbsp;references</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;chkRef&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;VBProj.References&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RefNo&nbsp;=&nbsp;RefNo&nbsp;&#43;&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'1st&nbsp;see&nbsp;each&nbsp;referance&nbsp;broken&nbsp;status</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;chkRef.IsBroken&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'2nd&nbsp;check&nbsp;if&nbsp;refarance&nbsp;is&nbsp;mscomct2.ocx.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'This&nbsp;is&nbsp;done&nbsp;thru&nbsp;the&nbsp;referance&nbsp;GUID&nbsp;wich&nbsp;is&nbsp;alwis&nbsp;presend</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'in&nbsp;contrast&nbsp;to&nbsp;the&nbsp;reference&nbsp;name&nbsp;that&nbsp;might&nbsp;be&nbsp;missing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;chkRef.GUID&nbsp;=&nbsp;<span class="visualBasic__string">&quot;{86CF1D34-0C5F-11D2-A9FC-0000F8754DA1}&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Now&nbsp;check&nbsp;if&nbsp;the&nbsp;mscomct2.ocx&nbsp;path&nbsp;is&nbsp;recognized&nbsp;correctly&nbsp;otherwise</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'the&nbsp;reference&nbsp;connectivity&nbsp;to&nbsp;the&nbsp;project&nbsp;is&nbsp;still&nbsp;broken</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">On</span>&nbsp;<span class="visualBasic__keyword">Error</span>&nbsp;<span class="visualBasic__keyword">Resume</span>&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sPath&nbsp;=&nbsp;chkRef.fullpath&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Err.Number&nbsp;=&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'mscomct2.ocx&nbsp;is&nbsp;correctly&nbsp;referenced&nbsp;but!!!</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Even&nbsp;if&nbsp;the&nbsp;reference&nbsp;path&nbsp;is&nbsp;OK&nbsp;the&nbsp;file&nbsp;may&nbsp;be&nbsp;still&nbsp;be&nbsp;missing.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'We&nbsp;need&nbsp;to&nbsp;check&nbsp;if&nbsp;the&nbsp;reference&nbsp;file&nbsp;exists&nbsp;in&nbsp;the&nbsp;registered</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'path.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;Dir(sPath)&nbsp;&lt;&gt;&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;&quot;Ref&nbsp;path&nbsp;is&nbsp;OK&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Even&nbsp;if&nbsp;the&nbsp;file&nbsp;exist&nbsp;the&nbsp;reference&nbsp;may&nbsp;be&nbsp;corrupt.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'We&nbsp;will&nbsp;now&nbsp;check&nbsp;if&nbsp;the&nbsp;reference&nbsp;file&nbsp;is&nbsp;lockated&nbsp;in&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'support&nbsp;file.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'1st&nbsp;we&nbsp;will&nbsp;check&nbsp;if&nbsp;the&nbsp;Support&nbsp;file&nbsp;path&nbsp;is&nbsp;set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;SupportFolder&nbsp;=&nbsp;<span class="visualBasic__string">&quot;&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GetMyWorkFolder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SetSupportFolder&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;sPath&nbsp;=&nbsp;SupportFolder&nbsp;&amp;&nbsp;<span class="visualBasic__string">&quot;mscomct2.ocx&quot;</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'Only&nbsp;if&nbsp;the&nbsp;reference&nbsp;file&nbsp;is&nbsp;lockated&nbsp;in&nbsp;the&nbsp;Support</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'folder&nbsp;we&nbsp;will&nbsp;concider&nbsp;it&nbsp;as&nbsp;OK.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RefOK&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;VBProj.Remove&nbsp;RefNo&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;RefOK&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;Mscomct2ReferenceStatus&nbsp;=&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;VBProj&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;chkRef&nbsp;=&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''</span>&nbsp;
<span class="visualBasic__com">'&nbsp;The&nbsp;following&nbsp;two&nbsp;procedures&nbsp;are&nbsp;used&nbsp;in&nbsp;order&nbsp;to&nbsp;prevent&nbsp;compilation&nbsp;errors:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;1.&nbsp;A&nbsp;direct&nbsp;call&nbsp;to&nbsp;CalendarForm.show&nbsp;may&nbsp;result&nbsp;in&nbsp;compilation&nbsp;error&nbsp;when&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mscomct.ocx&nbsp;is&nbsp;not&nbsp;referenced&nbsp;correctly.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;2.&nbsp;The&nbsp;error&nbsp;will&nbsp;be&nbsp;triggered&nbsp;by&nbsp;the&nbsp;declaration&nbsp;of&nbsp;MSComCtl2.MonthView.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;To&nbsp;protect&nbsp;user&nbsp;from&nbsp;this&nbsp;annoyance,&nbsp;calls&nbsp;to&nbsp;CalendarForm&nbsp;must&nbsp;be&nbsp;blocked&nbsp;unless&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;unbroken&nbsp;reference&nbsp;is&nbsp;confirmed.&nbsp;We&nbsp;will&nbsp;do&nbsp;it&nbsp;as&nbsp;follows:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;1.&nbsp;&nbsp;A&nbsp;call&nbsp;to&nbsp;CalendarForm.show&nbsp;will&nbsp;be&nbsp;conditioned&nbsp;on&nbsp;verifying&nbsp;correct&nbsp;reference&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;to&nbsp;mscomct2.ocx&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;2.&nbsp;&nbsp;We&nbsp;will&nbsp;prevent&nbsp;compilation&nbsp;errors&nbsp;by&nbsp;an&nbsp;indirect&nbsp;call&nbsp;to&nbsp;procedure&nbsp;containing&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;the&nbsp;command&nbsp;CalendarForm.show&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'</span>&nbsp;
<span class="visualBasic__com">'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'These&nbsp;procedures&nbsp;will&nbsp;protect&nbsp;user&nbsp;from&nbsp;compilation&nbsp;errors</span>&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ShowMonthPickerForm()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;bMscomct2ReferenceStatus&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Application.Run&nbsp;<span class="visualBasic__string">&quot;MonthPickerForm&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Else</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MsgBox&nbsp;<span class="visualBasic__string">&quot;The&nbsp;Date-Picker&nbsp;is&nbsp;not&nbsp;availble.&quot;</span>&nbsp;&amp;&nbsp;vbNewLine&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;You&nbsp;need&nbsp;to&nbsp;restart&nbsp;this&nbsp;file&nbsp;or&nbsp;call&nbsp;your&nbsp;adiministrator&nbsp;to&nbsp;fix&nbsp;&quot;</span>&nbsp;&amp;&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__string">&quot;the&nbsp;problem.&quot;</span>,&nbsp;vbExclamation,&nbsp;<span class="visualBasic__string">&quot;Date&nbsp;Picker&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__com">'A&nbsp;procedure&nbsp;called&nbsp;only&nbsp;if&nbsp;mscomct2.ocx&nbsp;is&nbsp;referenced&nbsp;correctly</span>&nbsp;
<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;MonthPickerForm()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CalendarForm.Show&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<p>8. Add the following code to the Workbook object (when used with Excel)</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>

<div class="preview">
<pre class="js">Private&nbsp;Sub&nbsp;Workbook_Open()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;CheckAndFixReferences&nbsp;
End&nbsp;Sub&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">&nbsp;</div>
<ul>
<li>This code will run every time the file is opened to verify reference validity.
</li><li>In the Straw House and Wood House strategies it will probably look different: You may call it per specific request or in the&nbsp;first time the file is used.
</li></ul>
<p>&nbsp;</p>
<h1>How to activate the DatePicker</h1>
<p>To activate the DatePicker you need to call the procedure <strong><em>ShowMonthPickerForm()
</em></strong>located in the standard module (Module1).</p>
<p>It will use the current active cell input as a date baseline when showing the DatePicker dialog and then it will return to the same cell the selected date.</p>
<p>Three basic options may be used to call the DatePicker:</p>
<p>1. Add a button to the file menu (the professional way)</p>
<p style="padding-left:30px">In Excel 2007, 2010 it is called - Fluent Ribbon. The implementation is more complicated in office 2007 (see link for more help
<a href="http://msdn.microsoft.com/en-us/library/aa338202%28v=office.12%29.aspx">
http://msdn.microsoft.com/en-us/library/aa338202%28v=office.12%29.aspx</a>) but in Excel 2010 it is easier to implement.</p>
<p style="padding-left:30px">The ribbon may look like this:</p>
<p><img id="70084" src="70084-ribbon.png" alt="" width="200" height="200" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;2. Floating buttons (a lot of hassle for little gain)</p>
<p style="padding-left:30px">You will need to work with events (e.g. Worksheet_SelectionChange, Worksheet_Activate, etc.) and probably create floating buttons to generate a call to the DataPicker once a cell is pressed. See link:
<a href="http://manan-shahsblog.blogspot.co.il/2012/02/date-picker-in-excel-for-any-cell.html">
</a></p>
<p style="padding-left:30px"><a href="http://manan-shahsblog.blogspot.co.il/2012/02/date-picker-in-excel-for-any-cell.html">http://manan-shahsblog.blogspot.co.il/2012/02/date-picker-in-excel-for-any-cell.html</a></p>
<p style="padding-left:30px"><a href="http://www.yogeshguptaonline.com/2010/01/excel-macros-excel-date-picker.html">http://www.yogeshguptaonline.com/2010/01/excel-macros-excel-date-picker.html</a></p>
<p>3. Enter a button to a Worksheet (the easiest way)</p>
<ul>
<li>Add a Button to a Sheet via the developer tab </li><li>Thru the Assign Macro dialog add the procedure <em><strong>ShowMonthPickerForm()</strong></em>
</li></ul>
<p>May look like this:</p>
<p><img id="70085" src="70085-button.png" alt="" width="204" height="200" style="display:block; margin-left:auto; margin-right:auto"></p>
<p>&nbsp;Finally you may also simply define a shortcut key to activate the procedure.</p>
<p>&nbsp;</p>
<h1>Samples</h1>
<p>&nbsp;You may find&nbsp;two&nbsp;attached Excel 2007 sample files&nbsp;that you may use as a starter.</p>
