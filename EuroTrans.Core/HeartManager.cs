using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace EuroTrans.Core
{
    public class HeartManager : IManager<DonorHeart>
    {
        List<DonorHeart> hearts = new List<DonorHeart>();

        public HeartManager()
        {
            LoadHeartsFromCSV("DonorHearts.csv");
        }

        public List<DonorHeart> GetAll() => hearts;
        public void Add(DonorHeart heart) => hearts.Add(heart);
        public void Remove(DonorHeart heart) => hearts.Remove(heart);

        private void LoadHeartsFromCSV(string path)
        {
            List<string[]> rows = PersistenceManager.ReadCSV(path);

            foreach (var parts in rows)
            {
                DonorHeart heart = new(
                    id: int.Parse(parts[0]),
                    bloodType: parts[1],
                    donorBodyweight: double.Parse(parts[2], CultureInfo.InvariantCulture),
                    lat: double.Parse(parts[3], CultureInfo.InvariantCulture),
                    lon: double.Parse(parts[4], CultureInfo.InvariantCulture),
                    isMatched: false
                );
                Add(heart);
            }
        }

        public void WriteHeartsToCSV(string path)
        {
            List<string[]> rows = new List<string[]>();
            rows.Add(new string[]
            {
                "Heart ID",
                "BloodType",
                "DonorBodyweight",
                "Lat",
                "Lon"
            });
            foreach (DonorHeart heart in hearts)
            {
                rows.Add(new string[]
                {
                    heart.Id.ToString(),
                    heart.BloodType,
                    heart.DonorBodyweight.ToString(CultureInfo.InvariantCulture),
                    heart.Lat.ToString(CultureInfo.InvariantCulture),
                    heart.Lon.ToString(CultureInfo.InvariantCulture)
                });
            }
            PersistenceManager.WriteCSV(path, rows);
        }
    }
}