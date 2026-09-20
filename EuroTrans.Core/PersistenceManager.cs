using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroTrans.Core
{
    public class PersistenceManager
    {
        private static string _dataDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static string DataDirectory
        {
            get => _dataDirectory;
            set
            {
                _dataDirectory = Path.GetFullPath(value);
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        private static string ResolvePath(string fileName) => Path.IsPathRooted(fileName) ? fileName : Path.Combine(DataDirectory, fileName);

        public static List<string[]> ReadCSV(string fileName)
        {
            var rows = new List<string[]>();

            string filePath = ResolvePath(fileName);
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

        private static readonly object _fileLock = new object();
        public static void WriteCSV(string fileName, List<string[]> rows)
        {
            string filePath = ResolvePath(fileName);
            string tempPath = filePath + ".tmp";

            lock (_fileLock)
            {
                using (StreamWriter writer = new StreamWriter(tempPath))
                {
                    foreach (var row in rows)
                        writer.WriteLine(string.Join(";", row));
                }
                File.Move(tempPath, filePath, overwrite: true);
            }
        }
    }
}