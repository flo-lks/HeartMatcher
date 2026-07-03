using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EuroTrans.Core
{
    public class ExtendedMatcher : IMatcher
    {
        public void Match(PatientManager patientManager, HeartManager heartManager, CandidateManager candidateManager)
        {
            foreach (RecipientPatient patient in patientManager.GetAll().Where(patient => !patient.IsMatched).ToList())
            {
                double lowestDistance = double.MaxValue;
                DonorHeart? matchHeart = null;

                foreach (DonorHeart heart in heartManager.GetAll())
                {
                    if (!CheckBloodType.IsCompatible(patient.BloodType, heart.BloodType)) continue;

                    if (!CheckBodyweight.IsCompatible(patient.Bodyweight, heart.DonorBodyweight)) continue;

                    double distance = DistanceCalculator.CalculateAirDistance(patient.Hospital.Lat, patient.Hospital.Lon, heart.Lat, heart.Lon);
                    if (distance < lowestDistance)
                    {
                        lowestDistance = distance;
                        matchHeart = heart;
                    }
                }

                if (matchHeart != null)
                {
                    candidateManager.Add(new Candidate(patient, matchHeart));
                    patient.IsMatched = true;
                    matchHeart.IsMatched = true;
                }
            }
            candidateManager.WriteCandidatesToCSV("Candidates.csv");
        }
    }
}