# DataGridView ComboBox allow navigation in drop down
## Requires
- Visual Studio 2013
## License
- MIT
## Technologies
- custom controls
- DataGridView
## Topics
- Windows Forms
- customization
- custom controls
## Updated
- 07/21/2015
## Description

<h1>Description</h1>
<p><span style="font-size:small">Normally when using a DataGridViewComboBoxColumn users will select from available items in the column which is covered in
<a title="My MSDN article on using DataGridView ComboBox" href="https://code.msdn.microsoft.com/DataGridview-ComboBox-usage-26010f73" target="_blank">
this article</a>. This focuses on allowing a user to type in information and have auto-complete feature. The auto-complete feature is extremely easy to do but as someone pointed out recently the left and right arrow keys will not function so to handle this
 a custom DataGridView is used to solve this issue.</span></p>
<p><span style="font-size:small"><br>
</span></p>
<p><span style="font-size:small"><img id="140232" src="140232-21.jpg" alt="" width="300" height="229"><br>
</span></p>
<p><span style="font-size:small"><br>
There are two projects with the same custom DataGridView, one for C#, one for VB.NET. To use the custom DataGridView, either add the custom DataGridView to your project, build and find the DataGridView at the top of the IDE toolbox or place the custom DataGridView
 in a class project, build the project then add it to the IDE toolbox which makes it available for other projects. Now if you did the latter in C# and find yourself needing it in VB.NET the C# version will work and the same goes in the opposite direction.</span></p>
<p><span style="font-size:small">Here is the custom DataGridView<em><br>
&nbsp;&nbsp;</em></span></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Public Class MyDataGridView
    Inherits DataGridView

    Protected Overrides Function ProcessDataGridViewKey(ByVal e As KeyEventArgs) As Boolean

        If e.KeyData = Keys.Left OrElse e.KeyData = Keys.Right Then
            If Me.EditingControl IsNot Nothing Then
                If Me.EditingControl.GetType() Is GetType(DataGridViewComboBoxEditingControl) Then
                    Dim control As ComboBox = TryCast(Me.EditingControl, ComboBox)
                    If control.DropDownStyle &lt;&gt; ComboBoxStyle.DropDownList Then
                        Select Case e.KeyData
                            Case Keys.Left
                                If control.SelectionStart &gt; 0 Then
                                    control.SelectionStart -= 1
                                    Return True
                                End If
                            Case Keys.Right
                                If control.SelectionStart &lt; control.Text.Length Then
                                    control.SelectionStart &#43;= 1
                                    Return True
                                End If
                        End Select
                    End If
                End If
            End If

        End If

        Return MyBase.ProcessDataGridViewKey(e)

    End Function
End Class</pre>
<pre class="hidden">using System.Windows.Forms;

