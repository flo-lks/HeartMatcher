using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace HeartMatcher
{
    public class ExtendedMatcher : IMatcher
    {
        public void Match(PatientManager patientManager, HeartManager heartManager, MatchManager matchManager)
        {
            foreach (Patient patient in patientManager.GetAll().ToList())
            {
                double lowestDistance = double.MaxValue;
                Heart matchHeart = null;

                foreach (Heart heart in heartManager.GetAll())
                {
                    double distance = DistanceCalculator.CalculateAirDistance(patient.Hospital.Lat, patient.Hospital.Lon, heart.Lat, heart.Lon);

                    if (distance < lowestDistance)
                    {
                        lowestDistance = distance;
                        matchHeart = heart;
                    }
                }

                if (matchHeart != null)
                {
                    matchManager.Add(new Match(patient, matchHeart));
                    patientManager.Remove(patient);
                    heartManager.Remove(matchHeart);
                }
            }
        }
    }

}