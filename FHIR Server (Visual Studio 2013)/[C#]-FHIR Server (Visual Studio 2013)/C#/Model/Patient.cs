using System;

namespace Model
{
    public class Patient
    {
        public Patient()
        {
            RecordNo = 0;
            Timestamp = DateTime.UtcNow;
            IsDeleted = false;

            PatientId = 0;
            Version = 0;
            LastName = "Unknown";
            Birthday = DateTime.UtcNow;
            Gender = GenderCode.Unknown;
            Active = true;
            Deceased = false;
        }


        public Patient(Patient patient)
        {
            RecordNo = 0;

            Action = patient.Action;
            Timestamp = patient.Timestamp;
            Version = patient.Version;
            IsDeleted = patient.IsDeleted;

            // Logical Identifier
            PatientId = patient.PatientId;

            // Patient propperties
            FirstName = patient.FirstName;
            LastName = patient.LastName;

            Birthday = patient.Birthday;
            Gender = patient.Gender;

            EMail = patient.EMail;
            Phone = patient.Phone;
            Mobile = patient.Mobile;

            AddressLine1 = patient.AddressLine1;
            AddressLine2 = patient.AddressLine2;
            Zip = patient.Zip;
            City = patient.City;
            Country = patient.Country;

            Active = patient.Active;
            Deceased = patient.Deceased;
        }


        // Each Record is immutable, in case of updates we create a new record and 
        // keep track of Version, Time of modification and action type like CREATE/UPDATE
        public int RecordNo { get; set; }
        public int Version { get; set; }
        public DateTime Timestamp { get; set; }
        public String Action { get; set; }
        public Boolean IsDeleted { get; set; }

        // Logical Identifier
        public int PatientId { get; set; }

        // Patient propperties
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }

        public DateTime Birthday { get; set; }
        public GenderCode Gender { get; set; }

        public String EMail { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }

        public String AddressLine1 { get; set; }
        public String AddressLine2 { get; set; }
        public String Zip { get; set; }
        public String City { get; set; }
        public String Country { get; set; }

        public Boolean Active { get; set; }
        public Boolean Deceased { get; set; }

        // Property that needs to be mapped to an extension, defintions for the nationalities can be found here:
        // http://www.englishclub.com/vocabulary/world-countries-nationality.htm
        //
        public String Nationality { get; set; }
    }
}
