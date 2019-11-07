Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Leisure

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _eatingOut As Decimal
    <DisplayName("Eating Out"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property eatingOut() As Decimal
        Get
            Return _eatingOut
        End Get
        Set(ByVal value As Decimal)
            _eatingOut = value
            totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol
        End Set
    End Property

    Private _cinema As Decimal
    <DisplayName("Cinema"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property cinema() As Decimal
        Get
            Return _cinema
        End Get
        Set(ByVal value As Decimal)
            _cinema = value
            totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol
        End Set
    End Property

    Private _holidays As Decimal
    <DisplayName("Holidays"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property holidays() As Decimal
        Get
            Return _holidays
        End Get
        Set(ByVal value As Decimal)
            _holidays = value
            totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol
        End Set
    End Property

    Private _sports As Decimal
    <DisplayName("Sports"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property sports() As Decimal
        Get
            Return _sports
        End Get
        Set(ByVal value As Decimal)
            _sports = value
            totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol
        End Set
    End Property

    Private _cigarettesAndAlcohol As Decimal
    <DisplayName("Cigarettes/Alcohol"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property cigarettesAndAlcohol() As Decimal
        Get
            Return _cigarettesAndAlcohol
        End Get
        Set(ByVal value As Decimal)
            _cigarettesAndAlcohol = value
            totalLeisure = eatingOut + cinema + holidays + sports + cigarettesAndAlcohol
        End Set
    End Property

    Private _totalLeisure As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Leisure Outgoings")> _
    Public Property totalLeisure() As Decimal
        Get
            Return _totalLeisure
        End Get
        Set(ByVal value As Decimal)
            _totalLeisure = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Leisure", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalLeisure.ToString("c2")
    End Function

End Class
