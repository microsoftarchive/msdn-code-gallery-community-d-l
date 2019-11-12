Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class OtherBills

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _cc As Decimal
    <DisplayName("Credit Cards"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property cc() As Decimal
        Get
            Return _cc
        End Get
        Set(ByVal value As Decimal)
            _cc = value
            totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous
        End Set
    End Property

    Private _loans As Decimal
    <DisplayName("Loan Repayments"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property loans() As Decimal
        Get
            Return _loans
        End Get
        Set(ByVal value As Decimal)
            _loans = value
            totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous
        End Set
    End Property

    Private _maintenance As Decimal
    <DisplayName("Maintenance"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property maintenance() As Decimal
        Get
            Return _maintenance
        End Get
        Set(ByVal value As Decimal)
            _maintenance = value
            totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous
        End Set
    End Property

    Private _opticalAndDental As Decimal
    <DisplayName("Optical/Dental Costs"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property opticalAndDental() As Decimal
        Get
            Return _opticalAndDental
        End Get
        Set(ByVal value As Decimal)
            _opticalAndDental = value
            totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous
        End Set
    End Property

    Private _miscellaneous As Decimal
    <DisplayName("Miscellaneous"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property miscellaneous() As Decimal
        Get
            Return _miscellaneous
        End Get
        Set(ByVal value As Decimal)
            _miscellaneous = value
            totalOtherBills = cc + loans + maintenance + opticalAndDental + miscellaneous
        End Set
    End Property

    Private _totalOtherBills As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Other Bills Outgoings")> _
    Public Property totalOtherBills() As Decimal
        Get
            Return _totalOtherBills
        End Get
        Set(ByVal value As Decimal)
            _totalOtherBills = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Other Bills", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalOtherBills.ToString("c2")
    End Function

End Class
