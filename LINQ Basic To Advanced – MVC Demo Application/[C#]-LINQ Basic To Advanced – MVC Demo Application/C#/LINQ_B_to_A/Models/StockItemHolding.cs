namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.StockItemHoldings")]
    public partial class StockItemHolding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemID { get; set; }

        public int QuantityOnHand { get; set; }

        [Required]
        [StringLength(20)]
        public string BinLocation { get; set; }

        public int LastStocktakeQuantity { get; set; }

        public decimal LastCostPrice { get; set; }

        public int ReorderLevel { get; set; }

        public int TargetStockLevel { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
