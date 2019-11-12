# Get Password from PasswordBox with MVVM in a secure and simple way
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- C#
- WPF
- XAML
- .NET Framework
- MVVM
## Topics
- MVVM
- WPF Data Binding
- password
- securestring
- PasswordBox
## Updated
- 01/22/2015
## Description

<h1>Introduction</h1>
<p>It is not possible to bind the value of a PasswordBox in WPF/MVVM. To access the password in the ViewModel in a secure way some work have to be done.<em><br>
</em></p>
<h1><span>Building the Sample</span></h1>
<p>There are no special requirements for building the sample.<em><em> </em></em></p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>To solve the problem we are using a RelayCommand that is using the View as parameter. The View implements an interface that is used to access the password. So the parameter is casted to the interface that the ViewModel implements. The interface provides
 a property of type SecureString so the password is protected by encryption until it is needed to check the password value. A method is presented to obtain the value of a SecureString.</p>
<p>&nbsp;</p>
<p>The interface:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;<span class="cs__keyword">interface</span>&nbsp;IHavePassword&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;System.Security.SecureString&nbsp;Password&nbsp;{&nbsp;<span class="cs__keyword">get</span>;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>The code-behind of the View:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">public</span>&nbsp;partial&nbsp;<span class="cs__keyword">class</span>&nbsp;LoginView&nbsp;:&nbsp;UserControl,&nbsp;IHavePassword&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;LoginView()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;InitializeComponent();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataContext&nbsp;=&nbsp;<span class="cs__keyword">new</span>&nbsp;LoginViewModel();&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">public</span>&nbsp;System.Security.SecureString&nbsp;Password&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;UserPassword.SecurePassword;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>The XAML part of the View:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>

<div class="preview">
<pre class="xaml"><span class="xaml__tag_start">&lt;UserControl</span>&nbsp;x:<span class="xaml__attr_name">Class</span>=<span class="xaml__attr_value">&quot;MvvmPassword.LoginView&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;This&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">xmlns</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__keyword">xmlns</span>:<span class="xaml__attr_name">x</span>=<span class="xaml__attr_value">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Grid</span><span class="xaml__tag_start">&gt;&nbsp;
</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;PasswordBox</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;UserPassword&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Column</span>=<span class="xaml__attr_value">&quot;1&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4&quot;</span>&nbsp;<span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_start">&lt;Button</span>&nbsp;x:<span class="xaml__attr_name">Name</span>=<span class="xaml__attr_value">&quot;Login&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">Row</span>=<span class="xaml__attr_value">&quot;3&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Grid.<span class="xaml__attr_name">ColumnSpan</span>=<span class="xaml__attr_value">&quot;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Margin</span>=<span class="xaml__attr_value">&quot;4&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Content</span>=<span class="xaml__attr_value">&quot;Login&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">Command</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;LoginCommand}&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__attr_name">CommandParameter</span>=<span class="xaml__attr_value">&quot;{Binding&nbsp;ElementName=This}&quot;</span><span class="xaml__tag_start">/&gt;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;...&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="xaml__tag_end">&lt;/Grid&gt;</span>&nbsp;
<span class="xaml__tag_end">&lt;/UserControl&gt;</span></pre>
</div>
</div>
</div>
<p>The ViewModel:</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">void</span>&nbsp;Login(<span class="cs__keyword">object</span>&nbsp;parameter)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;passwordContainer&nbsp;=&nbsp;parameter&nbsp;<span class="cs__keyword">as</span>&nbsp;IHavePassword;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(passwordContainer&nbsp;!=&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;var&nbsp;secureString&nbsp;=&nbsp;passwordContainer.Password;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;PasswordInVM&nbsp;=&nbsp;ConvertToUnsecureString(secureString);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>Converting SecureString to string (Source: <a href="http://blogs.msdn.com/b/fpintos/archive/2009/06/12/how-to-properly-convert-securestring-to-string.aspx">
How to properly convert SecureString to String by Fabio Pintos</a>)</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp"><span class="cs__keyword">private</span>&nbsp;<span class="cs__keyword">string</span>&nbsp;ConvertToUnsecureString(SecureString&nbsp;securePassword)&nbsp;
{&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">if</span>&nbsp;(securePassword&nbsp;==&nbsp;<span class="cs__keyword">null</span>)&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;<span class="cs__keyword">string</span>.Empty;&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;IntPtr&nbsp;unmanagedString&nbsp;=&nbsp;IntPtr.Zero;&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">try</span>&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;unmanagedString&nbsp;=&nbsp;Marshal.SecureStringToGlobalAllocUnicode(securePassword);&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="cs__keyword">return</span>&nbsp;Marshal.PtrToStringUni(unmanagedString);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;&nbsp;&nbsp;<span class="cs__keyword">finally</span>&nbsp;
&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);&nbsp;
&nbsp;&nbsp;&nbsp;}&nbsp;
}</pre>
</div>
</div>
</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em><em>source code file name LoginView.xaml - the View.</em></em> </li><li><em><em>source code file name LoginView.cs - code behind part of the View, setting of the DataContext.</em></em>
</li><li><em><em>source code file name LoginViewModel.cs - the ViewModel.</em></em> </li></ul>
<ul>
</ul>
<h1>More Information</h1>
<p><em><strong><em><strong>For further code samples visit <em><a href="http://chrigas.blogspot.com/">http://chrigas.blogspot.com/</a></em></strong></em></strong></em></p>
<p>&nbsp;</p>
<p>See also <a href="http://chrigas.blogspot.com/2014/07/get-password-from-wpf-passwordbox-with.html">
http://chrigas.blogspot.com/2014/07/get-password-from-wpf-passwordbox-with.html</a></p>
