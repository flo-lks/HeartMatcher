using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class PatientManager : IManager<RecipientPatient>
    {
        public PatientManager(HospitalManager hospitalManager)
        {
            LoadPatientsFromCSV("Patients.csv", hospitalManager);
        }

        List<RecipientPatient> patients = new();

        private void LoadPatientsFromCSV(string path, HospitalManager hospitalManager)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                Hospital? hospital = hospitalManager.GetAll().FirstOrDefault(h => h.ID == int.Parse(parts[5]));
                RecipientPatient patient = new RecipientPatient(
                    id: int.Parse(parts[0]),
                    firstname: parts[1],
                    lastname: parts[2],
                    bloodtype: parts[3],
                    bodyweight: double.Parse(parts[4]),
                    hospital: hospital
                );
                Add(patient);
            }
        }

        public List<RecipientPatient> GetAll() => patients;
        public void Add(RecipientPatient candidate) => patients.Add(candidate);
        public void Remove(RecipientPatient patient) => patients.Remove(patient);
    }
}