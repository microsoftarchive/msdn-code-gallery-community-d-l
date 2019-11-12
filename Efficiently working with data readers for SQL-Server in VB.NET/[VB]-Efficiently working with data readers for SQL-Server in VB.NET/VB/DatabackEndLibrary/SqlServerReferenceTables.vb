Public Class SqlServerReferenceTables
    Public Property Catagories As List(Of Category)
    Public Property Products As List(Of Product)
    Public Sub New()
        Catagories = New List(Of Category)
        Products = New List(Of Product)
    End Sub
End Class
