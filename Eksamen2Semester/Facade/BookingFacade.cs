using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Eksamen2Semester.Singletonz;
using Newtonsoft.Json;
using Eksamen2Semester;
using Eksamen2Semester.Model;
using Booking = Eksamen2Semester.Model.Booking;

namespace Eksamen2Semester.Facade
{
    public class BookingFacade
    {
        public BookingKatalogSingleton BookingKatalogSingelton { get; set; }

        public BookingFacade()
        {
            BookingKatalogSingelton = BookingKatalogSingleton.BookingKatalogSingeltons;
        }

        const string serverUrl = "http://bos-web-api.azurewebsites.net/";


        public static async Task<IEnumerable<Booking>> GetBooking()
        {
            #region GetBooking
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<Booking> Bookers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));

                var responce = await client.GetAsync("api/Bookings");

                if (responce.IsSuccessStatusCode)
                {
                    var Booker = responce.Content.ReadAsStringAsync().Result;

                    Bookers = JsonConvert.DeserializeObject<IEnumerable<Booking>>(Booker);
                    Singletonz.BookingKatalogSingleton.BookingKatalogSingeltons.Bookers.Clear();
                    foreach (var b in Bookers)
                    {

                        BookingSingelton.Intance.SingletonOCBooking.Add(b);


                    }
                }
                return Bookers;


                #endregion

            }  
                    
        }

        public static string PostBooking(Booking book)
        {

            Booking booke = book;
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));
                string bookMsg;

                var response = client.PostAsJsonAsync("api/Booking", booke).Result;

                if (response.IsSuccessStatusCode)
                {
                    bookMsg = "Din booking er oprettet";
                }
                else
                {
                  bookMsg =  "Booking ikke oprettet";
                }
                return bookMsg;
            }
           
        }
        
    }
}

//public static string PostGuest(Guest guest)
//{
//    Guest guesten = guest;
//    HttpClientHandler handler = new HttpClientHandler();
//    handler.UseDefaultCredentials = true;

//    using (var client = new HttpClient())
//    {
//        client.BaseAddress = new Uri(Serverurl);
//        client.DefaultRequestHeaders.Clear();
//        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("applocation/json"));
//        string guestMsg;

//        var response = client.PostAsJsonAsync("api/guests", guesten).Result;

//        if (response.IsSuccessStatusCode)
//        {
//            guestMsg = "Gæst er blevet oprettet";
//        }
//        else
//        {
//            guestMsg = "Fejl under oprettelse af gæst    " + response.StatusCode;
//        }
//        return guestMsg;
//    }
//}
