# How to add itens in a ComboBox in VB.NET with a Class binding an DataSource
## Requires
- Visual Studio 2010
## License
- Apache License, Version 2.0
## Technologies
- .NET Framework
## Topics
- Architecture and Design
- desktop
## Updated
- 12/27/2013
## Description

<h1>Introduction</h1>
<p>Frequently Im asked how to fill a Combo Box and the response is: there&rsquo;s a lot of ways to achieve that, one way is that which I demonstrate in this example.</p>
<p><span style="font-size:2em">Building the Sample</span></p>
<p>Only open Visual Studio and clique Generatefields to fill a ComboBox</p>
<p><span style="font-size:20px; font-weight:bold">Description</span></p>
<p>In this example I demonstrate how to add items with text and value in a ComboBox in VB.NET.</p>
<p>This example uses a classe which have two fields that are used in the ComboBox to aggravate Value and Text.</p>
<p>This value are used in the code to represent the text that was been showedThe same example could be used with DataSet, or whatever kind of source that has two fields to fill a ComboBox.</p>
<p>You could utilize with any other binding like DataSet, Array, but frequently you need show a Text and a Value of the text, in this case you need make a Binding in the DisplayMember and the ValueMember.&nbsp; &nbsp;&nbsp;</p>
<p>In this example you will see how to fill a ComboBox easy.</p>
<p>Another way is fill the class with the information of the Database, in this case you combo could be dynamic and will be filled as need.</p>
<p>In this example I used Winforms but you can use with ASP.NET also.</p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span>
<pre class="hidden">Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ComboBox1.DataSource = GetMailItems()
        ComboBox1.DisplayMember = &quot;Name&quot;
        ComboBox1.ValueMember = &quot;ValueCurrency&quot;

    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        MessageBox.Show(&quot;Selected Item = : &quot; &#43; ComboBox1.SelectedText.ToString() &#43; &quot; &quot; &#43; ComboBox1.SelectedValue.ToString())
    End Sub
    
    Function GetMailItems() As List(Of CurrencyOfWord)

        Dim mailItems = New List(Of CurrencyOfWord)

        mailItems.Add(New CurrencyOfWord(0.0684D, &quot;Neb&quot;))
        mailItems.Add(New CurrencyOfWord(0.0645D, &quot;Kan&quot;))
        mailItems.Add(New CurrencyOfWord(0.0792D, &quot;IA&quot;))

        Return mailItems

    End Function

End Class

Public Class CurrencyOfWord

    Public Sub New(ByVal ValueCurrency As Decimal, ByVal name As String)
        mValueCurrency = ValueCurrency
        mName = name
    End Sub

    Private mValueCurrency As Decimal
    Public Property ValueCurrency() As Decimal
        Get
            Return mValueCurrency
        End Get
        Set(ByVal ValueCr As Decimal)
            mValueCurrency = ValueCr
        End Set
    End Property

    Private mName As String
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal value As String)
            mName = value
        End Set
    End Property

End Class
</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox1.DataSource&nbsp;=&nbsp;GetMailItems()&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox1.DisplayMember&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Name&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ComboBox1.ValueMember&nbsp;=&nbsp;<span class="visualBasic__string">&quot;ValueCurrency&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;ComboBox1_SelectionChangeCommitted(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;System.EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;ComboBox1.SelectionChangeCommitted&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MessageBox.Show(<span class="visualBasic__string">&quot;Selected&nbsp;Item&nbsp;=&nbsp;:&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ComboBox1.SelectedText.ToString()&nbsp;&#43;&nbsp;<span class="visualBasic__string">&quot;&nbsp;&quot;</span>&nbsp;&#43;&nbsp;ComboBox1.SelectedValue.ToString())&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;GetMailItems()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;CurrencyOfWord)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;mailItems&nbsp;=&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;CurrencyOfWord)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailItems.Add(<span class="visualBasic__keyword">New</span>&nbsp;CurrencyOfWord(<span class="visualBasic__number">0</span>.0684D,&nbsp;<span class="visualBasic__string">&quot;Neb&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailItems.Add(<span class="visualBasic__keyword">New</span>&nbsp;CurrencyOfWord(<span class="visualBasic__number">0</span>.0645D,&nbsp;<span class="visualBasic__string">&quot;Kan&quot;</span>))&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mailItems.Add(<span class="visualBasic__keyword">New</span>&nbsp;CurrencyOfWord(<span class="visualBasic__number">0</span>.0792D,&nbsp;<span class="visualBasic__string">&quot;IA&quot;</span>))&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mailItems&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;CurrencyOfWord&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;<span class="visualBasic__keyword">New</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;ValueCurrency&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Decimal</span>,&nbsp;<span class="visualBasic__keyword">ByVal</span>&nbsp;name&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mValueCurrency&nbsp;=&nbsp;ValueCurrency&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mName&nbsp;=&nbsp;name&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;mValueCurrency&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Decimal</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;ValueCurrency()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Decimal</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mValueCurrency&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;ValueCr&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Decimal</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mValueCurrency&nbsp;=&nbsp;ValueCr&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;mName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;Name()&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;mName&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Get</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Set</span>(<span class="visualBasic__keyword">ByVal</span>&nbsp;value&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;mName&nbsp;=&nbsp;value&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Set</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Property</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<h1><span>Source Code Files</span></h1>
<ul>
<li><em>SampleComboBoxItems.zip</em> </li></ul>
<h1><em style="font-size:10px">Regards,&nbsp;</em></h1>
<p><em><span>Roberto Borges</span></em></p>
<p><em><span>Developer, Achitect, specialist Microsoft Since 1994, from Brazil and live in Canada, My twitter: @robertobborges.</span></em></p>
