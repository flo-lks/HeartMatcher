using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace EuroTrans.Core
{
    public class ExtendedMatcher : IMatcher
    {
        public void Match(PatientManager patientManager, HeartManager heartManager, CandidateManager matchManager, HospitalManager hospitalManager)
        {
            foreach (RecipientPatient patient in patientManager.GetAll().ToList())
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
                    matchManager.Add(new Candidate(patient, matchHeart));
                    patientManager.Remove(patient);
                    heartManager.Remove(matchHeart);
                }
            }
        }
    }
}