Imports System.ComponentModel

<TypeConverter(GetType(ExpandableObjectConverter))> <System.Serializable()> _
Public Class Children

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Private _care As Decimal
    <DisplayName("Daycare/Nanny"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property care() As Decimal
        Get
            Return _care
        End Get
        Set(ByVal value As Decimal)
            _care = value
            totalChildren = care + schooling + clothing + treats
        End Set
    End Property

    Private _schooling As Decimal
    <DisplayName("Schooling"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property schooling() As Decimal
        Get
            Return _schooling
        End Get
        Set(ByVal value As Decimal)
            _schooling = value
            totalChildren = care + schooling + clothing + treats
        End Set
    End Property

    Private _clothing As Decimal
    <DisplayName("Clothing"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property clothing() As Decimal
        Get
            Return _clothing
        End Get
        Set(ByVal value As Decimal)
            _clothing = value
            totalChildren = care + schooling + clothing + treats
        End Set
    End Property

    Private _treats As Decimal
    <DisplayName("Treats"), _
    RefreshProperties(RefreshProperties.All)> _
    Public Property treats() As Decimal
        Get
            Return _treats
        End Get
        Set(ByVal value As Decimal)
            _treats = value
            totalChildren = care + schooling + clothing + treats
        End Set
    End Property

    Private _totalChildren As Decimal
    <ReadOnlyAttribute(True), _
    Browsable(False), _
    DisplayName("Total Children Outgoings")> _
    Public Property totalChildren() As Decimal
        Get
            Return _totalChildren
        End Get
        Set(ByVal value As Decimal)
            _totalChildren = value
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Children", .newValue = value})
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return totalChildren.ToString("c2")
    End Function

End Class
