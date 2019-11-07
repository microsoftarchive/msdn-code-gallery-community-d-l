using System.Collections.Generic;
using MvvmExample.Data;
using System;
using System.Threading;

namespace MvvmExample.Model
{
    class PersonnelBusinessObject
    {
        public enum StatusType
        {
            Offline = 0,
            Online = 1
        }

        public event EventHandler PeopleChanged;

        List<PocoPerson> People { get; set; }
        public StatusType Status { get; set; }
        public string ReportTitle { get; set; }

        Timer StatusTimer;

        public PersonnelBusinessObject()
        {
            People = FakeDatabaseLayer.GetPocoPeopleFromDatabase();
            StatusTimer = new Timer(StatusChangeTick, null, 1000, 1000);
        }

        void StatusChangeTick(object state)
        {
            Status = Status == StatusType.Offline ? StatusType.Online : StatusType.Offline;
        }

        public List<PocoPerson> GetEmployees()
        {
            return People;
        }

        public void AddPerson(PocoPerson person)
        {
            People.Add(person);
            OnPeopleChanged();
        }

        public void DeletePerson(PocoPerson person)
        {
            People.Remove(person);
            OnPeopleChanged();
        }

        public void UpdatePerson(PocoPerson person)
        {

        }

        void OnPeopleChanged()
        {
            if (PeopleChanged != null)
                PeopleChanged(this, null);
        }
    }
}
