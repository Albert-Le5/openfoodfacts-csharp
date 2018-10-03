using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenFoodFacts.Test
{
    [TestClass]
    public class ApiConnectorTest
    {
        [TestMethod]
        public void Login_ShouldTrue()
        {
            var api = new ApiConnector();
            var res = api.LoginAsync("test_user", "test_password").Result;
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Logout_ShouldTrue()
        {
            var api = new ApiConnector();
            var res = api.LogoutAsync().Result;
            Assert.IsTrue(res);
        }
    }
}
