namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application.Countries")]
    public partial class Country
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Country()
        {
            StateProvinces = new HashSet<StateProvince>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CountryID { get; set; }

        [Required]
        [StringLength(60)]
        public string CountryName { get; set; }

        [Required]
        [StringLength(60)]
        public string FormalName { get; set; }

        [StringLength(3)]
        public string IsoAlpha3Code { get; set; }

        public int? IsoNumericCode { get; set; }

        [StringLength(20)]
        public string CountryType { get; set; }

        public long? LatestRecordedPopulation { get; set; }

        [Required]
        [StringLength(30)]
        public string Continent { get; set; }

        [Required]
        [StringLength(30)]
        public string Region { get; set; }

        [Required]
        [StringLength(30)]
        public string Subregion { get; set; }

        public DbGeography Border { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StateProvince> StateProvinces { get; set; }
    }
}
