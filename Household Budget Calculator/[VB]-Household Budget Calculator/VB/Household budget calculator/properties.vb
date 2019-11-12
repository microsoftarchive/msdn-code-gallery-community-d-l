Imports System.ComponentModel
Imports System.Globalization
Imports System.Drawing.Design

<System.Serializable()> Public Class properties

    Public Event propertiesChanged(ByVal e As propertiesChangedEventArgs)

    Public Sub New()
        removeEventHandlers()
        addEventHandlers()
    End Sub

    Public Sub addEventHandlers()
        AddHandler _children.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _finance.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _houseHold.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _insurance.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _leisure.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _otherBills.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _regularBills.propertiesChanged, AddressOf expandable_propertiesChanged
        AddHandler _transport.propertiesChanged, AddressOf expandable_propertiesChanged
    End Sub

    Public Sub removeEventHandlers()
        RemoveHandler _children.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _finance.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _houseHold.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _insurance.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _leisure.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _otherBills.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _regularBills.propertiesChanged, AddressOf expandable_propertiesChanged
        RemoveHandler _transport.propertiesChanged, AddressOf expandable_propertiesChanged
    End Sub

    Private _net As Decimal
    <CategoryAttribute("(Monthly Income)"), _
    RefreshProperties(RefreshProperties.All), _
    DisplayName("Net monthly pay")> _
    Public Property net() As Decimal
        Get
            Return _net
        End Get
        Set(ByVal value As Decimal)
            _net = value
            totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2")
        End Set
    End Property

    Private _pension As Decimal
    <CategoryAttribute("(Monthly Income)"), _
    RefreshProperties(RefreshProperties.All), _
    DisplayName("Pension")> _
    Public Property pension() As Decimal
        Get
            Return _pension
        End Get
        Set(ByVal value As Decimal)
            _pension = value
            totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2")
        End Set
    End Property

    Private _otherIncome1 As Decimal
    <CategoryAttribute("(Monthly Income)"), _
    RefreshProperties(RefreshProperties.All), _
    DisplayName("Income from Savings + Investments")> _
    Public Property otherIncome1() As Decimal
        Get
            Return _otherIncome1
        End Get
        Set(ByVal value As Decimal)
            _otherIncome1 = value
            totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2")
        End Set
    End Property

    Private _otherIncome2 As Decimal
    <CategoryAttribute("(Monthly Income)"), _
    RefreshProperties(RefreshProperties.All), _
    DisplayName("Other Income")> _
    Public Property otherIncome2() As Decimal
        Get
            Return _otherIncome2
        End Get
        Set(ByVal value As Decimal)
            _otherIncome2 = value
            totalIncome = (net + pension + otherIncome1 + otherIncome2).ToString("c2")
        End Set
    End Property

    Private _totalIncome As String
    <CategoryAttribute("(Monthly Income)"), _
    RefreshProperties(RefreshProperties.All), _
    ReadOnlyAttribute(True), _
    DisplayName("Total Income"), _
    Editor(GetType(TypeEditor0), GetType(UITypeEditor))> _
    Public Property totalIncome() As String
        Get
            Return _totalIncome
        End Get
        Set(ByVal value As String)
            _totalIncome = value
            Dim decValue As Decimal
            Decimal.TryParse(value, NumberStyles.Currency, CultureInfo.CurrentCulture, decValue)
            RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = "Total Income", .newValue = decValue})
        End Set
    End Property


    Private _houseHold As New Household
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Household"), _
    Editor(GetType(TypeEditor3), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property houseHold() As Household
        Get
            Return _houseHold
        End Get
        Set(ByVal value As Household)
            _houseHold = value
        End Set
    End Property

    Private _transport As New Transport
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Transport"), _
    Editor(GetType(TypeEditor8), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property transport() As Transport
        Get
            Return _transport
        End Get
        Set(ByVal value As Transport)
            _transport = value
        End Set
    End Property

    Private _finance As New Finance
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Finance"), _
    Editor(GetType(TypeEditor2), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property finance() As Finance
        Get
            Return _finance
        End Get
        Set(ByVal value As Finance)
            _finance = value
        End Set
    End Property

    Private _leisure As New Leisure
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Leisure"), _
    Editor(GetType(TypeEditor5), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property leisure() As Leisure
        Get
            Return _leisure
        End Get
        Set(ByVal value As Leisure)
            _leisure = value
        End Set
    End Property

    Private _regularBills As New RegularBills
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Regular Bills"), _
    Editor(GetType(TypeEditor7), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property regularBills() As RegularBills
        Get
            Return _regularBills
        End Get
        Set(ByVal value As RegularBills)
            _regularBills = value
        End Set
    End Property

    Private _insurance As New Insurance
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Insurance"), _
    Editor(GetType(TypeEditor4), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property insurance() As Insurance
        Get
            Return _insurance
        End Get
        Set(ByVal value As Insurance)
            _insurance = value
        End Set
    End Property

    Private _children As New Children
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Children"), _
    Editor(GetType(TypeEditor1), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property children() As Children
        Get
            Return _children
        End Get
        Set(ByVal value As Children)
            _children = value
            Stop
        End Set
    End Property

    Private _otherBills As New OtherBills
    <CategoryAttribute("(Monthly Outgoings)"), _
    DisplayName("Other Bills"), _
    Editor(GetType(TypeEditor6), GetType(UITypeEditor)), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property otherBills() As OtherBills
        Get
            Return _otherBills
        End Get
        Set(ByVal value As OtherBills)
            _otherBills = value
        End Set
    End Property

    Private Sub expandable_propertiesChanged(ByVal e As propertiesChangedEventArgs) 
        RaiseEvent propertiesChanged(New propertiesChangedEventArgs With {.propName = e.propName, .newValue = e.newValue})
    End Sub

End Class
