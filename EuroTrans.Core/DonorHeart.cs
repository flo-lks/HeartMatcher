using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class DonorHeart : IDonorHeart
    {
        public int Id { get; set; }
        public string BloodType {  get; set; }
        public double DonorBodyweight { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public DonorHeart(int id, string bloodtype, double donorBodyweight,  double lat, double lon)
        {
            this.Id = id;
            this.BloodType = bloodtype;
            this.DonorBodyweight = donorBodyweight;
            this.Lat = lat;
            this.Lon = lon;
        }
    }
}