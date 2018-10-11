using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Product;
using System;
using System.Net.Http;

namespace OpenFoodFacts.Test.Product
{
    [TestClass]
    public class ProductDataTest
    {
        [TestMethod]
        public void ProductDataDeserialize()
        {
            HttpClient client = new HttpClient();
            var uri = new Uri("https://world.openfoodfacts.org/api/v0/");
            var task = client.GetStringAsync(new Uri(uri, "product/3222475893421.json"));
            task.Wait();
            var body = task.Result;
            var json = JObject.Parse(body);
            var product = json["product"].ToObject<ProductData>();
            Console.WriteLine(JsonConvert.SerializeObject(product, Formatting.Indented));
        }
    }
}
