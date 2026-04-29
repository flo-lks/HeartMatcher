using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class Match : IMatch
    {
        public Patient Patient { get; set; }
        public Heart Heart { get; set; }

        public Match (Patient patient, Heart heart)
        {
            this.Patient = patient;
            this.Heart = heart;
        }
    }
}