Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Insurance

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _life As Decimal
    <DisplayName("Life + Protection"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property life() As Decimal
        Get
            Return _life
        End Get
        Set(ByVal value As Decimal)
            _life = value
            totalInsurance = life + motor + medical
        End Set
    End Property

    Private _motor As Decimal
    <DisplayName("Motor + Home"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property motor() As Decimal
        Get
            Return _motor
        End Get
        Set(ByVal value As Decimal)
            _motor = value
            totalInsurance = life + motor + medical
        End Set
    End Property

    Private _medical As Decimal
    <DisplayName("Medical"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property medical() As Decimal
        Get
            Return _medical
        End Get
        Set(ByVal value As Decimal)
            _medical = value
            totalInsurance = life + motor + medical
        End Set
    End Property

    Private _totalInsurance As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Insurance Outgoings")> _
    Public Property totalInsurance() As Decimal
        Get
            Return _totalInsurance
        End Get
        Set(ByVal value As Decimal)
            _totalInsurance = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Insurance", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalInsurance.ToString("c2")
    End Function

End Class
