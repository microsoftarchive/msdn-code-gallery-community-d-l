namespace ArticoloEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Famiglie")]
    public partial class Famiglie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Famiglie()
        {
            Articoli = new HashSet<Articoli>();
        }

        [Key]
        [StringLength(6)]
        public string CodFamiglia { get; set; }

        [Required]
        [StringLength(50)]
        public string DesFamiglia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Articoli> Articoli { get; set; }
    }
}
