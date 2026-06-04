using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroTrans.Core
{
    public class PersistenceManager
    {
        public static List<string[]> ReadCSV(string fileName)
        {
            var rows = new List<string[]>();

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Path not found");
                return rows;
            }
            var lines = File.ReadAllLines(filePath).Skip(1);
            foreach (var line in lines)
            {
                string[] parts = line.Split(";");
                rows.Add(parts);
            }
            return rows;
        }
    }
}