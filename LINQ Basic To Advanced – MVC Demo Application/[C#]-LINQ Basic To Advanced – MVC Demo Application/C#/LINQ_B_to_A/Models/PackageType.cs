namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.PackageTypes")]
    public partial class PackageType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PackageType()
        {
            PurchaseOrderLines = new HashSet<PurchaseOrderLine>();
            InvoiceLines = new HashSet<InvoiceLine>();
            OrderLines = new HashSet<OrderLine>();
            StockItems = new HashSet<StockItem>();
            StockItems1 = new HashSet<StockItem>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageTypeID { get; set; }

        [Required]
        [StringLength(50)]
        public string PackageTypeName { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceLine> InvoiceLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItem> StockItems { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockItem> StockItems1 { get; set; }
    }
}
