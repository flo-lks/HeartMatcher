using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Patient : IPatient
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Bloodtype { get; set; }
        public Hospital Hospital { get; set; }

        public Patient(string firstname, string lastname, int bloodtype, Hospital hospital)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Bloodtype = bloodtype;
            this.Hospital = hospital;
        }
    }
}