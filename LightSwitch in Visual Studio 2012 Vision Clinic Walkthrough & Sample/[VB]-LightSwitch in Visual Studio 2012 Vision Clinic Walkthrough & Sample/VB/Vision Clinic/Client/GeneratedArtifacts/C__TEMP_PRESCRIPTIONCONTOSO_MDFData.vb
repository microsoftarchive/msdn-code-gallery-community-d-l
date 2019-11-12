'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.17372
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


'Original file name:
'Generation date: 1/25/2012 1:43:32 PM
Namespace LightSwitchApplication.Implementation
    '''<summary>
    '''There are no comments for C__TEMP_PRESCRIPTIONCONTOSO_MDFDataObjectContext in the schema.
    '''</summary>
    Partial Public Class C__TEMP_PRESCRIPTIONCONTOSO_MDFDataObjectContext
        Inherits Global.Microsoft.LightSwitch.ClientGenerated.Implementation.DataServiceContext
        '''<summary>
        '''Initialize a new C__TEMP_PRESCRIPTIONCONTOSO_MDFDataObjectContext object.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Sub New(ByVal serviceRoot As Global.System.Uri)
            MyBase.New(serviceRoot)
            Me.ResolveName = AddressOf Me.ResolveNameFromType
            Me.ResolveType = AddressOf Me.ResolveTypeFromName
            Me.OnContextCreated
        End Sub
        Partial Private Sub OnContextCreated()
        End Sub
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private Shared ROOTNAMESPACE As String = GetType(LightSwitchApplication.Implementation.C__TEMP_PRESCRIPTIONCONTOSO_MDFDataObjectContext).Namespace.Remove(GetType(LightSwitchApplication.Implementation.C__TEMP_PRESCRIPTIONCONTOSO_MDFDataObjectContext).Namespace.LastIndexOf("LightSwitchApplication.Implementation"))
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Protected Function ResolveTypeFromName(ByVal typeName As String) As Global.System.Type
            If typeName.StartsWith("LightSwitchApplication", Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return Me.GetType.Assembly.GetType(String.Concat(String.Concat(ROOTNAMESPACE, "LightSwitchApplication.Implementation"), typeName.Substring(22)), false)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''Since the namespace configured for this service reference
        '''in Visual Studio is different from the one indicated in the
        '''server schema, use type-mappers to map between the two.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Protected Function ResolveNameFromType(ByVal clientType As Global.System.Type) As String
            If clientType.Namespace.Equals(String.Concat(ROOTNAMESPACE, "LightSwitchApplication.Implementation"), Global.System.StringComparison.OrdinalIgnoreCase) Then
                Return String.Concat("LightSwitchApplication.", clientType.Name)
            End If
            Return Nothing
        End Function
        '''<summary>
        '''There are no comments for Products in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public ReadOnly Property Products() As Global.System.Data.Services.Client.DataServiceQuery(Of Product)
            Get
                If (Me._Products Is Nothing) Then
                    Me._Products = MyBase.CreateQuery(Of Product)("Products")
                End If
                Return Me._Products
            End Get
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _Products As Global.System.Data.Services.Client.DataServiceQuery(Of Product)
        '''<summary>
        '''There are no comments for ProductRebates in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public ReadOnly Property ProductRebates() As Global.System.Data.Services.Client.DataServiceQuery(Of ProductRebate)
            Get
                If (Me._ProductRebates Is Nothing) Then
                    Me._ProductRebates = MyBase.CreateQuery(Of ProductRebate)("ProductRebates")
                End If
                Return Me._ProductRebates
            End Get
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductRebates As Global.System.Data.Services.Client.DataServiceQuery(Of ProductRebate)
        '''<summary>
        '''There are no comments for Products in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Sub AddToProducts(ByVal product As Product)
            MyBase.AddObject("Products", product)
        End Sub
        '''<summary>
        '''There are no comments for ProductRebates in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Sub AddToProductRebates(ByVal productRebate As ProductRebate)
            MyBase.AddObject("ProductRebates", productRebate)
        End Sub
    End Class
    '''<summary>
    '''There are no comments for LightSwitchApplication.Product in the schema.
    '''</summary>
    '''<KeyProperties>
    '''ProductID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.EntitySetAttribute("Products"),  _
     Global.System.Data.Services.Common.DataServiceKeyAttribute("ProductID")>  _
    Partial Public Class Product
        Inherits Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityBase
        Implements Global.System.ComponentModel.INotifyPropertyChanged
        '''<summary>
        '''Create a new Product object.
        '''</summary>
        '''<param name="productID">Initial value of ProductID.</param>
        '''<param name="productName">Initial value of ProductName.</param>
        '''<param name="mSRP">Initial value of MSRP.</param>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Shared Function CreateProduct(ByVal productID As Integer, ByVal productName As String, ByVal mSRP As Decimal) As Product
            Dim product As Product = New Product()
            product.ProductID = productID
            product.ProductName = productName
            product.MSRP = mSRP
            Return product
        End Function
        '''<summary>
        '''There are no comments for Property ProductID in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductID() As Integer
            Get
                Return Me._ProductID
            End Get
            Set
                Me.OnProductIDChanging(value)
                If Object.Equals(Me.ProductID, value) Then
                    Return
                End If
                Me._ProductID = value
                Me.OnProductIDChanged
                Me.OnPropertyChanged("ProductID")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductID As Integer
        Partial Private Sub OnProductIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnProductIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductName in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductName() As String
            Get
                Return Me._ProductName
            End Get
            Set
                Me.OnProductNameChanging(value)
                If Object.Equals(Me.ProductName, value) Then
                    Return
                End If
                Me._ProductName = value
                Me.OnProductNameChanged
                Me.OnPropertyChanged("ProductName")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductName As String
        Partial Private Sub OnProductNameChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnProductNameChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property MSRP in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property MSRP() As Decimal
            Get
                Return Me._MSRP
            End Get
            Set
                Me.OnMSRPChanging(value)
                If Object.Equals(Me.MSRP, value) Then
                    Return
                End If
                Me._MSRP = value
                Me.OnMSRPChanged
                Me.OnPropertyChanged("MSRP")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _MSRP As Decimal
        Partial Private Sub OnMSRPChanging(ByVal value As Decimal)
        End Sub
        Partial Private Sub OnMSRPChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Description in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property Description() As String
            Get
                Return Me._Description
            End Get
            Set
                Me.OnDescriptionChanging(value)
                If Object.Equals(Me.Description, value) Then
                    Return
                End If
                Me._Description = value
                Me.OnDescriptionChanged
                Me.OnPropertyChanged("Description")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _Description As String
        Partial Private Sub OnDescriptionChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnDescriptionChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductImage in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductImage() As Byte()
            Get
                If (Not (Me._ProductImage) Is Nothing) Then
                    Return CType(Me._ProductImage.Clone,Byte())
                Else
                    Return Nothing
                End If
            End Get
            Set
                Me.OnProductImageChanging(value)
                If Object.Equals(Me.ProductImage, value) Then
                    Return
                End If
                Me._ProductImage = value
                Me.OnProductImageChanged
                Me.OnPropertyChanged("ProductImage")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductImage() As Byte
        Partial Private Sub OnProductImageChanging(ByVal value() As Byte)
        End Sub
        Partial Private Sub OnProductImageChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Category in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property Category() As String
            Get
                Return Me._Category
            End Get
            Set
                Me.OnCategoryChanging(value)
                If Object.Equals(Me.Category, value) Then
                    Return
                End If
                Me._Category = value
                Me.OnCategoryChanged
                Me.OnPropertyChanged("Category")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _Category As String
        Partial Private Sub OnCategoryChanging(ByVal value As String)
        End Sub
        Partial Private Sub OnCategoryChanged()
        End Sub
        '''<summary>
        '''There are no comments for ProductRebates in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductRebates() As Global.System.Data.Services.Client.DataServiceCollection(Of ProductRebate)
            Get
                Me.__ProductRebates.EnsureValueInitialized
                Return Me._ProductRebates
            End Get
            Set
                Me._ProductRebates = value
                Me.OnPropertyChanged("ProductRebates")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductRebates As Global.System.Data.Services.Client.DataServiceCollection(Of ProductRebate) = New Global.System.Data.Services.Client.DataServiceCollection(Of ProductRebate)(Nothing, System.Data.Services.Client.TrackingMode.None)
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Event PropertyChanged As Global.System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Protected Overridable Sub OnPropertyChanged(ByVal [property] As String)
            If (Not (Me.PropertyChangedEvent) Is Nothing) Then
                RaiseEvent PropertyChanged(Me, New Global.System.ComponentModel.PropertyChangedEventArgs([property]))
            End If
        End Sub
    End Class
    '''<summary>
    '''There are no comments for LightSwitchApplication.ProductRebate in the schema.
    '''</summary>
    '''<KeyProperties>
    '''ProductRebateID
    '''</KeyProperties>
    <Global.System.Data.Services.Common.EntitySetAttribute("ProductRebates"),  _
     Global.System.Data.Services.Common.DataServiceKeyAttribute("ProductRebateID")>  _
    Partial Public Class ProductRebate
        Inherits Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityBase
        Implements Global.System.ComponentModel.INotifyPropertyChanged
        '''<summary>
        '''Create a new ProductRebate object.
        '''</summary>
        '''<param name="productRebateID">Initial value of ProductRebateID.</param>
        '''<param name="productID">Initial value of ProductID.</param>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Shared Function CreateProductRebate(ByVal productRebateID As Integer, ByVal productID As Integer) As ProductRebate
            Dim productRebate As ProductRebate = New ProductRebate()
            productRebate.ProductRebateID = productRebateID
            productRebate.ProductID = productID
            Return productRebate
        End Function
        '''<summary>
        '''There are no comments for Property ProductRebateID in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductRebateID() As Integer
            Get
                Return Me._ProductRebateID
            End Get
            Set
                Me.OnProductRebateIDChanging(value)
                If Object.Equals(Me.ProductRebateID, value) Then
                    Return
                End If
                Me._ProductRebateID = value
                Me.OnProductRebateIDChanged
                Me.OnPropertyChanged("ProductRebateID")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductRebateID As Integer
        Partial Private Sub OnProductRebateIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnProductRebateIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property RebateStart in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property RebateStart() As Global.System.Nullable(Of Date)
            Get
                Return Me._RebateStart
            End Get
            Set
                Me.OnRebateStartChanging(value)
                If Object.Equals(Me.RebateStart, value) Then
                    Return
                End If
                Me._RebateStart = value
                Me.OnRebateStartChanged
                Me.OnPropertyChanged("RebateStart")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _RebateStart As Global.System.Nullable(Of Date)
        Partial Private Sub OnRebateStartChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnRebateStartChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property RebateEnd in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property RebateEnd() As Global.System.Nullable(Of Date)
            Get
                Return Me._RebateEnd
            End Get
            Set
                Me.OnRebateEndChanging(value)
                If Object.Equals(Me.RebateEnd, value) Then
                    Return
                End If
                Me._RebateEnd = value
                Me.OnRebateEndChanged
                Me.OnPropertyChanged("RebateEnd")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _RebateEnd As Global.System.Nullable(Of Date)
        Partial Private Sub OnRebateEndChanging(ByVal value As Global.System.Nullable(Of Date))
        End Sub
        Partial Private Sub OnRebateEndChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property Rebate in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property Rebate() As Global.System.Nullable(Of Decimal)
            Get
                Return Me._Rebate
            End Get
            Set
                Me.OnRebateChanging(value)
                If Object.Equals(Me.Rebate, value) Then
                    Return
                End If
                Me._Rebate = value
                Me.OnRebateChanged
                Me.OnPropertyChanged("Rebate")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _Rebate As Global.System.Nullable(Of Decimal)
        Partial Private Sub OnRebateChanging(ByVal value As Global.System.Nullable(Of Decimal))
        End Sub
        Partial Private Sub OnRebateChanged()
        End Sub
        '''<summary>
        '''There are no comments for Property ProductID in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property ProductID() As Integer
            Get
                Return Me._ProductID
            End Get
            Set
                Me.OnProductIDChanging(value)
                If Object.Equals(Me.ProductID, value) Then
                    Return
                End If
                Me._ProductID = value
                Me.OnProductIDChanged
                Me.OnPropertyChanged("ProductID")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _ProductID As Integer
        Partial Private Sub OnProductIDChanging(ByVal value As Integer)
        End Sub
        Partial Private Sub OnProductIDChanged()
        End Sub
        '''<summary>
        '''There are no comments for Product in the schema.
        '''</summary>
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Property Product() As Product
            Get
                Me.__Product.EnsureValueInitialized
                Return Me._Product
            End Get
            Set
                Dim previous As Product = Me.Product
                If (previous Is value) Then
                    Return
                End If
                If (Not (previous) Is Nothing) Then
                    Me._Product = Nothing
                    previous.ProductRebates.Remove(Me)
                End If
                If (Not (Me.___Host) Is Nothing) Then
                    If (Not (value) Is Nothing) Then
                        Me.ProductID = value.ProductID
                    Else
                        Me.ProductID = CType(Nothing, Integer)
                    End If
                End If
                Me._Product = value
                Me.__Product.OnValueSet
                If (Not (value) Is Nothing) Then
                    value.__ProductRebates.Add(Me)
                End If
                Me.___OnPropertyChanged("Product")
                Me.OnPropertyChanged("Product")
            End Set
        End Property
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Private _Product As Product
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Public Event PropertyChanged As Global.System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Services.Design", "1.0.0")>  _
        Protected Overridable Sub OnPropertyChanged(ByVal [property] As String)
            If (Not (Me.PropertyChangedEvent) Is Nothing) Then
                RaiseEvent PropertyChanged(Me, New Global.System.ComponentModel.PropertyChangedEventArgs([property]))
            End If
        End Sub
    End Class
End Namespace
