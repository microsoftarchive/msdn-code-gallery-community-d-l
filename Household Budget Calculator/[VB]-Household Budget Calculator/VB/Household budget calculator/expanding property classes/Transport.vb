Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Transport

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _petrol As Decimal
    <DisplayName("Petrol"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property petrol() As Decimal
        Get
            Return _petrol
        End Get
        Set(ByVal value As Decimal)
            _petrol = value
            totalTransport = petrol + commuting + carCosts
        End Set
    End Property

    Private _commuting As Decimal
    <DisplayName("Commuting"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property commuting() As Decimal
        Get
            Return _commuting
        End Get
        Set(ByVal value As Decimal)
            _commuting = value
            totalTransport = petrol + commuting + carCosts
        End Set
    End Property

    Private _carCosts As Decimal
    <DisplayName("Car Costs"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property carCosts() As Decimal
        Get
            Return _carCosts
        End Get
        Set(ByVal value As Decimal)
            _carCosts = value
            totalTransport = petrol + commuting + carCosts
        End Set
    End Property

    Private _totalTransport As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Transport Outgoings")> _
    Public Property totalTransport() As Decimal
        Get
            Return _totalTransport
        End Get
        Set(ByVal value As Decimal)
            _totalTransport = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Transport", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalTransport.ToString("c2")
    End Function

End Class
