using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EuroTrans.Core;

namespace EuroTrans_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientManager patientManager = new();
            HeartManager heartManager = new();
            HospitalManager hospitalManager = new();
            CandidateManager candidateManager = new();

            ExtendedMatcher extendedMatcher = new();
            extendedMatcher.Match(patientManager, heartManager, candidateManager, hospitalManager);

            if(candidateManager.GetAll().Count == 0)
            {
                Console.WriteLine("No matches found.");
            }

            foreach (Candidate match in candidateManager.GetAll())
            {
                Console.WriteLine($"Patient: {match.RecipientPatient.Firstname} {match.RecipientPatient.Lastname} - HerzId: {match.DonorHeart.Id}");
            }
            Console.ReadKey();
        }
    }
}