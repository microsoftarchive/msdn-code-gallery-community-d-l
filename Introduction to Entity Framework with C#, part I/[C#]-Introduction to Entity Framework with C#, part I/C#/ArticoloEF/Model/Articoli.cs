namespace ArticoloEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articoli")]
    public partial class Articoli
    {
        [Key]
        public int IdArticolo { get; set; }

        [Required]
        [StringLength(25)]
        public string CodArt { get; set; }

        [Required]
        [StringLength(50)]
        public string DesArt { get; set; }

        [Required]
        [StringLength(6)]
        public string CodFamiglia { get; set; }

        [Required]
        public Decimal CostoStandard { get; set; }

        public virtual Famiglie Famiglie { get; set; }
    }
}
