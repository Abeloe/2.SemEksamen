using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
   public class Lokation
    {
        public string Adresse { get; set; }
        public string ByNavn { get; set; }
        public string Land { get; set; }

        public Lokation()
        {
            
        }

        public Lokation(string adresse, string byNavn, string land)
        {
            Adresse = adresse;
            ByNavn = byNavn;
            Land = land;
        }

       public override string ToString()
       {
           return $"Adresse: {Adresse}";
       }
    }
}
