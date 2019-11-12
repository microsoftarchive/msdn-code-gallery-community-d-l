# In place hint messages for user input text box or password text in WPF
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- WPF
- WPF Adornor
- WPF CustomControl
## Updated
- 10/09/2011
## Description

<h1>Introduction</h1>
<p><em>Building an in place hit messages for user input text box or password text in WPF, similar to Windows Vista/7 login screen.</em></p>
<h1><span>Building the Sample</span></h1>
<p><em>Visual Studio 2010/.NET 4</em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>Smiliar to Windows Vista/7 logon screen, a text hint/message is displayed in place with the text box or password control, as shown in the following image</p>
<p><img src="45042-1.jpg" alt="" width="231" height="100"></p>
<p>Once the input is not empty, the hint message will disappear.</p>
<p>The implementation is based on Adornor (for detailed explaination, please refer to
<a href="http://msdn.microsoft.com/en-us/library/ms743737.aspx">this</a>). The actual implementation inserts an adornor layer on the fly for the UI element that the input message needs to be displayed.</p>
<p>How to use: OverlayTextService provides attached property Text for the message/hint to show in place with WPF TextBox/PasswordBox, similar to the following</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;TextBox x:Name=&quot;UserNameTextBox&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Controls:OverlayTextService.Text =&quot;User...&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Grid.Row=&quot;2&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Grid.Column=&quot;1&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Margin=&quot;4, 4, 2, 2&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Style=&quot;{StaticResource InputTextStyle}&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Text=&quot;{Binding Path=UserName, UpdateSourceTrigger=PropertyChanged}&quot;/&gt;&nbsp;&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>OverlayTextControl: Control to render an input hint or message on top of the text box or password box</em><em><em>source
</em></em></li><li>OverlayTextAdorner: Custom Adorner implementation to host OverlayTextControl </li><li>OverlayTextService: Host for the text property to be displayed for input hint or message by attached property
</li></ul>
<h1>More Information</h1>
