using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

using Model;
using RepositoryProxy;

namespace Client
{
    class ViewModel : INotifyPropertyChanged
    {
        IRepositoryProxy proxy;
        ISet<Customer> dirtyCustomers;
        ISet<Order> dirtyOrders;
        public ObservableCollection<Customer> Customers { get; private set; }

        public ViewModel(IRepositoryProxy proxy)
        {
            this.proxy = proxy;

            Customers = new ObservableCollection<Customer>(proxy.GetCustomers());
            dirtyCustomers = new HashSet<Customer>();
            dirtyOrders = new HashSet<Order>();

            //track changes
            foreach (var customer in Customers) {
                ((INotifyPropertyChanged)customer).PropertyChanged += (s, a) => EntityPropertyChanged(dirtyCustomers, (Customer)s, a);
                customer.Orders.CollectionChanged += (s, a) => CollectionChanged(dirtyOrders, a);

                foreach (var order in customer.Orders)
                    ((INotifyPropertyChanged)order).PropertyChanged += (s, a) => EntityPropertyChanged(dirtyOrders, (Order)s, a);
            }

            Customers.CollectionChanged += (s, a) => CollectionChanged(dirtyCustomers, a);
        }

        public bool Online
        {
            get { return proxy.Online; }
        }

        static void CollectionChanged<T>(ISet<T> dirty, NotifyCollectionChangedEventArgs e) where T : IObjectWithChangeTracker
        {
            if (e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Replace)
                foreach (var item in e.OldItems) {
                    T entity = (T)item;
                    if (entity.ChangeTracker.State == ObjectState.Added)
                        dirty.Remove(entity);
                    else
                        dirty.Add(entity.MarkAsDeleted());
                }

            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Replace)
                foreach (var item in e.NewItems)
                    dirty.Add(((T)item).MarkAsAdded());
        }

        static void EntityPropertyChanged<T>(ISet<T> dirty, T item, PropertyChangedEventArgs e) where T : IObjectWithChangeTracker
        {
            if (item.ChangeTracker.State == ObjectState.Unchanged)
                dirty.Add(item.MarkAsModified());
        }

        public static void InitialiseOrder(Order order)
        {
            order.Date = DateTime.Now;
        }

        public void Save()
        {
            if (proxy == null) throw new InvalidOperationException("The Online property must be set before saving");

            proxy.SaveChanges(dirtyCustomers, dirtyOrders);

            dirtyCustomers.Clear();
            dirtyOrders.Clear();
        }

        #pragma warning disable 0067 // "The event 'PropertyChanged' is never used"
        public event PropertyChangedEventHandler PropertyChanged;
    }
}