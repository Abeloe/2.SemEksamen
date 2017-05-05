using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;

namespace Eksamen2Semester.Singletonz
{
    class KursusKatalogSingleton
    {
        private static KursusKatalogSingleton _kursusKatalogSingelton1;

        public static KursusKatalogSingleton KursusKatalogSingeltons
        {

            get { return _kursusKatalogSingelton1 ?? (_kursusKatalogSingelton1 = new KursusKatalogSingleton()); }
        }

        public ObservableCollection<Kursus> Kurser { get; set; }

        public KursusKatalogSingleton()
        {
            Kurser = new ObservableCollection<Kursus>();
        }
    }
}
