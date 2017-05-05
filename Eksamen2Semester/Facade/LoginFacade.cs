using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Eksamen2Semester.Model;
using Eksamen2Semester.Singletonz;
using Eksamen2Semester.View;
using Newtonsoft.Json;

namespace Eksamen2Semester.Facade
{
    class LoginFacade
    {
        public LoginKatalogSingleton LoginKatalogSingleton { get; set; }

        public LoginFacade()
        {
            LoginKatalogSingleton = LoginKatalogSingleton.LoginKatalogSingeltons;
        }

        public async static Task<IEnumerable<LoginBruger>> GetLogin()
        {
            const string serverUrl = "http://bos-web-api.azurewebsites.net/";

            #region GetLogin

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            IEnumerable<LoginBruger> logis = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(serverUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applocation/json"));
                var responce = await client.GetAsync("api/Logins");
                if (responce.IsSuccessStatusCode)
                {
                    var LOGO = responce.Content.ReadAsStringAsync().Result;
                    logis = JsonConvert.DeserializeObject<IEnumerable<LoginBruger>>(LOGO);
                    Singletonz.LoginKatalogSingleton.LoginKatalogSingeltons.Logins.Clear();
                    foreach (var d in logis)
                    {
                        Singletonz.LoginKatalogSingleton.LoginKatalogSingeltons.Logins.Add(d);
                    }
                }
                return logis;

                #endregion
            }
        }
    }
}
    
