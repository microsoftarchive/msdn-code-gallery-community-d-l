namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.OrderLines")]
    public partial class OrderLine
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderLineID { get; set; }

        public int OrderID { get; set; }

        public int StockItemID { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public int PackageTypeID { get; set; }

        public int Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal TaxRate { get; set; }

        public int PickedQuantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PickingCompletedWhen { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual Order Order { get; set; }

        public virtual PackageType PackageType { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
