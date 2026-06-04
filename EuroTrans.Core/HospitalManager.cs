using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class HospitalManager : IManager<Hospital>
    {
        public HospitalManager()
        {
            LoadHospitalsFromCSV("Hospitals.csv");
        }

        List<Hospital> hospitals = new List<Hospital>();

        private void LoadHospitalsFromCSV(string path)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                Hospital hospital = new(
                    id: int.Parse(parts[0]),
                    name: parts[1],
                    lat: double.Parse(parts[2], System.Globalization.CultureInfo.InvariantCulture),
                    lon: double.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture)
                );
                Add(hospital);
            }
        }

        public List<Hospital> GetAll() => hospitals;
        public void Add(Hospital hospital) => hospitals.Add(hospital);
    }
}