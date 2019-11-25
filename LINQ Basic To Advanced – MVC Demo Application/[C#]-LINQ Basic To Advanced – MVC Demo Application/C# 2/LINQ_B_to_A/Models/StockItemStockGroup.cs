namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.StockItemStockGroups")]
    public partial class StockItemStockGroup
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemStockGroupID { get; set; }

        public int StockItemID { get; set; }

        public int StockGroupID { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual StockGroup StockGroup { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
