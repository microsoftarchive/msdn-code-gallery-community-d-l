//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using global::System.Linq;

namespace LightSwitchApplication.Implementation
{
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class ApplicationDataDataService
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DataService<global::ApplicationData.Implementation.ApplicationDataObjectContext>
    {
    
        public ApplicationDataDataService() : base()
        {
        }
    
        protected override global::Microsoft.LightSwitch.IDataService CreateDataService()
        {
            return new global::LightSwitchApplication.DataWorkspace().ApplicationData;
        }
    }
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class PrescriptionContosoDataService
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DataService<global::PrescriptionContoso.Implementation.PrescriptionContosoObjectContext>
    {
    
        public PrescriptionContosoDataService() : base()
        {
        }
    
        protected override global::Microsoft.LightSwitch.IDataService CreateDataService()
        {
            return new global::LightSwitchApplication.DataWorkspace().PrescriptionContoso;
        }
    }
    
    [global::System.ServiceModel.DomainServices.Hosting.EnableClientAccess()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class ApplicationDataDomainService
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DomainService<global::ApplicationData.Implementation.ApplicationDataObjectContext>
    {
    
        public ApplicationDataDomainService() : base()
        {
        }
    
    #region Public Methods
    
    #region Patient
    
        public void InsertPatient(global::ApplicationData.Implementation.Patient entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.Patients.AddObject(entity);
            }
        }
    
        public void UpdatePatient(global::ApplicationData.Implementation.Patient currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.Patients, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeletePatient(global::ApplicationData.Implementation.Patient entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.Patients.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region Invoice
    
        public void InsertInvoice(global::ApplicationData.Implementation.Invoice entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.Invoices.AddObject(entity);
            }
        }
    
        public void UpdateInvoice(global::ApplicationData.Implementation.Invoice currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.Invoices, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeleteInvoice(global::ApplicationData.Implementation.Invoice entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.Invoices.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region InvoiceDetail
    
        public void InsertInvoiceDetail(global::ApplicationData.Implementation.InvoiceDetail entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.InvoiceDetails.AddObject(entity);
            }
        }
    
        public void UpdateInvoiceDetail(global::ApplicationData.Implementation.InvoiceDetail currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.InvoiceDetails, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeleteInvoiceDetail(global::ApplicationData.Implementation.InvoiceDetail entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.InvoiceDetails.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region Appointment
    
        public void InsertAppointment(global::ApplicationData.Implementation.Appointment entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.Appointments.AddObject(entity);
            }
        }
    
        public void UpdateAppointment(global::ApplicationData.Implementation.Appointment currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.Appointments, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeleteAppointment(global::ApplicationData.Implementation.Appointment entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.Appointments.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region Queries
    #endregion
    
        [global::System.ServiceModel.DomainServices.Server.Invoke(HasSideEffects=false)]
        public int __GetEntitySetCanInformation(string entitySetName)
        {
            return base.GetEntitySetCanInformation(entitySetName);
        }
    
        [global::System.ServiceModel.DomainServices.Server.Invoke(HasSideEffects=false)]
        public bool __CanExecuteOperation(string operationName)
        {
            return base.CanExecuteOperation(operationName);
        }
    
    #endregion
    
        protected override global::Microsoft.LightSwitch.IDataService CreateDataService()
        {
            return new global::LightSwitchApplication.DataWorkspace().ApplicationData;
        }
    
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class ApplicationDataServiceImplementation
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DataServiceImplementation<global::ApplicationData.Implementation.ApplicationDataObjectContext>
    {
        public ApplicationDataServiceImplementation(global::Microsoft.LightSwitch.IDataService dataService) : base(dataService)
        {
        }
    
    #region Queries
    #endregion

    #region Protected Methods
        protected override object CreateObject(global::System.Type type)
        {
            if (type == typeof(global::ApplicationData.Implementation.Patient))
            {
                return new global::ApplicationData.Implementation.Patient();
            }
            if (type == typeof(global::ApplicationData.Implementation.Invoice))
            {
                return new global::ApplicationData.Implementation.Invoice();
            }
            if (type == typeof(global::ApplicationData.Implementation.InvoiceDetail))
            {
                return new global::ApplicationData.Implementation.InvoiceDetail();
            }
            if (type == typeof(global::ApplicationData.Implementation.Appointment))
            {
                return new global::ApplicationData.Implementation.Appointment();
            }
    
            return base.CreateObject(type);
        }
    
        protected override global::ApplicationData.Implementation.ApplicationDataObjectContext CreateObjectContext()
        {
            string assemblyName = global::System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            return new global::ApplicationData.Implementation.ApplicationDataObjectContext(base.GetEntityConnectionString(
                "_IntrinsicData", 
                "res://" + assemblyName + "/ApplicationData.csdl|res://" + assemblyName + "/ApplicationData.ssdl|res://" + assemblyName + "/ApplicationData.msl", 
                "System.Data.SqlClient"));
        }
    
        protected override global::Microsoft.LightSwitch.Internal.IEntityImplementation CreateEntityImplementation<T>()
        {
            if (typeof(T) == typeof(global::LightSwitchApplication.Patient))
            {
                return new global::ApplicationData.Implementation.Patient();
            }
            if (typeof(T) == typeof(global::LightSwitchApplication.Invoice))
            {
                return new global::ApplicationData.Implementation.Invoice();
            }
            if (typeof(T) == typeof(global::LightSwitchApplication.InvoiceDetail))
            {
                return new global::ApplicationData.Implementation.InvoiceDetail();
            }
            if (typeof(T) == typeof(global::LightSwitchApplication.Appointment))
            {
                return new global::ApplicationData.Implementation.Appointment();
            }
            return null;
        }
    
    #endregion
    
    }
    
    [global::System.ServiceModel.DomainServices.Hosting.EnableClientAccess()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class PrescriptionContosoDomainService
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DomainService<global::PrescriptionContoso.Implementation.PrescriptionContosoObjectContext>
    {
    
        public PrescriptionContosoDomainService() : base()
        {
        }
    
    #region Public Methods
    
    #region Product
    
        public void InsertProduct(global::PrescriptionContoso.Implementation.Product entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.Products.AddObject(entity);
            }
        }
    
        public void UpdateProduct(global::PrescriptionContoso.Implementation.Product currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.Products, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeleteProduct(global::PrescriptionContoso.Implementation.Product entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.Products.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region ProductRebate
    
        public void InsertProductRebate(global::PrescriptionContoso.Implementation.ProductRebate entity)
        {
            if (entity.EntityState != global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(entity, global::System.Data.EntityState.Added);
            }
            else
            {
                this.ObjectContext.ProductRebates.AddObject(entity);
            }
        }
    
        public void UpdateProductRebate(global::PrescriptionContoso.Implementation.ProductRebate currentEntity)
        {
            global::System.ServiceModel.DomainServices.EntityFramework.ObjectContextExtensions.AttachAsModified(this.ObjectContext.ProductRebates, currentEntity, this.ChangeSet.GetOriginal(currentEntity));
        }
    
        public void DeleteProductRebate(global::PrescriptionContoso.Implementation.ProductRebate entity)
        {
            if (entity.EntityState == global::System.Data.EntityState.Detached)
            {
                this.ObjectContext.ProductRebates.Attach(entity);
            }
    
            this.DeleteEntity(entity);
        }
    #endregion
    
    #region Queries
        public global::System.Linq.IQueryable<global::PrescriptionContoso.Implementation.Product> RelatedProducts(string frameworkOperators, string Category)
        {
            return this.GetQuery<global::PrescriptionContoso.Implementation.Product>("RelatedProducts", frameworkOperators, Category);
        }
    
    #endregion
    
        [global::System.ServiceModel.DomainServices.Server.Invoke(HasSideEffects=false)]
        public int __GetEntitySetCanInformation(string entitySetName)
        {
            return base.GetEntitySetCanInformation(entitySetName);
        }
    
        [global::System.ServiceModel.DomainServices.Server.Invoke(HasSideEffects=false)]
        public bool __CanExecuteOperation(string operationName)
        {
            return base.CanExecuteOperation(operationName);
        }
    
    #endregion
    
        protected override global::Microsoft.LightSwitch.IDataService CreateDataService()
        {
            return new global::LightSwitchApplication.DataWorkspace().PrescriptionContoso;
        }
    
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class PrescriptionContosoServiceImplementation
        : global::Microsoft.LightSwitch.ServerGenerated.Implementation.DataServiceImplementation<global::PrescriptionContoso.Implementation.PrescriptionContosoObjectContext>
    {
        public PrescriptionContosoServiceImplementation(global::Microsoft.LightSwitch.IDataService dataService) : base(dataService)
        {
        }
    
    #region Queries
        public global::System.Linq.IQueryable<global::PrescriptionContoso.Implementation.Product> RelatedProducts(string Category)
        {
            global::System.Linq.IQueryable<global::PrescriptionContoso.Implementation.Product> query;
            query = global::System.Linq.Queryable.Where(
                this.GetQuery<global::PrescriptionContoso.Implementation.Product>("Products"),
                (p) => (p.Category.CompareTo(Category) == 0));
            return query;
        }
    
    #endregion

    #region Protected Methods
        protected override object CreateObject(global::System.Type type)
        {
            if (type == typeof(global::PrescriptionContoso.Implementation.Product))
            {
                return new global::PrescriptionContoso.Implementation.Product();
            }
            if (type == typeof(global::PrescriptionContoso.Implementation.ProductRebate))
            {
                return new global::PrescriptionContoso.Implementation.ProductRebate();
            }
    
            return base.CreateObject(type);
        }
    
        protected override global::PrescriptionContoso.Implementation.PrescriptionContosoObjectContext CreateObjectContext()
        {
            string assemblyName = global::System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            return new global::PrescriptionContoso.Implementation.PrescriptionContosoObjectContext(base.GetEntityConnectionString(
                "PrescriptionContoso", 
                "res://" + assemblyName + "/PrescriptionContoso.csdl|res://" + assemblyName + "/PrescriptionContoso.ssdl|res://" + assemblyName + "/PrescriptionContoso.msl", 
                "System.Data.SqlClient"));
        }
    
        protected override global::Microsoft.LightSwitch.Internal.IEntityImplementation CreateEntityImplementation<T>()
        {
            if (typeof(T) == typeof(global::LightSwitchApplication.Product))
            {
                return new global::PrescriptionContoso.Implementation.Product();
            }
            if (typeof(T) == typeof(global::LightSwitchApplication.ProductRebate))
            {
                return new global::PrescriptionContoso.Implementation.ProductRebate();
            }
            return null;
        }
    
    #endregion
    
    }
    
    #region DataServiceImplementationFactory
    [global::System.ComponentModel.Composition.PartCreationPolicy(global::System.ComponentModel.Composition.CreationPolicy.Shared)]
    [global::System.ComponentModel.Composition.Export(typeof(global::Microsoft.LightSwitch.Internal.IDataServiceFactory))]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class DataServiceFactory :
        global::Microsoft.LightSwitch.ServerGenerated.Implementation.DataServiceFactory
    {
    
        protected override global::Microsoft.LightSwitch.IDataService CreateDataService(global::System.Type dataServiceType)
        {
            if (dataServiceType == typeof(global::LightSwitchApplication.ApplicationData))
            {
                return new global::LightSwitchApplication.ApplicationDataService();
            }
            if (dataServiceType == typeof(global::LightSwitchApplication.PrescriptionContoso))
            {
                return new global::LightSwitchApplication.PrescriptionContosoService();
            }
            return base.CreateDataService(dataServiceType);
        }
    
        protected override global::Microsoft.LightSwitch.Internal.IDataServiceImplementation CreateDataServiceImplementation<TDataService>(TDataService dataService)
        {
            if (typeof(TDataService) == typeof(global::LightSwitchApplication.ApplicationData))
            {
                return new global::LightSwitchApplication.Implementation.ApplicationDataServiceImplementation(dataService);
            }
            if (typeof(TDataService) == typeof(global::LightSwitchApplication.PrescriptionContoso))
            {
                return new global::LightSwitchApplication.Implementation.PrescriptionContosoServiceImplementation(dataService);
            }
            return base.CreateDataServiceImplementation(dataService);
        }
    }
    #endregion
    
    [global::System.ComponentModel.Composition.PartCreationPolicy(global::System.ComponentModel.Composition.CreationPolicy.Shared)]
    [global::System.ComponentModel.Composition.Export(typeof(global::Microsoft.LightSwitch.Internal.ITypeMappingProvider))]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public class __TypeMapping
        : global::Microsoft.LightSwitch.Internal.ITypeMappingProvider
    {
        global::System.Type global::Microsoft.LightSwitch.Internal.ITypeMappingProvider.GetImplementationType(global::System.Type definitionType)
        {
            if (typeof(global::LightSwitchApplication.Patient) == definitionType)
            {
                return typeof(global::ApplicationData.Implementation.Patient);
            }
            if (typeof(global::LightSwitchApplication.Invoice) == definitionType)
            {
                return typeof(global::ApplicationData.Implementation.Invoice);
            }
            if (typeof(global::LightSwitchApplication.InvoiceDetail) == definitionType)
            {
                return typeof(global::ApplicationData.Implementation.InvoiceDetail);
            }
            if (typeof(global::LightSwitchApplication.Appointment) == definitionType)
            {
                return typeof(global::ApplicationData.Implementation.Appointment);
            }
            if (typeof(global::LightSwitchApplication.Product) == definitionType)
            {
                return typeof(global::PrescriptionContoso.Implementation.Product);
            }
            if (typeof(global::LightSwitchApplication.ProductRebate) == definitionType)
            {
                return typeof(global::PrescriptionContoso.Implementation.ProductRebate);
            }
            return null;
        }
    }
}

namespace ApplicationData.Implementation
{

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public partial class Patient :
        global::LightSwitchApplication.Patient.DetailsClass.IImplementation
    {
    
        global::System.Collections.IEnumerable global::LightSwitchApplication.Patient.DetailsClass.IImplementation.Invoices
        {
            get
            {
                return this.Invoices;
            }
        }
        
        global::System.Collections.IEnumerable global::LightSwitchApplication.Patient.DetailsClass.IImplementation.Appointments
        {
            get
            {
                return this.Appointments;
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.DataAnnotations.MetadataType(typeof(global::ApplicationData.Implementation.Invoice.Metadata))]
    public partial class Invoice :
        global::LightSwitchApplication.Invoice.DetailsClass.IImplementation
    {
    
        global::Microsoft.LightSwitch.Internal.IEntityImplementation global::LightSwitchApplication.Invoice.DetailsClass.IImplementation.Patient
        {
            get
            {
                return this.Patient;
            }
            set
            {
                this.Patient = (global::ApplicationData.Implementation.Patient)value;
                if (this.__host != null)
                {
                    this.__host.RaisePropertyChanged("Patient");
                }
            }
        }
        
        global::System.Collections.IEnumerable global::LightSwitchApplication.Invoice.DetailsClass.IImplementation.InvoiceDetails
        {
            get
            {
                return this.InvoiceDetails;
            }
        }
        
        partial void OnInvoice_PatientChanged()
        {
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged("Patient");
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
        
        internal class Metadata
        {
            [global::System.ServiceModel.DomainServices.Server.Include]
            public global::ApplicationData.Implementation.Patient Patient { get; set; }
        
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.DataAnnotations.MetadataType(typeof(global::ApplicationData.Implementation.InvoiceDetail.Metadata))]
    public partial class InvoiceDetail :
        global::LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation
    {
    
        global::Microsoft.LightSwitch.Internal.IEntityImplementation global::LightSwitchApplication.InvoiceDetail.DetailsClass.IImplementation.Invoice
        {
            get
            {
                return this.Invoice;
            }
            set
            {
                this.Invoice = (global::ApplicationData.Implementation.Invoice)value;
                if (this.__host != null)
                {
                    this.__host.RaisePropertyChanged("Invoice");
                }
            }
        }
        
        partial void OnInvoice_InvoiceDetailChanged()
        {
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged("Invoice");
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
        
        internal class Metadata
        {
            [global::System.ServiceModel.DomainServices.Server.Include]
            public global::ApplicationData.Implementation.Invoice Invoice { get; set; }
        
        }
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.DataAnnotations.MetadataType(typeof(global::ApplicationData.Implementation.Appointment.Metadata))]
    public partial class Appointment :
        global::LightSwitchApplication.Appointment.DetailsClass.IImplementation
    {
    
        global::Microsoft.LightSwitch.Internal.IEntityImplementation global::LightSwitchApplication.Appointment.DetailsClass.IImplementation.Patient
        {
            get
            {
                return this.Patient;
            }
            set
            {
                this.Patient = (global::ApplicationData.Implementation.Patient)value;
                if (this.__host != null)
                {
                    this.__host.RaisePropertyChanged("Patient");
                }
            }
        }
        
        partial void OnAppointment_PatientChanged()
        {
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged("Patient");
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
        
        internal class Metadata
        {
            [global::System.ServiceModel.DomainServices.Server.Include]
            public global::ApplicationData.Implementation.Patient Patient { get; set; }
        
        }
    }
    
}

namespace PrescriptionContoso.Implementation
{

    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    public partial class Product :
        global::LightSwitchApplication.Product.DetailsClass.IImplementation
    {
    
        global::System.Collections.IEnumerable global::LightSwitchApplication.Product.DetailsClass.IImplementation.ProductRebates
        {
            get
            {
                return this.ProductRebates;
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
    }
    
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.LightSwitch.BuildTasks.CodeGen", "11.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.ComponentModel.DataAnnotations.MetadataType(typeof(global::PrescriptionContoso.Implementation.ProductRebate.Metadata))]
    public partial class ProductRebate :
        global::LightSwitchApplication.ProductRebate.DetailsClass.IImplementation
    {
    
        global::Microsoft.LightSwitch.Internal.IEntityImplementation global::LightSwitchApplication.ProductRebate.DetailsClass.IImplementation.Product
        {
            get
            {
                return this.Product;
            }
            set
            {
                this.Product = (global::PrescriptionContoso.Implementation.Product)value;
                if (this.__host != null)
                {
                    this.__host.RaisePropertyChanged("Product");
                }
            }
        }
        
        partial void OnProductIDChanged()
        {
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged("Product");
            }
        }
        
        #region IEntityImplementation Members
        private global::Microsoft.LightSwitch.Internal.IEntityImplementationHost __host;
        
        global::Microsoft.LightSwitch.Internal.IEntityImplementationHost global::Microsoft.LightSwitch.Internal.IEntityImplementation.Host
        {
            get
            {
                return this.__host;
            }
        }
        
        void global::Microsoft.LightSwitch.Internal.IEntityImplementation.Initialize(global::Microsoft.LightSwitch.Internal.IEntityImplementationHost host)
        {
            this.__host = host;
        }
        
        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);
            if (this.__host != null)
            {
                this.__host.RaisePropertyChanged(propertyName);
            }
        }
        #endregion
        
        internal class Metadata
        {
            [global::System.ServiceModel.DomainServices.Server.Include]
            public global::PrescriptionContoso.Implementation.Product Product { get; set; }
        
        }
    }
    
}

