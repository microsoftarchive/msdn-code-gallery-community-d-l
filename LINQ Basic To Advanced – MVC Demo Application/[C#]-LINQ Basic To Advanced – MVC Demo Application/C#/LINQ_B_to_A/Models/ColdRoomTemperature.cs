namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.ColdRoomTemperatures")]
    public partial class ColdRoomTemperature
    {
        public long ColdRoomTemperatureID { get; set; }

        public int ColdRoomSensorNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RecordedWhen { get; set; }

        public decimal Temperature { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
