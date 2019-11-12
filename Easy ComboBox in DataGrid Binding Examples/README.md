# Easy ComboBox in DataGrid Binding Examples
## Requires
- Visual Studio 2013
## License
- Apache License, Version 2.0
## Technologies
- WPF
## Topics
- DataGrid
- ComboBox
- WPF Data Binding
- ItemsSource
## Updated
- 09/27/2014
## Description

<h1>Introduction</h1>
<p>One problem for developers new to XAML is binding a combobox in a DataGrid.&nbsp;&nbsp;This is a fairly common question in the WPF forum so posters are somehow not finding an article which helps them.&nbsp;Maybe they find a resource but it's not clear enough
 how things work - this is quite a complicated and confusing subject.&nbsp;&nbsp;There are a number of properties which don't work quite how one might expect - Binding the ItemsSource is particularly tricky.&nbsp;&nbsp;This article will hopefully be found by
 developers having problems and clear up any confusion.&nbsp;</p>
<p>&nbsp;</p>
<p><span style="color:#ff00ff">It takes quite a lot of work to write these articles. If you like the sample and or explanation, please take the time to give it a 5 star rating. Thanks.</span></p>
<h1><span>Building the Sample</span></h1>
<p>The sample was developed using Visual Studio 2013 targeting .Net 4.51. &nbsp;You should be able to open and compile it using VS2012 and later.</p>
<h2><span style="color:#0070c0">DataGridComboBoxColumn vs TemplateColumn</span></h2>
<p><br>
<span>Looking at the possible options for a datagrid column the developer wants a combobox in, the obvious choice would seem to be the DataGridComboBoxColumn.&nbsp;</span><br>
<span>This is the one to go for if you want to display a string in the combobox.&nbsp;</span><br>
<span>You can supply a template for the item but by the time you do that you may as well be using a TemplateColumn.&nbsp;</span><br>
<span>When you want anything other than a string then the column to go with is the TemplateColumn.&nbsp;</span><br>
<br>
</p>
<h2><span style="color:#0070c0">Properties to Bind<br>
</span></h2>
<p><br>
In the following table, those properties which have Yes in the binding will have a {Binding ....} and those which have No will have a text string like &quot;Id&quot;. &nbsp;This is one of those things which is quite difficult to explain in text but much clearer when
 you have a working example. &nbsp; Double check by comparing to the example code.</p>
<p>&nbsp;</p>
<table>
<tbody>
<tr>
<th>ComboBox Property</th>
<th>Explanation</th>
<th>Binding</th>
</tr>
<tr>
<td>ItemsSource</td>
<td>Collection of options in ViewModel/Resource</td>
<td>Or Resource</td>
</tr>
<tr>
<td><span style="background-color:#ffffff">SelectedValuePath</span></td>
<td><span style="background-color:#ffffff">Id from combo item</span></td>
<td><span style="background-color:#ffffff">No</span></td>
</tr>
<tr>
<td>SelectedValueBinding</td>
<td>Id of item in Datagrid row</td>
<td>Yes</td>
</tr>
<tr>
<td>SelectedValue</td>
<td>Id of item in Datagrid row</td>
<td>Yes</td>
</tr>
<tr>
<td>DisplayMemberPath</td>
<td>Name of property to show in combo list from combo item</td>
<td>No</td>
</tr>
</tbody>
</table>
<p><br>
<span>Note that the properties ending in Name or Path are the text names of your properties as opposed to a Binding.&nbsp;</span><br>
<span>As if things weren't confusing enough, the DataGridComboBoxColumn has SelectedValueBinding which is a Binding and a regular ComboBox has SelectedValue which will also be a Binding.&nbsp;</span><br>
<br>
</p>
<h2><a name="Terminology"></a><span style="color:#0070c0">Terminology</span></h2>
<p><br>
<span>In the following the ItemsSource of the Datagrid will be referred to as being an ObservableCollection&lt;DataGridRowViewModel&gt;, the ItemsSource of the ComboBox will be referred to as an ObservableCollection&lt;ComboRowViewModel&gt;.</span><br>
<br>
</p>
<h2><a name="ItemsSource_Binding_Complications"></a><span style="color:#0070c0">ItemsSource Binding Complications</span></h2>
<p><br>
<span>Unless your ComboBox is using a collection within DataGridRowViewModel then there are complications Binding a combo ItemsSource.&nbsp;</span><br>
<span>The combo column look like they're inside the DataGrid so they ought to be in it's datacontext but they only &quot;know&quot; about whatever item they are fed via the ItemsSource of the DataGrid. &nbsp;This is because the columns aren't in the Visual Tree as one
 might imagine.&nbsp;</span><br>
