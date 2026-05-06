using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Hospital : IHospital
    {
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Hospital(string name, double lat, double lon)
        {
            this.Name = name;
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}