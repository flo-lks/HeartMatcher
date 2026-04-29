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
            MatchManager matchManager = new MatchManager();

            Patient max = new Patient("Max", "Müller", 2);
            Patient anna = new Patient("Anna", "Schmidt", 4);
            Patient leon = new Patient("Leon", "Schneider", 1);
            Patient sophie = new Patient("Sophie", "Fischer", 3);
            Patient paul = new Patient("Paul", "Weber", 2);
            Patient laura = new Patient("Laura", "Meyer", 1);
            Patient tim = new Patient("Tim", "Wagner", 4);
            Patient lena = new Patient("Lena", "Becker", 3);
            Patient jonas = new Patient("Jonas", "Hoffmann", 2);
            Patient emma = new Patient("Emma", "Schulz", 1);
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

            Heart id1 = new Heart(1, 3);
            Heart id2 = new Heart(2, 1);
            Heart id3 = new Heart(3, 4);
            Heart id4 = new Heart(4, 2);
            Heart id5 = new Heart(5, 3);
            heartManager.Add(id1);
            heartManager.Add(id2);
            heartManager.Add(id3);
            heartManager.Add(id4);
            heartManager.Add(id5);

            SimpleMatcher matcher = new SimpleMatcher();
            matcher.match(personManager.GetAll(), heartManager.GetAll(), matchManager);

            foreach(Match match in matchManager.GetAll())
            {
                Console.WriteLine($"Patient: {match.Patient.Firstname} {match.Patient.Lastname} - HerzId: {match.Heart.Id}");
            }
            Console.ReadKey();
        }
    }
}
