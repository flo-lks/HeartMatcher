using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class Hospital : IHospital
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Hospital(int id, string name, double lat, double lon)
        {
            this.ID = id;
            this.Name = name;
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}