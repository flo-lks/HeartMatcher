using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class SimpleMatcher : IMatcher
    {
        public void Match(PatientManager patientManager, HeartManager heartManager, MatchManager matchManager)
        {
            foreach(Patient patient in patientManager.GetAll())
            {
                foreach(Heart heart in heartManager.GetAll())
                {
                    if (patient.Bloodtype == heart.Bloodtype) matchManager.Add(new Match(patient, heart));
                }
            }
        }
    }
}