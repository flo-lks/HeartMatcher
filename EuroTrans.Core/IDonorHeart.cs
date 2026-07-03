using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface IDonorHeart
    {
        string BloodType { get; set; }
        int Id { get; set; }
        double DonorBodyweight { get; set; }
        double Lat {  get; set; }
        double Lon { get; set; }
        bool IsMatched { get; set; }
    }
}