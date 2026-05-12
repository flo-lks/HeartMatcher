using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IMatch
    {
        RecipientPatient RecipientPatient { get; set; }
        DonorHeart DonorHeart { get; set; }
    }
}