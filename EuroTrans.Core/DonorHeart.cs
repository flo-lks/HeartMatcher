using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class DonorHeart : IDonorHeart
    {
        public string BloodType {  get; set; }
        public int Id { get; set; }
        public double DonorBodyweight { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public DonorHeart(string bloodtype, int id, double donorBodyweight,  double lat, double lon)
        {
            this.BloodType = bloodtype;
            this.Id = id;
            this.DonorBodyweight = donorBodyweight;
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}