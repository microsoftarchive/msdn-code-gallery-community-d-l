namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Warehouse.VehicleTemperatures")]
    public partial class VehicleTemperature
    {
        public long VehicleTemperatureID { get; set; }

        [Required]
        [StringLength(20)]
        public string VehicleRegistration { get; set; }

        public int ChillerSensorNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime RecordedWhen { get; set; }

        public decimal Temperature { get; set; }

        public bool IsCompressed { get; set; }

        [StringLength(1000)]
        public string FullSensorData { get; set; }

        public byte[] CompressedSensorData { get; set; }
    }
}
