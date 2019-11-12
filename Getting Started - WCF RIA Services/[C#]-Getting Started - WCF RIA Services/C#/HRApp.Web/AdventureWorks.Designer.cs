﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(HRApp.Web.Employee), "Employee1", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(HRApp.Web.Employee), true)]

#endregion

namespace HRApp.Web
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class AdventureWorks_DataEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new AdventureWorks_DataEntities object using the connection string found in the 'AdventureWorks_DataEntities' section of the application configuration file.
        /// </summary>
        public AdventureWorks_DataEntities() : base("name=AdventureWorks_DataEntities", "AdventureWorks_DataEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AdventureWorks_DataEntities object.
        /// </summary>
        public AdventureWorks_DataEntities(string connectionString) : base(connectionString, "AdventureWorks_DataEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new AdventureWorks_DataEntities object.
        /// </summary>
        public AdventureWorks_DataEntities(EntityConnection connection) : base(connection, "AdventureWorks_DataEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Employee> Employees
        {
            get
            {
                if ((_Employees == null))
                {
                    _Employees = base.CreateObjectSet<Employee>("Employees");
                }
                return _Employees;
            }
        }
        private ObjectSet<Employee> _Employees;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Employees EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToEmployees(Employee employee)
        {
            base.AddObject("Employees", employee);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="AdventureWorks_DataModel", Name="Employee")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Employee : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Employee object.
        /// </summary>
        /// <param name="employeeID">Initial value of the EmployeeID property.</param>
        /// <param name="nationalIDNumber">Initial value of the NationalIDNumber property.</param>
        /// <param name="contactID">Initial value of the ContactID property.</param>
        /// <param name="loginID">Initial value of the LoginID property.</param>
        /// <param name="title">Initial value of the Title property.</param>
        /// <param name="birthDate">Initial value of the BirthDate property.</param>
        /// <param name="maritalStatus">Initial value of the MaritalStatus property.</param>
        /// <param name="gender">Initial value of the Gender property.</param>
        /// <param name="hireDate">Initial value of the HireDate property.</param>
        /// <param name="salariedFlag">Initial value of the SalariedFlag property.</param>
        /// <param name="vacationHours">Initial value of the VacationHours property.</param>
        /// <param name="sickLeaveHours">Initial value of the SickLeaveHours property.</param>
        /// <param name="currentFlag">Initial value of the CurrentFlag property.</param>
        /// <param name="rowguid">Initial value of the rowguid property.</param>
        /// <param name="modifiedDate">Initial value of the ModifiedDate property.</param>
        public static Employee CreateEmployee(global::System.Int32 employeeID, global::System.String nationalIDNumber, global::System.Int32 contactID, global::System.String loginID, global::System.String title, global::System.DateTime birthDate, global::System.String maritalStatus, global::System.String gender, global::System.DateTime hireDate, global::System.Boolean salariedFlag, global::System.Int16 vacationHours, global::System.Int16 sickLeaveHours, global::System.Boolean currentFlag, global::System.Guid rowguid, global::System.DateTime modifiedDate)
        {
            Employee employee = new Employee();
            employee.EmployeeID = employeeID;
            employee.NationalIDNumber = nationalIDNumber;
            employee.ContactID = contactID;
            employee.LoginID = loginID;
            employee.Title = title;
            employee.BirthDate = birthDate;
            employee.MaritalStatus = maritalStatus;
            employee.Gender = gender;
            employee.HireDate = hireDate;
            employee.SalariedFlag = salariedFlag;
            employee.VacationHours = vacationHours;
            employee.SickLeaveHours = sickLeaveHours;
            employee.CurrentFlag = currentFlag;
            employee.rowguid = rowguid;
            employee.ModifiedDate = modifiedDate;
            return employee;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                if (_EmployeeID != value)
                {
                    OnEmployeeIDChanging(value);
                    ReportPropertyChanging("EmployeeID");
                    _EmployeeID = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("EmployeeID");
                    OnEmployeeIDChanged();
                }
            }
        }
        private global::System.Int32 _EmployeeID;
        partial void OnEmployeeIDChanging(global::System.Int32 value);
        partial void OnEmployeeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String NationalIDNumber
        {
            get
            {
                return _NationalIDNumber;
            }
            set
            {
                OnNationalIDNumberChanging(value);
                ReportPropertyChanging("NationalIDNumber");
                _NationalIDNumber = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("NationalIDNumber");
                OnNationalIDNumberChanged();
            }
        }
        private global::System.String _NationalIDNumber;
        partial void OnNationalIDNumberChanging(global::System.String value);
        partial void OnNationalIDNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                OnContactIDChanging(value);
                ReportPropertyChanging("ContactID");
                _ContactID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ContactID");
                OnContactIDChanged();
            }
        }
        private global::System.Int32 _ContactID;
        partial void OnContactIDChanging(global::System.Int32 value);
        partial void OnContactIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String LoginID
        {
            get
            {
                return _LoginID;
            }
            set
            {
                OnLoginIDChanging(value);
                ReportPropertyChanging("LoginID");
                _LoginID = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("LoginID");
                OnLoginIDChanged();
            }
        }
        private global::System.String _LoginID;
        partial void OnLoginIDChanging(global::System.String value);
        partial void OnLoginIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ManagerID
        {
            get
            {
                return _ManagerID;
            }
            set
            {
                OnManagerIDChanging(value);
                ReportPropertyChanging("ManagerID");
                _ManagerID = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ManagerID");
                OnManagerIDChanged();
            }
        }
        private Nullable<global::System.Int32> _ManagerID;
        partial void OnManagerIDChanging(Nullable<global::System.Int32> value);
        partial void OnManagerIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Title
        {
            get
            {
                return _Title;
            }
            set
            {
                OnTitleChanging(value);
                ReportPropertyChanging("Title");
                _Title = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Title");
                OnTitleChanged();
            }
        }
        private global::System.String _Title;
        partial void OnTitleChanging(global::System.String value);
        partial void OnTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                OnBirthDateChanging(value);
                ReportPropertyChanging("BirthDate");
                _BirthDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BirthDate");
                OnBirthDateChanged();
            }
        }
        private global::System.DateTime _BirthDate;
        partial void OnBirthDateChanging(global::System.DateTime value);
        partial void OnBirthDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String MaritalStatus
        {
            get
            {
                return _MaritalStatus;
            }
            set
            {
                OnMaritalStatusChanging(value);
                ReportPropertyChanging("MaritalStatus");
                _MaritalStatus = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("MaritalStatus");
                OnMaritalStatusChanged();
            }
        }
        private global::System.String _MaritalStatus;
        partial void OnMaritalStatusChanging(global::System.String value);
        partial void OnMaritalStatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                OnGenderChanging(value);
                ReportPropertyChanging("Gender");
                _Gender = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Gender");
                OnGenderChanged();
            }
        }
        private global::System.String _Gender;
        partial void OnGenderChanging(global::System.String value);
        partial void OnGenderChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime HireDate
        {
            get
            {
                return _HireDate;
            }
            set
            {
                OnHireDateChanging(value);
                ReportPropertyChanging("HireDate");
                _HireDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("HireDate");
                OnHireDateChanged();
            }
        }
        private global::System.DateTime _HireDate;
        partial void OnHireDateChanging(global::System.DateTime value);
        partial void OnHireDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean SalariedFlag
        {
            get
            {
                return _SalariedFlag;
            }
            set
            {
                OnSalariedFlagChanging(value);
                ReportPropertyChanging("SalariedFlag");
                _SalariedFlag = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SalariedFlag");
                OnSalariedFlagChanged();
            }
        }
        private global::System.Boolean _SalariedFlag;
        partial void OnSalariedFlagChanging(global::System.Boolean value);
        partial void OnSalariedFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 VacationHours
        {
            get
            {
                return _VacationHours;
            }
            set
            {
                OnVacationHoursChanging(value);
                ReportPropertyChanging("VacationHours");
                _VacationHours = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("VacationHours");
                OnVacationHoursChanged();
            }
        }
        private global::System.Int16 _VacationHours;
        partial void OnVacationHoursChanging(global::System.Int16 value);
        partial void OnVacationHoursChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int16 SickLeaveHours
        {
            get
            {
                return _SickLeaveHours;
            }
            set
            {
                OnSickLeaveHoursChanging(value);
                ReportPropertyChanging("SickLeaveHours");
                _SickLeaveHours = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SickLeaveHours");
                OnSickLeaveHoursChanged();
            }
        }
        private global::System.Int16 _SickLeaveHours;
        partial void OnSickLeaveHoursChanging(global::System.Int16 value);
        partial void OnSickLeaveHoursChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean CurrentFlag
        {
            get
            {
                return _CurrentFlag;
            }
            set
            {
                OnCurrentFlagChanging(value);
                ReportPropertyChanging("CurrentFlag");
                _CurrentFlag = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("CurrentFlag");
                OnCurrentFlagChanged();
            }
        }
        private global::System.Boolean _CurrentFlag;
        partial void OnCurrentFlagChanging(global::System.Boolean value);
        partial void OnCurrentFlagChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Guid rowguid
        {
            get
            {
                return _rowguid;
            }
            set
            {
                OnrowguidChanging(value);
                ReportPropertyChanging("rowguid");
                _rowguid = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("rowguid");
                OnrowguidChanged();
            }
        }
        private global::System.Guid _rowguid;
        partial void OnrowguidChanging(global::System.Guid value);
        partial void OnrowguidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime ModifiedDate
        {
            get
            {
                return _ModifiedDate;
            }
            set
            {
                OnModifiedDateChanging(value);
                ReportPropertyChanging("ModifiedDate");
                _ModifiedDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("ModifiedDate");
                OnModifiedDateChanged();
            }
        }
        private global::System.DateTime _ModifiedDate;
        partial void OnModifiedDateChanging(global::System.DateTime value);
        partial void OnModifiedDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee1")]
        public EntityCollection<Employee> Employee1
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee1");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee1", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("AdventureWorks_DataModel", "FK_Employee_Employee_ManagerID", "Employee")]
        public Employee Employee2
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Employee> Employee2Reference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Employee>("AdventureWorks_DataModel.FK_Employee_Employee_ManagerID", "Employee", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
