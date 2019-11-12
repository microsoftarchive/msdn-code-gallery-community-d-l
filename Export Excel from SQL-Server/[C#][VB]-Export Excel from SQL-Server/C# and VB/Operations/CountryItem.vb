Public Class CountryItem
    Public Property Name As String
    Public ReadOnly Property Compact As String
        Get
            Return Name.Replace(" ", "").Replace("'", "")
        End Get
    End Property

End Class
