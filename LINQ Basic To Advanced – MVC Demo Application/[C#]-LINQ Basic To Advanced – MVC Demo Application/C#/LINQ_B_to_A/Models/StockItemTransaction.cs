namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.StockItemTransactions")]
    public partial class StockItemTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemTransactionID { get; set; }

        public int StockItemID { get; set; }

        public int TransactionTypeID { get; set; }

        public int? CustomerID { get; set; }

        public int? InvoiceID { get; set; }

        public int? SupplierID { get; set; }

        public int? PurchaseOrderID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TransactionOccurredWhen { get; set; }

        public decimal Quantity { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual TransactionType TransactionType { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
