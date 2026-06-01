using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EuroTrans.Core
{
    public class PersistenceManager
    {
        public void ReadCSVPatients(string path, PatientManager patientManager)
        {
            if (File.Exists(path))
            {
                string[] rows = File.ReadAllLines(path);

                foreach (string row in rows.Skip(1))
                {
                    string[] cols = row.Split(';');
                    patientManager.Add(new RecipientPatient (cols[0], cols[1], cols[2], double.Parse(cols[3]), int.Parse(cols[4])));
                }
            }
        }
    }
}