using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class PatientManager : IManager<RecipientPatient>
    {
        List<RecipientPatient> patients = new();

        public PatientManager(HospitalManager hospitalManager)
        {
            LoadPatientsFromCSV("Patients.csv", hospitalManager);
        }

        public List<RecipientPatient> GetAll() => patients;
        public void Add(RecipientPatient candidate) => patients.Add(candidate);
        public void Remove(RecipientPatient patient) => patients.Remove(patient);

        public void AddPatientFromArray(string[] parts, HospitalManager hospitalManager)
        {
            if (parts.Length < 6) return;

            if (!int.TryParse(parts[0], out int id)) return;
            if (!double.TryParse(parts[4], NumberStyles.Any, CultureInfo.InvariantCulture, out double bodyweight)) return;
            if (!int.TryParse(parts[5], out int hospitalId)) return;

            Hospital? hospital = hospitalManager.GetAll()
                .FirstOrDefault(h => h.ID == hospitalId);

            RecipientPatient patient = new RecipientPatient(
                id: id,
                firstname: parts[1],
                lastname: parts[2],
                bloodType: parts[3],
                bodyweight: bodyweight,
                hospital: hospital,
                isMatched: false
            );

            Add(patient);
        }

        private void LoadPatientsFromCSV(string path, HospitalManager hospitalManager)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                AddPatientFromArray(parts, hospitalManager);
            }
        }

        public void WritePatientsToCSV(string path)
        {
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[]
            {
                "Patient ID",
                "Firstname",
                "Lastname",
                "BloodType",
                "Bodyweight",
                "Hospital"
            });
            foreach (RecipientPatient patient in patients)
            {
                rows.Add(new string[]
                {
                    patient.ID.ToString(),
                    patient.Firstname,
                    patient.Lastname,
                    patient.BloodType,
                    patient.Bodyweight.ToString(),
                    patient.Hospital.ID.ToString(),
                });
            }
            PersistenceManager.WriteCSV(path, rows);
        }
    }
}