namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Website.VehicleTemperatures")]
    public partial class VehicleTemperatures1
    {
        [Key]
        [Column(Order = 0)]
        public long VehicleTemperatureID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string VehicleRegistration { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ChillerSensorNumber { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime RecordedWhen { get; set; }

        [Key]
        [Column(Order = 4)]
        public decimal Temperature { get; set; }

        [StringLength(1000)]
        public string FullSensorData { get; set; }
    }
}
