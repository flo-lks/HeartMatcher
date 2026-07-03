using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface IRecipientPatient
    {
        int ID { get; set; }
        string Firstname { get; set; }
        string Lastname { get; set; }
        string BloodType { get; set; }
        double Bodyweight { get; set; }
        Hospital Hospital { get; set; }
        bool IsMatched { get; set; }
    }
}