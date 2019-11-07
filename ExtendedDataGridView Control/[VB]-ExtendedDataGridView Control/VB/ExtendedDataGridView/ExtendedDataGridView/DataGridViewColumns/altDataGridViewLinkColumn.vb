Imports System.ComponentModel
Imports System.Windows.Forms

Public Class altDataGridViewLinkColumn
    Inherits DataGridViewLinkColumn

    Private _HeaderStyle As enumerations.style1
    <Category("Design"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property HeaderStyle() As enumerations.style1
        Get
            Return _HeaderStyle
        End Get
        Set(ByVal value As enumerations.style1)
            _HeaderStyle = value
            Select Case _HeaderStyle
                Case style1.Standard
                    MyBase.HeaderCell = New DataGridViewColumnHeaderCell
                Case style1.HideColumn
                    MyBase.HeaderCell = New checkHideColumnHeaderCell
            End Select
        End Set
    End Property

    Public Overrides Function clone() As Object
        Dim copyColumn As altDataGridViewLinkColumn = DirectCast(MyBase.Clone, altDataGridViewLinkColumn)
        copyColumn._HeaderStyle = Me.HeaderStyle
        Return copyColumn
    End Function

End Class
