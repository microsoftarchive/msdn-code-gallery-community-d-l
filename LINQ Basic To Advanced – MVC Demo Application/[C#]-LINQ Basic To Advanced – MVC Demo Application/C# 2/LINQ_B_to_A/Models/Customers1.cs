namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Website.Customers")]
    public partial class Customers1
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CustomerID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string CustomerName { get; set; }

        [StringLength(50)]
        public string CustomerCategoryName { get; set; }

        [StringLength(50)]
        public string PrimaryContact { get; set; }

        [StringLength(50)]
        public string AlternateContact { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string FaxNumber { get; set; }

        [StringLength(50)]
        public string BuyingGroupName { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(256)]
        public string WebsiteURL { get; set; }

        [StringLength(50)]
        public string DeliveryMethod { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public DbGeography DeliveryLocation { get; set; }

        [StringLength(5)]
        public string DeliveryRun { get; set; }

        [StringLength(5)]
        public string RunPosition { get; set; }
    }
}
