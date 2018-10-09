using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using OpenFoodFacts.Login;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OpenFoodFacts.Test.Login
{
    [TestClass]
    public class LoginApiTest
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

        private void VerifyMockCalls(Mock<HttpMessageHandler> mock, HttpMethod expectedMethod, Uri expectedUri, HttpContent expectedContent)
        {
            mock.Protected().Verify<Task<HttpResponseMessage>>(
                "SendAsync",
                Times.Exactly(1), // We expected a single external request
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == expectedMethod // We expected a POST request
                    && req.RequestUri == expectedUri // to this uri
                    && req.Content.ReadAsStringAsync().Result == expectedContent.ReadAsStringAsync().Result // with this content
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [TestMethod]
        public void LoginTest_ShouldTrue()
        {
            // Setup the handler
            var mockHandler = GetHttpMessageHandlerMock("You are connected as xxxxxxxxxxxxxxxx.");

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new LoginApi(new Uri("https://test.com/"), ref httpClient);

            // Perform test
            var user = "test_user";
            var pass = "test_password_123";
            objectToTest.LoginAsync(user, pass).Result.Should().Be(true);
            objectToTest.IsLoggedIn.Should().Be(true);

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/cgi/session.pl");
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign+in"));
            formVariables.Add(new KeyValuePair<string, string>("user_id", user));
            formVariables.Add(new KeyValuePair<string, string>("password", pass));
            var expectedContent = new FormUrlEncodedContent(formVariables);

            VerifyMockCalls(mockHandler, HttpMethod.Post, expectedUri, expectedContent);
        }

        [TestMethod]
        public void LoginTest_ShouldFalse()
        {
            // Setup the handler
            var mockHandler = GetHttpMessageHandlerMock("Invalid Username or Password.");

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new LoginApi(new Uri("https://test.com/"), ref httpClient);

            // Perform test
            var user = "test_user";
            var pass = "test_password_123";
            objectToTest.LoginAsync(user, pass).Result.Should().Be(false);
            objectToTest.IsLoggedIn.Should().Be(false);

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/cgi/session.pl");
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign+in"));
            formVariables.Add(new KeyValuePair<string, string>("user_id", user));
            formVariables.Add(new KeyValuePair<string, string>("password", pass));
            var expectedContent = new FormUrlEncodedContent(formVariables);

            VerifyMockCalls(mockHandler, HttpMethod.Post, expectedUri, expectedContent);
        }

        [TestMethod]
        public void LogoutTest_ShouldTrue()
        {
            // Setup the handler
            var mockHandler = GetHttpMessageHandlerMock("See you soon!");

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new LoginApi(new Uri("https://test.com/"), ref httpClient);

            // Perform test
            objectToTest.LogoutAsync().Result.Should().Be(true);
            objectToTest.IsLoggedIn.Should().Be(false);

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/cgi/session.pl");
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign-out"));
            var expectedContent = new FormUrlEncodedContent(formVariables);

            VerifyMockCalls(mockHandler, HttpMethod.Post, expectedUri, expectedContent);
        }

        [TestMethod]
        public void LogoutTest_ShouldFalse()
        {
            // Setup the handler
            var mockHandler = GetHttpMessageHandlerMock("See you soon !");

            // Use HttpClient with mocked HttpMessageHandler
            var httpClient = new HttpClient(mockHandler.Object);

            var objectToTest = new LoginApi(new Uri("https://test.com/"), ref httpClient);

            // Perform test
            objectToTest.LogoutAsync().Result.Should().Be(false);
            objectToTest.IsLoggedIn.Should().Be(true);

            // Check the http call was as expected
            var expectedUri = new Uri("https://test.com/cgi/session.pl");
            var formVariables = new List<KeyValuePair<string, string>>(3);
            formVariables.Add(new KeyValuePair<string, string>(".submit", "Sign-out"));
            var expectedContent = new FormUrlEncodedContent(formVariables);

            VerifyMockCalls(mockHandler, HttpMethod.Post, expectedUri, expectedContent);
        }
    }
}
