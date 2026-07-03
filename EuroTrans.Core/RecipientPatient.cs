using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class RecipientPatient : IRecipientPatient
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string BloodType { get; set; }
        public double Bodyweight { get; set; }
        public Hospital Hospital { get; set; }
        public bool IsMatched { get; set; }

        public RecipientPatient(int id, string firstname, string lastname, string bloodtype, double bodyweight, Hospital hospital, bool isMatched)
        {
            this.ID = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.BloodType = bloodtype;
            this.Bodyweight = bodyweight;
            this.Hospital = hospital;
            this.IsMatched = isMatched;
        }
    }
}