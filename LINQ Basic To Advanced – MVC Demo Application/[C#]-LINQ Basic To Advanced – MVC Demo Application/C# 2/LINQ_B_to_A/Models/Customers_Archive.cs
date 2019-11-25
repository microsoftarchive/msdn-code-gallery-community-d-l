namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Customers_Archive")]
    public partial class Customers_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BillToCustomerID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerCategoryID { get; set; }

        public int? BuyingGroupID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PrimaryContactPersonID { get; set; }

        public int? AlternateContactPersonID { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryMethodID { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeliveryCityID { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostalCityID { get; set; }

        public decimal? CreditLimit { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "date")]
        public DateTime AccountOpenedDate { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal StandardDiscountPercentage { get; set; }

        [Key]
        [Column(Order = 10)]
        public bool IsStatementSent { get; set; }

        [Key]
        [Column(Order = 11)]
        public bool IsOnCreditHold { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentDays { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        [StringLength(5)]
        public string DeliveryRun { get; set; }

        [StringLength(5)]
        public string RunPosition { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(256)]
        public string WebsiteURL { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }

        public DbGeography DeliveryLocation { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }

        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }

        [Key]
        [Column(Order = 20)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 21, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 22, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
