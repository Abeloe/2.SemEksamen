    using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
    using Eksamen2Semester.Model;
    using Eksamen2Semester.Singletonz;
using Newtonsoft.Json;

namespace Eksamen2Semester.Facade
{
    internal class DeltaFacade
    {
        public DeltaKatalogSingleton DeltaKatalogSingleton { get; set; }

        public DeltaFacade()
        {
            DeltaKatalogSingleton = DeltaKatalogSingleton.Deltagkatalogsingeltons;
        }




        public static async Task<IEnumerable<Deltager>> GetDeltagere()
        {
            const string serverUrl = "http://bos-web-api.azurewebsites.net/";

            #region GetGuest

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<Deltager> deltas = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));

                var responce = await client.GetAsync("api/Deltageres");

                if (responce.IsSuccessStatusCode)
                {
                    var Delta = responce.Content.ReadAsStringAsync().Result;

                    deltas = JsonConvert.DeserializeObject<IEnumerable<Deltager>>(Delta);
                    Singletonz.DeltaKatalogSingleton.Deltagkatalogsingeltons.Deltageres.Clear();
                    foreach (var d in deltas)
                    {
                        Singletonz.DeltaKatalogSingleton.Deltagkatalogsingeltons.Deltageres.Add(d);

                    }
                }
                return deltas;

                #endregion



            }

        }
    }
}
