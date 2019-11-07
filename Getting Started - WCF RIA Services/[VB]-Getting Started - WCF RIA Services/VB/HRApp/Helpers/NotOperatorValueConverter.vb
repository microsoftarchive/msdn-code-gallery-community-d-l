Imports System
Imports System.Windows.Data

''' <summary>
'''     Two way IValueConverter that lets you bind the inverse of a boolean property
'''     to a dependency property
''' </summary>
Public Class NotOperatorValueConverter
    Implements IValueConverter


    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return Not DirectCast(value, Boolean)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return Not DirectCast(value, Boolean)
    End Function
End Class