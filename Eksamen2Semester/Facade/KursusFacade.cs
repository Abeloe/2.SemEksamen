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
    class KursusFacade
    {
        public KursusKatalogSingleton KursusKatalogSingleton { get; set; }

        public KursusFacade()
        {
            KursusKatalogSingleton = KursusKatalogSingleton.KursusKatalogSingeltons;
        }




        public async static Task<IEnumerable<Kursus>> GetKursus()
        {
            const string serverUrl = "http://bos-web-api.azurewebsites.net/";

            #region GetKurs
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<Kursus> Kurse = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responce = await client.GetAsync("api/Kursus");

                if (responce.IsSuccessStatusCode)
                {
                    var Kurser = responce.Content.ReadAsStringAsync().Result;

                    Kurse = JsonConvert.DeserializeObject<IEnumerable<Kursus>>(Kurser);
                    Singletonz.KursusKatalogSingleton.KursusKatalogSingeltons.Kurser.Clear();
                    foreach (var d in Kurse)
                    {
                        KursusOCSingleton.Intance.SingletonOCKursus.Add(d);

                    }
                }
                return Kurse;
                #endregion



            }

        }
    }
}
