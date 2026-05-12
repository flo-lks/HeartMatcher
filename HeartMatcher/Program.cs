using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartMatcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientManager personManager = new PatientManager();
            HeartManager heartManager = new HeartManager();
            HospitalManager hospitalManager = new HospitalManager();
            MatchManager matchManager = new MatchManager();

            // test
            Hospital hospital1 = new Hospital("Charité - Universitätsmedizin Berlin", 52.5255, 13.3783);
            Hospital hospital2 = new Hospital("Klinikum rechts der Isar München", 48.1364, 11.5991);
            Hospital hospital3 = new Hospital("Universitätsklinikum Hamburg-Eppendorf", 53.5925, 9.9754);
            Hospital hospital4 = new Hospital("Uniklinik Köln", 50.9262, 6.9189);
            Hospital hospital5 = new Hospital("Universitätsklinikum Frankfurt", 50.0931, 8.6631);
            hospitalManager.Add(hospital1);
            hospitalManager.Add(hospital2);
            hospitalManager.Add(hospital3);
            hospitalManager.Add(hospital4);
            hospitalManager.Add(hospital5);

            RecipientPatient max = new RecipientPatient("Max", "Müller", "A+", 80.0, hospital1);
            RecipientPatient anna = new RecipientPatient("Anna", "Schmidt", "0-", 65.0, hospital1);
            RecipientPatient leon = new RecipientPatient("Leon", "Schneider", "B+", 75.0, hospital2);
            RecipientPatient sophie = new RecipientPatient("Sophie", "Fischer", "AB-", 60.0, hospital2);
            RecipientPatient paul = new RecipientPatient("Paul", "Weber", "A-", 85.0, hospital3);
            RecipientPatient laura = new RecipientPatient("Laura", "Meyer", "0+", 55.0, hospital3);
            RecipientPatient tim = new RecipientPatient("Tim", "Wagner", "B-", 90.0, hospital4);
            RecipientPatient lena = new RecipientPatient("Lena", "Becker", "AB+", 70.0, hospital4);
            RecipientPatient jonas = new RecipientPatient("Jonas", "Hoffmann", "A+", 78.0, hospital5);
            RecipientPatient emma = new RecipientPatient("Emma", "Schulz", "0-", 62.0, hospital5);
            personManager.Add(max);
            personManager.Add(anna);
            personManager.Add(leon);
            personManager.Add(sophie);
            personManager.Add(paul);
            personManager.Add(laura);
            personManager.Add(tim);
            personManager.Add(lena);
            personManager.Add(jonas);
            personManager.Add(emma);

            DonorHeart heart1 = new DonorHeart("A+", 101, 82.0, 52.4120, 13.1230);
            DonorHeart heart2 = new DonorHeart("B+", 102, 73.0, 48.2105, 11.6210);
            DonorHeart heart3 = new DonorHeart("A-", 103, 87.0, 53.4890, 10.0120);
            DonorHeart heart4 = new DonorHeart("B-", 104, 88.0, 50.8520, 7.1230);
            DonorHeart heart5 = new DonorHeart("A+", 105, 76.0, 50.1230, 8.5410);
            DonorHeart heart6 = new DonorHeart("0-", 106, 64.0, 52.5000, 13.4000);
            DonorHeart heart7 = new DonorHeart("AB-", 107, 62.0, 48.1500, 11.5500);
            DonorHeart heart8 = new DonorHeart("0+", 108, 56.0, 53.5500, 9.9500);
            DonorHeart heart9 = new DonorHeart("AB+", 109, 72.0, 50.9500, 6.9500);
            DonorHeart heart10 = new DonorHeart("0-", 110, 60.0, 50.0500, 8.6000);
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

            ExtendedMatcher extendedMatcher = new ExtendedMatcher();
            extendedMatcher.Match(personManager, heartManager, matchManager);

            foreach (Match match in matchManager.GetAll())
            {
                Console.WriteLine($"Patient: {match.RecipientPatient.Firstname} {match.RecipientPatient.Lastname} - HerzId: {match.DonorHeart.Id}");
            }
            Console.ReadKey();
        }
    }
}
