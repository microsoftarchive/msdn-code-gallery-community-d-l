' Author    : Michel Posseth 
' Company   : VBDotNetCoder
' E-Mail    : info@VBDotNetCoder.com
Public Class frmMain
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DataGridView1.AutoGenerateColumns = True
        LoadNames()
    End Sub
    Private Sub LoadNames()
        Dim doc As XDocument = XDocument.Load("popnames.xml")
        Dim root As XElement = doc.Root
        Dim i As Integer = 0
        For Each child As XElement In root.Elements()
            Dim name As New PopName()
            name.name = child.Attribute("Name").Value
            name.gender = CType(System.Enum.Parse(GetType(NameGender), child.Attribute("Gender").Value), NameGender)
            name.state = child.Attribute("State").Value
            name.year = Integer.Parse(child.Attribute("Year").Value)
            name.rank = Integer.Parse(child.Attribute("Rank").Value)
            name.count = Integer.Parse(child.Attribute("Count").Value)
            Names.Add(name)
            i += 1
            If i = 100 Then Exit For
        Next
    End Sub
    Private Names As New List(Of PopName)
    'Note that you could also uncoment the construct below
    'then the list would be inmediatly sortable 
    ' Private Names As New VBDC.SortableBindingList(Of PopName)
    Friend Enum NameGender
        Male
        Female
    End Enum
    Friend Class PopName
        ' Fields:
        Property name As String
        Property gender As NameGender
        Property state As String
        Property year As Integer
        Property rank As Integer
        Property count As Integer
    End Class
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.DataGridView1.DataSource = Names
        MessageBox.Show("dgv is not sortable")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.DataGridView1.DataSource = New VBDC.SortableBindingList(Of PopName)(Names)
        MessageBox.Show("dgv is now sortable , click the coolumn headers to try ")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' note that you can even throw in throw in  LINQ query results 
        Dim lr = From en In Names Where en.count >= 80
        Me.DataGridView1.DataSource = New VBDC.SortableBindingList(Of PopName)(lr.ToList)

        MessageBox.Show("dgv is now sortable,click the coolumn headers to try")
    End Sub
End Class
