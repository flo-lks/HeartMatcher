using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class PatientManager : IManager<Patient>
    {
        List<Patient> candidates = new List<Patient>();

        public List<Patient> GetAll()
        {
            return candidates;
        }
        public void Add(Patient candidate)
        {
            candidates.Add(candidate);
        }
    }
}