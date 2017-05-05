using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
   public class Kursus
    {
        public int KursusId { get; set; }
        public string Adresse { get; set; }
        public string Navn { get; set; }
       public List<Deltager> DeltagerListe { get; set; }

        public Kursus()
        {
            
        }

       public Kursus(int kursusId, string adresse, string navn, List<Deltager> deltagerListe)
       {
           KursusId = kursusId;
           Adresse = adresse;
           Navn = navn;
           DeltagerListe = deltagerListe;
       }

        public override string ToString()
        {
            return $"Navn: {Navn}";
        }
    }
}
