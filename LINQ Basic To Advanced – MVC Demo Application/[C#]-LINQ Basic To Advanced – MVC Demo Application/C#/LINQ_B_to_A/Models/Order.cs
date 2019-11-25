namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.Orders")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Invoices = new HashSet<Invoice>();
            OrderLines = new HashSet<OrderLine>();
            Orders1 = new HashSet<Order>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public int SalespersonPersonID { get; set; }

        public int? PickedByPersonID { get; set; }

        public int ContactPersonID { get; set; }

        public int? BackorderOrderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ExpectedDeliveryDate { get; set; }

        [StringLength(20)]
        public string CustomerPurchaseOrderNumber { get; set; }

        public bool IsUndersupplyBackordered { get; set; }

        public string Comments { get; set; }

        public string DeliveryInstructions { get; set; }

        public string InternalComments { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PickingCompletedWhen { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual Person Person1 { get; set; }

        public virtual Person Person2 { get; set; }

        public virtual Person Person3 { get; set; }

        public virtual Customer Customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders1 { get; set; }

        public virtual Order Order1 { get; set; }
    }
}
