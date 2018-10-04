using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenFoodFacts.Product
{
    public interface IProductApi
    {
        Task<ProductData> GetAsync(string code);
        Task<IEnumerable<ProductData>> GetByFacets(IDictionary<string, string> query);
        Task<bool> AddNewProduct(ProductData product);
    }
}
