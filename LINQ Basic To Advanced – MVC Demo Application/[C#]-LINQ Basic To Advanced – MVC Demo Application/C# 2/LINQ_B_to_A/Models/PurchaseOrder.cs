namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Purchasing.PurchaseOrders")]
    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            SupplierTransactions = new HashSet<SupplierTransaction>();
            StockItemTransactions = new HashSet<StockItemTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PurchaseOrderID { get; set; }

        public int SupplierID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public int DeliveryMethodID { get; set; }

        public int ContactPersonID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        [StringLength(20)]
        public string SupplierReference { get; set; }

        public bool IsOrderFinalized { get; set; }

        public string Comments { get; set; }

        public string InternalComments { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual DeliveryMethod DeliveryMethod { get; set; }

        public virtual Person Person { get; set; }

        public virtual Person Person1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        public virtual Supplier Supplier { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierTransaction> SupplierTransactions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItemTransaction> StockItemTransactions { get; set; }
    }
}
