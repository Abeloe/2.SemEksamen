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
    class LokalerFacade
    {
        public LokalerKatalogSingleton LokalerKatalogSingleton { get; set; }

        public LokalerFacade()
        {
            LokalerKatalogSingleton = LokalerKatalogSingleton.LokalerKatalogSingeltons;
        }




        public async static Task<IEnumerable<Lokale>> GetLokaler()
        {
            const string serverUrl = "http://bos-web-api.azurewebsites.net/";

            #region GetRooms
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<Lokale> loks = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));

                var responce = await client.GetAsync("api/Lokalers");

                if (responce.IsSuccessStatusCode)
                {
                    var LOKO = responce.Content.ReadAsStringAsync().Result;

                    loks = JsonConvert.DeserializeObject<IEnumerable<Lokale>>(LOKO);
                    Singletonz.LokalerKatalogSingleton.LokalerKatalogSingeltons.Lokalers.Clear();
                    foreach (var d in loks)
                    {
                        Singletonz.LokalerKatalogSingleton.LokalerKatalogSingeltons.Lokalers.Add(d);

                    }
                }
                return loks;
                #endregion



            }

        }
    }
}
