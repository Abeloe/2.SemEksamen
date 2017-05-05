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
    class LokationFacade
    {
        public LokationKatalogSingleton LokationKatalogSingleton { get; set; }

        public LokationFacade()
        {
            LokationKatalogSingleton = LokationKatalogSingleton.LokationKatalogSingletons;
        }




        public async static Task<IEnumerable<Lokation>> GetLokation()
        {
            const string serverUrl = "http://bos-web-api.azurewebsites.net/";

            #region GetLocation
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<Lokation> Locati = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));

                var responce = await client.GetAsync("api/Lokations");

                if (responce.IsSuccessStatusCode)
                {
                    var LOCA = responce.Content.ReadAsStringAsync().Result;

                    Locati = JsonConvert.DeserializeObject<IEnumerable<Lokation>>(LOCA);
                    Singletonz.LokationKatalogSingleton.LokationKatalogSingletons.Lokations.Clear();
                    foreach (var d in Locati)
                    {
                        Singletonz.LokationKatalogSingleton.LokationKatalogSingletons.Lokations.Add(d);

                    }
                }
                return Locati;
                #endregion



            }

        }
    }
}
