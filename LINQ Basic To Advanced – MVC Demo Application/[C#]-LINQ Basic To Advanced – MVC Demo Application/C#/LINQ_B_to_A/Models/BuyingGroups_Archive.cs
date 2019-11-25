namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.BuyingGroups_Archive")]
    public partial class BuyingGroups_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BuyingGroupID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BuyingGroupName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
