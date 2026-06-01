using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class PatientManager : IManager<RecipientPatient>
    {
        List<RecipientPatient> patients = new ();

        public List<RecipientPatient> GetAll()
        {
            return patients;
        }
        public void Add(RecipientPatient candidate)
        {
            patients.Add(candidate);
        }
        public void Remove(RecipientPatient patient)
        {
            patients.Remove(patient);
        }
    }
}