namespace CustomerDataGridView_CS
{
    public class MyDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left || e.KeyData == Keys.Right)
            {
                if (this.EditingControl != null)
                {
                    if (this.EditingControl.GetType() ==
                    typeof(DataGridViewComboBoxEditingControl))
                    {
                        ComboBox control = this.EditingControl as ComboBox;
                        if (control.DropDownStyle !=
                        ComboBoxStyle.DropDownList)
                        {
                            switch (e.KeyData)
                            {
                                case Keys.Left:
                                    if (control.SelectionStart &gt; 0)
                                    {
                                        control.SelectionStart--;
                                        return true;
                                    }
                                    break;

                                case Keys.Right:
                                    if (control.SelectionStart &lt;
                                    control.Text.Length)
                                    {
                                        control.SelectionStart&#43;&#43;;
                                        return true;
                                    }
                                    break;
                            }
                        }
                    }
                }
            }

            return base.ProcessDataGridViewKey(e);
        }
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;MyDataGridView&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Inherits</span>&nbsp;DataGridView&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Protected</span>&nbsp;<span class="visualBasic__keyword">Overrides</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;ProcessDataGridViewKey(<span class="visualBasic__keyword">ByVal</span>&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;KeyEventArgs)&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Boolean</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;e.KeyData&nbsp;=&nbsp;Keys.Left&nbsp;<span class="visualBasic__keyword">OrElse</span>&nbsp;e.KeyData&nbsp;=&nbsp;Keys.Right&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.EditingControl&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Me</span>.EditingControl.<span class="visualBasic__keyword">GetType</span>()&nbsp;<span class="visualBasic__keyword">Is</span>&nbsp;<span class="visualBasic__keyword">GetType</span>(DataGridViewComboBoxEditingControl)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;control&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ComboBox&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(<span class="visualBasic__keyword">Me</span>.EditingControl,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;control.DropDownStyle&nbsp;&lt;&gt;&nbsp;ComboBoxStyle.DropDownList&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;e.KeyData&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;Keys.Left&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;control.SelectionStart&nbsp;&gt;&nbsp;<span class="visualBasic__number">0</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;control.SelectionStart&nbsp;-=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Case</span>&nbsp;Keys.Right&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;control.SelectionStart&nbsp;&lt;&nbsp;control.Text.Length&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;control.SelectionStart&nbsp;&#43;=&nbsp;<span class="visualBasic__number">1</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">True</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Select</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Return</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.ProcessDataGridViewKey(e)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Function</span>&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span></pre>
</div>
</div>
</div>
<p><span style="font-size:small">In the code below, form load event handles loading our DataGridView and the data used in the auto-complete featue of the DataGridViewComboBox colum. In the event EditingControlShowing we check to see if we are in the DataGridViewComboBox
 cell and if so setup our ComboBox with the auto-complete feature. Lastly, in CellLeave event we check to see if the item used is in the list of auto-complete, if not we added it. If this was a database application this is were we could if needed add the new
 item to a table in the database.</span></p>
<p><span style="font-size:small"></p>
<div class="scriptcode">
<div class="pluginEditHolder" pluginCommand="mceScriptCode">
<div class="title"><span>Visual Basic</span><span>C#</span></div>
<div class="pluginLinkHolder"><span class="pluginEditHolderLink">Edit</span>|<span class="pluginRemoveHolderLink">Remove</span></div>
<span class="hidden">vb</span><span class="hidden">csharp</span>
<pre class="hidden">Imports MockedData_VB
Public Class Form1
    Private AutoList As AutoCompleteStringCollection =
        New AutoCompleteStringCollection

    Private cbo As ComboBox
    Private ComboColumnName As String = &quot;C1&quot;

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        '
        ' DataOperation contains mocked data for this demo
        '
        Dim Data As New DataOperations

        Dim dict = Data.MonthDictionary
        Dim DataGridViewData As List(Of MockedData) = Data.MockedData

        Dim MonthNameColumn As New DataGridViewComboBoxColumn With
            {
                .DataSource = Data.AutoData,
                .DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                .Name = ComboColumnName,
                .HeaderText = &quot;Demo&quot;,
                .SortMode = DataGridViewColumnSortMode.NotSortable
            }

        Dim IndexColumn As New DataGridViewTextBoxColumn With
            {
                .Name = &quot;C2&quot;,
                .HeaderText = &quot;Col 2&quot;
            }

        AutoList.AddRange(Data.AutoData)

        DataGridView1.Columns.AddRange(New DataGridViewColumn() 
                                       {MonthNameColumn, IndexColumn})

        For Each item In Data.MockedData
            DataGridView1.Rows.Add(New Object() {item.Name, item.Index})
        Next

    End Sub
    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) _
        Handles DataGridView1.CellLeave

        If cbo IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(cbo.Text) Then
                If Not AutoList.Contains(cbo.Text) Then
                    Dim cb = CType(DataGridView1.Columns(0), DataGridViewComboBoxColumn)
                    AutoList.Add(cbo.Text)
                    Dim Items As List(Of String) = CType(cb.DataSource, String()).ToList
                    Items.Add(cbo.Text)
                    Dim Index = Items.FindIndex(Function(x) x.ToLower = cbo.Text.ToLower)
                    cb.DataSource = Items.ToArray
                    cbo.SelectedIndex = Index
                    '
                    ' For your project here is where you can do say a save back to the
                    ' database.
                    '
                End If
            End If
        End If

    End Sub
    Private Sub DataGridView1_EditingControlShowing(
        sender As Object, e As DataGridViewEditingControlShowingEventArgs) _
    Handles DataGridView1.EditingControlShowing

        ' IsComboBoxCell is an exension method in ExtensionMethods_VB project
        If DataGridView1.CurrentCell.IsComboBoxCell Then
            If DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name = ComboColumnName Then
                cbo = TryCast(e.Control, ComboBox)
                cbo.DropDownStyle = ComboBoxStyle.DropDown
                cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                cbo.AutoCompleteSource = AutoCompleteSource.ListItems
            End If
        End If
    End Sub

