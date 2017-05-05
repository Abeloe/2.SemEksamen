using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
  public class BookingSingelton
    {
        private static BookingSingelton intance = new BookingSingelton();

      public static BookingSingelton Intance
      {
          get { return intance; }
      }

      public ObservableCollection<Booking> SingletonOCBooking { get; set; }

      private BookingSingelton()
      {
          SingletonOCBooking = new ObservableCollection<Booking>();
      }
    }
}
