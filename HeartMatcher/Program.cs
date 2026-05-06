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

            Patient max = new Patient("Max", "Müller", 2, hospital1);
            Patient anna = new Patient("Anna", "Schmidt", 4, hospital1);
            Patient leon = new Patient("Leon", "Schneider", 1, hospital2);
            Patient sophie = new Patient("Sophie", "Fischer", 3, hospital2);
            Patient paul = new Patient("Paul", "Weber", 2, hospital3);
            Patient laura = new Patient("Laura", "Meyer", 1, hospital3);
            Patient tim = new Patient("Tim", "Wagner", 4, hospital4);
            Patient lena = new Patient("Lena", "Becker", 3, hospital4);
            Patient jonas = new Patient("Jonas", "Hoffmann", 2, hospital5);
            Patient emma = new Patient("Emma", "Schulz", 1, hospital5);
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

            Heart heart1 = new Heart(1, 101, 52.4120, 13.1230);
            Heart heart2 = new Heart(2, 102, 48.2105, 11.6210);
            Heart heart3 = new Heart(3, 103, 53.4890, 10.0120);
            Heart heart4 = new Heart(4, 104, 50.8520, 7.1230);
            Heart heart5 = new Heart(1, 105, 50.1230, 8.5410);
            Heart heart6 = new Heart(2, 106, 51.3450, 12.3780);
            Heart heart7 = new Heart(3, 107, 48.7750, 9.1830);
            Heart heart8 = new Heart(4, 108, 52.3730, 9.7330);
            Heart heart9 = new Heart(1, 109, 53.0790, 8.8010);
            Heart heart10 = new Heart(2, 110, 51.2270, 6.7730);
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
                Console.WriteLine($"Patient: {match.Patient.Firstname} {match.Patient.Lastname} - HerzId: {match.Heart.Id}");
            }
            Console.ReadKey();
        }
    }
}
