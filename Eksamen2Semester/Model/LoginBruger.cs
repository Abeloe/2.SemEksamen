using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
   public class LoginBruger
    {
        public string BrugerNavn { get; set; }
        public string KodeOrd { get; set; }

        public LoginBruger()
        {
            
        }

        public LoginBruger(string brugerNavn, string kodeOrd)
        {
            BrugerNavn = brugerNavn;
            KodeOrd = kodeOrd;
        }
    }
}
