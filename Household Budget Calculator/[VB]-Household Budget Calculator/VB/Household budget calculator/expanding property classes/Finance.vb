Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Finance

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _pension As Decimal
    <DisplayName("Pension"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property pension() As Decimal
        Get
            Return _pension
        End Get
        Set(ByVal value As Decimal)
            _pension = value
            totalFinance = pension + savings
        End Set
    End Property

    Private _savings As Decimal
    <DisplayName("Regular Savings"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property savings() As Decimal
        Get
            Return _savings
        End Get
        Set(ByVal value As Decimal)
            _savings = value
            totalFinance = pension + savings
        End Set
    End Property

    Private _totalFinance As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Finance Outgoings")> _
    Public Property totalFinance() As Decimal
        Get
            Return _totalFinance
        End Get
        Set(ByVal value As Decimal)
            _totalFinance = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Finance", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalFinance.ToString("c2")
    End Function

End Class
