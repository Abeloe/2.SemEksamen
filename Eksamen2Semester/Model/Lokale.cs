using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
   public class Lokale
    {
        public string Adresse { get; set; }
        public int LokaleNr { get; set; }

        public Lokale()
        {
            
        }

        public Lokale(string adresse, int lokaleNr)
        {
            Adresse = adresse;
            LokaleNr = lokaleNr;
        }

        public override string ToString()
        {
            return $"Adresse: {Adresse}, LokaleNr: {LokaleNr}";
        }
    }
}
