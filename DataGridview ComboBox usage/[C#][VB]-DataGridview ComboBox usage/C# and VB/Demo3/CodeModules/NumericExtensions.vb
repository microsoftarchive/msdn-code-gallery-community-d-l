Module NumericExtensions
    <System.Runtime.CompilerServices.Extension()> _
    Public Function IsEven(ByVal sender As Integer) As Boolean
        Return sender Mod 2 = 0
    End Function
End Module
