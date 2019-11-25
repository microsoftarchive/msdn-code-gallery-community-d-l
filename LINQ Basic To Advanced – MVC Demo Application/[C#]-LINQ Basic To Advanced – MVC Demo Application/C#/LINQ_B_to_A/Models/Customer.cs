namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Customers")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Customers1 = new HashSet<Customer>();
            CustomerTransactions = new HashSet<CustomerTransaction>();
            Invoices = new HashSet<Invoice>();
            Invoices1 = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
            SpecialDeals = new HashSet<SpecialDeal>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; }

        public int BillToCustomerID { get; set; }

        public int CustomerCategoryID { get; set; }

        public int? BuyingGroupID { get; set; }

        public int PrimaryContactPersonID { get; set; }

        public int? AlternateContactPersonID { get; set; }

        public int DeliveryMethodID { get; set; }

        public int DeliveryCityID { get; set; }

        public int PostalCityID { get; set; }

        public decimal? CreditLimit { get; set; }

        [Column(TypeName = "date")]
        public DateTime AccountOpenedDate { get; set; }

        public decimal StandardDiscountPercentage { get; set; }

        public bool IsStatementSent { get; set; }

        public bool IsOnCreditHold { get; set; }

        public int PaymentDays { get; set; }

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        [StringLength(5)]
        public string DeliveryRun { get; set; }

        [StringLength(5)]
        public string RunPosition { get; set; }

        [Required]
        [StringLength(256)]
        public string WebsiteURL { get; set; }

        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }

        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }

        public DbGeography DeliveryLocation { get; set; }

        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }

        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }

        public virtual City City { get; set; }

        public virtual City City1 { get; set; }

        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public virtual Person Person { get; set; }

        public virtual Person Person1 { get; set; }

        public virtual Person Person2 { get; set; }

        public virtual BuyingGroup BuyingGroup { get; set; }

        public virtual CustomerCategory CustomerCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers1 { get; set; }

        public virtual Customer Customer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpecialDeal> SpecialDeals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
