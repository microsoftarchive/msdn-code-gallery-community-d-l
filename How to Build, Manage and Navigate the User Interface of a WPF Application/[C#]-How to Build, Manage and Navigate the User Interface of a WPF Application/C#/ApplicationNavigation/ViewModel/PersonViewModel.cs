using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ApplicationNavigation.Model;

namespace ApplicationNavigation.ViewModel
{
    class PersonViewModel : ViewModelBase
    {
        Person _PersonData;
        public Person PersonData
        {
            get
            {
                return _PersonData;
            }
            set
            {
                if (_PersonData != value)
                {
                    _PersonData = value;
                    RaisePropertyChanged("PersonData");
                }
            }
        }

        List<Department> _Departments;
        public List<Department> Departments
        {
            get
            {
                return _Departments;
            }
            set
            {
                if (_Departments != value)
                {
                    _Departments = value;
                    RaisePropertyChanged("Departments");
                }
            }
        }

        public PersonViewModel(int id)
        {
            Departments = new List<Department>
            {
                new Department { Id = 1, Name="Development" },
                new Department { Id = 2, Name="Sales" },
                new Department { Id = 3, Name="Accounting" },
            };

            var people = (Person[])Application.Current.FindResource("People");
            PersonData = people.SingleOrDefault<Person>(p => p.Id == id);
        }
    }
}
