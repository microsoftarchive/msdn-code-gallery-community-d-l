using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;
using System.Collections.ObjectModel;
using System.Windows;
using System.Data.Entity;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Threading; 

namespace wpf_EntityFramework
{
    public class CustomersViewModel : CrudVMBase
    {
        public CustomerVM SelectedCustomer { get; set; }
        public ObservableCollection<CustomerVM> Customers { get; set; }
        public CustomersViewModel() 
            :  base()
        {

        }
        protected override void CommitUpdates()
        {
            UserMessage msg = new UserMessage();
            var inserted = (from c in Customers
                             where c.IsNew
                             select c).ToList();
            if(db.ChangeTracker.HasChanges() || inserted.Count > 0)
            { 
                foreach (CustomerVM c in inserted)
                {
                    db.Customers.Add(c.TheCustomer);
                }
                try
                {
                    db.SaveChanges();
                    msg.Message = "Database Updated";
                }
                catch (Exception e)
                {
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        ErrorMessage = e.InnerException.GetBaseException().ToString();
                    }
                    msg.Message = "There was a problem updating the database";
                }
            }
            else
            {
                msg.Message = "No changes to save";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }
        protected override void DeleteCurrent()
        {
            UserMessage msg = new UserMessage();
            if (SelectedCustomer !=null)
            {
                int NumOrders = NumberOfOrders();
                if (NumOrders > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Orders for this Customer", NumOrders);
                }
                else
                {
                    db.Customers.Remove(SelectedCustomer.TheCustomer);
                    Customers.Remove(SelectedCustomer);
                    RaisePropertyChanged("Customers");
                    msg.Message = "Deleted";
                }
            }
            else
            {
                msg.Message = "No Customer selected to delete";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }

        private int NumberOfOrders()
        {
            var cust = db.Customers.Find(SelectedCustomer.TheCustomer.Id);
            // Count how many Order Lines the Product has
            int ordersCount = db.Entry(cust)
                                .Collection(c => c.Orders)
                                .Query()
                                .Count();
            return ordersCount;
        }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;
            ObservableCollection<CustomerVM> _customers = new ObservableCollection<CustomerVM>();
            var customers = await (from c in db.Customers
                                    orderby c.CustomerName
                                    select c).ToListAsync();
            //  await Task.Delay(9000);
            foreach (Customer cust in customers)
            {
                _customers.Add(new CustomerVM { IsNew = false, TheCustomer = cust });
            }
            Customers = _customers;
            RaisePropertyChanged("Customers");
            ThrobberVisible = Visibility.Collapsed;
        }
    }
}
