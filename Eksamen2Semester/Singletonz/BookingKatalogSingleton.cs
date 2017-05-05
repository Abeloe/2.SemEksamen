using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;

namespace Eksamen2Semester.Singletonz
{
  public  class BookingKatalogSingleton
    {

        private static BookingKatalogSingleton _bookingKatalogSingelton1;

        public static BookingKatalogSingleton BookingKatalogSingeltons
        {

            get { return _bookingKatalogSingelton1 ?? (_bookingKatalogSingelton1 = new BookingKatalogSingleton()); }
        }

        public ObservableCollection<Booking> Bookers { get; set; }

        public BookingKatalogSingleton()
        {
            Bookers = new ObservableCollection<Booking>();
        }
    }
}
