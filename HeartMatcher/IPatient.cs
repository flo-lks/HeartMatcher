using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IPatient
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Bloodtype { get; set; }
        Hospital Hospital { get; set; }
    }
}