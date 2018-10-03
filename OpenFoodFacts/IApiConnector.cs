using OpenFoodFacts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenFoodFacts
{
    public interface IApiConnector
    {

        bool IsLoggedIn { get; }

        Task<bool> LoginAsync(string user, string pass);
        Task<bool> LogoutAsync();
        Task<Product> GetProductByCodeAsync(string code);
    }
}
