namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application.StateProvinces_Archive")]
    public partial class StateProvinces_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StateProvinceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string StateProvinceCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string StateProvinceName { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string SalesTerritory { get; set; }

        public DbGeography Border { get; set; }

        public long? LatestRecordedPopulation { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
