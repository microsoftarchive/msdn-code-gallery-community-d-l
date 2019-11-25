namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application.SystemParameters")]
    public partial class SystemParameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SystemParameterID { get; set; }

        [Required]
        [StringLength(60)]
        public string DeliveryAddressLine1 { get; set; }

        [StringLength(60)]
        public string DeliveryAddressLine2 { get; set; }

        public int DeliveryCityID { get; set; }

        [Required]
        [StringLength(10)]
        public string DeliveryPostalCode { get; set; }

        [Required]
        public DbGeography DeliveryLocation { get; set; }

        [Required]
        [StringLength(60)]
        public string PostalAddressLine1 { get; set; }

        [StringLength(60)]
        public string PostalAddressLine2 { get; set; }

        public int PostalCityID { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalPostalCode { get; set; }

        [Required]
        public string ApplicationSettings { get; set; }

        public int LastEditedBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime LastEditedWhen { get; set; }

        public virtual City City { get; set; }

        public virtual City City1 { get; set; }

        public virtual Person Person { get; set; }
    }
}
