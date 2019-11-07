Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Household

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _mortgage As Decimal
    <DisplayName("Mortgage/Rent"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property mortgage() As Decimal
        Get
            Return _mortgage
        End Get
        Set(ByVal value As Decimal)
            _mortgage = value
            totalHousehold = mortgage + groceries + clothing + laundry + homehelp
        End Set
    End Property

    Private _groceries As Decimal
    <DisplayName("Groceries"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property groceries() As Decimal
        Get
            Return _groceries
        End Get
        Set(ByVal value As Decimal)
            _groceries = value
            totalHousehold = mortgage + groceries + clothing + laundry + homehelp
        End Set
    End Property

    Private _clothing As Decimal
    <DisplayName("Clothing (adult)"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property clothing() As Decimal
        Get
            Return _clothing
        End Get
        Set(ByVal value As Decimal)
            _clothing = value
            totalHousehold = mortgage + groceries + clothing + laundry + homehelp
        End Set
    End Property

    Private _laundry As Decimal
    <DisplayName("Laundry / Dry Cleaning"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property laundry() As Decimal
        Get
            Return _laundry
        End Get
        Set(ByVal value As Decimal)
            _laundry = value
            totalHousehold = mortgage + groceries + clothing + laundry + homehelp
        End Set
    End Property

    Private _homehelp As Decimal
    <DisplayName("Home Help"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property homehelp() As Decimal
        Get
            Return _homehelp
        End Get
        Set(ByVal value As Decimal)
            _homehelp = value
            totalHousehold = mortgage + groceries + clothing + laundry + homehelp
        End Set
    End Property

    Private _totalHousehold As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Household Outgoings")> _
    Public Property totalHousehold() As Decimal
        Get
            Return _totalHousehold
        End Get
        Set(ByVal value As Decimal)
            _totalHousehold = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Household", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalHousehold.ToString("c2")
    End Function

End Class
