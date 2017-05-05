using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;

namespace Eksamen2Semester.Singletonz
{
    public class LokalerKatalogSingleton
    {   
        private static LokalerKatalogSingleton _lokalerKatalogSingelton1;

        public static LokalerKatalogSingleton LokalerKatalogSingeltons
        {

            get { return _lokalerKatalogSingelton1 ?? (_lokalerKatalogSingelton1 = new LokalerKatalogSingleton()); }
        }

        public ObservableCollection<Lokale> Lokalers { get; set; }

        public LokalerKatalogSingleton()
        {
            Lokalers = new ObservableCollection<Lokale>();
        }
    }
}
