Imports System
Imports System.Windows.Data

''' <summary>
'''     Two way IValueConverter that lets you bind a property on a bindable object
'''     to a dependency property when the dependency property treats empty as null
'''     and the object property treats empty as the empty string
''' </summary>
Public Class TargetNullValueConverter
    Implements IValueConverter
    
    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return If(String.IsNullOrEmpty(DirectCast(value, String)), Nothing, value)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return If(value Is Nothing, String.Empty, value)
    End Function
End Class