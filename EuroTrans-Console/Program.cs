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
            PersistenceManager persistenceManager = new();

            // test
            Hospital hospital1 = new(1, "Charité - Universitätsmedizin Berlin", 52.5255, 13.3783);
            Hospital hospital2 = new(2, "Klinikum rechts der Isar München", 48.1364, 11.5991);
            Hospital hospital3 = new(3, "Universitätsklinikum Hamburg-Eppendorf", 53.5925, 9.9754);
            Hospital hospital4 = new(4, "Uniklinik Köln", 50.9262, 6.9189);
            Hospital hospital5 = new(5, "Universitätsklinikum Frankfurt", 50.0931, 8.6631);
            hospitalManager.Add(hospital1);
            hospitalManager.Add(hospital2);
            hospitalManager.Add(hospital3);
            hospitalManager.Add(hospital4);
            hospitalManager.Add(hospital5);

            persistenceManager.ReadCSVPatients(@"E:\.HHEK\Q1\INF\HeartMatcher\Patients.csv", patientManager);

            DonorHeart heart1 = new("A+", 101, 82.0, 52.4120, 13.1230);
            DonorHeart heart2 = new("B+", 102, 73.0, 48.2105, 11.6210);
            DonorHeart heart3 = new("A-", 103, 87.0, 53.4890, 10.0120);
            DonorHeart heart4 = new("B-", 104, 88.0, 50.8520, 7.1230);
            DonorHeart heart5 = new("A+", 105, 76.0, 50.1230, 8.5410);
            DonorHeart heart6 = new("0-", 106, 64.0, 52.5000, 13.4000);
            DonorHeart heart7 = new("AB-", 107, 62.0, 48.1500, 11.5500);
            DonorHeart heart8 = new("0+", 108, 56.0, 53.5500, 9.9500);
            DonorHeart heart9 = new("AB+", 109, 72.0, 50.9500, 6.9500);
            DonorHeart heart10 = new("0-", 110, 60.0, 50.0500, 8.6000);
            heartManager.Add(heart1);
            heartManager.Add(heart2);
            heartManager.Add(heart3);
            heartManager.Add(heart4);
            heartManager.Add(heart5);
            heartManager.Add(heart6);
            heartManager.Add(heart7);
            heartManager.Add(heart8);
            heartManager.Add(heart9);
            heartManager.Add(heart10);

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