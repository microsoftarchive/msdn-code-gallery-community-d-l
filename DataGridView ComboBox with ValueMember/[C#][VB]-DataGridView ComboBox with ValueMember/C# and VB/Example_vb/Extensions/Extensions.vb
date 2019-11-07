''' <summary>
''' Several language extensions done so the code
''' in the form is cleaner as we could had done all
''' of this w/o extension methods.
''' </summary>
Module Extensions
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function IsComboBoxCell(ByVal sender As DataGridViewCell) As Boolean
        Dim Result As Boolean = False
        If sender.EditType IsNot Nothing Then
            If sender.EditType Is GetType(DataGridViewComboBoxEditingControl) Then
                Result = True
            End If
        End If
        Return Result
    End Function
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function ColorMessage(ByVal sender As BindingSource, ByVal ColorId As Integer) As String
        Dim index As Integer = sender.Find("Id", ColorId)
        If index = -1 Then
            ' this means someone messed with the database table
            Return ""
        Else
            Return CType(sender.Item(index), DataRowView).Row.Field(Of String)("Text")
        End If
    End Function
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function ColorIdFromPerson(ByVal sender As BindingSource) As Integer
        Return CType(sender.Current, DataRowView).Row.Field(Of Integer)("ColorId")
    End Function
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function ColorId(ByVal sender As BindingSource) As Integer
        Return CType(sender.Current, DataRowView).Row.Field(Of Integer)("ColorId")
    End Function
    <System.Diagnostics.DebuggerStepThrough()>
    <System.Runtime.CompilerServices.Extension()>
    Public Function Identifier(ByVal sender As BindingSource) As Integer
        Return CType(sender.Current, DataRowView).Row.Field(Of Integer)("Id")
    End Function
End Module
