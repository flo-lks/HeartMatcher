using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class PatientManager : IManager<Patient>
    {
        List<Patient> patients = new List<Patient>();

        public List<Patient> GetAll()
        {
            return patients;
        }
        public void Add(Patient candidate)
        {
            patients.Add(candidate);
        }
        public void Remove(Patient patient)
        {
            patients.Remove(patient);
        }
    }
}