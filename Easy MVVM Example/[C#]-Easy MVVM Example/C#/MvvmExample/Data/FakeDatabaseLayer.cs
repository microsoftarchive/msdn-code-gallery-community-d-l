using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MvvmExample.Model;

namespace MvvmExample.Data
{
    class FakeDatabaseLayer
    {
        public static ObservableCollection<Person> GetPeopleFromDatabase()
        {
            //Simulate database extaction
            //For example from ADO DataSets or EF
            return new ObservableCollection<Person>
            {
                new Person { FirstName="Tom", LastName="Jones", Age=80 },
                new Person { FirstName="Dick", LastName="Tracey", Age=40 },
                new Person { FirstName="Harry", LastName="Hill", Age=60 },
            };
        }

        public static List<PocoPerson> GetPocoPeopleFromDatabase()
        {
            //Simulate legacy database extaction of POCO classes
            //For example from ADO DataSets or EF
            return new List<PocoPerson>
            {
                new PocoPerson { FirstName="Tom", LastName="Jones", Age=80 },
                new PocoPerson { FirstName="Dick", LastName="Tracey", Age=40 },
                new PocoPerson { FirstName="Harry", LastName="Hill", Age=60 },
            };
        }
    }
}
