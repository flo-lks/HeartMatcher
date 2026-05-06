using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class HospitalManager : IManager<Hospital>
    {
        List<Hospital> hospitals = new List<Hospital>();

        public List<Hospital> GetAll()
        {
            return hospitals;
        }
        public void Add(Hospital hospital)
        {
            hospitals.Add(hospital);
        }
    }
}