using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OpenFoodFacts.Login;
using OpenFoodFacts.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenFoodFacts.Test
{
    [TestClass]
    public class ApiConnectorTest
    {
        [TestMethod]
        public void GetProductByCodeAsyncTest()
        {
            var productApiMock = new Mock<IProductApi>(MockBehavior.Strict);
            var loginApiMock = new Mock<ILoginApi>();
            productApiMock.Setup(x => x.GetAsync(It.IsAny<string>()))
                .ReturnsAsync(new ProductData())
                .Verifiable();
            var objToTest = new ApiConnector("world", "en", false, loginApiMock.Object, productApiMock.Object);
            objToTest.GetProductByCodeAsync("123456789").Result.Should().NotBeNull();
            productApiMock.Verify(x => x.GetAsync(It.Is<string>(s=>s=="123456789")), Times.Once);
        }

        [TestMethod]
        public void GetProductsByFacetsTest()
        {
            var productApiMock = new Mock<IProductApi>(MockBehavior.Strict);
            var loginApiMock = new Mock<ILoginApi>();
            productApiMock.Setup(x => x.GetByFacets(It.IsAny<IDictionary<string,string>>()))
                .ReturnsAsync(new List<ProductData>())
                .Verifiable();
            var objToTest = new ApiConnector("world", "en", false, loginApiMock.Object, productApiMock.Object);
            var facets = new Dictionary<string, string>
            {
                { "testkey", "testvalue" }
            };
            objToTest.GetProductsByFacets(facets).Result.Should().NotBeNull();
            productApiMock
                .Verify(x => x.GetByFacets(It.Is<IDictionary<string, string>>(s => s == facets))
                    , Times.Once);
        }

        [TestMethod]
        public void LoginAsyncTest()
        {
            var productApiMock = new Mock<IProductApi>();
            var loginApiMock = new Mock<ILoginApi>(MockBehavior.Strict);
            loginApiMock.Setup(x => x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true)
                .Verifiable();
            var objToTest = new ApiConnector("world", "en", false, loginApiMock.Object, productApiMock.Object);
            objToTest.LoginAsync("username", "password").Result.Should().Be(true);
            loginApiMock.Verify(x => x.LoginAsync(
                It.Is<string>(s => s == "username"),
                It.Is<string>(s => s == "password"))
                , Times.Once);
        }

        [TestMethod]
        public void LogoutAsyncTest()
        {
            var productApiMock = new Mock<IProductApi>();
            var loginApiMock = new Mock<ILoginApi>(MockBehavior.Strict);
            loginApiMock.Setup(x => x.LogoutAsync())
                .ReturnsAsync(true)
                .Verifiable();
            var objToTest = new ApiConnector("world", "en", false, loginApiMock.Object, productApiMock.Object);
            objToTest.LogoutAsync().Result.Should().Be(true);
            loginApiMock.Verify(x => x.LogoutAsync(), Times.Once);
        }
    }
}
