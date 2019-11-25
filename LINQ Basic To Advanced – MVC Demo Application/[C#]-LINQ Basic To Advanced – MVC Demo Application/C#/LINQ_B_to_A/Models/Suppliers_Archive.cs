namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchasing.Suppliers_Archive")]
    public partial class Suppliers_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string SupplierName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierCategoryID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrimaryContactPersonID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlternateContactPersonID { get; set; }

        public int? DeliveryMethodID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryCityID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostalCityID { get; set; }

        [StringLength(20)]
        public string SupplierReference { get; set; }

        [StringLength(50)]
        public string BankAccountName { get; set; }

        [StringLength(50)]
        public string BankAccountBranch { get; set; }

        [StringLength(20)]
        public string BankAccountCode { get; set; }

        [StringLength(20)]
        public string BankAccountNumber { get; set; }

        [StringLength(20)]
        public string BankInternationalCode { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentDays { get; set; }

        public string InternalComments { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(256)]
        public string WebsiteURL { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }

        public DbGeography DeliveryLocation { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }

        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }

        [Key]
        [Column(Order = 15)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 16, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 17, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
