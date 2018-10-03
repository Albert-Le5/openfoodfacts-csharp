using OpenFoodFacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoodFacts
{
    public interface IApiConnector
    {
        bool Login(string user, string pass);
        bool Logout();
        Product GetProductByCode(string code);
    }
}
