Module BindingSourceExtensions
    <System.Diagnostics.DebuggerStepThrough()> _
    <System.Runtime.CompilerServices.Extension()> _
    Public Function Locate(ByVal sender As BindingSource, ByVal Key As String, ByVal Value As String) As Integer

        Dim Position As Integer = -1

        Position = sender.Find(Key, Value)
        'If Position > -1 Then
        '    sender.Position = Position
        'End If

        Return Position

    End Function

End Module
