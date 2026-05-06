using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IHospital
    {
        string Name { get; set; }
        double Lat {  get; set; }
        double Lon { get; set; }
    }
}