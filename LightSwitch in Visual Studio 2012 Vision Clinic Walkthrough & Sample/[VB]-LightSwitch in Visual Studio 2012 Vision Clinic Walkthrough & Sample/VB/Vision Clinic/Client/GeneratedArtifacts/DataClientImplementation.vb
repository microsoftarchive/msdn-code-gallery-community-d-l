'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Namespace LightSwitchApplication.Implementation
    
    #Region "Patient"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/ApplicationData.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class Patient
        Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation
        Private Property _IdImplementation() As Integer Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Id
            Get
                Return Me.Id
            End Get
            Set(ByVal value As Integer)
                Me.Id = value
            End Set
        End Property
        
        Private Sub OnIdChanged()
            Me.___OnPropertyChanged("Id")
        End Sub
        
        Private Property _FirstNameImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.FirstName
            Get
                Return Me.FirstName
            End Get
            Set(ByVal value As String)
                Me.FirstName = value
            End Set
        End Property
        
        Private Sub OnFirstNameChanged()
            Me.___OnPropertyChanged("FirstName")
        End Sub
        
        Private Property _LastNameImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.LastName
            Get
                Return Me.LastName
            End Get
            Set(ByVal value As String)
                Me.LastName = value
            End Set
        End Property
        
        Private Sub OnLastNameChanged()
            Me.___OnPropertyChanged("LastName")
        End Sub
        
        Private Property _StreetImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Street
            Get
                Return Me.Street
            End Get
            Set(ByVal value As String)
                Me.Street = value
            End Set
        End Property
        
        Private Sub OnStreetChanged()
            Me.___OnPropertyChanged("Street")
        End Sub
        
        Private Property _Street2Implementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Street2
            Get
                Return Me.Street2
            End Get
            Set(ByVal value As String)
                Me.Street2 = value
            End Set
        End Property
        
        Private Sub OnStreet2Changed()
            Me.___OnPropertyChanged("Street2")
        End Sub
        
        Private Property _CityImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.City
            Get
                Return Me.City
            End Get
            Set(ByVal value As String)
                Me.City = value
            End Set
        End Property
        
        Private Sub OnCityChanged()
            Me.___OnPropertyChanged("City")
        End Sub
        
        Private Property _StateImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.State
            Get
                Return Me.State
            End Get
            Set(ByVal value As String)
                Me.State = value
            End Set
        End Property
        
        Private Sub OnStateChanged()
            Me.___OnPropertyChanged("State")
        End Sub
        
        Private Property _ZipImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Zip
            Get
                Return Me.Zip
            End Get
            Set(ByVal value As String)
                Me.Zip = value
            End Set
        End Property
        
        Private Sub OnZipChanged()
            Me.___OnPropertyChanged("Zip")
        End Sub
        
        Private Property _PrimaryPhoneImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.PrimaryPhone
            Get
                Return Me.PrimaryPhone
            End Get
            Set(ByVal value As String)
                Me.PrimaryPhone = value
            End Set
        End Property
        
        Private Sub OnPrimaryPhoneChanged()
            Me.___OnPropertyChanged("PrimaryPhone")
        End Sub
        
        Private Property _SecondaryPhoneImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.SecondaryPhone
            Get
                Return Me.SecondaryPhone
            End Get
            Set(ByVal value As String)
                Me.SecondaryPhone = value
            End Set
        End Property
        
        Private Sub OnSecondaryPhoneChanged()
            Me.___OnPropertyChanged("SecondaryPhone")
        End Sub
        
        Private Property _EmailImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Email
            Get
                Return Me.Email
            End Get
            Set(ByVal value As String)
                Me.Email = value
            End Set
        End Property
        
        Private Sub OnEmailChanged()
            Me.___OnPropertyChanged("Email")
        End Sub
        
        Private Property _PolicyNumberImplementation() As String Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.PolicyNumber
            Get
                Return Me.PolicyNumber
            End Get
            Set(ByVal value As String)
                Me.PolicyNumber = value
            End Set
        End Property
        
        Private Sub OnPolicyNumberChanged()
            Me.___OnPropertyChanged("PolicyNumber")
        End Sub
        
        Private ReadOnly Property _InvoicesImplementation() As Global.System.Collections.IEnumerable Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Invoices
            Get
                Return Me.Invoices
            End Get
        End Property
        
        Friend ReadOnly Property __Invoices As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Invoice) 
            Get
                If (Me.___Invoices Is Nothing) Then
                    Me.___Invoices = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Invoice)( _
                        Me, _
                        "Invoices", _
                        Function() Me._Invoices, _
                        Function(e) Global.System.Object.Equals(e.Invoice_Patient, Me.Id))
                End If
                Return Me.___Invoices
            End Get
        End Property
        
        Private ___Invoices As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Invoice)
        
        Private ReadOnly Property _AppointmentsImplementation() As Global.System.Collections.IEnumerable Implements Global.LightSwitchApplication.Patient.DetailsClass.IImplementation.Appointments
            Get
                Return Me.Appointments
            End Get
        End Property
        
        Friend ReadOnly Property __Appointments As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Appointment) 
            Get
                If (Me.___Appointments Is Nothing) Then
                    Me.___Appointments = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Appointment)( _
                        Me, _
                        "Appointments", _
                        Function() Me._Appointments, _
                        Function(e) Global.System.Object.Equals(e.Appointment_Patient, Me.Id))
                End If
                Return Me.___Appointments
            End Get
        End Property
        
        Private ___Appointments As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.Appointment)
        
    End Class
    #End Region
    
    #Region "Invoice"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/ApplicationData.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class Invoice
        Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation
        Private Sub OnInvoice_PatientChanged()
            Me.___OnPropertyChanged("Invoice_Patient")
            Me.___OnPropertyChanged("Patient")
        End Sub
        
        Private Property _IdImplementation() As Integer Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.Id
            Get
                Return Me.Id
            End Get
            Set(ByVal value As Integer)
                Me.Id = value
            End Set
        End Property
        
        Private Sub OnIdChanged()
            Me.___OnPropertyChanged("Id")
        End Sub
        
        Private Property _InvoiceDateImplementation() As Date Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.InvoiceDate
            Get
                Return Me.InvoiceDate
            End Get
            Set(ByVal value As Date)
                Me.InvoiceDate = value
            End Set
        End Property
        
        Private Sub OnInvoiceDateChanged()
            Me.___OnPropertyChanged("InvoiceDate")
        End Sub
        
        Private Property _InvoiceDueImplementation() As Global.System.Nullable(Of Date) Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.InvoiceDue
            Get
                Return Me.InvoiceDue
            End Get
            Set(ByVal value As Global.System.Nullable(Of Date))
                Me.InvoiceDue = value
            End Set
        End Property
        
        Private Sub OnInvoiceDueChanged()
            Me.___OnPropertyChanged("InvoiceDue")
        End Sub
        
        Private Property _InvoiceStatusImplementation() As Integer Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.InvoiceStatus
            Get
                Return Me.InvoiceStatus
            End Get
            Set(ByVal value As Integer)
                Me.InvoiceStatus = value
            End Set
        End Property
        
        Private Sub OnInvoiceStatusChanged()
            Me.___OnPropertyChanged("InvoiceStatus")
        End Sub
        
        Private Property _ShipDateImplementation() As Date Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.ShipDate
            Get
                Return Me.ShipDate
            End Get
            Set(ByVal value As Date)
                Me.ShipDate = value
            End Set
        End Property
        
        Private Sub OnShipDateChanged()
            Me.___OnPropertyChanged("ShipDate")
        End Sub
        
        Private Property _PatientImplementation() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.Patient
            Get
                Return Me.Patient
            End Get
            Set(ByVal value As Global.Microsoft.LightSwitch.Internal.IEntityImplementation)
                Me.Patient = DirectCast(value, Global.LightSwitchApplication.Implementation.Patient)
            End Set
        End Property
        
        Private ReadOnly Property __Patient As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient) 
            Get
                If (Me.___Patient Is Nothing) Then
                    Me.___Patient = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient)( _
                        Me, _
                        "Patient", _
                        New Global.System.String() {"Invoice_Patient"}, _
                        Function(e) Global.System.Object.Equals(e.Id, Me.Invoice_Patient), _
                        Function() Me._Patient, _
                        Sub(e) Me._Patient = e)
                End If
                Return Me.___Patient
            End Get
        End Property
        
        Private ___Patient As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient)
        
        Private ReadOnly Property _InvoiceDetailsImplementation() As Global.System.Collections.IEnumerable Implements Global.LightSwitchApplication.Invoice.DetailsClass.IImplementation.InvoiceDetails
            Get
                Return Me.InvoiceDetails
            End Get
        End Property
        
        Friend ReadOnly Property __InvoiceDetails As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.InvoiceDetail) 
            Get
                If (Me.___InvoiceDetails Is Nothing) Then
                    Me.___InvoiceDetails = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.InvoiceDetail)( _
                        Me, _
                        "InvoiceDetails", _
                        Function() Me._InvoiceDetails, _
                        Function(e) Global.System.Object.Equals(e.Invoice_InvoiceDetail, Me.Id))
                End If
                Return Me.___InvoiceDetails
            End Get
        End Property
        
        Private ___InvoiceDetails As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.InvoiceDetail)
        
    End Class
    #End Region
    
    #Region "InvoiceDetail"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/ApplicationData.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class InvoiceDetail
        Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation
        Private Sub OnInvoice_InvoiceDetailChanged()
            Me.___OnPropertyChanged("Invoice_InvoiceDetail")
            Me.___OnPropertyChanged("Invoice")
        End Sub
        
        Private Property _IdImplementation() As Integer Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.Id
            Get
                Return Me.Id
            End Get
            Set(ByVal value As Integer)
                Me.Id = value
            End Set
        End Property
        
        Private Sub OnIdChanged()
            Me.___OnPropertyChanged("Id")
        End Sub
        
        Private Property _QuantityImplementation() As Integer Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.Quantity
            Get
                Return Me.Quantity
            End Get
            Set(ByVal value As Integer)
                Me.Quantity = value
            End Set
        End Property
        
        Private Sub OnQuantityChanged()
            Me.___OnPropertyChanged("Quantity")
        End Sub
        
        Private Property _UnitPriceImplementation() As Decimal Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.UnitPrice
            Get
                Return Me.UnitPrice
            End Get
            Set(ByVal value As Decimal)
                Me.UnitPrice = value
            End Set
        End Property
        
        Private Sub OnUnitPriceChanged()
            Me.___OnPropertyChanged("UnitPrice")
        End Sub
        
        Private Property _Product_ProductIDImplementation() As Integer Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.Product_ProductID
            Get
                Return Me.Product_ProductID
            End Get
            Set(ByVal value As Integer)
                Me.Product_ProductID = value
            End Set
        End Property
        
        Private Sub OnProduct_ProductIDChanged()
            Me.___OnPropertyChanged("Product_ProductID")
        End Sub
        
        Private Property _InvoiceImplementation() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation Implements Global.LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.Invoice
            Get
                Return Me.Invoice
            End Get
            Set(ByVal value As Global.Microsoft.LightSwitch.Internal.IEntityImplementation)
                Me.Invoice = DirectCast(value, Global.LightSwitchApplication.Implementation.Invoice)
            End Set
        End Property
        
        Private ReadOnly Property __Invoice As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Invoice) 
            Get
                If (Me.___Invoice Is Nothing) Then
                    Me.___Invoice = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Invoice)( _
                        Me, _
                        "Invoice", _
                        New Global.System.String() {"Invoice_InvoiceDetail"}, _
                        Function(e) Global.System.Object.Equals(e.Id, Me.Invoice_InvoiceDetail), _
                        Function() Me._Invoice, _
                        Sub(e) Me._Invoice = e)
                End If
                Return Me.___Invoice
            End Get
        End Property
        
        Private ___Invoice As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Invoice)
        
    End Class
    #End Region
    
    #Region "Appointment"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/ApplicationData.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class Appointment
        Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation
        Private Sub OnAppointment_PatientChanged()
            Me.___OnPropertyChanged("Appointment_Patient")
            Me.___OnPropertyChanged("Patient")
        End Sub
        
        Private Property _IdImplementation() As Integer Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation.Id
            Get
                Return Me.Id
            End Get
            Set(ByVal value As Integer)
                Me.Id = value
            End Set
        End Property
        
        Private Sub OnIdChanged()
            Me.___OnPropertyChanged("Id")
        End Sub
        
        Private Property _AppointmentTimeImplementation() As Date Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation.AppointmentTime
            Get
                Return Me.AppointmentTime
            End Get
            Set(ByVal value As Date)
                Me.AppointmentTime = value
            End Set
        End Property
        
        Private Sub OnAppointmentTimeChanged()
            Me.___OnPropertyChanged("AppointmentTime")
        End Sub
        
        Private Property _AppointmentTypeImplementation() As Short Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation.AppointmentType
            Get
                Return Me.AppointmentType
            End Get
            Set(ByVal value As Short)
                Me.AppointmentType = value
            End Set
        End Property
        
        Private Sub OnAppointmentTypeChanged()
            Me.___OnPropertyChanged("AppointmentType")
        End Sub
        
        Private Property _DoctorNotesImplementation() As String Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation.DoctorNotes
            Get
                Return Me.DoctorNotes
            End Get
            Set(ByVal value As String)
                Me.DoctorNotes = value
            End Set
        End Property
        
        Private Sub OnDoctorNotesChanged()
            Me.___OnPropertyChanged("DoctorNotes")
        End Sub
        
        Private Property _PatientImplementation() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation Implements Global.LightSwitchApplication.Appointment.DetailsClass.IImplementation.Patient
            Get
                Return Me.Patient
            End Get
            Set(ByVal value As Global.Microsoft.LightSwitch.Internal.IEntityImplementation)
                Me.Patient = DirectCast(value, Global.LightSwitchApplication.Implementation.Patient)
            End Set
        End Property
        
        Private ReadOnly Property __Patient As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient) 
            Get
                If (Me.___Patient Is Nothing) Then
                    Me.___Patient = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient)( _
                        Me, _
                        "Patient", _
                        New Global.System.String() {"Appointment_Patient"}, _
                        Function(e) Global.System.Object.Equals(e.Id, Me.Appointment_Patient), _
                        Function() Me._Patient, _
                        Sub(e) Me._Patient = e)
                End If
                Return Me.___Patient
            End Get
        End Property
        
        Private ___Patient As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Patient)
        
    End Class
    #End Region
    
    #Region "Product"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/PrescriptionContoso.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class Product
        Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation
        Private ReadOnly Property _ProductIDImplementation() As Integer Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.ProductID
            Get
                Return Me.ProductID
            End Get
        End Property
        
        Private Sub OnProductIDChanged()
            Me.___OnPropertyChanged("ProductID")
        End Sub
        
        Private Property _ProductNameImplementation() As String Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.ProductName
            Get
                Return Me.ProductName
            End Get
            Set(ByVal value As String)
                Me.ProductName = value
            End Set
        End Property
        
        Private Sub OnProductNameChanged()
            Me.___OnPropertyChanged("ProductName")
        End Sub
        
        Private Property _MSRPImplementation() As Decimal Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.MSRP
            Get
                Return Me.MSRP
            End Get
            Set(ByVal value As Decimal)
                Me.MSRP = value
            End Set
        End Property
        
        Private Sub OnMSRPChanged()
            Me.___OnPropertyChanged("MSRP")
        End Sub
        
        Private Property _DescriptionImplementation() As String Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.Description
            Get
                Return Me.Description
            End Get
            Set(ByVal value As String)
                Me.Description = value
            End Set
        End Property
        
        Private Sub OnDescriptionChanged()
            Me.___OnPropertyChanged("Description")
        End Sub
        
        Private Property _ProductImageImplementation() As Byte() Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.ProductImage
            Get
                Return Me.ProductImage
            End Get
            Set(ByVal value As Byte())
                Me.ProductImage = value
            End Set
        End Property
        
        Private Sub OnProductImageChanged()
            Me.___OnPropertyChanged("ProductImage")
        End Sub
        
        Private Property _CategoryImplementation() As String Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.Category
            Get
                Return Me.Category
            End Get
            Set(ByVal value As String)
                Me.Category = value
            End Set
        End Property
        
        Private Sub OnCategoryChanged()
            Me.___OnPropertyChanged("Category")
        End Sub
        
        Private ReadOnly Property _ProductRebatesImplementation() As Global.System.Collections.IEnumerable Implements Global.LightSwitchApplication.Product.DetailsClass.IImplementation.ProductRebates
            Get
                Return Me.ProductRebates
            End Get
        End Property
        
        Friend ReadOnly Property __ProductRebates As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.ProductRebate) 
            Get
                If (Me.___ProductRebates Is Nothing) Then
                    Me.___ProductRebates = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.ProductRebate)( _
                        Me, _
                        "ProductRebates", _
                        Function() Me._ProductRebates, _
                        Function(e) Global.System.Object.Equals(e.ProductID, Me.ProductID))
                End If
                Return Me.___ProductRebates
            End Get
        End Property
        
        Private ___ProductRebates As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRefCollection(Of Global.LightSwitchApplication.Implementation.ProductRebate)
        
    End Class
    #End Region
    
    #Region "ProductRebate"
    <Global.System.Runtime.Serialization.DataContract(Namespace:="http://schemas.datacontract.org/2004/07/PrescriptionContoso.Implementation")> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class ProductRebate
        Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation
        Private Sub OnProductIDChanged()
            Me.___OnPropertyChanged("ProductID")
            Me.___OnPropertyChanged("Product")
        End Sub
        
        Private ReadOnly Property _ProductRebateIDImplementation() As Integer Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.ProductRebateID
            Get
                Return Me.ProductRebateID
            End Get
        End Property
        
        Private Sub OnProductRebateIDChanged()
            Me.___OnPropertyChanged("ProductRebateID")
        End Sub
        
        Private Property _RebateStartImplementation() As Global.System.Nullable(Of Date) Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.RebateStart
            Get
                Return Me.RebateStart
            End Get
            Set(ByVal value As Global.System.Nullable(Of Date))
                Me.RebateStart = value
            End Set
        End Property
        
        Private Sub OnRebateStartChanged()
            Me.___OnPropertyChanged("RebateStart")
        End Sub
        
        Private Property _RebateEndImplementation() As Global.System.Nullable(Of Date) Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.RebateEnd
            Get
                Return Me.RebateEnd
            End Get
            Set(ByVal value As Global.System.Nullable(Of Date))
                Me.RebateEnd = value
            End Set
        End Property
        
        Private Sub OnRebateEndChanged()
            Me.___OnPropertyChanged("RebateEnd")
        End Sub
        
        Private Property _RebateImplementation() As Global.System.Nullable(Of Decimal) Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.Rebate
            Get
                Return Me.Rebate
            End Get
            Set(ByVal value As Global.System.Nullable(Of Decimal))
                Me.Rebate = value
            End Set
        End Property
        
        Private Sub OnRebateChanged()
            Me.___OnPropertyChanged("Rebate")
        End Sub
        
        Private Property _ProductImplementation() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation Implements Global.LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.Product
            Get
                Return Me.Product
            End Get
            Set(ByVal value As Global.Microsoft.LightSwitch.Internal.IEntityImplementation)
                Me.Product = DirectCast(value, Global.LightSwitchApplication.Implementation.Product)
            End Set
        End Property
        
        Private ReadOnly Property __Product As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Product) 
            Get
                If (Me.___Product Is Nothing) Then
                    Me.___Product = New Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Product)( _
                        Me, _
                        "Product", _
                        New Global.System.String() {"ProductID"}, _
                        Function(e) Global.System.Object.Equals(e.ProductID, Me.ProductID), _
                        Function() Me._Product, _
                        Sub(e) Me._Product = e)
                End If
                Return Me.___Product
            End Get
        End Property
        
        Private ___Product As Global.Microsoft.LightSwitch.ClientGenerated.Implementation.EntityRef(Of Global.LightSwitchApplication.Implementation.Product)
        
    End Class
    #End Region
    
    #Region "ApplicationDataObjectContext"
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Partial Class ApplicationDataObjectContext
        Protected Overrides Function CreateEntityImplementation(Of T As Global.Microsoft.LightSwitch.IEntityObject)() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.Patient)) Then
                Return New Global.LightSwitchApplication.Implementation.Patient()
            End If
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.Invoice)) Then
                Return New Global.LightSwitchApplication.Implementation.Invoice()
            End If
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.InvoiceDetail)) Then
                Return New Global.LightSwitchApplication.Implementation.InvoiceDetail()
            End If
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.Appointment)) Then
                Return New Global.LightSwitchApplication.Implementation.Appointment()
            End If
            Return Nothing
        End Function
    End Class
    #End Region
    
    #Region "PrescriptionContosoObjectContext"
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Partial Class PrescriptionContosoObjectContext
        Protected Overrides Function CreateEntityImplementation(Of T As Global.Microsoft.LightSwitch.IEntityObject)() As Global.Microsoft.LightSwitch.Internal.IEntityImplementation
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.Product)) Then
                Return New Global.LightSwitchApplication.Implementation.Product()
            End If
            If GetType(T).Equals(GetType(Global.LightSwitchApplication.ProductRebate)) Then
                Return New Global.LightSwitchApplication.Implementation.ProductRebate()
            End If
            Return Nothing
        End Function
    End Class
    #End Region
    
    #Region "DataServiceImplementationFactory"
    <Global.System.ComponentModel.Composition.PartCreationPolicy(Global.System.ComponentModel.Composition.CreationPolicy.Shared)> _
    <Global.System.ComponentModel.Composition.Export(GetType(Global.Microsoft.LightSwitch.Internal.IDataServiceFactory))> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class DataServiceFactory
        Inherits Global.Microsoft.LightSwitch.ClientGenerated.Implementation.DataServiceFactory
    
        Protected Overrides Function CreateDataService(ByVal dataServiceType As Global.System.Type) As Global.Microsoft.LightSwitch.IDataService
            If dataServiceType.Equals(GetType(Global.LightSwitchApplication.ApplicationData)) Then
                Return New Global.LightSwitchApplication.ApplicationData()
            End If
            If dataServiceType.Equals(GetType(Global.LightSwitchApplication.PrescriptionContoso)) Then
                Return New Global.LightSwitchApplication.PrescriptionContoso()
            End If
            Return MyBase.CreateDataService(dataServiceType)
        End Function
    
        Protected Overrides Function CreateDataServiceImplementation(Of TDataService As Global.Microsoft.LightSwitch.IDataService)(ByVal dataService As TDataService) As Global.Microsoft.LightSwitch.Internal.IDataServiceImplementation
            If GetType(TDataService).Equals(GetType(Global.LightSwitchApplication.ApplicationData)) Then
                Return New Global.LightSwitchApplication.Implementation.ApplicationDataObjectContext(Global.Microsoft.LightSwitch.ClientGenerated.Implementation.DataServiceContext.CreateServiceUri("../ApplicationData.svc"))
            End If
            If GetType(TDataService).Equals(GetType(Global.LightSwitchApplication.PrescriptionContoso)) Then
                Return New Global.LightSwitchApplication.Implementation.PrescriptionContosoObjectContext(Global.Microsoft.LightSwitch.ClientGenerated.Implementation.DataServiceContext.CreateServiceUri("../PrescriptionContoso.svc"))
            End If
            Return MyBase.CreateDataServiceImplementation(dataService)
        End Function
    End Class
    #End Region
    
    <Global.System.ComponentModel.Composition.PartCreationPolicy(Global.System.ComponentModel.Composition.CreationPolicy.Shared)> _
    <Global.System.ComponentModel.Composition.Export(GetType(Global.Microsoft.LightSwitch.Internal.ITypeMappingProvider))> _
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")> _
    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Public Class __TypeMapping
        Implements Global.Microsoft.LightSwitch.Internal.ITypeMappingProvider
        Private Function GetImplementationType(ByVal definitionType As Global.System.Type) As Global.System.Type Implements Global.Microsoft.LightSwitch.Internal.ITypeMappingProvider.GetImplementationType
            If GetType(Global.LightSwitchApplication.Patient).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.Patient)
            End If
            If GetType(Global.LightSwitchApplication.Invoice).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.Invoice)
            End If
            If GetType(Global.LightSwitchApplication.InvoiceDetail).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.InvoiceDetail)
            End If
            If GetType(Global.LightSwitchApplication.Appointment).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.Appointment)
            End If
            If GetType(Global.LightSwitchApplication.Product).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.Product)
            End If
            If GetType(Global.LightSwitchApplication.ProductRebate).Equals(definitionType)
                Return GetType(Global.LightSwitchApplication.Implementation.ProductRebate)
            End If
            Return Nothing
        End Function
    End Class
End Namespace
