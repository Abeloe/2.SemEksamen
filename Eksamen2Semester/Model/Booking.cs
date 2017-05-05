using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamen2Semester.Model
{
    public class Booking
    {
        private string _deltagerAntal;
        public int Id { get; set; }
        public string Name { get; set; }
        public Lokale Lokale { get; set; }
        public DateTime DateTime { get; set; }

        public string DeltagerAntal
        {
            get { return _deltagerAntal; }
            set
            {
                int tal;
                if (!int.TryParse(value, out tal))
                {
                    throw new ArgumentException("Det skal være en numerisk værdi");
                }
                if (tal < 6)
                {
                    throw new ArgumentException("Der skal være mindst 6 deltagere");
                }
                _deltagerAntal = value;
            }
        }

        // Kode til Unittesting
        //public string DeltagerAntal
        //{
        //    get { return _deltagerAntal; }
        //    set
        //    {
        //        int p = 0;
        //        if (!Int32.TryParse(value, out p))
        //        {

        //        _deltagerAntal = value;

        //        }
        //            throw new ArgumentException("Der skal være mindst 2 deltagere");

        //    }
        //}


        public Lokation BookingLokation { get; set; }

        public Booking()
        {

        }

        public Booking(string name, Lokale lokale, DateTime dateTime, string deltagerAntal, Lokation bookingLokation)
        {

            Name = name;
            Lokale = lokale;
            DateTime = dateTime;
            DeltagerAntal = deltagerAntal;
            BookingLokation = bookingLokation;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Lokale: {Lokale}, DateTime: {DateTime}, DeltagerAntal: {DeltagerAntal}, BookingLokation: {BookingLokation}";
        }
    }
}
