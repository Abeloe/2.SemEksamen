using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
    public class Deltager
    {

        public string Navn { get; set; }
        public string TelefonNr { get; set; }
        public string Email { get; set; }

        public Deltager()
        {

        }



        public Deltager(string navn, string telefonNr, string email)
        {
            Navn = navn;
            TelefonNr = telefonNr;
            Email = email;
        }

        public override string ToString()
        {
            return $"Navn: {Navn}, TelefonNr: {TelefonNr}, Email: {Email}";
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != typeof(Deltager))
            {
                return false;
            }
            Deltager com = (Deltager)obj;

            return string.Equals(Navn, com.Navn) && string.Equals(TelefonNr, com.TelefonNr) && string.Equals(Email, com.Email);
        }

    }
}
