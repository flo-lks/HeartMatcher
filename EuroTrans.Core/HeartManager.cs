using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class HeartManager : IManager<DonorHeart>
    {
        public HeartManager()
        {
            LoadPatientsFromCSV("DonorHearts.csv");
        }

        List<DonorHeart> hearts = new List<DonorHeart>();

        private void LoadPatientsFromCSV(string path)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                DonorHeart heart = new(
                    id: int.Parse(parts[0]),
                    bloodtype: parts[1],
                    donorBodyweight: double.Parse(parts[2]),
                    lat: double.Parse(parts[3], System.Globalization.CultureInfo.InvariantCulture),
                    lon: double.Parse(parts[4], System.Globalization.CultureInfo.InvariantCulture)
                );
                Add(heart);
            }
        }

        public List<DonorHeart> GetAll() => hearts;
        public void Add(DonorHeart heart) => hearts.Add(heart);
        public void Remove(DonorHeart heart) => hearts.Remove(heart);
    }
}