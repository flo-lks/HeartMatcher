using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class RecipientPatient : IRecipientPatient
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BloodType { get; set; }
        public double Bodyweight { get; set; }
        public Hospital Hospital { get; set; }

        public RecipientPatient(string firstname, string lastname, string bloodtype, double bodyweight, Hospital hospital)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.BloodType = bloodtype;
            this.Bodyweight = bodyweight;
            this.Hospital = hospital;
        }
    }
}