namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.SpecialDeals")]
    public partial class SpecialDeal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SpecialDealID { get; set; }

        public int? StockItemID { get; set; }

        public int? CustomerID { get; set; }

        public int? BuyingGroupID { get; set; }

        public int? CustomerCategoryID { get; set; }

        public int? StockGroupID { get; set; }

        [Required]
        [StringLength(30)]
        public string DealDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public decimal? DiscountAmount { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? UnitPrice { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual Person Person { get; set; }

        public virtual BuyingGroup BuyingGroup { get; set; }

        public virtual CustomerCategory CustomerCategory { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual StockGroup StockGroup { get; set; }

        public virtual StockItem StockItem { get; set; }
    }
}
