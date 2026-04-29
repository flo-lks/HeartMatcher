using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IPerson
    {
        string Firstname { get; set; }
        string Lastname { get; set; }
        int Bloodtype { get; set; }
    }
}