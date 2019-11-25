namespace LINQ_B_to_A.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Application.People_Archive")]
    public partial class People_Archive
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FullName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string PreferredName { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(101)]
        public string SearchName { get; set; }

        [Key]
        [Column(Order = 4)]
        public bool IsPermittedToLogon { get; set; }

        [StringLength(50)]
        public string LogonName { get; set; }

        [Key]
        [Column(Order = 5)]
        public bool IsExternalLogonProvider { get; set; }

        public byte[] HashedPassword { get; set; }

        [Key]
        [Column(Order = 6)]
        public bool IsSystemUser { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool IsEmployee { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool IsSalesperson { get; set; }

        public string UserPreferences { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string FaxNumber { get; set; }

        [StringLength(256)]
        public string EmailAddress { get; set; }

        public byte[] Photo { get; set; }

        public string CustomFields { get; set; }

        public string OtherLanguages { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LastEditedBy { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
