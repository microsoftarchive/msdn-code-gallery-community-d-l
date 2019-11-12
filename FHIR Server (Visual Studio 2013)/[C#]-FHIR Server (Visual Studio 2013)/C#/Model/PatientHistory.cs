using System;
using System.Reflection;

namespace Model
{
    public class PatientHistory : Patient
    {
        public int PatientId { get; set; }
        public int HistoricVersion { get; set; }
        public String Action { get; set; }

        // Defaut c-tor
        public PatientHistory()
        {
            Id = 0;
            PatientId = 0;
            HistoricVersion = 0;
        }

        // Copy constructor - deep copy of Patient properties
        public PatientHistory(Patient patient, String action)
        {
            var type = typeof(Patient);
            var properties = type.GetProperties();
            foreach (PropertyInfo pi in properties)
            {
                pi.SetValue(this, pi.GetValue(patient, null), null);
            }

            Id = 0;

            PatientId = patient.Id;
            HistoricVersion = patient.Version;

            if (action != null)
            {
                this.Action = action;
            }

        }
    }
}
