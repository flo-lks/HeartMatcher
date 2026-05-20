using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface ICandidate
    {
        RecipientPatient RecipientPatient { get; set; }
        DonorHeart DonorHeart { get; set; }
    }
}