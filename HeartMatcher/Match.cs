using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Match : IMatch
    {
        public RecipientPatient RecipientPatient {  get; set; }
        public DonorHeart DonorHeart { get; set; }

        public Match(RecipientPatient patient, DonorHeart heart)
        {
            this.RecipientPatient = patient;
            this.DonorHeart = heart;
        }
    }
}