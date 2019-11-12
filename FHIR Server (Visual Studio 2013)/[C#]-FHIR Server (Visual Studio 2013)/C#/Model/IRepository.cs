using System.Collections.Generic;

namespace Model
{
    public interface IRepository
    {
        void CreatePatient( Patient patient);
        void UpdatePatient(Patient patient);
        bool DeletePatient(int patid);

        Patient ReadPatient(int id);

        List<Patient> SearchByName(string name);

        Patient ReadPatientHistory(int patid, int version);
        List<Patient> GetPatientHistory(int patid);
        List<Patient> GetPatientHistory(Patient patient);
    }
}