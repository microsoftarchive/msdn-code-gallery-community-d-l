# Disable ComboBoxItem in WPF ComboBox Control using Converter
## Requires
- Visual Studio 2010
## License
- MS-LPL
## Technologies
- C#
- WPF
## Topics
- How to Disable ComboBoxItem in WPF using Converter
## Updated
- 12/10/2014
## Description

<h1>Introduction</h1>
<p><span style="color:#000080"><em><br>
<strong>Disabling ComboBoxItem in WPF ComboBox Control using Converter : Many would have come across a scenario where-in you need to disable few items in comboBox based on businees needs or project requirements.This article will help you to do the same.</strong></em></span></p>
<h1><span style="font-size:20px; font-weight:bold">Description</span></h1>
<p>Step - 1 : Create Combbox in XAML and Bind ItemSource of CombBox</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Window x:Class=&quot;ComboboxDisable.WPFComboboxWindow&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns=&quot;<a href="http://schemas.microsoft.com/winfx/2006/xaml/presentation">http://schemas.microsoft.com/winfx/2006/xaml/presentation</a>&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns:x=&quot;<a href="http://schemas.microsoft.com/winfx/2006/xaml">http://schemas.microsoft.com/winfx/2006/xaml</a>&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Title=&quot;ComboboxItemDisable&quot; Height=&quot;165&quot; Width=&quot;332&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; xmlns:local=&quot;clr-namespace:ComboboxDisable&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp; &lt;Grid Height=&quot;130&quot; Width=&quot;316&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox Height=&quot;23&quot; HorizontalAlignment=&quot;Left&quot; Margin=&quot;78,12,0,0&quot; Name=&quot;comboBox1&quot; VerticalAlignment=&quot;Top&quot; Width=&quot;120&quot;
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ItemsSource=&quot;{Binding Items}&quot; Background=&quot;Bisque&quot; Foreground=&quot;Black&quot;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SelectedIndex=&quot;0&quot; &gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ComboBox&gt;<br>
&nbsp;&nbsp;&nbsp; &lt;/Grid&gt;<br>
&lt;/Window&gt; <br>
&nbsp; Step - 2 :Create Class for Binding Itmsource with List&lt;String&gt; collections</p>
<p>public class ExampleClass <br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Field for storing collection<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; private List&lt;String&gt; items;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // Property for Storing Collections<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public List&lt;String&gt; Items<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; get { return items; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; set {items = value;}<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// Constructor<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; /// &lt;/summary&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public ExampleClass()<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {&nbsp;&nbsp; <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items = new List&lt;String&gt;();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.Add(&quot;CollectionItem1&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.Add(&quot;CollectionItem2&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.Add(&quot;CollectionItem3&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.Add(&quot;CollectionItem4&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; items.Add(&quot;CollectionItem5&quot;);<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp; }<br>
&nbsp; <br>
Step -3 : Create Converter Class for Disabling Items in ComboBox&nbsp;</p>
<p>&nbsp;Below Converter will Disable 2nd and 3rd Item from ComboBox[You can have your own custom logic for which conditon the combobox item should be disabled]</p>
<p>&nbsp;namespace ComboboxDisable<br>
{<br>
&nbsp;&nbsp;&nbsp; // Converter for disabling ComboboxItem<br>
&nbsp;&nbsp;&nbsp; class ComboboxDisableConverter : IValueConverter<br>
&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object Convert(object value, Type targetType, object parameter, System.Globa&nbsp;&nbsp;lization.CultureInfo culture)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (value == null)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return value;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; // You can add your custom logic here to disable combobox item<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; if (value == &quot;CollectionItem2&quot; || value == &quot;CollectionItem3&quot;)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return true;</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; return false;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }</p>
<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; public object ConvertBack(object value, Type targetType, object parameter, System.G&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;lobalization.CultureInfo culture)<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; {<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; throw new NotImplementedException();<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; }<br>
&nbsp;&nbsp;&nbsp; }<br>
}<br>
&nbsp; <br>
&nbsp;</p>
<p>Step - 4 : Now Modify your XAML file by specifying the ItemContainerStyle for ComboBox and including Converter</p>
<p>//<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;!--Resource for Combobox to --&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox.Resources&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;local:ComboboxDisableConverter x:Key=&quot;itemDisableconverter&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ComboBox.Resources&gt;<br>
//&nbsp;&nbsp;&nbsp;&nbsp; <br>
&lt;!--ItemContainer Style for disabling Combobox Item--&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;ComboBox.ItemContainerStyle&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Style TargetType=&quot;ComboBoxItem&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Style.Triggers&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;DataTrigger Binding=&quot;{Binding Path=Content, RelativeSource={Relati&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;veSource Self},
<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Converter={StaticResource itemDisableconverter}}&quot; Value=&quot;true&quot;&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;Setter Property=&quot;IsEnabled&quot; Value=&quot;False&quot;/&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/DataTrigger&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Style.Triggers&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/Style&gt;<br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &lt;/ComboBox.ItemContainerStyle&gt;
<br>
By including above set of blocks in your XAML, your final XAML will look like the below once</p>
<p><br>
&nbsp;Execute the project and open the comboBox you will see the 2nd and 3rd item is disabled and user can't select it.</p>
<p><em>.&nbsp;&nbsp;&nbsp;<img id="102655" src="102655-disablecomboboxitem-wpf.png" alt="" width="252" height="166"></em></p>
<p>&nbsp;</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">csharp</span>

