using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenFoodFacts.Product
{
    public class ProductApi : IProductApi
    {
        private readonly Uri baseUri;
        private readonly HttpClient client;

        public ProductApi(Uri baseUri, ref HttpClient client)
        {
            this.baseUri = baseUri;
            this.client = client;
        }

        public Task<bool> AddNewProduct(ProductData product)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductData> GetAsync(string code)
        {
            var targetUri = new Uri(baseUri, string.Join('/', URLs.ServiceApiSuffix, string.Format("product/{0}.json", code)));
            var body = await client.GetStringAsync(targetUri);
            var json = JObject.Parse(body);
            if (json["status"].ToObject<int>() != 1) return null;
            var product = json["product"].ToObject<ProductData>();
            return product;
        }

        public async Task<IEnumerable<ProductData>> GetByFacets(IDictionary<string, string> query)
        {
            var path = new List<string>();
            foreach (var kvp in query.OrderBy(x=>x.Key))
            {
                path.Add(kvp.Key); path.Add(kvp.Value);
            }
            var targetUri = new Uri(baseUri, string.Join('/', path) + ".json");

            var body = await client.GetStringAsync(targetUri);
            var json = JObject.Parse(body);
            if (json["status"].ToObject<int>() != 1) return new List<ProductData>();
            var products = json["product"].ToObject<List<ProductData>>();
            return products;
        }
    }
}
