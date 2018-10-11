using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenFoodFacts.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenFoodFacts.Test.Product
{
    [TestClass]
    public class ProductApiTest
    {
        private Mock<HttpMessageHandler> GetHttpMessageHandlerMock(string response)
        {
            // Setup the handler
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            mockHandler.Protected()
                // Setup the protected method to mock
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                // prepare the expected response of the mocked http call
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(response)
                })
                .Verifiable();
            return mockHandler;
        }

        private void VerifyMockCalls(Mock<HttpMessageHandler> mock, HttpMethod expectedMethod, Uri expectedUri)
        {
            mock.Protected().Verify<Task<HttpResponseMessage>>(
                "SendAsync",
                Times.Exactly(1), // We expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == expectedMethod // using this method
                    && req.RequestUri == expectedUri // to this uri
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }
        
        [TestMethod]
        public void GetAsyncTest()
        {
            // Setup the handler
            var json = File.ReadAllText("Product/TestProduct.json");
            var jsonData = JObject.Parse(json);
            var mockHandler = GetHttpMessageHandlerMock(json);

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new ProductApi(new Uri("https://test.com/"), ref httpClient);

            // Perform test
            var res = objectToTest.GetAsync("3222475893421").Result;
            res.Should().NotBeNull();
            res.Id.Should().Be("3222475893421");

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/api/v0/product/3222475893421.json");

            VerifyMockCalls(mockHandler, HttpMethod.Get, expectedUri);
        }

        [TestMethod]
        public void GetByFacetsTest()
        {
            // Setup the handler
            var json = File.ReadAllText("Product/TestProductsByFacets.json");
            var jsonData = JObject.Parse(json);
            var mockHandler = GetHttpMessageHandlerMock(json);

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new ProductApi(new Uri("https://test.com/"), ref httpClient);

            // Prepare query
            var query = new Dictionary<string, string>
            {
                { "language", "italian" },
                { "brand", "monoprix" }
            };

            // Perform test
            var res = objectToTest.GetByFacets(query).Result;
            res.Should().NotBeNull().And.HaveCount(1);
            res.First().Id.Should().Be("3350033164765");

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/brand/monoprix/language/italian.json");

            VerifyMockCalls(mockHandler, HttpMethod.Get, expectedUri);
        }
    }
}