<div class="preview">
<pre class="csharp">&lt;Window&nbsp;x:Class=<span class="cs__string">&quot;ComboboxDisable.WPFComboboxWindow&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml/presentation&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:x=<span class="cs__string">&quot;http://schemas.microsoft.com/winfx/2006/xaml&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Title=<span class="cs__string">&quot;ComboboxItemDisable&quot;</span>&nbsp;Height=<span class="cs__string">&quot;165&quot;</span>&nbsp;Width=<span class="cs__string">&quot;332&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;xmlns:local=<span class="cs__string">&quot;clr-namespace:ComboboxDisable&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;Grid&nbsp;Height=<span class="cs__string">&quot;130&quot;</span>&nbsp;Width=<span class="cs__string">&quot;316&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBox&nbsp;Height=<span class="cs__string">&quot;23&quot;</span>&nbsp;HorizontalAlignment=<span class="cs__string">&quot;Left&quot;</span>&nbsp;Margin=<span class="cs__string">&quot;78,12,0,0&quot;</span>&nbsp;Name=<span class="cs__string">&quot;comboBox1&quot;</span>&nbsp;VerticalAlignment=<span class="cs__string">&quot;Top&quot;</span>&nbsp;Width=<span class="cs__string">&quot;120&quot;</span>&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ItemsSource=<span class="cs__string">&quot;{Binding&nbsp;Items}&quot;</span>&nbsp;Background=<span class="cs__string">&quot;Bisque&quot;</span>&nbsp;Foreground=<span class="cs__string">&quot;Black&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SelectedIndex=<span class="cs__string">&quot;0&quot;</span>&nbsp;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--Resource&nbsp;<span class="cs__keyword">for</span>&nbsp;Combobox&nbsp;to&nbsp;--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBox.Resources&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;local:ComboboxDisableConverter&nbsp;x:Key=<span class="cs__string">&quot;itemDisableconverter&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ComboBox.Resources&gt;&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;!--ItemContainer&nbsp;Style&nbsp;<span class="cs__keyword">for</span>&nbsp;disabling&nbsp;Combobox&nbsp;Item--&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;ComboBox.ItemContainerStyle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Style&nbsp;TargetType=<span class="cs__string">&quot;ComboBoxItem&quot;</span>&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Style.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;DataTrigger&nbsp;Binding=&quot;{Binding&nbsp;Path=Content,&nbsp;RelativeSource={RelativeSource&nbsp;Self},&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Converter={StaticResource&nbsp;itemDisableconverter}}<span class="cs__string">&quot;&nbsp;Value=&quot;</span><span class="cs__keyword">true</span>&quot;&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;Setter&nbsp;Property=<span class="cs__string">&quot;IsEnabled&quot;</span>&nbsp;Value=<span class="cs__string">&quot;False&quot;</span>/&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/DataTrigger&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Style.Triggers&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Style&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ComboBox.ItemContainerStyle&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&lt;/ComboBox&gt;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&lt;/Grid&gt;&nbsp;
&lt;/Window&gt;&nbsp;&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>source code file name #1 - summary for this source code file.</em> </li><li><em><em>source code file name #2 - summary for this source code file.</em></em>
</li></ul>
<h1>More Information</h1>
<p><em>For more information on X, see ...?</em></p>
