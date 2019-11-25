namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Invoices")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            CustomerTransactions = new HashSet<CustomerTransaction>();
            InvoiceLines = new HashSet<InvoiceLine>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int InvoiceID { get; set; }

        public int CustomerID { get; set; }

        public int BillToCustomerID { get; set; }

        public int? OrderID { get; set; }

        public int DeliveryMethodID { get; set; }

        public int ContactPersonID { get; set; }

        public int AccountsPersonID { get; set; }

        public int SalespersonPersonID { get; set; }

        public int PackedByPersonID { get; set; }

        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }

        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }

        public bool IsCreditNote { get; set; }

        public string CreditNoteReason { get; set; }

        public string Comments { get; set; }

        public string DeliveryInstructions { get; set; }

        public string InternalComments { get; set; }

        public int TotalDryItems { get; set; }

        public int TotalChillerItems { get; set; }

        [StringLength(5)]
        public string DeliveryRun { get; set; }

        [StringLength(5)]
        public string RunPosition { get; set; }

        public string ReturnedDeliveryData { get; set; }

        [Column(TypeName = "datetime2")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ConfirmedDeliveryTime { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(4000)]
        public string ConfirmedReceivedBy { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public virtual Person Person { get; set; }

        public virtual Person Person1 { get; set; }

        public virtual Person Person2 { get; set; }

        public virtual Person Person3 { get; set; }

        public virtual Person Person4 { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Customer Customer1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerTransaction> CustomerTransactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        public virtual Order Order { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
