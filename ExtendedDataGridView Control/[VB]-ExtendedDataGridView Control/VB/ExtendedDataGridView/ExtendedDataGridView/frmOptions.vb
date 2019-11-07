Imports System.Windows.Forms

Public Class frmOptions

    Public ReadOnly Property columns() As Boolean
        Get
            Return CheckBox1.Checked
        End Get
    End Property

    Public ReadOnly Property rows() As Boolean
        Get
            Return CheckBox2.Checked
        End Get
    End Property

    Public ReadOnly Property hidden() As Boolean
        Get
            Return CheckBox3.Checked
        End Get
    End Property

    Public Sub New(print As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        If print Then
            Me.Text = "Print Options"
            CheckBox1.Text = "&Print Column Headers"
            CheckBox2.Text = "Print &Row Headers"
            CheckBox3.Text = "Print &Hidden Columns"
            Button1.Text = "Pr&int"
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

End Class