End Class
</pre>
<pre class="hidden">using ExtensionMethods_VB;
using MockedData_VB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Demo_CS
{
    public partial class Form1 : Form
    {
        private AutoCompleteStringCollection AutoList = 
            new AutoCompleteStringCollection();

        private ComboBox cbo;
        private string ComboColumnName = &quot;C1&quot;;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            // DataOperation contains mocked data for this demo
            //
            DataOperations Data = new DataOperations();

            var dict = Data.MonthDictionary;
            List&lt;MockedData&gt; DataGridViewData = Data.MockedData;

            DataGridViewComboBoxColumn MonthNameColumn = new DataGridViewComboBoxColumn 
            { 
                DataSource = Data.AutoData, 
                DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing, 
                Name = ComboColumnName, 
                HeaderText = &quot;Demo&quot;, 
                SortMode = DataGridViewColumnSortMode.NotSortable 
            };

            DataGridViewTextBoxColumn IndexColumn = new DataGridViewTextBoxColumn 
            { 
                Name = &quot;C2&quot;, 
                HeaderText = &quot;Col 2&quot; 
            };

            AutoList.AddRange(Data.AutoData);

            DataGridView1.Columns.AddRange(new DataGridViewColumn[] 
            { 
                MonthNameColumn, IndexColumn 
            });

            foreach (var item in Data.MockedData)
            {
                DataGridView1.Rows.Add(new object[] { item.Name, item.Index });
            }

            DataGridView1.CellLeave &#43;= DataGridView1_CellLeave;
            DataGridView1.EditingControlShowing &#43;= DataGridView1_EditingControlShowing;
        }

        private void DataGridView1_EditingControlShowing(
            object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // IsComboBoxCell is an exension method in ExtensionMethods_VB project
            if (DataGridView1.CurrentCell.IsComboBoxCell())
            {
                if (DataGridView1.Columns[DataGridView1.CurrentCell.ColumnIndex].Name == ComboColumnName)
                {
                    cbo = e.Control as ComboBox;
                    cbo.DropDownStyle = ComboBoxStyle.DropDown;
                    cbo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    cbo.AutoCompleteSource = AutoCompleteSource.ListItems;
                }
            }
        }

        private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (cbo != null)
            {
                if (!(string.IsNullOrWhiteSpace(cbo.Text)))
                {
                    if (!(AutoList.Contains(cbo.Text)))
                    {
                        var cb = (DataGridViewComboBoxColumn)(DataGridView1.Columns[0]);
                        AutoList.Add(cbo.Text);
                        List&lt;string&gt; Items = ((string[])cb.DataSource).ToList();
                        Items.Add(cbo.Text);
                        var Index = Items.FindIndex((x) =&gt; x.ToLower() == cbo.Text.ToLower());
                        cb.DataSource = Items.ToArray();
                        cbo.SelectedIndex = Index;
                        //
                        // For your project here is where you can do say a save back to the
                        // database.
                        //
                    }
                }
            }
        }
    }
}</pre>
<div class="preview">
<pre class="vb"><span class="visualBasic__keyword">Imports</span>&nbsp;MockedData_VB&nbsp;
<span class="visualBasic__keyword">Public</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;Form1&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;AutoList&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;AutoCompleteStringCollection&nbsp;=&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;AutoCompleteStringCollection&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;cbo&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;ComboBox&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;ComboColumnName&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">String</span>&nbsp;=&nbsp;<span class="visualBasic__string">&quot;C1&quot;</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;Form1_Load(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;EventArgs)&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;<span class="visualBasic__keyword">MyBase</span>.Load&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;DataOperation&nbsp;contains&nbsp;mocked&nbsp;data&nbsp;for&nbsp;this&nbsp;demo</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Data&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataOperations&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;dict&nbsp;=&nbsp;Data.MonthDictionary&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;DataGridViewData&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;MockedData)&nbsp;=&nbsp;Data.MockedData&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;MonthNameColumn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataGridViewComboBoxColumn&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DataSource&nbsp;=&nbsp;Data.AutoData,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.DisplayStyle&nbsp;=&nbsp;DataGridViewComboBoxDisplayStyle.<span class="visualBasic__keyword">Nothing</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;ComboColumnName,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HeaderText&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Demo&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.SortMode&nbsp;=&nbsp;DataGridViewColumnSortMode.NotSortable&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;IndexColumn&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">New</span>&nbsp;DataGridViewTextBoxColumn&nbsp;<span class="visualBasic__keyword">With</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.Name&nbsp;=&nbsp;<span class="visualBasic__string">&quot;C2&quot;</span>,&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;.HeaderText&nbsp;=&nbsp;<span class="visualBasic__string">&quot;Col&nbsp;2&quot;</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;}&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutoList.AddRange(Data.AutoData)&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.Columns.AddRange(<span class="visualBasic__keyword">New</span>&nbsp;DataGridViewColumn()&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;{MonthNameColumn,&nbsp;IndexColumn})&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">For</span>&nbsp;<span class="visualBasic__keyword">Each</span>&nbsp;item&nbsp;<span class="visualBasic__keyword">In</span>&nbsp;Data.MockedData&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;DataGridView1.Rows.Add(<span class="visualBasic__keyword">New</span>&nbsp;<span class="visualBasic__keyword">Object</span>()&nbsp;{item.Name,&nbsp;item.Index})&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Next</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DataGridView1_CellLeave(sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewCellEventArgs)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;DataGridView1.CellLeave&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;cbo&nbsp;<span class="visualBasic__keyword">IsNot</span>&nbsp;<span class="visualBasic__keyword">Nothing</span>&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;<span class="visualBasic__keyword">String</span>.IsNullOrWhiteSpace(cbo.Text)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;<span class="visualBasic__keyword">Not</span>&nbsp;AutoList.Contains(cbo.Text)&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;cb&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(DataGridView1.Columns(<span class="visualBasic__number">0</span>),&nbsp;DataGridViewComboBoxColumn)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AutoList.Add(cbo.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Items&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;List(<span class="visualBasic__keyword">Of</span>&nbsp;<span class="visualBasic__keyword">String</span>)&nbsp;=&nbsp;<span class="visualBasic__keyword">CType</span>(cb.DataSource,&nbsp;<span class="visualBasic__keyword">String</span>()).ToList&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Items.Add(cbo.Text)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Dim</span>&nbsp;Index&nbsp;=&nbsp;Items.FindIndex(<span class="visualBasic__keyword">Function</span>(x)&nbsp;x.ToLower&nbsp;=&nbsp;cbo.Text.ToLower)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cb.DataSource&nbsp;=&nbsp;Items.ToArray&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbo.SelectedIndex&nbsp;=&nbsp;Index&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;For&nbsp;your&nbsp;project&nbsp;here&nbsp;is&nbsp;where&nbsp;you&nbsp;can&nbsp;do&nbsp;say&nbsp;a&nbsp;save&nbsp;back&nbsp;to&nbsp;the</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;database.</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Private</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;DataGridView1_EditingControlShowing(&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sender&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;<span class="visualBasic__keyword">Object</span>,&nbsp;e&nbsp;<span class="visualBasic__keyword">As</span>&nbsp;DataGridViewEditingControlShowingEventArgs)&nbsp;_&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">Handles</span>&nbsp;DataGridView1.EditingControlShowing&nbsp;
&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__com">'&nbsp;IsComboBoxCell&nbsp;is&nbsp;an&nbsp;exension&nbsp;method&nbsp;in&nbsp;ExtensionMethods_VB&nbsp;project</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.CurrentCell.IsComboBoxCell&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;DataGridView1.Columns(DataGridView1.CurrentCell.ColumnIndex).Name&nbsp;=&nbsp;ComboColumnName&nbsp;<span class="visualBasic__keyword">Then</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbo&nbsp;=&nbsp;<span class="visualBasic__keyword">TryCast</span>(e.Control,&nbsp;ComboBox)&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbo.DropDownStyle&nbsp;=&nbsp;ComboBoxStyle.DropDown&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbo.AutoCompleteMode&nbsp;=&nbsp;AutoCompleteMode.SuggestAppend&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;cbo.AutoCompleteSource&nbsp;=&nbsp;AutoCompleteSource.ListItems&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">If</span>&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Sub</span>&nbsp;
&nbsp;
<span class="visualBasic__keyword">End</span>&nbsp;<span class="visualBasic__keyword">Class</span>&nbsp;
</pre>
</div>
</div>
</div>
<div class="endscriptcode">In the solution screen shot you will find the top two projects are the custom DataGridView controls. Next two demo how to you them. Second from bottom is where IsComboBox extension method resides and the last handles giving the
 two form projects simple data.</div>
<img id="140233" src="140233-22.jpg" alt="" width="305" height="214"><br>
</span>
<p></p>
