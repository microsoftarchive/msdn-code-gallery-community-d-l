using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmExample.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace MvvmExample.ViewModel
{
    class ViewModelWindow4b : ViewModelBase
    {
        public string WindowTitle { get { return "Business Object via ViewModel"; } }

        ObservableCollection<PocoPerson> _People;
        public ObservableCollection<PocoPerson> People
        {
            get
            {
                _People = new ObservableCollection<PocoPerson>(personel.GetEmployees());
                _People.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(People_CollectionChanged);
                return _People;
            }
        }
        

        PersonelBusinessObject personel;

        public ViewModelWindow4b()
        {
            personel = new PersonelBusinessObject();
            personel.PeopleChanged += new EventHandler(personel_PeopleChanged);
            People.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(People_CollectionChanged);
        }

        void People_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var newItem = (PocoPerson)e.NewItems[0];
                    personel.AddPerson(newItem);
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    var oldItem = (PocoPerson)e.OldItems[0];
                    personel.DeletePerson(oldItem);
                    break;
            }
        }

        void personel_PeopleChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    RaisePropertyChanged("People");
                }));
        }
    }
}
