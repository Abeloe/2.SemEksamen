using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;
using Eksamen2Semester.View;

namespace Eksamen2Semester.Singletonz
{
   public class LoginKatalogSingleton
    {
        private static LoginKatalogSingleton _loginKatalogSingelton1;

        public static LoginKatalogSingleton LoginKatalogSingeltons
        {

            get { return _loginKatalogSingelton1 ?? (_loginKatalogSingelton1 = new LoginKatalogSingleton()); }
        }

        public ObservableCollection<LoginBruger> Logins { get; set; }

        public LoginKatalogSingleton()
        {
            Logins = new ObservableCollection<LoginBruger>();
        }
    }
}
