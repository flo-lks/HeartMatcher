using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class PatientManager : IManager<RecipientPatient>
    {
        public PatientManager()
        {
            LoadPatientsFromCSV("Patients.csv");
        }

        List<RecipientPatient> patients = new();

        private void LoadPatientsFromCSV(string path)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                RecipientPatient patient = new RecipientPatient(
                    firstname: parts[0],
                    lastname: parts[1],
                    bloodtype: parts[2],
                    bodyweight: double.Parse(parts[3]),
                    hospitalID: int.Parse(parts[4])
                );
                Add(patient);
            }
        }

        public List<RecipientPatient> GetAll() => patients;
        public void Add(RecipientPatient candidate) => patients.Add(candidate);
        public void Remove(RecipientPatient patient) => patients.Remove(patient);
    }
}