using EntityFrameWorkNorthWind_cs;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Example1_cs
{
    /// <summary>
    /// Used to assist with filtering strings
    /// </summary>
    public enum FilterOptions
    {
        StartsWith,
        Contains,
        EndsWith,
        Equals
    }

    public partial class Customers
    {
        public Customers()
        {
            GetCustomers();
            GetColumNames();
        }

        public List<Customer> DataSource { get; set; }
        public List<string> ColumnNames { get; set; }

        public void GetCustomers()
        {
            using (NorthWindEntity context = new NorthWindEntity())
            {
                DataSource = context.Customers.Select(cust => cust).ToList();
            }
        }

        /// <summary>
        /// Provides a search for company name
        /// </summary>
        /// <param name="value">text to use for filter</param>
        /// <param name="options">Type of search</param>
        /// <remarks>
        /// By default EF is case sensitive. Here we use ToLower to allow
        /// case insensitive search but a fragile method is modifying the underlying table
        /// https://milinaudara.wordpress.com/2015/02/04/case-sensitive-search-using-entity-framework-with-custom-annotation/
        /// </remarks>
        public void CompanyNameFilter(string value, FilterOptions options)
        {
            using (NorthWindEntity context = new NorthWindEntity())
            {
                switch (options)
                {
                    case FilterOptions.StartsWith:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().StartsWith(value.ToLower())).ToList();
                        break;

                    case FilterOptions.Contains:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().Contains(value.ToLower())).ToList();
                        break;

                    case FilterOptions.EndsWith:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().EndsWith(value.ToLower())).ToList();
                        break;

                    case FilterOptions.Equals:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.Equals(value, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Shows how to get column names for Customer table
        /// </summary>
        private void GetColumNames()
        {
            ColumnNames = new List<string>();
            using (NorthWindEntity context = new NorthWindEntity())
            {
                var objectContext = ((IObjectContextAdapter)context).ObjectContext;
                var storageMetadata = ((EntityConnection)objectContext.Connection).GetMetadataWorkspace().GetItems(DataSpace.SSpace);
                var entityProps = (from sm in storageMetadata where sm.BuiltInTypeKind == BuiltInTypeKind.EntityType select sm as EntityType);
                // For your project, open the model browser to get the name for the model, will have namespace.Store
                var metaData = (from m in entityProps where m.FullName == "NORTHWNDModel.Store.Customers" select m.DeclaredProperties).ToList();
                foreach (var topItem in metaData)
                {
                    foreach (var item in topItem)
                    {
                        ColumnNames.Add(item.Name);
                    }
                }
            }
        }
    }
}