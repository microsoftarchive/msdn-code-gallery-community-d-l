namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.ColdRoomTemperatures_Archive")]
    public partial class ColdRoomTemperatures_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long ColdRoomTemperatureID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ColdRoomSensorNumber { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "datetime2")]
        public DateTime RecordedWhen { get; set; }

        [Key]
        [Column(Order = 3)]
        public decimal Temperature { get; set; }

        [Key]
        [Column(Order = 4, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
