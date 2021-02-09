using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MathAPI.Tests
{
    public class MathAPITest
    {
        private HttpClient _client;
        private const string BaseUrl = "https://localhost:5001/";
        [SetUp]
        public void Setup()
        {
            // Maak een nieuwe HttpClientHandler
            var httpClientHandler = new HttpClientHandler();
            // Omdat de SSL certificaat self-signed is, geeft de HTTPClient standaard een error.
            // Daarom overwriten we de functie die de certificaten checkt zodat die altijd true returned
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            // Vervolgens maken we een nieuwe HttpClient met deze handler.
            _client = new HttpClient(httpClientHandler)
            {
                // Ook stellen we hier een BaseAddress in,
                // zodat we niet elke keer de 'https://localhost:5001/' voor onze URL's hoeven te zetten
                BaseAddress = new Uri(BaseUrl)
            };
        }

        [Test]
        public async Task TestAddRoute()
        {
            //Act
            var response = await _client.GetAsync("add?a=1&b=1");
            
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("2", await response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task TestAddRouteWithMissingParameters()
        {
            //Act
            var response = await _client.GetAsync("add?a=1");
            
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("U need to provide both an 'a' and a 'b' parameter", await response.Content.ReadAsStringAsync()); 
        }

        [Test]
        public async Task TestMultiplyRoute()
        {
            //Act
            var response = await _client.GetAsync("multiply?a=2&b=4");
            
            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual("8", await response.Content.ReadAsStringAsync());
        }

        [Test]
        public async Task TestMultiplyRouteWithMissingParameters()
        {
            //Act
            var response = await _client.GetAsync("multiply?b=4");
            
            //Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.AreEqual("U need to provide both an 'a' and a 'b' parameter", await response.Content.ReadAsStringAsync()); 
        }
    }
}