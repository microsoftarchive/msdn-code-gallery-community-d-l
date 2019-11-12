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
    public class ProductsViewModel : CrudVMBase
    {
        public ProductVM SelectedProduct { get; set; }
        public ObservableCollection<ProductVM> Products { get; set; }
        protected async override void GetData()
        {
            ThrobberVisible = Visibility.Visible;
            ObservableCollection<ProductVM> _products = new ObservableCollection<ProductVM>();
            var products = await (from p in db.Products
                                   orderby p.ProductShortName
                                   select p).ToListAsync();
            foreach (Product prod in products)
            {
                _products.Add(new ProductVM { IsNew = false, TheProduct = prod });
            }
            Products = _products;
            RaisePropertyChanged("Products");
            ThrobberVisible = Visibility.Collapsed;
        }
        protected override void CommitUpdates()
        {
            UserMessage msg = new UserMessage();
            var inserted = (from c in Products
                           where c.IsNew
                           select c).ToList();
            if (db.ChangeTracker.HasChanges() || inserted.Count > 0)
            {
                foreach (ProductVM c in inserted)
                {
                    db.Products.Add(c.TheProduct);
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
            if (SelectedProduct != null)
            {
                int NumLines = NumberOfOrderLines();
                if (NumLines > 0)
                {
                    msg.Message = string.Format("Cannot delete - there are {0} Order Lines for this Product", NumLines);
                }
                else if(NumLines < 0)
                {
                    msg.Message = "Cannot delete since not committed to database yet";
                }
                else
                {
                    db.Products.Remove(SelectedProduct.TheProduct);
                    Products.Remove(SelectedProduct);
                    RaisePropertyChanged("Products");
                    msg.Message = "Deleted";
                }
            }
            else
            {
                msg.Message = "No Product selected to delete";
            }
            Messenger.Default.Send<UserMessage>(msg);
        }
        private int NumberOfOrderLines()
        {
            var prod = db.Products.Find(SelectedProduct.TheProduct.Id);
            if (prod == null)
            {
                return -1;
            }
            // Count how many Order Lines there are for the Product
            int linesCount = db.Entry(prod)
                               .Collection(p => p.OrderLines)
                               .Query()
                               .Count();
            return linesCount;
        }
        public ProductsViewModel()
            : base()
        {
        }
    }
}
