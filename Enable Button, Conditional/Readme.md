# Enable Button, Conditional
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- WPF
- XAML
## Topics
- DataGrid
- WPF Commanding
- Button
- Relay Commands
- CanExecute
## Updated
- 09/19/2012
## Description

<h1>Introduction</h1>
<p>This is just a simple sample to show how Commands can trigger the enabled or disabled state of a button, and how you can define that state by other factors in the view, like in this case, if any CheckBoxes are checked, in the CheckBox column of a DataGrid.</p>
<p><img id="65907" src="65907-condit.png" alt="" width="347" height="242" style="margin-right:auto; margin-left:auto; display:block"></p>
<p>&nbsp;</p>
<h1><span>Building the Sample</span></h1>
<p>Just download, unzip, open and run!</p>
<p>&nbsp;</p>
<h1><span style="font-size:20px">Description</span></h1>
<p>This sample simply shows how to use a Command to control both the actions and the state of another control. In this case, it is controlling the state and action of a Button.</p>
<p>&nbsp;</p>
<p>For this example, we are using a classic RelayCommand, as documented <a href="http://msdn.microsoft.com/en-us/magazine/dd419663.aspx">
here</a>.</p>
<p>The Command has a CanExecute delegate, with which we are&nbsp;returning true/false&nbsp;based on properties of a collection.</p>
<p>The collection is used as ItemsSource for a DataGrid. The DataGrid has a CheckBox column with is bound to the IsSelected property of the class in our ItemsSource collection.</p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>XAML</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">xaml</span>
<pre class="hidden">&lt;StackPanel&gt;
    &lt;DataGrid ItemsSource=&quot;{Binding MyList}&quot; AutoGenerateColumns=&quot;False&quot; CanUserAddRows=&quot;False&quot;&gt;
        &lt;DataGrid.Columns&gt;
            &lt;DataGridTextColumn Header=&quot;Description&quot; Binding=&quot;{Binding Description}&quot;/&gt;
            &lt;DataGridCheckBoxColumn Header=&quot;Select&quot; Binding=&quot;{Binding IsSelected, UpdateSourceTrigger=PropertyChanged}&quot;/&gt;
        &lt;/DataGrid.Columns&gt;
    &lt;/DataGrid&gt;
    &lt;Button Content=&quot;Something is selected, do stuff!&quot; Command=&quot;{Binding DoStuffCommand}&quot; Width=&quot;200&quot; Margin=&quot;0,10,0,0&quot;/&gt;
&lt;/StackPanel&gt;</pre>
<div class="preview">
<pre class="js">&lt;StackPanel&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGrid&nbsp;ItemsSource=<span class="js__string">&quot;{Binding&nbsp;MyList}&quot;</span>&nbsp;AutoGenerateColumns=<span class="js__string">&quot;False&quot;</span>&nbsp;CanUserAddRows=<span class="js__string">&quot;False&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGrid.Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGridTextColumn&nbsp;Header=<span class="js__string">&quot;Description&quot;</span>&nbsp;Binding=<span class="js__string">&quot;{Binding&nbsp;Description}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataGridCheckBoxColumn&nbsp;Header=<span class="js__string">&quot;Select&quot;</span>&nbsp;Binding=<span class="js__string">&quot;{Binding&nbsp;IsSelected,&nbsp;UpdateSourceTrigger=PropertyChanged}&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataGrid.Columns&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataGrid&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Button&nbsp;Content=<span class="js__string">&quot;Something&nbsp;is&nbsp;selected,&nbsp;do&nbsp;stuff!&quot;</span>&nbsp;Command=<span class="js__string">&quot;{Binding&nbsp;DoStuffCommand}&quot;</span>&nbsp;Width=<span class="js__string">&quot;200&quot;</span>&nbsp;Margin=<span class="js__string">&quot;0,10,0,0&quot;</span>/&gt;&nbsp;
&lt;/StackPanel&gt;</pre>
</div>
</div>
</div>
<div class="endscriptcode">Whenever there are any changes in the UI, the CanExecute is re-evaluated.</div>
<div class="endscriptcode">If it finds any IsSelected properties set to true, then&nbsp;it returns &quot;true&quot;, which in turn enables the Button.</div>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>
<pre class="hidden">bool DoStuffCanExecute(object param)
{
    foreach (var obj in MyList)
        if (obj.IsSelected) return true;

    return false;
}</pre>
<div class="preview">
<pre class="js">bool&nbsp;DoStuffCanExecute(object&nbsp;param)&nbsp;
<span class="js__brace">{</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;foreach&nbsp;(<span class="js__statement">var</span>&nbsp;obj&nbsp;<span class="js__operator">in</span>&nbsp;MyList)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">if</span>&nbsp;(obj.IsSelected)&nbsp;<span class="js__statement">return</span>&nbsp;true;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="js__statement">return</span>&nbsp;false;&nbsp;
<span class="js__brace">}</span></pre>
</div>
</div>
</div>
<div class="endscriptcode">Note: The only problem with this quick sample is that DataGrid needs two clicks to change the CheckBox (one to select the row, another to change the CheckBox). This is a well known issue with DataGrid, and not part of this demonstration,&nbsp;because
 there are plenty of examples around that show how to get round that.</div>
<p>&nbsp;</p>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>MainWindow.xaml - startup window</em> </li><li><em>MainWindow.xaml.cs - assigns the ViewModel</em> </li><li><em>MainViewModel.cs - Holds dummy data, command, and&nbsp;canExecute/execute</em>
</li><li><em>ViewModelBase - just a INPC base class</em> </li><li><em>RelayCommand.cs - classic Relay Command as per MSDN</em> </li></ul>
<p><a href="http://social.msdn.microsoft.com/Forums/en/wpf/thread/24c8be07-8b16-46f8-aa4e-0d4b53b09358"></a></p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p><img src="-anithanks1.gif" alt="" style="margin-right:auto; margin-left:auto; display:block"></p>
