using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Model;

namespace DataAccess
{
    public class Repository : IRepository
    {
        const string CREATE = "CREATE";
        const string UPDATE = "UPDATE";
        const string DELETE = "DELETE";

        public void CreatePatient( Patient patient)
        {
            using (var ctx = new ResourceContext() )
            {
                var pat = new Patient(patient);
                patient.Action = CREATE;
                patient.Version = 1;

                ctx.Patients.Add(patient);
                ctx.SaveChanges();

                patient.PatientId = patient.RecordNo;
                ctx.SaveChanges();
            }
        }

        public bool DeletePatient(int id)
        {
            using (var ctx = new ResourceContext())
            {
                var history = ctx.Patients.Where(p => p.PatientId == id).ToList();
                if (history.Count == 0)
                {
                    return false;
                }

                try
                {
                    var patient = history.Single(p => p.Version == history.Max(h => h.Version));

                    var tmp = new Patient(patient);
                    tmp.Version = tmp.Version + 1;
                    tmp.IsDeleted = true;
                    tmp.Action = DELETE;

                    ctx.Patients.Add(tmp);
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                    throw;
                }
            }
            return true;
        }
        
        public Patient ReadPatient(int id)
        {
            using (var ctx = new ResourceContext())
            {
                var history = ctx.Patients.Where( p => p.PatientId == id).ToList();
                if (history.Count == 0) return null;
                
                var patient = history.Single(p => p.Version == history.Max(h=>h.Version));
                if (patient.IsDeleted)
                {
                    return null;
                }
               return patient;
            }
        }

        public Patient ReadPatientHistory(int patid, int version)
        {
            using (var ctx = new ResourceContext())
            {
                var qry = from p in ctx.Patients
                    where p.PatientId == patid && p.Version == version
                    select p;

                return qry.SingleOrDefault();
            }
        }

        public List<Patient> GetPatientHistory(int patid)
        {
            using (var ctx = new ResourceContext())
            {
                return ctx.Patients.Where(h => h.PatientId == patid).ToList();
            }
        }

        public List<Patient> GetPatientHistory(Patient patient)
        {
            return GetPatientHistory(patient.PatientId);
        }

        public void UpdatePatient(Patient patient)
        {
            if (patient.PatientId == 0)
            {
                throw new ArgumentException("Cant find patient id for update");
            }

            using (var ctx = new ResourceContext())
            {
                int version = ctx.Patients.Where(p => p.PatientId == patient.PatientId).Max(h => h.Version);
                if (version == 0)
                {
                    throw new Exception("Patient not found");
                }
                
                var tmp = new Patient(patient);
                tmp.Version = version + 1;
                tmp.Action = UPDATE;
                ctx.Patients.Add(tmp);
                ctx.SaveChanges();
            }
        }


        public List<Patient> SearchByName(string name)
        {
            using (var ctx = new ResourceContext())
            {
                var pattern = name.ToLower();

                var qry = from p in ctx.Patients
                    where p.FirstName.ToLower().Contains(pattern) ||
                          p.LastName.ToLower().Contains(pattern)
                    select p;
                
                Debug.WriteLine("{0}", qry.ToString());

                return qry.ToList();
            }
        }
    }
}
