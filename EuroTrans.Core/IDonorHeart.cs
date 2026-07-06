using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface IDonorHeart
    {
        int Id { get; set; }
        string BloodType { get; set; }
        double DonorBodyweight { get; set; }
        double Lat {  get; set; }
        double Lon { get; set; }
        bool IsMatched { get; set; }
    }
}