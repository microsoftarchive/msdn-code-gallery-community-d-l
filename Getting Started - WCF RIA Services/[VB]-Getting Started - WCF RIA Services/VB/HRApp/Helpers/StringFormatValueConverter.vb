Imports System
Imports System.Globalization
Imports System.Windows.Data

''' <summary>
'''     One way IValueConverter that lets you bind a dependency property to
'''     the an object by converting the object's value to a string representation
'''     using <code>String.Format</code>
''' </summary>
Public Class StringFormatValueConverter
    Implements IValueConverter

    Private ReadOnly formatString As String

    ''' <summary>
    '''     Creates a new <see cref="StringFormatValueConverter"/>
    ''' </summary>
    ''' <param name="formatString">Format string, it can take zero or one parameters, the first one being replaced by the source value</param>
    Public Sub New(ByVal formatString As String)
        Me.formatString = formatString
    End Sub

    Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
        Return String.Format(CultureInfo.CurrentUICulture, Me.formatString, value)
    End Function

    Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
        Throw New NotSupportedException()
    End Function
End Class