using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class Candidate : ICandidate
    {
        public RecipientPatient RecipientPatient {  get; set; }
        public DonorHeart DonorHeart { get; set; }

        public Candidate(RecipientPatient patient, DonorHeart heart)
        {
            this.RecipientPatient = patient;
            this.DonorHeart = heart;
        }
    }
}