using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace EuroTrans.Core
{
    public class CandidateManager : IManager<Candidate>
    {
        List<Candidate> candidates = new List<Candidate>();

        public List<Candidate> GetAll()
        {
            return candidates;
        }
        public void Add(Candidate match)
        {
            candidates.Add(match);
        }

        public void WriteCandidatesToCSV(string path)
        {
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[]
            {
                "Patient ID",
                "Firstname",
                "Lastname",
                "BloodType",
                "Bodyweight",
                "Hospital",
                "Heart ID",
                "BloodType",
                "Donor Bodyweight"
            });
            foreach (Candidate candidate in candidates)
            {
                rows.Add(new string[]
                {
                    candidate.RecipientPatient.ID.ToString(),
                    candidate.RecipientPatient.Firstname,
                    candidate.RecipientPatient.Lastname,
                    candidate.RecipientPatient.BloodType,
                    candidate.RecipientPatient.Bodyweight.ToString(CultureInfo.InvariantCulture),
                    candidate.RecipientPatient.Hospital.Name,
                    candidate.DonorHeart.Id.ToString(),
                    candidate.DonorHeart.BloodType,
                    candidate.DonorHeart.DonorBodyweight.ToString(CultureInfo.InvariantCulture),
                });
            }
            PersistenceManager.WriteCSV(path, rows);
        }
    }
}