<span>There are two alternative common approaches to resolving the issue.&nbsp;</span><br>
<br>
</p>
<h2><a name="Use_a_Resource"></a><span style="color:#0070c0">Use a Resource</span><br>
<br>
</h2>
<p><span>You can set the ItemsSource to a StaticResource or DyamicResource which is a Resource within scope of the DataGrid.&nbsp;</span><br>
<span>The attraction of this approach is the relative simplicity of the XAML you need. &nbsp;The approach side steps an issue which will become clearer later.&nbsp;</span><br>
<br>
<br>
</p>
<div class="reCodeBlock">
<div><span><code>&lt;</code><code>DataGridComboBoxColumn</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>Header</code><code>=</code><code>&quot;ComboboxColumn&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>ItemsSource</code><code>=</code><code>&quot;{DynamicResource ColourSource}&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>SelectedValueBinding</code><code>=</code><code>&quot;{Binding ColourId, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>SelectedValuePath</code><code>=</code><code>&quot;Id&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>DisplayMemberPath</code><code>=</code><code>&quot;ColourString&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&gt;</code></span></div>
</div>
<p><br>
<span>There are some complications to creating and filling a DynamicResource ObservableCollection which are covered in this article&nbsp;</span><a href="http://social.technet.microsoft.com/wiki/contents/articles/26200.wpf-dynamicresource-observablecollection.aspx">here.</a><span>&nbsp;</span><br>
<span>Exactly what ColourSource is explained there, but it is essentially an ObservableCollection&lt;complexType&gt; which is declared in XAML.</span><br>
<span>The ItemsSource is otherwise hopefully self explanatory.</span><br>
<span style="color:#808080; font-family:monospace">SelectedValueBinding&nbsp;</span><span>is as it's name suggests a Binding to the property in DataGridRowViewModel&nbsp;which will be set as the user chooses an item.</span><br>
<span style="color:#808080; font-family:monospace">SelectedValuePath&nbsp;</span><span>is not a binding and is the name of the property &nbsp;in&nbsp;ComboRowViewModel&nbsp;which will be used to set the SelectedValueBinding property.</span><br>
<span style="color:#808080; font-family:monospace">DisplayMemberPath&nbsp;</span><span>is&nbsp;not a binding and is the name of the property in the ComboRowViewModel&nbsp;to be shown.</span><br>
<br>
</p>
<h2><a name="Bind_to_the_Viewmodel"></a><span style="color:#0070c0">Bind to the Viewmodel</span></h2>
<p><br>
<span>Most WPF developers will be using MVVM and their Window's DataContext will be set to an instance of a ViewModel. The collection the developer usually wants the user to select from in the combo will be an ObservableCollection&lt;RowViewmodel&gt; which
 is a Public property of that ViewModel.&nbsp;</span><br>
<span>There are two aspects to such a binding.&nbsp;</span></p>
<ol>
<li>Find the parent Window using RelativeSource </li><li>Use the Datacontext </li></ol>
<p><br>
<span>This is probably best explained with an example binding:&nbsp;</span><br>
<br>
</p>
<div class="reCodeBlock">
<div><code>&nbsp;&nbsp;</code><span><code>&lt;</code><code>DataGridTemplateColumn</code>&nbsp;<code>Header</code><code>=</code><code>&quot;TemplateColumn&quot;</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>DataGridTemplateColumn.CellTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>DataTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>ComboBox</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>ItemsSource</code><code>=</code><code>&quot;{Binding DataContext.Colours, RelativeSource={RelativeSource AncestorType=local:MainWindow}}&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>SelectedValuePath</code><code>=</code><code>&quot;MColour.Id&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>SelectedValue</code><code>=</code><code>&quot;{Binding ColourId, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}&quot;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>ComboBox.ItemTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>DataTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;</code><code>Rectangle</code>&nbsp;<code>Fill</code><code>=</code><code>&quot;{Binding
 ColourBrush}&quot;</code>&nbsp;<code>Height</code><code>=</code><code>&quot;30&quot;</code>&nbsp;<code>Width</code><code>=</code><code>&quot;30&quot;</code><code>/&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;/</code><code>DataTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;/</code><code>ComboBox.ItemTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;/</code><code>ComboBox</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;/</code><code>DataTemplate</code><code>&gt;</code></span></div>
<div><code>&nbsp;&nbsp;&nbsp;&nbsp;</code><span><code>&lt;/</code><code>DataGridTemplateColumn.CellTemplate</code><code>&gt;</code></span></div>
<div><span><code>&lt;/</code><code>DataGridTemplateColumn</code><code>&gt;</code></span></div>
</div>
<p><br>
<span>Here , we want to show a coloured rectangle to show the user a representation of what colour the paint they are picking will be.</span><br>
<span>An explanation of the difference between a combo and template column is probably appropriate here.&nbsp;</span><br>
<span>You can actually apply an Itemtemplate to a combo column - so why not use that?</span><br>
<span>Well the template column is more obvioulsly something which will be templated so it should not surprise any developer to see a template inside it. &nbsp;A more subtle reason is that template columns cannot be clicked to sort. &nbsp;This is a positive
 feature in our case because it avoids a somewhat tricky problem of exactly what you might sort on and how you implement that. &nbsp;One logical sort of choice would be wavelength to give a rainbow like order. &nbsp;The simpler approach is to just not offer
 any sorting.</span><br>
<br>
<span>The ItemsSource is particularly tricky as explained in brief above. &nbsp;The collection uses a property in the window's viewmodel and this is what the rather strange DataContext., notation is about. &nbsp;The relativesource goes and finds that parent
 window by using it's type. &nbsp;In order to know about that type the XAML has a xmlns reference to our code namespace as local:</span><br>
<br>
</p>
<div class="reCodeBlock"><span><code>xmlns:local=&quot;clr-namespace:wpf_ComboBoxColumn&quot;</code></span></div>
<p><br>
<span>As the table above explains, the&nbsp;</span><span style="color:#808080; font-family:monospace">SelectedValuePath&nbsp;</span><span>is the name of the property out ComboRowViewModel&nbsp;whose value we will be using to identify the object. &nbsp;If your
 object originated from a database it probably has an Id you don't want to see and something else you are expecting to see in the items. &nbsp;In that case it is the Id you use.</span><br>
<span>The&nbsp;</span><span style="color:#808080; font-family:monospace">SelectedValue</span><span>&nbsp; is a binding to the property DataGridRowViewModel which will change as the user selects an item.</span></p>
<p>&nbsp;</p>
<p><span><img id="125326" src="125326-anithanks1.gif" alt="" width="471" height="156"><br>
</span></p>
