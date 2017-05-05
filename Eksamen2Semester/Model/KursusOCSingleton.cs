using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
    public class KursusOCSingleton
    {
        private static KursusOCSingleton intance = new KursusOCSingleton();

        public static KursusOCSingleton Intance
        {
            get { return intance; }
        }

        public ObservableCollection<Kursus> SingletonOCKursus { get; set; }

        private KursusOCSingleton()
        {
            SingletonOCKursus = new ObservableCollection<Kursus>();
        }
    }
}
