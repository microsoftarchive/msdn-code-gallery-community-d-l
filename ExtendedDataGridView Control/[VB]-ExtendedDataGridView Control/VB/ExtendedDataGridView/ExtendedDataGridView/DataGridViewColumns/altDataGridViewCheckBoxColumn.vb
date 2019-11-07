Imports System.ComponentModel

Public Class altDataGridViewCheckBoxColumn
    Inherits DataGridViewCheckBoxColumn

    Private _HeaderStyle As enumerations.style2
    <Category("Design"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property HeaderStyle() As enumerations.style2
        Get
            Return _HeaderStyle
        End Get
        Set(ByVal value As enumerations.style2)
            _HeaderStyle = value
            Select Case _HeaderStyle
                Case style2.Standard
                    MyBase.HeaderCell = New DataGridViewColumnHeaderCell
                Case style2.CheckAll
                    MyBase.HeaderCell = New checkAllHeaderCell
                Case style2.HideColumn
                    MyBase.HeaderCell = New checkHideColumnHeaderCell
            End Select
        End Set
    End Property

    Public Overrides Function clone() As Object
        Dim copyColumn As altDataGridViewCheckBoxColumn = DirectCast(MyBase.Clone, altDataGridViewCheckBoxColumn)
        copyColumn._HeaderStyle = Me.HeaderStyle
        Return copyColumn
    End Function

End Class
