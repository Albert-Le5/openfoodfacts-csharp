using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Models;

namespace OpenFoodFacts
{
    public class ApiConnector : IApiConnector
    {
        private static readonly Uri baseUri = new Uri("https://world.openfoodfacts.org/");
        private static readonly string apiSubUrl = "api/v0/";

        private string country;
        private string locale;
        private HttpClient client = new HttpClient();

        public ApiConnector(string country = "", string locale = "")
        {
            this.country = country;
            this.locale = locale;
        }

        #region IApiConnector
        public bool IsLoggedIn { get; private set; } = false;

        public async Task<Product> GetProductByCodeAsync(string code)
        {
            var body = await client.GetStringAsync(new Uri(baseUri, apiSubUrl + String.Format("product/{0}.json", code)));
            var json = JObject.Parse(body);
            if (json["status"].ToObject<int>() != 1) return null;
            var product = json["product"].ToObject<Product>();
            return product;
        }

        public async Task<bool> LoginAsync(string user, string pass)
        {
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign+in"));
            formVariables.Add(new KeyValuePair<string, string>("user_id", user));
            formVariables.Add(new KeyValuePair<string, string>("password", pass));
            
            var res = await client.PostAsync(new Uri(baseUri, "cgi/session.pl"), new FormUrlEncodedContent(formVariables));
            var content = await res.Content.ReadAsStringAsync();
            return content.Contains("You are connected as");
        }

        public async Task<bool> LogoutAsync()
        {
            var formVariables = new List<KeyValuePair<string, string>>(1);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign-out"));

            var res = await client.PostAsync(new Uri(baseUri, "cgi/session.pl"), new FormUrlEncodedContent(formVariables));
            var content = await res.Content.ReadAsStringAsync();
            return content.Contains("See you soon!");
        }
        #endregion IApiConnector
    }
}
