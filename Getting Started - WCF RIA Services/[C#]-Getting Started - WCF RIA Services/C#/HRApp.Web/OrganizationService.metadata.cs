
namespace HRApp.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // The MetadataTypeAttribute identifies EmployeeMetadata as the class
    // that carries additional metadata for the Employee class.
    [MetadataTypeAttribute(typeof(Employee.EmployeeMetadata))]
    public partial class Employee
    {

        // This class allows you to attach custom attributes to properties
        // of the Employee class.
        //
        // For example, the following marks the Xyz property as a
        // required property and specifies the format for valid values:
        //    [Required]
        //    [RegularExpression("[A-Z][A-Za-z0-9]*")]
        //    [StringLength(32)]
        //    public string Xyz { get; set; }
        internal sealed class EmployeeMetadata
        {

            // Metadata classes are not meant to be instantiated.
            private EmployeeMetadata()
            {
            }

            public DateTime BirthDate { get; set; }

            public int ContactID { get; set; }

            public bool CurrentFlag { get; set; }

            public EntityCollection<Employee> Employee1 { get; set; }

            public Employee Employee2 { get; set; }

            public int EmployeeID { get; set; }

            [Required]
            [CustomValidation(typeof(HRApp.Web.GenderValidator), "IsGenderValid")]
            public string Gender { get; set; }

            public DateTime HireDate { get; set; }

            public string LoginID { get; set; }

            public Nullable<int> ManagerID { get; set; }

            public string MaritalStatus { get; set; }

            public DateTime ModifiedDate { get; set; }

            public string NationalIDNumber { get; set; }

            public Guid rowguid { get; set; }

            public bool SalariedFlag { get; set; }

            public short SickLeaveHours { get; set; }

            public string Title { get; set; }

            [Range(0, 70)]
            public short VacationHours { get; set; }
        }
    }
}
