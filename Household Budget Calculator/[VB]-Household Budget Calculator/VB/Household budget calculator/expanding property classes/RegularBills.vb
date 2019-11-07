Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class RegularBills

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _councilTax As Decimal
    <DisplayName("Council Tax"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property councilTax() As Decimal
        Get
            Return _councilTax
        End Get
        Set(ByVal value As Decimal)
            _councilTax = value
            totalRegularBills = councilTax + amenities + communications
        End Set
    End Property

    Private _amenities As Decimal
    <DisplayName("Gas/Electricity/Water"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property amenities() As Decimal
        Get
            Return _amenities
        End Get
        Set(ByVal value As Decimal)
            _amenities = value
            totalRegularBills = councilTax + amenities + communications
        End Set
    End Property

    Private _communications As Decimal
    <DisplayName("Phone/Television"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property communications() As Decimal
        Get
            Return _communications
        End Get
        Set(ByVal value As Decimal)
            _communications = value
            totalRegularBills = councilTax + amenities + communications
        End Set
    End Property

    Private _totalRegularBills As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Regular Bills Outgoings")> _
    Public Property totalRegularBills() As Decimal
        Get
            Return _totalRegularBills
        End Get
        Set(ByVal value As Decimal)
            _totalRegularBills = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Regular Bills", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalRegularBills.ToString("c2")
    End Function

End Class
