using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Eksamen2Semester.Model;

namespace Eksamen2Semester
{
    class Pesitency
    {

        private const string ServerUrl = "HTTP://localhost:6463";
        //private static string eventFileName = "EventsAsJson.dat";

        #region Save Booking


        public static async void SaveBookingsAsJsonAsync(Booking bBooking)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                // Sætter base adress
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                // Fortæller hvilken fil der skal retureres i dette tilfælde Json
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));

                // Post = Create
                // Put = Update
                try
                {
                    await client.PostAsJsonAsync("api/Bookings", bBooking);


                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        #endregion


        #region Load Booking


        public static async Task<List<Booking>> LoadBookingFromJsonAsync()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                // Sætter base adress
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                // Bestemmer hvilken fil type vi gemmer i
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Applicaton/json"));

                try
                {
                    var response = client.GetAsync("api/events").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var eventdata = response.Content.ReadAsAsync<IEnumerable<Booking>>().Result;
                        return eventdata.ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                return null;
            }

        }

        #endregion


        #region Update Booking

        public static async void UpdateBooking(Booking uBooking)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                // Sætter base adress
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                // Bestemmer hvilken fil type vi gemmer i
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Applicaton/json"));

                try
                {
                    var response = client.PutAsJsonAsync(ServerUrl, uBooking).Result;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        #endregion


        #region Remove Booking


        public static async void RemoveBooking(Booking rBooking)
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {
                // Sætter base adress
                client.BaseAddress = new Uri(ServerUrl);
                client.DefaultRequestHeaders.Clear();
                // Bestemmer hvilken fil type vi gemmer i
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Applicaton/json"));

                try
                {
                    await client.DeleteAsync("api/events/" + rBooking);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        #endregion



        private class MessageDialogHelper
        {
            public static async void Show(string content, string title)
            {
                MessageDialog messageDialog = new MessageDialog(content, title);
                await messageDialog.ShowAsync();
            }
        }

    }

}


