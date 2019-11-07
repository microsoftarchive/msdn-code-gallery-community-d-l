// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// ----------------------------------------------------------------------------

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;

namespace AzureMobile.Samples.FieldEngineer.Service.Models
{
    public partial class MobileServiceContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";
        public string Schema { get; set; }

        public MobileServiceContext()
            : base(connectionStringName)
        {
            this.Schema = ServiceSettingsDictionary.GetSchemaName();
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobHistory> JobHistories { get; set; }
        public virtual DbSet<EquipmentSpecification> EquipmentSpecifications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (!string.IsNullOrEmpty(this.Schema))
            {
                modelBuilder.HasDefaultSchema(this.Schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));

            modelBuilder.Entity<EquipmentSpecification>().HasKey(es => es.Id);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Equipment>()
                .HasMany(e => e.Jobs)
                .WithMany(j => j.Equipments)
                .Map(t => t.MapLeftKey("EquipmentId")
                    .MapRightKey("JobId")
                    .ToTable("EquipmentIds"));
        }
    }
}
