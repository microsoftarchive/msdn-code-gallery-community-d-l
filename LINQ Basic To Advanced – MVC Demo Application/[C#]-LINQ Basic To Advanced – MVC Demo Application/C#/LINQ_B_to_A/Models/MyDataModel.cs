namespace LINQ_B_to_A.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDataModel : DbContext
    {
        public MyDataModel()
            : base("name=MyDataModel")
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<StateProvince> StateProvinces { get; set; }
        public virtual DbSet<SystemParameter> SystemParameters { get; set; }
        public virtual DbSet<TransactionType> TransactionTypes { get; set; }
        public virtual DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<SupplierCategory> SupplierCategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierTransaction> SupplierTransactions { get; set; }
        public virtual DbSet<BuyingGroup> BuyingGroups { get; set; }
        public virtual DbSet<CustomerCategory> CustomerCategories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerTransaction> CustomerTransactions { get; set; }
        public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<SpecialDeal> SpecialDeals { get; set; }
        public virtual DbSet<ColdRoomTemperature> ColdRoomTemperatures { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<StockGroup> StockGroups { get; set; }
        public virtual DbSet<StockItemHolding> StockItemHoldings { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<StockItemStockGroup> StockItemStockGroups { get; set; }
        public virtual DbSet<StockItemTransaction> StockItemTransactions { get; set; }
        public virtual DbSet<VehicleTemperature> VehicleTemperatures { get; set; }
        public virtual DbSet<Cities_Archive> Cities_Archive { get; set; }
        public virtual DbSet<Countries_Archive> Countries_Archive { get; set; }
        public virtual DbSet<DeliveryMethods_Archive> DeliveryMethods_Archive { get; set; }
        public virtual DbSet<PaymentMethods_Archive> PaymentMethods_Archive { get; set; }
        public virtual DbSet<People_Archive> People_Archive { get; set; }
        public virtual DbSet<StateProvinces_Archive> StateProvinces_Archive { get; set; }
        public virtual DbSet<TransactionTypes_Archive> TransactionTypes_Archive { get; set; }
        public virtual DbSet<SupplierCategories_Archive> SupplierCategories_Archive { get; set; }
        public virtual DbSet<Suppliers_Archive> Suppliers_Archive { get; set; }
        public virtual DbSet<BuyingGroups_Archive> BuyingGroups_Archive { get; set; }
        public virtual DbSet<CustomerCategories_Archive> CustomerCategories_Archive { get; set; }
        public virtual DbSet<Customers_Archive> Customers_Archive { get; set; }
        public virtual DbSet<ColdRoomTemperatures_Archive> ColdRoomTemperatures_Archive { get; set; }
        public virtual DbSet<Colors_Archive> Colors_Archive { get; set; }
        public virtual DbSet<PackageTypes_Archive> PackageTypes_Archive { get; set; }
        public virtual DbSet<StockGroups_Archive> StockGroups_Archive { get; set; }
        public virtual DbSet<StockItems_Archive> StockItems_Archive { get; set; }
        public virtual DbSet<Customers1> Customers1 { get; set; }
        public virtual DbSet<Suppliers1> Suppliers1 { get; set; }
        public virtual DbSet<VehicleTemperatures1> VehicleTemperatures1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasMany(e => e.SystemParameters)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.DeliveryCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.SystemParameters1)
                .WithRequired(e => e.City1)
                .HasForeignKey(e => e.PostalCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.DeliveryCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Suppliers1)
                .WithRequired(e => e.City1)
                .HasForeignKey(e => e.PostalCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.DeliveryCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers1)
                .WithRequired(e => e.City1)
                .HasForeignKey(e => e.PostalCityID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.StateProvinces)
                .WithRequired(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryMethod>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.DeliveryMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryMethod>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.DeliveryMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeliveryMethod>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.DeliveryMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Countries)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.DeliveryMethods)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PaymentMethods)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.People1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.LastEditedBy);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StateProvinces)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.SystemParameters)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.TransactionTypes)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PurchaseOrderLines)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PurchaseOrders1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.ContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.SupplierCategories)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.AlternateContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Suppliers1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Suppliers2)
                .WithRequired(e => e.Person2)
                .HasForeignKey(e => e.PrimaryContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.SupplierTransactions)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.BuyingGroups)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.CustomerCategories)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.AlternateContactPersonID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Customers1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Customers2)
                .WithRequired(e => e.Person2)
                .HasForeignKey(e => e.PrimaryContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.CustomerTransactions)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.AccountsPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices2)
                .WithRequired(e => e.Person2)
                .HasForeignKey(e => e.ContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices3)
                .WithRequired(e => e.Person3)
                .HasForeignKey(e => e.PackedByPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Invoices4)
                .WithRequired(e => e.Person4)
                .HasForeignKey(e => e.SalespersonPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Orders1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.ContactPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Orders2)
                .WithOptional(e => e.Person2)
                .HasForeignKey(e => e.PickedByPersonID);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Orders3)
                .WithRequired(e => e.Person3)
                .HasForeignKey(e => e.SalespersonPersonID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.SpecialDeals)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Colors)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.PackageTypes)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StockGroups)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StockItemHoldings)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StockItems)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StockItemStockGroups)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.StockItemTransactions)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.LastEditedBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StateProvince>()
                .HasMany(e => e.Cities)
                .WithRequired(e => e.StateProvince)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionType>()
                .HasMany(e => e.SupplierTransactions)
                .WithRequired(e => e.TransactionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionType>()
                .HasMany(e => e.CustomerTransactions)
                .WithRequired(e => e.TransactionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TransactionType>()
                .HasMany(e => e.StockItemTransactions)
                .WithRequired(e => e.TransactionType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderLines)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SupplierCategory>()
                .HasMany(e => e.Suppliers)
                .WithRequired(e => e.SupplierCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierTransactions)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.StockItems)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomerCategory>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.CustomerCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.StandardDiscountPercentage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Customers1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.BillToCustomerID);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.CustomerTransactions)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoices)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.BillToCustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Invoices1)
                .WithRequired(e => e.Customer1)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InvoiceLine>()
                .Property(e => e.TaxRate)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<OrderLine>()
                .Property(e => e.TaxRate)
                .HasPrecision(18, 3);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Orders1)
                .WithOptional(e => e.Order1)
                .HasForeignKey(e => e.BackorderOrderID);

            modelBuilder.Entity<SpecialDeal>()
                .Property(e => e.DiscountPercentage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ColdRoomTemperature>()
                .Property(e => e.Temperature)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PackageType>()
                .HasMany(e => e.PurchaseOrderLines)
                .WithRequired(e => e.PackageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageType>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.PackageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageType>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.PackageType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageType>()
                .HasMany(e => e.StockItems)
                .WithRequired(e => e.PackageType)
                .HasForeignKey(e => e.OuterPackageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PackageType>()
                .HasMany(e => e.StockItems1)
                .WithRequired(e => e.PackageType1)
                .HasForeignKey(e => e.UnitPackageID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockGroup>()
                .HasMany(e => e.StockItemStockGroups)
                .WithRequired(e => e.StockGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .Property(e => e.TaxRate)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockItem>()
                .Property(e => e.TypicalWeightPerUnit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.PurchaseOrderLines)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.InvoiceLines)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.OrderLines)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasOptional(e => e.StockItemHolding)
                .WithRequired(e => e.StockItem);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.StockItemStockGroups)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.StockItemTransactions)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItemTransaction>()
                .Property(e => e.Quantity)
                .HasPrecision(18, 3);

            modelBuilder.Entity<VehicleTemperature>()
                .Property(e => e.Temperature)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Customers_Archive>()
                .Property(e => e.StandardDiscountPercentage)
                .HasPrecision(18, 3);

            modelBuilder.Entity<ColdRoomTemperatures_Archive>()
                .Property(e => e.Temperature)
                .HasPrecision(10, 2);

            modelBuilder.Entity<StockItems_Archive>()
                .Property(e => e.TaxRate)
                .HasPrecision(18, 3);

            modelBuilder.Entity<StockItems_Archive>()
                .Property(e => e.TypicalWeightPerUnit)
                .HasPrecision(18, 3);

            modelBuilder.Entity<VehicleTemperatures1>()
                .Property(e => e.Temperature)
                .HasPrecision(10, 2);
        }
    }
}
