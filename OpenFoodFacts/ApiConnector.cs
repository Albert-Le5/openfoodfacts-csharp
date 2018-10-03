using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Models;

namespace OpenFoodFacts
{
    public class ApiConnector : IApiConnector
    {
        private static readonly Uri baseUri = new Uri("https://world.openfoodfacts.org/api/v0/");

        private string country;
        private string locale;
        private HttpClient client = new HttpClient();

        public ApiConnector(string country = "", string locale = "")
        {
            this.country = country;
            this.locale = locale;
        }

        Product IApiConnector.GetProductByCode(string code)
        {
            var task = client.GetStringAsync(new Uri(baseUri, String.Format("product/{0}.json", code)));
            task.Wait();
            var body = task.Result;
            var json = JObject.Parse(body);
            if (json["status"].ToObject<int>() != 1) return null;
            var product = json["product"].ToObject<Product>();
            return product;
        }

        bool IApiConnector.Login(string user, string pass)
        {
            throw new NotImplementedException();
        }

        bool IApiConnector.Logout()
        {
            throw new NotImplementedException();
        }
    }
}
