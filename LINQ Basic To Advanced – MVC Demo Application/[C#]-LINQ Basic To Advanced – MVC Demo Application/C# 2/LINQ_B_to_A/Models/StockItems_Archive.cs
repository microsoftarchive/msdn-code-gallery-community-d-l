namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.StockItems_Archive")]
    public partial class StockItems_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StockItemID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string StockItemName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SupplierID { get; set; }

        public int? ColorID { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UnitPackageID { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OuterPackageID { get; set; }

        [StringLength(50)]
        public string Brand { get; set; }

        [StringLength(20)]
        public string Size { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LeadTimeDays { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int QuantityPerOuter { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool IsChillerStock { get; set; }

        [StringLength(50)]
        public string Barcode { get; set; }

        [Key]
        [Column(Order = 8)]
        public decimal TaxRate { get; set; }

        [Key]
        [Column(Order = 9)]
        public decimal UnitPrice { get; set; }

        public decimal? RecommendedRetailPrice { get; set; }

        [Key]
        [Column(Order = 10)]
        public decimal TypicalWeightPerUnit { get; set; }

        public string MarketingComments { get; set; }

        public string InternalComments { get; set; }

        public byte[] Photo { get; set; }

        public string CustomFields { get; set; }

        public string Tags { get; set; }

        [Key]
        [Column(Order = 11)]
        public string SearchDetails { get; set; }

        [Key]
        [Column(Order = 12)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 14, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
