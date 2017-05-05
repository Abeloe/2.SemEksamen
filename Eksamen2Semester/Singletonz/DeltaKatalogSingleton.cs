using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;

namespace Eksamen2Semester.Singletonz
{
    public class DeltaKatalogSingleton
    {
        private static DeltaKatalogSingleton _deltagkatalogsingelton1;

        public static DeltaKatalogSingleton Deltagkatalogsingeltons
        {

            get { return _deltagkatalogsingelton1 ?? (_deltagkatalogsingelton1 = new DeltaKatalogSingleton()); }
        }

        public ObservableCollection<Deltager> Deltageres { get; set; }

        public DeltaKatalogSingleton()
        {
            Deltageres = new ObservableCollection<Deltager>();
        }
    }
}
