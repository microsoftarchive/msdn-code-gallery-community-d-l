using EntityFrameWorkNorthWind_cs;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

    public class Customers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="intitalize">false does not initialize list</param>
        public Customers(bool intitalize = false)
        {
            if (intitalize)
            {
                GetCustomers();
                GetColumNames();
                GetContactTitles();
            }
        }

        public List<Customer> DataSource { get; set; }
        public List<string> ColumnNames { get; set; }
        public List<string> ContactList { get; set; } 

        public void GetCustomers()
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {
                try
                {
                    DataSource = context.Customers.Select(cust => cust)
                        .Distinct()
                        .OrderBy(cust => cust.CompanyName)
                        .ToList();
                }
                catch (Exception ex)
                {
                    /*
                     * Of course for a production application we need to consider much better options
                     */
                    Console.WriteLine(ex.Message);
                }
            }
        }
        /// <summary>
        /// Used in tangent with update method
        /// </summary>
        public string ValidationMessage { get; set; }
        /// <summary>
        /// Here the current customer displayed in the DataGridView is removed
        /// from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <remarks>
        /// Make sure if working with child records that under table design for
        /// these tables you have set delete action to cascade otherwise the remove
        /// will fail and a runtime exception will be thrown.
        /// </remarks>
        public void Remove(Customer sender)
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {              
                context.Entry(sender).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Provides a method to update an existing customer and check for validation errors.
        /// If there are issues in validation the entry is reverted back to it's former state.
        /// 
        /// Also, the validation errors are reported back to the user interface.
        /// 
        /// </summary>
        /// <param name="EditedCustomer"></param>
        /// <returns></returns>
        public bool UpdateCustomer(Customer EditedCustomer)
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {
                try
                {
                    context.Entry(EditedCustomer).State = EntityState.Modified;
                    context.SaveChanges();
                    ValidationMessage = "";
                    return true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ef)
                {                   
                    UndoPendingChanges(context);
                    ValidationMessage = ef.DbEntityValidationExceptionToString();
                    return false;
                }
                catch (Exception ex)
                {
                    UndoPendingChanges(context);
                    ValidationMessage = "Update failed";
                    return false;
                }
            }
        }
        public int NewIdentifier  { get; set; }
        public bool AddNew(Customer NewCustomer)
        {

            using (NorthWindEntities context = new NorthWindEntities())
            {
                try
                {                    
                    context.Customers.Add(NewCustomer);
                    context.SaveChanges();
                    NewIdentifier = NewCustomer.CustomerIdentifier;
                    ValidationMessage = "";

                    return true;

                }
                catch (Exception ex)
                {
                    ValidationMessage = "Failed adding new customer.";

                    return false;

                }
            }
        }
        /// <summary>
        /// Will revert modfied entries to their former values so if there are many changes
        /// they all will be reverted while in this demo project saves are done at once so this
        /// will not happen here but in other situtation this might be an issue.
        /// </summary>
        /// <param name="context"></param>
        public static void UndoPendingChanges(DbContext context)
        {
            //detect all changes (probably not required if AutoDetectChanges is set to true)
            context.ChangeTracker.DetectChanges();

            //get all entries that are changed
            var entries = context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            //somehow try to discard changes on every entry
            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;

                if (entity == null) continue;

                if (dbEntityEntry.State == EntityState.Added)
                {
                    //if entity is in Added state, remove it. (there will be problems with Set methods if entity is of proxy type, in that case you need entity base type
                    var set = context.Set(entity.GetType());
                    set.Remove(entity);
                }
                else if (dbEntityEntry.State == EntityState.Modified)
                {
                    //entity is modified... you can set it to Unchanged or Reload it form Db??
                    dbEntityEntry.Reload();
                }
                else if (dbEntityEntry.State == EntityState.Deleted)
                    //entity is deleted...
                    dbEntityEntry.State = EntityState.Modified;
            }
        }
        /// <summary>
        /// Return a distinct list of contact titles
        /// </summary>
        /// <remarks>
        /// In a normalized database the titles would be in a reference table.
        /// </remarks>
        public void GetContactTitles()
        {
            using (NorthWindEntities context = new NorthWindEntities())
            {
                ContactList = context
                    .Customers
                    .DistinctBy(cust => cust.ContactTitle)
                    .OrderBy(cust => cust.ContactTitle)
                    .Select(cust => cust.ContactTitle)
                    .ToList();
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
            using (NorthWindEntities context = new NorthWindEntities())
            {
                switch (options)
                {
                    case FilterOptions.StartsWith:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().StartsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList();
                        break;

                    case FilterOptions.Contains:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().Contains(value.ToLower())).ToList();
                        break;

                    case FilterOptions.EndsWith:
                        DataSource = context.Customers.Filter(cust => cust.CompanyName.ToLower().EndsWith(value.ToLower(), StringComparison.CurrentCulture)).ToList();
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
        /// <remarks>Hard coded to the current model and Customer entity.</remarks>
        private void GetColumNames()
        {
            ColumnNames = new List<string>();
            using (NorthWindEntities context = new NorthWindEntities())
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