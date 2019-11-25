namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchasing.SupplierTransactions")]
    public partial class SupplierTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierTransactionID { get; set; }

        public int SupplierID { get; set; }

        public int TransactionTypeID { get; set; }

        public int? PurchaseOrderID { get; set; }

        public int? PaymentMethodID { get; set; }

        [StringLength(20)]
        public string SupplierInvoiceNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime TransactionDate { get; set; }

        public decimal AmountExcludingTax { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TransactionAmount { get; set; }

        public decimal OutstandingBalance { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FinalizationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public bool? IsFinalized { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual Person Person { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
