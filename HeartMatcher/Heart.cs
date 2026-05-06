using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Heart : IHeart
    {
        public int Bloodtype {  get; set; }
        public int Id { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Heart(int bloodtype, int id, double lat, double lon)
        {
            this.Bloodtype = bloodtype;
            this.Id = id;
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}