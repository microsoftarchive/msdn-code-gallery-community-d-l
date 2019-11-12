Public Class Form1

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ComboBox1.DataSource = GetMailItems()
        ComboBox1.DisplayMember = "Name"
        ComboBox1.ValueMember = "ValueCurrency"

    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(sender As Object, e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        MessageBox.Show("Selected Item = : " + ComboBox1.SelectedText.ToString() + " " + ComboBox1.SelectedValue.ToString())
    End Sub
    
    Function GetMailItems() As List(Of CurrencyOfWord)

        Dim mailItems = New List(Of CurrencyOfWord)

        mailItems.Add(New CurrencyOfWord(0.0684D, "Neb"))
        mailItems.Add(New CurrencyOfWord(0.0645D, "Kan"))
        mailItems.Add(New CurrencyOfWord(0.0792D, "IA"))

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
