using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
   public class LoginListe
    {
        public List<LoginBruger> LoginBrugerListe { get; set; }

        public LoginListe()
        {
            
        }

        public LoginListe(List<LoginBruger> loginBrugerListe)
        {
            LoginBrugerListe = loginBrugerListe;
        }
    }
}
