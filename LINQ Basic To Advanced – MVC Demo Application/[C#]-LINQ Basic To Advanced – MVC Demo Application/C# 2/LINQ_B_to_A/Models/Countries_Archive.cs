namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application.Countries_Archive")]
    public partial class Countries_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(60)]
        public string CountryName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(60)]
        public string FormalName { get; set; }

        [StringLength(3)]
        public string IsoAlpha3Code { get; set; }

        public int? IsoNumericCode { get; set; }

        [StringLength(20)]
        public string CountryType { get; set; }

        public long? LatestRecordedPopulation { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string Continent { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string Region { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(30)]
        public string Subregion { get; set; }

        public DbGeography Border { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
